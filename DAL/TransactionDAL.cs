using MySql.Data.MySqlClient;
using BankManagementSystem.Models;

namespace BankManagementSystem.DAL
{
    public class TransactionDAL
    {
        public List<Transaction> GetAll(int limit = 100)
        {
            var transactions = new List<Transaction>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                $"SELECT * FROM Transactions ORDER BY DateTime DESC LIMIT @limit;", conn);
            cmd.Parameters.AddWithValue("@limit", limit);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                transactions.Add(MapTransaction(reader));
            return transactions;
        }

        public List<Transaction> GetByAccountId(int accountId)
        {
            var transactions = new List<Transaction>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT * FROM Transactions
                  WHERE FromAccountID = @aid OR ToAccountID = @aid
                  ORDER BY DateTime DESC;", conn);
            cmd.Parameters.AddWithValue("@aid", accountId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                transactions.Add(MapTransaction(reader));
            return transactions;
        }

        public List<Transaction> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            var transactions = new List<Transaction>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT * FROM Transactions
                  WHERE DateTime BETWEEN @start AND @end
                  ORDER BY DateTime DESC;", conn);
            cmd.Parameters.AddWithValue("@start", startDate);
            cmd.Parameters.AddWithValue("@end", endDate);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                transactions.Add(MapTransaction(reader));
            return transactions;
        }

        public int Insert(Transaction txn, MySqlConnection? conn = null, MySqlTransaction? dbTxn = null)
        {
            bool ownConnection = conn == null;
            conn ??= DbConnectionManager.GetConnection();
            if (ownConnection) conn.Open();

            try
            {
                using var cmd = new MySqlCommand(
                    @"INSERT INTO Transactions (FromAccountID, ToAccountID, Amount, Type, Description)
                      VALUES (@from, @to, @amount, @type, @desc);
                      SELECT LAST_INSERT_ID();", conn);
                if (dbTxn != null) cmd.Transaction = dbTxn;
                cmd.Parameters.AddWithValue("@from", txn.FromAccountID.HasValue ? txn.FromAccountID.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@to", txn.ToAccountID.HasValue ? txn.ToAccountID.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@amount", txn.Amount);
                cmd.Parameters.AddWithValue("@type", txn.Type);
                cmd.Parameters.AddWithValue("@desc", txn.Description);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            finally
            {
                if (ownConnection) conn.Dispose();
            }
        }

        public List<Transaction> GetRecentTransactions(int count = 10)
        {
            var transactions = new List<Transaction>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                $"SELECT * FROM Transactions ORDER BY DateTime DESC LIMIT @count;", conn);
            cmd.Parameters.AddWithValue("@count", count);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                transactions.Add(MapTransaction(reader));
            return transactions;
        }

        public List<(DateTime Date, decimal Total)> GetDailyTotals(int days = 30)
        {
            var result = new List<(DateTime, decimal)>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT DATE(DateTime) as TxnDate, SUM(Amount) as Total
                  FROM Transactions
                  WHERE DateTime >= DATE_SUB(CURDATE(), INTERVAL @days DAY)
                  GROUP BY DATE(DateTime)
                  ORDER BY TxnDate;", conn);
            cmd.Parameters.AddWithValue("@days", days);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                result.Add((reader.GetDateTime("TxnDate"), reader.GetDecimal("Total")));
            return result;
        }

        private static Transaction MapTransaction(MySqlDataReader reader)
        {
            return new Transaction
            {
                TransactionID = reader.GetInt32("TransactionID"),
                FromAccountID = reader.IsDBNull(reader.GetOrdinal("FromAccountID")) ? null : reader.GetInt32("FromAccountID"),
                ToAccountID = reader.IsDBNull(reader.GetOrdinal("ToAccountID")) ? null : reader.GetInt32("ToAccountID"),
                Amount = reader.GetDecimal("Amount"),
                Type = reader.GetString("Type"),
                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString("Description"),
                DateTime = reader.GetDateTime("DateTime")
            };
        }
    }
}
