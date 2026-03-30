using MySql.Data.MySqlClient;
using BankManagementSystem.Models;

namespace BankManagementSystem.DAL
{
    public class LoanDAL
    {
        public List<Loan> GetAll()
        {
            var loans = new List<Loan>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT l.*, c.FullName AS CustomerName,
                         COALESCE(u.FullName, '') AS ApprovedByName
                  FROM Loans l
                  JOIN Customers c ON l.CustomerID = c.CustomerID
                  LEFT JOIN Users u ON l.ApprovedBy = u.UserID
                  ORDER BY l.CreatedAt DESC;", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                loans.Add(MapLoan(reader));
            return loans;
        }

        public Loan? GetById(int id)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT l.*, c.FullName AS CustomerName,
                         COALESCE(u.FullName, '') AS ApprovedByName
                  FROM Loans l
                  JOIN Customers c ON l.CustomerID = c.CustomerID
                  LEFT JOIN Users u ON l.ApprovedBy = u.UserID
                  WHERE l.LoanID = @id;", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return MapLoan(reader);
            return null;
        }

        public List<Loan> GetByCustomerId(int customerId)
        {
            var loans = new List<Loan>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT l.*, c.FullName AS CustomerName,
                         COALESCE(u.FullName, '') AS ApprovedByName
                  FROM Loans l
                  JOIN Customers c ON l.CustomerID = c.CustomerID
                  LEFT JOIN Users u ON l.ApprovedBy = u.UserID
                  WHERE l.CustomerID = @cid
                  ORDER BY l.CreatedAt DESC;", conn);
            cmd.Parameters.AddWithValue("@cid", customerId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                loans.Add(MapLoan(reader));
            return loans;
        }

        public int Insert(Loan loan)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"INSERT INTO Loans (CustomerID, Amount, InterestRate, Status, StartDate, EndDate)
                  VALUES (@cid, @amount, @rate, @status, @start, @end);
                  SELECT LAST_INSERT_ID();", conn);
            cmd.Parameters.AddWithValue("@cid", loan.CustomerID);
            cmd.Parameters.AddWithValue("@amount", loan.Amount);
            cmd.Parameters.AddWithValue("@rate", loan.InterestRate);
            cmd.Parameters.AddWithValue("@status", loan.Status);
            cmd.Parameters.AddWithValue("@start", loan.StartDate);
            cmd.Parameters.AddWithValue("@end", loan.EndDate);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void UpdateStatus(int loanId, string status, int? approvedBy = null)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"UPDATE Loans SET Status = @status, ApprovedBy = @approvedBy
                  WHERE LoanID = @id;", conn);
            cmd.Parameters.AddWithValue("@id", loanId);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@approvedBy", approvedBy.HasValue ? approvedBy.Value : DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public int GetActiveCount()
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM Loans WHERE Status IN ('Pending','Approved');", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public Dictionary<string, int> GetCountByStatus()
        {
            var result = new Dictionary<string, int>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT Status, COUNT(*) as Cnt FROM Loans GROUP BY Status;", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                result[reader.GetString("Status")] = reader.GetInt32("Cnt");
            return result;
        }

        public decimal GetTotalRepaid(int loanId)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT COALESCE(SUM(Amount), 0) FROM LoanPayments WHERE LoanID = @id;", conn);
            cmd.Parameters.AddWithValue("@id", loanId);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        private static Loan MapLoan(MySqlDataReader reader)
        {
            return new Loan
            {
                LoanID = reader.GetInt32("LoanID"),
                CustomerID = reader.GetInt32("CustomerID"),
                Amount = reader.GetDecimal("Amount"),
                InterestRate = reader.GetDecimal("InterestRate"),
                Status = reader.GetString("Status"),
                StartDate = reader.GetDateTime("StartDate"),
                EndDate = reader.GetDateTime("EndDate"),
                ApprovedBy = reader.IsDBNull(reader.GetOrdinal("ApprovedBy")) ? null : reader.GetInt32("ApprovedBy"),
                CreatedAt = reader.GetDateTime("CreatedAt"),
                CustomerName = reader.GetString("CustomerName"),
                ApprovedByName = reader.GetString("ApprovedByName")
            };
        }
    }
}
