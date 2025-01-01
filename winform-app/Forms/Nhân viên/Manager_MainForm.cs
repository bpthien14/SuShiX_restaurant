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

namespace winform_app.Forms.Nhân_viên
{
    public partial class Manager_MainForm : Form
    {
        private Staff staff;
        public Manager_MainForm(Staff _staff)
        {
            InitializeComponent();
            staff = _staff;
            menuStrip.Dock = DockStyle.Top;
            this.IsMdiContainer = true;
        }
        private void ResetMenuItemBackColor()
        {
            quanLyMonAnToolStripMenuItem.BackColor = Color.White;
            thongKeDoanhThuTheoMonAnToolStripMenuItem.BackColor = Color.White;
            quanLyNhanSuToolStripMenuItem.BackColor = Color.White;
        }

        private void quanLyMonAnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetMenuItemBackColor();
            quanLyMonAnToolStripMenuItem.BackColor = Color.LightGray;
            try
            {
                // Check if the form is already open
                foreach (Form form in this.MdiChildren)
                {
                    if (form is Manager_MenuItemsForm)
                    {
                        form.Activate();
                        return;
                    }
                }

                // Create and show the new form
                Manager_MenuItemsForm menuForm = new Manager_MenuItemsForm(staff)
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill,
                    WindowState = FormWindowState.Maximized,
                    FormBorderStyle = FormBorderStyle.None
                };

                // Ensure proper docking and size handling
                this.IsMdiContainer = true;
                this.LayoutMdi(MdiLayout.Cascade);

                menuForm.Show();
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
                    if (form is Manager_RevenueForm)
                    {
                        form.Activate();
                        return;
                    }
                }

                // Create and show the new form
                Manager_RevenueForm revenueForm = new Manager_RevenueForm(staff)
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill,
                    WindowState = FormWindowState.Maximized,
                    FormBorderStyle = FormBorderStyle.None
                };

                // Ensure proper docking and size handling
                this.IsMdiContainer = true;
                this.LayoutMdi(MdiLayout.Cascade);

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
                    if (form is Manager_ManageStaff)
                    {
                        form.Activate();
                        return;
                    }
                }

                // Create and show the new form
                Manager_ManageStaff staffForm = new Manager_ManageStaff(staff)
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill,
                    WindowState = FormWindowState.Maximized,
                    FormBorderStyle = FormBorderStyle.None
                };

                // Ensure proper docking and size handling
                this.IsMdiContainer = true;
                this.LayoutMdi(MdiLayout.Cascade);

                staffForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Manager_MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
