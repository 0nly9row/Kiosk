namespace Kiosk.Components.Cart
{
    partial class CartItemControl
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
            picBox = new PictureBox();
            lblTitle = new Label();
            btnDown = new Button();
            btnDel = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblCount = new Label();
            btnUp = new Button();
            lblSumPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // picBox
            // 
            picBox.Location = new Point(3, 3);
            picBox.Name = "picBox";
            picBox.Size = new Size(85, 89);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.TabIndex = 0;
            picBox.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(94, 3);
            lblTitle.Margin = new Padding(3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(75, 86);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "lblTitle";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDown
            // 
            btnDown.Location = new Point(175, 3);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(88, 85);
            btnDown.TabIndex = 3;
            btnDown.Text = "<";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(561, 3);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(88, 85);
            btnDel.TabIndex = 6;
            btnDel.Text = "X";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(picBox);
            flowLayoutPanel1.Controls.Add(lblTitle);
            flowLayoutPanel1.Controls.Add(btnDown);
            flowLayoutPanel1.Controls.Add(lblCount);
            flowLayoutPanel1.Controls.Add(btnUp);
            flowLayoutPanel1.Controls.Add(lblSumPrice);
            flowLayoutPanel1.Controls.Add(btnDel);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(656, 91);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.WrapContents = false;
            // 
            // lblCount
            // 
            lblCount.Location = new Point(269, 3);
            lblCount.Margin = new Padding(3);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(75, 86);
            lblCount.TabIndex = 4;
            lblCount.Text = "lblCount";
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnUp
            // 
            btnUp.Location = new Point(350, 3);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(88, 85);
            btnUp.TabIndex = 5;
            btnUp.Text = ">";
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUP_Click;
            // 
            // lblSumPrice
            // 
            lblSumPrice.Location = new Point(444, 3);
            lblSumPrice.Margin = new Padding(3);
            lblSumPrice.Name = "lblSumPrice";
            lblSumPrice.Size = new Size(111, 86);
            lblSumPrice.TabIndex = 6;
            lblSumPrice.Text = "lblSumPrice";
            lblSumPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CartItemControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel1);
            Name = "CartItemControl";
            Size = new Size(656, 91);
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picBox;
        private Label lblTitle;
        private Button btnDown;
        private Button button2;
        private Button btnDel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblCount;
        private Button btnUp;
        private Label lblSumPrice;
    }
}
