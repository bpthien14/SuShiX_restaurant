namespace winform_app.Forms.Khách_hàng
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonViewMenu = new Button();
            buttonReserveTable = new Button();
            buttonOrderTakeout = new Button();
            buttonFindBranch = new Button();
            labelTitle = new Label();
            buttonLogin = new Button();
            buttonRegister = new Button();
            buttonLogout = new Button();
            labelOngoingDeliveries = new Label();
            labelPendingReservations = new Label();
            labelCurrentOrders = new Label();
            labelPoints = new Label();
            buttonOrderHistory = new Button();
            buttonPersonalInfo = new Button();
            labelMembership = new Label();
            labelGreeting = new Label();
            panelUserInterface = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelUserInterface.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(53, 18);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(69, 73);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(452, 155);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(259, 227);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(785, 3);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(43, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(664, 51);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(229, 200);
            panel1.TabIndex = 14;
            panel1.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(buttonViewMenu, 0, 3);
            tableLayoutPanel1.Controls.Add(buttonReserveTable, 0, 1);
            tableLayoutPanel1.Controls.Add(buttonOrderTakeout, 0, 2);
            tableLayoutPanel1.Controls.Add(buttonFindBranch, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(229, 200);
            tableLayoutPanel1.TabIndex = 0;
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
            buttonViewMenu.Location = new Point(3, 129);
            buttonViewMenu.Margin = new Padding(3, 0, 3, 0);
            buttonViewMenu.Name = "buttonViewMenu";
            buttonViewMenu.Size = new Size(161, 40);
            buttonViewMenu.TabIndex = 4;
            buttonViewMenu.Text = "Xem Menu";
            buttonViewMenu.UseVisualStyleBackColor = false;
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
            buttonReserveTable.Location = new Point(3, 43);
            buttonReserveTable.Margin = new Padding(3, 0, 3, 0);
            buttonReserveTable.Name = "buttonReserveTable";
            buttonReserveTable.Size = new Size(161, 40);
            buttonReserveTable.TabIndex = 3;
            buttonReserveTable.Text = "Đặt bàn";
            buttonReserveTable.UseVisualStyleBackColor = false;
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
            buttonOrderTakeout.Location = new Point(3, 86);
            buttonOrderTakeout.Margin = new Padding(3, 0, 3, 0);
            buttonOrderTakeout.Name = "buttonOrderTakeout";
            buttonOrderTakeout.Size = new Size(161, 40);
            buttonOrderTakeout.TabIndex = 5;
            buttonOrderTakeout.Text = "Đặt giao hàng";
            buttonOrderTakeout.UseVisualStyleBackColor = false;
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
            buttonFindBranch.Location = new Point(3, 0);
            buttonFindBranch.Margin = new Padding(3, 0, 3, 0);
            buttonFindBranch.Name = "buttonFindBranch";
            buttonFindBranch.Size = new Size(161, 40);
            buttonFindBranch.TabIndex = 6;
            buttonFindBranch.Text = "Tìm chi nhánh";
            buttonFindBranch.UseVisualStyleBackColor = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Maroon;
            labelTitle.Location = new Point(403, 155);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(43, 234);
            labelTitle.TabIndex = 11;
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
            buttonLogin.Location = new Point(403, 7);
            buttonLogin.Margin = new Padding(3, 4, 3, 4);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(114, 40);
            buttonLogin.TabIndex = 12;
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
            buttonRegister.Location = new Point(523, 7);
            buttonRegister.Margin = new Padding(3, 4, 3, 4);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(114, 40);
            buttonRegister.TabIndex = 13;
            buttonRegister.Text = "Đăng ký";
            buttonRegister.UseVisualStyleBackColor = false;
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
            buttonLogout.Location = new Point(643, 7);
            buttonLogout.Margin = new Padding(3, 4, 3, 4);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(114, 40);
            buttonLogout.TabIndex = 2;
            buttonLogout.Text = "Đăng xuất";
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Visible = false;
            // 
            // labelOngoingDeliveries
            // 
            labelOngoingDeliveries.AutoSize = true;
            labelOngoingDeliveries.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelOngoingDeliveries.Location = new Point(29, 300);
            labelOngoingDeliveries.Name = "labelOngoingDeliveries";
            labelOngoingDeliveries.Size = new Size(228, 28);
            labelOngoingDeliveries.TabIndex = 12;
            labelOngoingDeliveries.Text = "Đơn hàng đang giao: x";
            // 
            // labelPendingReservations
            // 
            labelPendingReservations.AutoSize = true;
            labelPendingReservations.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPendingReservations.Location = new Point(29, 267);
            labelPendingReservations.Name = "labelPendingReservations";
            labelPendingReservations.Size = new Size(248, 28);
            labelPendingReservations.TabIndex = 11;
            labelPendingReservations.Text = "Đơn đặt bàn đang chờ: x";
            // 
            // labelCurrentOrders
            // 
            labelCurrentOrders.AutoSize = true;
            labelCurrentOrders.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCurrentOrders.Location = new Point(21, 239);
            labelCurrentOrders.Name = "labelCurrentOrders";
            labelCurrentOrders.Size = new Size(270, 28);
            labelCurrentOrders.TabIndex = 10;
            labelCurrentOrders.Text = "-------- Đơn hiện tại --------";
            // 
            // labelPoints
            // 
            labelPoints.AutoSize = true;
            labelPoints.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPoints.Location = new Point(29, 89);
            labelPoints.Name = "labelPoints";
            labelPoints.Size = new Size(237, 28);
            labelPoints.TabIndex = 9;
            labelPoints.Text = "Điểm tích lũy: xxx điểm";
            // 
            // buttonOrderHistory
            // 
            buttonOrderHistory.BackColor = Color.IndianRed;
            buttonOrderHistory.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
            buttonOrderHistory.FlatAppearance.BorderSize = 0;
            buttonOrderHistory.FlatAppearance.MouseOverBackColor = Color.Brown;
            buttonOrderHistory.FlatStyle = FlatStyle.Flat;
            buttonOrderHistory.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonOrderHistory.ForeColor = Color.White;
            buttonOrderHistory.Location = new Point(77, 195);
            buttonOrderHistory.Margin = new Padding(3, 4, 3, 4);
            buttonOrderHistory.Name = "buttonOrderHistory";
            buttonOrderHistory.Size = new Size(161, 40);
            buttonOrderHistory.TabIndex = 8;
            buttonOrderHistory.Text = "Lịch sử đơn hàng";
            buttonOrderHistory.UseVisualStyleBackColor = false;
            // 
            // buttonPersonalInfo
            // 
            buttonPersonalInfo.BackColor = Color.IndianRed;
            buttonPersonalInfo.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
            buttonPersonalInfo.FlatAppearance.BorderSize = 0;
            buttonPersonalInfo.FlatAppearance.MouseOverBackColor = Color.Brown;
            buttonPersonalInfo.FlatStyle = FlatStyle.Flat;
            buttonPersonalInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPersonalInfo.ForeColor = Color.White;
            buttonPersonalInfo.Location = new Point(77, 147);
            buttonPersonalInfo.Margin = new Padding(3, 4, 3, 4);
            buttonPersonalInfo.Name = "buttonPersonalInfo";
            buttonPersonalInfo.Size = new Size(161, 40);
            buttonPersonalInfo.TabIndex = 7;
            buttonPersonalInfo.Text = "Thông tin cá nhân";
            buttonPersonalInfo.UseVisualStyleBackColor = false;
            // 
            // labelMembership
            // 
            labelMembership.AutoSize = true;
            labelMembership.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMembership.Location = new Point(13, 55);
            labelMembership.Name = "labelMembership";
            labelMembership.Size = new Size(288, 28);
            labelMembership.TabIndex = 1;
            labelMembership.Text = "[Thẻ MEMBER/SILVER/GOLD]";
            // 
            // labelGreeting
            // 
            labelGreeting.AutoSize = true;
            labelGreeting.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelGreeting.Location = new Point(20, 12);
            labelGreeting.Name = "labelGreeting";
            labelGreeting.Size = new Size(267, 28);
            labelGreeting.TabIndex = 0;
            labelGreeting.Text = "Xin chào, [Tên khách hàng]";
            // 
            // panelUserInterface
            // 
            panelUserInterface.Controls.Add(buttonPersonalInfo);
            panelUserInterface.Controls.Add(labelMembership);
            panelUserInterface.Controls.Add(buttonOrderHistory);
            panelUserInterface.Controls.Add(labelGreeting);
            panelUserInterface.Controls.Add(labelCurrentOrders);
            panelUserInterface.Controls.Add(labelPoints);
            panelUserInterface.Controls.Add(labelPendingReservations);
            panelUserInterface.Controls.Add(labelOngoingDeliveries);
            panelUserInterface.Location = new Point(53, 94);
            panelUserInterface.Name = "panelUserInterface";
            panelUserInterface.Size = new Size(301, 347);
            panelUserInterface.TabIndex = 18;
            panelUserInterface.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(839, 459);
            Controls.Add(pictureBox2);
            Controls.Add(labelTitle);
            Controls.Add(buttonLogin);
            Controls.Add(pictureBox3);
            Controls.Add(buttonLogout);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(buttonRegister);
            Controls.Add(panelUserInterface);
            Name = "MainForm";
            Text = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panelUserInterface.ResumeLayout(false);
            panelUserInterface.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelTitle;
        private Button buttonLogin;
        private Button buttonRegister;
        private Button buttonLogout;
        private Label labelOngoingDeliveries;
        private Label labelPendingReservations;
        private Label labelCurrentOrders;
        private Label labelPoints;
        private Button buttonOrderHistory;
        private Button buttonPersonalInfo;
        private Button buttonFindBranch;
        private Button buttonOrderTakeout;
        private Button buttonViewMenu;
        private Button buttonReserveTable;
        private Label labelMembership;
        private Label labelGreeting;
        private Panel panelUserInterface;
    }
}