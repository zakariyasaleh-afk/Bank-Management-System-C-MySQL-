namespace BankManagementSystem.Forms
{
    partial class CustomerListControl
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
            this.lblTotalTitle = new Label();
            this.lblTotalCount = new Label();
            this.lblNewTitle = new Label();
            this.lblNewThisMonth = new Label();
            this.pnlActions = new Panel();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.txtSearch = new TextBox();
            this.lblSearch = new Label();
            this.dgvCustomers = new DataGridView();

            this.pnlHubHeader.SuspendLayout();
            this.pnlHubStats.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvCustomers).BeginInit();
            this.SuspendLayout();

            // CustomerListControl
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.Size = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlHubStats);
            this.Controls.Add(this.pnlHubHeader);

            // pnlHubHeader
            this.pnlHubHeader.Dock = DockStyle.Top;
            this.pnlHubHeader.Height = 50;
            this.lblHubTitle.Text = "Customer Relationship Hub";
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
            this.pnlHubStats.Controls.AddRange(new Control[] { lblNewThisMonth, lblNewTitle, lblTotalCount, lblTotalTitle });

            this.lblTotalTitle.Text = "TOTAL RECORDS:";
            this.lblTotalTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTotalTitle.AutoSize = true;

            this.lblTotalCount.Text = "0";
            this.lblTotalCount.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.lblTotalCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblTotalCount.Location = new System.Drawing.Point(140, 20);
            this.lblTotalCount.AutoSize = true;

            this.lblNewTitle.Text = "NEW (30D):";
            this.lblNewTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblNewTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNewTitle.Location = new System.Drawing.Point(250, 25);
            this.lblNewTitle.AutoSize = true;

            this.lblNewThisMonth.Text = "0";
            this.lblNewThisMonth.ForeColor = System.Drawing.Color.FromArgb(46, 160, 67);
            this.lblNewThisMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblNewThisMonth.Location = new System.Drawing.Point(330, 20);
            this.lblNewThisMonth.AutoSize = true;

            // pnlActions
            this.pnlActions.Dock = DockStyle.Top;
            this.pnlActions.Height = 60;
            this.pnlActions.Padding = new Padding(25, 12, 25, 12);
            this.pnlActions.Controls.AddRange(new Control[] { btnEdit, btnAdd, txtSearch, lblSearch });

            this.btnAdd.Text = "+ Add Customer";
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Location = new System.Drawing.Point(25, 12);
            this.btnAdd.Size = new System.Drawing.Size(130, 36);

            this.btnEdit.Text = "Edit Profile";
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(165, 12);
            this.btnEdit.Size = new System.Drawing.Size(100, 36);

            this.lblSearch.Text = "SEARCH:";
            this.lblSearch.ForeColor = System.Drawing.Color.Gray;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(600, 22);
            this.lblSearch.AutoSize = true;

            this.txtSearch.Location = new System.Drawing.Point(660, 18);
            this.txtSearch.Size = new System.Drawing.Size(300, 25);
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = BorderStyle.FixedSingle;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // dgvCustomers
            this.dgvCustomers.Dock = DockStyle.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.FromArgb(18, 18, 18);

            this.pnlHubHeader.ResumeLayout(false);
            this.pnlHubHeader.PerformLayout();
            this.pnlHubStats.ResumeLayout(false);
            this.pnlHubStats.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvCustomers).EndInit();
            this.ResumeLayout(false);
        }

        private Panel pnlHubHeader, pnlHubStats, pnlActions;
        private Label lblHubTitle, lblTotalTitle, lblTotalCount, lblNewTitle, lblNewThisMonth, lblSearch;
        private Button btnAdd, btnEdit;
        private TextBox txtSearch;
        private DataGridView dgvCustomers;
    }
}
