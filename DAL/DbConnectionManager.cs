using MySql.Data.MySqlClient;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.DAL
{
  
    /// Central MySQL connection manager.
    /// All DAL classes use this to obtain connections.
    public static class DbConnectionManager
    {
        public static MySqlConnection GetConnection()
        {
            string connStr = AppConfig.GetConnectionString();
            return new MySqlConnection(connStr);
        }

        
        /// Tests the database connection. Returns true if successful.
        public static bool TestConnection(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using var conn = GetConnection();
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

       
        // Initializes the database schema and seeds the default admin user if needed.
        // Called on application startup.

        public static void InitializeDatabase()
        {
            // First, connect without specifying a database to create it if needed
            var cfg = AppConfig.GetConnectionString();
            string connStrNoDB = cfg.Replace("Database=BankManagementDB;", "");

            using (var conn = new MySqlConnection(connStrNoDB))
            {
                conn.Open();
                using var cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS BankManagementDB;", conn);
                cmd.ExecuteNonQuery();
            }

            // Now create all tables
            using (var conn = GetConnection())
            {
                conn.Open();
                string schemaScript = GetEmbeddedSchema();
                // Execute each statement separately
                var statements = schemaScript.Split(';',
                    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                foreach (var stmt in statements)
                {
                    if (string.IsNullOrWhiteSpace(stmt) || stmt.StartsWith("--")) continue;
                    try
                    {
                        using var cmd = new MySqlCommand(stmt + ";", conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException)
                    {
                        // Table already exists — skip
                    }
                }
            }

            // Seeds no longer needed - handled by FirstRunSetupForm
        }

        private static string GetEmbeddedSchema()
        {
            return @"
CREATE TABLE IF NOT EXISTS Users (
    UserID          INT AUTO_INCREMENT PRIMARY KEY,
    Username        VARCHAR(50)  NOT NULL UNIQUE,
    PasswordHash    VARCHAR(255) NOT NULL,
    FullName        VARCHAR(100) NOT NULL,
    Role            ENUM('Admin','Employee') NOT NULL DEFAULT 'Employee',
    Status          ENUM('Active','Inactive') NOT NULL DEFAULT 'Active',
    MustChangePassword TINYINT(1) NOT NULL DEFAULT 0,
    CreatedAt       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_users_username (Username),
    INDEX idx_users_role (Role)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS Customers (
    CustomerID      INT AUTO_INCREMENT PRIMARY KEY,
    FullName        VARCHAR(100) NOT NULL,
    DOB             DATE         NOT NULL,
    Phone           VARCHAR(20)  NOT NULL,
    Email           VARCHAR(100),
    Address         VARCHAR(255),
    NationalID      VARCHAR(50)  NOT NULL UNIQUE,
    CreatedAt       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_customers_name (FullName),
    INDEX idx_customers_nationalid (NationalID),
    INDEX idx_customers_phone (Phone)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS Accounts (
    AccountID       INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID      INT NOT NULL,
    AccountType     ENUM('Savings','Current','FixedDeposit') NOT NULL DEFAULT 'Savings',
    Balance         DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    Status          ENUM('Active','Frozen','Closed') NOT NULL DEFAULT 'Active',
    CreatedAt       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_accounts_customer FOREIGN KEY (CustomerID)
        REFERENCES Customers(CustomerID) ON DELETE RESTRICT,
    INDEX idx_accounts_customerid (CustomerID),
    INDEX idx_accounts_status (Status),
    INDEX idx_accounts_type (AccountType)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS Transactions (
    TransactionID   INT AUTO_INCREMENT PRIMARY KEY,
    FromAccountID   INT,
    ToAccountID     INT,
    Amount          DECIMAL(18,2) NOT NULL,
    Type            ENUM('Deposit','Withdraw','Transfer') NOT NULL,
    Description     VARCHAR(255),
    DateTime        DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_transactions_from FOREIGN KEY (FromAccountID)
        REFERENCES Accounts(AccountID) ON DELETE RESTRICT,
    CONSTRAINT fk_transactions_to FOREIGN KEY (ToAccountID)
        REFERENCES Accounts(AccountID) ON DELETE RESTRICT,
    INDEX idx_transactions_from (FromAccountID),
    INDEX idx_transactions_to (ToAccountID),
    INDEX idx_transactions_datetime (DateTime),
    INDEX idx_transactions_type (Type)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS Loans (
    LoanID          INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID      INT NOT NULL,
    Amount          DECIMAL(18,2) NOT NULL,
    InterestRate    DECIMAL(5,2)  NOT NULL,
    Status          ENUM('Pending','Approved','Paid','Defaulted') NOT NULL DEFAULT 'Pending',
    StartDate       DATE NOT NULL,
    EndDate         DATE NOT NULL,
    ApprovedBy      INT,
    CreatedAt       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_loans_customer FOREIGN KEY (CustomerID)
        REFERENCES Customers(CustomerID) ON DELETE RESTRICT,
    CONSTRAINT fk_loans_approver FOREIGN KEY (ApprovedBy)
        REFERENCES Users(UserID) ON DELETE SET NULL,
    INDEX idx_loans_customerid (CustomerID),
    INDEX idx_loans_status (Status)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS LoanPayments (
    PaymentID       INT AUTO_INCREMENT PRIMARY KEY,
    LoanID          INT NOT NULL,
    Amount          DECIMAL(18,2) NOT NULL,
    PaymentDate     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_loanpayments_loan FOREIGN KEY (LoanID)
        REFERENCES Loans(LoanID) ON DELETE RESTRICT,
    INDEX idx_loanpayments_loanid (LoanID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS AuditLogs (
    LogID           INT AUTO_INCREMENT PRIMARY KEY,
    UserID          INT,
    Action          VARCHAR(500) NOT NULL,
    Details         TEXT,
    Timestamp       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_auditlogs_user FOREIGN KEY (UserID)
        REFERENCES Users(UserID) ON DELETE SET NULL,
    INDEX idx_auditlogs_userid (UserID),
    INDEX idx_auditlogs_timestamp (Timestamp)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";
        }
    }
}
