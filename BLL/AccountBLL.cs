using BankManagementSystem.DAL;
using BankManagementSystem.Models;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.BLL
{
    public class AccountBLL
    {
        private readonly AccountDAL _accountDAL = new();
        private readonly AuditLogBLL _auditLog = new();

        public List<Account> GetAll() => _accountDAL.GetAll();
        public Account? GetById(int id) => _accountDAL.GetById(id);
        public List<Account> GetByCustomerId(int customerId) => _accountDAL.GetByCustomerId(customerId);
        public List<Account> Search(string query) => _accountDAL.Search(query);
        public int GetTotalCount() => _accountDAL.GetTotalCount();
        public decimal GetTotalBalance() => _accountDAL.GetTotalBalance();
        public Dictionary<string, int> GetCountByType() => _accountDAL.GetCountByType();
        public Dictionary<string, decimal> GetBalanceByType() => _accountDAL.GetBalanceByType();

        public (bool success, string message, int accountId) CreateAccount(int customerId, string accountType, decimal initialDeposit)
        {
            // Validate account type
            if (accountType != "Savings" && accountType != "Current" && accountType != "FixedDeposit")
                return (false, "Invalid account type.", 0);

            // Minimum deposit is now 0 as per user request to allow full flexibility
            decimal minBalance = 0;

            if (initialDeposit < minBalance)
                return (false, $"Minimum initial deposit for {accountType} account is {minBalance:C}.", 0);

            var account = new Account
            {
                CustomerID = customerId,
                AccountType = accountType,
                Balance = initialDeposit,
                Status = "Active"
            };

            int id = _accountDAL.Insert(account);
            _auditLog.Log("Account Created",
                $"Account #{id} ({accountType}) created for customer #{customerId} with initial deposit {initialDeposit:C}.");
            return (true, $"Account created successfully. Account ID: {id}", id);
        }

        public (bool success, string message) CloseAccount(int accountId)
        {
            var account = _accountDAL.GetById(accountId);
            if (account == null) return (false, "Account not found.");
            if (account.Status == "Closed") return (false, "Account is already closed.");
            if (account.Balance > 0) return (false, $"Account has a balance of {account.Balance:C}. Withdraw all funds before closing.");

            _accountDAL.UpdateStatus(accountId, "Closed");
            _auditLog.Log("Account Closed", $"Account #{accountId} was closed.");
            return (true, "Account closed successfully.");
        }

        public (bool success, string message) FreezeAccount(int accountId)
        {
            var account = _accountDAL.GetById(accountId);
            if (account == null) return (false, "Account not found.");
            if (account.Status != "Active") return (false, "Only active accounts can be frozen.");

            _accountDAL.UpdateStatus(accountId, "Frozen");
            _auditLog.Log("Account Frozen", $"Account #{accountId} was frozen.");
            return (true, "Account frozen successfully.");
        }

        public (bool success, string message) UnfreezeAccount(int accountId)
        {
            var account = _accountDAL.GetById(accountId);
            if (account == null) return (false, "Account not found.");
            if (account.Status != "Frozen") return (false, "Only frozen accounts can be unfrozen.");

            _accountDAL.UpdateStatus(accountId, "Active");
            _auditLog.Log("Account Unfrozen", $"Account #{accountId} was unfrozen.");
            return (true, "Account unfrozen successfully.");
        }

        /// Gets the minimum balance for an account type.
        public decimal GetMinBalance(string accountType)
        {
            return 0; // Allow full withdrawal as per user request
        }
    }
}
