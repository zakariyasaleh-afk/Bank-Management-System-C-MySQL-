using MySql.Data.MySqlClient;
using BankManagementSystem.Models;

namespace BankManagementSystem.DAL
{
    public class AuditLogDAL
    {
        public void Insert(AuditLog log)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"INSERT INTO AuditLogs (UserID, Action, Details)
                  VALUES (@uid, @action, @details);", conn);
            cmd.Parameters.AddWithValue("@uid", log.UserID.HasValue ? log.UserID.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@action", log.Action);
            cmd.Parameters.AddWithValue("@details", log.Details);
            cmd.ExecuteNonQuery();
        }

        public List<AuditLog> GetAll(int limit = 200)
        {
            var logs = new List<AuditLog>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT al.*, COALESCE(u.Username, 'System') AS Username
                  FROM AuditLogs al
                  LEFT JOIN Users u ON al.UserID = u.UserID
                  ORDER BY al.Timestamp DESC
                  LIMIT @limit;", conn);
            cmd.Parameters.AddWithValue("@limit", limit);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                logs.Add(MapLog(reader));
            return logs;
        }

        public List<AuditLog> GetByDateRange(DateTime start, DateTime end)
        {
            var logs = new List<AuditLog>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT al.*, COALESCE(u.Username, 'System') AS Username
                  FROM AuditLogs al
                  LEFT JOIN Users u ON al.UserID = u.UserID
                  WHERE al.Timestamp BETWEEN @start AND @end
                  ORDER BY al.Timestamp DESC;", conn);
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                logs.Add(MapLog(reader));
            return logs;
        }

        public List<AuditLog> GetRecent(int count = 20)
        {
            var logs = new List<AuditLog>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT al.*, COALESCE(u.Username, 'System') AS Username
                  FROM AuditLogs al
                  LEFT JOIN Users u ON al.UserID = u.UserID
                  ORDER BY al.Timestamp DESC
                  LIMIT @count;", conn);
            cmd.Parameters.AddWithValue("@count", count);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                logs.Add(MapLog(reader));
            return logs;
        }

        private static AuditLog MapLog(MySqlDataReader reader)
        {
            return new AuditLog
            {
                LogID = reader.GetInt32("LogID"),
                UserID = reader.IsDBNull(reader.GetOrdinal("UserID")) ? null : reader.GetInt32("UserID"),
                Action = reader.GetString("Action"),
                Details = reader.IsDBNull(reader.GetOrdinal("Details")) ? "" : reader.GetString("Details"),
                Timestamp = reader.GetDateTime("Timestamp"),
                Username = reader.GetString("Username")
            };
        }
    }
}
