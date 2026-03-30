using MySql.Data.MySqlClient;
using BankManagementSystem.Models;

namespace BankManagementSystem.DAL
{
    public class AccountDAL
    {
        public List<Account> GetAll()
        {
            var accounts = new List<Account>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT a.*, c.FullName AS CustomerName
                  FROM Accounts a
                  JOIN Customers c ON a.CustomerID = c.CustomerID
                  ORDER BY a.CreatedAt DESC;", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                accounts.Add(MapAccount(reader));
            return accounts;
        }

        public Account? GetById(int id)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT a.*, c.FullName AS CustomerName
                  FROM Accounts a
                  JOIN Customers c ON a.CustomerID = c.CustomerID
                  WHERE a.AccountID = @id;", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return MapAccount(reader);
            return null;
        }

        public List<Account> GetByCustomerId(int customerId)
        {
            var accounts = new List<Account>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT a.*, c.FullName AS CustomerName
                  FROM Accounts a
                  JOIN Customers c ON a.CustomerID = c.CustomerID
                  WHERE a.CustomerID = @cid
                  ORDER BY a.CreatedAt DESC;", conn);
            cmd.Parameters.AddWithValue("@cid", customerId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                accounts.Add(MapAccount(reader));
            return accounts;
        }

        public List<Account> Search(string query)
        {
            var accounts = new List<Account>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT a.*, c.FullName AS CustomerName
                  FROM Accounts a
                  JOIN Customers c ON a.CustomerID = c.CustomerID
                  WHERE c.FullName LIKE @q OR CAST(a.AccountID AS CHAR) LIKE @q
                  ORDER BY a.CreatedAt DESC;", conn);
            cmd.Parameters.AddWithValue("@q", $"%{query}%");
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                accounts.Add(MapAccount(reader));
            return accounts;
        }

        public int Insert(Account account)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"INSERT INTO Accounts (CustomerID, AccountType, Balance, Status)
                  VALUES (@cid, @type, @balance, @status);
                  SELECT LAST_INSERT_ID();", conn);
            cmd.Parameters.AddWithValue("@cid", account.CustomerID);
            cmd.Parameters.AddWithValue("@type", account.AccountType);
            cmd.Parameters.AddWithValue("@balance", account.Balance);
            cmd.Parameters.AddWithValue("@status", account.Status);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void UpdateBalance(int accountId, decimal newBalance, MySqlConnection? conn = null, MySqlTransaction? transaction = null)
        {
            bool ownConnection = conn == null;
            conn ??= DbConnectionManager.GetConnection();
            if (ownConnection) conn.Open();

            try
            {
                using var cmd = new MySqlCommand(
                    "UPDATE Accounts SET Balance = @balance WHERE AccountID = @id;", conn);
                if (transaction != null) cmd.Transaction = transaction;
                cmd.Parameters.AddWithValue("@balance", newBalance);
                cmd.Parameters.AddWithValue("@id", accountId);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (ownConnection) conn.Dispose();
            }
        }

        public void UpdateStatus(int accountId, string status)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "UPDATE Accounts SET Status = @status WHERE AccountID = @id;", conn);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@id", accountId);
            cmd.ExecuteNonQuery();
        }

        public int GetTotalCount()
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM Accounts;", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public decimal GetTotalBalance()
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT COALESCE(SUM(Balance), 0) FROM Accounts WHERE Status = 'Active';", conn);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        public Dictionary<string, int> GetCountByType()
        {
            var result = new Dictionary<string, int>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT AccountType, COUNT(*) as Cnt FROM Accounts GROUP BY AccountType;", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                result[reader.GetString("AccountType")] = reader.GetInt32("Cnt");
            return result;
        }

        public Dictionary<string, decimal> GetBalanceByType()
        {
            var result = new Dictionary<string, decimal>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT AccountType, COALESCE(SUM(Balance), 0) as Total
                  FROM Accounts WHERE Status = 'Active' GROUP BY AccountType;", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                result[reader.GetString("AccountType")] = reader.GetDecimal("Total");
            return result;
        }

        private static Account MapAccount(MySqlDataReader reader)
        {
            return new Account
            {
                AccountID = reader.GetInt32("AccountID"),
                CustomerID = reader.GetInt32("CustomerID"),
                AccountType = reader.GetString("AccountType"),
                Balance = reader.GetDecimal("Balance"),
                Status = reader.GetString("Status"),
                CreatedAt = reader.GetDateTime("CreatedAt"),
                CustomerName = reader.GetString("CustomerName")
            };
        }
    }
}
