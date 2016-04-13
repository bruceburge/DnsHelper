namespace UnblockUSTest
{
    partial class NetflixForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetflixForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNetflixRegionPicker = new System.Windows.Forms.ComboBox();
            this.btnVerifyUsername = new System.Windows.Forms.Button();
            this.btnRegionAssign = new System.Windows.Forms.Button();
            this.tbUnblockLog = new System.Windows.Forms.TextBox();
            this.lblSeparator01 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNetflixLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUnblockActive = new System.Windows.Forms.Button();
            this.btnUnblockCountry = new System.Windows.Forms.Button();
            this.btnNetflixCountry = new System.Windows.Forms.Button();
            this.btnNetflixGeoLocation = new System.Windows.Forms.Button();
            this.picNetflixRegionPicker = new System.Windows.Forms.PictureBox();
            this.btnRefreshNetflix = new System.Windows.Forms.Button();
            this.btnRefreshUnblockUs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picNetflixRegionPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unblock-Us Username";
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(15, 35);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(6);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(272, 26);
            this.tbUsername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Unblock-Us Region";
            // 
            // cmbNetflixRegionPicker
            // 
            this.cmbNetflixRegionPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNetflixRegionPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNetflixRegionPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNetflixRegionPicker.FormattingEnabled = true;
            this.cmbNetflixRegionPicker.Items.AddRange(new object[] {
            "US|USA",
            "AR|Argentina",
            "AU|Australia",
            "AT|Austria"});
            this.cmbNetflixRegionPicker.Location = new System.Drawing.Point(45, 93);
            this.cmbNetflixRegionPicker.Margin = new System.Windows.Forms.Padding(6);
            this.cmbNetflixRegionPicker.Name = "cmbNetflixRegionPicker";
            this.cmbNetflixRegionPicker.Size = new System.Drawing.Size(242, 28);
            this.cmbNetflixRegionPicker.TabIndex = 2;
            this.cmbNetflixRegionPicker.SelectedValueChanged += new System.EventHandler(this.cmbNetflixRegionPicker_SelectedValueChanged);
            // 
            // btnVerifyUsername
            // 
            this.btnVerifyUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerifyUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerifyUsername.Image = ((System.Drawing.Image)(resources.GetObject("btnVerifyUsername.Image")));
            this.btnVerifyUsername.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerifyUsername.Location = new System.Drawing.Point(296, 33);
            this.btnVerifyUsername.Name = "btnVerifyUsername";
            this.btnVerifyUsername.Size = new System.Drawing.Size(111, 32);
            this.btnVerifyUsername.TabIndex = 3;
            this.btnVerifyUsername.Text = "Login";
            this.btnVerifyUsername.UseVisualStyleBackColor = true;
            this.btnVerifyUsername.Click += new System.EventHandler(this.btnVerifyUsername_Click);
            // 
            // btnRegionAssign
            // 
            this.btnRegionAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegionAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegionAssign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegionAssign.Location = new System.Drawing.Point(296, 92);
            this.btnRegionAssign.Name = "btnRegionAssign";
            this.btnRegionAssign.Size = new System.Drawing.Size(111, 32);
            this.btnRegionAssign.TabIndex = 3;
            this.btnRegionAssign.Text = "Update";
            this.btnRegionAssign.UseVisualStyleBackColor = true;
            this.btnRegionAssign.Click += new System.EventHandler(this.btnRegionAssign_Click);
            // 
            // tbUnblockLog
            // 
            this.tbUnblockLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbUnblockLog.Location = new System.Drawing.Point(12, 238);
            this.tbUnblockLog.Multiline = true;
            this.tbUnblockLog.Name = "tbUnblockLog";
            this.tbUnblockLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbUnblockLog.Size = new System.Drawing.Size(233, 291);
            this.tbUnblockLog.TabIndex = 4;
            // 
            // lblSeparator01
            // 
            this.lblSeparator01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeparator01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparator01.Location = new System.Drawing.Point(12, 131);
            this.lblSeparator01.Name = "lblSeparator01";
            this.lblSeparator01.Size = new System.Drawing.Size(491, 2);
            this.lblSeparator01.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Unblock-Us Region";
            // 
            // tbNetflixLog
            // 
            this.tbNetflixLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbNetflixLog.Location = new System.Drawing.Point(272, 238);
            this.tbNetflixLog.Multiline = true;
            this.tbNetflixLog.Name = "tbNetflixLog";
            this.tbNetflixLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNetflixLog.Size = new System.Drawing.Size(233, 291);
            this.tbNetflixLog.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(269, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Netflix Config";
            // 
            // btnUnblockActive
            // 
            this.btnUnblockActive.FlatAppearance.BorderSize = 0;
            this.btnUnblockActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnblockActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnblockActive.Image = ((System.Drawing.Image)(resources.GetObject("btnUnblockActive.Image")));
            this.btnUnblockActive.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnblockActive.Location = new System.Drawing.Point(12, 162);
            this.btnUnblockActive.Name = "btnUnblockActive";
            this.btnUnblockActive.Size = new System.Drawing.Size(236, 32);
            this.btnUnblockActive.TabIndex = 3;
            this.btnUnblockActive.Text = "Active";
            this.btnUnblockActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnblockActive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUnblockActive.UseVisualStyleBackColor = true;
            // 
            // btnUnblockCountry
            // 
            this.btnUnblockCountry.FlatAppearance.BorderSize = 0;
            this.btnUnblockCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnblockCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnblockCountry.Image = ((System.Drawing.Image)(resources.GetObject("btnUnblockCountry.Image")));
            this.btnUnblockCountry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnblockCountry.Location = new System.Drawing.Point(12, 200);
            this.btnUnblockCountry.Name = "btnUnblockCountry";
            this.btnUnblockCountry.Size = new System.Drawing.Size(236, 32);
            this.btnUnblockCountry.TabIndex = 3;
            this.btnUnblockCountry.Text = "Country";
            this.btnUnblockCountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnblockCountry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUnblockCountry.UseVisualStyleBackColor = true;
            // 
            // btnNetflixCountry
            // 
            this.btnNetflixCountry.FlatAppearance.BorderSize = 0;
            this.btnNetflixCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNetflixCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNetflixCountry.Image = ((System.Drawing.Image)(resources.GetObject("btnNetflixCountry.Image")));
            this.btnNetflixCountry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNetflixCountry.Location = new System.Drawing.Point(272, 162);
            this.btnNetflixCountry.Name = "btnNetflixCountry";
            this.btnNetflixCountry.Size = new System.Drawing.Size(233, 32);
            this.btnNetflixCountry.TabIndex = 3;
            this.btnNetflixCountry.Text = "Country";
            this.btnNetflixCountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNetflixCountry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNetflixCountry.UseVisualStyleBackColor = true;
            // 
            // btnNetflixGeoLocation
            // 
            this.btnNetflixGeoLocation.FlatAppearance.BorderSize = 0;
            this.btnNetflixGeoLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNetflixGeoLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNetflixGeoLocation.Image = ((System.Drawing.Image)(resources.GetObject("btnNetflixGeoLocation.Image")));
            this.btnNetflixGeoLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNetflixGeoLocation.Location = new System.Drawing.Point(272, 200);
            this.btnNetflixGeoLocation.Name = "btnNetflixGeoLocation";
            this.btnNetflixGeoLocation.Size = new System.Drawing.Size(234, 32);
            this.btnNetflixGeoLocation.TabIndex = 3;
            this.btnNetflixGeoLocation.Text = "GeoLocation Country";
            this.btnNetflixGeoLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNetflixGeoLocation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNetflixGeoLocation.UseVisualStyleBackColor = true;
            // 
            // picNetflixRegionPicker
            // 
            this.picNetflixRegionPicker.Location = new System.Drawing.Point(21, 98);
            this.picNetflixRegionPicker.Name = "picNetflixRegionPicker";
            this.picNetflixRegionPicker.Size = new System.Drawing.Size(16, 16);
            this.picNetflixRegionPicker.TabIndex = 6;
            this.picNetflixRegionPicker.TabStop = false;
            // 
            // btnRefreshNetflix
            // 
            this.btnRefreshNetflix.FlatAppearance.BorderSize = 0;
            this.btnRefreshNetflix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshNetflix.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshNetflix.Image")));
            this.btnRefreshNetflix.Location = new System.Drawing.Point(358, 143);
            this.btnRefreshNetflix.Name = "btnRefreshNetflix";
            this.btnRefreshNetflix.Size = new System.Drawing.Size(16, 16);
            this.btnRefreshNetflix.TabIndex = 7;
            this.btnRefreshNetflix.UseVisualStyleBackColor = true;
            this.btnRefreshNetflix.Click += new System.EventHandler(this.btnRefreshNetflix_Click);
            // 
            // btnRefreshUnblockUs
            // 
            this.btnRefreshUnblockUs.FlatAppearance.BorderSize = 0;
            this.btnRefreshUnblockUs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshUnblockUs.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshUnblockUs.Image")));
            this.btnRefreshUnblockUs.Location = new System.Drawing.Point(135, 143);
            this.btnRefreshUnblockUs.Name = "btnRefreshUnblockUs";
            this.btnRefreshUnblockUs.Size = new System.Drawing.Size(16, 16);
            this.btnRefreshUnblockUs.TabIndex = 7;
            this.btnRefreshUnblockUs.UseVisualStyleBackColor = true;
            this.btnRefreshUnblockUs.Click += new System.EventHandler(this.btnRefreshUnblockUs_Click);
            // 
            // NetflixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 541);
            this.Controls.Add(this.btnRefreshUnblockUs);
            this.Controls.Add(this.btnRefreshNetflix);
            this.Controls.Add(this.picNetflixRegionPicker);
            this.Controls.Add(this.lblSeparator01);
            this.Controls.Add(this.tbNetflixLog);
            this.Controls.Add(this.tbUnblockLog);
            this.Controls.Add(this.btnRegionAssign);
            this.Controls.Add(this.btnNetflixGeoLocation);
            this.Controls.Add(this.btnNetflixCountry);
            this.Controls.Add(this.btnUnblockCountry);
            this.Controls.Add(this.btnUnblockActive);
            this.Controls.Add(this.btnVerifyUsername);
            this.Controls.Add(this.cmbNetflixRegionPicker);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(534, 9615);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(534, 275);
            this.Name = "NetflixForm";
            this.Text = "Netflix Configuration";
            this.Load += new System.EventHandler(this.NetflixForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picNetflixRegionPicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNetflixRegionPicker;
        private System.Windows.Forms.Button btnVerifyUsername;
        private System.Windows.Forms.Button btnRegionAssign;
        private System.Windows.Forms.TextBox tbUnblockLog;
        private System.Windows.Forms.Label lblSeparator01;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNetflixLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUnblockActive;
        private System.Windows.Forms.Button btnUnblockCountry;
        private System.Windows.Forms.Button btnNetflixCountry;
        private System.Windows.Forms.Button btnNetflixGeoLocation;
        private System.Windows.Forms.PictureBox picNetflixRegionPicker;
        private System.Windows.Forms.Button btnRefreshNetflix;
        private System.Windows.Forms.Button btnRefreshUnblockUs;
    }
}