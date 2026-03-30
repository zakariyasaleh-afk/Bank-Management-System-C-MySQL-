using BankManagementSystem.BLL;
using BankManagementSystem.Models;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    public partial class AccountCreateForm : Form
    {
        private readonly AccountBLL _accountBLL = new();
        private readonly CustomerBLL _customerBLL = new();

        public AccountCreateForm()
        {
            InitializeComponent();
            LoadCustomers();
            cmbType.SelectedIndex = 0;
        }

        private void LoadCustomers()
        {
            var customers = _customerBLL.GetAll();
            cmbCustomer.DisplayMember = "Display";
            cmbCustomer.ValueMember = "ID";
            cmbCustomer.DataSource = customers.Select(c => new { Display = $"{c.FullName} (ID: {c.CustomerID})", ID = c.CustomerID }).ToList();
        }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null)
            {
                lblStatus.Text = "Please select a customer.";
                return;
            }

            int customerId = (int)cmbCustomer.SelectedValue;
            string type = cmbType.SelectedItem?.ToString() ?? "Savings";
            decimal initialDeposit = nudInitialDeposit.Value;

            var (success, message, _) = _accountBLL.CreateAccount(customerId, type, initialDeposit);

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
