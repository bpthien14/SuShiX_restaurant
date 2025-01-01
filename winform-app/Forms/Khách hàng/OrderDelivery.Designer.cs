namespace winform_app.Forms.Khách_hàng
{
    partial class OrderDelivery
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblRegionName;
        private System.Windows.Forms.ComboBox cmbRegionName;
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.ComboBox cmbBranchName;
        private System.Windows.Forms.Label lblDeliveryType;
        private System.Windows.Forms.RadioButton rbPickup;
        private System.Windows.Forms.RadioButton rbDelivery;
        private System.Windows.Forms.GroupBox gbDeliveryInfo;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblMenuCategory;
        private System.Windows.Forms.ComboBox cmbMenuCategory;
        private System.Windows.Forms.Button btnSearchMenu;
        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDeliveryAvailable;
        private System.Windows.Forms.DataGridViewButtonColumn colAddToCart;
        private System.Windows.Forms.Label lblSelectedItems;
        private System.Windows.Forms.DataGridView dgvSelectedItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelectedItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPrice;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblDeliveryFee;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblFinalAmount;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCheckout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblRegionName = new Label();
            cmbRegionName = new ComboBox();
            lblBranchName = new Label();
            cmbBranchName = new ComboBox();
            lblDeliveryType = new Label();
            rbPickup = new RadioButton();
            rbDelivery = new RadioButton();
            gbDeliveryInfo = new GroupBox();
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            lblCustomerPhone = new Label();
            txtCustomerPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblMenuCategory = new Label();
            cmbMenuCategory = new ComboBox();
            btnSearchMenu = new Button();
            dgvMenu = new DataGridView();
            colAddToCart = new DataGridViewButtonColumn();
            lblSelectedItems = new Label();
            dgvSelectedItems = new DataGridView();
            lblNotes = new Label();
            txtNotes = new TextBox();
            lblTotalAmount = new Label();
            lblDeliveryFee = new Label();
            lblDiscount = new Label();
            lblFinalAmount = new Label();
            btnBack = new Button();
            btnCheckout = new Button();
            gbDeliveryInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedItems).BeginInit();
            SuspendLayout();
            // 
            // lblRegionName
            // 
            lblRegionName.AutoSize = true;
            lblRegionName.Location = new Point(24, 34);
            lblRegionName.Margin = new Padding(6, 0, 6, 0);
            lblRegionName.Name = "lblRegionName";
            lblRegionName.Size = new Size(144, 30);
            lblRegionName.TabIndex = 0;
            lblRegionName.Text = "Khu vực:";
            // 
            // cmbRegionName
            // 
            cmbRegionName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRegionName.FormattingEnabled = true;
            cmbRegionName.Location = new Point(240, 27);
            cmbRegionName.Margin = new Padding(6, 8, 6, 8);
            cmbRegionName.Name = "cmbRegionName";
            cmbRegionName.Size = new Size(396, 38);
            cmbRegionName.TabIndex = 1;
            cmbRegionName.SelectedIndexChanged += cmbRegionName_SelectedIndexChanged;
            // 
            // lblBranchName
            // 
            lblBranchName.AutoSize = true;
            lblBranchName.Location = new Point(24, 104);
            lblBranchName.Margin = new Padding(6, 0, 6, 0);
            lblBranchName.Name = "lblBranchName";
            lblBranchName.Size = new Size(144, 30);
            lblBranchName.TabIndex = 2;
            lblBranchName.Text = "Chi Nhánh:";
            // 
            // cmbBranchName
            // 
            cmbBranchName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranchName.FormattingEnabled = true;
            cmbBranchName.Location = new Point(240, 98);
            cmbBranchName.Margin = new Padding(6, 8, 6, 8);
            cmbBranchName.Name = "cmbBranchName";
            cmbBranchName.Size = new Size(396, 38);
            cmbBranchName.TabIndex = 3;
            cmbBranchName.SelectedIndexChanged += cmbBranchName_SelectedIndexChanged;
            // 
            // lblDeliveryType
            // 
            lblDeliveryType.AutoSize = true;
            lblDeliveryType.Location = new Point(24, 172);
            lblDeliveryType.Margin = new Padding(6, 0, 6, 0);
            lblDeliveryType.Name = "lblDeliveryType";
            lblDeliveryType.Size = new Size(141, 30);
            lblDeliveryType.TabIndex = 4;
            lblDeliveryType.Text = "Loại giao hàng:";
            // 
            // rbPickup
            // 
            rbPickup.AutoSize = true;
            rbPickup.Location = new Point(240, 168);
            rbPickup.Margin = new Padding(6, 8, 6, 8);
            rbPickup.Name = "rbPickup";
            rbPickup.Size = new Size(99, 34);
            rbPickup.TabIndex = 5;
            rbPickup.TabStop = true;
            rbPickup.Text = "Đến lấy";
            rbPickup.UseVisualStyleBackColor = true;
            rbPickup.CheckedChanged += rbPickup_CheckedChanged;
            // 
            // rbDelivery
            // 
            rbDelivery.AutoSize = true;
            rbDelivery.Location = new Point(422, 168);
            rbDelivery.Margin = new Padding(6, 8, 6, 8);
            rbDelivery.Name = "rbDelivery";
            rbDelivery.Size = new Size(112, 34);
            rbDelivery.TabIndex = 6;
            rbDelivery.TabStop = true;
            rbDelivery.Text = "Giao hàng";
            rbDelivery.UseVisualStyleBackColor = true;
            rbDelivery.CheckedChanged += rbDelivery_CheckedChanged;
            // 
            // gbDeliveryInfo
            // 
            gbDeliveryInfo.Controls.Add(lblCustomerName);
            gbDeliveryInfo.Controls.Add(txtCustomerName);
            gbDeliveryInfo.Controls.Add(lblCustomerPhone);
            gbDeliveryInfo.Controls.Add(txtCustomerPhone);
            gbDeliveryInfo.Controls.Add(lblAddress);
            gbDeliveryInfo.Controls.Add(txtAddress);
            gbDeliveryInfo.Location = new Point(30, 222);
            gbDeliveryInfo.Margin = new Padding(6, 8, 6, 8);
            gbDeliveryInfo.Name = "gbDeliveryInfo";
            gbDeliveryInfo.Padding = new Padding(6, 8, 6, 8);
            gbDeliveryInfo.Size = new Size(610, 231);
            gbDeliveryInfo.TabIndex = 7;
            gbDeliveryInfo.TabStop = false;
            gbDeliveryInfo.Text = "Thông tin giao hàng";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(12, 51);
            lblCustomerName.Margin = new Padding(6, 0, 6, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(169, 30);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "Tên khách hàng:";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(194, 44);
            txtCustomerName.Margin = new Padding(6, 8, 6, 8);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(396, 35);
            txtCustomerName.TabIndex = 1;
            // 
            // lblCustomerPhone
            // 
            lblCustomerPhone.AutoSize = true;
            lblCustomerPhone.Location = new Point(12, 111);
            lblCustomerPhone.Margin = new Padding(6, 0, 6, 0);
            lblCustomerPhone.Name = "lblCustomerPhone";
            lblCustomerPhone.Size = new Size(172, 30);
            lblCustomerPhone.TabIndex = 2;
            lblCustomerPhone.Text = "Số điện thoại:";
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.Location = new Point(194, 104);
            txtCustomerPhone.Margin = new Padding(6, 8, 6, 8);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.Size = new Size(396, 35);
            txtCustomerPhone.TabIndex = 3;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(12, 171);
            lblAddress.Margin = new Padding(6, 0, 6, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(92, 30);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(194, 164);
            txtAddress.Margin = new Padding(6, 8, 6, 8);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(396, 35);
            txtAddress.TabIndex = 5;
            // 
            // lblMenuCategory
            // 
            lblMenuCategory.AutoSize = true;
            lblMenuCategory.Location = new Point(24, 483);
            lblMenuCategory.Margin = new Padding(6, 0, 6, 0);
            lblMenuCategory.Name = "lblMenuCategory";
            lblMenuCategory.Size = new Size(161, 30);
            lblMenuCategory.TabIndex = 8;
            lblMenuCategory.Text = "Phân loại:";
            // 
            // cmbMenuCategory
            // 
            cmbMenuCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMenuCategory.FormattingEnabled = true;
            cmbMenuCategory.Location = new Point(240, 476);
            cmbMenuCategory.Margin = new Padding(6, 8, 6, 8);
            cmbMenuCategory.Name = "cmbMenuCategory";
            cmbMenuCategory.Size = new Size(396, 38);
            cmbMenuCategory.TabIndex = 9;
            // 
            // btnSearchMenu
            // 
            btnSearchMenu.BackColor = Color.RosyBrown;
            btnSearchMenu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearchMenu.ForeColor = Color.White;
            btnSearchMenu.Location = new Point(652, 476);
            btnSearchMenu.Margin = new Padding(6, 8, 6, 8);
            btnSearchMenu.Name = "btnSearchMenu";
            btnSearchMenu.Size = new Size(150, 42);
            btnSearchMenu.TabIndex = 10;
            btnSearchMenu.Text = "Tìm kiếm";
            btnSearchMenu.UseVisualStyleBackColor = false;
            btnSearchMenu.Click += btnSearchMenu_Click;
            // 
            // dgvMenu
            // 
            dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMenu.Columns.AddRange(new DataGridViewColumn[] { colAddToCart });
            dgvMenu.Location = new Point(22, 540);
            dgvMenu.Margin = new Padding(4, 4, 4, 4);
            dgvMenu.Name = "dgvMenu";
            dgvMenu.RowHeadersWidth = 51;
            dgvMenu.Size = new Size(789, 225);
            dgvMenu.TabIndex = 11;
            dgvMenu.CellContentClick += dgvMenu_CellContentClick;
            // 
            // colAddToCart
            // 
            colAddToCart.HeaderText = "Add to Cart";
            colAddToCart.MinimumWidth = 9;
            colAddToCart.Name = "colAddToCart";
            colAddToCart.Text = "Thêm vào giỏ";
            colAddToCart.UseColumnTextForButtonValue = true;
            colAddToCart.Width = 175;
            // 
            // lblSelectedItems
            // 
            lblSelectedItems.AutoSize = true;
            lblSelectedItems.Location = new Point(22, 770);
            lblSelectedItems.Margin = new Padding(4, 0, 4, 0);
            lblSelectedItems.Name = "lblSelectedItems";
            lblSelectedItems.Size = new Size(153, 30);
            lblSelectedItems.TabIndex = 12;
            lblSelectedItems.Text = "Chọn món:";
            // 
            // dgvSelectedItems
            // 
            dgvSelectedItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSelectedItems.Location = new Point(22, 825);
            dgvSelectedItems.Margin = new Padding(4, 4, 4, 4);
            dgvSelectedItems.Name = "dgvSelectedItems";
            dgvSelectedItems.RowHeadersWidth = 51;
            dgvSelectedItems.Size = new Size(789, 150);
            dgvSelectedItems.TabIndex = 13;
            dgvSelectedItems.CellContentClick += dgvSelectedItems_CellContentClick;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(24, 980);
            lblNotes.Margin = new Padding(6, 0, 6, 0);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(73, 30);
            lblNotes.TabIndex = 14;
            lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(20, 1017);
            txtNotes.Margin = new Padding(6, 8, 6, 8);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(676, 82);
            txtNotes.TabIndex = 15;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(20, 1108);
            lblTotalAmount.Margin = new Padding(6, 0, 6, 0);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(143, 30);
            lblTotalAmount.TabIndex = 16;
            lblTotalAmount.Text = "Tổng số lượng:";
            // 
            // lblDeliveryFee
            // 
            lblDeliveryFee.AutoSize = true;
            lblDeliveryFee.Location = new Point(22, 1138);
            lblDeliveryFee.Margin = new Padding(6, 0, 6, 0);
            lblDeliveryFee.Name = "lblDeliveryFee";
            lblDeliveryFee.Size = new Size(130, 30);
            lblDeliveryFee.TabIndex = 17;
            lblDeliveryFee.Text = "Phí giao hàng:";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(22, 1168);
            lblDiscount.Margin = new Padding(6, 0, 6, 0);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(100, 30);
            lblDiscount.TabIndex = 18;
            lblDiscount.Text = "Discount:";
            // 
            // lblFinalAmount
            // 
            lblFinalAmount.AutoSize = true;
            lblFinalAmount.Location = new Point(20, 1198);
            lblFinalAmount.Margin = new Padding(6, 0, 6, 0);
            lblFinalAmount.Name = "lblFinalAmount";
            lblFinalAmount.Size = new Size(142, 30);
            lblFinalAmount.TabIndex = 19;
            lblFinalAmount.Text = "Tổng giá tiền:";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(386, 1239);
            btnBack.Margin = new Padding(6, 8, 6, 8);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(150, 52);
            btnBack.TabIndex = 20;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(548, 1239);
            btnCheckout.Margin = new Padding(6, 8, 6, 8);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(150, 52);
            btnCheckout.TabIndex = 21;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // OrderDelivery
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(824, 1384);
            Controls.Add(btnCheckout);
            Controls.Add(btnBack);
            Controls.Add(lblFinalAmount);
            Controls.Add(lblDiscount);
            Controls.Add(lblDeliveryFee);
            Controls.Add(lblTotalAmount);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(dgvSelectedItems);
            Controls.Add(lblSelectedItems);
            Controls.Add(dgvMenu);
            Controls.Add(btnSearchMenu);
            Controls.Add(cmbMenuCategory);
            Controls.Add(lblMenuCategory);
            Controls.Add(gbDeliveryInfo);
            Controls.Add(rbDelivery);
            Controls.Add(rbPickup);
            Controls.Add(lblDeliveryType);
            Controls.Add(cmbBranchName);
            Controls.Add(lblBranchName);
            Controls.Add(cmbRegionName);
            Controls.Add(lblRegionName);
            Margin = new Padding(6, 8, 6, 8);
            Name = "OrderDelivery";
            Text = "Đặt giao hàng";
            gbDeliveryInfo.ResumeLayout(false);
            gbDeliveryInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}