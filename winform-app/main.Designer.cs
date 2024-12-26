namespace winform_app;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Button buttonLogin;
    private System.Windows.Forms.Button buttonRegister;
    private System.Windows.Forms.Button buttonReserveTable;
    private System.Windows.Forms.Button buttonViewMenu;
    private System.Windows.Forms.Button buttonOrderTakeout;
    private System.Windows.Forms.Button buttonFindBranch;

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
        labelTitle = new Label();
        buttonLogin = new Button();
        buttonRegister = new Button();
        buttonReserveTable = new Button();
        buttonViewMenu = new Button();
        buttonOrderTakeout = new Button();
        buttonFindBranch = new Button();
        panel1 = new Panel();
        tableLayoutPanel1 = new TableLayoutPanel();
        pictureBox1 = new PictureBox();
        pictureBox2 = new PictureBox();
        pictureBox3 = new PictureBox();
        panel1.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
        SuspendLayout();
        // 
        // labelTitle
        // 
        labelTitle.AutoSize = true;
        labelTitle.Font = new Font("Viner Hand ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        labelTitle.ForeColor = Color.Maroon;
        labelTitle.Location = new Point(33, 70);
        labelTitle.Name = "labelTitle";
        labelTitle.Size = new Size(42, 264);
        labelTitle.TabIndex = 0;
        labelTitle.Text = "S\r\nU\r\nS\r\nH\r\nI\r\nX\r\n";
        labelTitle.TextAlign = ContentAlignment.MiddleCenter;
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
        buttonLogin.Location = new Point(294, 12);
        buttonLogin.Name = "buttonLogin";
        buttonLogin.Size = new Size(100, 30);
        buttonLogin.TabIndex = 1;
        buttonLogin.Text = "Đăng nhập";
        buttonLogin.UseVisualStyleBackColor = false;
        buttonLogin.Click += buttonLogin_Click;
        // 
        // buttonRegister
        // 
        buttonRegister.BackColor = Color.IndianRed;
        buttonRegister.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
        buttonRegister.FlatAppearance.BorderSize = 0;
        buttonRegister.FlatAppearance.MouseOverBackColor = Color.Brown;
        buttonRegister.FlatStyle = FlatStyle.Flat;
        buttonRegister.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonRegister.ForeColor = Color.White;
        buttonRegister.Location = new Point(394, 12);
        buttonRegister.Name = "buttonRegister";
        buttonRegister.Size = new Size(100, 30);
        buttonRegister.TabIndex = 2;
        buttonRegister.Text = "Đăng ký";
        buttonRegister.UseVisualStyleBackColor = false;
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
        buttonReserveTable.Location = new Point(3, 0);
        buttonReserveTable.Margin = new Padding(3, 0, 3, 0);
        buttonReserveTable.Name = "buttonReserveTable";
        buttonReserveTable.Size = new Size(141, 30);
        buttonReserveTable.TabIndex = 3;
        buttonReserveTable.Text = "Đặt bàn";
        buttonReserveTable.UseVisualStyleBackColor = false;
        buttonReserveTable.Click += buttonReserveTable_Click;
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
        buttonViewMenu.Location = new Point(3, 96);
        buttonViewMenu.Margin = new Padding(3, 0, 3, 0);
        buttonViewMenu.Name = "buttonViewMenu";
        buttonViewMenu.Size = new Size(141, 30);
        buttonViewMenu.TabIndex = 4;
        buttonViewMenu.Text = "Xem Menu";
        buttonViewMenu.UseVisualStyleBackColor = false;
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
        buttonOrderTakeout.Location = new Point(3, 64);
        buttonOrderTakeout.Margin = new Padding(3, 0, 3, 0);
        buttonOrderTakeout.Name = "buttonOrderTakeout";
        buttonOrderTakeout.Size = new Size(141, 30);
        buttonOrderTakeout.TabIndex = 5;
        buttonOrderTakeout.Text = "Đặt giao hàng";
        buttonOrderTakeout.UseVisualStyleBackColor = false;
        buttonOrderTakeout.Click += buttonOrderTakeout_Click;
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
        buttonFindBranch.Location = new Point(3, 32);
        buttonFindBranch.Margin = new Padding(3, 0, 3, 0);
        buttonFindBranch.Name = "buttonFindBranch";
        buttonFindBranch.Size = new Size(141, 30);
        buttonFindBranch.TabIndex = 6;
        buttonFindBranch.Text = "Tìm chi nhánh";
        buttonFindBranch.UseVisualStyleBackColor = false;
        buttonFindBranch.Click += buttonFindBranch_Click;
        // 
        // panel1
        // 
        panel1.Controls.Add(tableLayoutPanel1);
        panel1.Location = new Point(394, 48);
        panel1.Name = "panel1";
        panel1.Size = new Size(200, 150);
        panel1.TabIndex = 7;
        panel1.Visible = false;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Controls.Add(buttonReserveTable, 0, 0);
        tableLayoutPanel1.Controls.Add(buttonFindBranch, 0, 1);
        tableLayoutPanel1.Controls.Add(buttonOrderTakeout, 0, 2);
        tableLayoutPanel1.Controls.Add(buttonViewMenu, 0, 3);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 4;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel1.Size = new Size(200, 150);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(500, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(38, 30);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 8;
        pictureBox1.TabStop = false;
        pictureBox1.Click += pictureBox1_Click;
        // 
        // pictureBox2
        // 
        pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
        pictureBox2.Location = new Point(139, 80);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new Size(227, 170);
        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox2.TabIndex = 9;
        pictureBox2.TabStop = false;
        // 
        // pictureBox3
        // 
        pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
        pictureBox3.Location = new Point(24, 12);
        pictureBox3.Name = "pictureBox3";
        pictureBox3.Size = new Size(60, 55);
        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox3.TabIndex = 10;
        pictureBox3.TabStop = false;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(565, 338);
        Controls.Add(pictureBox3);
        Controls.Add(pictureBox2);
        Controls.Add(pictureBox1);
        Controls.Add(panel1);
        Controls.Add(labelTitle);
        Controls.Add(buttonLogin);
        Controls.Add(buttonRegister);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Main Page";
        Load += MainForm_Load;
        panel1.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
    #endregion
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel1;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;
    private PictureBox pictureBox3;
}