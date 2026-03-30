namespace BankManagementSystem.Forms
{
    partial class AccountListControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHubHeader = new Panel();
            this.lblHubTitle = new Label();
            this.pnlHubStats = new Panel();
            this.lblAssetsTitle = new Label();
            this.lblTotalBalance = new Label();
            this.lblActiveTitle = new Label();
            this.lblActiveCount = new Label();
            this.pnlActions = new Panel();
            this.btnCreate = new Button();
            this.btnDeposit = new Button();
            this.btnWithdraw = new Button();
            this.txtSearch = new TextBox();
            this.lblSearch = new Label();
            this.dgvAccounts = new DataGridView();

            this.pnlHubHeader.SuspendLayout();
            this.pnlHubStats.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvAccounts).BeginInit();
            this.SuspendLayout();

            // AccountListControl
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.Size = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.dgvAccounts);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlHubStats);
            this.Controls.Add(this.pnlHubHeader);

            // pnlHubHeader
            this.pnlHubHeader.Dock = DockStyle.Top;
            this.pnlHubHeader.Height = 50;
            this.lblHubTitle.Text = "Portfolio Management Hub";
            this.lblHubTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblHubTitle.ForeColor = System.Drawing.Color.White;
            this.lblHubTitle.Location = new System.Drawing.Point(25, 10);
            this.lblHubTitle.AutoSize = true;
            this.pnlHubHeader.Controls.Add(this.lblHubTitle);

            // pnlHubStats
            this.pnlHubStats.Dock = DockStyle.Top;
            this.pnlHubStats.Height = 70;
            this.pnlHubStats.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            this.pnlHubStats.Padding = new Padding(25, 10, 25, 10);
            this.pnlHubStats.Controls.AddRange(new Control[] { lblActiveCount, lblActiveTitle, lblTotalBalance, lblAssetsTitle });

            this.lblAssetsTitle.Text = "TOTAL ASSETS:";
            this.lblAssetsTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblAssetsTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblAssetsTitle.Location = new System.Drawing.Point(30, 25);
            this.lblAssetsTitle.AutoSize = true;

            this.lblTotalBalance.Text = "$0.00";
            this.lblTotalBalance.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.lblTotalBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblTotalBalance.Location = new System.Drawing.Point(135, 20);
            this.lblTotalBalance.AutoSize = true;

            this.lblActiveTitle.Text = "ACTIVE ACCOUNTS:";
            this.lblActiveTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblActiveTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblActiveTitle.Location = new System.Drawing.Point(300, 25);
            this.lblActiveTitle.AutoSize = true;

            this.lblActiveCount.Text = "0";
            this.lblActiveCount.ForeColor = System.Drawing.Color.FromArgb(46, 160, 67);
            this.lblActiveCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblActiveCount.Location = new System.Drawing.Point(420, 20);
            this.lblActiveCount.AutoSize = true;

            // pnlActions
            this.pnlActions.Dock = DockStyle.Top;
            this.pnlActions.Height = 60;
            this.pnlActions.Padding = new Padding(25, 12, 25, 12);
            this.pnlActions.Controls.AddRange(new Control[] { btnWithdraw, btnDeposit, btnCreate, txtSearch, lblSearch });

            this.btnCreate.Text = "+ Open Account";
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnCreate.ForeColor = Color.White;
            this.btnCreate.FlatStyle = FlatStyle.Flat;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.Location = new System.Drawing.Point(25, 12);
            this.btnCreate.Size = new System.Drawing.Size(125, 36);

            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.btnDeposit.ForeColor = Color.White;
            this.btnDeposit.FlatStyle = FlatStyle.Flat;
            this.btnDeposit.Location = new System.Drawing.Point(160, 12);
            this.btnDeposit.Size = new System.Drawing.Size(85, 36);

            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.btnWithdraw.ForeColor = Color.White;
            this.btnWithdraw.FlatStyle = FlatStyle.Flat;
            this.btnWithdraw.Location = new System.Drawing.Point(255, 12);
            this.btnWithdraw.Size = new System.Drawing.Size(85, 36);

            this.lblSearch.Text = "SEARCH:";
            this.lblSearch.ForeColor = System.Drawing.Color.Gray;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(600, 22);
            this.lblSearch.AutoSize = true;

            this.txtSearch.Location = new System.Drawing.Point(665, 18);
            this.txtSearch.Size = new System.Drawing.Size(300, 25);
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = BorderStyle.FixedSingle;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // dgvAccounts
            this.dgvAccounts.Dock = DockStyle.Fill;
            this.dgvAccounts.BackgroundColor = System.Drawing.Color.FromArgb(18, 18, 18);

            this.pnlHubHeader.ResumeLayout(false);
            this.pnlHubHeader.PerformLayout();
            this.pnlHubStats.ResumeLayout(false);
            this.pnlHubStats.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvAccounts).EndInit();
            this.ResumeLayout(false);
        }

        private Panel pnlHubHeader, pnlHubStats, pnlActions;
        private Label lblHubTitle, lblAssetsTitle, lblTotalBalance, lblActiveTitle, lblActiveCount, lblSearch;
        private Button btnCreate, btnDeposit, btnWithdraw;
        private TextBox txtSearch;
        private DataGridView dgvAccounts;
    }
}
