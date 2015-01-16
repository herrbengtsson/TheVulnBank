using System.Collections.Generic;
using System.Data.SqlClient;
using TheVulnBank.Models.Data;

namespace TheVulnBank.Repositories
{
    public class ArticleRepository
    {
        private SqlConnection connection;

        public ArticleRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public Article GetArticle(int articleId)
        {
            Article result = new Article();
            //using (this.connection)
            {
                SqlCommand command = new SqlCommand("SELECT Id, Title, Text, Internal FROM Articles WHERE Id='" + articleId + "';", this.connection);
                this.connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = new Article
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Text = reader.GetString(2),
                        Internal = reader.GetBoolean(3),
                    };
                }
                reader.Close();
                this.connection.Close();
            }
            return result;
        }

        public List<Article> SearchArticles(string query)
        {
            List<Article> result = new List<Article>();
            //using(this.connection) 
            {
                SqlCommand command = new SqlCommand("SELECT Id, Title, Text FROM Articles WHERE (Title LIKE '%" + query + "%' OR Text LIKE '%" + query + "%') AND Internal=0;", this.connection);
                this.connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Article
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Text = reader.GetString(2),
                    });
                }
                reader.Close();
                this.connection.Close();
            }
            return result;
        }
    }
}