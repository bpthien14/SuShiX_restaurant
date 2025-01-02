using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using winform_app.Models;
using winform_app.Services;

namespace winform_app.Forms.Khách_hàng
{
    public partial class Checkout : Form
    {
        private DatabaseService _databaseService;
        private List<OrderItem> _orderItems;
        private OnlineBooking _booking;

        public Checkout(List<OrderItem> orderItems, OnlineBooking booking)
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            _orderItems = orderItems;
            _booking = booking;
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            // Display order details in the DataGridView
            dgvOrderSummary.DataSource = _orderItems.Select(item => new
            {
                ItemName = item.ItemName,
                Quantity = item.Quantity,
                TotalAmount = item.Quantity * item.Price
            }).ToList();

            // Display customer details
            txtCustomerName.Text = _booking.GuestName;
            txtCustomerPhone.Text = _booking.GuestPhone;

            // Conditionally enable the delivery address field
            if (_booking.DeliveryType == "Delivery")
            {
                txtDeliveryAddress.Text = _booking.DeliveryAddress;
                txtDeliveryAddress.ReadOnly = false;
            }
            else
            {
                txtDeliveryAddress.Text = string.Empty;
                txtDeliveryAddress.ReadOnly = true;
            }

            // Disable editing of customer details
            txtCustomerName.ReadOnly = true;
            txtCustomerPhone.ReadOnly = true;

            // Calculate and display invoice details
            double totalAmount = _orderItems.Sum(item => item.Quantity * item.Price);
            txtTotalAmount.Text = totalAmount.ToString("C");
            txtDiscount.Text = "0"; // Default discount
            UpdateFinalAmount();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            UpdateFinalAmount();
        }

        private void UpdateFinalAmount()
        {
            if (double.TryParse(txtDiscount.Text, out double discount))
            {
                double totalAmount = _orderItems.Sum(item => item.Quantity * item.Price);
                double finalAmount = totalAmount - discount;
                txtFinalAmount.Text = finalAmount.ToString("C");
            }
            else
            {
                txtFinalAmount.Text = txtTotalAmount.Text;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Save the order, booking, and invoice to the database
            if (double.TryParse(txtDiscount.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out double discount) &&
                double.TryParse(txtFinalAmount.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out double finalAmount))
            {
                string paymentMethod = cmbPaymentMethod.SelectedItem.ToString();
                string cardID = txtCardID.Text == null ? txtCardID.Text : null;

                bool success = _databaseService.SaveOrderAndBooking(_orderItems, _booking, discount, finalAmount, paymentMethod, cardID);
                if (success)
                {
                    MessageBox.Show("Order confirmed and saved to the database!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    // Close the OrderDelivery form if it is open
                    Form orderDeliveryForm = Application.OpenForms["OrderDelivery"];
                    if (orderDeliveryForm != null)
                    {
                        orderDeliveryForm.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Failed to save the order. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid input format. Please enter valid numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOrderSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
