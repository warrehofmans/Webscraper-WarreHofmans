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
            /*Create job table if not exists*/
              CreateJobDatabase();
        }

        /*Save job to database*/
        public int InsertJobAdv(JobAdv jobAdv)
        {
            /*Insert sql query*/ 
            string sql = "INSERT OR IGNORE INTO JobAdv (Title, Url , Company, Location) Values (@title, @url, @company, @location);";

            /*Use DB connection*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open connection
                /*Execute insert query*/
                return connection.Execute(sql, jobAdv);
            }
        }

        /*Delete a job from database*/
        public int DeleteJob(JobAdv job)
        {
            /*Delete sql query
             delete job based in id
            */
            string sql = "DELETE FROM JobAdv WHERE Id = @id;";
            /*Use DB connection*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open connection
                /*Execute query*/
                return connection.Execute(sql, job);
            }
        }

        /*Delete all saved jobs from database*/
        public int ResetJobDb()
        {
            /*Delete all sql query*/
            string sql = "DELETE  FROM JobAdv;";

            /*Use DB connection*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open connection
                /*Execute query*/
                return connection.Execute(sql);
            }
        }

        /*Get al saved jobs from database*/
        public IEnumerable<JobAdv> GetJobAdvs()
        {
            /*Get all sql query*/
            string sql = "SELECT * FROM JobAdv;";

            /*Use DB connection*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open connection
                /*Execute query*/
                return connection.Query<JobAdv>(sql);
            }
        }

    }
}
