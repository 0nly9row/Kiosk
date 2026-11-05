namespace Kiosk
{
    partial class ReceiptForm
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
            lblStoreName = new Label();
            lblDescription = new Label();
            lblOrderNumber = new Label();
            lblOrderTime = new Label();
            lblTotalPrice = new Label();
            lblTotalCount = new Label();
            flpnl = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblStoreName
            // 
            lblStoreName.Location = new Point(20, 17);
            lblStoreName.Name = "lblStoreName";
            lblStoreName.Size = new Size(440, 34);
            lblStoreName.TabIndex = 0;
            lblStoreName.Text = "lblStoreName";
            lblStoreName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(20, 56);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(440, 34);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "lblDescription";
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOrderNumber
            // 
            lblOrderNumber.Location = new Point(20, 100);
            lblOrderNumber.Name = "lblOrderNumber";
            lblOrderNumber.Size = new Size(440, 34);
            lblOrderNumber.TabIndex = 2;
            lblOrderNumber.Text = "lblOrderNumber";
            lblOrderNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOrderTime
            // 
            lblOrderTime.Location = new Point(20, 130);
            lblOrderTime.Name = "lblOrderTime";
            lblOrderTime.Size = new Size(440, 34);
            lblOrderTime.TabIndex = 3;
            lblOrderTime.Text = "lblOrderTime";
            lblOrderTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.Location = new Point(20, 550);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(440, 34);
            lblTotalPrice.TabIndex = 4;
            lblTotalPrice.Text = "lblTotalPrice";
            lblTotalPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalCount
            // 
            lblTotalCount.Location = new Point(20, 515);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(440, 34);
            lblTotalCount.TabIndex = 5;
            lblTotalCount.Text = "lblTotalCount";
            lblTotalCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flpnl
            // 
            flpnl.AutoScroll = true;
            flpnl.FlowDirection = FlowDirection.TopDown;
            flpnl.Location = new Point(20, 180);
            flpnl.Name = "flpnl";
            flpnl.Size = new Size(440, 305);
            flpnl.TabIndex = 6;
            flpnl.WrapContents = false;
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(479, 790);
            Controls.Add(flpnl);
            Controls.Add(lblTotalCount);
            Controls.Add(lblTotalPrice);
            Controls.Add(lblOrderTime);
            Controls.Add(lblOrderNumber);
            Controls.Add(lblDescription);
            Controls.Add(lblStoreName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReceiptForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ReceiptForm";
            ResumeLayout(false);
        }

        #endregion

        private Label lblStoreName;
        private Label lblDescription;
        private Label lblOrderNumber;
        private Label lblOrderTime;
        private Label lblTotalPrice;
        private Label lblTotalCount;
        private FlowLayoutPanel flpnl;
    }
}