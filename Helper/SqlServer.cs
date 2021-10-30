using APICatalogo.Models.Product;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace APICatalogo.Helper
{
    public static class SqlServer
    {
        public static string ConnectionString
        {
            get
            {
                return Startup.StaticConfig.GetConnectionString("DefaultConnection");
            }
        }

        public static ProductModel GetProduct()
        {
            var models = new ProductModel();
            models.products = new List<Product>();


            using (var sqlCnn = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlCnn.Open();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 53)
                        GetProduct();
                }
                using (var sqlCmd = new SqlCommand("SELECT Id, Title, Price FROM [dbo].[APICatalogoGabriel]", sqlCnn))
                {
                    using (var sqlReader = sqlCmd.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            var model = new ProductModel();
                            models.products.Add(new Product((string)sqlReader["Title"], (decimal)sqlReader["Price"], (int)sqlReader["Id"]));
                        }
                    }
                }
            }

            return models;
        }

        public static void InsertProduct(string title, decimal price)
        {
            using (var sqlCnn = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlCnn.Open();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 53)
                        InsertProduct(title, price);
                }
                using (var sqlCmd = new SqlCommand("INSERT INTO [dbo].[APICatalogoGabriel]VALUES(@title, @price)", sqlCnn))
                {
                    sqlCmd.Parameters.AddWithValue("@title", title);
                    sqlCmd.Parameters.AddWithValue("@price", price);

                    try
                    {
                        sqlCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }


        }

        public static void UpdateProduct(string title, decimal price, int IdProduct)
        {
            using (var sqlCnn = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlCnn.Open();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 53)
                        UpdateProduct(title, price, IdProduct);
                }
                using (var sqlCmd = new SqlCommand("UPDATE [dbo].[APICatalogoGabriel] SET Title = @title, Price = @price WHERE Id = @IdProduct", sqlCnn))
                {
                    sqlCmd.Parameters.AddWithValue("@title", title);
                    sqlCmd.Parameters.AddWithValue("@price", price);
                    sqlCmd.Parameters.AddWithValue("@IdProduct", IdProduct);

                    try
                    {
                        sqlCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }


        }

        public static void DeleteProduct(int IdProduct)
        {
            using (var sqlCnn = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlCnn.Open();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 53)
                        DeleteProduct(IdProduct);
                }
                using (var sqlCmd = new SqlCommand("DELETE FROM [dbo].[APICatalogoGabriel] WHERE Id = @IdProduct", sqlCnn))
                {
                    sqlCmd.Parameters.AddWithValue("@IdProduct", IdProduct);

                    try
                    {
                        sqlCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }


        }

    }
}
