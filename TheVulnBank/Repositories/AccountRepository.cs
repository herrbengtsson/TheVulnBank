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
                SqlCeCommand command = new SqlCeCommand("SELECT Id, Amount, Name FROM Accounts WHERE UserId='" + userId + "';", this.connection);
                this.connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Account
                    {
                        Id = reader.GetInt32(0),
                        Amount = reader.GetDouble(1),
                        Name = reader.GetString(2),
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
                SqlCeCommand command = new SqlCeCommand("SELECT Accounts.Id, Users.FirstName + ' ' + Users.LastName + ' - ' + Accounts.Name FROM Accounts LEFT OUTER JOIN Users ON Accounts.Id = Users.Id ORDER BY User.FirstName, User.LastName, Account.Name;", this.connection);
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
                SqlCeCommand command = new SqlCeCommand("SELECT Id, FromAccountId, ToAccountId, Amount, Message FROM Transfers WHERE FromAccountId='" + accountId + "' OR ToAccountId='" + accountId + "';", this.connection);
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
                SqlCeCommand command = new SqlCeCommand("INSERT INTO Transfers (FromAccountId, ToAccountId, Amount, Message) VALUES (" + fromAccountId + ", " + toAccountId + ", " + amount + ", '" + message + "');", this.connection);
                this.connection.Open();
                command.ExecuteNonQuery();
                this.connection.Close();
            }
        }

    }
}