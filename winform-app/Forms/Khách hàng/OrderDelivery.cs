using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using winform_app.Models;
using winform_app.Services;

namespace winform_app.Forms.Khách_hàng
{
    public partial class OrderDelivery : Form
    {
        private Users _user;
        private DatabaseService _databaseService;
        private List<MenuItem> _menuItems;
        private List<OrderItem> _orderItems;
        private string _customerID; // Thêm biến này để lưu CustomerID
        private Form _mainForm;

        public OrderDelivery(Users user, Form mainForm)
        {
            InitializeComponent();
            _user = user;
            _mainForm = mainForm;
            _databaseService = new DatabaseService();
            _menuItems = new List<MenuItem>();
            _orderItems = new List<OrderItem>();
            LoadRegionNames();
            FillCustomerDetails();
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

        private void cmbBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBranchName.SelectedValue is string branchID)
            {
                LoadMenuCategories(branchID);
            }
        }

        private void LoadMenuCategories(string branchID)
        {
            List<Category> categories = _databaseService.GetCategoriesByBranch(branchID);
            cmbMenuCategory.DataSource = categories;
            cmbMenuCategory.DisplayMember = "CategoryName";
            cmbMenuCategory.ValueMember = "CategoryID";
        }

        private void btnSearchMenu_Click(object sender, EventArgs e)
        {
            string branchID = cmbBranchName.SelectedValue.ToString();
            string categoryID = cmbMenuCategory.SelectedValue.ToString();
            LoadMenuItems(branchID, categoryID);
        }

        private void LoadMenuItems(string branchID, string categoryID)
        {
            _menuItems = _databaseService.GetMenuItemsByBranch(branchID).Where(item => item.CategoryID == categoryID).ToList();
            dgvMenu.DataSource = _menuItems;
        }

        private void dgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvMenu.Columns["colAddToCart"].Index && e.RowIndex >= 0)
            {
                MenuItem menuItem = _menuItems[e.RowIndex];
                AddToOrder(menuItem);
            }
        }

        private void AddToOrder(MenuItem menuItem)
        {
            OrderItem orderItem = _orderItems.FirstOrDefault(item => item.ItemID == menuItem.ItemID);
            if (orderItem == null)
            {
                orderItem = new OrderItem
                {
                    ItemID = menuItem.ItemID,
                    ItemName = menuItem.ItemName,
                    Quantity = 1,
                    Price = menuItem.CurrentPrice
                };
                _orderItems.Add(orderItem);
            }
            else
            {
                orderItem.Quantity++;
            }
            UpdateOrderGrid();
            UpdateOrderSummary();
        }

        private void dgvSelectedItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSelectedItems.Columns["colQuantity"].Index && e.RowIndex >= 0)
            {
                DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)dgvSelectedItems.Rows[e.RowIndex].Cells[e.ColumnIndex];
                int newQuantity;
                if (int.TryParse(cell.Value.ToString(), out newQuantity) && newQuantity > 0)
                {
                    _orderItems[e.RowIndex].Quantity = newQuantity;
                    UpdateOrderGrid();
                    UpdateOrderSummary();
                }
                else
                {
                    MessageBox.Show("Invalid quantity. Please enter a positive integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateOrderGrid()
        {
            dgvSelectedItems.DataSource = null;
            dgvSelectedItems.DataSource = _orderItems;
        }

        private void UpdateOrderSummary()
        {
            double totalAmount = _orderItems.Sum(item => item.Quantity * item.Price);
            double deliveryFee = rbDelivery.Checked ? 50000 : 0; // Placeholder delivery fee
            double discount = 0; // Placeholder discount
            double finalAmount = totalAmount + deliveryFee - discount;

            lblTotalAmount.Text = $"Total Amount: {totalAmount:C}";
            lblDeliveryFee.Text = $"Delivery Fee: {deliveryFee:C}";
            lblDiscount.Text = $"Discount: {discount:C}";
            lblFinalAmount.Text = $"Final Amount: {finalAmount:C}";
        }

        private void rbPickup_CheckedChanged(object sender, EventArgs e)
        {
            gbDeliveryInfo.Enabled = !rbPickup.Checked;
            UpdateOrderSummary();
        }

        private void rbDelivery_CheckedChanged(object sender, EventArgs e)
        {
            gbDeliveryInfo.Enabled = rbDelivery.Checked;
            UpdateOrderSummary();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // Gather booking details
            OnlineBooking booking = new OnlineBooking
            {
                CustomerID = _customerID,
                BranchID = cmbBranchName.SelectedValue.ToString(),
                GuestCount = 1, // Placeholder value
                BookingDate = DateTime.Now, // Chỉ lấy ngày tháng năm
                GuestName = txtCustomerName.Text,
                GuestPhone = txtCustomerPhone.Text,
                DeliveryType = rbDelivery.Checked ? "Delivery" : "Pickup",
                DeliveryAddress = rbDelivery.Checked ? txtAddress.Text : string.Empty,
                DeliveryFee = rbDelivery.Checked ? 50000 : 0, // Placeholder delivery fee
                Status = "PENDING"
            };

            // Create an OrderTable object
            string nextOrderID = _databaseService.GetNextOrderID();
            OrderTable order = new OrderTable
            {
                OrderID = nextOrderID,
                OrderDate = DateTime.Now,
                StaffID = "ST06357", // Assuming no staff ID for online orders
                TableNumber = 0, // Assuming no table number for delivery orders
                BranchID = cmbBranchName.SelectedValue.ToString(),
                CustomerID = _customerID,
                Notes = string.Empty,
                GuestName = txtCustomerName.Text,
                GuestPhone = txtCustomerPhone.Text,
                OrderStatus = "PENDING"
            };

            // Open the Checkout form and pass the order items and booking details
            Checkout checkoutForm = new Checkout(order, _orderItems, booking);
            checkoutForm.ShowDialog();
        }

        private void FillCustomerDetails()
        {
            Customer customer = _databaseService.GetCustomerByUserID(_user.UserID);
            if (customer != null)
            {
                txtCustomerName.Text = customer.FullName;
                txtCustomerPhone.Text = customer.PhoneNumber;
                _customerID = customer.CustomerID; // Lưu CustomerID để sử dụng sau
            }
            else
            {
                MessageBox.Show("Unable to retrieve customer details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
