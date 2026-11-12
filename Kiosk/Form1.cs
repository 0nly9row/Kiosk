using Kiosk.Components.OrderTotal;
using Kiosk.Models;
using System;
using System.Windows.Forms;
using Kiosk.Database;
using Microsoft.Data.SqlClient;

namespace Kiosk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //menuBoard1.CreateMenuItems();

            try
            {
                List<MenuItemData> dbItems =
                    GetMenuItemsFromDatabase();

                List<MenuItemData> designItems =
                    menuBoard1.Items;

                foreach (MenuItemData dbItem in dbItems)
                {
                    foreach (MenuItemData designItem
                        in designItems)
                    {
                        if (dbItem.Title == designItem.Title)
                        {
                            dbItem.Image = designItem.Image;
                            break;
                        }
                    }
                }

                menuBoard1.Items = dbItems;
                menuBoard1.CreateMenuItems();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "메뉴 조회 실패: " + ex.Message);
            }


        }

        private void menuBoard1_ItemClicked(object sender, MenuItemData e)
        {
            shoppingCartControl1.AddItem(e);
        }

        private void shoppingCartControl1_CartChanged(object sender, EventArgs e)
        {
            orderTotalControl1.TotalCountView = shoppingCartControl1.TotalCount;
            orderTotalControl1.TotalPriceView = shoppingCartControl1.TotalPrice;
        }

        private void buttonPay1_ButtonClick(object sender, EventArgs e)
        {
            if (shoppingCartControl1.TotalCount == 0)
            {
                MessageBox.Show("상품을 담아주세요!");
                return;
            }

            ShowReceipt();
        }

        private void buttonClear1_ButtonClick(object sender, EventArgs e)
        {
            shoppingCartControl1.CancelClear();
        }

        private void ShowReceipt()
        {
            List<ReceiptItemData> receiptItems =
                shoppingCartControl1.ReceiptItems();

            DateTime orderTime = DateTime.Now;

            ReceiptData receiptData = new ReceiptData
            {
                StoreName = "먼지덩이",
                StoreDescription = "스티커 가게 임니다.",
                OrderNumber =
                    orderTime.ToString("yyyyMMddHHmmss"),

                OrderTime = orderTime,
                Items = receiptItems,

                TotalCount =
                    receiptItems.Sum(item => item.Count),

                TotalPrice =
                    receiptItems.Sum(item => item.SumPrice)
            };

            ReceiptForm receiptForm = new ReceiptForm(receiptData);
            receiptForm.ShowDialog(this);
            receiptForm.Dispose();
            
            shoppingCartControl1.CancelClear();
        }

        private List<MenuItemData> GetMenuItemsFromDatabase()
        {
            List<MenuItemData> items =
                new List<MenuItemData>();

            string connectionString =
                "Server=localhost;" +
                "Database=KioskDB;" +
                "Integrated Security=True;" +
                "Encrypt=True;" +
                "TrustServerCertificate=True;";

            string sql =
                "SELECT MenuId, MenuName, Price " +
                "FROM dbo.Menu;";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command =
                    new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MenuItemData item =
                                new MenuItemData();

                            item.ID = reader.GetInt32(0);
                            item.Title = reader.GetString(1);
                            item.Price = reader.GetDecimal(2);

                            items.Add(item);
                        }
                    }
                }
            }

            return items;
        }


    }
}