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
            lblRegionName = new Label();
            cmbRegionName = new ComboBox();
            lblBranchName = new Label();
            cmbBranchName = new ComboBox();
            lblBranchInfo = new Label();
            rtbBranchInfo = new RichTextBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblRegionName
            // 
            lblRegionName.AutoSize = true;
            lblRegionName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblRegionName.ForeColor = Color.IndianRed;
            lblRegionName.Location = new Point(19, 36);
            lblRegionName.Margin = new Padding(6, 0, 6, 0);
            lblRegionName.Name = "lblRegionName";
            lblRegionName.Size = new Size(151, 30);
            lblRegionName.TabIndex = 0;
            lblRegionName.Text = "Chọn Khu vực:";
            // 
            // cmbRegionName
            // 
            cmbRegionName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRegionName.ForeColor = Color.Black;
            cmbRegionName.FormattingEnabled = true;
            cmbRegionName.Location = new Point(240, 28);
            cmbRegionName.Margin = new Padding(6, 7, 6, 7);
            cmbRegionName.Name = "cmbRegionName";
            cmbRegionName.Size = new Size(396, 38);
            cmbRegionName.TabIndex = 1;
            cmbRegionName.SelectedIndexChanged += cmbRegionName_SelectedIndexChanged;
            // 
            // lblBranchName
            // 
            lblBranchName.AutoSize = true;
            lblBranchName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblBranchName.ForeColor = Color.IndianRed;
            lblBranchName.Location = new Point(19, 105);
            lblBranchName.Margin = new Padding(6, 0, 6, 0);
            lblBranchName.Name = "lblBranchName";
            lblBranchName.Size = new Size(173, 30);
            lblBranchName.TabIndex = 2;
            lblBranchName.Text = "Chọn Chi Nhánh:";
            // 
            // cmbBranchName
            // 
            cmbBranchName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranchName.ForeColor = Color.Black;
            cmbBranchName.FormattingEnabled = true;
            cmbBranchName.Location = new Point(240, 97);
            cmbBranchName.Margin = new Padding(6, 7, 6, 7);
            cmbBranchName.Name = "cmbBranchName";
            cmbBranchName.Size = new Size(396, 38);
            cmbBranchName.TabIndex = 3;
            cmbBranchName.SelectedIndexChanged += cmbBranchName_SelectedIndexChanged;
            // 
            // lblBranchInfo
            // 
            lblBranchInfo.AutoSize = true;
            lblBranchInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblBranchInfo.ForeColor = Color.IndianRed;
            lblBranchInfo.Location = new Point(19, 169);
            lblBranchInfo.Margin = new Padding(6, 0, 6, 0);
            lblBranchInfo.Name = "lblBranchInfo";
            lblBranchInfo.Size = new Size(209, 30);
            lblBranchInfo.TabIndex = 4;
            lblBranchInfo.Text = "Thông tin chi nhánh:";
            // 
            // rtbBranchInfo
            // 
            rtbBranchInfo.BackColor = Color.White;
            rtbBranchInfo.ForeColor = Color.IndianRed;
            rtbBranchInfo.Location = new Point(240, 166);
            rtbBranchInfo.Margin = new Padding(6, 7, 6, 7);
            rtbBranchInfo.Name = "rtbBranchInfo";
            rtbBranchInfo.ReadOnly = true;
            rtbBranchInfo.Size = new Size(396, 341);
            rtbBranchInfo.TabIndex = 5;
            rtbBranchInfo.Text = "";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.RosyBrown;
            btnClose.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(490, 531);
            btnClose.Margin = new Padding(6, 7, 6, 7);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 53);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // FindBranchForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(668, 602);
            Controls.Add(btnClose);
            Controls.Add(rtbBranchInfo);
            Controls.Add(lblBranchInfo);
            Controls.Add(cmbBranchName);
            Controls.Add(lblBranchName);
            Controls.Add(cmbRegionName);
            Controls.Add(lblRegionName);
            Margin = new Padding(6, 7, 6, 7);
            Name = "FindBranchForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tìm chi nhánh";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}


