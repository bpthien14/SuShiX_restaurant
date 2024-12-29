using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform_app.Models;
using winform_app.Services;
using winform_app.Forms.Khách_hàng;
using winform_app.Forms.Nhân_viên;
using System.Drawing.Drawing2D;

namespace winform_app
{
    public partial class LoginForm : Form
    {
        private DatabaseService _databaseService;

        public LoginForm()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            ApplyRoundedCorners(buttonLogin, 10);
        }
        private void ApplyRoundedCorners(Button button, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(0, 0, cornerRadius, cornerRadius), 180, 90);
            path.AddArc(new Rectangle(button.Width - cornerRadius - 1, 0, cornerRadius, cornerRadius), -90, 90);
            path.AddArc(new Rectangle(button.Width - cornerRadius - 1, button.Height - cornerRadius - 1, cornerRadius, cornerRadius), 0, 90);
            path.AddArc(new Rectangle(0, button.Height - cornerRadius - 1, cornerRadius, cornerRadius), 90, 90);
            path.CloseAllFigures();
            button.Region = new System.Drawing.Region(path);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string loginInput = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (_databaseService.CheckLogin(loginInput, password, out Users user))
            {
                if (user.Role.ToUpper() == "CUSTOMER")
                {
                    MessageBox.Show("Xin Chào khách hàng " + user.Username);
                    KH_MainForm khMainForm = new KH_MainForm(user);
                    khMainForm.FormClosed += (s, args) => this.Close();
                    khMainForm.Show();
                    this.Hide();
                }
            }
            else if (_databaseService.CheckLoginStaff(loginInput, password, out Staff staff, out string? level))
            {
                if (level != null)
                {
                    if (level.ToUpper() == "MANAGER")
                    {
                        MessageBox.Show("Xin Chào Quản lý Chi Nhánh " + _databaseService.GetBranchNameById(staff.BranchID) + " Mr. " + staff.FullName);
                        Manager_MainForm nvMainForm = new Manager_MainForm(staff);
                        nvMainForm.FormClosed += (s, args) => this.Close();
                        nvMainForm.Show();
                        this.Hide();
                    }
                    else if (level.ToUpper() == "ADMIN")
                    {
                        MessageBox.Show("Xin Chào Quản lý Công ty " + "Mr." + staff.FullName);
                        Admin_MainForm nvMainForm = new Admin_MainForm();
                        nvMainForm.FormClosed += (s, args) => this.Close();
                        nvMainForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không phải quản lý Chi Nhánh hay Công ty");
                }
            }
            else
            {
                MessageBox.Show("Invalid login input or password.");
            }
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
