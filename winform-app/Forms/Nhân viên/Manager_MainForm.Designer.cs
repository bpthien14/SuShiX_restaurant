namespace winform_app.Forms.Nhân_viên
{
    partial class Manager_MainForm
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
            menuStrip = new MenuStrip();
            quanLyMonAnToolStripMenuItem = new ToolStripMenuItem();
            thongKeDoanhThuTheoMonAnToolStripMenuItem = new ToolStripMenuItem();
            quanLyNhanSuToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(28, 28);
            menuStrip.Items.AddRange(new ToolStripItem[] { quanLyMonAnToolStripMenuItem, thongKeDoanhThuTheoMonAnToolStripMenuItem, quanLyNhanSuToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(10, 4, 0, 4);
            menuStrip.Size = new Size(1162, 42);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // quanLyMonAnToolStripMenuItem
            // 
            quanLyMonAnToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            quanLyMonAnToolStripMenuItem.ForeColor = Color.IndianRed;
            quanLyMonAnToolStripMenuItem.Name = "quanLyMonAnToolStripMenuItem";
            quanLyMonAnToolStripMenuItem.Size = new Size(188, 34);
            quanLyMonAnToolStripMenuItem.Text = "Quản lý món ăn";
            quanLyMonAnToolStripMenuItem.Click += quanLyMonAnToolStripMenuItem_Click;
            // 
            // thongKeDoanhThuTheoMonAnToolStripMenuItem
            // 
            thongKeDoanhThuTheoMonAnToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            thongKeDoanhThuTheoMonAnToolStripMenuItem.ForeColor = Color.IndianRed;
            thongKeDoanhThuTheoMonAnToolStripMenuItem.Name = "thongKeDoanhThuTheoMonAnToolStripMenuItem";
            thongKeDoanhThuTheoMonAnToolStripMenuItem.Size = new Size(233, 34);
            thongKeDoanhThuTheoMonAnToolStripMenuItem.Text = "Thống kê doanh thu";
            thongKeDoanhThuTheoMonAnToolStripMenuItem.Click += thongKeDoanhThuTheoMonAnToolStripMenuItem_Click;
            // 
            // quanLyNhanSuToolStripMenuItem
            // 
            quanLyNhanSuToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            quanLyNhanSuToolStripMenuItem.ForeColor = Color.IndianRed;
            quanLyNhanSuToolStripMenuItem.Name = "quanLyNhanSuToolStripMenuItem";
            quanLyNhanSuToolStripMenuItem.Size = new Size(192, 34);
            quanLyNhanSuToolStripMenuItem.Text = "Quản lý nhân sự";
            quanLyNhanSuToolStripMenuItem.Click += quanLyNhanSuToolStripMenuItem_Click;
            // 
            // Manager_MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1162, 805);
            Controls.Add(menuStrip);
            Name = "Manager_MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SuShiX Management System";
            Load += Manager_MainForm_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem quanLyMonAnToolStripMenuItem;
        private ToolStripMenuItem thongKeDoanhThuTheoMonAnToolStripMenuItem;
        private ToolStripMenuItem quanLyNhanSuToolStripMenuItem;
    }
}