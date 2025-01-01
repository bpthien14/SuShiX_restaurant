namespace winform_app;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Button buttonLogin;
    private System.Windows.Forms.Button buttonDangKi;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        buttonLogin = new Button();
        buttonDangKi = new Button();
        pictureBox2 = new PictureBox();
        pictureBox3 = new PictureBox();
        pictureBox1 = new PictureBox();
        panel1 = new Panel();
        tableLayoutPanel1 = new TableLayoutPanel();
        buttonFindBranch = new Button();
        buttonReserveTable = new Button();
        buttonOrderTakeout = new Button();
        buttonLogout = new Button();
        buttonViewMenu = new Button();
        label1 = new Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        panel1.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // buttonLogin
        // 
        buttonLogin.BackColor = Color.IndianRed;
        buttonLogin.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
        buttonLogin.FlatAppearance.BorderSize = 0;
        buttonLogin.FlatAppearance.MouseOverBackColor = Color.Brown;
        buttonLogin.FlatStyle = FlatStyle.Flat;
        buttonLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonLogin.ForeColor = Color.White;
        buttonLogin.Location = new Point(308, 420);
        buttonLogin.Margin = new Padding(4, 6, 4, 6);
        buttonLogin.Name = "buttonLogin";
        buttonLogin.Size = new Size(411, 60);
        buttonLogin.TabIndex = 1;
        buttonLogin.Text = "Đăng Nhập";
        buttonLogin.UseVisualStyleBackColor = false;
        buttonLogin.Click += buttonKhachHang_Click;
        // 
        // buttonDangKi
        // 
        buttonDangKi.BackColor = Color.IndianRed;
        buttonDangKi.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
        buttonDangKi.FlatAppearance.BorderSize = 0;
        buttonDangKi.FlatAppearance.MouseOverBackColor = Color.Brown;
        buttonDangKi.FlatStyle = FlatStyle.Flat;
        buttonDangKi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonDangKi.ForeColor = Color.White;
        buttonDangKi.Location = new Point(308, 492);
        buttonDangKi.Margin = new Padding(4, 6, 4, 6);
        buttonDangKi.Name = "buttonDangKi";
        buttonDangKi.Size = new Size(411, 60);
        buttonDangKi.TabIndex = 2;
        buttonDangKi.Text = "Đăng Ký";
        buttonDangKi.UseVisualStyleBackColor = false;
        buttonDangKi.Click += buttonNhanVien_Click;
        // 
        // pictureBox2
        // 
        pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
        pictureBox2.Location = new Point(290, 25);
        pictureBox2.Margin = new Padding(4, 6, 4, 6);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new Size(388, 340);
        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox2.TabIndex = 9;
        pictureBox2.TabStop = false;
        // 
        // pictureBox3
        // 
        pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
        pictureBox3.Location = new Point(40, 24);
        pictureBox3.Margin = new Padding(4, 6, 4, 6);
        pictureBox3.Name = "pictureBox3";
        pictureBox3.Size = new Size(104, 110);
        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox3.TabIndex = 10;
        pictureBox3.TabStop = false;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(892, 15);
        pictureBox1.Margin = new Padding(4, 6, 4, 6);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(64, 60);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 17;
        pictureBox1.TabStop = false;
        pictureBox1.Click += pictureBox1_Click;
        // 
        // panel1
        // 
        panel1.Controls.Add(tableLayoutPanel1);
        panel1.Location = new Point(768, 87);
        panel1.Margin = new Padding(4, 6, 4, 6);
        panel1.Name = "panel1";
        panel1.Size = new Size(206, 327);
        panel1.TabIndex = 16;
        panel1.Visible = false;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Controls.Add(buttonFindBranch, 0, 1);
        tableLayoutPanel1.Controls.Add(buttonReserveTable, 0, 0);
        tableLayoutPanel1.Controls.Add(buttonOrderTakeout, 0, 2);
        tableLayoutPanel1.Controls.Add(buttonLogout, 0, 5);
        tableLayoutPanel1.Controls.Add(buttonViewMenu, 0, 4);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Margin = new Padding(4, 6, 4, 6);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 6;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
        tableLayoutPanel1.Size = new Size(206, 327);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // buttonFindBranch
        // 
        buttonFindBranch.BackColor = Color.IndianRed;
        buttonFindBranch.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
        buttonFindBranch.FlatAppearance.BorderSize = 0;
        buttonFindBranch.FlatAppearance.MouseOverBackColor = Color.Brown;
        buttonFindBranch.FlatStyle = FlatStyle.Flat;
        buttonFindBranch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonFindBranch.ForeColor = Color.White;
        buttonFindBranch.Location = new Point(4, 55);
        buttonFindBranch.Margin = new Padding(4, 0, 4, 0);
        buttonFindBranch.Name = "buttonFindBranch";
        buttonFindBranch.Size = new Size(188, 50);
        buttonFindBranch.TabIndex = 6;
        buttonFindBranch.Text = "Tìm chi nhánh";
        buttonFindBranch.UseVisualStyleBackColor = false;
        buttonFindBranch.Click += buttonFindBranch_Click;
        // 
        // buttonReserveTable
        // 
        buttonReserveTable.BackColor = Color.IndianRed;
        buttonReserveTable.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
        buttonReserveTable.FlatAppearance.BorderSize = 0;
        buttonReserveTable.FlatAppearance.MouseOverBackColor = Color.Brown;
        buttonReserveTable.FlatStyle = FlatStyle.Flat;
        buttonReserveTable.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonReserveTable.ForeColor = Color.White;
        buttonReserveTable.Location = new Point(4, 0);
        buttonReserveTable.Margin = new Padding(4, 0, 4, 0);
        buttonReserveTable.Name = "buttonReserveTable";
        buttonReserveTable.Size = new Size(188, 50);
        buttonReserveTable.TabIndex = 3;
        buttonReserveTable.Text = "Đặt bàn";
        buttonReserveTable.UseVisualStyleBackColor = false;
        buttonReserveTable.Click += buttonReserveTable_Click;
        // 
        // buttonOrderTakeout
        // 
        buttonOrderTakeout.BackColor = Color.IndianRed;
        buttonOrderTakeout.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
        buttonOrderTakeout.FlatAppearance.BorderSize = 0;
        buttonOrderTakeout.FlatAppearance.MouseOverBackColor = Color.Brown;
        buttonOrderTakeout.FlatStyle = FlatStyle.Flat;
        buttonOrderTakeout.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonOrderTakeout.ForeColor = Color.White;
        buttonOrderTakeout.Location = new Point(4, 110);
        buttonOrderTakeout.Margin = new Padding(4, 0, 4, 0);
        buttonOrderTakeout.Name = "buttonOrderTakeout";
        buttonOrderTakeout.Size = new Size(188, 50);
        buttonOrderTakeout.TabIndex = 5;
        buttonOrderTakeout.Text = "Đặt giao hàng";
        buttonOrderTakeout.UseVisualStyleBackColor = false;
        buttonOrderTakeout.Click += buttonOrderTakeout_Click;
        // 
        // buttonLogout
        // 
        buttonLogout.BackColor = Color.IndianRed;
        buttonLogout.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
        buttonLogout.FlatAppearance.BorderSize = 0;
        buttonLogout.FlatAppearance.MouseOverBackColor = Color.Brown;
        buttonLogout.FlatStyle = FlatStyle.Flat;
        buttonLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonLogout.ForeColor = Color.White;
        buttonLogout.Location = new Point(4, 226);
        buttonLogout.Margin = new Padding(4, 6, 4, 6);
        buttonLogout.Name = "buttonLogout";
        buttonLogout.Size = new Size(188, 52);
        buttonLogout.TabIndex = 2;
        buttonLogout.Text = "Đăng xuất";
        buttonLogout.UseVisualStyleBackColor = false;
        buttonLogout.Visible = false;
        // 
        // buttonViewMenu
        // 
        buttonViewMenu.BackColor = Color.IndianRed;
        buttonViewMenu.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
        buttonViewMenu.FlatAppearance.BorderSize = 0;
        buttonViewMenu.FlatAppearance.MouseOverBackColor = Color.Brown;
        buttonViewMenu.FlatStyle = FlatStyle.Flat;
        buttonViewMenu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonViewMenu.ForeColor = Color.White;
        buttonViewMenu.Location = new Point(4, 165);
        buttonViewMenu.Margin = new Padding(4, 0, 4, 0);
        buttonViewMenu.Name = "buttonViewMenu";
        buttonViewMenu.Size = new Size(188, 52);
        buttonViewMenu.TabIndex = 4;
        buttonViewMenu.Text = "Xem Menu";
        buttonViewMenu.UseVisualStyleBackColor = false;
        buttonViewMenu.Click += buttonViewMenu_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Viner Hand ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        label1.ForeColor = Color.Maroon;
        label1.Location = new Point(53, 140);
        label1.Margin = new Padding(5, 0, 5, 0);
        label1.Name = "label1";
        label1.Size = new Size(73, 468);
        label1.TabIndex = 18;
        label1.Text = "S\r\nU\r\nS\r\nH\r\nI\r\nX\r\n";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(12F, 30F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(969, 676);
        Controls.Add(label1);
        Controls.Add(pictureBox1);
        Controls.Add(panel1);
        Controls.Add(pictureBox3);
        Controls.Add(pictureBox2);
        Controls.Add(buttonLogin);
        Controls.Add(buttonDangKi);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(4, 6, 4, 6);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Main Page";
        Load += MainForm_Load;
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        panel1.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private PictureBox pictureBox2;
    private PictureBox pictureBox3;
    private PictureBox pictureBox1;
    private Panel panel1;
    private TableLayoutPanel tableLayoutPanel1;
    private Button buttonFindBranch;
    private Button buttonReserveTable;
    private Button buttonOrderTakeout;
    private Button buttonLogout;
    private Button buttonViewMenu;
    private Label label1;
}