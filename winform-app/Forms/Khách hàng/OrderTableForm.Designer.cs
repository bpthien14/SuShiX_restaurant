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
            this.components = new System.ComponentModel.Container();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.lblRegionName = new System.Windows.Forms.Label();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.lblBookingDate = new System.Windows.Forms.Label();
            this.lblArrivalTime = new System.Windows.Forms.Label();
            this.lblGuestCount = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.cmbRegionName = new System.Windows.Forms.ComboBox();
            this.cmbBranchName = new System.Windows.Forms.ComboBox();
            this.dtpBookingDate = new System.Windows.Forms.DateTimePicker();
            this.dtpArrivalTime = new System.Windows.Forms.DateTimePicker();
            this.numGuestCount = new System.Windows.Forms.NumericUpDown();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnBookTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numGuestCount)).BeginInit();
            this.SuspendLayout();

            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(12, 15);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(54, 13);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Họ tên:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(120, 12);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(200, 20);
            this.txtCustomerName.TabIndex = 1;
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Location = new System.Drawing.Point(12, 45);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(54, 13);
            this.lblCustomerPhone.TabIndex = 2;
            this.lblCustomerPhone.Text = "SĐT:";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(120, 42);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(200, 20);
            this.txtCustomerPhone.TabIndex = 3;
            // 
            // lblRegionName
            // 
            this.lblRegionName.AutoSize = true;
            this.lblRegionName.Location = new System.Drawing.Point(12, 75);
            this.lblRegionName.Name = "lblRegionName";
            this.lblRegionName.Size = new System.Drawing.Size(54, 13);
            this.lblRegionName.TabIndex = 4;
            this.lblRegionName.Text = "Khu vực:";
            // 
            // cmbRegionName
            // 
            this.cmbRegionName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegionName.FormattingEnabled = true;
            this.cmbRegionName.Location = new System.Drawing.Point(120, 72);
            this.cmbRegionName.Name = "cmbRegionName";
            this.cmbRegionName.Size = new System.Drawing.Size(200, 21);
            this.cmbRegionName.TabIndex = 5;
            this.cmbRegionName.SelectedIndexChanged += new System.EventHandler(this.cmbRegionName_SelectedIndexChanged);
            // 
            // lblBranchName
            // 
            this.lblBranchName.AutoSize = true;
            this.lblBranchName.Location = new System.Drawing.Point(12, 105);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(54, 13);
            this.lblBranchName.TabIndex = 6;
            this.lblBranchName.Text = "Chi nhánh:";
            // 
            // cmbBranchName
            // 
            this.cmbBranchName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranchName.FormattingEnabled = true;
            this.cmbBranchName.Location = new System.Drawing.Point(120, 102);
            this.cmbBranchName.Name = "cmbBranchName";
            this.cmbBranchName.Size = new System.Drawing.Size(200, 21);
            this.cmbBranchName.TabIndex = 7;
            // 
            // lblBookingDate
            // 
            this.lblBookingDate.AutoSize = true;
            this.lblBookingDate.Location = new System.Drawing.Point(12, 135);
            this.lblBookingDate.Name = "lblBookingDate";
            this.lblBookingDate.Size = new System.Drawing.Size(54, 13);
            this.lblBookingDate.TabIndex = 8;
            this.lblBookingDate.Text = "Ngày:";
            // 
            // dtpBookingDate
            // 
            this.dtpBookingDate.Location = new System.Drawing.Point(120, 132);
            this.dtpBookingDate.Name = "dtpBookingDate";
            this.dtpBookingDate.Size = new System.Drawing.Size(200, 20);
            this.dtpBookingDate.TabIndex = 9;
            // 
            // lblArrivalTime
            // 
            this.lblArrivalTime.AutoSize = true;
            this.lblArrivalTime.Location = new System.Drawing.Point(12, 165);
            this.lblArrivalTime.Name = "lblArrivalTime";
            this.lblArrivalTime.Size = new System.Drawing.Size(54, 13);
            this.lblArrivalTime.TabIndex = 10;
            this.lblArrivalTime.Text = "Giờ:";
            // 
            // dtpArrivalTime
            // 
            this.dtpArrivalTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpArrivalTime.Location = new System.Drawing.Point(120, 162);
            this.dtpArrivalTime.Name = "dtpArrivalTime";
            this.dtpArrivalTime.Size = new System.Drawing.Size(200, 20);
            this.dtpArrivalTime.TabIndex = 11;
            // 
            // lblGuestCount
            // 
            this.lblGuestCount.AutoSize = true;
            this.lblGuestCount.Location = new System.Drawing.Point(12, 195);
            this.lblGuestCount.Name = "lblGuestCount";
            this.lblGuestCount.Size = new System.Drawing.Size(54, 13);
            this.lblGuestCount.TabIndex = 12;
            this.lblGuestCount.Text = "Số khách:";
            // 
            // numGuestCount
            // 
            this.numGuestCount.Location = new System.Drawing.Point(120, 192);
            this.numGuestCount.Name = "numGuestCount";
            this.numGuestCount.Size = new System.Drawing.Size(200, 20);
            this.numGuestCount.TabIndex = 13;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(12, 225);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(54, 13);
            this.lblNotes.TabIndex = 14;
            this.lblNotes.Text = "Ghi chú:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(120, 222);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(200, 60);
            this.txtNotes.TabIndex = 15;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(120, 300);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(95, 23);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Đóng";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnBookTable
            // 
            this.btnBookTable.Location = new System.Drawing.Point(225, 300);
            this.btnBookTable.Name = "btnBookTable";
            this.btnBookTable.Size = new System.Drawing.Size(95, 23);
            this.btnBookTable.TabIndex = 17;
            this.btnBookTable.Text = "Đặt bàn";
            this.btnBookTable.UseVisualStyleBackColor = true;
            this.btnBookTable.Click += new System.EventHandler(this.btnBookTable_Click);
            // 
            // OrderTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBookTable);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.numGuestCount);
            this.Controls.Add(this.lblGuestCount);
            this.Controls.Add(this.dtpArrivalTime);
            this.Controls.Add(this.lblArrivalTime);
            this.Controls.Add(this.dtpBookingDate);
            this.Controls.Add(this.lblBookingDate);
            this.Controls.Add(this.cmbBranchName);
            this.Controls.Add(this.lblBranchName);
            this.Controls.Add(this.cmbRegionName);
            this.Controls.Add(this.lblRegionName);
            this.Controls.Add(this.txtCustomerPhone);
            this.Controls.Add(this.lblCustomerPhone);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Name = "OrderTableForm";
            this.Text = "Đặt bàn";
            ((System.ComponentModel.ISupportInitialize)(this.numGuestCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
