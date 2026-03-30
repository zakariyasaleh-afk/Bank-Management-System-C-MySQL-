using BankManagementSystem.DAL;
using BankManagementSystem.Models;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.BLL
{
    public class AuditLogBLL
    {
        private readonly AuditLogDAL _auditLogDAL = new();

        public void Log(string action, string details = "")
        {
            var log = new AuditLog
            {
                UserID = SessionManager.IsLoggedIn ? SessionManager.CurrentUserID : null,
                Action = action,
                Details = details
            };
            try
            {
                _auditLogDAL.Insert(log);
            }
            catch
            {
                // Silently fail — audit logging should never break the app
            }
        }

        public List<AuditLog> GetAll(int limit = 200) => _auditLogDAL.GetAll(limit);
        public List<AuditLog> GetByDateRange(DateTime start, DateTime end) => _auditLogDAL.GetByDateRange(start, end);
        public List<AuditLog> GetRecent(int count = 20) => _auditLogDAL.GetRecent(count);
    }
}
