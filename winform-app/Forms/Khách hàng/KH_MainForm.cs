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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;


namespace winform_app.Forms.Khách_hàng
{
    public partial class KH_MainForm : Form
    {
        private Users currentUser;
        private DatabaseService _databaseService;
        private int targetHeight = 0;
        public KH_MainForm(Users user)
        {
            InitializeComponent();
            this.Load += new EventHandler(MainForm_Load_KH);
            _databaseService = new DatabaseService();
            currentUser = user;
        }
        private void MainForm_Load_KH(object? sender, EventArgs e)
        {
            // ApplyRoundedCorners(buttonViewMenu, 10);
            ApplyRoundedCorners(buttonOrderTakeout, 10);
            ApplyRoundedCorners(buttonReserveTable, 10);
            //ApplyRoundedCorners(buttonOrderHistory, 10);
            //ApplyRoundedCorners(buttonPersonalInfo, 10);
            ApplyRoundedCorners(buttonFindBranch, 10);
            ApplyRoundedCorners(buttonLogout, 10);

            LoadCustomerDashboard();
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
        private void LoadCustomerDashboard()
        {
            var dashboard = _databaseService.GetCustomerDashboard(currentUser.UserID);
            labelGreeting.Text = $"Xin chào, {currentUser.Username}";

            if (dashboard.CardType.ToUpper() == "GOLD")
            {
                labelMembership.BackColor = Color.Gold;
            }
            else if (dashboard.CardType.ToUpper() == "SILVER")
            {
                labelMembership.BackColor = Color.Silver;
            }
            else if (dashboard.CardType.ToUpper() == "MEMBERSHIP")
            {
                labelMembership.BackColor = Color.Brown;
            }
            labelMembership.Text = dashboard.CardType;

            labelPoints.Text = $"Điểm tích lũy: {dashboard.AccumulatedPoints} điểm";
            labelPendingReservations.Text = $"Đơn đặt bàn đang chờ: {dashboard.PendingBookings}";
            labelOngoingDeliveries.Text = $"Đơn hàng đang giao: {dashboard.ProcessingOrders}";
        }

        private void buttonReserveTable_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderTableForm orderTableForm = new OrderTableForm(currentUser);
            orderTableForm.FormClosed += (s, args) =>
            {
                this.Show();
                LoadCustomerDashboard();
            };
            orderTableForm.Show();
        }

        private void buttonFindBranch_Click(object sender, EventArgs e)
        {
            this.Hide();
            FindBranchForm findBranchForm = new FindBranchForm(currentUser);
            findBranchForm.FormClosed += (s, args) =>
            {
                this.Show();
                LoadCustomerDashboard();
            };
            findBranchForm.Show();
        }

        private void buttonOrderTakeout_Click(object sender, EventArgs e)
        {
            OrderDelivery orderDelivery = new OrderDelivery(currentUser, this);
            orderDelivery.FormClosed += (s, args) =>
            {
                this.Show();
                LoadCustomerDashboard();
            };
            orderDelivery.Show();
        }

        private void UpdatePersonalInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdatePersonalInfo updatePersonalInfoForm = new UpdatePersonalInfo(currentUser);
            updatePersonalInfoForm.FormClosed += (s, args) =>
            {
                this.Show();
                LoadCustomerDashboard();
            };
            updatePersonalInfoForm.Show();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
