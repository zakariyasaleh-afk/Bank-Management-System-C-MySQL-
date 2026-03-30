namespace BankManagementSystem.Forms
{
    partial class AccountCreateForm
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
            this.pnlMain = new Panel();
            this.lblTitle = new Label();
            this.lblCustomer = new Label();
            this.cmbCustomer = new ComboBox();
            this.lblType = new Label();
            this.cmbType = new ComboBox();
            this.lblDeposit = new Label();
            this.nudInitialDeposit = new NumericUpDown();
            this.btnCreate = new Button();
            this.btnCancel = new Button();
            this.lblStatus = new Label();

            ((System.ComponentModel.ISupportInitialize)this.nudInitialDeposit).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Padding = new Padding(30);

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Size = new System.Drawing.Size(400, 35);
            this.lblTitle.Text = "Open New Account";

            int y = 75;
            this.lblCustomer.Text = "Customer *";
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblCustomer.Location = new System.Drawing.Point(30, y);
            this.lblCustomer.AutoSize = true;
            this.cmbCustomer.Location = new System.Drawing.Point(30, y + 25);
            this.cmbCustomer.Size = new System.Drawing.Size(400, 32);
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCustomer.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.cmbCustomer.ForeColor = System.Drawing.Color.White;

            y += 75;
            this.lblType.Text = "Account Type *";
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblType.Location = new System.Drawing.Point(30, y);
            this.lblType.AutoSize = true;
            this.cmbType.Location = new System.Drawing.Point(30, y + 25);
            this.cmbType.Size = new System.Drawing.Size(400, 32);
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbType.Items.AddRange(new object[] { "Savings", "Current", "FixedDeposit" });
            this.cmbType.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.cmbType.ForeColor = System.Drawing.Color.White;

            y += 75;
            this.lblDeposit.Text = "Initial Deposit *";
            this.lblDeposit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDeposit.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblDeposit.Location = new System.Drawing.Point(30, y);
            this.lblDeposit.AutoSize = true;
            this.nudInitialDeposit.Location = new System.Drawing.Point(30, y + 25);
            this.nudInitialDeposit.Size = new System.Drawing.Size(400, 32);
            this.nudInitialDeposit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudInitialDeposit.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudInitialDeposit.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.nudInitialDeposit.ForeColor = System.Drawing.Color.White;
            this.nudInitialDeposit.DecimalPlaces = 2;

            y += 85;
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(40, 180, 100);
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(30, y);
            this.btnCreate.Size = new System.Drawing.Size(200, 42);
            this.btnCreate.Text = "Open Account";
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);

            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(100, 100, 130);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(250, y);
            this.btnCancel.Size = new System.Drawing.Size(120, 42);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += (s, e) => this.Close();

            y += 55;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(220, 60, 60);
            this.lblStatus.Location = new System.Drawing.Point(30, y);
            this.lblStatus.Size = new System.Drawing.Size(400, 25);

            this.pnlMain.Controls.AddRange(new Control[] { lblTitle, lblCustomer, cmbCustomer, lblType, cmbType, lblDeposit, nudInitialDeposit, btnCreate, btnCancel, lblStatus });

            this.ClientSize = new System.Drawing.Size(470, y + 100);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Create Account";

            ((System.ComponentModel.ISupportInitialize)this.nudInitialDeposit).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel pnlMain;
        private Label lblTitle, lblCustomer, lblType, lblDeposit, lblStatus;
        private ComboBox cmbCustomer, cmbType;
        private NumericUpDown nudInitialDeposit;
        private Button btnCreate, btnCancel;
    }
}
