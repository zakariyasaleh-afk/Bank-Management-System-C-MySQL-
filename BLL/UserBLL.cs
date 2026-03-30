using BankManagementSystem.DAL;
using BankManagementSystem.Models;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.BLL
{
    public class UserBLL
    {
        private readonly UserDAL _userDAL = new();
        private readonly AuditLogBLL _auditLog = new();

        /// <summary>
        /// Authenticates a user. Returns the User object if successful, null otherwise.
        /// </summary>
        public int GetUserCount() => _userDAL.GetUserCount();

        public (User? user, string message) Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return (null, "Username and password are required.");

            var user = _userDAL.GetByUsername(username);
            if (user == null)
                return (null, "Invalid username or password.");

            if (user.Status != "Active")
                return (null, "This account has been deactivated. Contact administrator.");

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return (null, "Invalid username or password.");

            return (user, "Login successful.");
        }

        /// <summary>
        /// Changes a user's password. Used for forced change on first login and normal changes.
        /// </summary>
        public (bool success, string message) ChangePassword(int userId, string currentPassword, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                return (false, "New password cannot be empty.");

            if (newPassword.Length < 8)
                return (false, "Password must be at least 8 characters long.");

            if (newPassword != confirmPassword)
                return (false, "Passwords do not match.");

            var user = _userDAL.GetById(userId);
            if (user == null)
                return (false, "User not found.");

            // Verify current password (skip if forced change with temporary password)
            if (!string.IsNullOrEmpty(currentPassword) && !BCrypt.Net.BCrypt.Verify(currentPassword, user.PasswordHash))
                return (false, "Current password is incorrect.");

            // Check that new password is different from current
            if (BCrypt.Net.BCrypt.Verify(newPassword, user.PasswordHash))
                return (false, "New password must be different from current password.");

            string newHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            _userDAL.UpdatePassword(userId, newHash, false);

            _auditLog.Log("Password Changed", $"User '{user.Username}' changed their password.");

            return (true, "Password changed successfully.");
        }

        /// <summary>
        /// Forces username and password change on first login.
        /// </summary>
        public (bool success, string message) ForceCredentialChange(int userId, string newUsername, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(newUsername))
                return (false, "New username cannot be empty.");

            if (newUsername.Length < 4)
                return (false, "Username must be at least 4 characters long.");

            if (string.IsNullOrWhiteSpace(newPassword))
                return (false, "New password cannot be empty.");

            if (newPassword.Length < 8)
                return (false, "Password must be at least 8 characters long.");

            if (newPassword != confirmPassword)
                return (false, "Passwords do not match.");

            // Check username uniqueness
            if (_userDAL.UsernameExists(newUsername, userId))
                return (false, "This username is already taken.");

            var user = _userDAL.GetById(userId);
            if (user == null)
                return (false, "User not found.");

            // Don't allow keeping the default username
            if (newUsername.ToLower() == "admin" && user.MustChangePassword)
                return (false, "You must choose a different username than 'admin'.");

            user.Username = newUsername;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            user.MustChangePassword = false;
            _userDAL.Update(user);

            _auditLog.Log("Credentials Changed (First Login)", $"User changed default credentials. New username: '{newUsername}'.");

            // Delete the first-run credentials file if it exists
            string tempFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FIRST_RUN_CREDENTIALS.txt");
            if (File.Exists(tempFile))
            {
                try { File.Delete(tempFile); } catch { }
            }

            return (true, "Credentials updated successfully. Please log in with your new credentials.");
        }

        public (bool success, string message, string tempPassword) AddUser(string username, string fullName, string role)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length < 4)
                return (false, "Username must be at least 4 characters.", "");

            if (string.IsNullOrWhiteSpace(fullName))
                return (false, "Full name is required.", "");

            if (_userDAL.UsernameExists(username))
                return (false, "Username already exists.", "");

            // Generate a random temporary password
            string tempPassword = Guid.NewGuid().ToString("N").Substring(0, 8);

            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(tempPassword),
                FullName = fullName,
                Role = role,
                Status = "Active",
                MustChangePassword = true
            };

            _userDAL.Insert(user);
            _auditLog.Log("User Created", $"New {role} user '{username}' created with temporary password.");
            return (true, "User created successfully.", tempPassword);
        }

        public void CreateInitialAdmin(User admin)
        {
            _userDAL.Insert(admin);
            _auditLog.Log("Initial Setup", $"Administrator account '{admin.Username}' created during first-run setup.");
        }

        public List<User> GetAllUsers() => _userDAL.GetAll();

        public (bool success, string message) DeactivateUser(int userId)
        {
            var user = _userDAL.GetById(userId);
            if (user == null) return (false, "User not found.");
            
            user.Status = "Inactive";
            _userDAL.Update(user);
            _auditLog.Log("User Deactivated", $"User '{user.Username}' was set to Inactive.");
            return (true, $"User '{user.Username}' is now Inactive.");
        }

        public (bool success, string message) ReactivateUser(int userId)
        {
            var user = _userDAL.GetById(userId);
            if (user == null) return (false, "User not found.");

            user.Status = "Active";
            _userDAL.Update(user);
            _auditLog.Log("User Reactivated", $"User '{user.Username}' was reactivated.");
            return (true, $"User '{user.Username}' reactivated.");
        }
    }
}
