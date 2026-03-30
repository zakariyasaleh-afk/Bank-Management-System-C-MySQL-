namespace BankManagementSystem.Forms
{
    partial class LoanListControl
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
            this.btnCreate = new Button();
            this.btnApprove = new Button();
            this.btnReject = new Button();
            this.btnPayment = new Button();
            this.dgvLoans = new DataGridView();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvLoans).BeginInit();
            this.SuspendLayout();

            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(35, 40, 65);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.Padding = new Padding(15, 12, 15, 12);
            this.pnlTop.Controls.AddRange(new Control[] { btnPayment, btnReject, btnApprove, btnCreate });

            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(40, 180, 100);
            this.btnCreate.Dock = DockStyle.Left;
            this.btnCreate.FlatStyle = FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Size = new System.Drawing.Size(130, 36);
            this.btnCreate.Text = "+ New Loan";
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);

            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(50, 120, 230);
            this.btnApprove.Dock = DockStyle.Left;
            this.btnApprove.FlatStyle = FlatStyle.Flat;
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(145, 12);
            this.btnApprove.Size = new System.Drawing.Size(110, 36);
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.BtnApprove_Click);

            this.btnReject.BackColor = System.Drawing.Color.FromArgb(220, 60, 60);
            this.btnReject.Dock = DockStyle.Left;
            this.btnReject.FlatStyle = FlatStyle.Flat;
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(260, 12);
            this.btnReject.Size = new System.Drawing.Size(100, 36);
            this.btnReject.Text = "Reject";
            this.btnReject.Click += new System.EventHandler(this.BtnReject_Click);

            this.btnPayment.BackColor = System.Drawing.Color.FromArgb(160, 100, 230);
            this.btnPayment.Dock = DockStyle.Left;
            this.btnPayment.FlatStyle = FlatStyle.Flat;
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.Location = new System.Drawing.Point(365, 12);
            this.btnPayment.Size = new System.Drawing.Size(140, 36);
            this.btnPayment.Text = "Record Payment";
            this.btnPayment.Click += new System.EventHandler(this.BtnPayment_Click);

            this.dgvLoans.Dock = DockStyle.Fill;
            this.dgvLoans.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 46);

            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 46);
            this.Controls.Add(this.dgvLoans);
            this.Controls.Add(this.pnlTop);
            this.Size = new System.Drawing.Size(1060, 660);

            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvLoans).EndInit();
            this.ResumeLayout(false);
        }

        private Panel pnlTop;
        private Button btnCreate, btnApprove, btnReject, btnPayment;
        private DataGridView dgvLoans;
    }
}
