namespace BankManagementSystem.Forms
{
    partial class TransactionControl
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
            this.btnRefresh = new Button();
            this.dgvTransactions = new DataGridView();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvTransactions).BeginInit();
            this.SuspendLayout();

            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(35, 40, 65);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.Padding = new Padding(15);
            this.pnlTop.Controls.Add(this.lblTitle);

            this.lblTitle.Text = "Transaction History";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.AutoSize = true;

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(850, 15);
            this.btnRefresh.Size = new System.Drawing.Size(120, 30);
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.Click += (s, e) => LoadTransactions();
            this.pnlTop.Controls.Add(this.btnRefresh);

            this.dgvTransactions.Dock = DockStyle.Fill;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.FromArgb(18, 18, 18);

            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.pnlTop);
            this.Size = new System.Drawing.Size(1060, 660);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvTransactions).EndInit();
            this.ResumeLayout(false);
        }

        private Panel pnlTop;
        private Label lblTitle;
        private Button btnRefresh;
        private DataGridView dgvTransactions;
    }
}
