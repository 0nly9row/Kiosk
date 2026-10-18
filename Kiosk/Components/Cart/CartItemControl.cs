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

namespace Kiosk.Components.Cart
{
    public partial class CartItemControl : UserControl
    {
        private CartItemData? _data;

        public event EventHandler? CountChanged;
        public event EventHandler? DeleteClicked;

        public CartItemControl()
        {
            InitializeComponent();

        }

        public CartItemData? Data => _data;

        public void SetData(CartItemData data)
        {
            _data = data;
            RefreshDisplay();
        }

        public void RefreshDisplay()
        {
            if (_data == null) return;

            picBox.Image = _data.Image;
            lblTitle.Text = _data.Title;
            lblCount.Text = _data.Count.ToString();
            lblSumPrice.Text = $"{_data.SumPrice:#,##0}원";
        }

        private void btnUP_Click(object? sender, EventArgs e)
        {
            if (_data == null) return;

            _data.Count++;
            RefreshDisplay();
            CountChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btnDown_Click(object? sender, EventArgs e)
        {
            if (_data == null || _data.Count <= 1) return;

            _data.Count--;
            RefreshDisplay();
            CountChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btnDel_Click(object? sender, EventArgs e)
        {
            if (_data == null) return;

            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
