namespace winform_app;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Button buttonKhachHang;
    private System.Windows.Forms.Button buttonNhanVien;

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
        buttonKhachHang = new Button();
        buttonNhanVien = new Button();
        pictureBox2 = new PictureBox();
        pictureBox3 = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
        SuspendLayout();
        // 
        // labelTitle
        // 
        labelTitle.AutoSize = true;
        labelTitle.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        labelTitle.ForeColor = Color.Maroon;
        labelTitle.Location = new Point(38, 93);
        labelTitle.Name = "labelTitle";
        labelTitle.Size = new Size(43, 234);
        labelTitle.TabIndex = 0;
        labelTitle.Text = "S\r\nU\r\nS\r\nH\r\nI\r\nX\r\n";
        labelTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // buttonKhachHang
        // 
        buttonKhachHang.BackColor = Color.IndianRed;
        buttonKhachHang.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
        buttonKhachHang.FlatAppearance.BorderSize = 0;
        buttonKhachHang.FlatAppearance.MouseOverBackColor = Color.Brown;
        buttonKhachHang.FlatStyle = FlatStyle.Flat;
        buttonKhachHang.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonKhachHang.ForeColor = Color.White;
        buttonKhachHang.Location = new Point(468, 137);
        buttonKhachHang.Margin = new Padding(3, 4, 3, 4);
        buttonKhachHang.Name = "buttonKhachHang";
        buttonKhachHang.Size = new Size(114, 40);
        buttonKhachHang.TabIndex = 1;
        buttonKhachHang.Text = "Khách hàng";
        buttonKhachHang.UseVisualStyleBackColor = false;
        // 
        // buttonNhanVien
        // 
        buttonNhanVien.BackColor = Color.IndianRed;
        buttonNhanVien.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
        buttonNhanVien.FlatAppearance.BorderSize = 0;
        buttonNhanVien.FlatAppearance.MouseOverBackColor = Color.Brown;
        buttonNhanVien.FlatStyle = FlatStyle.Flat;
        buttonNhanVien.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonNhanVien.ForeColor = Color.White;
        buttonNhanVien.Location = new Point(468, 197);
        buttonNhanVien.Margin = new Padding(3, 4, 3, 4);
        buttonNhanVien.Name = "buttonNhanVien";
        buttonNhanVien.Size = new Size(114, 40);
        buttonNhanVien.TabIndex = 2;
        buttonNhanVien.Text = "Nhân viên";
        buttonNhanVien.UseVisualStyleBackColor = false;
        buttonNhanVien.Click += buttonNhanVien_Click;
        // 
        // pictureBox2
        // 
        pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
        pictureBox2.Location = new Point(159, 107);
        pictureBox2.Margin = new Padding(3, 4, 3, 4);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new Size(259, 227);
        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox2.TabIndex = 9;
        pictureBox2.TabStop = false;
        // 
        // pictureBox3
        // 
        pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
        pictureBox3.Location = new Point(27, 16);
        pictureBox3.Margin = new Padding(3, 4, 3, 4);
        pictureBox3.Name = "pictureBox3";
        pictureBox3.Size = new Size(69, 73);
        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox3.TabIndex = 10;
        pictureBox3.TabStop = false;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(646, 451);
        Controls.Add(pictureBox3);
        Controls.Add(pictureBox2);
        Controls.Add(labelTitle);
        Controls.Add(buttonKhachHang);
        Controls.Add(buttonNhanVien);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(3, 4, 3, 4);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Main Page";
        Load += MainForm_Load;
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private PictureBox pictureBox2;
    private PictureBox pictureBox3;
}