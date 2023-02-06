using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace _02_Connected_Mode_CRUD
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public float CostPrice { get; set; }
        public string Producer { get; set; }
        public float Price { get; set; }
    }
    class SportShopDb
    {
        //CRUD
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
            string cmdText = $@"INSERT INTO Products
                                VALUES ('{product.Name}', 
                                        '{product.Type}', 
                                         {product.Quantity}, 
                                         {product.CostPrice}, 
                                        '{product.Producer}', 
                                         {product.Price})";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 5; 
            command.ExecuteNonQuery();
        }
        public List<Product> GetAll()
        {
            string cmdText = @"select * from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();           
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice =  Convert.ToSingle(reader[4]),
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
                                SET Name = '{product.Name}', 
                                    TypeProduct = '{product.Type}', 
                                    Quantity = {product.Quantity}, 
                                    CostPrice = {product.CostPrice}, 
                                    Producer = '{product.Producer}', 
                                    Price = {product.Price}
                                where Id = {product.Id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 5;
            command.ExecuteNonQuery();
        }
        public Product GetOneById(int id)
        {
            string cmdText = $@"select * from Products where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            Product product = new Product();
            while (reader.Read())
            {

                product.Id = (int)reader[0];
                product.Name = (string)reader[1];
                product.Type = (string)reader[2];
                product.Quantity = (int)reader[3];
                product.CostPrice = (int)reader[4];
                product.Producer = (string)reader[5];
                product.Price = (int)reader[6];
               
            }
            reader.Close();
            return product;
        }
        public void Delete(int id)
        {
            string cmdText = $@"Delete  Products WHERE Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string connectionstring = @"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
                                Initial Catalog=SportShop;Integrated Security=True;
                                Connect Timeout=2";
            SportShopDb db = new SportShopDb(connectionstring);
            Product product = new Product()
            {
                Name = "Ball",
                Type = "Football equimpent",
                Quantity = 5,
                CostPrice = 1500,
                Producer = "China",
                Price = 1300
            };
            //db.Create(product);
            var products = db.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine(item.Id + " " + item.Name);
            }
            //Product p = db.GetOneById(5);

            //p.Quantity = 10;
            //p.CostPrice = 5000;
            //p.Price = 4700;
            //Console.WriteLine(p.Id + " " + p.Name);

            //db.Update(p);
            // db.Delete(20);




        }
    }
}
