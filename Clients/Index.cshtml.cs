using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Crud__Asp.net_core_.Pages.Clients
{
    public class IndexModel : PageModel
    {
        // same as array.
        public List<ClientInfo> listClients= new List<ClientInfo>(); 
        public void OnGet()
        {


            try
            {


                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=mystore;Integrated Security=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.address = reader.GetString(4);
                                clientInfo.created_at = reader.GetDateTime(5).ToString();
                                //Console.WriteLine($"ID Got: {clientInfo.id}");
                                listClients.Add(clientInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
    public class ClientInfo {
        public string id = "";
        public string name = "";
        public string email = "";
        public string phone = "";
        public string address = "";
        public string created_at = "";
    }
}
