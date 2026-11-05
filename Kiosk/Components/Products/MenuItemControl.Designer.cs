using Kiosk.Components.Common;

namespace Kiosk.Components.Products
{
    partial class MenuItemControl
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
            roundedPanel1 = new RoundedPanel();
            lblPrice = new Label();
            lblTitle = new Label();
            picBox = new PictureBox();
            roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            SuspendLayout();
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.Transparent;
            roundedPanel1.BorderColor = Color.Gainsboro;
            roundedPanel1.Controls.Add(picBox);
            roundedPanel1.Controls.Add(lblTitle);
            roundedPanel1.Controls.Add(lblPrice);
            roundedPanel1.Dock = DockStyle.Fill;
            roundedPanel1.Location = new Point(0, 0);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Padding = new Padding(20);
            roundedPanel1.Size = new Size(232, 244);
            roundedPanel1.TabIndex = 0;
            // 
            // lblPrice
            // 
            lblPrice.Dock = DockStyle.Bottom;
            lblPrice.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblPrice.Location = new Point(20, 186);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(192, 38);
            lblPrice.TabIndex = 0;
            lblPrice.Text = "lblPrice";
            lblPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Bottom;
            lblTitle.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTitle.Location = new Point(20, 148);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(192, 38);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "lblTitle";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // picBox
            // 
            picBox.Dock = DockStyle.Fill;
            picBox.Location = new Point(20, 20);
            picBox.Name = "picBox";
            picBox.Size = new Size(192, 128);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.TabIndex = 2;
            picBox.TabStop = false;
            // 
            // MenuItemControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundedPanel1);
            Name = "MenuItemControl";
            Size = new Size(232, 244);
            roundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel roundedPanel1;
        private Label lblTitle;
        private Label lblPrice;
        private PictureBox picBox;
    }
}
