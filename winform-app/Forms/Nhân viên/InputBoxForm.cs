using System;
using System.Windows.Forms;
using winform_app.Models;
using winform_app.Services;

namespace winform_app.Forms.Nhân_viên
{
    public partial class InputBoxForm : Form
    {
        public double Salary { get; private set; }
        private string _departmentID;
        private string _branchID;
        private readonly DatabaseService _databaseService;

        public InputBoxForm(string departmentID, string branchID)
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            _departmentID = departmentID;
            _branchID = branchID;
            labelPrompt.Text = $"Nhập lương cho các Nhân Viên thuộc {_databaseService.GetDeptNameById(departmentID)} tại {_databaseService.GetBranchNameById(branchID)}";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxInput.Text, out double salary))
            {
                Salary = salary;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InputBoxForm_Load(object sender, EventArgs e)
        {

        }
    }
}
