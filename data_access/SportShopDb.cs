﻿using data_access.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access
{
    public class SportShopDb
    {
        //CRUD interface
        //[C]reate
        //[R]ead
        //[U]pdate
        //[D]elete
        private SqlConnection connection;

        public SportShopDb(string connectionstring)
        {
            connection = new SqlConnection(connectionstring);
            connection.Open();
        }
        ~SportShopDb()
        {
            connection.Close();
        }
        public void Create(Product product)
        {
            //string cmdText = $@"INSERT INTO Products
            //                    VALUES ('{product.Name}', 
            //                            '{product.Type}', 
            //                             {product.Quantity}, 
            //                             {product.CostPrice}, 
            //                            '{product.Producer}', 
            //                             {product.Price})";
            string cmdText = $@"INSERT INTO Products
                                VALUES (@name, 
                                        @type, 
                                        @quantity, 
                                        @costPrice, 
                                        @producer, 
                                        @price)";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("name", product.Name);
            command.Parameters.AddWithValue("type", product.Type);
            command.Parameters.AddWithValue("quantity", product.Quantity);
            command.Parameters.AddWithValue("costPrice", product.CostPrice);
            command.Parameters.AddWithValue("producer", product.Producer);
            command.Parameters.AddWithValue("price", product.Price);

            command.CommandTimeout = 5;
            command.ExecuteNonQuery();
        }
        public List<Product> GetAll()
        {
            string cmdText = @"select * from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            return this.GetProductsByQuery(reader);
        }
        public List<Product> GetAllByName(string name)
        {
            //SQL injection :name = 'Ball'; drop database SportShop;--
            //name = "Ball";
            string cmdText = $@"select * from Products where Name = @name";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = name;

            //SqlParameter sql = new SqlParameter()
            //{
            //    ParameterName = "name",
            //    SqlDbType = System.Data.SqlDbType.NVarChar,
            //    Value = name
            //};
            //command.Parameters.Add(sql);

            SqlDataReader reader = command.ExecuteReader();
            return this.GetProductsByQuery(reader);
        }
        private List<Product> GetProductsByQuery(SqlDataReader reader)
        {
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = Convert.ToSingle(reader[4]),
                    Producer = (string)reader[5],
                    Price = Convert.ToSingle(reader[6])
                });
            }
            reader.Close();
            return products;
        }
        public void Update(Product product)
        {
            string cmdText = $@"UPDATE Products
                                SET Name = @name, 
                                    TypeProduct = @type, 
                                    Quantity = @quantity, 
                                    CostPrice = @costPrice, 
                                    Producer = @producer, 
                                    Price = @price
                                where Id = {product.Id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("name", product.Name);
            command.Parameters.AddWithValue("type", product.Type);
            command.Parameters.AddWithValue("quantity", product.Quantity);
            command.Parameters.AddWithValue("costPrice", product.CostPrice);
            command.Parameters.AddWithValue("producer", product.Producer);
            command.Parameters.AddWithValue("price", product.Price);
            command.CommandTimeout = 5;
            command.ExecuteNonQuery();
        }
        public Product GetOneById(int id)
        {
            string cmdText = $@"select * from Products where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            return this.GetProductsByQuery(reader).FirstOrDefault();
        }
        public void Delete(int id)
        {
            string cmdText = $@"Delete  Products WHERE Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }
    }
}
