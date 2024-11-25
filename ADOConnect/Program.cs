using Microsoft.Data.SqlClient;

namespace ADOConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=MATT\\MSSQLSERVER01;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True";

            string insertQuery = "INSERT INTO Products (ProductName, UnitPrice, UnitsInStock) VALUES (@ProductName, @UnitPrice, @UnitsInStock)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@ProductName", "New Product");
                command.Parameters.AddWithValue("@UnitPrice", 15.00);
                command.Parameters.AddWithValue("@UnitsInStock", 50);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} fila(s) insertada(s)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erorr: {ex.Message}");
                }
            }
        }
    }
}
