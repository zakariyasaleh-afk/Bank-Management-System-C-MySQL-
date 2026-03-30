using MySql.Data.MySqlClient;
using BankManagementSystem.Models;

namespace BankManagementSystem.DAL
{
    public class LoanPaymentDAL
    {
        public List<LoanPayment> GetByLoanId(int loanId)
        {
            var payments = new List<LoanPayment>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT * FROM LoanPayments WHERE LoanID = @lid ORDER BY PaymentDate DESC;", conn);
            cmd.Parameters.AddWithValue("@lid", loanId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                payments.Add(MapPayment(reader));
            return payments;
        }

        public int Insert(LoanPayment payment)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"INSERT INTO LoanPayments (LoanID, Amount)
                  VALUES (@lid, @amount);
                  SELECT LAST_INSERT_ID();", conn);
            cmd.Parameters.AddWithValue("@lid", payment.LoanID);
            cmd.Parameters.AddWithValue("@amount", payment.Amount);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public decimal GetTotalPayments(int loanId)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT COALESCE(SUM(Amount), 0) FROM LoanPayments WHERE LoanID = @lid;", conn);
            cmd.Parameters.AddWithValue("@lid", loanId);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        private static LoanPayment MapPayment(MySqlDataReader reader)
        {
            return new LoanPayment
            {
                PaymentID = reader.GetInt32("PaymentID"),
                LoanID = reader.GetInt32("LoanID"),
                Amount = reader.GetDecimal("Amount"),
                PaymentDate = reader.GetDateTime("PaymentDate")
            };
        }
    }
}
