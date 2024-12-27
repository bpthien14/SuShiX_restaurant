using System.Drawing.Drawing2D;
using winform_app.Forms.Khách_hàng;
using winform_app.Forms.Nhân_viên;

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
        ApplyRoundedCorners(buttonKhachHang, 10);
        ApplyRoundedCorners(buttonNhanVien, 10);
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

    private void buttonKhachHang_Click(object sender, EventArgs e)
    {
        KH_MainForm khMainForm = new KH_MainForm();
        khMainForm.FormClosed += (s, args) => this.Close();
        khMainForm.Show();
        this.Hide();
    }

    private void buttonNhanVien_Click(object sender, EventArgs e)
    {
        NV_MainForm nvMainForm = new NV_MainForm();
        nvMainForm.FormClosed += (s, args) => this.Close();
        nvMainForm.Show();
        this.Hide();
    }
}