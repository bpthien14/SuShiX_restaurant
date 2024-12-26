using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using winform_app.Services;
using winform_app.Models;

namespace winform_app.Forms.Khách_hàng
{
    public partial class MainForm : Form
    {
        private Users currentUser = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateUIAfterLogin()
        {
            if (currentUser != null)
            {
                // Cập nhật giao diện để hiển thị thông tin người dùng
                // labelWelcome.Text = $"Welcome, {currentUser.Username}!";
                buttonLogin.Visible = false;
                buttonRegister.Visible = false;
                buttonLogout.Visible = true;
                panelUserInterface.Visible = true;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            // Show the form and check the result
            DialogResult result = loginForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentUser = loginForm.LoggedInUser;
                UpdateUIAfterLogin();
            }
            //else
            //{
            //    MessageBox.Show("Login was cancelled or failed");
            //}
        }

    }
}
