namespace Babylon
{
    partial class TabControl
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
            this.dgvTranslationLog = new System.Windows.Forms.DataGridView();
            this.lblInstance = new System.Windows.Forms.Label();
            this.pnlSubmitTranslation = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTranslationTo = new System.Windows.Forms.ComboBox();
            this.cmbTranslationFrom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTranslationSubmitClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubmitTranslationTranslation = new System.Windows.Forms.TextBox();
            this.txtSubmitTranslationOrigonal = new System.Windows.Forms.TextBox();
            this.txtSubmitTrasnlationEmail = new System.Windows.Forms.TextBox();
            this.btnTranslationSubmitSubmit = new System.Windows.Forms.Button();
            this.btnTrasnlationSubmitCancel = new System.Windows.Forms.Button();
            this.btnSubmitTranslation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTranslationLog)).BeginInit();
            this.pnlSubmitTranslation.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTranslationLog
            // 
            this.dgvTranslationLog.AllowUserToAddRows = false;
            this.dgvTranslationLog.AllowUserToDeleteRows = false;
            this.dgvTranslationLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTranslationLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTranslationLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTranslationLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTranslationLog.Location = new System.Drawing.Point(0, 36);
            this.dgvTranslationLog.Name = "dgvTranslationLog";
            this.dgvTranslationLog.Size = new System.Drawing.Size(650, 411);
            this.dgvTranslationLog.TabIndex = 0;
            // 
            // lblInstance
            // 
            this.lblInstance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstance.Location = new System.Drawing.Point(121, 3);
            this.lblInstance.Name = "lblInstance";
            this.lblInstance.Size = new System.Drawing.Size(526, 30);
            this.lblInstance.TabIndex = 1;
            this.lblInstance.Text = "Waiting for an instance...";
            this.lblInstance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlSubmitTranslation
            // 
            this.pnlSubmitTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSubmitTranslation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSubmitTranslation.Controls.Add(this.label6);
            this.pnlSubmitTranslation.Controls.Add(this.cmbTranslationTo);
            this.pnlSubmitTranslation.Controls.Add(this.cmbTranslationFrom);
            this.pnlSubmitTranslation.Controls.Add(this.label5);
            this.pnlSubmitTranslation.Controls.Add(this.btnTranslationSubmitClose);
            this.pnlSubmitTranslation.Controls.Add(this.label4);
            this.pnlSubmitTranslation.Controls.Add(this.label2);
            this.pnlSubmitTranslation.Controls.Add(this.label1);
            this.pnlSubmitTranslation.Controls.Add(this.label3);
            this.pnlSubmitTranslation.Controls.Add(this.txtSubmitTranslationTranslation);
            this.pnlSubmitTranslation.Controls.Add(this.txtSubmitTranslationOrigonal);
            this.pnlSubmitTranslation.Controls.Add(this.txtSubmitTrasnlationEmail);
            this.pnlSubmitTranslation.Controls.Add(this.btnTranslationSubmitSubmit);
            this.pnlSubmitTranslation.Controls.Add(this.btnTrasnlationSubmitCancel);
            this.pnlSubmitTranslation.Location = new System.Drawing.Point(146, 125);
            this.pnlSubmitTranslation.Name = "pnlSubmitTranslation";
            this.pnlSubmitTranslation.Size = new System.Drawing.Size(363, 187);
            this.pnlSubmitTranslation.TabIndex = 2;
            this.pnlSubmitTranslation.Visible = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(214, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "To:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTranslationTo
            // 
            this.cmbTranslationTo.FormattingEnabled = true;
            this.cmbTranslationTo.Location = new System.Drawing.Point(248, 116);
            this.cmbTranslationTo.Name = "cmbTranslationTo";
            this.cmbTranslationTo.Size = new System.Drawing.Size(100, 21);
            this.cmbTranslationTo.TabIndex = 5;
            // 
            // cmbTranslationFrom
            // 
            this.cmbTranslationFrom.FormattingEnabled = true;
            this.cmbTranslationFrom.Location = new System.Drawing.Point(98, 116);
            this.cmbTranslationFrom.Name = "cmbTranslationFrom";
            this.cmbTranslationFrom.Size = new System.Drawing.Size(100, 21);
            this.cmbTranslationFrom.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Traslate From:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTranslationSubmitClose
            // 
            this.btnTranslationSubmitClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTranslationSubmitClose.BackColor = System.Drawing.Color.Red;
            this.btnTranslationSubmitClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTranslationSubmitClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTranslationSubmitClose.Location = new System.Drawing.Point(330, 0);
            this.btnTranslationSubmitClose.Name = "btnTranslationSubmitClose";
            this.btnTranslationSubmitClose.Size = new System.Drawing.Size(31, 23);
            this.btnTranslationSubmitClose.TabIndex = 11;
            this.btnTranslationSubmitClose.TabStop = false;
            this.btnTranslationSubmitClose.Text = "X";
            this.btnTranslationSubmitClose.UseVisualStyleBackColor = false;
            this.btnTranslationSubmitClose.Click += new System.EventHandler(this.btnTranslationSubmitClose_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Submit Translation/Correction";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Email Address:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Origonal Text:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(22, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Translation:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSubmitTranslationTranslation
            // 
            this.txtSubmitTranslationTranslation.Location = new System.Drawing.Point(97, 63);
            this.txtSubmitTranslationTranslation.Name = "txtSubmitTranslationTranslation";
            this.txtSubmitTranslationTranslation.Size = new System.Drawing.Size(251, 20);
            this.txtSubmitTranslationTranslation.TabIndex = 2;
            // 
            // txtSubmitTranslationOrigonal
            // 
            this.txtSubmitTranslationOrigonal.Location = new System.Drawing.Point(97, 37);
            this.txtSubmitTranslationOrigonal.Name = "txtSubmitTranslationOrigonal";
            this.txtSubmitTranslationOrigonal.Size = new System.Drawing.Size(251, 20);
            this.txtSubmitTranslationOrigonal.TabIndex = 1;
            // 
            // txtSubmitTrasnlationEmail
            // 
            this.txtSubmitTrasnlationEmail.Location = new System.Drawing.Point(97, 89);
            this.txtSubmitTrasnlationEmail.Name = "txtSubmitTrasnlationEmail";
            this.txtSubmitTrasnlationEmail.Size = new System.Drawing.Size(251, 20);
            this.txtSubmitTrasnlationEmail.TabIndex = 3;
            // 
            // btnTranslationSubmitSubmit
            // 
            this.btnTranslationSubmitSubmit.Location = new System.Drawing.Point(164, 159);
            this.btnTranslationSubmitSubmit.Name = "btnTranslationSubmitSubmit";
            this.btnTranslationSubmitSubmit.Size = new System.Drawing.Size(103, 23);
            this.btnTranslationSubmitSubmit.TabIndex = 6;
            this.btnTranslationSubmitSubmit.Text = "Submit Translation";
            this.btnTranslationSubmitSubmit.UseVisualStyleBackColor = true;
            this.btnTranslationSubmitSubmit.Click += new System.EventHandler(this.btnTranslationSubmitSubmit_Click);
            // 
            // btnTrasnlationSubmitCancel
            // 
            this.btnTrasnlationSubmitCancel.Location = new System.Drawing.Point(273, 159);
            this.btnTrasnlationSubmitCancel.Name = "btnTrasnlationSubmitCancel";
            this.btnTrasnlationSubmitCancel.Size = new System.Drawing.Size(75, 23);
            this.btnTrasnlationSubmitCancel.TabIndex = 7;
            this.btnTrasnlationSubmitCancel.Text = "Cancel";
            this.btnTrasnlationSubmitCancel.UseVisualStyleBackColor = true;
            this.btnTrasnlationSubmitCancel.Click += new System.EventHandler(this.btnTranslationSubmitClose_Click);
            // 
            // btnSubmitTranslation
            // 
            this.btnSubmitTranslation.Location = new System.Drawing.Point(3, 3);
            this.btnSubmitTranslation.Name = "btnSubmitTranslation";
            this.btnSubmitTranslation.Size = new System.Drawing.Size(112, 30);
            this.btnSubmitTranslation.TabIndex = 0;
            this.btnSubmitTranslation.Text = "Submit Translation";
            this.btnSubmitTranslation.UseVisualStyleBackColor = true;
            this.btnSubmitTranslation.Click += new System.EventHandler(this.btnSubmitTranslation_Click);
            // 
            // TabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnSubmitTranslation);
            this.Controls.Add(this.pnlSubmitTranslation);
            this.Controls.Add(this.lblInstance);
            this.Controls.Add(this.dgvTranslationLog);
            this.Name = "TabControl";
            this.Size = new System.Drawing.Size(650, 450);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTranslationLog)).EndInit();
            this.pnlSubmitTranslation.ResumeLayout(false);
            this.pnlSubmitTranslation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTranslationLog;
        private System.Windows.Forms.Label lblInstance;
        private System.Windows.Forms.Panel pnlSubmitTranslation;
        private System.Windows.Forms.Button btnTranslationSubmitClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubmitTranslationTranslation;
        private System.Windows.Forms.TextBox txtSubmitTranslationOrigonal;
        private System.Windows.Forms.TextBox txtSubmitTrasnlationEmail;
        private System.Windows.Forms.Button btnTranslationSubmitSubmit;
        private System.Windows.Forms.Button btnTrasnlationSubmitCancel;
        private System.Windows.Forms.Button btnSubmitTranslation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTranslationTo;
        private System.Windows.Forms.ComboBox cmbTranslationFrom;
        private System.Windows.Forms.Label label5;
    }
}
