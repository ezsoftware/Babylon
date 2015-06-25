using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XIPlugin;
using System.Windows.Forms;
using NLog;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Web;
using System.Threading;
using System.Collections.Specialized;

namespace Babylon
{
    public class XIPlugin : XIPluginInterface, XIMultiInstancePlugin
    {
        /*
         * Creates a NLog logger for this class.  Try to use the correct
         * logging level when logging information (from lowest to highest):
         * Trace: The lowest level, use for fine detail.  i.e. entering/exiting logging
         * Debug: Information on the application flow.  Use for debugging info during
         * development.  This is the lowest level that appears in the console by default.
         * Info: Used for interesting runtime events.  Starting/stopped logging should go here
         * Warn: Used for runtime conditions that are bad, but not necessarily a dealbreaker.  
         * This is the lowest level that is logged to a file by default.
         * Error: Pretty obvious, these are serious problems.
         * 
         * The inclusion of NLog is to encourage thorough logging.  Ideally, all a user should
         * need to do in order to provide precise logs in the event of an error is to change to the 
         * appropriate logging level and send in their text log.
         */
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private TabControl tabControl;
        public TabControl TabControl { get { return tabControl; } }

        public Boolean ThreadRun = false;
        private Thread LoopThread;

        /*
         * SettingsControl object, need to hang onto a pointer in order
         * to properly handle save calls
         */
        private SettingsControl settingsControl;

        /*
         * This dictionary holds on to the ffxi instance list, as a dictionary 
         * with the format:
         * [processId => FFXIWindow]
         */
        public Dictionary<int, FFXIWindow> windows;


        /*
         * The startPlugin call is used to setup any necessary data or 
         * callbacks for the plugin.  This is where you would setup
         * low level hardware callbacks for plugins with message support, or
         * initialize any fface/windower text fields
         */
        public void startPlugin(Form mainApp)
        {
            logger.Debug("Starting Babylon");
            StartBabylonThread();
        }
        private void StartBabylonThread()
        {
            if (LoopThread == null)
            {
                ThreadRun = true;
                BabylonParams bp = new BabylonParams();
                bp.Plugin = this;
                bp.windows = windows;
                LoopThread = new Thread(Babylon.ThreadLoop);
                LoopThread.Start(bp);
            }
        }
        private void StopBabylonThread()
        {
            ThreadRun = false; //Should allow thread to finish and shut down gracefully
            if(LoopThread != null) //if program is shut down after FFXI the thread will already be shut down and LoopThread will be null
                LoopThread.Join();
            LoopThread = null;
        }

        /*
         * Plugin name.
         */
        public string Name
        {
            get
            {
                return "Babylon";
            }
        }

        /*
         * This method is called in different contexts depending on the
         * plugin type.  For a multi instance plugin, this is called every time a 
         * ffxi window is created or exits, along with on creation.
         * For a single instance plugin, this is only called at creation.
         */
        public void setPluginContext(XIPluginContext context)
        {
            logger.Trace("Plugin Context updated");
            if (ThreadRun) //Stop Thread if Running
                StopBabylonThread();

            windows = context.windows;

            //restart Babylon Thread
            if (windows.Count > 0)
                StartBabylonThread();

            StringBuilder sbInstance = new StringBuilder();
            for (int i = 0; i < windows.Keys.Count; i++ )
            {
                int iKey = windows.Keys.ToList<Int32>()[i];
                sbInstance.Append(windows[iKey].process.MainWindowTitle + (windows.Count - 1 != i ? ", " : ""));
            }
            if (sbInstance.Length > 0)
                Translator.UpdateStatusText(sbInstance.ToString(), this);
            else if(tabControl != null)
                tabControl.UpdateStatusText("waiting for instance...");
        }

        /*
         * This method is called when the plugin needs to terminate.  
         * If the plugin thread is still active some time after calling this, 
         * it will be force stopped.  Clean up any windower or fface
         * text boxes here, take care of any timers, etc.
         */
        public void stopPlugin()
        {
            StopBabylonThread();
        }

        /*
         * This returns the keyboard command associated with this plugin.  Any 
         * windower input matching this command will be sent to the processCommand 
         * method in this plugin.  If no keyboard command is necessary for a plugin,
         * return null from this method.
         */
        public string Command
        {
            get
            {
                return "babylon";
            }
        }

