using Microsoft.Data.SqlClient;
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
using System.Configuration;
using winform_app.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace winform_app.Forms.Nhân_viên
{
    public partial class Admin_RevenueForm : Form
    {
        private readonly DatabaseService _databaseService;
        private readonly ExcelExportService _excelExportService;
        public Admin_RevenueForm()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            _excelExportService = new ExcelExportService();
            LoadRegions();
        }
        private void LoadRegions()
        {
            List<Models.Region> regions = _databaseService.GetRegions();

            regions.Insert(0, new Models.Region { RegionID = -1, RegionName = "Tất cả khu vực" });

            comboBoxKhuVuc.DisplayMember = "RegionName";
            comboBoxKhuVuc.ValueMember = "RegionID";
            comboBoxKhuVuc.DataSource = regions;
        }
        private void LoadBranches(int regionID)
        {
            List<Models.Branch> branches = _databaseService.GetBranchesByRegion(regionID);

            branches.Insert(0, new Models.Branch { BranchID = null, BranchName = "Tất cả chi nhánh" });

            comboBoxChiNhanh.DisplayMember = "BranchName";
            comboBoxChiNhanh.ValueMember = "BranchID";
            comboBoxChiNhanh.DataSource = branches;
        }
        private void dateTimePickerTuNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKhuVuc.SelectedValue is int regionID)
            {
                LoadBranches(regionID);
            }
        }

        private void comboBoxChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonXemThongKe_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerTuNgay.Value;
            DateTime endDate = dateTimePickerDenNgay.Value;
            string? branchID = comboBoxChiNhanh.SelectedValue?.ToString();
            //if (string.IsNullOrEmpty(branchID))
            //{
            //    MessageBox.Show("Please select a branch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            try
            {
                DataTable revenueData = _databaseService.GetRevenueStatisticsByBranch(startDate, endDate, branchID);
                dataGridViewKetQua.DataSource = revenueData;
                dataGridViewKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewKetQua.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonXuatExcel_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerTuNgay.Value;
            DateTime endDate = dateTimePickerDenNgay.Value;
            string? branchID = comboBoxChiNhanh.SelectedValue?.ToString();
            DataTable revenueData = _databaseService.GetRevenueStatisticsByBranch(startDate, endDate, branchID);

            if (revenueData != null)
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
                        _excelExportService.ExportToExcel(revenueData, filePath, fileName);
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
