using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Babylon
{
    public class SettingsModel
    {
        public bool Linkshell { get; set; }
        public bool Party { get; set; }
        public bool Shout { get; set; }
        public bool Say { get; set; }
        public bool Tell { get; set; }
        public bool Yell { get; set; }
        public bool OutEcho { get; set; }
        public bool OutLinkshell { get; set; }
        public bool OutParty { get; set; }
        public bool English { get; set; }
        public bool German { get; set; }
        public bool French { get; set; }
        public bool Japanese { get; set; }
        public bool Spanish { get; set; }
        public String JPEngine { get; set; }

        private static SettingsModel _settingsModel = null;

        SettingsModel()
        {
        }

        private void LoadSettings()
        {
            System.Configuration.AppSettingsReader reader = new System.Configuration.AppSettingsReader();

            Linkshell = getBoolSetting(reader, "Babylon.Linkshell", true);
            Party = getBoolSetting(reader, "Babylon.Party", true);
            Shout = getBoolSetting(reader, "Babylon.Shout", true);
            Say = getBoolSetting(reader, "Babylon.Say", true);
            Tell = getBoolSetting(reader, "Babylon.Tell", true);
            Yell = getBoolSetting(reader, "Babylon.Yell", true);
            OutEcho = getBoolSetting(reader, "Babylon.OutEcho", true);
            OutLinkshell = getBoolSetting(reader, "Babylon.OutLinkshell", false);
            OutParty = getBoolSetting(reader, "Babylon.OutParty", false);
            English = getBoolSetting(reader, "Babylon.English", true);
            German = getBoolSetting(reader, "Babylon.German", false);
            French = getBoolSetting(reader, "Babylon.French", false);
            Japanese = getBoolSetting(reader, "Babylon.Japanese", false);
            Spanish = getBoolSetting(reader, "Babylon.Spanish", false);
            JPEngine = getStringSetting(reader, "Babylon.JPEngine", "Microsoft (All)");
        }


        public void SaveSettings()
        {
            System.Configuration.Configuration cfg =
    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            KeyValueConfigurationCollection kv = cfg.AppSettings.Settings;

            updateKV(kv, "Babylon.Linkshell", TF10(Linkshell));
            updateKV(kv, "Babylon.Party", TF10(Party));
            updateKV(kv, "Babylon.Shout", TF10(Shout));
            updateKV(kv, "Babylon.Say", TF10(Say));
            updateKV(kv, "Babylon.Tell", TF10(Tell));
            updateKV(kv, "Babylon.Yell", TF10(Yell));
            updateKV(kv, "Babylon.OutEcho", TF10(OutEcho));
            updateKV(kv, "Babylon.OutLinkshell", TF10(OutLinkshell));
            updateKV(kv, "Babylon.OutParty", TF10(OutParty));
            updateKV(kv, "Babylon.English", TF10(English));
            updateKV(kv, "Babylon.German", TF10(German));
            updateKV(kv, "Babylon.French", TF10(French));
            updateKV(kv, "Babylon.Japanese", TF10(Japanese));
            updateKV(kv, "Babylon.Spanish", TF10(Spanish));
            updateKV(kv, "Babylon.JPEngine", JPEngine);

            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

        }

        private void updateKV(KeyValueConfigurationCollection kv, string key_name, string value_string)
        {
            kv.Remove(key_name);
            kv.Add(key_name, value_string);
        }

        public static SettingsModel getInstance()
        {
            if (_settingsModel == null)
            {
                _settingsModel = new SettingsModel();

                _settingsModel.LoadSettings();
            }


            return _settingsModel;
        }

        private string TF10(bool v)
        {
            return v ? "1" : "0";
        }

        bool getBoolSetting(System.Configuration.AppSettingsReader reader, string valueName, bool default_value)
        {
            try
            {
                Object o = reader.GetValue(valueName, typeof(int));
                if (o == null)
                    return default_value;
                return 0 != (int)o;
            }
            catch (InvalidOperationException)
            {
                return default_value;
            }
        }

        byte getByteSetting(System.Configuration.AppSettingsReader reader, string valueName, byte default_value)
        {
            try
            {
                Object o = reader.GetValue(valueName, typeof(int));
                if (o == null)
                    return default_value;
                return (byte)(int)o;
            }
            catch (InvalidOperationException)
            {
                return default_value;
            }
        }

        float getFloatSetting(System.Configuration.AppSettingsReader reader, string valueName, float default_value)
        {
            try
            {
                Object o = reader.GetValue(valueName, typeof(float));
                if (o == null)
                    return default_value;
                return (float)o;
            }
            catch (InvalidOperationException)
            {
                return default_value;
            }
        }

        string getStringSetting(System.Configuration.AppSettingsReader reader, string valueName, string default_value)
        {
            try
            {
                Object o = reader.GetValue(valueName, typeof(string));
                if (o == null)
                    return default_value;
                return (string)o;
            }
            catch (InvalidOperationException)
            {
                return default_value;
            }
        }
    }

}
