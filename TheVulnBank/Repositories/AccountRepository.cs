using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Web;
using TheVulnBank.Models.Data;

namespace TheVulnBank.Repositories
{
    public class AccountRepository
    {
        private SqlCeConnection connection;

        public AccountRepository(SqlCeConnection connection)
        {
            this.connection = connection;
        }

        public List<Account> ListAccounts(int userId)
        {
            List<Account> result = new List<Account>();
            //using(this.connection) 
            {
                SqlCeCommand command = new SqlCeCommand("SELECT Id, Amount FROM Accounts WHERE UserId='" + userId + "';", this.connection);
                this.connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Account
                    {
                        Id = reader.GetInt32(0),
                        Amount = reader.GetDouble(1),
                    });
                }
                reader.Close();
                this.connection.Close();
            }
            return result;
        }

        public List<Account> ListAllAccounts()
        {
            List<Account> result = new List<Account>();
            //using(this.connection) 
            {
                SqlCeCommand command = new SqlCeCommand("SELECT Accounts.Id, Users.Username FROM Accounts LEFT OUTER JOIN Users ON Accounts.Id = Users.Id;", this.connection);
                this.connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Account
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                    });
                }
                reader.Close();
                this.connection.Close();
            }
            return result;
        }

        public List<Transfer> ListTransfers(int accountId)
        {
            List<Transfer> result = new List<Transfer>();
            //using(this.connection) 
            {
                SqlCeCommand command = new SqlCeCommand("SELECT Id, SendAccId, RecAccId, Amount, Message FROM Transfers WHERE SendAccId='" + accountId + "' OR RecAccId='" + accountId + "';", this.connection);
                this.connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Transfer
                    {
                        Id = reader.GetInt32(0),
                        SendAccId = reader.GetInt32(1),
                        RecAccId = reader.GetInt32(2),
                        Amount = reader.GetDouble(3),
                        Message = reader.GetString(4),
                    });
                }
                reader.Close();
                this.connection.Close();
            }
            return result;
        }

        public void AddTransfer(int fromAccountId, int toAccountId, double amount, string message)
        {
            //using(this.connection) 
            {
                SqlCeCommand command = new SqlCeCommand("INSERT INTO Transfers (SendAccId, RecAccId, Amount, Message) VALUES (" + fromAccountId + ", " + toAccountId + ", " + amount + ", '" + message + "');", this.connection);
                this.connection.Open();
                command.ExecuteNonQuery();
                this.connection.Close();
            }
        }

    }
}