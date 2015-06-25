using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XIPlugin;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.IO;
using System.Net;
using System.Globalization;
using System.Diagnostics;

namespace Babylon
{
    public static class Babylon
    {
        public static Translator BabylonTranslator = new MicrosoftTranslator();
        /// <summary>
        /// Process Translation Tick of the Timer
        /// </summary>
        /// <param name="sender">timer/object sending the call</param>
        /// <param name="e">Event Arguments</param>
        public static void ThreadLoop(object BabylonParams)
        {
            BabylonParams bp = (BabylonParams)BabylonParams;
            List<String> WindowNames = new List<string>();
            Dictionary<int, int> LastCounts = new Dictionary<int, int>();
            DateTime LastUpdate = DateTime.Now.AddMilliseconds(-501);
            DEBUG("Thread Loop Started", DateTime.Now.ToString(), bp.Plugin);
            while (bp.Plugin.ThreadRun)
            {
                if (BabylonTranslator == null || BabylonTranslator.GetTranslatorName() != SettingsModel.getInstance().JPEngine)
                {
                    switch (SettingsModel.getInstance().JPEngine)
                    {
                        case "Microsoft (All)":
                            BabylonTranslator = new MicrosoftTranslator();
                            break;
                        case "Excite.co.jp (JP only)/Microsoft (Others)":
                            BabylonTranslator = new ExcitCoJP();
                            break;
                    }
                }


                try
                {
                    //loop through all instances open and scan chat log
                    WindowNames.Clear();
                    Queue<ChatLine> ChatLines = new Queue<ChatLine>();
                    foreach (int iKey in bp.windows.Keys)
                    {
                        if (!LastCounts.ContainsKey(iKey))
                            LastCounts.Add(iKey, Int32.MinValue);
                        ChatLines.Clear();
                        //Int32 iLastCount = Int32.MinValue;
                        FFXIWindow window = bp.windows[iKey];
                        WindowNames.Add(window.process.MainWindowTitle);
                        //Loop through lines in chatlog

                        if (FFACE.IsNewLine(window.ffaceHandle))
                        {

                            int iChatCount = FFACE.GetChatLineCount(window.ffaceHandle);

                            if (LastCounts[iKey] == Int32.MinValue)
                                LastCounts[iKey] = iChatCount;

                            Int32 iDelta = iChatCount - LastCounts[iKey];
                            if (iChatCount > LastCounts[iKey])
                            {
                                for (int i = iDelta - 1; i >= 0; i--)
                                    ChatLines.Enqueue(new ChatLine(window.ffaceHandle, (short)i));
                            }
                            else if (iDelta < 0)
                            {
                                iDelta = 50 - LastCounts[iKey];
                                for (int i = iChatCount - 1 + iDelta; i >= 0; i--)
                                    ChatLines.Enqueue(new ChatLine(window.ffaceHandle, (short)i));
                            }

                            LastCounts[iKey] = iChatCount;

                            while (ChatLines.Count > 0)
                            {
                                ChatLine cl = ChatLines.Dequeue();    
                                //byte[] bChatLine = new byte[400];
                                //int iSize = 400;
                                //FFACE.ChatMode cmChatMode = new FFACE.ChatMode();
                                //FFACE.GetChatLineEx(window.ffaceHandle, (short)i, bChatLine, ref iSize, ref cmChatMode);
                                if (cl.CleanLine.Contains((char)26))
                                    continue;
                                switch (cl.ChatMode)
                                {
                                    case FFACE.ChatMode.SentSay:
                                    case FFACE.ChatMode.SentShout:
                                    case FFACE.ChatMode.SentTell:
                                        BabylonTranslator.LastSent = DateTime.Now;
                                        break;
                                    case FFACE.ChatMode.RcvdLinkShell:
                                    case FFACE.ChatMode.RcvdParty:
                                    case FFACE.ChatMode.RcvdSay:
                                    case FFACE.ChatMode.RcvdShout:
                                    case FFACE.ChatMode.RcvdTell:
                                    case FFACE.ChatMode.SentLinkShell:
                                    case FFACE.ChatMode.SentParty:
                                    case (FFACE.ChatMode)11: //RcvdYell
                                        if ((cl.ChatMode == FFACE.ChatMode.SentLinkShell || cl.ChatMode == FFACE.ChatMode.SentParty))
                                            BabylonTranslator.LastSent = DateTime.Now;
                                        if ((cl.ChatMode == FFACE.ChatMode.RcvdLinkShell || cl.ChatMode == FFACE.ChatMode.SentLinkShell) && !SettingsModel.getInstance().Linkshell)
                                            break;
                                        if ((cl.ChatMode == FFACE.ChatMode.RcvdParty || cl.ChatMode == FFACE.ChatMode.SentParty) && !SettingsModel.getInstance().Party)
                                            break;
                                        if ((cl.ChatMode == FFACE.ChatMode.RcvdSay && !SettingsModel.getInstance().Say))
                                            break;
                                        if ((cl.ChatMode == FFACE.ChatMode.RcvdShout && !SettingsModel.getInstance().Shout))
                                            break;
                                        if ((cl.ChatMode == (FFACE.ChatMode)11 && !SettingsModel.getInstance().Yell))
                                            break;
                                        if (cl.ChatMode == FFACE.ChatMode.RcvdTell && !SettingsModel.getInstance().Tell)
                                            break;
                                        
                                        switch (SettingsModel.getInstance().JPEngine)
                                        {
                                            case "Microsoft (All)":
                                                ((MicrosoftTranslator)BabylonTranslator).TranslateText(cl.CleanLine, ref window, ref cl.ChatMode, bp.Plugin);
                                                break;
                                            case "Excite.co.jp (JP only)/Microsoft (Others)":
                                                ((ExcitCoJP)BabylonTranslator).TranslateText(cl.CleanLine, ref window, ref cl.ChatMode, bp.Plugin);
                                                break;
                                        }
                                        
                                        
                                        break;
                                    default:
#if DEBUG
                                        //String sDebugLine = Encoding.GetEncoding(932).GetString(bChatLine, 0, iSize - 1);
                                        //Translator.UpdateTranslationLog("DEBUG", "ChatMode: " + cmChatMode.ToString(), sDebugLine, bp.Plugin);
#endif
                                        break;
                                }
                            }
                        }
                    }
                }
                finally
                {
                    if (LastUpdate.AddMilliseconds(500) < DateTime.Now)
                    {
                        StringBuilder sbInstance = new StringBuilder();
                        for (int i = 0; i < WindowNames.Count; i++)
                        {
                            sbInstance.Append(WindowNames[i] + (WindowNames.Count - 1 != i ? ", " : ""));
                        }
                        Translator.UpdateStatusText(sbInstance.ToString(), bp.Plugin);
                        LastUpdate = DateTime.Now;
                    }
                }
                Thread.Sleep(10); //loop delay high enough to NOT dominate cp usage, but low enough to be negligable.
            }
            DEBUG("Thread Stopping", DateTime.Now.ToString(), bp.Plugin);
        }

