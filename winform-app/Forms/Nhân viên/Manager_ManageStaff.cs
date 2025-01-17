﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    public partial class Manager_ManageStaff : Form
    {
        private Staff _staff;
        private readonly DatabaseService _databaseService;
        private readonly ExcelExportService _excelExportService;
        Models.Region region = new Models.Region();

        public Manager_ManageStaff(Staff staff)
        {
            InitializeComponent();
            _staff = staff; 
            _databaseService = new DatabaseService();
            _excelExportService = new ExcelExportService();

            region = _databaseService.GetRegionByBranchId(_staff.BranchID.ToString());
            if (region != null)
            {
                labelKhuVuc.Text = region.RegionName;
            }

            labelChiNhanh.Text = _databaseService.GetBranchNameById(_staff.BranchID);
            LoadDepartments();
        }
        private void LoadDepartments()
        {
            List<Models.Department> departments = _databaseService.GetDepartments();

            departments.Insert(0, new Models.Department { DepartmentID = null, DepartmentName = "Tất cả bộ phận" });

            comboBoxBoPhan.DisplayMember = "DepartmentName";
            comboBoxBoPhan.ValueMember = "DepartmentID";
            comboBoxBoPhan.DataSource = departments;
        }


        private void dataGridViewNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //NhanVienDetailForm detailForm = new NhanVienDetailForm();
            //detailForm.ShowDialog();
        }


        private void buttonXemThongKe_Click(object sender, EventArgs e)
        {
            textBoxTimKiem.Clear();
            int regionID = region.RegionID;
            string? branchID = _staff.BranchID;
            string? departmentID = comboBoxBoPhan.SelectedValue?.ToString();

            DataTable staffStatistics = _databaseService.GetStaffStatistics(regionID, branchID, departmentID);
            dataGridViewNhanVien.DataSource = staffStatistics;
            dataGridViewNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void buttonXuatExcel_Click(object sender, EventArgs e)
        {
            int regionID = region.RegionID;
            string? branchID = _staff.BranchID;
            string? departmentID = comboBoxBoPhan.SelectedValue?.ToString();

            DataTable staffStatistics = _databaseService.GetStaffStatistics(regionID, branchID, departmentID);

            if (staffStatistics != null)
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
                        _excelExportService.ExportToExcel(staffStatistics, filePath, fileName);
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

        private void comboBoxBoPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBoxChiNhanh.SelectedValue == null)
            //{
            //    comboBoxKhuVuc.SelectedIndex = -1;
            //}
        }

        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewNhanVien.DataSource is DataTable dt)
            {
                string searchValue = textBoxTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(searchValue))
                {
                    // Show all rows if the search is empty
                    dt.DefaultView.RowFilter = string.Empty;
                    return;
                }

                string filterExpression = $"CONVERT([Họ Tên], System.String) LIKE '%{searchValue}%' OR " +
                                   $"[Khu Vực] LIKE '%{searchValue}%' OR " +
                                   $"[Chi Nhánh] LIKE '%{searchValue}%' OR " +
                                   $"[Bộ Phận] LIKE '%{searchValue}%' OR " +
                                   $"[SĐT] LIKE '%{searchValue}%' OR " +
                                   $"CONVERT([Lương], System.String) LIKE '%{searchValue}%'";

                dt.DefaultView.RowFilter = filterExpression;

                //// Check if any rows are visible after filtering
                //if (dt.DefaultView.Count == 0)
                //{
                //    MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            else if (!string.IsNullOrEmpty(textBoxTimKiem.Text))
            {
                MessageBox.Show("Xin hãy thống kê dữ liệu trước khi tìm kiếm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
