namespace Kiosk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            menuBoard1.CreateMenuItems();
        }

        private void menuBoard1_ItemClicked(object sender, Kiosk.Models.MenuItemData e)
        {

        }
    }
}
