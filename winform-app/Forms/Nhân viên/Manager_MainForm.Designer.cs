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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager_MainForm));
            menuStrip = new MenuStrip();
            quanLyMonAnToolStripMenuItem = new ToolStripMenuItem();
            thongKeDoanhThuTheoMonAnToolStripMenuItem = new ToolStripMenuItem();
            quanLyNhanSuToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1047, 674);
            pictureBox1.Margin = new Padding(5, 6, 5, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Manager_MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1162, 805);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip);
            Name = "Manager_MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SuShiX Management System";
            Load += Manager_MainForm_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem quanLyMonAnToolStripMenuItem;
        private ToolStripMenuItem thongKeDoanhThuTheoMonAnToolStripMenuItem;
        private ToolStripMenuItem quanLyNhanSuToolStripMenuItem;
        private PictureBox pictureBox1;
    }
}