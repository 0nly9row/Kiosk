using Kiosk.Components.Receipt;
using Kiosk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class ReceiptForm : Form
    {
        private readonly ReceiptData _receiptData;

        public ReceiptForm(ReceiptData receiptData)
        {
            InitializeComponent();

            _receiptData = receiptData;
            Load += ReceiptForm_Load;
        }

        private void ReceiptForm_Load(object? sender, EventArgs e)
        {
            TopText();
            MiddleText();
            BottomText();
        }

        private void TopText()
        {
            lblStoreName.Text = _receiptData.StoreName;
            lblDescription.Text = _receiptData.StoreDescription;
            lblOrderNumber.Text = $"주문번호: {_receiptData.OrderNumber}";
            lblOrderTime.Text = $"주문시간: {_receiptData.OrderTime:yyyy-MM-dd HH:mm:ss}";
        }

        private void MiddleText()
        {
            flpnl.Controls.Clear();

            foreach (ReceiptItemData item in _receiptData.Items)
            {
                ReceiptItemControl receiptItemControl = new ReceiptItemControl();
                receiptItemControl.SetData(item);
                flpnl.Controls.Add(receiptItemControl);
            }
        }

        private void BottomText()
        {
            lblTotalCount.Text = $"총 수량: {_receiptData.TotalCount}개";
            lblTotalPrice.Text = $"총 금액: {_receiptData.TotalPrice:#,##0}원";
        }
    }
}
