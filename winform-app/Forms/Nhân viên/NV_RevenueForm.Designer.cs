namespace winform_app.Forms.Nhân_viên
{
    partial class NV_RevenueForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxKhuVuc;
        private System.Windows.Forms.ComboBox comboBoxChiNhanh;
        private System.Windows.Forms.DateTimePicker dateTimePickerTuNgay;
        private System.Windows.Forms.DateTimePicker dateTimePickerDenNgay;
        private System.Windows.Forms.Button buttonXemThongKe;
        private System.Windows.Forms.Button buttonXuatExcel;
        private System.Windows.Forms.DataGridView dataGridViewKetQua;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NV_RevenueForm));
            comboBoxKhuVuc = new ComboBox();
            comboBoxChiNhanh = new ComboBox();
            dateTimePickerTuNgay = new DateTimePicker();
            dateTimePickerDenNgay = new DateTimePicker();
            buttonXemThongKe = new Button();
            buttonXuatExcel = new Button();
            dataGridViewKetQua = new DataGridView();
            labelTitle = new Label();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKetQua).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // comboBoxKhuVuc
            // 
            comboBoxKhuVuc.FormattingEnabled = true;
            comboBoxKhuVuc.Location = new Point(38, 40);
            comboBoxKhuVuc.Margin = new Padding(5, 6, 5, 6);
            comboBoxKhuVuc.Name = "comboBoxKhuVuc";
            comboBoxKhuVuc.Size = new Size(205, 38);
            comboBoxKhuVuc.TabIndex = 1;
            comboBoxKhuVuc.Text = "Khu Vực";
            comboBoxKhuVuc.SelectedIndexChanged += comboBoxKhuVuc_SelectedIndexChanged;
            // 
            // comboBoxChiNhanh
            // 
            comboBoxChiNhanh.FormattingEnabled = true;
            comboBoxChiNhanh.Location = new Point(412, 40);
            comboBoxChiNhanh.Margin = new Padding(5, 6, 5, 6);
            comboBoxChiNhanh.Name = "comboBoxChiNhanh";
            comboBoxChiNhanh.Size = new Size(205, 38);
            comboBoxChiNhanh.TabIndex = 2;
            comboBoxChiNhanh.Text = "Chi Nhánh";
            comboBoxChiNhanh.SelectedIndexChanged += comboBoxChiNhanh_SelectedIndexChanged;
            // 
            // dateTimePickerTuNgay
            // 
            dateTimePickerTuNgay.Location = new Point(38, 148);
            dateTimePickerTuNgay.Margin = new Padding(5, 6, 5, 6);
            dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            dateTimePickerTuNgay.Size = new Size(340, 35);
            dateTimePickerTuNgay.TabIndex = 3;
            dateTimePickerTuNgay.ValueChanged += dateTimePickerTuNgay_ValueChanged;
            // 
            // dateTimePickerDenNgay
            // 
            dateTimePickerDenNgay.Location = new Point(412, 148);
            dateTimePickerDenNgay.Margin = new Padding(5, 6, 5, 6);
            dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            dateTimePickerDenNgay.Size = new Size(340, 35);
            dateTimePickerDenNgay.TabIndex = 4;
            // 
            // buttonXemThongKe
            // 
            buttonXemThongKe.BackColor = Color.RosyBrown;
            buttonXemThongKe.FlatAppearance.BorderColor = Color.RosyBrown;
            buttonXemThongKe.FlatAppearance.BorderSize = 2;
            buttonXemThongKe.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            buttonXemThongKe.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            buttonXemThongKe.ForeColor = Color.White;
            buttonXemThongKe.Location = new Point(669, 220);
            buttonXemThongKe.Margin = new Padding(5, 6, 5, 6);
            buttonXemThongKe.Name = "buttonXemThongKe";
            buttonXemThongKe.Size = new Size(171, 46);
            buttonXemThongKe.TabIndex = 8;
            buttonXemThongKe.Text = "Xem thống kê";
            buttonXemThongKe.UseVisualStyleBackColor = false;
            buttonXemThongKe.Click += buttonXemThongKe_Click;
            // 
            // buttonXuatExcel
            // 
            buttonXuatExcel.BackColor = Color.RosyBrown;
            buttonXuatExcel.FlatAppearance.BorderColor = Color.RosyBrown;
            buttonXuatExcel.FlatAppearance.BorderSize = 2;
            buttonXuatExcel.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            buttonXuatExcel.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            buttonXuatExcel.ForeColor = Color.White;
            buttonXuatExcel.Location = new Point(850, 220);
            buttonXuatExcel.Margin = new Padding(5, 6, 5, 6);
            buttonXuatExcel.Name = "buttonXuatExcel";
            buttonXuatExcel.Size = new Size(171, 46);
            buttonXuatExcel.TabIndex = 9;
            buttonXuatExcel.Text = "Xuất Excel";
            buttonXuatExcel.UseVisualStyleBackColor = false;
            buttonXuatExcel.Click += buttonXuatExcel_Click;
            // 
            // dataGridViewKetQua
            // 
            dataGridViewKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKetQua.Location = new Point(38, 278);
            dataGridViewKetQua.Margin = new Padding(5, 6, 5, 6);
            dataGridViewKetQua.Name = "dataGridViewKetQua";
            dataGridViewKetQua.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewKetQua.Size = new Size(994, 450);
            dataGridViewKetQua.TabIndex = 11;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Viner Hand ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Maroon;
            labelTitle.Location = new Point(1042, 140);
            labelTitle.Margin = new Padding(5, 0, 5, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(73, 468);
            labelTitle.TabIndex = 12;
            labelTitle.Text = "S\r\nU\r\nS\r\nH\r\nI\r\nX\r\n";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(1011, 24);
            pictureBox3.Margin = new Padding(5, 6, 5, 6);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(103, 110);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 13;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(38, 112);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(93, 30);
            label1.TabIndex = 14;
            label1.Text = "Từ ngày";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(412, 112);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(110, 30);
            label2.TabIndex = 15;
            label2.Text = "Đến Ngày";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.IndianRed;
            label3.Location = new Point(38, 4);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(94, 30);
            label3.TabIndex = 16;
            label3.Text = "Khu vực";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.IndianRed;
            label4.Location = new Point(412, 4);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(118, 30);
            label4.TabIndex = 17;
            label4.Text = "Chi Nhánh";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NV_RevenueForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1135, 774);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(labelTitle);
            Controls.Add(dataGridViewKetQua);
            Controls.Add(buttonXuatExcel);
            Controls.Add(buttonXemThongKe);
            Controls.Add(dateTimePickerDenNgay);
            Controls.Add(dateTimePickerTuNgay);
            Controls.Add(comboBoxChiNhanh);
            Controls.Add(comboBoxKhuVuc);
            Margin = new Padding(5, 6, 5, 6);
            Name = "NV_RevenueForm";
            Text = "Thống kê doanh thu chi nhánh";
            ((System.ComponentModel.ISupportInitialize)dataGridViewKetQua).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private PictureBox pictureBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}