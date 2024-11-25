using Microsoft.Data.SqlClient;

namespace ADOConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=MATT\\MSSQLSERVER01;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductID, ProductName, UnitPrice FROM Products";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("ProductID\tProductName\t\tUnitPrice");

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["ProductID"]}\t{reader["ProductName"]}\t{reader["UnitPrice"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
