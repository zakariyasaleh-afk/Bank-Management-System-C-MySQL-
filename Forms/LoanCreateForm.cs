using BankManagementSystem.BLL;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    public partial class LoanCreateForm : Form
    {
        private readonly LoanBLL _loanBLL = new();
        private readonly CustomerBLL _customerBLL = new();

        public LoanCreateForm()
        {
            InitializeComponent();
            LoadCustomers();
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
            decimal amount = nudAmount.Value;
            decimal rate = nudRate.Value;
            DateTime start = dtpStart.Value.Date;
            DateTime end = dtpEnd.Value.Date;

            if (end <= start)
            {
                lblStatus.Text = "End date must be after start date.";
                return;
            }

            var (success, message) = _loanBLL.CreateLoan(customerId, amount, rate, start, end);

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
