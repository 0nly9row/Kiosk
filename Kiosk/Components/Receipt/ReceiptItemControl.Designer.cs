namespace Kiosk.Components.Receipt
{
    partial class ReceiptItemControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblCount = new Label();
            lblSumPrice = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoEllipsis = true;
            lblTitle.ImageAlign = ContentAlignment.MiddleLeft;
            lblTitle.Location = new Point(3, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(109, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCount
            // 
            lblCount.Location = new Point(161, 12);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(109, 38);
            lblCount.TabIndex = 1;
            lblCount.Text = "label2";
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSumPrice
            // 
            lblSumPrice.ImageAlign = ContentAlignment.MiddleRight;
            lblSumPrice.Location = new Point(318, 12);
            lblSumPrice.Name = "lblSumPrice";
            lblSumPrice.Size = new Size(109, 38);
            lblSumPrice.TabIndex = 2;
            lblSumPrice.Text = "label3";
            lblSumPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ReceiptItemControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblSumPrice);
            Controls.Add(lblCount);
            Controls.Add(lblTitle);
            Margin = new Padding(0, 2, 0, 2);
            Name = "ReceiptItemControl";
            Size = new Size(430, 63);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblCount;
        private Label lblSumPrice;
    }
}
