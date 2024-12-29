namespace winform_app.Forms.Khách_hàng
{
    partial class FindBranchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblRegionName;
        private System.Windows.Forms.ComboBox cmbRegionName;
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.ComboBox cmbBranchName;
        private System.Windows.Forms.Label lblBranchInfo;
        private System.Windows.Forms.RichTextBox rtbBranchInfo;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblRegionName = new System.Windows.Forms.Label();
            this.cmbRegionName = new System.Windows.Forms.ComboBox();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.cmbBranchName = new System.Windows.Forms.ComboBox();
            this.lblBranchInfo = new System.Windows.Forms.Label();
            this.rtbBranchInfo = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRegionName
            // 
            this.lblRegionName.AutoSize = true;
            this.lblRegionName.Location = new System.Drawing.Point(12, 15);
            this.lblRegionName.Name = "lblRegionName";
            this.lblRegionName.Size = new System.Drawing.Size(75, 13);
            this.lblRegionName.TabIndex = 0;
            this.lblRegionName.Text = "Region Name:";
            // 
            // cmbRegionName
            // 
            this.cmbRegionName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegionName.FormattingEnabled = true;
            this.cmbRegionName.Location = new System.Drawing.Point(120, 12);
            this.cmbRegionName.Name = "cmbRegionName";
            this.cmbRegionName.Size = new System.Drawing.Size(200, 21);
            this.cmbRegionName.TabIndex = 1;
            this.cmbRegionName.SelectedIndexChanged += new System.EventHandler(this.cmbRegionName_SelectedIndexChanged);
            // 
            // lblBranchName
            // 
            this.lblBranchName.AutoSize = true;
            this.lblBranchName.Location = new System.Drawing.Point(12, 45);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(75, 13);
            this.lblBranchName.TabIndex = 2;
            this.lblBranchName.Text = "Branch Name:";
            // 
            // cmbBranchName
            // 
            this.cmbBranchName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranchName.FormattingEnabled = true;
            this.cmbBranchName.Location = new System.Drawing.Point(120, 42);
            this.cmbBranchName.Name = "cmbBranchName";
            this.cmbBranchName.Size = new System.Drawing.Size(200, 21);
            this.cmbBranchName.TabIndex = 3;
            this.cmbBranchName.SelectedIndexChanged += new System.EventHandler(this.cmbBranchName_SelectedIndexChanged);
            // 
            // lblBranchInfo
            // 
            this.lblBranchInfo.AutoSize = true;
            this.lblBranchInfo.Location = new System.Drawing.Point(12, 75);
            this.lblBranchInfo.Name = "lblBranchInfo";
            this.lblBranchInfo.Size = new System.Drawing.Size(68, 13);
            this.lblBranchInfo.TabIndex = 4;
            this.lblBranchInfo.Text = "Branch Info:";
            // 
            // rtbBranchInfo
            // 
            this.rtbBranchInfo.Location = new System.Drawing.Point(120, 72);
            this.rtbBranchInfo.Name = "rtbBranchInfo";
            this.rtbBranchInfo.ReadOnly = true;
            this.rtbBranchInfo.Size = new System.Drawing.Size(200, 150);
            this.rtbBranchInfo.TabIndex = 5;
            this.rtbBranchInfo.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(245, 230);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FindBranchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.rtbBranchInfo);
            this.Controls.Add(this.lblBranchInfo);
            this.Controls.Add(this.cmbBranchName);
            this.Controls.Add(this.lblBranchName);
            this.Controls.Add(this.cmbRegionName);
            this.Controls.Add(this.lblRegionName);
            this.Name = "FindBranchForm";
            this.Text = "Find Branch";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


