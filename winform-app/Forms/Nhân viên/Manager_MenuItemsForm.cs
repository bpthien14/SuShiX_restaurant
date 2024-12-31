using Microsoft.Data.SqlClient;
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
using winform_app.Models;
using winform_app.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace winform_app.Forms.Nhân_viên
{
    public partial class Manager_MenuItemsForm : Form
    {
        private Staff _staff;
        private DatabaseService _databaseService;
        List<Models.MenuItem> _items;
        List<Models.Category> _categories;
        public Manager_MenuItemsForm(Staff staff)
        {
            InitializeComponent();
            _staff = staff;
            _databaseService = new DatabaseService();
            _items = new List<Models.MenuItem>();
            _categories = new List<Category>();

            Models.Region region = _databaseService.GetRegionByBranchId(_staff.BranchID.ToString());
            if (region != null)
            {
                labelKhuVuc.Text = region.RegionName;
            }

            labelChiNhanh.Text = _databaseService.GetBranchNameById(_staff.BranchID);
            LoadMenuCategories();
            LoadMenu(_staff.BranchID);
        }


        private void LoadMenuCategories()
        {
            _categories = _databaseService.GetCategory();

            _categories.Insert(0, new Models.Category { CategoryID = null, CategoryName = "Tất cả Phân loại" });

            comboBoxCategory.DataSource = _categories;
            comboBoxCategory.DisplayMember = "CategoryName";
            comboBoxCategory.ValueMember = "CategoryID";
        }

        private void LoadMenu(string branchID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemID", typeof(string));
            dt.Columns.Add("CategoryID", typeof(string));
            dt.Columns.Add("Phân loại ", typeof(string));
            dt.Columns.Add("Tên món", typeof(string));
            dt.Columns.Add("Giá tiền", typeof(double));
            dt.Columns.Add("Có thể phục vụ", typeof(bool));

            _items = _databaseService.GetMenuItemsByBranch(branchID);

            foreach (Models.MenuItem item in _items)
            {
                if (comboBoxCategory.SelectedValue == null)
                {
                    foreach (Models.Category category in _categories)
                    {
                        if (item.CategoryID == category.CategoryID)
                        {
                            dt.Rows.Add(item.ItemID, item.CategoryID, category.CategoryName, item.ItemName, item.CurrentPrice, item.DeliveryAvailable);
                        }
                    }
                }
                else if (item.CategoryID != null && item.CategoryID == comboBoxCategory.SelectedValue.ToString())
                {
                    dt.Rows.Add(item.ItemID, item.CategoryID, comboBoxCategory.Text, item.ItemName, item.CurrentPrice, item.DeliveryAvailable);
                }
            }

            dataGridViewKetQua.DataSource = dt;
            dataGridViewKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewKetQua.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            foreach (DataGridViewColumn column in dataGridViewKetQua.Columns)
            {
                column.ReadOnly = true;
            }
            dataGridViewKetQua.Columns[3].ReadOnly = false;
            dataGridViewKetQua.Columns[4].ReadOnly = false;
            dataGridViewKetQua.Columns[5].ReadOnly = false;
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenu(_staff.BranchID);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            AddMenuItem();
        }

        private void buttonXemThongKe_Click(object sender, EventArgs e)
        {
            //dataGridViewKetQua.Rows.Add();
        }

        public void AddMenuItem()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO MENU_ITEM (ItemID, CategoryID, ItemName, CurrentPrice, DeliveryAvailable) VALUES (@ItemID, @CategoryID, @ItemName, @CurrentPrice, @DeliveryAvailable)", conn);
                    SqlCommand command_1 = new SqlCommand("INSERT INTO MENU_ITEM_AVAILABILITY (BranchID, ItemID, IsAvailable) VALUES (@BranchID, @ItemID, 1)", conn);

                    foreach (DataGridViewRow row in dataGridViewKetQua.Rows)
                    {
                        // Skip empty or unedited rows (this assumes the first column is not empty)
                        if (row.IsNewRow) continue;

                        string ItemID = row.Cells["ItemID"].Value.ToString();
                        string CategoryID = row.Cells["CategoryID"].Value.ToString();
                        string ItemName = row.Cells["Tên món"].Value.ToString();
                        double CurrentPrice = Convert.ToDouble(row.Cells["Giá tiền"].Value);
                        bool DeliveryAvailable = Convert.ToBoolean(row.Cells["Có thể phục vụ"].Value);

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ItemID", ItemID);
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        command.Parameters.AddWithValue("@ItemName", ItemName);
                        command.Parameters.AddWithValue("@CurrentPrice", CurrentPrice);
                        command.Parameters.AddWithValue("@DeliveryAvailable", DeliveryAvailable);

                        command_1.Parameters.Clear();
                        command_1.Parameters.AddWithValue("@BranchID", _staff.BranchID);
                        command_1.Parameters.AddWithValue("@ItemID", ItemID);

                        // Execute the insert command
                        command.ExecuteNonQuery();
                        command_1.ExecuteNonQuery();
                    }

                    MessageBox.Show("Lưu món ăn thành công!");
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Co bien!: {ex.Message}");
            }
        }
    }
}
