using MySql.Data.MySqlClient;
using BankManagementSystem.Models;

namespace BankManagementSystem.DAL
{
    public class UserDAL
    {
        public User? GetByUsername(string username)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT * FROM Users WHERE Username = @username;", conn);
            cmd.Parameters.AddWithValue("@username", username);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return MapUser(reader);
            return null;
        }

        public User? GetById(int userId)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT * FROM Users WHERE UserID = @id;", conn);
            cmd.Parameters.AddWithValue("@id", userId);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return MapUser(reader);
            return null;
        }

        public List<User> GetAll()
        {
            var users = new List<User>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("SELECT * FROM Users ORDER BY CreatedAt DESC;", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                users.Add(MapUser(reader));
            return users;
        }

        public int Insert(User user)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"INSERT INTO Users (Username, PasswordHash, FullName, Role, Status, MustChangePassword)
                  VALUES (@username, @hash, @fullname, @role, @status, @mustChange);
                  SELECT LAST_INSERT_ID();", conn);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@hash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@fullname", user.FullName);
            cmd.Parameters.AddWithValue("@role", user.Role);
            cmd.Parameters.AddWithValue("@status", user.Status);
            cmd.Parameters.AddWithValue("@mustChange", user.MustChangePassword ? 1 : 0);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Update(User user)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"UPDATE Users SET Username = @username, PasswordHash = @hash,
                  FullName = @fullname, Role = @role, Status = @status,
                  MustChangePassword = @mustChange
                  WHERE UserID = @id;", conn);
            cmd.Parameters.AddWithValue("@id", user.UserID);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@hash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@fullname", user.FullName);
            cmd.Parameters.AddWithValue("@role", user.Role);
            cmd.Parameters.AddWithValue("@status", user.Status);
            cmd.Parameters.AddWithValue("@mustChange", user.MustChangePassword ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public void UpdatePassword(int userId, string passwordHash, bool mustChange = false)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"UPDATE Users SET PasswordHash = @hash, MustChangePassword = @mustChange
                  WHERE UserID = @id;", conn);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.Parameters.AddWithValue("@hash", passwordHash);
            cmd.Parameters.AddWithValue("@mustChange", mustChange ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int userId)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "UPDATE Users SET Status = 'Inactive' WHERE UserID = @id;", conn);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        public bool UsernameExists(string username, int excludeUserId = 0)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM Users WHERE Username = @username AND UserID != @excludeId;", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@excludeId", excludeUserId);
            return Convert.ToInt64(cmd.ExecuteScalar()) > 0;
        }

        public int GetUserCount()
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM Users;", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private static User MapUser(MySqlDataReader reader)
        {
            return new User
            {
                UserID = reader.GetInt32("UserID"),
                Username = reader.GetString("Username"),
                PasswordHash = reader.GetString("PasswordHash"),
                FullName = reader.GetString("FullName"),
                Role = reader.GetString("Role"),
                Status = reader.GetString("Status"),
                MustChangePassword = reader.GetBoolean("MustChangePassword"),
                CreatedAt = reader.GetDateTime("CreatedAt")
            };
        }
    }
}
