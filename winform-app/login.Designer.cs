using System.Drawing;
using System.Windows.Forms;

namespace winform_app
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.LinkLabel linkForgotPassword;
        private System.Windows.Forms.LinkLabel linkRegister;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            labelTitle = new Label();
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            linkForgotPassword = new LinkLabel();
            linkRegister = new LinkLabel();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.IndianRed;
            labelTitle.Location = new Point(352, 60);
            labelTitle.Margin = new Padding(5, 0, 5, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(320, 65);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "ĐĂNG NHẬP";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUsername.Location = new Point(308, 180);
            labelUsername.Margin = new Padding(5, 0, 5, 0);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(213, 30);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Tên đăng nhập/SĐT:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(308, 220);
            textBoxUsername.Margin = new Padding(5, 6, 5, 6);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(409, 35);
            textBoxUsername.TabIndex = 2;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPassword.Location = new Point(308, 300);
            labelPassword.Margin = new Padding(5, 0, 5, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(113, 30);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Mật khẩu:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(308, 340);
            textBoxPassword.Margin = new Padding(5, 6, 5, 6);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(409, 35);
            textBoxPassword.TabIndex = 4;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.IndianRed;
            buttonLogin.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatAppearance.MouseOverBackColor = Color.Brown;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(308, 420);
            buttonLogin.Margin = new Padding(5, 6, 5, 6);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(411, 60);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "Đăng nhập";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // linkForgotPassword
            // 
            linkForgotPassword.AutoSize = true;
            linkForgotPassword.LinkColor = Color.IndianRed;
            linkForgotPassword.Location = new Point(308, 520);
            linkForgotPassword.Margin = new Padding(5, 0, 5, 0);
            linkForgotPassword.Name = "linkForgotPassword";
            linkForgotPassword.Size = new Size(166, 30);
            linkForgotPassword.TabIndex = 6;
            linkForgotPassword.TabStop = true;
            linkForgotPassword.Text = "Quên mật khẩu?";
            linkForgotPassword.LinkClicked += linkForgotPassword_LinkClicked;
            // 
            // linkRegister
            // 
            linkRegister.AutoSize = true;
            linkRegister.LinkColor = Color.IndianRed;
            linkRegister.Location = new Point(308, 580);
            linkRegister.Margin = new Padding(5, 0, 5, 0);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(323, 30);
            linkRegister.TabIndex = 7;
            linkRegister.TabStop = true;
            linkRegister.Text = "Chưa có tài khoản? Đăng ký ngay";
            linkRegister.LinkClicked += linkRegister_LinkClicked;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(55, 24);
            pictureBox3.Margin = new Padding(5, 6, 5, 6);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(103, 110);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Viner Hand ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Maroon;
            label1.Location = new Point(70, 140);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(73, 468);
            label1.TabIndex = 11;
            label1.Text = "S\r\nU\r\nS\r\nH\r\nI\r\nX\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(854, 24);
            pictureBox1.Margin = new Padding(5, 6, 5, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(969, 676);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Controls.Add(label1);
            Controls.Add(linkRegister);
            Controls.Add(linkForgotPassword);
            Controls.Add(buttonLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(labelPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(labelUsername);
            Controls.Add(labelTitle);
            Margin = new Padding(5, 6, 5, 6);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private PictureBox pictureBox3;
        private Label label1;
        private PictureBox pictureBox1;
    }
}
