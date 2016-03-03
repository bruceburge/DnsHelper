namespace UnblockUSTest
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.primarySetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondarySetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbDns01 = new System.Windows.Forms.TextBox();
            this.tbDns02 = new System.Windows.Forms.TextBox();
            this.btnApplyDns = new System.Windows.Forms.Button();
            this.btnClearDns = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDns01Current = new System.Windows.Forms.Label();
            this.lblDns02Current = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblSelectedNic = new System.Windows.Forms.Label();
            this.btnGoToWebsite = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNS 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "DNS 2";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.primarySetupToolStripMenuItem,
            this.secondarySetupToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 48);
            // 
            // primarySetupToolStripMenuItem
            // 
            this.primarySetupToolStripMenuItem.Name = "primarySetupToolStripMenuItem";
            this.primarySetupToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.primarySetupToolStripMenuItem.Text = "Primary Setup";
            this.primarySetupToolStripMenuItem.Click += new System.EventHandler(this.primarySetupToolStripMenuItem_Click);
            // 
            // secondarySetupToolStripMenuItem
            // 
            this.secondarySetupToolStripMenuItem.Name = "secondarySetupToolStripMenuItem";
            this.secondarySetupToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.secondarySetupToolStripMenuItem.Text = "Secondary Setup";
            this.secondarySetupToolStripMenuItem.Click += new System.EventHandler(this.secondarySetupToolStripMenuItem_Click);
            // 
            // tbDns01
            // 
            this.tbDns01.ContextMenuStrip = this.contextMenuStrip1;
            this.tbDns01.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDns01.Location = new System.Drawing.Point(15, 65);
            this.tbDns01.Name = "tbDns01";
            this.tbDns01.Size = new System.Drawing.Size(178, 26);
            this.tbDns01.TabIndex = 0;
            this.tbDns01.Text = "208.122.293.239";
            this.tbDns01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDns02
            // 
            this.tbDns02.ContextMenuStrip = this.contextMenuStrip1;
            this.tbDns02.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDns02.Location = new System.Drawing.Point(15, 115);
            this.tbDns02.Name = "tbDns02";
            this.tbDns02.Size = new System.Drawing.Size(178, 26);
            this.tbDns02.TabIndex = 1;
            this.tbDns02.Text = "208.122.293.239";
            this.tbDns02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnApplyDns
            // 
            this.btnApplyDns.Location = new System.Drawing.Point(118, 147);
            this.btnApplyDns.Name = "btnApplyDns";
            this.btnApplyDns.Size = new System.Drawing.Size(75, 23);
            this.btnApplyDns.TabIndex = 2;
            this.btnApplyDns.Text = "Apply";
            this.toolTip1.SetToolTip(this.btnApplyDns, "Apply the current DNS 1 and 2 values");
            this.btnApplyDns.UseVisualStyleBackColor = true;
            this.btnApplyDns.Click += new System.EventHandler(this.btnApplyDns_Click);
            // 
            // btnClearDns
            // 
            this.btnClearDns.Location = new System.Drawing.Point(295, 147);
            this.btnClearDns.Name = "btnClearDns";
            this.btnClearDns.Size = new System.Drawing.Size(75, 23);
            this.btnClearDns.TabIndex = 4;
            this.btnClearDns.Text = "Clear";
            this.toolTip1.SetToolTip(this.btnClearDns, "Clear DNS values and set to obtain automatically");
            this.btnClearDns.UseVisualStyleBackColor = true;
            this.btnClearDns.Click += new System.EventHandler(this.btnClearDns_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(199, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 141);
            this.label3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Current Status:";
            // 
            // lblDns01Current
            // 
            this.lblDns01Current.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDns01Current.Location = new System.Drawing.Point(208, 68);
            this.lblDns01Current.Name = "lblDns01Current";
            this.lblDns01Current.Size = new System.Drawing.Size(162, 20);
            this.lblDns01Current.TabIndex = 5;
            this.lblDns01Current.Text = "208.122.23.23";
            this.lblDns01Current.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.lblDns01Current, "Currently set DNS 1 value");
            // 
            // lblDns02Current
            // 
            this.lblDns02Current.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDns02Current.Location = new System.Drawing.Point(208, 115);
            this.lblDns02Current.Name = "lblDns02Current";
            this.lblDns02Current.Size = new System.Drawing.Size(162, 20);
            this.lblDns02Current.TabIndex = 5;
            this.lblDns02Current.Text = "208.122.23.23";
            this.lblDns02Current.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.lblDns02Current, "Currently set DNS 2 value");
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(343, 40);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(27, 23);
            this.btnRefresh.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnRefresh, "Refresh currently set DNS values");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblSelectedNic
            // 
            this.lblSelectedNic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedNic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedNic.Location = new System.Drawing.Point(13, 9);
            this.lblSelectedNic.Name = "lblSelectedNic";
            this.lblSelectedNic.Size = new System.Drawing.Size(361, 23);
            this.lblSelectedNic.TabIndex = 6;
            this.lblSelectedNic.Text = "label7";
            this.toolTip1.SetToolTip(this.lblSelectedNic, "The selected NIC that is being modified");
            // 
            // btnGoToWebsite
            // 
            this.btnGoToWebsite.FlatAppearance.BorderSize = 0;
            this.btnGoToWebsite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToWebsite.Image = ((System.Drawing.Image)(resources.GetObject("btnGoToWebsite.Image")));
            this.btnGoToWebsite.Location = new System.Drawing.Point(17, 147);
            this.btnGoToWebsite.Name = "btnGoToWebsite";
            this.btnGoToWebsite.Size = new System.Drawing.Size(27, 23);
            this.btnGoToWebsite.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnGoToWebsite, "Click to open the Unblock-US website");
            this.btnGoToWebsite.UseVisualStyleBackColor = true;
            this.btnGoToWebsite.Click += new System.EventHandler(this.btnGoToWebsite_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 188);
            this.Controls.Add(this.lblSelectedNic);
            this.Controls.Add(this.lblDns02Current);
            this.Controls.Add(this.lblDns01Current);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGoToWebsite);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClearDns);
            this.Controls.Add(this.btnApplyDns);
            this.Controls.Add(this.tbDns02);
            this.Controls.Add(this.tbDns01);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Unblock-Us DNS Helper";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem primarySetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondarySetupToolStripMenuItem;
        private System.Windows.Forms.TextBox tbDns01;
        private System.Windows.Forms.TextBox tbDns02;
        private System.Windows.Forms.Button btnApplyDns;
        private System.Windows.Forms.Button btnClearDns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDns01Current;
        private System.Windows.Forms.Label lblDns02Current;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblSelectedNic;
        private System.Windows.Forms.Button btnGoToWebsite;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

