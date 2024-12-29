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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace winform_app.Forms.Nhân_viên
{
    public partial class Manager_RevenueForm : Form
    {
        private Staff _staff;
        private DatabaseService _databaseService;
        private readonly ExcelExportService _excelExportService;

        public Manager_RevenueForm(Staff staff)
        {
            InitializeComponent();
            _staff = staff;
            _databaseService = new DatabaseService();
            _excelExportService = new ExcelExportService(); 

            Models.Region region = _databaseService.GetRegionByBranchId(_staff.BranchID.ToString());
            if (region != null)
            {
                labelKhuVuc.Text = region.RegionName;
            }

            labelChiNhanh.Text = _databaseService.GetBranchNameById(_staff.BranchID);
            LoadMenu(_staff.BranchID);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadMenu(string branchID)
        {
            List<Models.MenuItem> menu = _databaseService.GetMenuItemsByBranch(branchID);

            menu.Insert(0, new Models.MenuItem { ItemID = null, ItemName = "Tất cả món ăn" });

            comboBoxFood.DisplayMember = "ItemName";
            comboBoxFood.ValueMember = "ItemID";
            comboBoxFood.DataSource = menu;
        }
        private void comboBoxFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonXemThongKe_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePickerTuNgay.Value;
            DateTime toDate = dateTimePickerDenNgay.Value;
            string itemID = comboBoxFood.SelectedValue?.ToString();

            DataTable menuItemStatus = _databaseService.GetMenuItemStatus(_staff.BranchID, fromDate, toDate, itemID);
            dataGridViewKetQua.DataSource = menuItemStatus;
            dataGridViewKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewKetQua.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void buttonXuatExcel_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePickerTuNgay.Value;
            DateTime toDate = dateTimePickerDenNgay.Value;
            string itemID = comboBoxFood.SelectedValue?.ToString();

            DataTable menuItemStatus = _databaseService.GetMenuItemStatus(_staff.BranchID, fromDate, toDate, itemID);

            if (menuItemStatus != null)
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
                        _excelExportService.ExportToExcel(menuItemStatus, filePath, fileName);
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
