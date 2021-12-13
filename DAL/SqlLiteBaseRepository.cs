﻿using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Webscraper_ConsoleApplication.DAL
{
    class SqlLiteBaseRepository
    {
        public SqlLiteBaseRepository()
        {
        }

  
        public static SqliteConnection DbConnectionFactory()
        {
            return new SqliteConnection(@"DataSource=ScraperDB.sqlite");
        }

        public static void dbHardReset()
        {
            string sql = "DROP TABLE JobAdv;";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                connection.Execute(sql);
            }
            
        }

        protected static bool DatabaseExists()
        {
           
            return File.Exists(@"ScraperDB.sqlite");
        }

        protected static void CreateVideoDatabase()
        {
            using (var connection = DbConnectionFactory())
            {
                connection.Open();
  
                //create youtube table
                connection.Execute(
                    @"CREATE TABLE YoutubeVideo
                    (
                    Id                                 INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title                              VARCHAR(50) UNIQUE,
                    Url                                VARCHAR(100),
                    Uploader                           VARCHAR(100),
                    Views                              VARCHAR(100),
                    Date                               VARCHAR(100)
                    )"
                   ) ;
            }
        } 
        protected static void CreateJobDatabase()
        {
            using (var connection = DbConnectionFactory())
            {
                connection.Open();
  
                //create youtube table
                connection.Execute(
                    @"CREATE TABLE JobAdv
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
    }
}
