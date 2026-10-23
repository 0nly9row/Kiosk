using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.Components.OrderTotal
{
    public partial class OrderTotalControl : UserControl
    {
        public OrderTotalControl()
        {
            InitializeComponent();
            RefreshUI();
        }

        private int _count = 0;
        private decimal _price = 0m;


        public int TotalCountView
        {
            get { return _count; }
            set 
            {
                _count = value;
                RefreshUI();
            }
        }

        public decimal TotalPriceView
        {
            get { return _price; }
            set 
            { 
                _price = value;
                RefreshUI();
            }
        }

        public void RefreshUI()
        {
            lblTotalCount.Text = _count.ToString();
            lblTotalPrice.Text = $"{_price:#,##0}원";
        }
    }
}
