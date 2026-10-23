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
    }
}