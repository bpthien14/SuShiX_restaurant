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

        private void thongKeDoanhThuChiNhanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                revenueForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void thongKeDoanhThuTheoMonAnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quanLyNhanSuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void capNhatLuongNhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
