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
            txtCardID = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrderSummary).BeginInit();
            SuspendLayout();
            // 
            // lblOrderSummary
            // 
            lblOrderSummary.AutoSize = true;
            lblOrderSummary.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderSummary.ForeColor = Color.IndianRed;
            lblOrderSummary.Location = new Point(12, 9);
            lblOrderSummary.Name = "lblOrderSummary";
            lblOrderSummary.Size = new Size(130, 20);
            lblOrderSummary.TabIndex = 0;
            lblOrderSummary.Text = "Tóm tắt đơn hàng";
            // 
            // dgvOrderSummary
            // 
            dgvOrderSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderSummary.Columns.AddRange(new DataGridViewColumn[] { colItemName, colQuantity, colTotalAmount });
            dgvOrderSummary.Location = new Point(12, 32);
            dgvOrderSummary.Name = "dgvOrderSummary";
            dgvOrderSummary.RowHeadersWidth = 51;
            dgvOrderSummary.Size = new Size(366, 150);
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
            lblCustomerDetails.Location = new Point(9, 195);
            lblCustomerDetails.Name = "lblCustomerDetails";
            lblCustomerDetails.Size = new Size(159, 20);
            lblCustomerDetails.TabIndex = 2;
            lblCustomerDetails.Text = "Thông tin khách hàng";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(12, 222);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(57, 20);
            lblCustomerName.TabIndex = 3;
            lblCustomerName.Text = "Họ tên:";
            // 
            // txtCustomerName
            // 
            txtCustomerName.BackColor = Color.White;
            txtCustomerName.Location = new Point(137, 219);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(250, 27);
            txtCustomerName.TabIndex = 4;
            // 
            // lblCustomerPhone
            // 
            lblCustomerPhone.AutoSize = true;
            lblCustomerPhone.Location = new Point(12, 255);
            lblCustomerPhone.Name = "lblCustomerPhone";
            lblCustomerPhone.Size = new Size(100, 20);
            lblCustomerPhone.TabIndex = 5;
            lblCustomerPhone.Text = "Số điện thoại:";
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.BackColor = Color.White;
            txtCustomerPhone.Location = new Point(137, 253);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.Size = new Size(250, 27);
            txtCustomerPhone.TabIndex = 6;
            // 
            // lblDeliveryAddress
            // 
            lblDeliveryAddress.AutoSize = true;
            lblDeliveryAddress.Location = new Point(12, 289);
            lblDeliveryAddress.Name = "lblDeliveryAddress";
            lblDeliveryAddress.Size = new Size(129, 20);
            lblDeliveryAddress.TabIndex = 7;
            lblDeliveryAddress.Text = "Địa chỉ giao hàng:";
            // 
            // txtDeliveryAddress
            // 
            txtDeliveryAddress.BackColor = Color.White;
            txtDeliveryAddress.Location = new Point(137, 285);
            txtDeliveryAddress.Name = "txtDeliveryAddress";
            txtDeliveryAddress.Size = new Size(250, 27);
            txtDeliveryAddress.TabIndex = 8;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Location = new Point(12, 321);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(119, 20);
            lblPaymentMethod.TabIndex = 9;
            lblPaymentMethod.Text = "Cách thanh toán:";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.BackColor = Color.White;
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "MOMO", "Bank Transfer" });
            cmbPaymentMethod.Location = new Point(137, 318);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(250, 28);
            cmbPaymentMethod.TabIndex = 10;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.RosyBrown;
            btnConfirm.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(9, 394);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
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
            btnBack.Location = new Point(293, 394);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 12;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(9, 435);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(94, 20);
            lblTotalAmount.TabIndex = 13;
            lblTotalAmount.Text = "Tổng số tiền:";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(12, 468);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(70, 20);
            lblDiscount.TabIndex = 15;
            lblDiscount.Text = "Discount:";
            // 
            // lblFinalAmount
            // 
            lblFinalAmount.AutoSize = true;
            lblFinalAmount.Location = new Point(9, 501);
            lblFinalAmount.Name = "lblFinalAmount";
            lblFinalAmount.Size = new Size(113, 20);
            lblFinalAmount.TabIndex = 17;
            lblFinalAmount.Text = "Số tiền phải trả:";
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.BackColor = Color.White;
            txtTotalAmount.Location = new Point(128, 432);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.ReadOnly = true;
            txtTotalAmount.Size = new Size(250, 27);
            txtTotalAmount.TabIndex = 14;
            // 
            // txtDiscount
            // 
            txtDiscount.BackColor = Color.White;
            txtDiscount.Location = new Point(128, 465);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(250, 27);
            txtDiscount.TabIndex = 16;
            txtDiscount.TextChanged += txtDiscount_TextChanged;
            // 
            // txtFinalAmount
            // 
            txtFinalAmount.BackColor = Color.White;
            txtFinalAmount.Location = new Point(128, 498);
            txtFinalAmount.Name = "txtFinalAmount";
            txtFinalAmount.ReadOnly = true;
            txtFinalAmount.Size = new Size(250, 27);
            txtFinalAmount.TabIndex = 18;
            // 
            // txtCardID
            // 
            txtCardID.BackColor = Color.White;
            txtCardID.Location = new Point(137, 352);
            txtCardID.Name = "txtCardID";
            txtCardID.ReadOnly = true;
            txtCardID.Size = new Size(250, 27);
            txtCardID.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 355);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 20;
            label1.Text = "Số thẻ :";
            // 
            // Checkout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(405, 556);
            Controls.Add(label1);
            Controls.Add(txtCardID);
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
            Name = "Checkout";
            Text = "Checkout";
            ((System.ComponentModel.ISupportInitialize)dgvOrderSummary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtCardID;
        private Label label1;
    }
}
