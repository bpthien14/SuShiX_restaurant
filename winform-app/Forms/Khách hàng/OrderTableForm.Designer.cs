namespace winform_app.Forms.Khách_hàng
{
    partial class OrderTableForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label lblRegionName;
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.Label lblBookingDate;
        private System.Windows.Forms.Label lblArrivalTime;
        private System.Windows.Forms.Label lblGuestCount;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.ComboBox cmbRegionName;
        private System.Windows.Forms.ComboBox cmbBranchName;
        private System.Windows.Forms.DateTimePicker dtpBookingDate;
        private System.Windows.Forms.DateTimePicker dtpArrivalTime;
        private System.Windows.Forms.NumericUpDown numGuestCount;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnBookTable;

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
            lblCustomerName = new Label();
            lblCustomerPhone = new Label();
            lblRegionName = new Label();
            lblBranchName = new Label();
            lblBookingDate = new Label();
            lblArrivalTime = new Label();
            lblGuestCount = new Label();
            lblNotes = new Label();
            txtCustomerName = new TextBox();
            txtCustomerPhone = new TextBox();
            cmbRegionName = new ComboBox();
            cmbBranchName = new ComboBox();
            dtpBookingDate = new DateTimePicker();
            dtpArrivalTime = new DateTimePicker();
            numGuestCount = new NumericUpDown();
            txtNotes = new TextBox();
            btnBack = new Button();
            btnBookTable = new Button();
            ((System.ComponentModel.ISupportInitialize)numGuestCount).BeginInit();
            SuspendLayout();
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(24, 35);
            lblCustomerName.Margin = new Padding(6, 0, 6, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(81, 30);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "Họ tên:";
            // 
            // lblCustomerPhone
            // 
            lblCustomerPhone.AutoSize = true;
            lblCustomerPhone.Location = new Point(24, 104);
            lblCustomerPhone.Margin = new Padding(6, 0, 6, 0);
            lblCustomerPhone.Name = "lblCustomerPhone";
            lblCustomerPhone.Size = new Size(55, 30);
            lblCustomerPhone.TabIndex = 2;
            lblCustomerPhone.Text = "SĐT:";
            // 
            // lblRegionName
            // 
            lblRegionName.AutoSize = true;
            lblRegionName.Location = new Point(24, 173);
            lblRegionName.Margin = new Padding(6, 0, 6, 0);
            lblRegionName.Name = "lblRegionName";
            lblRegionName.Size = new Size(92, 30);
            lblRegionName.TabIndex = 4;
            lblRegionName.Text = "Khu vực:";
            // 
            // lblBranchName
            // 
            lblBranchName.AutoSize = true;
            lblBranchName.Location = new Point(24, 242);
            lblBranchName.Margin = new Padding(6, 0, 6, 0);
            lblBranchName.Name = "lblBranchName";
            lblBranchName.Size = new Size(113, 30);
            lblBranchName.TabIndex = 6;
            lblBranchName.Text = "Chi nhánh:";
            // 
            // lblBookingDate
            // 
            lblBookingDate.AutoSize = true;
            lblBookingDate.Location = new Point(24, 312);
            lblBookingDate.Margin = new Padding(6, 0, 6, 0);
            lblBookingDate.Name = "lblBookingDate";
            lblBookingDate.Size = new Size(67, 30);
            lblBookingDate.TabIndex = 8;
            lblBookingDate.Text = "Ngày:";
            // 
            // lblArrivalTime
            // 
            lblArrivalTime.AutoSize = true;
            lblArrivalTime.Location = new Point(24, 381);
            lblArrivalTime.Margin = new Padding(6, 0, 6, 0);
            lblArrivalTime.Name = "lblArrivalTime";
            lblArrivalTime.Size = new Size(50, 30);
            lblArrivalTime.TabIndex = 10;
            lblArrivalTime.Text = "Giờ:";
            // 
            // lblGuestCount
            // 
            lblGuestCount.AutoSize = true;
            lblGuestCount.Location = new Point(24, 450);
            lblGuestCount.Margin = new Padding(6, 0, 6, 0);
            lblGuestCount.Name = "lblGuestCount";
            lblGuestCount.Size = new Size(102, 30);
            lblGuestCount.TabIndex = 12;
            lblGuestCount.Text = "Số khách:";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(24, 519);
            lblNotes.Margin = new Padding(6, 0, 6, 0);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(89, 30);
            lblNotes.TabIndex = 14;
            lblNotes.Text = "Ghi chú:";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(240, 28);
            txtCustomerName.Margin = new Padding(6, 7, 6, 7);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(396, 35);
            txtCustomerName.TabIndex = 1;
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.Location = new Point(240, 97);
            txtCustomerPhone.Margin = new Padding(6, 7, 6, 7);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.Size = new Size(396, 35);
            txtCustomerPhone.TabIndex = 3;
            // 
            // cmbRegionName
            // 
            cmbRegionName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRegionName.FormattingEnabled = true;
            cmbRegionName.Location = new Point(240, 166);
            cmbRegionName.Margin = new Padding(6, 7, 6, 7);
            cmbRegionName.Name = "cmbRegionName";
            cmbRegionName.Size = new Size(396, 38);
            cmbRegionName.TabIndex = 5;
            cmbRegionName.SelectedIndexChanged += cmbRegionName_SelectedIndexChanged;
            // 
            // cmbBranchName
            // 
            cmbBranchName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranchName.FormattingEnabled = true;
            cmbBranchName.Location = new Point(240, 235);
            cmbBranchName.Margin = new Padding(6, 7, 6, 7);
            cmbBranchName.Name = "cmbBranchName";
            cmbBranchName.Size = new Size(396, 38);
            cmbBranchName.TabIndex = 7;
            // 
            // dtpBookingDate
            // 
            dtpBookingDate.Location = new Point(240, 305);
            dtpBookingDate.Margin = new Padding(6, 7, 6, 7);
            dtpBookingDate.Name = "dtpBookingDate";
            dtpBookingDate.Size = new Size(396, 35);
            dtpBookingDate.TabIndex = 9;
            // 
            // dtpArrivalTime
            // 
            dtpArrivalTime.Format = DateTimePickerFormat.Time;
            dtpArrivalTime.Location = new Point(240, 374);
            dtpArrivalTime.Margin = new Padding(6, 7, 6, 7);
            dtpArrivalTime.Name = "dtpArrivalTime";
            dtpArrivalTime.Size = new Size(396, 35);
            dtpArrivalTime.TabIndex = 11;
            // 
            // numGuestCount
            // 
            numGuestCount.Location = new Point(240, 443);
            numGuestCount.Margin = new Padding(6, 7, 6, 7);
            numGuestCount.Name = "numGuestCount";
            numGuestCount.Size = new Size(400, 35);
            numGuestCount.TabIndex = 13;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(240, 512);
            txtNotes.Margin = new Padding(6, 7, 6, 7);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(396, 133);
            txtNotes.TabIndex = 15;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.RosyBrown;
            btnBack.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(240, 692);
            btnBack.Margin = new Padding(6, 7, 6, 7);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(190, 53);
            btnBack.TabIndex = 16;
            btnBack.Text = "Đóng";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnBookTable
            // 
            btnBookTable.BackColor = Color.RosyBrown;
            btnBookTable.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnBookTable.ForeColor = Color.White;
            btnBookTable.Location = new Point(450, 692);
            btnBookTable.Margin = new Padding(6, 7, 6, 7);
            btnBookTable.Name = "btnBookTable";
            btnBookTable.Size = new Size(190, 53);
            btnBookTable.TabIndex = 17;
            btnBookTable.Text = "Đặt bàn";
            btnBookTable.UseVisualStyleBackColor = false;
            btnBookTable.Click += btnBookTable_Click;
            // 
            // OrderTableForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(676, 773);
            Controls.Add(btnBookTable);
            Controls.Add(btnBack);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(numGuestCount);
            Controls.Add(lblGuestCount);
            Controls.Add(dtpArrivalTime);
            Controls.Add(lblArrivalTime);
            Controls.Add(dtpBookingDate);
            Controls.Add(lblBookingDate);
            Controls.Add(cmbBranchName);
            Controls.Add(lblBranchName);
            Controls.Add(cmbRegionName);
            Controls.Add(lblRegionName);
            Controls.Add(txtCustomerPhone);
            Controls.Add(lblCustomerPhone);
            Controls.Add(txtCustomerName);
            Controls.Add(lblCustomerName);
            Margin = new Padding(6, 7, 6, 7);
            Name = "OrderTableForm";
            Text = "Đặt bàn";
            ((System.ComponentModel.ISupportInitialize)numGuestCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
