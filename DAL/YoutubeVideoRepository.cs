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
            if (!DatabaseExists())
            {
                CreateVideoDatabase();
            }
        }
        public int InsertYoutubeVideo(YoutubeVideo youtubeVideo)
        {
            string sql = "INSERT INTO YoutubeVideo (Title, Url , Uploader, Views, Date) Values (@title, @url, @uploader, @views, @date);";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, youtubeVideo);
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
