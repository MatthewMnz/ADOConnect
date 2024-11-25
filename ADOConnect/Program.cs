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
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexion Exitosa");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
