namespace Kiosk.Buttons
{
    partial class ButtonPay
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
            roundedPanel1 = new Kiosk.Components.Common.RoundedPanel();
            lblText = new Label();
            roundedPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // roundedPanel1
            // 
            roundedPanel1.Controls.Add(lblText);
            roundedPanel1.Dock = DockStyle.Fill;
            roundedPanel1.Location = new Point(0, 0);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(150, 150);
            roundedPanel1.TabIndex = 0;
            // 
            // lblText
            // 
            lblText.BackColor = Color.Transparent;
            lblText.Dock = DockStyle.Fill;
            lblText.Font = new Font("맑은 고딕", 16F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblText.Location = new Point(0, 0);
            lblText.Name = "lblText";
            lblText.Size = new Size(150, 150);
            lblText.TabIndex = 0;
            lblText.Text = "결제";
            lblText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ButtonPay
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundedPanel1);
            Name = "ButtonPay";
            roundedPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Components.Common.RoundedPanel roundedPanel1;
        private Label lblText;
    }
}
