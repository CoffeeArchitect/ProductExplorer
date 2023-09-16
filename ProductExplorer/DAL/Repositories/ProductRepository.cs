using ProductExplorer.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System;

namespace ProductExplorer.DAL.Repositories
{
    /// <summary>
    /// Репозиторий для работы с товарами в базе данных SQL Server
    /// </summary>
    public class ProductRepository : IProductRepository<Product>
    {
        string connectionString = ConfigurationManager.ConnectionStrings["СonnectToLocalDb"].ConnectionString;
        /// <summary>
        /// Получить все товары из базы данных
        /// </summary>
        /// <returns>Список товаров</returns>
        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_GetAllProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                Id = (int)reader["Id"],
                                Article = reader["Article"].ToString(),
                                Name = reader["Name"].ToString(),
                                Price = (decimal)reader["Price"],
                                Quantity = (int)reader["Quantity"]
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
        /// <summary>
        /// Получить товар по идентификатору
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Объект типа товара</returns>
        public Product GetById(int productId)
        {
            Product product = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_GetProductById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductId", productId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                Id = (int)reader["Id"],
                                Article = reader["Article"].ToString(),
                                Name = reader["Name"].ToString(),
                                Price = (decimal)reader["Price"],
                                Quantity = (int)reader["Quantity"]
                            };
                        }
                    }
                }
            }

            return product;
        }
        /// <summary>
        /// Добавить товар в базу данных
        /// </summary>
        /// <param name="product"></param>
        public void Add(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("usp_AddProduct", connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@Article", product.Article);
                            command.Parameters.AddWithValue("@Name", product.Name);
                            command.Parameters.AddWithValue("@Price", product.Price);
                            command.Parameters.AddWithValue("@Quantity", product.Quantity);

                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Ошибка добавления товара: " + ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Удалить товар из базы данных
        /// </summary>
        /// <param name="productId"></param>
        public void Delete(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_DeleteProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductId", productId);

                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Обновить товар в базе данных
        /// </summary>
        /// <param name="product"></param>
        public void Update(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_UpdateProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    
                    command.Parameters.AddWithValue("@Article", product.Article);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);

                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Сохранить изменения в базе данных
        /// </summary>
        /// <param name="product"></param>
        public void Save(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_SaveProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductId", product.Id);
                    command.Parameters.AddWithValue("@Article", product.Article);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
