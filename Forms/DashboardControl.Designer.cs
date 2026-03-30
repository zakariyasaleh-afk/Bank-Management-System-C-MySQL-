namespace BankManagementSystem.Forms
{
    partial class DashboardControl
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
            this.pnlTop = new Panel();
            this.lblTitle = new Label();
            this.pnlCards = new FlowLayoutPanel();
            this.card1 = new Panel();
            this.lblCard1Title = new Label();
            this.lblTotalCustomers = new Label();
            this.card2 = new Panel();
            this.lblCard2Title = new Label();
            this.lblTotalAccounts = new Label();
            this.card3 = new Panel();
            this.lblCard3Title = new Label();
            this.lblTotalBalance = new Label();
            this.card4 = new Panel();
            this.lblCard4Title = new Label();
            this.lblTodayTransactions = new Label();
            this.pnlMain = new Panel();
            this.lblLogTitle = new Label();
            this.dgvRecentActivity = new DataGridView();

            this.pnlTop.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.card1.SuspendLayout();
            this.card2.SuspendLayout();
            this.card3.SuspendLayout();
            this.card4.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvRecentActivity).BeginInit();
            this.SuspendLayout();

            // DashboardControl
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.Size = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlTop);

            // pnlTop
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;
            this.lblTitle.Text = "System Overview";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 15);
            this.lblTitle.AutoSize = true;
            this.pnlTop.Controls.Add(this.lblTitle);

            // pnlCards
            this.pnlCards.Dock = DockStyle.Top;
            this.pnlCards.Height = 130;
            this.pnlCards.Padding = new Padding(15, 0, 15, 0);
            this.pnlCards.Controls.AddRange(new Control[] { card1, card2, card3, card4 });

            // Stats Cards Styling
            Action<Panel, Label, Label, string, System.Drawing.Color> styleCard = (p, lt, lv, title, color) => {
                p.Size = new System.Drawing.Size(220, 100);
                p.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                p.Margin = new Padding(10);
                lt.Text = title; lt.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
                lt.ForeColor = System.Drawing.Color.Silver; lt.Location = new System.Drawing.Point(15, 15); lt.AutoSize = true;
                lv.Text = "0"; lv.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
                lv.ForeColor = color; lv.Location = new System.Drawing.Point(15, 45); lv.AutoSize = true;
                p.Controls.AddRange(new Control[] { lt, lv });
            };

            styleCard(card1, lblCard1Title, lblTotalCustomers, "CUSTOMERS", System.Drawing.Color.FromArgb(0, 120, 215));
            styleCard(card2, lblCard2Title, lblTotalAccounts, "ACCOUNTS", System.Drawing.Color.FromArgb(46, 160, 67));
            styleCard(card3, lblCard3Title, lblTotalBalance, "TOTAL ASSETS", System.Drawing.Color.FromArgb(210, 153, 34));
            styleCard(card4, lblCard4Title, lblTodayTransactions, "TODAY'S TXN", System.Drawing.Color.FromArgb(218, 54, 51));

            // pnlMain
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Padding = new Padding(25);
            this.pnlMain.Controls.Add(this.dgvRecentActivity);
            this.pnlMain.Controls.Add(this.lblLogTitle);

            this.lblLogTitle.Text = "RECENT SYSTEM AUDIT LOG";
            this.lblLogTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLogTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblLogTitle.Dock = DockStyle.Top;
            this.lblLogTitle.Height = 30;

            this.dgvRecentActivity.Dock = DockStyle.Fill;
            this.dgvRecentActivity.BackgroundColor = System.Drawing.Color.FromArgb(18, 18, 18);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.card1.ResumeLayout(false);
            this.card1.PerformLayout();
            this.card2.ResumeLayout(false);
            this.card2.PerformLayout();
            this.card3.ResumeLayout(false);
            this.card3.PerformLayout();
            this.card4.ResumeLayout(false);
            this.card4.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvRecentActivity).EndInit();
            this.ResumeLayout(false);
        }

        private Panel pnlTop, pnlCards, pnlMain;
        private Label lblTitle, lblLogTitle;
        private Panel card1, card2, card3, card4;
        private Label lblCard1Title, lblTotalCustomers;
        private Label lblCard2Title, lblTotalAccounts;
        private Label lblCard3Title, lblTotalBalance;
        private Label lblCard4Title, lblTodayTransactions;
        private DataGridView dgvRecentActivity;
    }
}
