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
    public partial class Manager_MenuItemsForm : Form
    {
        private Staff _staff;
        private DatabaseService _databaseService;

        public Manager_MenuItemsForm(Staff staff)
        {
            InitializeComponent();
            _staff = staff;
            _databaseService = new DatabaseService();

            Models.Region region = _databaseService.GetRegionByBranchId(_staff.BranchID.ToString());
            if (region != null)
            {
                labelKhuVuc.Text = region.RegionName;
            }

            labelChiNhanh.Text = _databaseService.GetBranchNameById(_staff.BranchID);
            LoadMenu(_staff.BranchID);
            LoadMenuCategories();

        }

        private void LoadMenuCategories()
        {
            //var categories = _databaseService.GetMenuCategories();
            //comboBoxCategory.DataSource = categories;
            //comboBoxCategory.DisplayMember = "CategoryName";
            //comboBoxCategory.ValueMember = "CategoryID";
        }

        private void LoadMenu(string branchID)
        {

        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //public List<MenuCategory> GetMenuCategories()
        //{
        //    // Implement database retrieval logic
        //}

        //public List<MenuItem> GetMenuItems()
        //{
        //    // Implement database retrieval logic
        //}

        //public void AddMenuItem(MenuItem item)
        //{
        //    // Implement database insertion logic
        //}

        //public void UpdateMenuItem(MenuItem item)
        //{
        //    // Implement database update logic
        //}

        //public void DeleteMenuItem(string itemID)
        //{
        //    // Implement database deletion logic
        //}

        //private void label5_Click(object sender, EventArgs e)
        //{

        //}
    }
}
