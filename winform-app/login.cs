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

namespace winform_app
{
    public partial class LoginForm : Form
    {
        private DatabaseService _databaseService;
        public Users LoggedInUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
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
                LoggedInUser = user;
                if (user.Role == "customer")
                {
                    MessageBox.Show("Xin Chào khách hàng " + user.Username);
                    KH_MainForm khMainForm = new KH_MainForm(user);
                    khMainForm.FormClosed += (s, args) => this.Close();
                    khMainForm.Show();
                    this.Hide();
                }
                else if (user.Role == "admin")
                {
                    MessageBox.Show("Xin Chào admin" + user.Username);
                    this.Close();
                }
                else if (user.Role == "staff")
                {
                    MessageBox.Show("Xin Chào nhân viên" + user.Username);
                    this.Close();
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
