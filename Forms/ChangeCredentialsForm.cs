using BankManagementSystem.BLL;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    public partial class ChangeCredentialsForm : Form
    {
        private readonly UserBLL _userBLL = new();

        public ChangeCredentialsForm()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            lblStatus.ForeColor = Color.FromArgb(220, 60, 60);
            lblStatus.Text = "";

            string newUsername = txtNewUsername.Text.Trim();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            var (success, message) = _userBLL.ForceCredentialChange(
                SessionManager.CurrentUserID, newUsername, newPassword, confirmPassword);

            if (success)
            {
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblStatus.Text = message;
            }
        }
    }
}
