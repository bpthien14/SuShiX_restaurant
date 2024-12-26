using System.Drawing.Drawing2D;

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
        ApplyRoundedCorners(buttonRegister, 10);
        ApplyRoundedCorners(buttonReserveTable, 10);
        ApplyRoundedCorners(buttonViewMenu, 10);
        ApplyRoundedCorners(buttonOrderTakeout, 10);
        ApplyRoundedCorners(buttonFindBranch, 10);
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
    private void buttonReserveTable_Click(object sender, EventArgs e)
    {

    }
    private void buttonOrderTakeout_Click(object sender, EventArgs e)
    {

    }
    private void buttonFindBranch_Click(object sender, EventArgs e)
    {

    }
    private void ApplyRoundedCorners(Button button, int cornerRadius)
    {
        GraphicsPath path = new GraphicsPath();
        path.AddArc(new Rectangle(0, 0, cornerRadius, cornerRadius), 180, 90);
        path.AddArc(new Rectangle(button.Width - cornerRadius - 1, 0, cornerRadius, cornerRadius), -90, 90);
        path.AddArc(new Rectangle(button.Width - cornerRadius - 1, button.Height - cornerRadius - 1, cornerRadius, cornerRadius), 0, 90);
        path.AddArc(new Rectangle(0, button.Height - cornerRadius - 1, cornerRadius, cornerRadius), 90, 90);
        path.CloseAllFigures();
        button.Region = new Region(path);
    }

    private void buttonLogin_Click(object sender, EventArgs e)
    {
        LoginForm loginForm = new LoginForm();
        loginForm.Show();
        this.Hide();
    }
}