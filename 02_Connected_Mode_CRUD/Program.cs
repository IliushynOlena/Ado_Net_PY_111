using data_access;
using data_access.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;

namespace _02_Connected_Mode_CRUD
{
    //class Product
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Type { get; set; }
    //    public int Quantity { get; set; }
    //    public float CostPrice { get; set; }
    //    public string Producer { get; set; }
    //    public float Price { get; set; }
    //}
    //class SportShopDb
    //{
    //    //CRUD interface
    //    //[C]reate
    //    //[R]ead
    //    //[U]pdate
    //    //[D]elete
    //    private SqlConnection connection;
        
    //    public SportShopDb(string connectionstring)
    //    {
    //        connection = new SqlConnection(connectionstring);
    //        connection.Open();
    //    }
    //    ~SportShopDb()
    //    {
    //        connection.Close();
    //    }
    //    public void Create(Product product)
    //    {
    //        //string cmdText = $@"INSERT INTO Products
    //        //                    VALUES ('{product.Name}', 
    //        //                            '{product.Type}', 
    //        //                             {product.Quantity}, 
    //        //                             {product.CostPrice}, 
    //        //                            '{product.Producer}', 
    //        //                             {product.Price})";
    //        string cmdText = $@"INSERT INTO Products
    //                            VALUES (@name, 
    //                                    @type, 
    //                                    @quantity, 
    //                                    @costPrice, 
    //                                    @producer, 
    //                                    @price)";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        command.Parameters.AddWithValue("name", product.Name);
    //        command.Parameters.AddWithValue("type", product.Type);
    //        command.Parameters.AddWithValue("quantity", product.Quantity);
    //        command.Parameters.AddWithValue("costPrice", product.CostPrice);
    //        command.Parameters.AddWithValue("producer", product.Producer);
    //        command.Parameters.AddWithValue("price", product.Price);

    //        command.CommandTimeout = 5; 
    //        command.ExecuteNonQuery();
    //    }
    //    public List<Product> GetAll()
    //    {
    //        string cmdText = @"select * from Products";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        SqlDataReader reader = command.ExecuteReader();
    //        return this.GetProductsByQuery(reader);
    //    }
    //    public List<Product> GetAllByName(string name)
    //    {
    //        //SQL injection :name = 'Ball'; drop database SportShop;--
    //        //name = "Ball";
    //        string cmdText = $@"select * from Products where Name = @name";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        command.Parameters.Add("name",System.Data.SqlDbType.NVarChar).Value = name;

    //        //SqlParameter sql = new SqlParameter()
    //        //{
    //        //    ParameterName = "name",
    //        //    SqlDbType = System.Data.SqlDbType.NVarChar,
    //        //    Value = name
    //        //};
    //        //command.Parameters.Add(sql);

    //        SqlDataReader reader = command.ExecuteReader();
    //        return this.GetProductsByQuery(reader);
    //    }
    //    private List<Product> GetProductsByQuery(SqlDataReader reader)
    //    {         

    //        List<Product> products = new List<Product>();
    //        while (reader.Read())
    //        {
    //            products.Add(new Product()
    //            {
    //                Id = (int)reader[0],
    //                Name = (string)reader[1],
    //                Type = (string)reader[2],
    //                Quantity = (int)reader[3],
    //                CostPrice = Convert.ToSingle(reader[4]),
    //                Producer = (string)reader[5],
    //                Price = Convert.ToSingle(reader[6])
    //            });
    //        }
    //        reader.Close();
    //        return products;
    //    }
    //    public void Update(Product product)
    //    {
    //        string cmdText = $@"UPDATE Products
    //                            SET Name = @name, 
    //                                TypeProduct = @type, 
    //                                Quantity = @quantity, 
    //                                CostPrice = @costPrice, 
    //                                Producer = @producer, 
    //                                Price = @price
    //                            where Id = {product.Id}";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        command.Parameters.AddWithValue("name", product.Name);
    //        command.Parameters.AddWithValue("type", product.Type);
    //        command.Parameters.AddWithValue("quantity", product.Quantity);
    //        command.Parameters.AddWithValue("costPrice", product.CostPrice);
    //        command.Parameters.AddWithValue("producer", product.Producer);
    //        command.Parameters.AddWithValue("price", product.Price);
    //        command.CommandTimeout = 5;
    //        command.ExecuteNonQuery();
    //    }
    //    public Product GetOneById(int id)
    //    {
    //        string cmdText = $@"select * from Products where Id = {id}";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        SqlDataReader reader = command.ExecuteReader();
    //        return this.GetProductsByQuery(reader).FirstOrDefault();
    //    }
    //    public void Delete(int id)
    //    {
    //        string cmdText = $@"Delete  Products WHERE Id = {id}";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        command.ExecuteNonQuery();
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string connectionstring = @"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
                                Initial Catalog=SportShop;Integrated Security=True;
                                Connect Timeout=2";
            SportShopDb db = new SportShopDb(connectionstring);
            //Product product = new Product()
            //{
            //    Name = "Ball",
            //    Type = "Football equimpent",
            //    Quantity = 5,
            //    CostPrice = 1500,
            //    Producer = "China",
            //    Price = 1300
            //};
            //db.Create(product);
            Product product = new Product()
            {
                Name = "Footbal T-Shirt",
                Type = "Sport clothes",
                Quantity = 12,
                CostPrice = 600,
                Producer = "Turkey",
                Price = 1000
            };
            //db.Create(product);
           

            //Console.WriteLine("Enter product name to search : ");
            //string name = Console.ReadLine();
           // List<Product> products = db.GetAllByName(name);
            //foreach (var item in products)
            //{
            //    Console.WriteLine(item.Id + " " + item.Name + " " + item.CostPrice + " " + item.Producer);
            //}
            var pr = db.GetAll();
            foreach (var item in pr)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.CostPrice + " " + item.Producer);
            }
            Product p = db.GetOneById(27);
            Console.WriteLine(p.Id + " " + p.Name);

            p.Quantity = 100;
            p.CostPrice = 1500;
            p.Price = 2000;
            db.Update(p);
            pr = db.GetAll();
            foreach (var item in pr)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.CostPrice + " " + item.Producer);
            }

            // db.Delete(20);




        }
    }
}
