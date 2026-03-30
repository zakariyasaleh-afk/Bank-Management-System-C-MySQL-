using BankManagementSystem.BLL;
using BankManagementSystem.Models;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    public partial class FirstRunSetupForm : Form
    {
        private readonly UserBLL _userBLL = new();

        public FirstRunSetupForm()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simple validation
            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.", "Security", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var adminUser = new User
            {
                FullName = fullName,
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = "Admin",
                Status = "Active",
                MustChangePassword = false
            };

            try
            {
                _userBLL.CreateInitialAdmin(adminUser);
                MessageBox.Show("Administrator account created successfully!\nYou can now log in with these credentials.", "Setup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create admin: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
