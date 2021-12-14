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
          
                CreateVideoDatabase();
       
    }
        public int InsertYoutubeVideo(YoutubeVideo youtubeVideo)
        {
            string sql = "INSERT OR IGNORE INTO YoutubeVideo (Title, Url , Uploader, Views, Date) Values (@title, @url, @uploader, @views, @date);";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, youtubeVideo);
            }
        }

        public int ResetYoutubeDb()
        {
            string sql = "DELETE  FROM YoutubeVideo;";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql);
            }
        }

        public int DeleteVideo(YoutubeVideo video)
        {
            string sql = "DELETE FROM YoutubeVideo WHERE Id = @id;";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, video);
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

        public IEnumerable<YoutubeVideo> GetYoutubeVideos()
        {
            string sql = "SELECT * FROM YoutubeVideo;";

            using (var connection = DbConnectionFactory())
            {
                return connection.Query<YoutubeVideo>(sql);
            }
        }

    }
}
