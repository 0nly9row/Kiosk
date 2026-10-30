using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.Models
{
    public class ReceiptItemData
    {
        public string Title { get; set; } = "";
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal SumPrice { get; set; }
    }
}
