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

namespace winform_app.Forms.Khách_hàng
{
    public partial class OrderDelivery : Form
    {
        private Users _user;
        private DatabaseService _databaseService;
        private List<MenuItem> _menuItems;
        private List<OrderItem> _orderItems;

        public OrderDelivery(Users user)
        {
            InitializeComponent();
            _user = user;
            _databaseService = new DatabaseService();
            _menuItems = new List<MenuItem>();
            _orderItems = new List<OrderItem>();
            LoadRegionNames();
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
            // Load menu categories based on the selected branch
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
            // Load menu items based on the selected branch and category
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
            // Handle quantity changes in the selected items grid
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
            this.Close();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // Handle checkout process
            MessageBox.Show("Checkout process initiated.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
