using Kiosk.Components.OrderTotal;
using Kiosk.Models;
using System;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            menuBoard1.CreateMenuItems();
        }

        private void menuBoard1_ItemClicked(object sender, MenuItemData e)
        {
            shoppingCartControl1.AddItem(e);
        }

        private void shoppingCartControl1_CartChanged(object sender, EventArgs e)
        {
            orderTotalControl1.TotalCountView = shoppingCartControl1.TotalCount;
            orderTotalControl1.TotalPriceView = shoppingCartControl1.TotalPrice;
        }

        private void buttonPay1_ButtonClick(object sender, EventArgs e)
        {
            if (shoppingCartControl1.TotalCount == 0)
            {
                MessageBox.Show("상품을 담아주세요!");
                return;
            }
            // 영수증 연결 로직은 이후 구현
        }

        private void buttonClear1_ButtonClick(object sender, EventArgs e)
        {
            shoppingCartControl1.CancelClear();
        }
    }
}