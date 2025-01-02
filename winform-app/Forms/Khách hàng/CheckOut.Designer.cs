namespace winform_app.Forms.Khách_hàng
{
    partial class Checkout
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblOrderSummary;
        private System.Windows.Forms.DataGridView dgvOrderSummary;
        private System.Windows.Forms.Label lblCustomerDetails;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label lblDeliveryAddress;
        private System.Windows.Forms.TextBox txtDeliveryAddress;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblFinalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtFinalAmount;

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
            lblOrderSummary = new Label();
            dgvOrderSummary = new DataGridView();
            colItemName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colTotalAmount = new DataGridViewTextBoxColumn();
            lblCustomerDetails = new Label();
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            lblCustomerPhone = new Label();
            txtCustomerPhone = new TextBox();
            lblDeliveryAddress = new Label();
            txtDeliveryAddress = new TextBox();
            lblPaymentMethod = new Label();
            cmbPaymentMethod = new ComboBox();
            btnConfirm = new Button();
            btnBack = new Button();
            lblTotalAmount = new Label();
            lblDiscount = new Label();
            lblFinalAmount = new Label();
            txtTotalAmount = new TextBox();
            txtDiscount = new TextBox();
            txtFinalAmount = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvOrderSummary).BeginInit();
            SuspendLayout();
            // 
            // lblOrderSummary
            // 
            lblOrderSummary.AutoSize = true;
            lblOrderSummary.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderSummary.ForeColor = Color.IndianRed;
            lblOrderSummary.Location = new Point(18, 14);
            lblOrderSummary.Margin = new Padding(4, 0, 4, 0);
            lblOrderSummary.Name = "lblOrderSummary";
            lblOrderSummary.Size = new Size(186, 30);
            lblOrderSummary.TabIndex = 0;
            lblOrderSummary.Text = "Tóm tắt đơn hàng";
            // 
            // dgvOrderSummary
            // 
            dgvOrderSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderSummary.Columns.AddRange(new DataGridViewColumn[] { colItemName, colQuantity, colTotalAmount });
            dgvOrderSummary.Location = new Point(18, 48);
            dgvOrderSummary.Margin = new Padding(4);
            dgvOrderSummary.Name = "dgvOrderSummary";
            dgvOrderSummary.RowHeadersWidth = 51;
            dgvOrderSummary.RowTemplate.Height = 29;
            dgvOrderSummary.Size = new Size(549, 225);
            dgvOrderSummary.TabIndex = 1;
            dgvOrderSummary.CellContentClick += dgvOrderSummary_CellContentClick;
            // 
            // colItemName
            // 
            colItemName.DataPropertyName = "ItemName";
            colItemName.HeaderText = "Item Name";
            colItemName.MinimumWidth = 6;
            colItemName.Name = "colItemName";
            colItemName.Width = 250;
            // 
            // colQuantity
            // 
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Quantity";
            colQuantity.MinimumWidth = 6;
            colQuantity.Name = "colQuantity";
            colQuantity.Width = 125;
            // 
            // colTotalAmount
            // 
            colTotalAmount.DataPropertyName = "TotalAmount";
            colTotalAmount.HeaderText = "Total Amount";
            colTotalAmount.MinimumWidth = 6;
            colTotalAmount.Name = "colTotalAmount";
            colTotalAmount.Width = 125;
            // 
            // lblCustomerDetails
            // 
            lblCustomerDetails.AutoSize = true;
            lblCustomerDetails.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerDetails.ForeColor = Color.IndianRed;
            lblCustomerDetails.Location = new Point(13, 292);
            lblCustomerDetails.Margin = new Padding(4, 0, 4, 0);
            lblCustomerDetails.Name = "lblCustomerDetails";
            lblCustomerDetails.Size = new Size(222, 30);
            lblCustomerDetails.TabIndex = 2;
            lblCustomerDetails.Text = "Thông tin khách hàng";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(18, 333);
            lblCustomerName.Margin = new Padding(4, 0, 4, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(81, 30);
            lblCustomerName.TabIndex = 3;
            lblCustomerName.Text = "Họ tên:";
            // 
            // txtCustomerName
            // 
            txtCustomerName.BackColor = Color.White;
            txtCustomerName.Location = new Point(206, 329);
            txtCustomerName.Margin = new Padding(4);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(373, 35);
            txtCustomerName.TabIndex = 4;
            // 
            // lblCustomerPhone
            // 
            lblCustomerPhone.AutoSize = true;
            lblCustomerPhone.Location = new Point(18, 383);
            lblCustomerPhone.Margin = new Padding(4, 0, 4, 0);
            lblCustomerPhone.Name = "lblCustomerPhone";
            lblCustomerPhone.Size = new Size(140, 30);
            lblCustomerPhone.TabIndex = 5;
            lblCustomerPhone.Text = "Số điện thoại:";
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.BackColor = Color.White;
            txtCustomerPhone.Location = new Point(206, 379);
            txtCustomerPhone.Margin = new Padding(4);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.Size = new Size(373, 35);
            txtCustomerPhone.TabIndex = 6;
            // 
            // lblDeliveryAddress
            // 
            lblDeliveryAddress.AutoSize = true;
            lblDeliveryAddress.Location = new Point(18, 433);
            lblDeliveryAddress.Margin = new Padding(4, 0, 4, 0);
            lblDeliveryAddress.Name = "lblDeliveryAddress";
            lblDeliveryAddress.Size = new Size(181, 30);
            lblDeliveryAddress.TabIndex = 7;
            lblDeliveryAddress.Text = "Địa chỉ giao hàng:";
            // 
            // txtDeliveryAddress
            // 
            txtDeliveryAddress.BackColor = Color.White;
            txtDeliveryAddress.Location = new Point(206, 428);
            txtDeliveryAddress.Margin = new Padding(4);
            txtDeliveryAddress.Name = "txtDeliveryAddress";
            txtDeliveryAddress.Size = new Size(373, 35);
            txtDeliveryAddress.TabIndex = 8;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Location = new Point(18, 482);
            lblPaymentMethod.Margin = new Padding(4, 0, 4, 0);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(172, 30);
            lblPaymentMethod.TabIndex = 9;
            lblPaymentMethod.Text = "Cách thanh toán:";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.BackColor = Color.White;
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "MOMO", "Bank Transfer" }); 
            cmbPaymentMethod.Location = new Point(206, 477);
            cmbPaymentMethod.Margin = new Padding(4);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(373, 38);
            cmbPaymentMethod.TabIndex = 10;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.RosyBrown;
            btnConfirm.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(18, 532);
            btnConfirm.Margin = new Padding(4);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(141, 44);
            btnConfirm.TabIndex = 11;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.RosyBrown;
            btnBack.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(440, 532);
            btnBack.Margin = new Padding(4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(141, 44);
            btnBack.TabIndex = 12;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(18, 585);
            lblTotalAmount.Margin = new Padding(4, 0, 4, 0);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(133, 30);
            lblTotalAmount.TabIndex = 13;
            lblTotalAmount.Text = "Tổng số tiền:";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(18, 634);
            lblDiscount.Margin = new Padding(4, 0, 4, 0);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(100, 30);
            lblDiscount.TabIndex = 15;
            lblDiscount.Text = "Discount:";
            // 
            // lblFinalAmount
            // 
            lblFinalAmount.AutoSize = true;
            lblFinalAmount.Location = new Point(18, 684);
            lblFinalAmount.Margin = new Padding(4, 0, 4, 0);
            lblFinalAmount.Name = "lblFinalAmount";
            lblFinalAmount.Size = new Size(159, 30);
            lblFinalAmount.TabIndex = 17;
            lblFinalAmount.Text = "Số tiền phải trả:";
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.BackColor = Color.White;
            txtTotalAmount.Location = new Point(206, 580);
            txtTotalAmount.Margin = new Padding(4);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.ReadOnly = true;
            txtTotalAmount.Size = new Size(373, 35);
            txtTotalAmount.TabIndex = 14;
            // 
            // txtDiscount
            // 
            txtDiscount.BackColor = Color.White;
            txtDiscount.Location = new Point(206, 630);
            txtDiscount.Margin = new Padding(4);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(373, 35);
            txtDiscount.TabIndex = 16;
            txtDiscount.TextChanged += txtDiscount_TextChanged;
            // 
            // txtFinalAmount
            // 
            txtFinalAmount.BackColor = Color.White;
            txtFinalAmount.Location = new Point(206, 680);
            txtFinalAmount.Margin = new Padding(4);
            txtFinalAmount.Name = "txtFinalAmount";
            txtFinalAmount.ReadOnly = true;
            txtFinalAmount.Size = new Size(373, 35);
            txtFinalAmount.TabIndex = 18;
            // 
            // Checkout
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(607, 750);
            Controls.Add(txtFinalAmount);
            Controls.Add(lblFinalAmount);
            Controls.Add(txtDiscount);
            Controls.Add(lblDiscount);
            Controls.Add(txtTotalAmount);
            Controls.Add(lblTotalAmount);
            Controls.Add(btnBack);
            Controls.Add(btnConfirm);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(lblPaymentMethod);
            Controls.Add(txtDeliveryAddress);
            Controls.Add(lblDeliveryAddress);
            Controls.Add(txtCustomerPhone);
            Controls.Add(lblCustomerPhone);
            Controls.Add(txtCustomerName);
            Controls.Add(lblCustomerName);
            Controls.Add(lblCustomerDetails);
            Controls.Add(dgvOrderSummary);
            Controls.Add(lblOrderSummary);
            Margin = new Padding(4);
            Name = "Checkout";
            Text = "Checkout";
            ((System.ComponentModel.ISupportInitialize)dgvOrderSummary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
