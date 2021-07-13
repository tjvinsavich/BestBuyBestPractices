using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            
            IDbConnection conn = new MySqlConnection(connString);
            var depRepo = new DapperDepartmentRepository(conn);
            var prodRepo = new DapperProductRepository(conn);

            //DEPARTMENT SECTION 

            //Console.WriteLine("Type a new Department name");

            //var newDept = Console.ReadLine();

            //depRepo.InsertDepartment(newDept);

            //var departments = depRepo.GetAllDepartments();

            //foreach (var dept in departments)
            //{
            //    Console.WriteLine(dept.Name);
            //}

            //PRODUCT SECTION

            //Console.WriteLine("Type a new Product name (STRING)");
            //var name = Console.ReadLine();
            //Console.WriteLine("Type a new Product price (DOUBLE)");
            //var price = double.Parse(Console.ReadLine());
            //Console.WriteLine("Type the correct CategoryID for the new Product (INT)");
            //var categoryID = int.Parse(Console.ReadLine());

            //prodRepo.CreateProduct(name, price, categoryID);

            var products = prodRepo.GetAllProducts();

            //foreach (var prod in products)
            //{
            //    Console.WriteLine(prod.Name);
            //}

            //Console.WriteLine("Would you like to update that new product?");

            //var temp = name;

            //Console.WriteLine("Type a new Product name (STRING)");
            //name = Console.ReadLine();
            //Console.WriteLine("Type a new Product price (DOUBLE)");
            //price = double.Parse(Console.ReadLine());
            //Console.WriteLine("Type the correct CategoryID for the new Product (INT)");
            //categoryID = int.Parse(Console.ReadLine());

            //prodRepo.UpdateProduct(name, price, categoryID, temp);

            products = prodRepo.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine(prod.Name);
            }

            Console.WriteLine("Would you like to delete a product?");

            Console.WriteLine("Type the product ID");

            var prodID = int.Parse(Console.ReadLine());

            prodRepo.DeleteProduct(prodID);

            products = prodRepo.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine(prod.Name);
            }

            Console.WriteLine("DELETED!");


        }
    }
}
