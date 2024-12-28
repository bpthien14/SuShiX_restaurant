using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform_app.Services;

namespace winform_app.Forms.Nhân_viên
{
    public partial class nv_RevenueFood : Form
    {
        private readonly DatabaseService _databaseService;
        private readonly ExcelExportService _excelExportService;
        public nv_RevenueFood()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            _excelExportService = new ExcelExportService();
            LoadRegions();
        }
        private void LoadRegions()
        {
            List<Models.Region> regions = _databaseService.GetRegions();

            comboBoxKhuVuc.DisplayMember = "RegionName";
            comboBoxKhuVuc.ValueMember = "RegionID";
            comboBoxKhuVuc.DataSource = regions;
        }
        private void LoadBranches(int regionID)
        {
            List<Models.Branch> branches = _databaseService.GetBranchesByRegion(regionID);

            comboBoxChiNhanh.DisplayMember = "BranchName";
            comboBoxChiNhanh.ValueMember = "BranchID";
            comboBoxChiNhanh.DataSource = branches;
        }
        private void comboBoxKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKhuVuc.SelectedValue is int regionID)
            {
                LoadBranches(regionID);
            }
        }
        //private void LoadMenu(string branchID)
        //{
        //    List<Models.MenuItem> menu = _databaseService.GetMenuItemsByBranch(branchID);
        //    foreach (var item in menu)
        //    {
        //        MessageBox.Show($"ItemID: {item.ItemID}, ItemName: {item.ItemName}, CurrentPrice: {item.CurrentPrice}, DeliveryAvailable: {item.DeliveryAvailable}");
        //    }
        //    comboBoxFood.DisplayMember = "ItemName";
        //    comboBoxFood.ValueMember = "ItemID";
        //    comboBoxFood.DataSource = menu;
        //}
        //private void comboBoxChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBoxChiNhanh.SelectedValue != null)
        //    {
        //        string branchID = comboBoxChiNhanh.SelectedValue.ToString();
        //        LoadMenu(branchID);
        //    }
        //}

        private void buttonXemThongKe_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePickerTuNgay.Value;
            DateTime toDate = dateTimePickerDenNgay.Value;
            string branchID = comboBoxChiNhanh.SelectedValue?.ToString();

            DataTable menuItemStatus = _databaseService.GetMenuItemStatus(branchID, fromDate, toDate);
            dataGridViewKetQua.DataSource = menuItemStatus;
            dataGridViewKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewKetQua.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
    }
}
