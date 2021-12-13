using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication.DAL
{
    class JobAdvRepository : SqlLiteBaseRepository
    {

        public JobAdvRepository()
        {
            if (!DatabaseExists())
            {
                CreateJobDatabase();
        }
    }
        public int InsertJobAdv(JobAdv jobAdv)
        {
            string sql = "INSERT OR IGNORE INTO JobAdv (Title, Url , Company, Location) Values (@title, @url, @company, @location);";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, jobAdv);
            }
        }

        /*  public int DeleteCompany(string symbol)
          {
              string sql = "DELETE FROM YoutubeVideo WHERE Symbol = @Symbol;";

              using (var connection = DbConnectionFactory())
              {
                  connection.Open();
                  return connection.Execute(sql, new { Symbol = symbol });
              }
          }*/

        public int DeleteJob(JobAdv job)
        {
            string sql = "DELETE FROM JobAdv WHERE Id = @id;";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, job);
            }
        }

        public int ResetJobDb()
        {
            string sql = "DELETE  FROM JobAdv;";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql);
            }
        }
        public IEnumerable<JobAdv> GetJobAdvs()
        {
            string sql = "SELECT * FROM JobAdv;";

            using (var connection = DbConnectionFactory())
            {
                return connection.Query<JobAdv>(sql);
            }
        }

    }
}
