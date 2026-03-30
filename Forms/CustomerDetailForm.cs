using BankManagementSystem.BLL;
using BankManagementSystem.Models;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    public partial class CustomerDetailForm : Form
    {
        private readonly CustomerBLL _customerBLL = new();
        private readonly AccountBLL _accountBLL = new();
        private readonly Customer? _customer;
        private readonly bool _isEdit;

        public CustomerDetailForm(Customer? customer = null)
        {
            InitializeComponent();
            _customer = customer;
            _isEdit = customer != null;

            if (_isEdit)
            {
                this.Text = "Edit Customer";
                lblTitle.Text = "Update Customer Profile";
                btnSave.Text = "Update Customer";
                FillCustomerData();
                LoadAccounts();
                pnlAccounts.Visible = true;
            }
            else
            {
                this.Text = "New Customer";
                lblTitle.Text = "Create New Customer Profile";
                btnSave.Text = "Save Customer";
                pnlAccounts.Visible = false;
                this.Height -= 250;
            }
        }

        private void FillCustomerData()
        {
            if (_customer == null) return;
            txtFullName.Text = _customer.FullName;
            dtpDOB.Value = _customer.DOB;
            txtPhone.Text = _customer.Phone;
            txtEmail.Text = _customer.Email;
            txtAddress.Text = _customer.Address;
            txtNationalID.Text = _customer.NationalID;
        }

        private void LoadAccounts()
        {
            if (_customer == null) return;
            var accounts = _accountBLL.GetByCustomerId(_customer.CustomerID);
            dgvAccounts.DataSource = accounts.Select(a => new { a.AccountID, a.AccountType, Balance = a.Balance.ToString("C"), a.Status }).ToList();
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            StyleGrid();
        }

        private void StyleGrid()
        {
            dgvAccounts.BackgroundColor = ThemeManager.Surface;
            dgvAccounts.DefaultCellStyle.BackColor = ThemeManager.Surface;
            dgvAccounts.DefaultCellStyle.ForeColor = ThemeManager.TextColor;
            dgvAccounts.ColumnHeadersDefaultCellStyle.BackColor = ThemeManager.CardColor;
            dgvAccounts.ColumnHeadersDefaultCellStyle.ForeColor = ThemeManager.TextColor;
            dgvAccounts.EnableHeadersVisualStyles = false;
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RowHeadersVisible = false;
            dgvAccounts.BorderStyle = BorderStyle.None;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var customer = _customer ?? new Customer();
            customer.FullName = txtFullName.Text.Trim();
            customer.DOB = dtpDOB.Value.Date;
            customer.Phone = txtPhone.Text.Trim();
            customer.Email = txtEmail.Text.Trim();
            customer.Address = txtAddress.Text.Trim();
            customer.NationalID = txtNationalID.Text.Trim();

            var result = _isEdit ? _customerBLL.Update(customer) : _customerBLL.Add(customer);

            if (result.success)
            {
                MessageBox.Show(result.message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblStatus.Text = result.message;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtNationalID.Text))
            {
                lblStatus.Text = "Full Name and National ID are required.";
                return false;
            }
            return true;
        }
    }
}
