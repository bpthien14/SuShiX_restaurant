namespace winform_app.Forms.Khách_hàng
{
    partial class UpdatePersonalInfo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblIDNumber;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtIDNumber;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            lblFullName = new Label();
            lblPhoneNumber = new Label();
            lblEmail = new Label();
            lblIDNumber = new Label();
            lblGender = new Label();
            txtFullName = new TextBox();
            txtPhoneNumber = new TextBox();
            txtEmail = new TextBox();
            txtIDNumber = new TextBox();
            txtGender = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.BackColor = Color.White;
            lblFullName.Location = new Point(12, 15);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(81, 30);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Họ tên:";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(12, 60);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(55, 30);
            lblPhoneNumber.TabIndex = 2;
            lblPhoneNumber.Text = "SĐT:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 101);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(68, 30);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // lblIDNumber
            // 
            lblIDNumber.AutoSize = true;
            lblIDNumber.Location = new Point(12, 142);
            lblIDNumber.Name = "lblIDNumber";
            lblIDNumber.Size = new Size(68, 30);
            lblIDNumber.TabIndex = 6;
            lblIDNumber.Text = "Số ID:";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(12, 183);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(97, 30);
            lblGender.TabIndex = 8;
            lblGender.Text = "Giới tính:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(189, 19);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(212, 35);
            txtFullName.TabIndex = 1;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(189, 60);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(212, 35);
            txtPhoneNumber.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(189, 101);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(212, 35);
            txtEmail.TabIndex = 5;
            // 
            // txtIDNumber
            // 
            txtIDNumber.Location = new Point(189, 142);
            txtIDNumber.Name = "txtIDNumber";
            txtIDNumber.Size = new Size(212, 35);
            txtIDNumber.TabIndex = 7;
            // 
            // txtGender
            // 
            txtGender.Location = new Point(189, 183);
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(212, 35);
            txtGender.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RosyBrown;
            btnSave.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(185, 237);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(105, 49);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.RosyBrown;
            btnCancel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(296, 237);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 49);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // UpdatePersonalInfo
            // 
            BackColor = Color.White;
            ClientSize = new Size(437, 319);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtGender);
            Controls.Add(lblGender);
            Controls.Add(txtIDNumber);
            Controls.Add(lblIDNumber);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtPhoneNumber);
            Controls.Add(lblPhoneNumber);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Name = "UpdatePersonalInfo";
            Text = "Cập nhật thông tin";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
