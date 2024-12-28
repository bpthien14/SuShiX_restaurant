namespace winform_app.Forms.Nhân_viên
{
    partial class NV_MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem thongKeDoanhThuChiNhanhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongKeDoanhThuTheoMonAnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyNhanSuToolStripMenuItem;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NV_MainForm));
            menuStrip = new MenuStrip();
            thongKeDoanhThuChiNhanhToolStripMenuItem = new ToolStripMenuItem();
            thongKeDoanhThuTheoMonAnToolStripMenuItem = new ToolStripMenuItem();
            quanLyNhanSuToolStripMenuItem = new ToolStripMenuItem();
            pictureBox3 = new PictureBox();
            labelTitle = new Label();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(28, 28);
            menuStrip.Items.AddRange(new ToolStripItem[] { thongKeDoanhThuChiNhanhToolStripMenuItem, thongKeDoanhThuTheoMonAnToolStripMenuItem, quanLyNhanSuToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(10, 4, 0, 4);
            menuStrip.Size = new Size(1162, 42);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // thongKeDoanhThuChiNhanhToolStripMenuItem
            // 
            thongKeDoanhThuChiNhanhToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            thongKeDoanhThuChiNhanhToolStripMenuItem.ForeColor = Color.IndianRed;
            thongKeDoanhThuChiNhanhToolStripMenuItem.Name = "thongKeDoanhThuChiNhanhToolStripMenuItem";
            thongKeDoanhThuChiNhanhToolStripMenuItem.Size = new Size(337, 34);
            thongKeDoanhThuChiNhanhToolStripMenuItem.Text = "Thống kê doanh thu chi nhánh";
            thongKeDoanhThuChiNhanhToolStripMenuItem.Click += thongKeDoanhThuChiNhanhToolStripMenuItem_Click;
            // 
            // thongKeDoanhThuTheoMonAnToolStripMenuItem
            // 
            thongKeDoanhThuTheoMonAnToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            thongKeDoanhThuTheoMonAnToolStripMenuItem.ForeColor = Color.IndianRed;
            thongKeDoanhThuTheoMonAnToolStripMenuItem.Name = "thongKeDoanhThuTheoMonAnToolStripMenuItem";
            thongKeDoanhThuTheoMonAnToolStripMenuItem.Size = new Size(365, 34);
            thongKeDoanhThuTheoMonAnToolStripMenuItem.Text = "Thống kê doanh thu theo món ăn";
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
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(606, 43);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(60, 55);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Viner Hand ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Maroon;
            labelTitle.Location = new Point(615, 101);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(42, 264);
            labelTitle.TabIndex = 11;
            labelTitle.Text = "S\r\nU\r\nS\r\nH\r\nI\r\nX\r\n";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NV_MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1162, 805);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(5, 6, 5, 6);
            Name = "NV_MainForm";
            Text = "SuShiX Management System";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private PictureBox pictureBox3;
        private Label labelTitle;
    }
}