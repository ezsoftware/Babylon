using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Babylon
{
    public partial class SettingsControl : UserControl
    {
        //Note: initialize display elements here, or settings will reset to defaults
        //if tabpage has not been visited
        public SettingsControl()
        {
            InitializeComponent();
            SettingsModel settings = SettingsModel.getInstance();

            chkLinkshell.Checked = settings.Linkshell;
            chkParty.Checked = settings.Party;
            chkSay.Checked = settings.Say;
            chkTell.Checked = settings.Tell;
            chkYell.Checked = settings.Yell;
            chkShout.Checked = settings.Shout;
            chkOutEcho.Checked = settings.OutEcho;
            chkOutLinkshell.Checked = settings.OutLinkshell;
            chkOutParty.Checked = settings.OutParty;
            chkEnglish.Checked = settings.English;
            chkGerman.Checked = settings.German;
            chkFrench.Checked = settings.French;
            chkJapanese.Checked = settings.Japanese;
            chkSpanish.Checked = settings.Spanish;
            cmbJapaneseTranslationEngine.Text = settings.JPEngine;
        }
    }
}
