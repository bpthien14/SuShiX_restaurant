namespace winform_app.Forms.Nhân_viên
{
    partial class Manager_MenuItemsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager_MenuItemsForm));
            label5 = new Label();
            comboBoxCategory = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            labelTitle = new Label();
            dataGridViewKetQua = new DataGridView();
            labelKhuVuc = new Label();
            labelChiNhanh = new Label();
            label1 = new Label();
            button1 = new Button();
            buttonSave = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKetQua).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.IndianRed;
            label5.Location = new Point(29, 76);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(105, 30);
            label5.TabIndex = 50;
            label5.Text = "Phân loại";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(146, 72);
            comboBoxCategory.Margin = new Padding(5, 6, 5, 6);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(398, 38);
            comboBoxCategory.TabIndex = 49;
            comboBoxCategory.Text = "Phân loại";
            comboBoxCategory.SelectedIndexChanged += comboBoxCategory_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.IndianRed;
            label4.Location = new Point(291, 18);
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
            label3.Location = new Point(29, 24);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(94, 30);
            label3.TabIndex = 47;
            label3.Text = "Khu vực";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(1001, 44);
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
            labelTitle.Location = new Point(1034, 160);
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
            dataGridViewKetQua.Location = new Point(29, 160);
            dataGridViewKetQua.Margin = new Padding(5, 6, 5, 6);
            dataGridViewKetQua.Name = "dataGridViewKetQua";
            dataGridViewKetQua.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewKetQua.Size = new Size(970, 396);
            dataGridViewKetQua.TabIndex = 42;
            dataGridViewKetQua.CellValueChanged += dataGridViewKetQua_CellValueChanged_1;
            dataGridViewKetQua.UserAddedRow += dataGridViewKetQua_UserAddedRow_1;
            // 
            // labelKhuVuc
            // 
            labelKhuVuc.AutoSize = true;
            labelKhuVuc.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelKhuVuc.ForeColor = Color.IndianRed;
            labelKhuVuc.Location = new Point(146, 24);
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
            labelChiNhanh.Location = new Point(439, 18);
            labelChiNhanh.Margin = new Padding(5, 0, 5, 0);
            labelChiNhanh.Name = "labelChiNhanh";
            labelChiNhanh.Size = new Size(112, 30);
            labelChiNhanh.TabIndex = 55;
            labelChiNhanh.Text = "Chi Nhánh";
            labelChiNhanh.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(29, 124);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(195, 30);
            label1.TabIndex = 56;
            label1.Text = "Danh sách món ăn";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.FlatAppearance.BorderColor = Color.RosyBrown;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            button1.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            button1.ForeColor = Color.White;
            button1.Location = new Point(830, 568);
            button1.Margin = new Padding(5, 6, 5, 6);
            button1.Name = "button1";
            button1.Size = new Size(171, 46);
            button1.TabIndex = 57;
            button1.Text = "Xuất Excel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.RosyBrown;
            buttonSave.FlatAppearance.BorderColor = Color.RosyBrown;
            buttonSave.FlatAppearance.BorderSize = 2;
            buttonSave.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            buttonSave.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(648, 568);
            buttonSave.Margin = new Padding(5, 6, 5, 6);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(171, 46);
            buttonSave.TabIndex = 58;
            buttonSave.Text = "Lưu ";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // Manager_MenuItemsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1135, 640);
            Controls.Add(buttonSave);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(labelChiNhanh);
            Controls.Add(labelKhuVuc);
            Controls.Add(label5);
            Controls.Add(comboBoxCategory);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox3);
            Controls.Add(labelTitle);
            Controls.Add(dataGridViewKetQua);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Manager_MenuItemsForm";
            Text = "Thống kê doanh thu";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKetQua).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private ComboBox comboBoxCategory;
        private Label label4;
        private Label label3;
        private PictureBox pictureBox3;
        private Label labelTitle;
        private DataGridView dataGridViewKetQua;
        private Label labelKhuVuc;
        private Label labelChiNhanh;
        private Label label1;
        private Button button1;
        private Button buttonSave;
    }
}