        /*
         * This method is called when a matching keyboard command is found.  
         * For example, the command for this plugin is "simple", typing
         * "//simple test 1 2 3" into the chatline will call this method with a
         * XICommandContext object with args of ["test", "1", "2", "3"]
         * It is important to note that processCommand is called in a new
         * thread, so be sure to use threadsafe access to data
         */
        public void processCommand(object args)
        {
            XICommandContext xic = (XICommandContext)args;
            List<String> commandArgs = xic.args;

            logger.Debug("CommandArgs from pid " + xic.pid + ": ");
            StringCollection scText = new StringCollection();
            String sLang = "en";
            String sOutput = "p";
            for (int i = 0; i < commandArgs.Count; i++)
            {
                logger.Debug(commandArgs[i]);
                switch (i)
                {
                    case 0:
                        sLang = commandArgs[i];
                        break;
                    case 1:
                        sOutput = commandArgs[i];
                        break;
                    default:
                        scText.Add(commandArgs[i]);
                        break;
                }
            }
            if (scText.Count > 0)
            {
                String[] saText = new String[scText.Count];
                scText.CopyTo(saText, 0);
                String Text = String.Join(" ", saText);
                FFXIWindow window = null;
                foreach(int iKey in windows.Keys)
                {
                    FFXIWindow w = windows[iKey];
                    if(w.process.Id == xic.pid)
                        window = w;
                }

                if (window != null)
                {
                    String sTranslatedText = String.Empty;
                    String sFrom = Babylon.BabylonTranslator.GetLanguageCode(Text);
                    if (SettingsModel.getInstance().JPEngine == "Microsoft (All)")
                        sTranslatedText = ((MicrosoftTranslator)Babylon.BabylonTranslator).GetTranslatedText(Text, sFrom, sLang);
                    else if (SettingsModel.getInstance().JPEngine == "Excite.co.jp (JP only)/Microsoft (Others)")
                        sTranslatedText = ((ExcitCoJP)Babylon.BabylonTranslator).GetTranslatedText(Text, sFrom, sLang);

                    String sText = Babylon.BabylonTranslator.EncodeShiftJIS(sTranslatedText);
                    switch (sOutput)
                    {
                        case "p":
                            WindowerHelper.CKHSendString(window.keyboardHandle, String.Format("//input /p {0}", sText));
                            tabControl.UpdateTranslationLog(window.process.MainWindowTitle, "babylon " + sLang + " p " + Text, "/p " + sText);
                            break;
                        case "l":
                            WindowerHelper.CKHSendString(window.keyboardHandle, String.Format("//input /l {0}", sText));
                            tabControl.UpdateTranslationLog(window.process.MainWindowTitle, "babylon " + sLang + " p " + Text, "/l " + sText);
                            break;
                        default:
                            WindowerHelper.CKHSendString(window.keyboardHandle, String.Format("//input {0} {1}", sOutput, sText));
                            tabControl.UpdateTranslationLog(window.process.MainWindowTitle, String.Format("babylon {0} {1} {2}", sLang, sOutput, Text), sOutput + sText);
                            break;
                    }
                }
            }
        }

        /*
         * Plugin description, this shows up in the plugin selection box
         */
        public string Description
        {
            get
            {
                return "Auto-Translate chat";
            }
        }

        /*
         * This should return the display tab of the plugin, if one is needed.
         * For plugins that do not require a display tab, return null.
         */
        public TabPage DisplayTab
        {
            get
            {
                TabPage t = new TabPage(Name);
                tabControl = new TabControl(this);
                t.Controls.Add(tabControl);
                return t;
            }
        }

        /*
         * This should return the settings tab of the plugin, if one is needed.
         * For plugins that do not require a settings tab, return null.
         */
        public TabPage SettingsTab
        {
            get
            {
                if (settingsControl == null || settingsControl.IsDisposed)
                {
                    settingsControl = new SettingsControl();
                }
                TabPage t = new TabPage(Name);
                t.Controls.Add(settingsControl);
                return t;
            }
        }

        /*
         * This method is called when settings should be saved.  It is expected that
         * the plugin will read in settings from the SettingsTab, and save them as necessary.
         */
        public void saveSettings()
        {
            SettingsModel settings = SettingsModel.getInstance();

            settings.Linkshell = settingsControl.chkLinkshell.Checked;
            settings.Party = settingsControl.chkParty.Checked;
            settings.Say = settingsControl.chkSay.Checked;
            settings.Shout = settingsControl.chkShout.Checked;
            settings.Tell = settingsControl.chkTell.Checked;
            settings.Yell = settingsControl.chkYell.Checked;
            settings.OutEcho = settingsControl.chkOutEcho.Checked;
            settings.OutParty = settingsControl.chkOutParty.Checked;
            settings.OutLinkshell = settingsControl.chkOutLinkshell.Checked;
            settings.English = settingsControl.chkEnglish.Checked;
            settings.German = settingsControl.chkGerman.Checked;
            settings.French = settingsControl.chkFrench.Checked;
            settings.Japanese = settingsControl.chkJapanese.Checked;
            settings.Spanish = settingsControl.chkSpanish.Checked;
            settings.JPEngine = settingsControl.cmbJapaneseTranslationEngine.Text;

            logger.Debug("Saving settings");
            settings.SaveSettings();
        }


        
    }
}
