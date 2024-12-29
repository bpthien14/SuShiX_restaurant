namespace winform_app.Forms.Nhân_viên
{
    partial class Manager_RevenueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager_RevenueForm));
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            comboBoxFood = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            labelTitle = new Label();
            dataGridViewKetQua = new DataGridView();
            buttonXuatExcel = new Button();
            buttonXemThongKe = new Button();
            dateTimePickerDenNgay = new DateTimePicker();
            dateTimePickerTuNgay = new DateTimePicker();
            labelKhuVuc = new Label();
            labelChiNhanh = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKetQua).BeginInit();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 8.142858F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.IndianRed;
            label8.Location = new Point(29, 259);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(468, 28);
            label8.TabIndex = 53;
            label8.Text = "Món chậm: Top 20% món có doanh thu thấp nhất";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 8.142858F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.IndianRed;
            label7.Location = new Point(29, 231);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(450, 28);
            label7.TabIndex = 52;
            label7.Text = "Món chạy: Top 20% món có doanh thu cao nhất";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.IndianRed;
            label6.Location = new Point(29, 201);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(89, 30);
            label6.TabIndex = 51;
            label6.Text = "Ghi chú";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.IndianRed;
            label5.Location = new Point(29, 70);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(89, 30);
            label5.TabIndex = 50;
            label5.Text = "Món ăn";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxFood
            // 
            comboBoxFood.FormattingEnabled = true;
            comboBoxFood.Location = new Point(146, 70);
            comboBoxFood.Margin = new Padding(5, 6, 5, 6);
            comboBoxFood.Name = "comboBoxFood";
            comboBoxFood.Size = new Size(223, 38);
            comboBoxFood.TabIndex = 49;
            comboBoxFood.Text = "Món ăn";
            comboBoxFood.SelectedIndexChanged += comboBoxFood_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.IndianRed;
            label4.Location = new Point(403, 25);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(118, 30);
            label4.TabIndex = 48;
            label4.Text = "Chi Nhánh";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.IndianRed;
            label3.Location = new Point(29, 25);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(94, 30);
            label3.TabIndex = 47;
            label3.Text = "Khu vực";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(403, 113);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(110, 30);
            label2.TabIndex = 46;
            label2.Text = "Đến Ngày";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(29, 113);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(93, 30);
            label1.TabIndex = 45;
            label1.Text = "Từ ngày";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(1002, 45);
            pictureBox3.Margin = new Padding(5, 6, 5, 6);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(103, 110);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 44;
            pictureBox3.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Viner Hand ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Maroon;
            labelTitle.Location = new Point(1033, 161);
            labelTitle.Margin = new Padding(5, 0, 5, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(73, 468);
            labelTitle.TabIndex = 43;
            labelTitle.Text = "S\r\nU\r\nS\r\nH\r\nI\r\nX\r\n";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridViewKetQua
            // 
            dataGridViewKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKetQua.Location = new Point(29, 299);
            dataGridViewKetQua.Margin = new Padding(5, 6, 5, 6);
            dataGridViewKetQua.Name = "dataGridViewKetQua";
            dataGridViewKetQua.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewKetQua.Size = new Size(994, 410);
            dataGridViewKetQua.TabIndex = 42;
            // 
            // buttonXuatExcel
            // 
            buttonXuatExcel.BackColor = Color.RosyBrown;
            buttonXuatExcel.FlatAppearance.BorderColor = Color.RosyBrown;
            buttonXuatExcel.FlatAppearance.BorderSize = 2;
            buttonXuatExcel.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            buttonXuatExcel.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            buttonXuatExcel.ForeColor = Color.White;
            buttonXuatExcel.Location = new Point(841, 241);
            buttonXuatExcel.Margin = new Padding(5, 6, 5, 6);
            buttonXuatExcel.Name = "buttonXuatExcel";
            buttonXuatExcel.Size = new Size(171, 46);
            buttonXuatExcel.TabIndex = 41;
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
            buttonXemThongKe.Location = new Point(660, 241);
            buttonXemThongKe.Margin = new Padding(5, 6, 5, 6);
            buttonXemThongKe.Name = "buttonXemThongKe";
            buttonXemThongKe.Size = new Size(171, 46);
            buttonXemThongKe.TabIndex = 40;
            buttonXemThongKe.Text = "Xem thống kê";
            buttonXemThongKe.UseVisualStyleBackColor = false;
            buttonXemThongKe.Click += buttonXemThongKe_Click;
            // 
            // dateTimePickerDenNgay
            // 
            dateTimePickerDenNgay.Location = new Point(403, 149);
            dateTimePickerDenNgay.Margin = new Padding(5, 6, 5, 6);
            dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            dateTimePickerDenNgay.Size = new Size(340, 35);
            dateTimePickerDenNgay.TabIndex = 39;
            // 
            // dateTimePickerTuNgay
            // 
            dateTimePickerTuNgay.Location = new Point(29, 149);
            dateTimePickerTuNgay.Margin = new Padding(5, 6, 5, 6);
            dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            dateTimePickerTuNgay.Size = new Size(340, 35);
            dateTimePickerTuNgay.TabIndex = 38;
            // 
            // labelKhuVuc
            // 
            labelKhuVuc.AutoSize = true;
            labelKhuVuc.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelKhuVuc.ForeColor = Color.IndianRed;
            labelKhuVuc.Location = new Point(146, 25);
            labelKhuVuc.Margin = new Padding(5, 0, 5, 0);
            labelKhuVuc.Name = "labelKhuVuc";
            labelKhuVuc.Size = new Size(90, 30);
            labelKhuVuc.TabIndex = 54;
            labelKhuVuc.Text = "Khu vực";
            labelKhuVuc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelChiNhanh
            // 
            labelChiNhanh.AutoSize = true;
            labelChiNhanh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelChiNhanh.ForeColor = Color.IndianRed;
            labelChiNhanh.Location = new Point(549, 25);
            labelChiNhanh.Margin = new Padding(5, 0, 5, 0);
            labelChiNhanh.Name = "labelChiNhanh";
            labelChiNhanh.Size = new Size(112, 30);
            labelChiNhanh.TabIndex = 55;
            labelChiNhanh.Text = "Chi Nhánh";
            labelChiNhanh.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Manager_RevenueForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1135, 774);
            Controls.Add(labelChiNhanh);
            Controls.Add(labelKhuVuc);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(comboBoxFood);
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
            Name = "Manager_RevenueForm";
            Text = "Thống kê doanh thu";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKetQua).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private ComboBox comboBoxFood;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox3;
        private Label labelTitle;
        private DataGridView dataGridViewKetQua;
        private Button buttonXuatExcel;
        private Button buttonXemThongKe;
        private DateTimePicker dateTimePickerDenNgay;
        private DateTimePicker dateTimePickerTuNgay;
        private Label labelKhuVuc;
        private Label labelChiNhanh;
    }
}