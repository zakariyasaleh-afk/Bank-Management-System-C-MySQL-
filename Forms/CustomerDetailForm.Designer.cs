namespace BankManagementSystem.Forms
{
    partial class CustomerDetailForm
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
            this.txtFullName = new TextBox();
            this.dtpDOB = new DateTimePicker();
            this.txtPhone = new TextBox();
            this.txtEmail = new TextBox();
            this.txtAddress = new TextBox();
            this.txtNationalID = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.lblStatus = new Label();
            this.pnlAccounts = new Panel();
            this.dgvAccounts = new DataGridView();
            this.lblAccountsTitle = new Label();

            this.pnlMain.SuspendLayout();
            this.pnlAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvAccounts).BeginInit();
            this.SuspendLayout();

            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.AutoScroll = true;

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Size = new System.Drawing.Size(500, 35);

            int y = 70;
            AddLabel("Full Name *", y);
            this.txtFullName.Location = new System.Drawing.Point(30, y + 25); this.txtFullName.Size = new System.Drawing.Size(440, 30);
            
            y += 70;
            AddLabel("National ID *", y);
            this.txtNationalID.Location = new System.Drawing.Point(30, y + 25); this.txtNationalID.Size = new System.Drawing.Size(210, 30);
            
            AddLabel("Date of Birth", y, 260);
            this.dtpDOB.Location = new System.Drawing.Point(260, y + 25); this.dtpDOB.Size = new System.Drawing.Size(210, 30);

            y += 70;
            AddLabel("Phone", y);
            this.txtPhone.Location = new System.Drawing.Point(30, y + 25); this.txtPhone.Size = new System.Drawing.Size(210, 30);

            AddLabel("Email", y, 260);
            this.txtEmail.Location = new System.Drawing.Point(260, y + 25); this.txtEmail.Size = new System.Drawing.Size(210, 30);

            y += 70;
            AddLabel("Address", y);
            this.txtAddress.Location = new System.Drawing.Point(30, y + 25); this.txtAddress.Size = new System.Drawing.Size(440, 30);

            y += 75;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(40, 180, 100);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(30, y);
            this.btnSave.Size = new System.Drawing.Size(210, 42);
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(100, 100, 130);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(260, y);
            this.btnCancel.Size = new System.Drawing.Size(120, 42);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += (s, e) => this.Close();

            y += 50;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(220, 60, 60);
            this.lblStatus.Location = new System.Drawing.Point(30, y);
            this.lblStatus.Size = new System.Drawing.Size(440, 25);

            y += 40;
            this.pnlAccounts.Location = new System.Drawing.Point(0, y);
            this.pnlAccounts.Size = new System.Drawing.Size(530, 250);
            this.pnlAccounts.Controls.Add(this.dgvAccounts);
            this.pnlAccounts.Controls.Add(this.lblAccountsTitle);

            this.lblAccountsTitle.Text = "Customer Accounts";
            this.lblAccountsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAccountsTitle.ForeColor = System.Drawing.Color.White;
            this.lblAccountsTitle.Location = new System.Drawing.Point(30, 10);
            this.lblAccountsTitle.Size = new System.Drawing.Size(200, 25);

            this.dgvAccounts.Location = new System.Drawing.Point(30, 45);
            this.dgvAccounts.Size = new System.Drawing.Size(440, 150);

            this.pnlMain.Controls.AddRange(new Control[] { lblTitle, txtFullName, txtNationalID, dtpDOB, txtPhone, txtEmail, txtAddress, btnSave, btnCancel, lblStatus, pnlAccounts });

            this.ClientSize = new System.Drawing.Size(530, 700);
            this.Controls.Add(this.pnlMain);
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            this.pnlMain.ResumeLayout(false);
            this.pnlAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvAccounts).EndInit();
            this.ResumeLayout(false);
        }

        private void AddLabel(string text, int y, int x = 30)
        {
            Label lbl = new Label { Text = text, Location = new System.Drawing.Point(x, y), AutoSize = true, ForeColor = System.Drawing.Color.FromArgb(200, 205, 220) };
            this.pnlMain.Controls.Add(lbl);
        }

        private Panel pnlMain, pnlAccounts;
        private Label lblTitle, lblAccountsTitle, lblStatus;
        private TextBox txtFullName, txtPhone, txtEmail, txtAddress, txtNationalID;
        private DateTimePicker dtpDOB;
        private DataGridView dgvAccounts;
        private Button btnSave, btnCancel;
    }
}
