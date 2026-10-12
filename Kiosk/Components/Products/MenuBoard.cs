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

namespace Kiosk.Components.Products
{
    [DefaultEvent("ItemClicked")]
    public partial class MenuBoard : UserControl
    {
        public event EventHandler<MenuItemData>? ItemClicked;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<MenuItemData> Items { get; set; } = [];

        public MenuBoard()
        {
            InitializeComponent();
        }

        public void CreateMenuItems()
        {

            foreach (MenuItemData item in Items)
            {
                MenuItemControl menuItem =
                    new MenuItemControl
                    {
                        ID = item.ID,
                        Title = item.Title,
                        Price = item.Price,
                        Image = item.Image
                    };

                menuItem.MenuClicked +=
                    MenuItem_MenuClicked;

                flpnl.Controls.Add(menuItem);
            }
        }


        private void MenuItem_MenuClicked(object? sender, IMenuItemControl e)
        {
            MenuItemData? selectedItem = null;

            foreach (MenuItemData item in Items)
            {
                if (item.ID == e.ID)
                {
                    selectedItem = item;
                    break;
                }
            }

            if(selectedItem == null) return;

            ItemClicked?.Invoke(this,selectedItem);
        }

    }
}
