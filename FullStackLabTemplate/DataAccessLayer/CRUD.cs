using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Npgsql;

namespace DataAccessLayer
{
    public class CRUD
    {
        public static List<ProductModel> GetAllData()
        {
            const string Query = @"select ""Id"", ""Name"" FROM ""Products""";

            List<ProductModel> products = new List<ProductModel>();

            NpgsqlConnection connection = DBHelper.GetConnection();
            connection .Open();

            NpgsqlCommand command = new NpgsqlCommand(Query, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) { 
            ProductModel model = new ProductModel();
                model.Id = Convert.ToInt32(reader["Id"]);
                model.Name = reader["Name"].ToString();
              
                products.Add(model);

            }
            connection.Close();
            return products;
        }
    }
}
