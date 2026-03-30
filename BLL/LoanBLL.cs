using BankManagementSystem.DAL;
using BankManagementSystem.Models;

namespace BankManagementSystem.BLL
{
    public class LoanBLL
    {
        private readonly LoanDAL _loanDAL = new();
        private readonly LoanPaymentDAL _paymentDAL = new();
        private readonly AuditLogBLL _auditLog = new();

        public List<Loan> GetAll() => _loanDAL.GetAll();
        public Loan? GetById(int id) => _loanDAL.GetById(id);
        public List<Loan> GetByCustomerId(int customerId) => _loanDAL.GetByCustomerId(customerId);
        public int GetActiveCount() => _loanDAL.GetActiveCount();
        public Dictionary<string, int> GetCountByStatus() => _loanDAL.GetCountByStatus();

        public (bool success, string message) CreateLoan(int customerId, decimal amount, decimal interestRate,
            DateTime startDate, DateTime endDate)
        {
            if (amount <= 0)
                return (false, "Loan amount must be positive.");

            if (interestRate < 0 || interestRate > 100)
                return (false, "Interest rate must be between 0 and 100.");

            if (endDate <= startDate)
                return (false, "End date must be after start date.");

            if (startDate < DateTime.Today.AddDays(-1))
                return (false, "Start date cannot be in the past.");

            var loan = new Loan
            {
                CustomerID = customerId,
                Amount = amount,
                InterestRate = interestRate,
                Status = "Pending",
                StartDate = startDate,
                EndDate = endDate
            };

            int id = _loanDAL.Insert(loan);
            _auditLog.Log("Loan Created",
                $"Loan #{id} created for customer #{customerId}. Amount: {amount:C}, Rate: {interestRate}%.");
            return (true, $"Loan created successfully. Loan ID: {id}. Status: Pending approval.");
        }

        public (bool success, string message) ApproveLoan(int loanId, int approvedByUserId)
        {
            var loan = _loanDAL.GetById(loanId);
            if (loan == null) return (false, "Loan not found.");
            if (loan.Status != "Pending") return (false, "Only pending loans can be approved.");

            _loanDAL.UpdateStatus(loanId, "Approved", approvedByUserId);
            _auditLog.Log("Loan Approved",
                $"Loan #{loanId} approved by user #{approvedByUserId}. Amount: {loan.Amount:C}.");
            return (true, "Loan approved successfully.");
        }

        public (bool success, string message) RejectLoan(int loanId)
        {
            var loan = _loanDAL.GetById(loanId);
            if (loan == null) return (false, "Loan not found.");
            if (loan.Status != "Pending") return (false, "Only pending loans can be rejected.");

            _loanDAL.UpdateStatus(loanId, "Defaulted");
            _auditLog.Log("Loan Rejected", $"Loan #{loanId} was rejected.");
            return (true, "Loan rejected.");
        }

        public (bool success, string message) RecordPayment(int loanId, decimal amount)
        {
            if (amount <= 0) return (false, "Payment amount must be positive.");

            var loan = _loanDAL.GetById(loanId);
            if (loan == null) return (false, "Loan not found.");
            if (loan.Status != "Approved") return (false, "Can only make payments on approved loans.");

            decimal totalWithInterest = CalculateTotalRepayment(loan);
            decimal totalPaid = _paymentDAL.GetTotalPayments(loanId);
            decimal remaining = totalWithInterest - totalPaid;

            if (amount > remaining)
                return (false, $"Payment exceeds remaining balance. Remaining: {remaining:C}");

            var payment = new LoanPayment
            {
                LoanID = loanId,
                Amount = amount
            };
            _paymentDAL.Insert(payment);

            // Check if loan is fully paid
            totalPaid += amount;
            if (totalPaid >= totalWithInterest)
            {
                _loanDAL.UpdateStatus(loanId, "Paid");
                _auditLog.Log("Loan Fully Paid", $"Loan #{loanId} has been fully repaid.");
            }

            _auditLog.Log("Loan Payment",
                $"Payment of {amount:C} recorded for loan #{loanId}. Remaining: {(remaining - amount):C}.");
            return (true, $"Payment of {amount:C} recorded successfully. Remaining: {(remaining - amount):C}");
        }

        public List<LoanPayment> GetPayments(int loanId) => _paymentDAL.GetByLoanId(loanId);

        public decimal GetTotalRepaid(int loanId) => _paymentDAL.GetTotalPayments(loanId);

      
        /// Calculates total repayment amount with simple interest.
        /// Formula: Principal + (Principal * Rate * Years / 100)
    
        public decimal CalculateTotalRepayment(Loan loan)
        {
            double years = (loan.EndDate - loan.StartDate).TotalDays / 365.25;
            decimal interest = loan.Amount * loan.InterestRate * (decimal)years / 100m;
            return loan.Amount + interest;
        }

      
        public decimal GetRemainingBalance(int loanId)
        {
            var loan = _loanDAL.GetById(loanId);
            if (loan == null) return 0;

            decimal total = CalculateTotalRepayment(loan);
            decimal paid = _paymentDAL.GetTotalPayments(loanId);
            return total - paid;
        }
    }
}
