namespace winform_app.Forms.Nhân_viên
{
    partial class InputBoxForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelPrompt;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;

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
            labelPrompt = new Label();
            textBoxInput = new TextBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelPrompt
            // 
            labelPrompt.AutoSize = true;
            labelPrompt.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPrompt.ForeColor = Color.IndianRed;
            labelPrompt.Location = new Point(21, 18);
            labelPrompt.Margin = new Padding(5, 0, 5, 0);
            labelPrompt.Name = "labelPrompt";
            labelPrompt.Size = new Size(173, 30);
            labelPrompt.TabIndex = 0;
            labelPrompt.Text = "Nhập Lương cho";
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(21, 54);
            textBoxInput.Margin = new Padding(5, 6, 5, 6);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(567, 35);
            textBoxInput.TabIndex = 1;
            // 
            // buttonOK
            // 
            buttonOK.BackColor = Color.RosyBrown;
            buttonOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonOK.ForeColor = Color.White;
            buttonOK.Location = new Point(320, 112);
            buttonOK.Margin = new Padding(5, 6, 5, 6);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(129, 46);
            buttonOK.TabIndex = 2;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = false;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.RosyBrown;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Location = new Point(459, 112);
            buttonCancel.Margin = new Padding(5, 6, 5, 6);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(129, 46);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // InputBoxForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(613, 182);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(textBoxInput);
            Controls.Add(labelPrompt);
            Margin = new Padding(5, 6, 5, 6);
            Name = "InputBoxForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vui lòng nhập lương";
            Load += InputBoxForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
