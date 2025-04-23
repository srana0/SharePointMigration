namespace SiteComparerForm
{
    partial class siteComparerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSourceUrl = new System.Windows.Forms.Label();
            this.lblSourceUserName = new System.Windows.Forms.Label();
            this.lblSourcePassword = new System.Windows.Forms.Label();
            this.lblDestinationUrl = new System.Windows.Forms.Label();
            this.lblDestinationUserName = new System.Windows.Forms.Label();
            this.lblDestinationPassword = new System.Windows.Forms.Label();
            this.txtSourceUrl = new System.Windows.Forms.TextBox();
            this.txtDestinationUrl = new System.Windows.Forms.TextBox();
            this.txtSourceUserName = new System.Windows.Forms.TextBox();
            this.txtDestinationUserName = new System.Windows.Forms.TextBox();
            this.txtDestinationPassword = new System.Windows.Forms.TextBox();
            this.txtSourcePassword = new System.Windows.Forms.TextBox();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.btnComapreSites = new System.Windows.Forms.Button();
            this.txtSourceDomain = new System.Windows.Forms.TextBox();
            this.lblSourceDomain = new System.Windows.Forms.Label();
            this.lblDestinationDomain = new System.Windows.Forms.Label();
            this.txtDestinationDomain = new System.Windows.Forms.TextBox();
            this.ckboxDocumentRecursiveStatus = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblSourceUrl
            // 
            this.lblSourceUrl.AutoSize = true;
            this.lblSourceUrl.Location = new System.Drawing.Point(22, 22);
            this.lblSourceUrl.Name = "lblSourceUrl";
            this.lblSourceUrl.Size = new System.Drawing.Size(57, 13);
            this.lblSourceUrl.TabIndex = 0;
            this.lblSourceUrl.Text = "Source Url";
            // 
            // lblSourceUserName
            // 
            this.lblSourceUserName.AutoSize = true;
            this.lblSourceUserName.Location = new System.Drawing.Point(22, 60);
            this.lblSourceUserName.Name = "lblSourceUserName";
            this.lblSourceUserName.Size = new System.Drawing.Size(60, 13);
            this.lblSourceUserName.TabIndex = 1;
            this.lblSourceUserName.Text = "User Name";
            // 
            // lblSourcePassword
            // 
            this.lblSourcePassword.AutoSize = true;
            this.lblSourcePassword.Location = new System.Drawing.Point(292, 56);
            this.lblSourcePassword.Name = "lblSourcePassword";
            this.lblSourcePassword.Size = new System.Drawing.Size(53, 13);
            this.lblSourcePassword.TabIndex = 2;
            this.lblSourcePassword.Text = "Password";
            // 
            // lblDestinationUrl
            // 
            this.lblDestinationUrl.AutoSize = true;
            this.lblDestinationUrl.Location = new System.Drawing.Point(22, 129);
            this.lblDestinationUrl.Name = "lblDestinationUrl";
            this.lblDestinationUrl.Size = new System.Drawing.Size(76, 13);
            this.lblDestinationUrl.TabIndex = 3;
            this.lblDestinationUrl.Text = "Destination Url";
            // 
            // lblDestinationUserName
            // 
            this.lblDestinationUserName.AutoSize = true;
            this.lblDestinationUserName.Location = new System.Drawing.Point(19, 162);
            this.lblDestinationUserName.Name = "lblDestinationUserName";
            this.lblDestinationUserName.Size = new System.Drawing.Size(60, 13);
            this.lblDestinationUserName.TabIndex = 4;
            this.lblDestinationUserName.Text = "User Name";
            // 
            // lblDestinationPassword
            // 
            this.lblDestinationPassword.AutoSize = true;
            this.lblDestinationPassword.Location = new System.Drawing.Point(292, 166);
            this.lblDestinationPassword.Name = "lblDestinationPassword";
            this.lblDestinationPassword.Size = new System.Drawing.Size(48, 13);
            this.lblDestinationPassword.TabIndex = 5;
            this.lblDestinationPassword.Text = "Pasword";
            // 
            // txtSourceUrl
            // 
            this.txtSourceUrl.Location = new System.Drawing.Point(104, 22);
            this.txtSourceUrl.Name = "txtSourceUrl";
            this.txtSourceUrl.Size = new System.Drawing.Size(432, 20);
            this.txtSourceUrl.TabIndex = 6;
            // 
            // txtDestinationUrl
            // 
            this.txtDestinationUrl.Location = new System.Drawing.Point(104, 129);
            this.txtDestinationUrl.Name = "txtDestinationUrl";
            this.txtDestinationUrl.Size = new System.Drawing.Size(432, 20);
            this.txtDestinationUrl.TabIndex = 7;
            // 
            // txtSourceUserName
            // 
            this.txtSourceUserName.Location = new System.Drawing.Point(104, 53);
            this.txtSourceUserName.Name = "txtSourceUserName";
            this.txtSourceUserName.Size = new System.Drawing.Size(162, 20);
            this.txtSourceUserName.TabIndex = 8;
            // 
            // txtDestinationUserName
            // 
            this.txtDestinationUserName.Location = new System.Drawing.Point(104, 159);
            this.txtDestinationUserName.Name = "txtDestinationUserName";
            this.txtDestinationUserName.Size = new System.Drawing.Size(166, 20);
            this.txtDestinationUserName.TabIndex = 10;
            // 
            // txtDestinationPassword
            // 
            this.txtDestinationPassword.Location = new System.Drawing.Point(370, 163);
            this.txtDestinationPassword.Name = "txtDestinationPassword";
            this.txtDestinationPassword.PasswordChar = '*';
            this.txtDestinationPassword.Size = new System.Drawing.Size(162, 20);
            this.txtDestinationPassword.TabIndex = 11;
            // 
            // txtSourcePassword
            // 
            this.txtSourcePassword.Location = new System.Drawing.Point(370, 53);
            this.txtSourcePassword.Name = "txtSourcePassword";
            this.txtSourcePassword.PasswordChar = '*';
            this.txtSourcePassword.Size = new System.Drawing.Size(162, 20);
            this.txtSourcePassword.TabIndex = 12;
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.AutoSize = true;
            this.lblStatusMessage.Location = new System.Drawing.Point(312, 224);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(83, 13);
            this.lblStatusMessage.TabIndex = 13;
            this.lblStatusMessage.Text = "Status Message";
            // 
            // btnComapreSites
            // 
            this.btnComapreSites.Location = new System.Drawing.Point(25, 258);
            this.btnComapreSites.Name = "btnComapreSites";
            this.btnComapreSites.Size = new System.Drawing.Size(166, 23);
            this.btnComapreSites.TabIndex = 14;
            this.btnComapreSites.Text = "Compare Sites";
            this.btnComapreSites.UseVisualStyleBackColor = true;
            this.btnComapreSites.Click += new System.EventHandler(this.btnComapreSites_Click);
            // 
            // txtSourceDomain
            // 
            this.txtSourceDomain.Location = new System.Drawing.Point(104, 88);
            this.txtSourceDomain.Name = "txtSourceDomain";
            this.txtSourceDomain.Size = new System.Drawing.Size(162, 20);
            this.txtSourceDomain.TabIndex = 15;
            // 
            // lblSourceDomain
            // 
            this.lblSourceDomain.AutoSize = true;
            this.lblSourceDomain.Location = new System.Drawing.Point(27, 88);
            this.lblSourceDomain.Name = "lblSourceDomain";
            this.lblSourceDomain.Size = new System.Drawing.Size(43, 13);
            this.lblSourceDomain.TabIndex = 16;
            this.lblSourceDomain.Text = "Domain";
            // 
            // lblDestinationDomain
            // 
            this.lblDestinationDomain.AutoSize = true;
            this.lblDestinationDomain.Location = new System.Drawing.Point(27, 196);
            this.lblDestinationDomain.Name = "lblDestinationDomain";
            this.lblDestinationDomain.Size = new System.Drawing.Size(43, 13);
            this.lblDestinationDomain.TabIndex = 17;
            this.lblDestinationDomain.Text = "Domain";
            // 
            // txtDestinationDomain
            // 
            this.txtDestinationDomain.Location = new System.Drawing.Point(104, 196);
            this.txtDestinationDomain.Name = "txtDestinationDomain";
            this.txtDestinationDomain.Size = new System.Drawing.Size(166, 20);
            this.txtDestinationDomain.TabIndex = 18;
            // 
            // ckboxDocumentRecursiveStatus
            // 
            this.ckboxDocumentRecursiveStatus.AutoSize = true;
            this.ckboxDocumentRecursiveStatus.Location = new System.Drawing.Point(104, 224);
            this.ckboxDocumentRecursiveStatus.Name = "ckboxDocumentRecursiveStatus";
            this.ckboxDocumentRecursiveStatus.Size = new System.Drawing.Size(136, 17);
            this.ckboxDocumentRecursiveStatus.TabIndex = 19;
            this.ckboxDocumentRecursiveStatus.Text = "Crawl Web Recursively";
            this.ckboxDocumentRecursiveStatus.UseVisualStyleBackColor = true;
            // 
            // siteComparerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 322);
            this.Controls.Add(this.ckboxDocumentRecursiveStatus);
            this.Controls.Add(this.txtDestinationDomain);
            this.Controls.Add(this.lblDestinationDomain);
            this.Controls.Add(this.lblSourceDomain);
            this.Controls.Add(this.txtSourceDomain);
            this.Controls.Add(this.btnComapreSites);
            this.Controls.Add(this.lblStatusMessage);
            this.Controls.Add(this.txtSourcePassword);
            this.Controls.Add(this.txtDestinationPassword);
            this.Controls.Add(this.txtDestinationUserName);
            this.Controls.Add(this.txtSourceUserName);
            this.Controls.Add(this.txtDestinationUrl);
            this.Controls.Add(this.txtSourceUrl);
            this.Controls.Add(this.lblDestinationPassword);
            this.Controls.Add(this.lblDestinationUserName);
            this.Controls.Add(this.lblDestinationUrl);
            this.Controls.Add(this.lblSourcePassword);
            this.Controls.Add(this.lblSourceUserName);
            this.Controls.Add(this.lblSourceUrl);
            this.Name = "siteComparerForm";
            this.Text = "Site Comparer";
            this.Load += new System.EventHandler(this.siteComparerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSourceUrl;
        private System.Windows.Forms.Label lblSourceUserName;
        private System.Windows.Forms.Label lblSourcePassword;
        private System.Windows.Forms.Label lblDestinationUrl;
        private System.Windows.Forms.Label lblDestinationUserName;
        private System.Windows.Forms.Label lblDestinationPassword;
        private System.Windows.Forms.TextBox txtSourceUrl;
        private System.Windows.Forms.TextBox txtDestinationUrl;
        private System.Windows.Forms.TextBox txtSourceUserName;
        private System.Windows.Forms.TextBox txtDestinationUserName;
        private System.Windows.Forms.TextBox txtDestinationPassword;
        private System.Windows.Forms.TextBox txtSourcePassword;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Button btnComapreSites;
        private System.Windows.Forms.TextBox txtSourceDomain;
        private System.Windows.Forms.Label lblSourceDomain;
        private System.Windows.Forms.Label lblDestinationDomain;
        private System.Windows.Forms.TextBox txtDestinationDomain;
        private System.Windows.Forms.CheckBox ckboxDocumentRecursiveStatus;
    }
}

