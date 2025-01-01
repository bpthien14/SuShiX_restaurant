using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
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
        private readonly ExcelExportService _excelExportService;
        List<Models.MenuItem> _items;
        List<Models.Category> _categories;

        public Manager_MenuItemsForm(Staff staff)
        {
            InitializeComponent();
            _staff = staff;
            _databaseService = new DatabaseService();
            _excelExportService = new ExcelExportService();
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
            dataGridViewKetQua.AllowUserToAddRows = true;
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
            dt.Columns.Add("Phân loại", typeof(string));
            dt.Columns.Add("Tên món", typeof(string));
            dt.Columns.Add("Giá tiền", typeof(double));
            dt.Columns.Add("Có thể giao hàng", typeof(bool));
            dt.Columns.Add("RowState", typeof(string));

            _items = _databaseService.GetMenuItemsByBranch(branchID);

            foreach (Models.MenuItem item in _items)
            {
                if (comboBoxCategory.SelectedValue == null)
                {
                    foreach (Models.Category category in _categories)
                    {
                        if (item.CategoryID == category.CategoryID)
                        {
                            dt.Rows.Add(item.ItemID, item.CategoryID, category.CategoryName, item.ItemName, item.CurrentPrice, item.DeliveryAvailable, "Unchanged");
                        }
                    }
                }
                else if (item.CategoryID != null && item.CategoryID == comboBoxCategory.SelectedValue.ToString())
                {
                    dt.Rows.Add(item.ItemID, item.CategoryID, comboBoxCategory.Text, item.ItemName, item.CurrentPrice, item.DeliveryAvailable, "Unchanged");
                }
            }

            dataGridViewKetQua.DataSource = dt;
            dataGridViewKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewKetQua.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            foreach (DataGridViewColumn column in dataGridViewKetQua.Columns)
            {
                column.ReadOnly = true;
            }
            dataGridViewKetQua.Columns[2].ReadOnly = false;
            dataGridViewKetQua.Columns[3].ReadOnly = false;
            dataGridViewKetQua.Columns[4].ReadOnly = false;
            dataGridViewKetQua.Columns[5].ReadOnly = false;
            dataGridViewKetQua.Columns["RowState"].Visible = false;
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenu(_staff.BranchID);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            AddMenuItem();
        }

        public void AddMenuItem()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    bool kt = false;
                    conn.Open();
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO MENU_ITEM (ItemID, CategoryID, ItemName, CurrentPrice, DeliveryAvailable) VALUES (@ItemID, @CategoryID, @ItemName, @CurrentPrice, @DeliveryAvailable)", conn);
                    SqlCommand insertAvailabilityCommand = new SqlCommand("INSERT INTO MENU_ITEM_AVAILABILITY (BranchID, ItemID, IsAvailable) VALUES (@BranchID, @ItemID, 1)", conn);
                    SqlCommand updateCommand = new SqlCommand("UPDATE MENU_ITEM SET CategoryID = @CategoryID, ItemName = @ItemName, CurrentPrice = @CurrentPrice, DeliveryAvailable = @DeliveryAvailable WHERE ItemID = @ItemID", conn);

                    foreach (DataGridViewRow row in dataGridViewKetQua.Rows)
                    {
                        // Skip empty or unedited rows (this assumes the first column is not empty)
                        if (row.IsNewRow) continue;

                        string itemID;
                        string categoryID;
                        string itemName;
                        double currentPrice;
                        bool deliveryAvailable;

                        if (string.IsNullOrEmpty(row.Cells["Tên món"].Value?.ToString()))
                        {
                            MessageBox.Show("Vui lòng nhập tên cho món ăn!");
                            continue;
                        }
                        else
                        {
                            itemName = row.Cells["Tên món"].Value.ToString();
                        }

                        if (string.IsNullOrEmpty(row.Cells["Giá tiền"].Value?.ToString()))
                        {
                            MessageBox.Show("Vui lòng nhập giá tiền cho món ăn!");
                            continue;
                        }
                        else
                        {
                            if (!double.TryParse(row.Cells["Giá tiền"].Value.ToString(), out currentPrice))
                            {
                                MessageBox.Show("Giá tiền không hợp lệ!");
                                continue;
                            }
                        }

                        if (string.IsNullOrEmpty(row.Cells["Có thể giao hàng"].Value?.ToString()))
                        {
                            deliveryAvailable = false;
                        }
                        else
                        {
                            if (!bool.TryParse(row.Cells["Có thể giao hàng"].Value.ToString(), out deliveryAvailable))
                            {
                                MessageBox.Show("Giá trị 'Có thể giao hàng' không hợp lệ!");
                                continue;
                            }
                        }

                        string? rowState = row.Cells["RowState"].Value.ToString();

                        if (rowState == "")
                        {
                            insertCommand.Parameters.Clear();

                            string latestItemID = _databaseService.GetLatestMenuItemID();
                            itemID = GenerateNewItemID(latestItemID);

                            bool ktCategory = false;
                            foreach (Models.Category _category in _categories)
                            {
                                if (row.Cells["Phân loại"].Value.ToString() == _category.CategoryName)
                                {
                                    categoryID = _category.CategoryID;
                                    insertCommand.Parameters.AddWithValue("@CategoryID", categoryID);
                                    ktCategory = true;
                                    break;
                                }
                            }
                            if (!ktCategory)
                            {
                                MessageBox.Show("Vui lòng nhập đúng phân loại có sẵn trong hệ thống!");
                                continue;
                            }

                            insertCommand.Parameters.AddWithValue("@ItemID", itemID);
                            insertCommand.Parameters.AddWithValue("@ItemName", itemName);
                            insertCommand.Parameters.AddWithValue("@CurrentPrice", currentPrice);
                            insertCommand.Parameters.AddWithValue("@DeliveryAvailable", deliveryAvailable);

                            insertAvailabilityCommand.Parameters.Clear();
                            insertAvailabilityCommand.Parameters.AddWithValue("@BranchID", _staff.BranchID);
                            insertAvailabilityCommand.Parameters.AddWithValue("@ItemID", itemID);

                            // Execute the insert command
                            insertCommand.ExecuteNonQuery();
                            insertAvailabilityCommand.ExecuteNonQuery();
                            row.Cells["RowState"].Value = "Unchanged";
                            kt = true;
                        }
                        else if (rowState == "Updated")
                        {
                            updateCommand.Parameters.Clear();

                            bool ktCategory = false;
                            itemID = row.Cells["ItemID"].Value.ToString();

                            foreach (Models.Category _category in _categories)
                            {
                                if (row.Cells["Phân loại"].Value.ToString() == _category.CategoryName)
                                {
                                    ktCategory = true;
                                    categoryID = _category.CategoryID;

                                    updateCommand.Parameters.AddWithValue("@CategoryID", categoryID);
                                    updateCommand.Parameters.AddWithValue("@ItemID", itemID);
                                    updateCommand.Parameters.AddWithValue("@ItemName", itemName);
                                    updateCommand.Parameters.AddWithValue("@CurrentPrice", currentPrice);
                                    updateCommand.Parameters.AddWithValue("@DeliveryAvailable", deliveryAvailable);
                                    updateCommand.ExecuteNonQuery();
                                    row.Cells["RowState"].Value = "Unchanged";
                                    kt = true;
                                    break;
                                }
                            }
                            if (!ktCategory)
                            {
                                MessageBox.Show("Vui lòng nhập đúng phân loại có sẵn trong hệ thống!");
                                continue;
                            }
                        }
                    }
                    if (kt)
                    {
                        MessageBox.Show("Lưu món ăn thành công!");
                        LoadMenu(_staff.BranchID);
                    }
                    else
                    {
                        MessageBox.Show("Không có món ăn nào được thêm hoặc sửa!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Co bien!: {ex.Message}");
            }
        }
        private string GenerateNewItemID(string latestItemID)
        {
            if (string.IsNullOrEmpty(latestItemID))
            {
                return "MI001";
            }

            int newID = int.Parse(latestItemID.Substring(2)) + 1;
            return "MI" + newID.ToString("D3");
        }

        private void dataGridViewKetQua_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewKetQua.Rows[e.RowIndex];
                if (row.Cells["RowState"].Value != null && row.Cells["RowState"].Value.ToString() == "Unchanged")
                {
                    row.Cells["RowState"].Value = "Updated";
                }
            }
        }

        private void dataGridViewKetQua_UserAddedRow_1(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["RowState"].Value = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemID", typeof(string));
            dt.Columns.Add("CategoryID", typeof(string));
            dt.Columns.Add("Phân loại", typeof(string));
            dt.Columns.Add("Tên món", typeof(string));
            dt.Columns.Add("Giá tiền", typeof(double));
            dt.Columns.Add("Có thể giao hàng", typeof(bool));

            _items = _databaseService.GetMenuItemsByBranch(_staff.BranchID);

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

            if (dt != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Save an Excel File"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    string fileName = Path.GetFileName(filePath);
                    try
                    {
                        _excelExportService.ExportToExcel(dt, filePath, fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data available to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
