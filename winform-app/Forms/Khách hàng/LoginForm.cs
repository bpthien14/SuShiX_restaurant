using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform_app.Services;
using winform_app.Models;

namespace winform_app.Forms.Khách_hàng
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string loginInput = txtUsername.Text;
            string password = txtPassword.Text;

            if (_databaseService.CheckLogin(loginInput, password, out Users user))
            {
                LoggedInUser = user;
                if (user.Role == "customer")
                {
                    MessageBox.Show("Xin Chào khách hàng " + user.Username);
                    KH_MainForm kh_MainForm = new KH_MainForm(user);
                    kh_MainForm.Show();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (user.Role == "admin")
                {
                    MessageBox.Show("Xin Chào admin" + user.Username);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (user.Role == "staff")
                {
                    MessageBox.Show("Xin Chào nhân viên" + user.Username);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Invalid login input or password.");
            }
        }
    }
}
