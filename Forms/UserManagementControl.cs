using BankManagementSystem.BLL;
using BankManagementSystem.Models;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    public partial class UserManagementControl : UserControl
    {
        private readonly UserBLL _userBLL = new();

        public UserManagementControl()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                var users = _userBLL.GetAllUsers();
                dgvUsers.DataSource = users.Select(u => new
                {
                    u.UserID,
                    u.Username,
                    u.FullName,
                    u.Role,
                    u.Status,
                    MustChange = u.MustChangePassword ? "Yes" : "No",
                    Created = u.CreatedAt.ToString("yyyy-MM-dd HH:mm")
                }).ToList();

                StyleGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleGrid()
        {
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.BackgroundColor = ThemeManager.Surface;
            dgvUsers.DefaultCellStyle.BackColor = ThemeManager.Surface;
            dgvUsers.DefaultCellStyle.ForeColor = ThemeManager.TextColor;
            dgvUsers.DefaultCellStyle.SelectionBackColor = ThemeManager.AccentColor;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = ThemeManager.TextColor;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.BorderStyle = BorderStyle.None;
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var form = new AddUserForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadUsers();
        }

        private void BtnDeactivate_Click(object? sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            
            if (userId == SessionManager.CurrentUserID)
            {
                MessageBox.Show("You cannot deactivate your own account.", "Action Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to deactivate this user? They will no longer be able to log in.",
                "Confirm Deactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (confirm == DialogResult.Yes)
            {
                var (success, message) = _userBLL.DeactivateUser(userId);
                MessageBox.Show(message, success ? "Success" : "Error", MessageBoxButtons.OK, 
                    success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (success) LoadUsers();
            }
        }

        private void BtnReactivate_Click(object? sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);

            var (success, message) = _userBLL.ReactivateUser(userId);
            MessageBox.Show(message, success ? "Success" : "Error", MessageBoxButtons.OK,
                success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (success) LoadUsers();
        }
    }
}
