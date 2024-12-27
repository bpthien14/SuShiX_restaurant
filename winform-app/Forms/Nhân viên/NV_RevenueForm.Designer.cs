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
        private System.Windows.Forms.RadioButton radioButtonNgay;
        private System.Windows.Forms.RadioButton radioButtonThang;
        private System.Windows.Forms.RadioButton radioButtonQuy;
        private System.Windows.Forms.RadioButton radioButtonNam;
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
            radioButtonNgay = new RadioButton();
            radioButtonThang = new RadioButton();
            radioButtonQuy = new RadioButton();
            radioButtonNam = new RadioButton();
            buttonXemThongKe = new Button();
            buttonXuatExcel = new Button();
            dataGridViewKetQua = new DataGridView();
            labelTitle = new Label();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKetQua).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // comboBoxKhuVuc
            // 
            comboBoxKhuVuc.FormattingEnabled = true;
            comboBoxKhuVuc.Location = new Point(18, 35);
            comboBoxKhuVuc.Name = "comboBoxKhuVuc";
            comboBoxKhuVuc.Size = new Size(121, 23);
            comboBoxKhuVuc.TabIndex = 1;
            comboBoxKhuVuc.Text = "Khu Vực";
            // 
            // comboBoxChiNhanh
            // 
            comboBoxChiNhanh.FormattingEnabled = true;
            comboBoxChiNhanh.Location = new Point(236, 35);
            comboBoxChiNhanh.Name = "comboBoxChiNhanh";
            comboBoxChiNhanh.Size = new Size(121, 23);
            comboBoxChiNhanh.TabIndex = 2;
            comboBoxChiNhanh.Text = "Chi Nhánh";
            // 
            // dateTimePickerTuNgay
            // 
            dateTimePickerTuNgay.Location = new Point(18, 89);
            dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            dateTimePickerTuNgay.Size = new Size(200, 23);
            dateTimePickerTuNgay.TabIndex = 3;
            dateTimePickerTuNgay.ValueChanged += dateTimePickerTuNgay_ValueChanged;
            // 
            // dateTimePickerDenNgay
            // 
            dateTimePickerDenNgay.Location = new Point(236, 89);
            dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            dateTimePickerDenNgay.Size = new Size(200, 23);
            dateTimePickerDenNgay.TabIndex = 4;
            // 
            // radioButtonNgay
            // 
            radioButtonNgay.AutoSize = true;
            radioButtonNgay.BackColor = Color.White;
            radioButtonNgay.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButtonNgay.ForeColor = Color.IndianRed;
            radioButtonNgay.Location = new Point(18, 125);
            radioButtonNgay.Name = "radioButtonNgay";
            radioButtonNgay.Size = new Size(53, 19);
            radioButtonNgay.TabIndex = 1;
            radioButtonNgay.TabStop = true;
            radioButtonNgay.Text = "Ngày";
            radioButtonNgay.UseVisualStyleBackColor = false;
            // 
            // radioButtonThang
            // 
            radioButtonThang.AutoSize = true;
            radioButtonThang.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButtonThang.ForeColor = Color.IndianRed;
            radioButtonThang.Location = new Point(76, 125);
            radioButtonThang.Name = "radioButtonThang";
            radioButtonThang.Size = new Size(59, 19);
            radioButtonThang.TabIndex = 5;
            radioButtonThang.TabStop = true;
            radioButtonThang.Text = "Tháng";
            radioButtonThang.UseVisualStyleBackColor = true;
            // 
            // radioButtonQuy
            // 
            radioButtonQuy.AutoSize = true;
            radioButtonQuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButtonQuy.ForeColor = Color.IndianRed;
            radioButtonQuy.Location = new Point(146, 125);
            radioButtonQuy.Name = "radioButtonQuy";
            radioButtonQuy.Size = new Size(47, 19);
            radioButtonQuy.TabIndex = 6;
            radioButtonQuy.TabStop = true;
            radioButtonQuy.Text = "Quý";
            radioButtonQuy.UseVisualStyleBackColor = true;
            // 
            // radioButtonNam
            // 
            radioButtonNam.AutoSize = true;
            radioButtonNam.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButtonNam.ForeColor = Color.IndianRed;
            radioButtonNam.Location = new Point(206, 125);
            radioButtonNam.Name = "radioButtonNam";
            radioButtonNam.Size = new Size(51, 19);
            radioButtonNam.TabIndex = 7;
            radioButtonNam.TabStop = true;
            radioButtonNam.Text = "Năm";
            radioButtonNam.UseVisualStyleBackColor = true;
            // 
            // buttonXemThongKe
            // 
            buttonXemThongKe.BackColor = Color.RosyBrown;
            buttonXemThongKe.FlatAppearance.BorderColor = Color.RosyBrown;
            buttonXemThongKe.FlatAppearance.BorderSize = 2;
            buttonXemThongKe.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            buttonXemThongKe.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            buttonXemThongKe.ForeColor = Color.White;
            buttonXemThongKe.Location = new Point(386, 125);
            buttonXemThongKe.Name = "buttonXemThongKe";
            buttonXemThongKe.Size = new Size(100, 23);
            buttonXemThongKe.TabIndex = 8;
            buttonXemThongKe.Text = "Xem thống kê";
            buttonXemThongKe.UseVisualStyleBackColor = false;
            // 
            // buttonXuatExcel
            // 
            buttonXuatExcel.BackColor = Color.RosyBrown;
            buttonXuatExcel.FlatAppearance.BorderColor = Color.RosyBrown;
            buttonXuatExcel.FlatAppearance.BorderSize = 2;
            buttonXuatExcel.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            buttonXuatExcel.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            buttonXuatExcel.ForeColor = Color.White;
            buttonXuatExcel.Location = new Point(492, 125);
            buttonXuatExcel.Name = "buttonXuatExcel";
            buttonXuatExcel.Size = new Size(100, 23);
            buttonXuatExcel.TabIndex = 9;
            buttonXuatExcel.Text = "Xuất Excel";
            buttonXuatExcel.UseVisualStyleBackColor = false;
            // 
            // dataGridViewKetQua
            // 
            dataGridViewKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKetQua.Location = new Point(18, 150);
            dataGridViewKetQua.Name = "dataGridViewKetQua";
            dataGridViewKetQua.Size = new Size(580, 225);
            dataGridViewKetQua.TabIndex = 11;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Viner Hand ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Maroon;
            labelTitle.Location = new Point(608, 70);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(42, 264);
            labelTitle.TabIndex = 12;
            labelTitle.Text = "S\r\nU\r\nS\r\nH\r\nI\r\nX\r\n";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(590, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(60, 55);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 13;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(18, 71);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 14;
            label1.Text = "Từ ngày";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(236, 71);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 15;
            label2.Text = "Đến Ngày";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NV_RevenueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(662, 387);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(labelTitle);
            Controls.Add(dataGridViewKetQua);
            Controls.Add(buttonXuatExcel);
            Controls.Add(buttonXemThongKe);
            Controls.Add(radioButtonNam);
            Controls.Add(radioButtonQuy);
            Controls.Add(radioButtonThang);
            Controls.Add(radioButtonNgay);
            Controls.Add(dateTimePickerDenNgay);
            Controls.Add(dateTimePickerTuNgay);
            Controls.Add(comboBoxChiNhanh);
            Controls.Add(comboBoxKhuVuc);
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
    }
}