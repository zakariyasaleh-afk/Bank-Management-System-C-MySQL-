using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    public partial class MainForm : Form
    {
        private Control? _currentControl;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            SetupNavigation();
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            lblUser.Text = SessionManager.CurrentUsername;
            lblRole.Text = SessionManager.CurrentUser?.Role ?? "Employee";
            lblLogo.Text = (SessionManager.CurrentUsername ?? "USER").ToUpper();
            
            // Default view
            ShowModule(new DashboardControl(), "Operational Overview", btnDashboard);
            
            // Enable dragging for borderless form
            pnlHeader.MouseDown += (s, ev) => {
                if (ev.Button == MouseButtons.Left) {
                    Capture = false;
                    Message m = Message.Create(Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
                    WndProc(ref m);
                }
            };
        }

        private void SetupNavigation()
        {
            btnDashboard.Click += (s, e) => ShowModule(new DashboardControl(), "Operational Overview", btnDashboard);
            btnCustomers.Click += (s, e) => ShowModule(new CustomerListControl(), "Customer Management Hub", btnCustomers);
            btnAccounts.Click += (s, e) => ShowModule(new AccountListControl(), "Account Portfolio Hub", btnAccounts);
            btnTransactions.Click += (s, e) => ShowModule(new TransactionControl(), "Transaction Registry", btnTransactions);
            btnLoans.Click += (s, e) => ShowModule(new LoanListControl(), "Loan Processing Hub", btnLoans);
            btnReports.Click += (s, e) => ShowModule(new ReportsControl(), "Analytics & Reporting", btnReports);
            btnSettings.Click += (s, e) => ShowModule(new SettingsControl(), "System Configuration", btnSettings);
            
            if (SessionManager.IsAdmin)
            {
                btnUsers.Visible = true;
                btnUsers.Click += (s, e) => ShowModule(new UserManagementControl(), "Administration", btnUsers);
            }
            else
            {
                btnUsers.Visible = false;
            }

            btnLogout.Click += (s, e) => {
                if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SessionManager.Logout();
                    this.Close(); // Close MainForm to return to the Program loop
                }
            };
            
            btnClose.Click += (s, e) => Application.Exit();
            btnMin.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
        }

        private void ShowModule(Control control, string title, Button activeBtn)
        {
            lblTitle.Text = title;
            
            // Highlighting active button
            foreach (Control c in pnlSidebar.Controls)
            {
                if (c is Button b && b.Tag?.ToString() == "nav")
                {
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Color.FromArgb(180, 180, 180);
                }
            }
            activeBtn.BackColor = Color.FromArgb(40, 40, 40);
            activeBtn.ForeColor = Color.White;

            // Swap controls
            pnlContent.Controls.Clear();
            _currentControl = control;
            control.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(control);
            
            // Re-apply theme to new control for good measure
            ThemeManager.ApplyTheme(control);
        }
    }
}
