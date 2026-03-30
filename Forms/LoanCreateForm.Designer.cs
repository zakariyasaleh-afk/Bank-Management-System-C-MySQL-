namespace BankManagementSystem.Forms
{
    partial class LoanCreateForm
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
            this.lblAmount = new Label();
            this.nudAmount = new NumericUpDown();
            this.lblRate = new Label();
            this.nudRate = new NumericUpDown();
            this.lblStart = new Label();
            this.dtpStart = new DateTimePicker();
            this.lblEnd = new Label();
            this.dtpEnd = new DateTimePicker();
            this.btnCreate = new Button();
            this.btnCancel = new Button();
            this.lblStatus = new Label();

            ((System.ComponentModel.ISupportInitialize)this.nudAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudRate).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Padding = new Padding(30);

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Size = new System.Drawing.Size(400, 35);
            this.lblTitle.Text = "Request New Loan";

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
            this.lblAmount.Text = "Loan Amount *";
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblAmount.Location = new System.Drawing.Point(30, y);
            this.lblAmount.AutoSize = true;
            this.nudAmount.Location = new System.Drawing.Point(30, y + 25);
            this.nudAmount.Size = new System.Drawing.Size(190, 32);
            this.nudAmount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudAmount.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.nudAmount.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.nudAmount.ForeColor = System.Drawing.Color.White;
            this.nudAmount.DecimalPlaces = 2;

            this.lblRate.Text = "Interest Rate % *";
            this.lblRate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRate.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblRate.Location = new System.Drawing.Point(240, y);
            this.lblRate.AutoSize = true;
            this.nudRate.Location = new System.Drawing.Point(240, y + 25);
            this.nudRate.Size = new System.Drawing.Size(190, 32);
            this.nudRate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudRate.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudRate.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.nudRate.ForeColor = System.Drawing.Color.White;
            this.nudRate.DecimalPlaces = 2;
            this.nudRate.Value = 5;

            y += 75;
            this.lblStart.Text = "Start Date *";
            this.lblStart.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStart.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblStart.Location = new System.Drawing.Point(30, y);
            this.lblStart.AutoSize = true;
            this.dtpStart.Location = new System.Drawing.Point(30, y + 25);
            this.dtpStart.Size = new System.Drawing.Size(190, 27);

            this.lblEnd.Text = "End Date *";
            this.lblEnd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEnd.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblEnd.Location = new System.Drawing.Point(240, y);
            this.lblEnd.AutoSize = true;
            this.dtpEnd.Location = new System.Drawing.Point(240, y + 25);
            this.dtpEnd.Size = new System.Drawing.Size(190, 27);
            this.dtpEnd.Value = DateTime.Today.AddYears(1);

            y += 85;
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(40, 180, 100);
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(30, y);
            this.btnCreate.Size = new System.Drawing.Size(200, 42);
            this.btnCreate.Text = "Submit Request";
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

            this.pnlMain.Controls.AddRange(new Control[] { lblTitle, lblCustomer, cmbCustomer, lblAmount, nudAmount, lblRate, nudRate, lblStart, dtpStart, lblEnd, dtpEnd, btnCreate, btnCancel, lblStatus });

            this.ClientSize = new System.Drawing.Size(470, y + 100);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "New Loan";

            ((System.ComponentModel.ISupportInitialize)this.nudAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudRate).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel pnlMain;
        private Label lblTitle, lblCustomer, lblAmount, lblRate, lblStart, lblEnd, lblStatus;
        private ComboBox cmbCustomer;
        private NumericUpDown nudAmount, nudRate;
        private DateTimePicker dtpStart, dtpEnd;
        private Button btnCreate, btnCancel;
    }
}
