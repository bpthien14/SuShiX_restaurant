using System;
using System.Windows.Forms;
using winform_app.Models;
using winform_app.Services;

namespace winform_app.Forms.Khách_hàng
{
    public partial class UpdatePersonalInfo : Form
    {
        private Users _user;
        private DatabaseService _databaseService;
        private Customer _customer;

        public UpdatePersonalInfo(Users user)
        {
            InitializeComponent();
            _user = user;
            _databaseService = new DatabaseService();
            LoadCustomerDetails();
        }

        private void LoadCustomerDetails()
        {
            _customer = _databaseService.GetCustomerByUserID(_user.UserID);
            if (_customer != null)
            {
                txtFullName.Text = _customer.FullName;
                txtPhoneNumber.Text = _customer.PhoneNumber;
                txtEmail.Text = _customer.Email;
                txtIDNumber.Text = _customer.IDNumber;
                txtGender.Text = _customer.Gender;
            }
            else
            {
                MessageBox.Show("Unable to retrieve customer details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _customer.FullName = txtFullName.Text;
            _customer.PhoneNumber = txtPhoneNumber.Text;
            _customer.Email = txtEmail.Text;
            _customer.IDNumber = txtIDNumber.Text;
            _customer.Gender = txtGender.Text;

            bool success = _databaseService.UpdateCustomerInfo(_customer);
            if (success)
            {
                MessageBox.Show("Customer information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                KH_MainForm mainForm = new KH_MainForm(_user);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Failed to update customer information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
