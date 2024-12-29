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
            colItemName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colDeliveryAvailable = new DataGridViewCheckBoxColumn();
            colAddToCart = new DataGridViewButtonColumn();
            lblSelectedItems = new Label();
            dgvSelectedItems = new DataGridView();
            colSelectedItemName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colTotalPrice = new DataGridViewTextBoxColumn();
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
            lblRegionName.Location = new Point(16, 23);
            lblRegionName.Margin = new Padding(4, 0, 4, 0);
            lblRegionName.Name = "lblRegionName";
            lblRegionName.Size = new Size(103, 20);
            lblRegionName.TabIndex = 0;
            lblRegionName.Text = "Region Name:";
            // 
            // cmbRegionName
            // 
            cmbRegionName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRegionName.FormattingEnabled = true;
            cmbRegionName.Location = new Point(160, 18);
            cmbRegionName.Margin = new Padding(4, 5, 4, 5);
            cmbRegionName.Name = "cmbRegionName";
            cmbRegionName.Size = new Size(265, 28);
            cmbRegionName.TabIndex = 1;
            cmbRegionName.SelectedIndexChanged += cmbRegionName_SelectedIndexChanged;
            // 
            // lblBranchName
            // 
            lblBranchName.AutoSize = true;
            lblBranchName.Location = new Point(16, 69);
            lblBranchName.Margin = new Padding(4, 0, 4, 0);
            lblBranchName.Name = "lblBranchName";
            lblBranchName.Size = new Size(101, 20);
            lblBranchName.TabIndex = 2;
            lblBranchName.Text = "Branch Name:";
            // 
            // cmbBranchName
            // 
            cmbBranchName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranchName.FormattingEnabled = true;
            cmbBranchName.Location = new Point(160, 65);
            cmbBranchName.Margin = new Padding(4, 5, 4, 5);
            cmbBranchName.Name = "cmbBranchName";
            cmbBranchName.Size = new Size(265, 28);
            cmbBranchName.TabIndex = 3;
            cmbBranchName.SelectedIndexChanged += cmbBranchName_SelectedIndexChanged;
            // 
            // lblDeliveryType
            // 
            lblDeliveryType.AutoSize = true;
            lblDeliveryType.Location = new Point(16, 115);
            lblDeliveryType.Margin = new Padding(4, 0, 4, 0);
            lblDeliveryType.Name = "lblDeliveryType";
            lblDeliveryType.Size = new Size(101, 20);
            lblDeliveryType.TabIndex = 4;
            lblDeliveryType.Text = "Delivery Type:";
            // 
            // rbPickup
            // 
            rbPickup.AutoSize = true;
            rbPickup.Location = new Point(160, 112);
            rbPickup.Margin = new Padding(4, 5, 4, 5);
            rbPickup.Name = "rbPickup";
            rbPickup.Size = new Size(73, 24);
            rbPickup.TabIndex = 5;
            rbPickup.TabStop = true;
            rbPickup.Text = "Pickup";
            rbPickup.UseVisualStyleBackColor = true;
            rbPickup.CheckedChanged += rbPickup_CheckedChanged;
            // 
            // rbDelivery
            // 
            rbDelivery.AutoSize = true;
            rbDelivery.Location = new Point(281, 112);
            rbDelivery.Margin = new Padding(4, 5, 4, 5);
            rbDelivery.Name = "rbDelivery";
            rbDelivery.Size = new Size(84, 24);
            rbDelivery.TabIndex = 6;
            rbDelivery.TabStop = true;
            rbDelivery.Text = "Delivery";
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
            gbDeliveryInfo.Location = new Point(20, 148);
            gbDeliveryInfo.Margin = new Padding(4, 5, 4, 5);
            gbDeliveryInfo.Name = "gbDeliveryInfo";
            gbDeliveryInfo.Padding = new Padding(4, 5, 4, 5);
            gbDeliveryInfo.Size = new Size(407, 154);
            gbDeliveryInfo.TabIndex = 7;
            gbDeliveryInfo.TabStop = false;
            gbDeliveryInfo.Text = "Delivery Info";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(8, 34);
            lblCustomerName.Margin = new Padding(4, 0, 4, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(119, 20);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "Customer Name:";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(129, 29);
            txtCustomerName.Margin = new Padding(4, 5, 4, 5);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(265, 27);
            txtCustomerName.TabIndex = 1;
            // 
            // lblCustomerPhone
            // 
            lblCustomerPhone.AutoSize = true;
            lblCustomerPhone.Location = new Point(8, 74);
            lblCustomerPhone.Margin = new Padding(4, 0, 4, 0);
            lblCustomerPhone.Name = "lblCustomerPhone";
            lblCustomerPhone.Size = new Size(120, 20);
            lblCustomerPhone.TabIndex = 2;
            lblCustomerPhone.Text = "Customer Phone:";
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.Location = new Point(129, 69);
            txtCustomerPhone.Margin = new Padding(4, 5, 4, 5);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.Size = new Size(265, 27);
            txtCustomerPhone.TabIndex = 3;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(8, 114);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(65, 20);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(129, 109);
            txtAddress.Margin = new Padding(4, 5, 4, 5);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(265, 27);
            txtAddress.TabIndex = 5;
            // 
            // lblMenuCategory
            // 
            lblMenuCategory.AutoSize = true;
            lblMenuCategory.Location = new Point(16, 322);
            lblMenuCategory.Margin = new Padding(4, 0, 4, 0);
            lblMenuCategory.Name = "lblMenuCategory";
            lblMenuCategory.Size = new Size(113, 20);
            lblMenuCategory.TabIndex = 8;
            lblMenuCategory.Text = "Menu Category:";
            // 
            // cmbMenuCategory
            // 
            cmbMenuCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMenuCategory.FormattingEnabled = true;
            cmbMenuCategory.Location = new Point(160, 317);
            cmbMenuCategory.Margin = new Padding(4, 5, 4, 5);
            cmbMenuCategory.Name = "cmbMenuCategory";
            cmbMenuCategory.Size = new Size(265, 28);
            cmbMenuCategory.TabIndex = 9;
            // 
            // btnSearchMenu
            // 
            btnSearchMenu.Location = new Point(435, 317);
            btnSearchMenu.Margin = new Padding(4, 5, 4, 5);
            btnSearchMenu.Name = "btnSearchMenu";
            btnSearchMenu.Size = new Size(100, 28);
            btnSearchMenu.TabIndex = 10;
            btnSearchMenu.Text = "Search Menu";
            btnSearchMenu.UseVisualStyleBackColor = true;
            btnSearchMenu.Click += btnSearchMenu_Click;
            // 
            // dgvMenu
            // 
            dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colItemName,
            colPrice,
            colDeliveryAvailable,
            colAddToCart});
            dgvMenu.Location = new Point(15, 360);
            dgvMenu.Name = "dgvMenu";
            dgvMenu.RowHeadersWidth = 51;
            dgvMenu.Size = new Size(550, 150);
            dgvMenu.TabIndex = 11;
            dgvMenu.CellContentClick += dgvMenu_CellContentClick;
            dgvMenu.AutoGenerateColumns = false;
            // 
            // colItemName
            // 
            colItemName.DataPropertyName = "ItemName";
            colItemName.HeaderText = "Item Name";
            colItemName.Name = "colItemName";
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "CurrentPrice";
            colPrice.HeaderText = "Price";
            colPrice.Name = "colPrice";
            // 
            // colDeliveryAvailable
            // 
            colDeliveryAvailable.DataPropertyName = "DeliveryAvailable";
            colDeliveryAvailable.HeaderText = "Delivery Available";
            colDeliveryAvailable.Name = "colDeliveryAvailable";
            // 
            // colAddToCart
            // 
            colAddToCart.HeaderText = "Add to Cart";
            colAddToCart.Name = "colAddToCart";
            colAddToCart.Text = "Add";
            colAddToCart.UseColumnTextForButtonValue = true;
            // 
            // lblSelectedItems
            // 
            lblSelectedItems.AutoSize = true;
            lblSelectedItems.Location = new Point(15, 513);
            lblSelectedItems.Name = "lblSelectedItems";
            lblSelectedItems.Size = new Size(109, 20);
            lblSelectedItems.TabIndex = 12;
            lblSelectedItems.Text = "Selected Items:";
            // 
            // dgvSelectedItems
            // 
            dgvSelectedItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSelectedItems.Location = new Point(15, 550);
            dgvSelectedItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colSelectedItemName,
            colQuantity,
            colTotalPrice});
            dgvSelectedItems.Name = "dgvSelectedItems";
            dgvSelectedItems.RowHeadersWidth = 51;
            dgvSelectedItems.Size = new Size(550, 100);
            dgvSelectedItems.TabIndex = 13;
            dgvSelectedItems.CellContentClick += dgvSelectedItems_CellContentClick;
            dgvSelectedItems.AutoGenerateColumns = false;
            // 
            // colSelectedItemName
            // 
            colSelectedItemName.DataPropertyName = "ItemName";
            colSelectedItemName.HeaderText = "Item Name";
            colSelectedItemName.Name = "colSelectedItemName";
            // 
            // colQuantity
            // 
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Quantity";
            colQuantity.Name = "colQuantity";
            // 
            // colTotalPrice
            // 
            colTotalPrice.DataPropertyName = "TotalPrice";
            colTotalPrice.HeaderText = "Total Price";
            colTotalPrice.Name = "colTotalPrice";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(16, 653);
            lblNotes.Margin = new Padding(4, 0, 4, 0);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(51, 20);
            lblNotes.TabIndex = 14;
            lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(13, 678);
            txtNotes.Margin = new Padding(4, 5, 4, 5);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(452, 56);
            txtNotes.TabIndex = 15;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(13, 739);
            lblTotalAmount.Margin = new Padding(4, 0, 4, 0);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(102, 20);
            lblTotalAmount.TabIndex = 16;
            lblTotalAmount.Text = "Total Amount:";
            // 
            // lblDeliveryFee
            // 
            lblDeliveryFee.AutoSize = true;
            lblDeliveryFee.Location = new Point(15, 759);
            lblDeliveryFee.Margin = new Padding(4, 0, 4, 0);
            lblDeliveryFee.Name = "lblDeliveryFee";
            lblDeliveryFee.Size = new Size(93, 20);
            lblDeliveryFee.TabIndex = 17;
            lblDeliveryFee.Text = "Delivery Fee:";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(15, 779);
            lblDiscount.Margin = new Padding(4, 0, 4, 0);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(70, 20);
            lblDiscount.TabIndex = 18;
            lblDiscount.Text = "Discount:";
            // 
            // lblFinalAmount
            // 
            lblFinalAmount.AutoSize = true;
            lblFinalAmount.Location = new Point(13, 799);
            lblFinalAmount.Margin = new Padding(4, 0, 4, 0);
            lblFinalAmount.Name = "lblFinalAmount";
            lblFinalAmount.Size = new Size(100, 20);
            lblFinalAmount.TabIndex = 19;
            lblFinalAmount.Text = "Final Amount:";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(257, 826);
            btnBack.Margin = new Padding(4, 5, 4, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 35);
            btnBack.TabIndex = 20;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(365, 826);
            btnCheckout.Margin = new Padding(4, 5, 4, 5);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(100, 35);
            btnCheckout.TabIndex = 21;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // OrderDelivery
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 923);
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
            Margin = new Padding(4, 5, 4, 5);
            Name = "OrderDelivery";
            Text = "Order Delivery";
            gbDeliveryInfo.ResumeLayout(false);
            gbDeliveryInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}