using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using winform_app.Models;
using winform_app.Services;

namespace winform_app.Forms.Khách_hàng
{
    public partial class OrderTableForm : Form
    {
        private Users _user;
        private DatabaseService _databaseService;

        public OrderTableForm(Users user)
        {
            InitializeComponent();
            _user = user;
            _databaseService = new DatabaseService();
            LoadRegionNames();
            LoadCustomerDetails();
        }

        private void LoadRegionNames()
        {
            List<Models.Region> regions = _databaseService.GetRegions();
            cmbRegionName.DataSource = regions;
            cmbRegionName.DisplayMember = "RegionName";
            cmbRegionName.ValueMember = "RegionID";
        }

        private void cmbRegionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRegionName.SelectedValue is int regionID)
            {
                LoadBranchNames(regionID);
            }
        }

        private void LoadBranchNames(int regionID)
        {
            List<Branch> branches = _databaseService.GetBranchesByRegion(regionID);
            cmbBranchName.DataSource = branches;
            cmbBranchName.DisplayMember = "BranchName";
            cmbBranchName.ValueMember = "BranchID";
        }

        private void LoadCustomerDetails()
        {
            // Assuming you have a method to get the customer details by user ID
            Customer customer = _databaseService.GetCustomerByUserID(_user.UserID);
            if (customer != null)
            {
                txtCustomerName.Text = customer.FullName;
                txtCustomerPhone.Text = customer.PhoneNumber;
            }
        }

        private void btnBookTable_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string customerPhone = txtCustomerPhone.Text;
            string customerID = _databaseService.GetCustomerIDByInfo(customerName);

            if (string.IsNullOrEmpty(customerID))
            {
                MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OrderTable orderTable = new OrderTable
            {
                CustomerID = customerID,
                BranchID = cmbBranchName.SelectedValue.ToString(),
                TableNumber = (int)numGuestCount.Value,
                OrderDate = dtpBookingDate.Value.Date + dtpArrivalTime.Value.TimeOfDay,
                Notes = txtNotes.Text,
                GuestName = txtCustomerName.Text,
                GuestPhone = txtCustomerPhone.Text,
                OrderStatus = "PENDING"
            };

            if (_databaseService.BookTable(orderTable, out int bookingID))
            {
                MessageBox.Show($"Booking successful! Your booking ID is {bookingID}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                KH_MainForm mainForm = new KH_MainForm(_user);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("An error occurred while booking the table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                KH_MainForm mainForm = new KH_MainForm(_user);
                mainForm.Show();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            KH_MainForm mainForm = new KH_MainForm(_user);
            mainForm.Show();

        }
    }
}
