using BankManagementSystem.BLL;
using BankManagementSystem.Models;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    public partial class AccountListControl : UserControl
    {
        private readonly AccountBLL _accountBLL = new();

        public AccountListControl()
        {
            InitializeComponent();
            this.Load += AccountListControl_Load;
            
            // Wire events missing in Designer
            btnCreate.Click += BtnCreate_Click;
            btnDeposit.Click += BtnDeposit_Click;
            btnWithdraw.Click += BtnWithdraw_Click;
        }

        private void AccountListControl_Load(object? sender, EventArgs e)
        {
            LoadAccounts();
            LoadHubStats();
        }

        private void LoadHubStats()
        {
            try
            {
                var accounts = _accountBLL.GetAll();
                lblTotalBalance.Text = accounts.Sum(a => a.Balance).ToString("C0");
                lblActiveCount.Text = accounts.Count(a => a.Status == "Active").ToString();
            }
            catch { }
        }

        private void LoadAccounts()
        {
            try
            {
                var accounts = _accountBLL.GetAll();
                dgvAccounts.DataSource = accounts.Select(a => new
                {
                    ID = a.AccountID,
                    Customer = a.CustomerName,
                    Type = a.AccountType,
                    Balance = a.Balance.ToString("C"),
                    a.Status,
                    Created = a.CreatedAt.ToString("yyyy-MM-dd")
                }).ToList();

                StyleGrid();
            }
            catch { }
        }

        private void StyleGrid()
        {
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccounts.BackgroundColor = ThemeManager.Background;
            dgvAccounts.DefaultCellStyle.BackColor = ThemeManager.Surface;
            dgvAccounts.DefaultCellStyle.ForeColor = ThemeManager.TextColor;
            dgvAccounts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 45);
            dgvAccounts.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAccounts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
            dgvAccounts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAccounts.EnableHeadersVisualStyles = false;
            dgvAccounts.ReadOnly = true;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.RowHeadersVisible = false;
            dgvAccounts.BorderStyle = BorderStyle.None;
            dgvAccounts.GridColor = Color.FromArgb(45, 45, 45);
        }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            var form = new AccountCreateForm();
            if (form.ShowDialog() == DialogResult.OK) { LoadAccounts(); LoadHubStats(); }
        }

        private void BtnDeposit_Click(object? sender, EventArgs e)
        {
            var accountNum = GetSelectedAccountID();
            if (accountNum == 0) return;
            var account = _accountBLL.GetById(accountNum);
            if (account == null) return;
            var dialog = new TransactionDialogForm(account, "Deposit");
            if (dialog.ShowDialog() == DialogResult.OK) { LoadAccounts(); LoadHubStats(); }
        }

        private void BtnWithdraw_Click(object? sender, EventArgs e)
        {
            var accountNum = GetSelectedAccountID();
            if (accountNum == 0) return;
            var account = _accountBLL.GetById(accountNum);
            if (account == null) return;
            var dialog = new TransactionDialogForm(account, "Withdraw");
            if (dialog.ShowDialog() == DialogResult.OK) { LoadAccounts(); LoadHubStats(); }
        }

        private int GetSelectedAccountID()
        {
            if (dgvAccounts.SelectedRows.Count == 0) return 0;
            return Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells["ID"].Value);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string term = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(term)) { LoadAccounts(); return; }
            try
            {
                var results = _accountBLL.Search(term);
                dgvAccounts.DataSource = results.Select(a => new { ID = a.AccountID, Customer = a.CustomerName, Type = a.AccountType, Balance = a.Balance.ToString("C"), a.Status }).ToList();
            }
            catch { }
        }
    }
}
