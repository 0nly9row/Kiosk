using Kiosk.Components.Products;
using Kiosk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.Components.Products
{
    public partial class MenuItemControl : UserControl
    {
        public MenuItemControl()
        {
            InitializeComponent();
            AddClickEvent(this);
        }

        private decimal _price;
        public event EventHandler? MenuClicked;

        [Category("MenuItemControl"), Description("상품 ID")]
        public int ID { get; set; }

        [Category("MenuItemControl"), Description("상품명")]
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }

        [Category("MenuItemControl"), Description("상품 사진")]
        public Image? Image { get => picBox.Image; set => picBox.Image = value; }

        [Category("MenuItemControl"), Description("상품 가격")]
        public decimal Price 
        { 
            get => _price;
            set 
            { _price = value;
              SetPrice();
            }
        }

        private void SetPrice()
        {
            lblPrice.Text = $"{_price.ToString("#,###")}원";
        }

        private void AddClickEvent(Control parentControl) 
        {
            foreach (Control control in parentControl.Controls) 
            { 
                control.Click += Control_Click;
                if (control.HasChildren)
                {
                    AddClickEvent(control);
                }
            }
        }

        private void Control_Click(object? sender,EventArgs e)
        {
            MenuClicked?.Invoke(this,EventArgs.Empty);
        }
    }
}


