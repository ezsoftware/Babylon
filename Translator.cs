using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XIPlugin;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Globalization;
using System.Web;
using System.Threading;

namespace Babylon
{
    public class Translator
    {
        public const string APP_ID = "2E61FFF16E85327AFCC8C16D49FB73159D7AE8A5"; //PLEASE DO NOT USE THIS APPID IN YOUR OWN PROGRAMS, ITS REGISTERED TO THIS APPLICATION
        public Regex SameAsRegex = new Regex(@"[ \\\.\+\*\?\^\$\[\]\(\)\|\{\/\'\#!@%&_\-1234567890\=・]", RegexOptions.Compiled);
        public String GetLanguageCode(String Text)
        {
            String sReturn = String.Empty;

            GroupCollection gMatch = Regex.Match(Text, @"^(.*?> |.*?\) |.*?: )?(.*?)$").Groups; //seperates the name in say/tell/shout/party/ls from the content

            String sName = String.Empty;
            String sText = String.Empty;
            if (gMatch.Count == 1)
            {
                sText = gMatch[0].Value;
            }
            else
            {
                sName = gMatch[1].Value;
                sText = gMatch[2].Value;
            }
            sText = sText.Replace("・", " ");

            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Detect?appId=" + APP_ID +
                "&text=" + HttpUtility.UrlEncode(sText.Replace('<', (char)5).Replace('>', (char)6));

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);

