using BankManagementSystem.DAL;
using BankManagementSystem.Models;

namespace BankManagementSystem.BLL
{
    public class CustomerBLL
    {
        private readonly CustomerDAL _customerDAL = new();
        private readonly AuditLogBLL _auditLog = new();

        public List<Customer> GetAll() => _customerDAL.GetAll();
        public Customer? GetById(int id) => _customerDAL.GetById(id);
        public List<Customer> Search(string query) => _customerDAL.Search(query);
        public int GetTotalCount() => _customerDAL.GetTotalCount();

        public (bool success, string message) Add(Customer customer)
        {
            var validation = ValidateCustomer(customer);
            if (!validation.success) return validation;

            if (_customerDAL.NationalIDExists(customer.NationalID))
                return (false, "A customer with this National ID already exists.");

            int id = _customerDAL.Insert(customer);
            _auditLog.Log("Customer Added", $"Customer '{customer.FullName}' (ID: {id}) was added.");
            return (true, $"Customer added successfully. ID: {id}");
        }

        public (bool success, string message) Update(Customer customer)
        {
            var validation = ValidateCustomer(customer);
            if (!validation.success) return validation;

            if (_customerDAL.NationalIDExists(customer.NationalID, customer.CustomerID))
                return (false, "Another customer already has this National ID.");

            _customerDAL.Update(customer);
            _auditLog.Log("Customer Updated", $"Customer '{customer.FullName}' (ID: {customer.CustomerID}) was updated.");
            return (true, "Customer updated successfully.");
        }

        public (bool success, string message) Delete(int id)
        {
            var customer = _customerDAL.GetById(id);
            if (customer == null) return (false, "Customer not found.");

            // Check for linked accounts
            var accountDAL = new AccountDAL();
            var accounts = accountDAL.GetByCustomerId(id);
            if (accounts.Any(a => a.Status == "Active"))
                return (false, "Cannot delete customer with active accounts. Close all accounts first.");

            try
            {
                _customerDAL.Delete(id);
                _auditLog.Log("Customer Deleted", $"Customer '{customer.FullName}' (ID: {id}) was deleted.");
                return (true, "Customer deleted successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Cannot delete customer: {ex.Message}");
            }
        }

        private static (bool success, string message) ValidateCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FullName))
                return (false, "Full name is required.");

            if (customer.DOB > DateTime.Today.AddYears(-18))
                return (false, "Customer must be at least 18 years old.");

            if (string.IsNullOrWhiteSpace(customer.Phone))
                return (false, "Phone number is required.");

            if (string.IsNullOrWhiteSpace(customer.NationalID))
                return (false, "National ID is required.");

            if (!string.IsNullOrWhiteSpace(customer.Email) && !customer.Email.Contains('@'))
                return (false, "Invalid email address.");

            return (true, string.Empty);
        }
    }
}
