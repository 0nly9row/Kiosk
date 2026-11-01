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

namespace Kiosk.Components.Receipt
{
    public partial class ReceiptItemControl : UserControl
    {
        public ReceiptItemControl()
        {
            InitializeComponent();
        }

        public void SetData(ReceiptItemData receiptItemData)
        {
            lblTitle.Text = receiptItemData.Title;
            lblCount.Text = $"{receiptItemData.Count}개";
            lblSumPrice.Text = $"{receiptItemData.SumPrice:#,##0}원";
        }
    }
}
