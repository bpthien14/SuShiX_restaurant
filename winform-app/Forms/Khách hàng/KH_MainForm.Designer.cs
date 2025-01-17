﻿namespace winform_app.Forms.Khách_hàng
{
    partial class KH_MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KH_MainForm));
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonFindBranch = new Button();
            buttonOrderTakeout = new Button();
            buttonReserveTable = new Button();
            buttonLogout = new Button();
            labelTitle = new Label();
            labelOngoingDeliveries = new Label();
            labelPendingReservations = new Label();
            labelCurrentOrders = new Label();
            labelPoints = new Label();
            labelMembership = new Label();
            labelGreeting = new Label();
            panelUserInterface = new Panel();
            UpdatePersonalInfo = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelUserInterface.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(18, 20);
            pictureBox3.Margin = new Padding(4, 6, 4, 6);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(104, 110);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(939, 4);
            pictureBox1.Margin = new Padding(4, 6, 4, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(815, 76);
            panel1.Margin = new Padding(4, 6, 4, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(206, 225);
            panel1.TabIndex = 14;
            panel1.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(buttonFindBranch, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonOrderTakeout, 0, 2);
            tableLayoutPanel1.Controls.Add(buttonReserveTable, 0, 1);
            tableLayoutPanel1.Controls.Add(buttonLogout, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 6, 4, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
            tableLayoutPanel1.Size = new Size(206, 225);
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
            buttonFindBranch.Location = new Point(4, 0);
            buttonFindBranch.Margin = new Padding(4, 0, 4, 0);
            buttonFindBranch.Name = "buttonFindBranch";
            buttonFindBranch.Size = new Size(188, 50);
            buttonFindBranch.TabIndex = 6;
            buttonFindBranch.Text = "Tìm chi nhánh";
            buttonFindBranch.UseVisualStyleBackColor = false;
            buttonFindBranch.Click += buttonFindBranch_Click;
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
            buttonOrderTakeout.Location = new Point(4, 114);
            buttonOrderTakeout.Margin = new Padding(4, 0, 4, 0);
            buttonOrderTakeout.Name = "buttonOrderTakeout";
            buttonOrderTakeout.Size = new Size(188, 50);
            buttonOrderTakeout.TabIndex = 5;
            buttonOrderTakeout.Text = "Đặt giao hàng";
            buttonOrderTakeout.UseVisualStyleBackColor = false;
            buttonOrderTakeout.Click += buttonOrderTakeout_Click;
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
            buttonReserveTable.Location = new Point(4, 57);
            buttonReserveTable.Margin = new Padding(4, 0, 4, 0);
            buttonReserveTable.Name = "buttonReserveTable";
            buttonReserveTable.Size = new Size(188, 50);
            buttonReserveTable.TabIndex = 3;
            buttonReserveTable.Text = "Đặt bàn";
            buttonReserveTable.UseVisualStyleBackColor = false;
            buttonReserveTable.Click += buttonReserveTable_Click;
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
            buttonLogout.Location = new Point(4, 177);
            buttonLogout.Margin = new Padding(4, 6, 4, 6);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(188, 45);
            buttonLogout.TabIndex = 2;
            buttonLogout.Text = "Đăng xuất";
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Viner Hand ITC", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Maroon;
            labelTitle.Location = new Point(38, 135);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(64, 408);
            labelTitle.TabIndex = 11;
            labelTitle.Text = "S\r\nU\r\nS\r\nH\r\nI\r\nX\r\n";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelOngoingDeliveries
            // 
            labelOngoingDeliveries.AutoSize = true;
            labelOngoingDeliveries.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelOngoingDeliveries.Location = new Point(57, 453);
            labelOngoingDeliveries.Margin = new Padding(4, 0, 4, 0);
            labelOngoingDeliveries.Name = "labelOngoingDeliveries";
            labelOngoingDeliveries.Size = new Size(318, 38);
            labelOngoingDeliveries.TabIndex = 12;
            labelOngoingDeliveries.Text = "Đơn hàng đang giao: x";
            // 
            // labelPendingReservations
            // 
            labelPendingReservations.AutoSize = true;
            labelPendingReservations.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPendingReservations.Location = new Point(44, 390);
            labelPendingReservations.Margin = new Padding(4, 0, 4, 0);
            labelPendingReservations.Name = "labelPendingReservations";
            labelPendingReservations.Size = new Size(344, 38);
            labelPendingReservations.TabIndex = 11;
            labelPendingReservations.Text = "Đơn đặt bàn đang chờ: x";
            // 
            // labelCurrentOrders
            // 
            labelCurrentOrders.AutoSize = true;
            labelCurrentOrders.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCurrentOrders.Location = new Point(26, 332);
            labelCurrentOrders.Margin = new Padding(4, 0, 4, 0);
            labelCurrentOrders.Name = "labelCurrentOrders";
            labelCurrentOrders.Size = new Size(372, 38);
            labelCurrentOrders.TabIndex = 10;
            labelCurrentOrders.Text = "-------- Đơn hiện tại --------";
            // 
            // labelPoints
            // 
            labelPoints.AutoSize = true;
            labelPoints.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPoints.Location = new Point(44, 134);
            labelPoints.Margin = new Padding(4, 0, 4, 0);
            labelPoints.Name = "labelPoints";
            labelPoints.Size = new Size(328, 38);
            labelPoints.TabIndex = 9;
            labelPoints.Text = "Điểm tích lũy: xxx điểm";
            // 
            // labelMembership
            // 
            labelMembership.BackColor = Color.White;
            labelMembership.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMembership.ForeColor = SystemColors.ActiveBorder;
            labelMembership.Location = new Point(15, 72);
            labelMembership.Margin = new Padding(4, 0, 4, 0);
            labelMembership.Name = "labelMembership";
            labelMembership.Size = new Size(432, 42);
            labelMembership.TabIndex = 1;
            labelMembership.Text = "Member";
            labelMembership.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGreeting
            // 
            labelGreeting.AutoSize = true;
            labelGreeting.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelGreeting.Location = new Point(30, 18);
            labelGreeting.Margin = new Padding(4, 0, 4, 0);
            labelGreeting.Name = "labelGreeting";
            labelGreeting.Size = new Size(371, 38);
            labelGreeting.TabIndex = 0;
            labelGreeting.Text = "Xin chào, [Tên khách hàng]";
            // 
            // panelUserInterface
            // 
            panelUserInterface.Controls.Add(UpdatePersonalInfo);
            panelUserInterface.Controls.Add(labelMembership);
            panelUserInterface.Controls.Add(labelGreeting);
            panelUserInterface.Controls.Add(labelCurrentOrders);
            panelUserInterface.Controls.Add(labelPoints);
            panelUserInterface.Controls.Add(labelPendingReservations);
            panelUserInterface.Controls.Add(labelOngoingDeliveries);
            panelUserInterface.Location = new Point(303, 76);
            panelUserInterface.Margin = new Padding(4, 4, 4, 4);
            panelUserInterface.Name = "panelUserInterface";
            panelUserInterface.Size = new Size(452, 520);
            panelUserInterface.TabIndex = 18;
            // 
            // UpdatePersonalInfo
            // 
            UpdatePersonalInfo.BackColor = Color.IndianRed;
            UpdatePersonalInfo.FlatAppearance.BorderColor = Color.FromArgb(255, 165, 79);
            UpdatePersonalInfo.FlatAppearance.BorderSize = 0;
            UpdatePersonalInfo.FlatAppearance.MouseOverBackColor = Color.Brown;
            UpdatePersonalInfo.FlatStyle = FlatStyle.Flat;
            UpdatePersonalInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdatePersonalInfo.ForeColor = Color.White;
            UpdatePersonalInfo.Location = new Point(111, 216);
            UpdatePersonalInfo.Margin = new Padding(4, 6, 4, 6);
            UpdatePersonalInfo.Name = "UpdatePersonalInfo";
            UpdatePersonalInfo.Size = new Size(225, 58);
            UpdatePersonalInfo.TabIndex = 7;
            UpdatePersonalInfo.Text = "Cập nhật thông tin";
            UpdatePersonalInfo.UseVisualStyleBackColor = false;
            UpdatePersonalInfo.Click += UpdatePersonalInfo_Click;
            // 
            // KH_MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1038, 645);
            Controls.Add(labelTitle);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(panelUserInterface);
            Margin = new Padding(4, 4, 4, 4);
            Name = "KH_MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load_KH;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panelUserInterface.ResumeLayout(false);
            panelUserInterface.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelTitle;
        private Button buttonLogout;
        private Label labelOngoingDeliveries;
        private Label labelPendingReservations;
        private Label labelCurrentOrders;
        private Label labelPoints;
        private Button buttonFindBranch;
        private Button buttonOrderTakeout;
        private Button buttonReserveTable;
        private Label labelMembership;
        private Label labelGreeting;
        private Panel panelUserInterface;
        private Button UpdatePersonalInfo;
    }
}