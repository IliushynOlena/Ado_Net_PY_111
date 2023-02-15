using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_linqToSql
{
  
    internal class Program
    {
        static void Main(string[] args)
        {
            ShopClassesDataContext dbContext = new ShopClassesDataContext();
            //CRUD  - Create, Read,  Update, Delete;

            //Read
            //var products = dbContext.Products;
            //foreach (var p in products)
            //{
            //    Console.WriteLine($"Product : {p.Id} : {p.Name}   Price : {p.Price}$");
            //}

            //Filter
            //var products = dbContext.Products.Where(p => p.Price > 500).
            //    OrderByDescending(p => p.Price).Take(5);
            //var products = (from p in dbContext.Products
            //               where p.Price > 500
            //               orderby p.Price descending
            //               select p).Take(5);
            //foreach (var p in products) Console.WriteLine($"Product : {p.Id} : {p.Name}   Price : {p.Price}$");

            //Insert
            var spotrBottle = new Product()
            {
                Name = "My Bottle RX",
                TypeProduct = "Acessories",
                Quantity = 22,
                Price = 450,
                CostPrice = 350,
                Producer = "UA"
            };

            //dbContext.Products.InsertOnSubmit(spotrBottle);
            //dbContext.Products.InsertOnSubmit(new Product() { });
            // dbContext.SubmitChanges();

            //Update
            //var productToEdit = dbContext.Products.Where(p => p.Id == 26).FirstOrDefault();
            //var productToEdit = dbContext.Products.FirstOrDefault(p => p.Id == 26);
            //productToEdit.Price -= 300;
            //productToEdit.CostPrice -= 300;
            //dbContext.SubmitChanges();
            //Delete
            var productToDelete = dbContext.Products.FirstOrDefault(p => p.Id == 25);

            if(productToDelete != null)
                dbContext.Products.DeleteOnSubmit(productToDelete);



            dbContext.SubmitChanges();
            var products = dbContext.Products;
            foreach (var p in products)
            {
                Console.WriteLine($"Product : {p.Id} : {p.Name}   Price : {p.Price}$");
            }

        }
    }
}
