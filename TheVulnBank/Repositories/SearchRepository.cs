using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TheVulnBank.Models.Data;

namespace TheVulnBank.Repositories
{
    public class SearchRepository
    {
        private SqlConnection connection;

        public SearchRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public List<SearchItem> Search(string text, string noOfItems)
        {
            List<SearchItem> result = new List<SearchItem>();
            SqlCommand command = new SqlCommand("SELECT TOP " + noOfItems + " * FROM Search WHERE Summary LIKE @text;", this.connection);
            command.Parameters.AddWithValue("@text", "%" + text + "%");
            this.connection.Open();
            SqlDataReader reader = command.ExecuteReader(); ;
            
            while (reader.Read())
            {
                result.Add(new SearchItem
                {
                    Id = reader.SafeGetInt32("Id", -1),
                    Url = reader.SafeGetString("Url", null),
                    Summary = reader.SafeGetString("Summary", null),
                });
            }

            reader.Close();
            this.connection.Close();
            return result;
        }
    }
}