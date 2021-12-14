using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using Webscraper_ConsoleApplication.model;

namespace Webscraper_ConsoleApplication.DAL
{
    class ProductItemRepository : SqlLiteBaseRepository
    {

        public ProductItemRepository()
        {
            if (!DatabaseExists())
            {
                CreateProductDatabase();
            }
        }
        public int InsertProductItem(ProductItem productItem)
        {
            string sql = "INSERT OR IGNORE INTO ProductItem (Title , Url, Creator, Delivery, Price) Values (@title, @url, @creator, @delivery, @price);";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, productItem);
            }
        }

        public int ResetProductDb()
        {
            string sql = "DELETE  FROM ProductItem;";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql);
            }
        }

        public int DeleteProduct(ProductItem product)
        {
            string sql = "DELETE FROM ProductItem WHERE Id = @id;";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, product);
            }
        }

        public IEnumerable<ProductItem> GetProductItems()
        {
            string sql = "SELECT * FROM ProductItem;";

            using (var connection = DbConnectionFactory())
            {
                return connection.Query<ProductItem>(sql);
            }
        }

    }
}
