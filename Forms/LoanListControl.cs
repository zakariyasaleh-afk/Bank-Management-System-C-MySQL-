using BankManagementSystem.BLL;
using BankManagementSystem.Models;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    public partial class LoanListControl : UserControl
    {
        private readonly LoanBLL _loanBLL = new();

        public LoanListControl()
        {
            InitializeComponent();
            this.Load += (s, e) => {
                LoadLoans();
                // RBAC: Only admin can approve/reject
                btnApprove.Enabled = SessionManager.IsAdmin;
                btnReject.Enabled = SessionManager.IsAdmin;
            };

            // Wire events missing in Designer
            btnCreate.Click += BtnCreate_Click;
            btnApprove.Click += BtnApprove_Click;
            btnReject.Click += BtnReject_Click;
            btnPayment.Click += BtnPayment_Click;
        }

        private void LoadLoans()
        {
            var loans = _loanBLL.GetAll();
            dgvLoans.DataSource = loans.Select(l => new
            {
                l.LoanID,
                Customer = l.CustomerName,
                Amount = l.Amount.ToString("C"),
                Rate = $"{l.InterestRate}%",
                l.Status,
                TotalDue = _loanBLL.CalculateTotalRepayment(l).ToString("C"),
                Paid = _loanBLL.GetTotalRepaid(l.LoanID).ToString("C"),
                Start = l.StartDate.ToString("yyyy-MM-dd"),
                End = l.EndDate.ToString("yyyy-MM-dd")
            }).ToList();

            StyleGrid();
        }

        private void StyleGrid()
        {
            dgvLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoans.ReadOnly = true;
            dgvLoans.AllowUserToAddRows = false;
            dgvLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoans.RowHeadersVisible = false;
            dgvLoans.BackgroundColor = ThemeManager.Surface;
            dgvLoans.DefaultCellStyle.BackColor = ThemeManager.Surface;
            dgvLoans.DefaultCellStyle.ForeColor = ThemeManager.TextColor;
            dgvLoans.ColumnHeadersDefaultCellStyle.BackColor = ThemeManager.CardColor;
            dgvLoans.ColumnHeadersDefaultCellStyle.ForeColor = ThemeManager.TextColor;
            dgvLoans.EnableHeadersVisualStyles = false;
            dgvLoans.BorderStyle = BorderStyle.None;
        }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            var form = new LoanCreateForm();
            if (form.ShowDialog() == DialogResult.OK) LoadLoans();
        }

        private int GetSelectedLoanId()
        {
            if (dgvLoans.SelectedRows.Count == 0) return -1;
            return Convert.ToInt32(dgvLoans.SelectedRows[0].Cells["LoanID"].Value);
        }

        private void BtnApprove_Click(object? sender, EventArgs e)
        {
            int id = GetSelectedLoanId();
            if (id < 0) return;
            var (success, message) = _loanBLL.ApproveLoan(id, SessionManager.CurrentUserID);
            MessageBox.Show(message, success ? "Success" : "Error");
            if (success) LoadLoans();
        }

        private void BtnReject_Click(object? sender, EventArgs e)
        {
            int id = GetSelectedLoanId();
            if (id < 0) return;
            var (success, message) = _loanBLL.RejectLoan(id);
            MessageBox.Show(message, success ? "Success" : "Error");
            if (success) LoadLoans();
        }

        private void BtnPayment_Click(object? sender, EventArgs e)
        {
            int id = GetSelectedLoanId();
            if (id < 0) return;
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter payment amount:", "Record Payment", "0");
            if (decimal.TryParse(input, out decimal amount))
            {
                var (success, message) = _loanBLL.RecordPayment(id, amount);
                MessageBox.Show(message);
                if (success) LoadLoans();
            }
        }
    }
}
