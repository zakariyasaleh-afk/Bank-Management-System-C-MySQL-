using BankManagementSystem.BLL;
using BankManagementSystem.Models;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    public partial class TransactionControl : UserControl
    {
        private readonly TransactionBLL _transactionBLL = new();

        public TransactionControl()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadTransactions();
        }

        private void LoadTransactions()
        {
            dgvTransactions.DataSource = null;
            var txs = _transactionBLL.GetAll();
            dgvTransactions.DataSource = txs.Select(t => new
            {
                t.TransactionID,
                t.Type,
                Amount = t.Amount.ToString("C"),
                From = t.FromAccountID?.ToString() ?? "-",
                To = t.ToAccountID?.ToString() ?? "-",
                t.Description,
                Date = t.DateTime.ToString("yyyy-MM-dd HH:mm")
            }).ToList();

            StyleGrid();
        }

        private void StyleGrid()
        {
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.ReadOnly = true;
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.BackgroundColor = ThemeManager.Surface;
            dgvTransactions.DefaultCellStyle.BackColor = ThemeManager.Surface;
            dgvTransactions.DefaultCellStyle.ForeColor = ThemeManager.TextColor;
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = ThemeManager.CardColor;
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = ThemeManager.TextColor;
            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.BorderStyle = BorderStyle.None;
        }

        private void BtnTransfer_Click(object? sender, EventArgs e)
        {
            // Simple transfer dialog placeholder or logic
            MessageBox.Show("Use the Accounts menu to perform Deposits/Withdrawals. Transfer feature coming soon.", "Info");
        }
    }
}
