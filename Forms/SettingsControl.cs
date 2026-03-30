using BankManagementSystem.BLL;
using BankManagementSystem.Helpers;
using MySql.Data.MySqlClient;

namespace BankManagementSystem.Forms
{
    public partial class SettingsControl : UserControl
    {
        private readonly UserBLL _userBLL = new();

        public SettingsControl()
        {
            InitializeComponent();
            chkDarkMode.Checked = ThemeManager.IsDarkMode;
            chkDarkMode.CheckedChanged += (s, e) => {
                ThemeManager.IsDarkMode = chkDarkMode.Checked;
                ThemeManager.ApplyTheme(this.ParentForm); // Apply to the whole application shell
            };
        }

        private void ChangePassword()
        {
            lblPasswordStatus.ForeColor = System.Drawing.Color.FromArgb(220, 60, 60);
            var (success, message) = _userBLL.ChangePassword(
                SessionManager.CurrentUserID,
                txtCurrentPassword.Text,
                txtNewPassword.Text,
                txtConfirmPassword.Text);

            if (success)
            {
                lblPasswordStatus.ForeColor = System.Drawing.Color.FromArgb(40, 180, 100);
                lblPasswordStatus.Text = "✓ Changed!";
                txtCurrentPassword.Text = txtNewPassword.Text = txtConfirmPassword.Text = "";
            }
            else
            {
                lblPasswordStatus.Text = message;
            }
        }

        private void BackupDatabase()
        {
            if (!SessionManager.IsAdmin)
            {
                MessageBox.Show("Only admins can perform database backups.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var sfd = new SaveFileDialog { Filter = "SQL Files|*.sql", FileName = $"BankDB_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql" };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var conn = DAL.DbConnectionManager.GetConnection();
                using var cmd = new MySqlCommand();
                conn.Open();
                
                // MySqlBackup.Net usage - typically in MySql.Data.MySqlClient namespace in this library
                using var backup = new MySqlBackup(cmd);
                cmd.Connection = conn;
                backup.ExportToFile(sfd.FileName);
                
                MessageBox.Show("Database backup exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new AuditLogBLL().Log("Database Backup", $"Backup exported to {sfd.FileName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Backup failed: {ex.Message}\n\nMake sure the database is accessible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
