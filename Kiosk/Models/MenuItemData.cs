using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.Models
{
    public class MenuItemData
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public Image? Image { get; set; }
    }
}
