using MySql.Data.MySqlClient;
using BankManagementSystem.DAL;
using BankManagementSystem.Models;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.BLL
{
    public class TransactionBLL
    {
        private readonly TransactionDAL _transactionDAL = new();
        private readonly AccountDAL _accountDAL = new();
        private readonly AuditLogBLL _auditLog = new();

        public List<Transaction> GetAll(int limit = 100) => _transactionDAL.GetAll(limit);
        public List<Transaction> GetByAccountId(int accountId) => _transactionDAL.GetByAccountId(accountId);
        public List<Transaction> GetByDateRange(DateTime start, DateTime end) => _transactionDAL.GetByDateRange(start, end);
        public List<Transaction> GetRecentTransactions(int count = 10) => _transactionDAL.GetRecentTransactions(count);
        public List<(DateTime Date, decimal Total)> GetDailyTotals(int days = 30) => _transactionDAL.GetDailyTotals(days);

        /// Processes a deposit into an account.
        public (bool success, string message) Deposit(int accountId, decimal amount, string description = "")
        {
            if (amount <= 0)
                return (false, "Deposit amount must be positive.");

            var account = _accountDAL.GetById(accountId);
            if (account == null) return (false, "Account not found.");
            if (account.Status != "Active") return (false, "Can only deposit to active accounts.");

            // Use MySQL transaction for atomicity
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var dbTxn = conn.BeginTransaction();

            try
            {
                decimal newBalance = account.Balance + amount;
                _accountDAL.UpdateBalance(accountId, newBalance, conn, dbTxn);

                var txn = new Transaction
                {
                    ToAccountID = accountId,
                    Amount = amount,
                    Type = "Deposit",
                    Description = string.IsNullOrWhiteSpace(description) ? "Cash deposit" : description
                };
                _transactionDAL.Insert(txn, conn, dbTxn);

                dbTxn.Commit();
                _auditLog.Log("Deposit", $"Deposited {amount:C} to account #{accountId}. New balance: {newBalance:C}.");
                return (true, $"Deposited {amount:C} successfully. New balance: {newBalance:C}");
            }
            catch (Exception ex)
            {
                dbTxn.Rollback();
                return (false, $"Deposit failed: {ex.Message}");
            }
        }

       
        /// Processes a withdrawal from an account.
        public (bool success, string message) Withdraw(int accountId, decimal amount, string description = "")
        {
            if (amount <= 0)
                return (false, "Withdrawal amount must be positive.");

            var account = _accountDAL.GetById(accountId);
            if (account == null) return (false, "Account not found.");
            if (account.Status != "Active") return (false, "Can only withdraw from active accounts.");

            // Check minimum balance requirement
            var accountBLL = new AccountBLL();
            decimal minBalance = accountBLL.GetMinBalance(account.AccountType);
            decimal newBalance = account.Balance - amount;

            if (newBalance < minBalance)
                return (false, $"Insufficient funds. Minimum balance for {account.AccountType} is {minBalance:C}. " +
                              $"Maximum withdrawal: {(account.Balance - minBalance):C}");

            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var dbTxn = conn.BeginTransaction();

            try
            {
                _accountDAL.UpdateBalance(accountId, newBalance, conn, dbTxn);

                var txn = new Transaction
                {
                    FromAccountID = accountId,
                    Amount = amount,
                    Type = "Withdraw",
                    Description = string.IsNullOrWhiteSpace(description) ? "Cash withdrawal" : description
                };
                _transactionDAL.Insert(txn, conn, dbTxn);

                dbTxn.Commit();
                _auditLog.Log("Withdrawal", $"Withdrew {amount:C} from account #{accountId}. New balance: {newBalance:C}.");
                return (true, $"Withdrew {amount:C} successfully. New balance: {newBalance:C}");
            }
            catch (Exception ex)
            {
                dbTxn.Rollback();
                return (false, $"Withdrawal failed: {ex.Message}");
            }
        }

    
        /// Transfers money between two accounts using MySQL transaction (commit/rollback).
        public (bool success, string message) Transfer(int fromAccountId, int toAccountId, decimal amount, string description = "")
        {
            if (amount <= 0)
                return (false, "Transfer amount must be positive.");

            if (fromAccountId == toAccountId)
                return (false, "Cannot transfer to the same account.");

            var fromAccount = _accountDAL.GetById(fromAccountId);
            var toAccount = _accountDAL.GetById(toAccountId);

            if (fromAccount == null) return (false, "Source account not found.");
            if (toAccount == null) return (false, "Destination account not found.");
            if (fromAccount.Status != "Active") return (false, "Source account is not active.");
            if (toAccount.Status != "Active") return (false, "Destination account is not active.");

            // Check minimum balance
            var accountBLL = new AccountBLL();
            decimal minBalance = accountBLL.GetMinBalance(fromAccount.AccountType);
            decimal newFromBalance = fromAccount.Balance - amount;

            if (newFromBalance < minBalance)
                return (false, $"Insufficient funds. Minimum balance: {minBalance:C}. " +
                              $"Maximum transfer: {(fromAccount.Balance - minBalance):C}");

            decimal newToBalance = toAccount.Balance + amount;

            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var dbTxn = conn.BeginTransaction();

            try
            {
                // Debit source
                _accountDAL.UpdateBalance(fromAccountId, newFromBalance, conn, dbTxn);
                // Credit destination
                _accountDAL.UpdateBalance(toAccountId, newToBalance, conn, dbTxn);

                var txn = new Transaction
                {
                    FromAccountID = fromAccountId,
                    ToAccountID = toAccountId,
                    Amount = amount,
                    Type = "Transfer",
                    Description = string.IsNullOrWhiteSpace(description)
                        ? $"Transfer from #{fromAccountId} to #{toAccountId}" : description
                };
                _transactionDAL.Insert(txn, conn, dbTxn);

                dbTxn.Commit();
                _auditLog.Log("Transfer",
                    $"Transferred {amount:C} from account #{fromAccountId} to #{toAccountId}.");
                return (true, $"Transferred {amount:C} successfully.\n" +
                             $"Source balance: {newFromBalance:C}\n" +
                             $"Destination balance: {newToBalance:C}");
            }
            catch (Exception ex)
            {
                dbTxn.Rollback();
                return (false, $"Transfer failed: {ex.Message}");
            }
        }
    }
}
