using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }
        public void CreateProduct(string newName, double newPrice, int newCategoryID)
        {
            _connection.Execute("INSERT INTO products (name, price, categoryID) VALUES (@prodName, @prodPrice, @prodCategoryID);",
                new { prodName = newName, prodPrice = newPrice, prodCategoryID = newCategoryID });
        }

        public void UpdateProduct(string newName, double newPrice, int newCategoryID, string oldProd)
        {
            _connection.Execute("UPDATE products SET name = @prodName, price = @prodPrice, categoryID = @prodCategoryID WHERE" +
                " name = @oldName;", new { prodName = newName, prodPrice = newPrice, prodCategoryID = newCategoryID, oldName = oldProd });
        }

    }
}
