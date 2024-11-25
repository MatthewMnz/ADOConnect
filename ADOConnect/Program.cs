using Microsoft.Data.SqlClient;
using System.Data;

namespace ADOConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=MATT\\MSSQLSERVER01;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True";

            DataSet dataSet = new DataSet();

            string Query = "sELECT * FROM Products;SELECT * FROM CAtegories";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(Query, connection);

                adapter.Fill(dataSet);

                DataTable productsTable = dataSet.Tables[0];
                DataTable categoriesTable = dataSet.Tables[1];

                foreach (DataRow row in productsTable.Rows)
                {
                    Console.WriteLine($"ID: {row["ProductID"]}, Nombre: {row["ProductName"]}");
                }
            }
        }
    }
}
