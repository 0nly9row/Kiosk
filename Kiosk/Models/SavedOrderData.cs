using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.Models
{
    public class SavedOrderData
    {
        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; }
        public List<ReceiptItemData> Items { get; set; } = new();
    }
}
