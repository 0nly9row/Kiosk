using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.Models
{
    public class ReceiptData
    {
        public string StoreName { get; set; } = "";
        public string StoreDescription { get; set; } = "";
        public string OrderNumber { get; set; } = "";
        public DateTime OrderTime { get; set; }

        // 주문한 상품들의 각 항목의 목록
        public List<ReceiptItemData> Items { get; set; } = new();

        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
