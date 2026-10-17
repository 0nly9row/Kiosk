using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.Models
{
    public class CartItemData
    {
        public int ID { get; set; }

        public string Title { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public Image? Image { get; set; }

        private int _count = 1;

        public int Count
        {
            get => _count;
            set
            {
                if (value < 1) return;
                _count = value;
            }
        }

        public decimal SumPrice => Price * Count;
    }
}
