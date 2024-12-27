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
using System.Drawing.Drawing2D;

namespace winform_app.Forms.Khách_hàng
{
    public partial class KH_MainForm : Form
    {
        private Users currentUser = null;
        private int targetHeight = 0;

        public KH_MainForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(MainForm_Load_KH);
        }
        private void MainForm_Load_KH(object? sender, EventArgs e)
        {
            ApplyRoundedCorners(buttonViewMenu, 10);
            ApplyRoundedCorners(buttonLogin, 10);
            ApplyRoundedCorners(buttonRegister, 10);
            ApplyRoundedCorners(buttonViewMenu, 10);
            ApplyRoundedCorners(buttonOrderTakeout, 10);
            ApplyRoundedCorners(buttonReserveTable, 10);
            ApplyRoundedCorners(buttonOrderHistory, 10);
            ApplyRoundedCorners(buttonPersonalInfo, 10); 
            ApplyRoundedCorners(buttonFindBranch, 10);
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
            else
            {
                MessageBox.Show("Login was cancelled or failed");
            }
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                targetHeight = panel1.Height;
                panel1.Height = 0;
                panel1.Visible = true;
                await RevealPanelAsync();
            }
            else
            {
                await HidePanelAsync();
                panel1.Visible = false;
                panel1.Height = targetHeight;
            }
        }
        private async Task RevealPanelAsync()
        {
            while (panel1.Height < targetHeight)
            {
                panel1.Height += 5;
                await Task.Delay(1);
                if (panel1.Height >= targetHeight)
                {
                    panel1.Height = targetHeight;
                }
            }
        }
        private async Task HidePanelAsync()
        {
            while (panel1.Height > 0)
            {
                panel1.Height -= 5;
                await Task.Delay(1);
                if (panel1.Height <= 0)
                {
                    panel1.Height = 0;
                }
            }
        }
    }
}
