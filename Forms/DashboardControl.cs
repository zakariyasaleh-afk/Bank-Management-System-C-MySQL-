using BankManagementSystem.BLL;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    public partial class DashboardControl : UserControl
    {
        private readonly CustomerBLL _customerBLL = new();
        private readonly AccountBLL _accountBLL = new();
        private readonly TransactionBLL _transactionBLL = new();
        private readonly AuditLogBLL _auditLogBLL = new();

        public DashboardControl()
        {
            InitializeComponent();
            this.Load += DashboardControl_Load;
        }

        private void DashboardControl_Load(object? sender, EventArgs e)
        {
            LoadStats();
            LoadRecentActivity();
        }

        private void LoadStats()
        {
            try
            {
                lblTotalCustomers.Text = _customerBLL.GetAll().Count.ToString("N0");
                lblTotalAccounts.Text = _accountBLL.GetAll().Count.ToString("N0");
                
                var accounts = _accountBLL.GetAll();
                lblTotalBalance.Text = accounts.Sum(a => a.Balance).ToString("C0");

                var today = DateTime.Today;
                lblTodayTransactions.Text = _transactionBLL.GetAll().Count(t => t.DateTime.Date == today).ToString("N0");
            }
            catch { /* Silent fail for stability */ }
        }

        private void LoadRecentActivity()
        {
            try
            {
                var logs = _auditLogBLL.GetAll().OrderByDescending(l => l.Timestamp).Take(15).ToList();
                dgvRecentActivity.DataSource = logs.Select(l => new {
                    Time = l.Timestamp.ToString("HH:mm"),
                    l.Action,
                    User = l.Username,
                    Details = (l.Details?.Length > 60) ? l.Details.Substring(0, 57) + "..." : l.Details
                }).ToList();

                StyleGrid();
            }
            catch { }
        }

        private void StyleGrid()
        {
            dgvRecentActivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecentActivity.BackgroundColor = ThemeManager.Background;
            dgvRecentActivity.DefaultCellStyle.BackColor = ThemeManager.Surface;
            dgvRecentActivity.DefaultCellStyle.ForeColor = ThemeManager.TextColor;
            dgvRecentActivity.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 45);
            dgvRecentActivity.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvRecentActivity.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
            dgvRecentActivity.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRecentActivity.EnableHeadersVisualStyles = false;
            dgvRecentActivity.ReadOnly = true;
            dgvRecentActivity.RowHeadersVisible = false;
            dgvRecentActivity.BorderStyle = BorderStyle.None;
            dgvRecentActivity.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRecentActivity.GridColor = Color.FromArgb(45, 45, 45);
        }
    }
}
