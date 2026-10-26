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
            const string Query = @"SELECT ""Pid"", ""productname"", ""price"" FROM ""products"" ORDER BY ""Pid""";

            List<ProductModel> products = new List<ProductModel>();

            using (NpgsqlConnection connection = DBHelper.GetConnection())
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Query, connection))
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductModel model = new ProductModel();
                        model.Id = Convert.ToInt32(reader["Pid"]);
                        model.Name = reader["productname"].ToString();
                        model.Price = reader["price"] != DBNull.Value ? Convert.ToInt64(reader["price"]) : 0;

                        products.Add(model);
                    }
                }
            }
            return products;
        }

        // READ BY ID
        public static ProductModel? GetDataById(int id)
        {
            const string Query = @"SELECT ""Pid"", ""productname"", ""price"" FROM ""products"" WHERE ""Pid"" = @Id";

            ProductModel? model = null;

            using (NpgsqlConnection connection = DBHelper.GetConnection())
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model = new ProductModel();
                            model.Id = Convert.ToInt32(reader["Pid"]);
                            model.Name = reader["productname"].ToString();
                            model.Price = reader["price"] != DBNull.Value ? Convert.ToInt64(reader["price"]) : 0;
                        }
                    }
                }
            }
            return model;
        }

        // CREATE
        public static bool InsertData(ProductModel model)
        {
            const string Query = @"INSERT INTO ""products"" (""productname"", ""price"") VALUES (@Name, @Price)";

            using (NpgsqlConnection connection = DBHelper.GetConnection())
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Name", (object?)model.Name ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Price", model.Price);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // UPDATE
        public static bool UpdateData(ProductModel model)
        {
            const string Query = @"UPDATE ""products"" SET ""productname"" = @Name, ""price"" = @Price WHERE ""Pid"" = @Id";

            using (NpgsqlConnection connection = DBHelper.GetConnection())
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Id", model.Id);
                    command.Parameters.AddWithValue("@Name", (object?)model.Name ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Price", model.Price);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // DELETE
        public static bool DeleteData(int id)
        {
            const string Query = @"DELETE FROM ""products"" WHERE ""Pid"" = @Id";

            using (NpgsqlConnection connection = DBHelper.GetConnection())
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