        public static void DEBUG(String Title, String Message, XIPlugin Plugin)
        {
#if DEBUG
            Translator.UpdateTranslationLog("DEBUG", Title, Message, Plugin);
#endif
        }

        public static string CleanLine(String Line)
        {
            char SOH = (char)1;
            char STX = (char)2;
            char RS = (char)30;
            char US = (char)31;
            // change the dot to a [ for start of string
            string startingChars = System.Text.Encoding.GetEncoding(932).GetString(new byte[2] { 0x1e, 0xfc });
            if (Line.StartsWith(startingChars))
                Line = "[" + Line.Substring(2);

            Line = Line.Replace(US.ToString() + "y", String.Empty);

            if (Line.Contains(" " + RS.ToString() + STX.ToString()))
            {
                Line = Line.Replace(" " + RS.ToString() + SOH.ToString(), "**&*&!!@#$@$#$");
                Line = Line.Replace("**&*&!!@#$@$#$", " ");
            }

            Line = Line.Replace("1", "")
                .Replace(" " + RS.ToString() + STX.ToString(), " ") // green start
                .Replace(RS.ToString() + SOH.ToString(), "")   // green end
                .Replace("Ð", "")
                .Replace(US.ToString() + "{", "")
                .Replace(US.ToString() + "?", "")
                .Replace(US.ToString() + "", "")
                .Replace(US.ToString() + "·", "E")
                .Replace(RS.ToString() + "·", "[")
                .Replace(RS.ToString() + "ｷ", "[")
                .Replace(RS.ToString() + "・", "[")
                .Replace(US.ToString() + "｡", "")
                .Replace(US.ToString() + "ﾐ", "")
                .Replace("·", "");

            // trim the 1 that occasionally shows up at the end
            if (Line.EndsWith("1"))
                Line = Line.TrimEnd('1');

            Line = Regex.Replace(Line, @"^.?\??\[.+?\] ", ""); //remove timestamp

            return Line;

        }
    }

    public class BabylonParams
    {
        public Dictionary<int, FFXIWindow> windows;
        public XIPlugin Plugin;
    }
    public class StatusParams
    {
        public String Text;
        public XIPlugin Plugin;
    }
    public class TranslationLogParams
    {
        public XIPlugin Plugin;
        public String WindowTitle;
        public String From;
        public String To;
    }

    public class ChatLine
    {
        public String RawLine;
        public String CleanLine;
        public FFACE.ChatMode ChatMode;
        public Int32 LineID;

        public ChatLine(int FFACE_HANDLE, short i)
        {
            int iSize = 400;
            byte[] bChatLine = new byte[iSize];
            LineID = (Int32)i;
            ChatMode = new FFACE.ChatMode();
            FFACE.GetChatLineEx(FFACE_HANDLE, i, bChatLine, ref iSize, ref ChatMode);
            RawLine = Encoding.GetEncoding(932).GetString(bChatLine, 0, iSize - 1);
            this.CleanLine = Babylon.CleanLine(RawLine);
        }
    }
}
