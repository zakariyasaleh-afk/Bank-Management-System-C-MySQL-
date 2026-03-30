using MySql.Data.MySqlClient;
using BankManagementSystem.Models;

namespace BankManagementSystem.DAL
{
    public class CustomerDAL
    {
        public List<Customer> GetAll()
        {
            var customers = new List<Customer>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("SELECT * FROM Customers ORDER BY FullName;", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                customers.Add(MapCustomer(reader));
            return customers;
        }

        public Customer? GetById(int id)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT * FROM Customers WHERE CustomerID = @id;", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return MapCustomer(reader);
            return null;
        }

        public List<Customer> Search(string query)
        {
            var customers = new List<Customer>();
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"SELECT * FROM Customers
                  WHERE FullName LIKE @q OR NationalID LIKE @q OR Phone LIKE @q OR Email LIKE @q
                  ORDER BY FullName;", conn);
            cmd.Parameters.AddWithValue("@q", $"%{query}%");
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                customers.Add(MapCustomer(reader));
            return customers;
        }

        public int Insert(Customer customer)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"INSERT INTO Customers (FullName, DOB, Phone, Email, Address, NationalID)
                  VALUES (@name, @dob, @phone, @email, @address, @nid);
                  SELECT LAST_INSERT_ID();", conn);
            cmd.Parameters.AddWithValue("@name", customer.FullName);
            cmd.Parameters.AddWithValue("@dob", customer.DOB);
            cmd.Parameters.AddWithValue("@phone", customer.Phone);
            cmd.Parameters.AddWithValue("@email", customer.Email);
            cmd.Parameters.AddWithValue("@address", customer.Address);
            cmd.Parameters.AddWithValue("@nid", customer.NationalID);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Update(Customer customer)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"UPDATE Customers SET FullName = @name, DOB = @dob, Phone = @phone,
                  Email = @email, Address = @address, NationalID = @nid
                  WHERE CustomerID = @id;", conn);
            cmd.Parameters.AddWithValue("@id", customer.CustomerID);
            cmd.Parameters.AddWithValue("@name", customer.FullName);
            cmd.Parameters.AddWithValue("@dob", customer.DOB);
            cmd.Parameters.AddWithValue("@phone", customer.Phone);
            cmd.Parameters.AddWithValue("@email", customer.Email);
            cmd.Parameters.AddWithValue("@address", customer.Address);
            cmd.Parameters.AddWithValue("@nid", customer.NationalID);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "DELETE FROM Customers WHERE CustomerID = @id;", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public bool NationalIDExists(string nationalId, int excludeId = 0)
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM Customers WHERE NationalID = @nid AND CustomerID != @excludeId;", conn);
            cmd.Parameters.AddWithValue("@nid", nationalId);
            cmd.Parameters.AddWithValue("@excludeId", excludeId);
            return Convert.ToInt64(cmd.ExecuteScalar()) > 0;
        }

        public int GetTotalCount()
        {
            using var conn = DbConnectionManager.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM Customers;", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private static Customer MapCustomer(MySqlDataReader reader)
        {
            return new Customer
            {
                CustomerID = reader.GetInt32("CustomerID"),
                FullName = reader.GetString("FullName"),
                DOB = reader.GetDateTime("DOB"),
                Phone = reader.GetString("Phone"),
                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString("Email"),
                Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? "" : reader.GetString("Address"),
                NationalID = reader.GetString("NationalID"),
                CreatedAt = reader.GetDateTime("CreatedAt")
            };
        }
    }
}
