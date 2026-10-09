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

        public List<MenuItemData> Items { get; set; } = [];

        public MenuBoard()
        {
            InitializeComponent();
            CreateMenuItems();
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

        private void MenuItem_MenuClicked(object? sender,EventArgs e)
        {
            // 전달받은 sender가 MenuItemControl 아니면 return하고, 맞으면 menuItem이라 부르겠다.
            if (sender is not MenuItemControl menuItem) return;

            MenuItemData? selectedItem = null;

            foreach (MenuItemData item in Items)
            {
                if (item.ID == menuItem.ID)
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
