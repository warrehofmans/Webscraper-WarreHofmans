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
          /*Create product table if not exists*/
          CreateProductDatabase();
            
        }

        /*Save product to database*/
        public int InsertProductItem(ProductItem productItem)
        {
            /*Insert sql query*/
            string sql = "INSERT OR IGNORE INTO ProductItem (Title , Url, Creator, Delivery, Price) Values (@title, @url, @creator, @delivery, @price);";

            /*Use DB conection*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open connection
                /*Execute query*/
                return connection.Execute(sql, productItem);
            }
        }

        /*Delete all saved product from database*/
        public int ResetProductDb()
        {
            /*Delet all sql query*/
            string sql = "DELETE  FROM ProductItem;";

            /*Use DB connection*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open connection
                /*Execute query*/
                return connection.Execute(sql);
            }
        }

        /*Delet product from database*/
        public int DeleteProduct(ProductItem product)
        {
            /*Delete sql quert
             * Delete based on id
             */
            string sql = "DELETE FROM ProductItem WHERE Id = @id;";

            /*Use DB connection*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open connection
                /*Execute query*/
                return connection.Execute(sql, product);
            }
        }

        //Get all saved products from database*/
        public IEnumerable<ProductItem> GetProductItems()
        {
            /*Get all sql query*/
            string sql = "SELECT * FROM ProductItem;";
            /*Use DB conneciton*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open connection
                /*Execute query*/
                return connection.Query<ProductItem>(sql);
            }
        }

    }
}
