namespace Babylon
{
    partial class SettingsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkParty = new System.Windows.Forms.CheckBox();
            this.chkLinkshell = new System.Windows.Forms.CheckBox();
            this.chkSay = new System.Windows.Forms.CheckBox();
            this.chkShout = new System.Windows.Forms.CheckBox();
            this.chkYell = new System.Windows.Forms.CheckBox();
            this.chkTell = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkOutParty = new System.Windows.Forms.CheckBox();
            this.chkOutLinkshell = new System.Windows.Forms.CheckBox();
            this.chkOutEcho = new System.Windows.Forms.CheckBox();
            this.grpTranslateTo = new System.Windows.Forms.GroupBox();
            this.chkSpanish = new System.Windows.Forms.CheckBox();
            this.chkJapanese = new System.Windows.Forms.CheckBox();
            this.chkGerman = new System.Windows.Forms.CheckBox();
            this.chkFrench = new System.Windows.Forms.CheckBox();
            this.chkEnglish = new System.Windows.Forms.CheckBox();
            this.cmbJapaneseTranslationEngine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpTranslateTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkParty
            // 
            this.chkParty.AutoSize = true;
            this.chkParty.Location = new System.Drawing.Point(6, 19);
            this.chkParty.Name = "chkParty";
            this.chkParty.Size = new System.Drawing.Size(50, 17);
            this.chkParty.TabIndex = 0;
            this.chkParty.Text = "Party";
            this.chkParty.UseVisualStyleBackColor = true;
            // 
            // chkLinkshell
            // 
            this.chkLinkshell.AutoSize = true;
            this.chkLinkshell.Location = new System.Drawing.Point(6, 42);
            this.chkLinkshell.Name = "chkLinkshell";
            this.chkLinkshell.Size = new System.Drawing.Size(67, 17);
            this.chkLinkshell.TabIndex = 1;
            this.chkLinkshell.Text = "Linkshell";
            this.chkLinkshell.UseVisualStyleBackColor = true;
            // 
            // chkSay
            // 
            this.chkSay.AutoSize = true;
            this.chkSay.Location = new System.Drawing.Point(6, 65);
            this.chkSay.Name = "chkSay";
            this.chkSay.Size = new System.Drawing.Size(44, 17);
            this.chkSay.TabIndex = 2;
            this.chkSay.Text = "Say";
            this.chkSay.UseVisualStyleBackColor = true;
            // 
            // chkShout
            // 
            this.chkShout.AutoSize = true;
            this.chkShout.Location = new System.Drawing.Point(6, 88);
            this.chkShout.Name = "chkShout";
            this.chkShout.Size = new System.Drawing.Size(54, 17);
            this.chkShout.TabIndex = 3;
            this.chkShout.Text = "Shout";
            this.chkShout.UseVisualStyleBackColor = true;
            // 
            // chkYell
            // 
            this.chkYell.AutoSize = true;
            this.chkYell.Location = new System.Drawing.Point(6, 132);
            this.chkYell.Name = "chkYell";
            this.chkYell.Size = new System.Drawing.Size(43, 17);
            this.chkYell.TabIndex = 4;
            this.chkYell.Text = "Yell";
            this.chkYell.UseVisualStyleBackColor = true;
            // 
            // chkTell
            // 
            this.chkTell.AutoSize = true;
            this.chkTell.Location = new System.Drawing.Point(6, 109);
            this.chkTell.Name = "chkTell";
            this.chkTell.Size = new System.Drawing.Size(43, 17);
            this.chkTell.TabIndex = 5;
            this.chkTell.Text = "Tell";
            this.chkTell.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkParty);
            this.groupBox1.Controls.Add(this.chkTell);
            this.groupBox1.Controls.Add(this.chkLinkshell);
            this.groupBox1.Controls.Add(this.chkYell);
            this.groupBox1.Controls.Add(this.chkSay);
            this.groupBox1.Controls.Add(this.chkShout);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 155);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inputs (To Translate)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkOutParty);
            this.groupBox2.Controls.Add(this.chkOutLinkshell);
            this.groupBox2.Controls.Add(this.chkOutEcho);
            this.groupBox2.Location = new System.Drawing.Point(170, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 155);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outputs (Display Translation)";
            // 
            // chkOutParty
            // 
            this.chkOutParty.AutoSize = true;
            this.chkOutParty.Location = new System.Drawing.Point(6, 42);
            this.chkOutParty.Name = "chkOutParty";
            this.chkOutParty.Size = new System.Drawing.Size(154, 17);
            this.chkOutParty.TabIndex = 0;
            this.chkOutParty.Text = "Party (only party chat input)";
            this.chkOutParty.UseVisualStyleBackColor = true;
            // 
            // chkOutLinkshell
            // 
            this.chkOutLinkshell.AutoSize = true;
            this.chkOutLinkshell.Location = new System.Drawing.Point(6, 65);
            this.chkOutLinkshell.Name = "chkOutLinkshell";
            this.chkOutLinkshell.Size = new System.Drawing.Size(161, 17);
            this.chkOutLinkshell.TabIndex = 1;
            this.chkOutLinkshell.Text = "Linkshell (only LS chat input)";
            this.chkOutLinkshell.UseVisualStyleBackColor = true;
            // 
            // chkOutEcho
            // 
            this.chkOutEcho.AutoSize = true;
            this.chkOutEcho.Location = new System.Drawing.Point(6, 19);
            this.chkOutEcho.Name = "chkOutEcho";
            this.chkOutEcho.Size = new System.Drawing.Size(51, 17);
            this.chkOutEcho.TabIndex = 3;
            this.chkOutEcho.Text = "Echo";
            this.chkOutEcho.UseVisualStyleBackColor = true;
            // 
            // grpTranslateTo
            // 
            this.grpTranslateTo.Controls.Add(this.chkSpanish);
            this.grpTranslateTo.Controls.Add(this.chkJapanese);
            this.grpTranslateTo.Controls.Add(this.chkGerman);
            this.grpTranslateTo.Controls.Add(this.chkFrench);
            this.grpTranslateTo.Controls.Add(this.chkEnglish);
            this.grpTranslateTo.Location = new System.Drawing.Point(170, 165);
            this.grpTranslateTo.Name = "grpTranslateTo";
            this.grpTranslateTo.Size = new System.Drawing.Size(177, 141);
            this.grpTranslateTo.TabIndex = 8;
            this.grpTranslateTo.TabStop = false;
            this.grpTranslateTo.Text = "Translate To...";
            // 
            // chkSpanish
            // 
            this.chkSpanish.AutoSize = true;
            this.chkSpanish.Location = new System.Drawing.Point(7, 115);
            this.chkSpanish.Name = "chkSpanish";
            this.chkSpanish.Size = new System.Drawing.Size(64, 17);
            this.chkSpanish.TabIndex = 4;
            this.chkSpanish.Text = "Español";
            this.chkSpanish.UseVisualStyleBackColor = true;
            // 
            // chkJapanese
            // 
            this.chkJapanese.AutoSize = true;
            this.chkJapanese.Location = new System.Drawing.Point(7, 92);
            this.chkJapanese.Name = "chkJapanese";
            this.chkJapanese.Size = new System.Drawing.Size(50, 17);
            this.chkJapanese.TabIndex = 3;
            this.chkJapanese.Text = "日本";
            this.chkJapanese.UseVisualStyleBackColor = true;
            // 
            // chkGerman
            // 
            this.chkGerman.AutoSize = true;
            this.chkGerman.Location = new System.Drawing.Point(7, 68);
            this.chkGerman.Name = "chkGerman";
            this.chkGerman.Size = new System.Drawing.Size(66, 17);
            this.chkGerman.TabIndex = 2;
            this.chkGerman.Text = "Deutsch";
            this.chkGerman.UseVisualStyleBackColor = true;
            // 
            // chkFrench
            // 
            this.chkFrench.AutoSize = true;
            this.chkFrench.Location = new System.Drawing.Point(7, 44);
            this.chkFrench.Name = "chkFrench";
            this.chkFrench.Size = new System.Drawing.Size(72, 17);
            this.chkFrench.TabIndex = 1;
            this.chkFrench.Text = "Française";
            this.chkFrench.UseVisualStyleBackColor = true;
            // 
            // chkEnglish
            // 
            this.chkEnglish.AutoSize = true;
            this.chkEnglish.Location = new System.Drawing.Point(7, 20);
            this.chkEnglish.Name = "chkEnglish";
            this.chkEnglish.Size = new System.Drawing.Size(60, 17);
            this.chkEnglish.TabIndex = 0;
            this.chkEnglish.Text = "English";
            this.chkEnglish.UseVisualStyleBackColor = true;
            // 
            // cmbJapaneseTranslationEngine
            // 
            this.cmbJapaneseTranslationEngine.FormattingEnabled = true;
            this.cmbJapaneseTranslationEngine.Items.AddRange(new object[] {
            "Microsoft (All)",
            "Excite.co.jp (JP only)/Microsoft (Others)"});
            this.cmbJapaneseTranslationEngine.Location = new System.Drawing.Point(3, 342);
            this.cmbJapaneseTranslationEngine.Name = "cmbJapaneseTranslationEngine";
            this.cmbJapaneseTranslationEngine.Size = new System.Drawing.Size(344, 21);
            this.cmbJapaneseTranslationEngine.TabIndex = 5;
            this.cmbJapaneseTranslationEngine.Text = "Microsoft (All)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Translation Engine:";
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbJapaneseTranslationEngine);
            this.Controls.Add(this.grpTranslateTo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(350, 500);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpTranslateTo.ResumeLayout(false);
            this.grpTranslateTo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox chkParty;
        public System.Windows.Forms.CheckBox chkLinkshell;
        public System.Windows.Forms.CheckBox chkSay;
        public System.Windows.Forms.CheckBox chkShout;
        public System.Windows.Forms.CheckBox chkYell;
        public System.Windows.Forms.CheckBox chkTell;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.CheckBox chkOutParty;
        public System.Windows.Forms.CheckBox chkOutLinkshell;
        public System.Windows.Forms.CheckBox chkOutEcho;
        public System.Windows.Forms.GroupBox grpTranslateTo;
        public System.Windows.Forms.CheckBox chkJapanese;
        public System.Windows.Forms.CheckBox chkGerman;
        public System.Windows.Forms.CheckBox chkFrench;
        public System.Windows.Forms.CheckBox chkEnglish;
        public System.Windows.Forms.CheckBox chkSpanish;
        public System.Windows.Forms.ComboBox cmbJapaneseTranslationEngine;
        private System.Windows.Forms.Label label1;


    }
}
