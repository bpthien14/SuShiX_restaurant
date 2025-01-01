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
            lblFullName.Location = new Point(12, 15);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(79, 20);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Full Name:";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(12, 45);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(111, 20);
            lblPhoneNumber.TabIndex = 2;
            lblPhoneNumber.Text = "Phone Number:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 75);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // lblIDNumber
            // 
            lblIDNumber.AutoSize = true;
            lblIDNumber.Location = new Point(12, 105);
            lblIDNumber.Name = "lblIDNumber";
            lblIDNumber.Size = new Size(85, 20);
            lblIDNumber.TabIndex = 6;
            lblIDNumber.Text = "ID Number:";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(12, 135);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(60, 20);
            lblGender.TabIndex = 8;
            lblGender.Text = "Gender:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(155, 12);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(200, 27);
            txtFullName.TabIndex = 1;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(155, 42);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(200, 27);
            txtPhoneNumber.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(155, 72);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 27);
            txtEmail.TabIndex = 5;
            // 
            // txtIDNumber
            // 
            txtIDNumber.Location = new Point(155, 102);
            txtIDNumber.Name = "txtIDNumber";
            txtIDNumber.Size = new Size(200, 27);
            txtIDNumber.TabIndex = 7;
            // 
            // txtGender
            // 
            txtGender.Location = new Point(155, 132);
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(200, 27);
            txtGender.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(145, 170);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 33);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(280, 170);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 33);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // UpdatePersonalInfo
            // 
            ClientSize = new Size(391, 238);
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
            Text = "Update Personal Information";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
