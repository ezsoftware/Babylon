using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using XIPlugin;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Web;
using System.Globalization;

namespace Babylon
{
    public partial class TabControl : UserControl
    {
        XIPlugin xiParent;
        public TabControl(XIPlugin parent)
        {
            InitializeComponent();
            xiParent = parent;
            cmbTranslationFrom.Items.Add(new TranslationComboBoxItem("English", "en"));
            cmbTranslationFrom.Items.Add(new TranslationComboBoxItem("Español", "es"));
            cmbTranslationFrom.Items.Add(new TranslationComboBoxItem("Deutsch", "de"));
            cmbTranslationFrom.Items.Add(new TranslationComboBoxItem("Française", "fr"));
            cmbTranslationFrom.Items.Add(new TranslationComboBoxItem("日本", "ja"));
            cmbTranslationTo.Items.Add(new TranslationComboBoxItem("English", "en"));
            cmbTranslationTo.Items.Add(new TranslationComboBoxItem("Español", "es"));
            cmbTranslationTo.Items.Add(new TranslationComboBoxItem("Deutsch", "de"));
            cmbTranslationTo.Items.Add(new TranslationComboBoxItem("Française", "fr"));
            cmbTranslationTo.Items.Add(new TranslationComboBoxItem("日本", "ja"));
        }

        public delegate void UpdateTranslationLogDelegate(String Source, String From, String To);
        public void UpdateTranslationLog(String Source, String From, String To)
        {
            if (dgvTranslationLog.InvokeRequired)
            {
                UpdateTranslationLogDelegate ugvd = new UpdateTranslationLogDelegate(UpdateTranslationLog);
                if (!dgvTranslationLog.IsDisposed && !dgvTranslationLog.Disposing)
                {
                    try
                    {
                        dgvTranslationLog.Invoke(ugvd, Source, From, To);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Babylon.DEBUG("InvalidOperationException", ex.Message, xiParent);
                    }
                }
            }
            else
            {
                if (dgvTranslationLog.Columns.Count == 0)
                {
                    dgvTranslationLog.Columns.Add("instance", "FFXI Instance");
                    dgvTranslationLog.Columns.Add("from", "From");
                    dgvTranslationLog.Columns.Add("to", "To");
                }
                dgvTranslationLog.Rows.Insert(0, Source, From, To);
                while (dgvTranslationLog.Rows.Count > 100)
                {
                    dgvTranslationLog.Rows.RemoveAt(100);
                }
            }
        }

        public delegate void UpdateStatusTextDelegate(String Text);
        public void UpdateStatusText(String Text)
        {
            if (lblInstance.InvokeRequired)
            {
                UpdateStatusTextDelegate ustd = new UpdateStatusTextDelegate(UpdateStatusText);
                if (!lblInstance.IsDisposed && !lblInstance.Disposing)
                {
                    try
                    {
                        lblInstance.Invoke(ustd, Text);
                    }
                    catch (InvalidOperationException ex)
                    {
                        String s = ex.Message;
                    }
                }
            }
            else
            {
                lblInstance.Text = Text;
                Application.DoEvents();
            }
        }

        private void btnTranslationSubmitClose_Click(object sender, EventArgs e)
        {
            pnlSubmitTranslation.Visible = false;
            txtSubmitTranslationOrigonal.Text = txtSubmitTranslationTranslation.Text = String.Empty;
        }

        private void btnTranslationSubmitSubmit_Click(object sender, EventArgs e)
        {
            string uri = "http://api.microsofttranslator.com/V2/Http.svc/AddTranslation?appId=" + Translator.APP_ID +
                "&originalText=" + txtSubmitTranslationOrigonal.Text + "&translatedText=" + txtSubmitTranslationTranslation.Text + "&from=" + ((TranslationComboBoxItem)cmbTranslationFrom.SelectedItem).Value + "&to=" + ((TranslationComboBoxItem)cmbTranslationTo.SelectedItem).Value + "&contentType=text/plain&user=" + txtSubmitTrasnlationEmail.Text.Trim();

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);

            try
            {
                WebResponse response = httpWebRequest.GetResponse();
                StreamReader srResponse = new StreamReader(response.GetResponseStream());
                Babylon.DEBUG("Translation Submission", srResponse.ReadToEnd(), xiParent);
                MessageBox.Show("Submission Sent.");
            }
            catch //(WebException ex)
            {
                //sReturn = ex.Message;
            }
            finally
            {
                btnTranslationSubmitClose_Click(null, null);
            }
        }

        private void btnSubmitTranslation_Click(object sender, EventArgs e)
        {
            pnlSubmitTranslation.Visible = true;
        }
    }
    public class TranslationComboBoxItem
    {
        public String Text;
        public String Value;

        public TranslationComboBoxItem(String Text, String Value)
        {
            this.Text = Text;
            this.Value = Value;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == typeof(TranslationComboBoxItem))
                return ((TranslationComboBoxItem)obj).Value == this.Value;
            else
                return false;
        }
        public override string ToString()
        {
            return Text;
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
