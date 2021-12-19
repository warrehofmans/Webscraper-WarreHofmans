using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication.DAL
{
    class YoutubeVideoRepository : SqlLiteBaseRepository
    {
        public YoutubeVideoRepository()
        {
                /*Create video table if not exists*/
                CreateVideoDatabase();
    }

        /*Save a youtube video to database*/
        public int InsertYoutubeVideo(YoutubeVideo youtubeVideo)
        {
            /*Insert sql query*/
            string sql = "INSERT OR IGNORE INTO YoutubeVideo (Title, Type, Url , Uploader, Views, Date) Values (@title, @type, @url, @uploader, @views, @date);";

            /*use DB connection*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open connection
                /*Execute query*/
                return connection.Execute(sql, youtubeVideo);
            }
        }

        /*Reset the video table: remove all video's*/
        public int ResetYoutubeDb()
        {
            /*Delete all sql query*/
            string sql = "DELETE  FROM YoutubeVideo;";

            /*Use DB connection*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open conenction
                /*Execute query*/
                return connection.Execute(sql);
            }
        }

        /*Delete a video from database*/
        public int DeleteVideo(YoutubeVideo video)
        {
            /*Delete sql query
             * delete based on id
             */
            string sql = "DELETE FROM YoutubeVideo WHERE Id = @id;";

            /*Use DB conenction*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open connection
                /*Execute query*/
                return connection.Execute(sql, video);
            }
        }


        /*Get all saved video's from database*/
        public IEnumerable<YoutubeVideo> GetYoutubeVideos()
        {
            /*Get all sql query*/
            string sql = "SELECT * FROM YoutubeVideo;";

            /*Use DB connection*/
            using (var connection = DbConnectionFactory())
            {
                connection.Open(); //open connection
                /*Execute query*/
                return connection.Query<YoutubeVideo>(sql);
            }
        }

    }
}
