using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using winform_app.Models;
using winform_app.Services;

namespace winform_app.Forms.Khách_hàng
{
    public partial class FindBranchForm : Form
    {
        private Users _user;
        private DatabaseService _databaseService;

        public FindBranchForm(Users user)
        {
            InitializeComponent();
            _user = user;
            _databaseService = new DatabaseService();
            LoadRegionNames();
        }

        private void LoadRegionNames()
        {
            List<Models.Region> regions = _databaseService.GetRegions();

            regions.Insert(0, new Models.Region { RegionID = -1, RegionName = "Tất cả khu vực" });

            cmbRegionName.DisplayMember = "RegionName";
            cmbRegionName.ValueMember = "RegionID";
            cmbRegionName.DataSource = regions;
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

            //branches.Insert(0, new Models.Branch { BranchID = null, BranchName = "Tất cả chi nhánh" });

            cmbBranchName.DisplayMember = "BranchName";
            cmbBranchName.ValueMember = "BranchID";
            cmbBranchName.DataSource = branches;
        }

        private void cmbBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBranchName.SelectedValue is string branchID)
            {
                DisplayBranchInfo(branchID);
            }
        }

        private void DisplayBranchInfo(string branchID)
        {
            Branch branch = _databaseService.GetBranchById(branchID);
            if (branch != null)
            {
                rtbBranchInfo.Text = $"Branch Name: {branch.BranchName}\n" +
                                     $"Address: {branch.Address}\n" +
                                     $"Phone: {branch.BranchPhoneNumber}\n" +
                                     $"Opening Time: {branch.OpeningTime}\n" +
                                     $"Closing Time: {branch.ClosingTime}\n" +
                                     $"Car Parking: {(branch.HasCarParking ? "Yes" : "No")}\n" +
                                     $"Bike Parking: {(branch.HasBikeParking ? "Yes" : "No")}\n" +
                                     $"Delivery Service: {(branch.DeliveryService ? "Yes" : "No")}\n" +
                                     $"Manager ID: {branch.ManagerID}";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            KH_MainForm mainForm = new KH_MainForm(_user);
            mainForm.Show();
        }
    }
}


