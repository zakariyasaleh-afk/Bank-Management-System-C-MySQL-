namespace BankManagementSystem.Forms
{
    partial class TransactionDialogForm
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
            this.lblBalance = new Label();
            this.lblAmount = new Label();
            this.nudAmount = new NumericUpDown();
            this.lblDesc = new Label();
            this.txtDescription = new TextBox();
            this.btnConfirm = new Button();
            this.btnCancel = new Button();
            this.lblStatus = new Label();

            ((System.ComponentModel.ISupportInitialize)this.nudAmount).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Padding = new Padding(30);

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Size = new System.Drawing.Size(400, 35);

            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(180, 185, 200);
            this.lblBalance.Location = new System.Drawing.Point(30, 55);
            this.lblBalance.Size = new System.Drawing.Size(400, 25);

            int y = 100;
            this.lblAmount.Text = "Amount *";
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblAmount.Location = new System.Drawing.Point(30, y);
            this.lblAmount.AutoSize = true;

            this.nudAmount.Location = new System.Drawing.Point(30, y + 25);
            this.nudAmount.Size = new System.Drawing.Size(370, 32);
            this.nudAmount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudAmount.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.nudAmount.ForeColor = System.Drawing.Color.White;
            this.nudAmount.DecimalPlaces = 2;

            y += 75;
            this.lblDesc.Text = "Description";
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDesc.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblDesc.Location = new System.Drawing.Point(30, y);
            this.lblDesc.AutoSize = true;

            this.txtDescription.Location = new System.Drawing.Point(30, y + 25);
            this.txtDescription.Size = new System.Drawing.Size(370, 32);
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.txtDescription.ForeColor = System.Drawing.Color.White;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.BorderStyle = BorderStyle.FixedSingle;

            y += 85;
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(40, 180, 100);
            this.btnConfirm.FlatStyle = FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(30, y);
            this.btnConfirm.Size = new System.Drawing.Size(200, 42);
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);

            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(100, 100, 130);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(240, y);
            this.btnCancel.Size = new System.Drawing.Size(120, 42);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += (s, e) => this.Close();

            y += 55;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(220, 60, 60);
            this.lblStatus.Location = new System.Drawing.Point(30, y);
            this.lblStatus.Size = new System.Drawing.Size(370, 25);

            this.pnlMain.Controls.AddRange(new Control[] { lblTitle, lblBalance, lblAmount, nudAmount, lblDesc, txtDescription, btnConfirm, btnCancel, lblStatus });

            this.ClientSize = new System.Drawing.Size(430, y + 100);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)this.nudAmount).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel pnlMain;
        private Label lblTitle, lblBalance, lblAmount, lblDesc, lblStatus;
        private TextBox txtDescription;
        private NumericUpDown nudAmount;
        private Button btnConfirm, btnCancel;
    }
}
