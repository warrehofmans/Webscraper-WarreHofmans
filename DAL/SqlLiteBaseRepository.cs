using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Webscraper_ConsoleApplication.DAL
{
    class SqlLiteBaseRepository
    {
        private bool dbStatus;
        public SqlLiteBaseRepository()
        {
        }

        /*MAke connection database*/
        public static SqliteConnection DbConnectionFactory()
        {
            return new SqliteConnection(@"DataSource=ScraperDB.sqlite");
        }

        /*Check if database existst*/
        protected static bool DatabaseExists()
        {
           /*check if the file exists*/
            return File.Exists(@"ScraperDB.sqlite");
        }

        /*Create the video table in database if not exists*/
        protected static void CreateVideoDatabase()
        {
            /*Use the db connection*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open connection

                /*execute create video table sql query*/
                connection.Execute(
                    @"CREATE TABLE IF NOT EXISTS YoutubeVideo
                    (
                    Id                                 INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title                              VARCHAR(50) UNIQUE,
                    Type                               VARCHAR(50),
                    Url                                VARCHAR(100),
                    Uploader                           VARCHAR(100),
                    Views                              VARCHAR(100),
                    Date                               VARCHAR(100)
                    )"
                   );
            }
        }

        /*Create the job table in database if not exists*/
        protected static void CreateJobDatabase()
        {
            /*Use the db connection*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open connection

                /*execute create job table sql query*/
                connection.Execute(
                    @"CREATE TABLE IF NOT EXISTS JobAdv
                    (
                    Id                                 INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title                              VARCHAR(50) UNIQUE,
                    Url                                VARCHAR(100),
                    Company                            VARCHAR(100),
                    Location                           VARCHAR(100)
                    )"
                   ) ;
            }
        }

        /*Create the product table in database if not exists*/
        protected static void CreateProductDatabase()
        {
            /*Use the db connection*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open();  //open connection

                /*execute create product table sql query*/
                connection.Execute(
                    @"CREATE TABLE IF NOT EXISTS ProductItem
                    (
                    Id                                 INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title                              VARCHAR(50) UNIQUE,
                    Url                                VARCHAR(100),
                    Creator                            VARCHAR(100),
                    Delivery                           VARCHAR(100),
                    Price                              VARCHAR(100)
                    )"
                   );
            }
        }
    }
}
