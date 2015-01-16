using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TheVulnBank.Models.Data;

namespace TheVulnBank.Repositories
{
    public class QuestionsRepository
    {
        private SqlConnection connection;

        public QuestionsRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public List<Question> GetQuestions()
        {
            List<Question> result = new List<Question>();
            //using(this.connection) 
            {
                SqlCommand command = new SqlCommand("SELECT Accounts.Id, Users.FirstName + ' ' + Users.LastName + ' - ' + Accounts.Name FROM Accounts LEFT OUTER JOIN Users ON Accounts.UserId = Users.Id ORDER BY Users.FirstName, Users.LastName, Accounts.Name;", this.connection);
                this.connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Question
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        AgentId = reader.GetInt32(2),
                        Text = reader.GetString(3),
                        Answer = reader.GetString(4),
                    });
                }
                reader.Close();
                this.connection.Close();
            }

            return result;
        }
    }
}