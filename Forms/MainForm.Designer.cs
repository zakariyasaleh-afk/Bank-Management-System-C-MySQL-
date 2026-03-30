namespace BankManagementSystem.Forms
{
    partial class MainForm
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
            this.pnlSidebar = new Panel();
            this.pnlLogo = new Panel();
            this.lblLogo = new Label();
            this.btnDashboard = new Button();
            this.btnCustomers = new Button();
            this.btnAccounts = new Button();
            this.btnTransactions = new Button();
            this.btnLoans = new Button();
            this.btnReports = new Button();
            this.btnUsers = new Button();
            this.btnSettings = new Button();
            this.btnLogout = new Button();
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.pnlUser = new Panel();
            this.lblUser = new Label();
            this.lblRole = new Label();
            this.btnClose = new Button();
            this.btnMin = new Button();
            this.pnlContent = new Panel();

            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.SuspendLayout();

            // MainForm
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            this.pnlSidebar.Dock = DockStyle.Left;
            this.pnlSidebar.Width = 220;
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnSettings);
            this.pnlSidebar.Controls.Add(this.btnUsers);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.btnLoans);
            this.pnlSidebar.Controls.Add(this.btnTransactions);
            this.pnlSidebar.Controls.Add(this.btnAccounts);
            this.pnlSidebar.Controls.Add(this.btnCustomers);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.pnlLogo);

            // pnlLogo
            this.pnlLogo.Dock = DockStyle.Top;
            this.pnlLogo.Height = 80;
            this.lblLogo.Text = "BANK ADMIN";
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.lblLogo.Dock = DockStyle.Fill;
            this.pnlLogo.Controls.Add(this.lblLogo);

            // Button Styling Helper
            Action<Button, string> styleBtn = (b, txt) => {
                b.Text = "  " + txt;
                b.Dock = DockStyle.Top;
                b.Height = 45;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.TextAlign = ContentAlignment.MiddleLeft;
                b.Padding = new Padding(20, 0, 0, 0);
                b.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
                b.Tag = "nav";
            };

            styleBtn(btnSettings, "Settings");
            styleBtn(btnUsers, "Administration");
            styleBtn(btnReports, "Reports");
            styleBtn(btnLoans, "Loans");
            styleBtn(btnTransactions, "Transactions");
            styleBtn(btnAccounts, "Accounts");
            styleBtn(btnCustomers, "Customers");
            styleBtn(btnDashboard, "Dashboard");

            // btnLogout
            this.btnLogout.Text = "  Logout";
            this.btnLogout.Dock = DockStyle.Bottom;
            this.btnLogout.Height = 50;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.ForeColor = System.Drawing.Color.IndianRed;
            this.btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            this.btnLogout.Padding = new Padding(20, 0, 0, 0);
            this.btnLogout.Cursor = Cursors.Hand;

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 60;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.pnlUser);
            this.pnlHeader.Controls.Add(this.btnMin);
            this.pnlHeader.Controls.Add(this.btnClose);

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 0);
            this.lblTitle.Size = new System.Drawing.Size(400, 60);
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            this.lblTitle.Text = "Operational Overview";

            // btnClose / btnMin
            this.btnClose.Text = "✕";
            this.btnClose.Location = new System.Drawing.Point(1165, 5);
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.ForeColor = Color.Gray;

            this.btnMin.Text = "—";
            this.btnMin.Location = new System.Drawing.Point(1135, 5);
            this.btnMin.Size = new System.Drawing.Size(30, 30);
            this.btnMin.FlatStyle = FlatStyle.Flat;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.ForeColor = Color.Gray;

            // pnlUser
            this.pnlUser.Location = new System.Drawing.Point(850, 10);
            this.pnlUser.Size = new System.Drawing.Size(270, 40);
            this.pnlUser.Controls.Add(this.lblUser);
            this.pnlUser.Controls.Add(this.lblRole);

            this.lblUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblUser.ForeColor = Color.White;
            this.lblUser.Location = new System.Drawing.Point(0, 0);
            this.lblUser.Size = new System.Drawing.Size(270, 20);
            this.lblUser.TextAlign = ContentAlignment.MiddleRight;

            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.lblRole.Location = new System.Drawing.Point(0, 20);
            this.lblRole.Size = new System.Drawing.Size(270, 15);
            this.lblRole.TextAlign = ContentAlignment.MiddleRight;

            // pnlContent
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Panel pnlSidebar, pnlHeader, pnlContent, pnlLogo, pnlUser;
        private Label lblLogo, lblTitle, lblUser, lblRole;
        private Button btnDashboard, btnCustomers, btnAccounts, btnTransactions, btnLoans, btnReports, btnUsers, btnSettings, btnLogout;
        private Button btnClose, btnMin;
    }
}