            WebResponse response = null;
            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    String Response = sr.ReadToEnd();
                    sReturn = Regex.Matches(Response, "<string.*?>(.*?)</string>", RegexOptions.Multiline)[0].Groups[1].Value;
                    sReturn = RemoveDiacritics(HttpUtility.HtmlDecode(HttpUtility.UrlDecode(sReturn)).Replace((char)5, '<').Replace((char)6, '>')).Replace("&amp;", "&");
                }
            }
            catch //(WebException ex)
            {
                //sReturn = ex.Message;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
            return sReturn;
        }
        public string RemoveDiacritics(string stIn)
        {
            string stFormD = stIn.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            String sReturn;
            try
            {
                Int32 iLastAppendedBaseChar = 0;
                for (int ich = 0; ich < stFormD.Length; ich++)
                {
                    UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                    if (uc != UnicodeCategory.NonSpacingMark || iLastAppendedBaseChar > 0x7F)
                    {
                        iLastAppendedBaseChar = (Int32)stFormD[ich];
                        sb.Append(stFormD[ich]);
                    }
                }
            }
            catch
            {
                sb.Length = 0;
                sb.Append(stIn);
            }
            finally
            {
                sReturn = (sb.ToString().Normalize(NormalizationForm.FormC));
            }
            return sReturn;
        }
        public String GetDisplayText(String Text, String Result)
        {
            String NoChange = String.Empty;
            return IsSameTranslated(Text, Result) ? NoChange : Result;
        }
        public Boolean IsSameTranslated(String Text, String Result)
        {
            return SameAsRegex.Replace(Result.ToLower(), "") == SameAsRegex.Replace(Text.ToLower(), "");
        }
        public DateTime LastSent = DateTime.MinValue;

        public void ShowMessage(ref FFXIWindow window, String From, String To, ref FFACE.ChatMode cmChatMode, XIPlugin Plugin)
        {
            if (To.Length == 0)
                return;

            String EncodedTo = EncodeShiftJIS(To);

            UpdateTranslationLog(window.process.MainWindowTitle, From, To, Plugin);

            if (SettingsModel.getInstance().OutEcho)
            {
                WindowerHelper.CKHSendString(window.keyboardHandle, String.Format("//input /echo {0}", EncodedTo));
            }
            if (SettingsModel.getInstance().OutLinkshell && (cmChatMode == FFACE.ChatMode.RcvdLinkShell || cmChatMode == FFACE.ChatMode.SentLinkShell))
            {
                WaitForLastSent();
                WindowerHelper.CKHSendString(window.keyboardHandle, String.Format("//input /l {0}", ((char)26).ToString() + EncodedTo));
                LastSent = DateTime.Now;
            }
            if (SettingsModel.getInstance().OutParty && (cmChatMode == FFACE.ChatMode.RcvdParty || cmChatMode == FFACE.ChatMode.SentParty))
            {
                WaitForLastSent();
                WindowerHelper.CKHSendString(window.keyboardHandle, String.Format("//input /p {0}", ((char)26).ToString() + EncodedTo));
                LastSent = DateTime.Now;
            }
        }
        public void WaitForLastSent()
        {
            while (LastSent.AddSeconds(1) > DateTime.Now)
            {
                Thread.Sleep(100);
            }
        }
        public String EncodeShiftJIS(String To)
        {
            // Thanks to Iryoku for the following to fix Shift-JIS with windower!
            Byte[] bytes = Encoding.GetEncoding(932).GetBytes(To);

            StringBuilder buffer = new StringBuilder();
            foreach (byte B in bytes)
            {
                if (B <= 0x7F)
                {
                    buffer.Append((char)B);
                }
                else
                {
                    buffer.AppendFormat("\\x{0:X2}", B);
                }
            }
            return buffer.ToString();
        }
        public static void UpdateStatusText(String Text, XIPlugin Plugin)
        {
            Thread tUpdateStatusText = new Thread(UpdateStatusTextTT);
            StatusParams sp = new StatusParams();
            if (Text.Trim() == String.Empty)
                sp.Text = "Waiting for an instance...";
            else
                sp.Text = "Monitoring the instance(s) of: " + Text;
            sp.Plugin = Plugin;
            tUpdateStatusText.Start(sp);
        }
        public static void UpdateStatusTextTT(object StatusParam)
        {
            StatusParams sp = (StatusParams)StatusParam;
            if (sp.Plugin.TabControl != null)
                sp.Plugin.TabControl.UpdateStatusText(sp.Text);
        }

        public static void UpdateTranslationLog(String WindowTitle, String From, String To, XIPlugin Plugin)
        {
            Thread tUpdateTransLog = new Thread(UpdateTranslationLogTT);
            TranslationLogParams tp = new TranslationLogParams();
            tp.Plugin = Plugin;
            tp.WindowTitle = WindowTitle;
            tp.From = From;
            tp.To = To;
            tUpdateTransLog.Start(tp);
        }
        public static void UpdateTranslationLogTT(object TranslationParams)
        {
            TranslationLogParams tp = (TranslationLogParams)TranslationParams;
            if (tp.Plugin.TabControl != null)
                tp.Plugin.TabControl.UpdateTranslationLog(tp.WindowTitle, tp.From, tp.To);
        }
        
        
        public void TranslateText(String Text, ref FFXIWindow window, ref FFACE.ChatMode cmChatMode, XIPlugin Plugin) { }
        public string Translate(String Text, String From, String To) {return String.Empty;}
        public String GetTranslatorName() {return String.Empty;}
        public String GetTranslatedText(String Text, String From, String To) { return Text; }
    }

    public class MicrosoftTranslator : Translator
    {
        public new void TranslateText(String Text, ref FFXIWindow window, ref FFACE.ChatMode cmChatMode, XIPlugin Plugin)
        {
            String sFromCode = GetLanguageCode(Text);
            String Result = String.Empty;

            if (SettingsModel.getInstance().English)
            {
                Result = GetTranslatedText(Text, sFromCode, "en");
                ShowMessage(ref window, Text, GetDisplayText(Text, Result), ref cmChatMode, Plugin);
            }
            if (SettingsModel.getInstance().German)
            {
                Result = GetTranslatedText(Text, sFromCode, "de");
                ShowMessage(ref window, Text, GetDisplayText(Text, Result), ref cmChatMode, Plugin);
            }
            if (SettingsModel.getInstance().French)
            {
                Result = GetTranslatedText(Text, sFromCode, "fr");
                ShowMessage(ref window, Text, GetDisplayText(Text, Result), ref cmChatMode, Plugin);
            }
            if (SettingsModel.getInstance().Japanese)
            {
                Result = GetTranslatedText(Text, sFromCode, "ja");
                ShowMessage(ref window, Text, GetDisplayText(Text, Result), ref cmChatMode, Plugin);
            }
            if (SettingsModel.getInstance().Spanish)
            {
                Result = GetTranslatedText(Text, sFromCode, "es");
                ShowMessage(ref window, Text, GetDisplayText(Text, Result), ref cmChatMode, Plugin);
            }
        }
        public new String GetTranslatedText(String Text, String From, String To)
        {
            return Translate(Text, From, To);
        }
        public new string Translate(String Text, String From, String To)
        {
            String sReturn = String.Empty;

            GroupCollection gMatch = Regex.Match(Text, @"^(.*?> |.*?\) |.*?: )?(.*?)$").Groups; //seperates the name in say/tell/shout/party/ls from the content

            String sName = String.Empty;
            String sText = String.Empty;
            if (gMatch.Count == 1)
            {
                sText = gMatch[0].Value;
            }
            else
            {
                sName = gMatch[1].Value;
                sText = gMatch[2].Value;
            }
            sText = sText.Replace("・", " ");

            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?appId=" + APP_ID +
                "&text=" + HttpUtility.UrlEncode(sText.Replace('<', (char)5).Replace('>', (char)6)) + "&to=" + To + "&contentType=text/plain";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);

            WebResponse response = null;
            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    String Response = sr.ReadToEnd();
                    sReturn = Regex.Matches(Response, "<string.*?>(.*?)</string>", RegexOptions.Multiline)[0].Groups[1].Value;
                    sReturn = sName + RemoveDiacritics(HttpUtility.HtmlDecode(HttpUtility.UrlDecode(sReturn)).Replace((char)5, '<').Replace((char)6, '>')).Replace("&amp;", "&");
                }
            }
            catch //(WebException ex)
            {
                //sReturn = ex.Message;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
            return sReturn;
        }
        public new string GetTranslatorName()
        {
            return "Microsoft (All)";
        }
        public new String GetLanguageCode(String Text)
        {
            return String.Empty;
        }
    }

    public class ExcitCoJP : Translator
    {
        MicrosoftTranslator mTranslate = new MicrosoftTranslator();
        public new void TranslateText(String Text, ref FFXIWindow window, ref FFACE.ChatMode cmChatMode, XIPlugin Plugin)
        {
            String sFromCode = GetLanguageCode(Text);
            String Result = String.Empty;

            if (SettingsModel.getInstance().English)
            {
                Result = GetTranslatedText(Text, sFromCode, "en");
                ShowMessage(ref window, Text, GetDisplayText(Text, Result), ref cmChatMode, Plugin);
            }
            if (SettingsModel.getInstance().German)
            {
                Result = GetTranslatedText(Text, sFromCode, "de");
                ShowMessage(ref window, Text, GetDisplayText(Text, Result), ref cmChatMode, Plugin);
            }
            if (SettingsModel.getInstance().French)
            {
                Result = GetTranslatedText(Text, sFromCode, "fr");
                ShowMessage(ref window, Text, GetDisplayText(Text, Result), ref cmChatMode, Plugin);
            }
            if (SettingsModel.getInstance().Japanese)
            {
                Result = GetTranslatedText(Text, sFromCode, "ja");
                ShowMessage(ref window, Text, GetDisplayText(Text, Result), ref cmChatMode, Plugin);
            }
            if (SettingsModel.getInstance().Spanish)
            {
                Result = GetTranslatedText(Text, sFromCode, "es");
                ShowMessage(ref window, Text, GetDisplayText(Text, Result), ref cmChatMode, Plugin);
            }
        }
        public new String GetTranslatedText(String Text, String From, String To)
        {
            if (From == To)
                return Text;
            if ((From == "ja" || From == "en") && (To == "ja" || To == "en"))
                return Translate(Text, From, To);
            return mTranslate.Translate(Text, From, To);
        }
        public new string Translate(String Text, String From, String To)
        {
            String sReturn = String.Empty;
            String sURL;
            if (From == "en")
                sURL = "http://www.excite.co.jp/world/english/?_token=04b41f59d3ac7&wb_lp=ENJA&swb_lp=&count_translation=0&re_translation=&before=";
            else if (From == "ja")
                sURL = "http://www.excite.co.jp/world/english/?_token=04b41f59d3ac7&wb_lp=JAEN&swb_lp=&count_translation=0&re_translation=&before=";
            else
                return mTranslate.Translate(Text, From, To);

            GroupCollection gMatch = Regex.Match(Text, @"^(.*?> |.*?\) |.*?: )?(.*?)$").Groups; //seperates the name in say/tell/shout/party/ls from the content

            String sName = String.Empty;
            String sText = String.Empty;
            if (gMatch.Count == 1)
            {
                sText = gMatch[0].Value;
            }
            else
            {
                sName = gMatch[1].Value;
                sText = gMatch[2].Value;
            }
            sText = sText.Replace("・", " ");

            string uri = sURL + HttpUtility.UrlEncode(sText.Replace('<', (char)5).Replace('>', (char)6));

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);

            WebResponse response = null;
            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    String Response = sr.ReadToEnd();
                    sReturn = Regex.Matches(Response, @"<textarea.*?id=""after"".*?>(.*?)</textarea>", RegexOptions.Multiline)[0].Groups[1].Value;
                    sReturn = sName + RemoveDiacritics(HttpUtility.HtmlDecode(HttpUtility.UrlDecode(sReturn)).Replace((char)5, '<').Replace((char)6, '>')).Replace("&amp;", "&");
                    sReturn = sReturn.Replace("&#010;", "").Trim().Replace("\n", "").Replace("\r", "");
                }
            }
            catch //(WebException ex)
            {
                //sReturn = ex.Message;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
            return sReturn;
        }
        public new string GetTranslatorName()
        {
            return "Excite.co.jp (JP only)/Microsoft (Others)";
        }
    }
}
