using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiosk.Models;
using Microsoft.Data.SqlClient;

namespace Kiosk.Database
{
    public class MenuRepository
    {
        private readonly string connectionString =
            "Server=localhost;" +
            "Database=KioskDB;" +
            "Integrated Security=True;" +
            "Encrypt=True;" +
            "TrustServerCertificate=True;";

        public List<MenuItemData> GetMenuItems()
        {
            List<MenuItemData> items =
                new List<MenuItemData>();

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
