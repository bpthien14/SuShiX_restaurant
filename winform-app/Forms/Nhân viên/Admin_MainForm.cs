using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_app.Forms.Nhân_viên
{
    public partial class Admin_MainForm : Form
    {
        public Admin_MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        private void ResetMenuItemBackColor()
        {
            thongKeDoanhThuTheoMonAnToolStripMenuItem.BackColor = Color.White;
            quanLyNhanSuToolStripMenuItem.BackColor = Color.White;
            thongKeDoanhThuChiNhanhToolStripMenuItem.BackColor = Color.White;
        }
        private void thongKeDoanhThuChiNhanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetMenuItemBackColor();
            thongKeDoanhThuChiNhanhToolStripMenuItem.BackColor = Color.LightGray;
            try
            {
                // Check if the form is already open
                foreach (Form form in this.MdiChildren)
                {
                    if (form is Admin_RevenueForm)
                    {
                        form.Activate();
                        return;
                    }
                }
                
                // Create and show the new form
                Admin_RevenueForm revenueForm = new Admin_RevenueForm
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill,
                    WindowState = FormWindowState.Maximized,
                    FormBorderStyle = FormBorderStyle.None
                };

                // Ensure proper docking and size handling
                this.IsMdiContainer = true; // Ensure the parent is an MDI container
                this.LayoutMdi(MdiLayout.Cascade); // Optional layout for MDI children

                revenueForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void thongKeDoanhThuTheoMonAnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetMenuItemBackColor();
            thongKeDoanhThuTheoMonAnToolStripMenuItem.BackColor = Color.LightGray;
            try
            {
                // Check if the form is already open
                foreach (Form form in this.MdiChildren)
                {
                    if (form is Admin_RevenueFood)
                    {
                        form.Activate();
                        return;
                    }
                }
                
                // Create and show the new form
                Admin_RevenueFood revenueForm = new Admin_RevenueFood
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill, // Ensure it fills the parent
                    WindowState = FormWindowState.Maximized, // Ensure it's maximized
                    FormBorderStyle = FormBorderStyle.None // Optional: borderless
                };

                // Ensure proper docking and size handling
                this.IsMdiContainer = true; // Ensure the parent is an MDI container
                this.LayoutMdi(MdiLayout.Cascade); // Optional layout for MDI children

                revenueForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void quanLyNhanSuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetMenuItemBackColor();
            quanLyNhanSuToolStripMenuItem.BackColor = Color.LightGray;
            try
            {
                // Check if the form is already open
                foreach (Form form in this.MdiChildren)
                {
                    if (form is Admin_ManageStaff)
                    {
                        form.Activate();
                        return;
                    }
                }

                // Create and show the new form
                Admin_ManageStaff manageStaffForm = new Admin_ManageStaff
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill,
                    WindowState = FormWindowState.Maximized,
                    FormBorderStyle = FormBorderStyle.None
                };
                manageStaffForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
