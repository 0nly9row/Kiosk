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

        // 영수증용 상품 데이터 추출 구현
        public List<ReceiptItemData> ReceiptItems()
        {
            List<ReceiptItemData> receiptItemDatas = new List<ReceiptItemData>();
            foreach (var item in _items) 
            {
                ReceiptItemData receiptItemData = new ReceiptItemData
                {
                    Title = item.Title,
                    Count = item.Count,
                    Price = item.Price,
                    SumPrice = item.SumPrice,
                };

                receiptItemDatas.Add(receiptItemData);
            }

            return receiptItemDatas;
        }

        /// <summary>
        /// 장바구니의 상품 ID와 수량을
        /// DB 주문 저장 요청용 데이터로 변환한다.
        /// </summary>
        public List<OrderItemRequest> GetOrderItems()
        {
            List<OrderItemRequest> result = new();

            foreach (CartItemData item in _items)
            {
                result.Add(new OrderItemRequest
                {
                    MenuId = item.ID,
                    Quantity = item.Count
                });
            }
            return result;
        }
    }
}
