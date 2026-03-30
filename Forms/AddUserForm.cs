using BankManagementSystem.BLL;
using BankManagementSystem.Models;

namespace BankManagementSystem.Forms
{
    public partial class AddUserForm : Form
    {
        private readonly UserBLL _userBLL = new();

        public AddUserForm()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            lblStatus.Text = "";
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString() ?? "Employee";

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(username))
            {
                lblStatus.Text = "Please fill in all required fields.";
                return;
            }

            var (success, message, tempPassword) = _userBLL.AddUser(username, fullName, role);

            if (success)
            {
                MessageBox.Show($"{message}\n\nTEMPORARY PASSWORD: {tempPassword}\n\nPlease provide this to the user. They must change it upon first login.",
                    "User Created Succesfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
