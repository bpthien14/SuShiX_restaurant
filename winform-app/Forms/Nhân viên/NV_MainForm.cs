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
    public partial class NV_MainForm : Form
    {
        public NV_MainForm()
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
                    if (form is NV_RevenueForm)
                    {
                        form.Activate();
                        return;
                    }
                }
                
                // Create and show the new form
                NV_RevenueForm revenueForm = new NV_RevenueForm
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
                    if (form is nv_RevenueFood)
                    {
                        form.Activate();
                        return;
                    }
                }
                
                // Create and show the new form
                nv_RevenueFood revenueForm = new nv_RevenueFood
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
                    if (form is NV_RevenueForm)
                    {
                        form.Activate();
                        return;
                    }
                }

                // Create and show the new form
                NV_ManageStaff manageStaffForm = new NV_ManageStaff
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
