namespace winform_app.Forms.Khách_hàng
{
    partial class LoginForm
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
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnForgotPassword = new Button();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.Location = new Point(50, 50);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(150, 30);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên đăng nhập/SĐT/Email:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(200, 50);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 27);
            txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(50, 100);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(150, 30);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(200, 100);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 27);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(200, 150);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 30);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Đăng nhập";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnForgotPassword
            // 
            btnForgotPassword.Location = new Point(200, 200);
            btnForgotPassword.Name = "btnForgotPassword";
            btnForgotPassword.Size = new Size(150, 30);
            btnForgotPassword.TabIndex = 5;
            btnForgotPassword.Text = "Quên mật khẩu?";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(200, 250);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(234, 30);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Chưa có tài khoản? Đăng ký ngay";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 390);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(btnForgotPassword);
            Controls.Add(btnRegister);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnForgotPassword;
        private Button btnRegister;
    }
}