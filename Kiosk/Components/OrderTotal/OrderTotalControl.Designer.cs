using Kiosk.Components.Common;

namespace Kiosk.Components.OrderTotal
{
    partial class OrderTotalControl
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTotalPrice = new Label();
            label3 = new Label();
            lblTotalCount = new Label();
            label1 = new Label();
            roundedPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // roundedPanel1
            // 
            roundedPanel1.Controls.Add(tableLayoutPanel1);
            roundedPanel1.Dock = DockStyle.Fill;
            roundedPanel1.Location = new Point(0, 0);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Padding = new Padding(20);
            roundedPanel1.Size = new Size(369, 276);
            roundedPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblTotalPrice, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(lblTotalCount, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(20, 20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(329, 236);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.Dock = DockStyle.Fill;
            lblTotalPrice.Font = new Font("맑은 고딕", 14F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTotalPrice.Location = new Point(167, 118);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(159, 118);
            lblTotalPrice.TabIndex = 3;
            lblTotalPrice.Text = "lblTotalPrice";
            lblTotalPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("맑은 고딕", 14F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label3.Location = new Point(3, 118);
            label3.Name = "label3";
            label3.Size = new Size(158, 118);
            label3.TabIndex = 2;
            label3.Text = "총 합계";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalCount
            // 
            lblTotalCount.Dock = DockStyle.Fill;
            lblTotalCount.Font = new Font("맑은 고딕", 14F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTotalCount.Location = new Point(167, 0);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(159, 118);
            lblTotalCount.TabIndex = 1;
            lblTotalCount.Text = "lblTotalCount";
            lblTotalCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("맑은 고딕", 14F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(158, 118);
            label1.TabIndex = 0;
            label1.Text = "총량";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // OrderTotalControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundedPanel1);
            Name = "OrderTotalControl";
            Size = new Size(369, 276);
            roundedPanel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel roundedPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label lblTotalPrice;
        private Label label3;
        private Label lblTotalCount;
    }
}
