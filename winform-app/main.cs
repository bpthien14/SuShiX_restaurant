using System.Drawing.Drawing2D;
using winform_app.Forms.Khách_hàng;
using winform_app.Forms.Nhân_viên;
using winform_app.Services;
using winform_app.Models;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic.ApplicationServices;

namespace winform_app;

public partial class MainForm : Form
{
    private int targetHeight = 0;
    public MainForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(MainForm_Load);
    }
    private void MainForm_Load(object? sender, EventArgs e)
    {
        ApplyRoundedCorners(buttonLogin, 10);
        ApplyRoundedCorners(buttonDangKi, 10);
        ApplyRoundedCorners(buttonViewMenu, 10);
        ApplyRoundedCorners(buttonViewMenu, 10);
        ApplyRoundedCorners(buttonOrderTakeout, 10);
        ApplyRoundedCorners(buttonReserveTable, 10);
        ApplyRoundedCorners(buttonFindBranch, 10);
        ApplyRoundedCorners(buttonLogout, 10);
    }
    private void ApplyRoundedCorners(Button button, int cornerRadius)
    {
        GraphicsPath path = new GraphicsPath();
        path.AddArc(new Rectangle(0, 0, cornerRadius, cornerRadius), 180, 90);
        path.AddArc(new Rectangle(button.Width - cornerRadius - 1, 0, cornerRadius, cornerRadius), -90, 90);
        path.AddArc(new Rectangle(button.Width - cornerRadius - 1, button.Height - cornerRadius - 1, cornerRadius, cornerRadius), 0, 90);
        path.AddArc(new Rectangle(0, button.Height - cornerRadius - 1, cornerRadius, cornerRadius), 90, 90);
        path.CloseAllFigures();
        button.Region = new System.Drawing.Region(path);
    }


    private void buttonNhanVien_Click(object sender, EventArgs e)
    {

    }

    private void buttonKhachHang_Click(object sender, EventArgs e)
    {
        LoginForm login = new LoginForm();
        login.FormClosed += (s, args) => this.Close();
        login.Show();
        this.Hide();
    }

    private async void pictureBox1_Click(object sender, EventArgs e)
    {

        if (panel1.Visible == false)
        {
            targetHeight = panel1.Height;
            panel1.Height = 0;
            panel1.Visible = true;
            await RevealPanelAsync();
        }
        else
        {
            await HidePanelAsync();
            panel1.Visible = false;
            panel1.Height = targetHeight;
        }
    }
    private async Task RevealPanelAsync()
    {
        while (panel1.Height < targetHeight)
        {
            panel1.Height += 5;
            await Task.Delay(1);
            if (panel1.Height >= targetHeight)
            {
                panel1.Height = targetHeight;
            }
        }
    }
    private async Task HidePanelAsync()
    {
        while (panel1.Height > 0)
        {
            panel1.Height -= 5;
            await Task.Delay(1);
            if (panel1.Height <= 0)
            {
                panel1.Height = 0;
            }
        }
    }

    private void buttonFindBranch_Click(object sender, EventArgs e)
    {
        Models.Users user = new Users();
        FindBranchForm orderTableForm = new FindBranchForm(user);
        orderTableForm.ShowDialog();
        //this.Close();
    }

    private void buttonViewMenu_Click(object sender, EventArgs e)
    {

    }

    private void buttonOrderTakeout_Click(object sender, EventArgs e)
    {
        //Models.Users user = new Users();
        //FindBranchForm orderTableForm = new FindBranchForm(user);
        //OrderDelivery orderDelivery = new OrderDelivery(user, this);
        //orderDelivery.ShowDialog();
    }

    private void buttonReserveTable_Click(object sender, EventArgs e)
    {
        //Models.Users user = new Users();
        //OrderTableForm orderTableForm = new OrderTableForm(user);
        //orderTableForm.ShowDialog();
        //this.Close();
    }
}