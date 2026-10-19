using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Npgsql;

namespace DataAccessLayer
{
    public class CRUD
    {
        // READ ALL
        public static List<ProductModel> GetAllData()
        {
            const string Query = @"select ""Id"", ""Name"" FROM ""Products"" ORDER BY ""Id""";

            List<ProductModel> products = new List<ProductModel>();

            NpgsqlConnection connection = DBHelper.GetConnection();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand(Query, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ProductModel model = new ProductModel();
                model.Id = Convert.ToInt32(reader["Id"]);
                model.Name = reader["Name"].ToString();

                products.Add(model);
            }
            connection.Close();
            return products;
        }

        // READ BY ID
        public static ProductModel? GetDataById(int id)
        {
            const string Query = @"select ""Id"", ""Name"" FROM ""Products"" WHERE ""Id"" = @Id";

            ProductModel? model = null;

            NpgsqlConnection connection = DBHelper.GetConnection();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Id", id);
            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                model = new ProductModel();
                model.Id = Convert.ToInt32(reader["Id"]);
                model.Name = reader["Name"].ToString();
            }
            connection.Close();
            return model;
        }

        // CREATE
        public static bool InsertData(ProductModel model)
        {
            const string Query = @"INSERT INTO ""Products"" (""Name"") VALUES (@Name)";

            NpgsqlConnection connection = DBHelper.GetConnection();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Name", (object?)model.Name ?? DBNull.Value);

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected > 0;
        }

        // UPDATE
        public static bool UpdateData(ProductModel model)
        {
            const string Query = @"UPDATE ""Products"" SET ""Name"" = @Name WHERE ""Id"" = @Id";

            NpgsqlConnection connection = DBHelper.GetConnection();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Id", model.Id);
            command.Parameters.AddWithValue("@Name", (object?)model.Name ?? DBNull.Value);

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected > 0;
        }

        // DELETE
        public static bool DeleteData(int id)
        {
            const string Query = @"DELETE FROM ""Products"" WHERE ""Id"" = @Id";

            NpgsqlConnection connection = DBHelper.GetConnection();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Id", id);

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected > 0;
        }
    }
}