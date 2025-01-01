namespace winform_app.Forms.Nhân_viên
{
    partial class Admin_ManageStaff
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
        private System.Windows.Forms.TextBox textBoxTimKiem;
        private System.Windows.Forms.DataGridView dataGridViewNhanVien;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_ManageStaff));
            textBoxTimKiem = new TextBox();
            dataGridViewNhanVien = new DataGridView();
            label4 = new Label();
            label3 = new Label();
            comboBoxChiNhanh = new ComboBox();
            comboBoxKhuVuc = new ComboBox();
            labelBoPhan = new Label();
            comboBoxBoPhan = new ComboBox();
            pictureBox3 = new PictureBox();
            labelTitle = new Label();
            label1 = new Label();
            buttonXuatExcel = new Button();
            buttonXemThongKe = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNhanVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // textBoxTimKiem
            // 
            textBoxTimKiem.Location = new Point(154, 145);
            textBoxTimKiem.Name = "textBoxTimKiem";
            textBoxTimKiem.Size = new Size(288, 35);
            textBoxTimKiem.TabIndex = 3;
            textBoxTimKiem.TextChanged += textBoxTimKiem_TextChanged;
            // 
            // dataGridViewNhanVien
            // 
            dataGridViewNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNhanVien.Location = new Point(34, 189);
            dataGridViewNhanVien.Name = "dataGridViewNhanVien";
            dataGridViewNhanVien.RowHeadersWidth = 72;
            dataGridViewNhanVien.Size = new Size(967, 560);
            dataGridViewNhanVien.TabIndex = 7;
            dataGridViewNhanVien.CellContentClick += dataGridViewNhanVien_CellContentClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.IndianRed;
            label4.Location = new Point(264, 21);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(118, 30);
            label4.TabIndex = 34;
            label4.Text = "Chi Nhánh";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.IndianRed;
            label3.Location = new Point(28, 21);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(94, 30);
            label3.TabIndex = 33;
            label3.Text = "Khu vực";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxChiNhanh
            // 
            comboBoxChiNhanh.FormattingEnabled = true;
            comboBoxChiNhanh.Location = new Point(264, 57);
            comboBoxChiNhanh.Margin = new Padding(5, 6, 5, 6);
            comboBoxChiNhanh.Name = "comboBoxChiNhanh";
            comboBoxChiNhanh.Size = new Size(205, 38);
            comboBoxChiNhanh.TabIndex = 32;
            comboBoxChiNhanh.Text = "Chi Nhánh";
            comboBoxChiNhanh.SelectedIndexChanged += comboBoxChiNhanh_SelectedIndexChanged;
            // 
            // comboBoxKhuVuc
            // 
            comboBoxKhuVuc.FormattingEnabled = true;
            comboBoxKhuVuc.Location = new Point(28, 57);
            comboBoxKhuVuc.Margin = new Padding(5, 6, 5, 6);
            comboBoxKhuVuc.Name = "comboBoxKhuVuc";
            comboBoxKhuVuc.Size = new Size(205, 38);
            comboBoxKhuVuc.TabIndex = 31;
            comboBoxKhuVuc.Text = "Khu Vực";
            comboBoxKhuVuc.SelectedIndexChanged += comboBoxKhuVuc_SelectedIndexChanged;
            // 
            // labelBoPhan
            // 
            labelBoPhan.AutoSize = true;
            labelBoPhan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBoPhan.ForeColor = Color.IndianRed;
            labelBoPhan.Location = new Point(500, 21);
            labelBoPhan.Margin = new Padding(5, 0, 5, 0);
            labelBoPhan.Name = "labelBoPhan";
            labelBoPhan.Size = new Size(95, 30);
            labelBoPhan.TabIndex = 36;
            labelBoPhan.Text = "Bộ Phận";
            labelBoPhan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxBoPhan
            // 
            comboBoxBoPhan.FormattingEnabled = true;
            comboBoxBoPhan.Location = new Point(500, 57);
            comboBoxBoPhan.Margin = new Padding(5, 6, 5, 6);
            comboBoxBoPhan.Name = "comboBoxBoPhan";
            comboBoxBoPhan.Size = new Size(205, 38);
            comboBoxBoPhan.TabIndex = 35;
            comboBoxBoPhan.Text = "Bộ Phận";
            comboBoxBoPhan.SelectedIndexChanged += comboBoxBoPhan_SelectedIndexChanged;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(1008, 57);
            pictureBox3.Margin = new Padding(5, 6, 5, 6);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(103, 110);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 38;
            pictureBox3.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Viner Hand ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Maroon;
            labelTitle.Location = new Point(1039, 173);
            labelTitle.Margin = new Padding(5, 0, 5, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(73, 468);
            labelTitle.TabIndex = 37;
            labelTitle.Text = "S\r\nU\r\nS\r\nH\r\nI\r\nX\r\n";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(34, 145);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(112, 30);
            label1.TabIndex = 39;
            label1.Text = "Tìm Kiếm:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonXuatExcel
            // 
            buttonXuatExcel.BackColor = Color.RosyBrown;
            buttonXuatExcel.FlatAppearance.BorderColor = Color.RosyBrown;
            buttonXuatExcel.FlatAppearance.BorderSize = 2;
            buttonXuatExcel.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            buttonXuatExcel.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            buttonXuatExcel.ForeColor = Color.White;
            buttonXuatExcel.Location = new Point(827, 134);
            buttonXuatExcel.Margin = new Padding(5, 6, 5, 6);
            buttonXuatExcel.Name = "buttonXuatExcel";
            buttonXuatExcel.Size = new Size(171, 46);
            buttonXuatExcel.TabIndex = 40;
            buttonXuatExcel.Text = "Xuất Excel";
            buttonXuatExcel.UseVisualStyleBackColor = false;
            buttonXuatExcel.Click += buttonXuatExcel_Click;
            // 
            // buttonXemThongKe
            // 
            buttonXemThongKe.BackColor = Color.RosyBrown;
            buttonXemThongKe.FlatAppearance.BorderColor = Color.RosyBrown;
            buttonXemThongKe.FlatAppearance.BorderSize = 2;
            buttonXemThongKe.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            buttonXemThongKe.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            buttonXemThongKe.ForeColor = Color.White;
            buttonXemThongKe.Location = new Point(646, 134);
            buttonXemThongKe.Margin = new Padding(5, 6, 5, 6);
            buttonXemThongKe.Name = "buttonXemThongKe";
            buttonXemThongKe.Size = new Size(171, 46);
            buttonXemThongKe.TabIndex = 41;
            buttonXemThongKe.Text = "Xem thống kê";
            buttonXemThongKe.UseVisualStyleBackColor = false;
            buttonXemThongKe.Click += buttonXemThongKe_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.FlatAppearance.BorderColor = Color.RosyBrown;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            button1.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            button1.ForeColor = Color.White;
            button1.Location = new Point(737, 49);
            button1.Margin = new Padding(5, 6, 5, 6);
            button1.Name = "button1";
            button1.Size = new Size(261, 46);
            button1.TabIndex = 42;
            button1.Text = "Cập Nhật Lương";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Admin_ManageStaff
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1135, 774);
            Controls.Add(button1);
            Controls.Add(buttonXemThongKe);
            Controls.Add(buttonXuatExcel);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(labelTitle);
            Controls.Add(labelBoPhan);
            Controls.Add(comboBoxBoPhan);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBoxChiNhanh);
            Controls.Add(comboBoxKhuVuc);
            Controls.Add(dataGridViewNhanVien);
            Controls.Add(textBoxTimKiem);
            Name = "Admin_ManageStaff";
            Text = "Quản lý nhân sự";
            ((System.ComponentModel.ISupportInitialize)dataGridViewNhanVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private ComboBox comboBoxChiNhanh;
        private ComboBox comboBoxKhuVuc;
        private Label labelBoPhan;
        private ComboBox comboBoxBoPhan;
        private PictureBox pictureBox3;
        private Label labelTitle;
        private Label label1;
        private Button buttonXuatExcel;
        private Button buttonXemThongKe;
        private Button button1;
    }
}