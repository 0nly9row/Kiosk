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
using System.Xml.Linq;

namespace Kiosk.Components.Cart
{
    public partial class ShoppingCartControl : UserControl
    {
        private List<CartItemData> _items = new();

        public event EventHandler? CartChanged;

        public ShoppingCartControl()
        {
            InitializeComponent();
        }

        public int TotalCount => _items.Sum(item => item.Count);
        public decimal TotalPrice => _items.Sum(item => item.SumPrice);

        private void RaiseCartChanged()
        {
            CartChanged?.Invoke(this, EventArgs.Empty);
        }

        public void AddItem(MenuItemData menu)
        {
            CartItemData? existingData =　_items.FirstOrDefault(item => item.ID == menu.ID);

            if (existingData != null)
            {
                existingData.Count++;

                CartItemControl? existingControl =
                    flpnl.Controls.OfType<CartItemControl>()
                    .FirstOrDefault(control => control.Data == existingData);

                existingControl?.RefreshDisplay();
                RaiseCartChanged();
                return;
            }

            CartItemData data = new CartItemData
            {
                ID = menu.ID,
                Title = menu.Title,
                Price = menu.Price,
                Image = menu.Image,
                Count = 1
            };

            CartItemControl control = new CartItemControl();
            control.SetData(data);

            control.CountChanged += CartItemControl_CountChanged;
            control.DeleteClicked += CartItemControl_DeleteClicked;

            _items.Add(data);
            flpnl.Controls.Add(control);

            RaiseCartChanged();
        }

        private void CartItemControl_CountChanged(object? sender, EventArgs e)
        {
            RaiseCartChanged();
        }

        private void CartItemControl_DeleteClicked(object? sender, EventArgs e)
        {
            if (sender is not CartItemControl control || control.Data == null)
                return;

            _items.Remove(control.Data);
            flpnl.Controls.Remove(control);
            control.Dispose();

            RaiseCartChanged();
        }

        public void CancelClear()
        {
            _items.Clear();

            while (flpnl.Controls.Count > 0)
            {
                Control control = flpnl.Controls[0];
                flpnl.Controls.Remove(control);
                control.Dispose();
            }

            RaiseCartChanged();
        }
    }
}
