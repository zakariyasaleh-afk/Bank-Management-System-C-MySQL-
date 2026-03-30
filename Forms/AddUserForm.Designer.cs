namespace BankManagementSystem.Forms
{
    partial class AddUserForm
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
            this.lblFullName = new Label();
            this.txtFullName = new TextBox();
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblRole = new Label();
            this.cmbRole = new ComboBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.lblStatus = new Label();

            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Padding = new Padding(30);

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Size = new System.Drawing.Size(440, 35);
            this.lblTitle.Text = "Add New Staff Member";

            int y = 75;
            this.lblFullName.Text = "Full Name *";
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblFullName.Location = new System.Drawing.Point(30, y);
            this.lblFullName.AutoSize = true;
            this.txtFullName.Location = new System.Drawing.Point(30, y + 25);
            this.txtFullName.Size = new System.Drawing.Size(440, 32);
            this.txtFullName.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.txtFullName.ForeColor = System.Drawing.Color.White;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFullName.BorderStyle = BorderStyle.FixedSingle;

            y += 75;
            this.lblUsername.Text = "Username *";
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblUsername.Location = new System.Drawing.Point(30, y);
            this.lblUsername.AutoSize = true;
            this.txtUsername.Location = new System.Drawing.Point(30, y + 25);
            this.txtUsername.Size = new System.Drawing.Size(440, 32);
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.txtUsername.ForeColor = System.Drawing.Color.White;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.BorderStyle = BorderStyle.FixedSingle;

            y += 75;
            this.lblRole.Text = "Role *";
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblRole.Location = new System.Drawing.Point(30, y);
            this.lblRole.AutoSize = true;
            this.cmbRole.Location = new System.Drawing.Point(30, y + 25);
            this.cmbRole.Size = new System.Drawing.Size(440, 32);
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.Items.AddRange(new object[] { "Employee", "Admin" });
            this.cmbRole.SelectedIndex = 0;
            this.cmbRole.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.cmbRole.ForeColor = System.Drawing.Color.White;

            y += 85;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(40, 180, 100);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(30, y);
            this.btnSave.Size = new System.Drawing.Size(200, 42);
            this.btnSave.Text = "💾 Create User";
            this.btnSave.Cursor = Cursors.Hand;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(100, 100, 130);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(250, y);
            this.btnCancel.Size = new System.Drawing.Size(120, 42);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(220, 60, 60);
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(30, y + 55);
            this.lblStatus.Size = new System.Drawing.Size(440, 25);

            this.pnlMain.Controls.AddRange(new Control[] {
                lblTitle, lblFullName, txtFullName, lblUsername, txtUsername,
                lblRole, cmbRole, btnSave, btnCancel, lblStatus
            });

            this.ClientSize = new System.Drawing.Size(520, y + 100);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add User";

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel pnlMain;
        private Label lblTitle, lblFullName, lblUsername, lblRole, lblStatus;
        private TextBox txtFullName, txtUsername;
        private ComboBox cmbRole;
        private Button btnSave, btnCancel;
    }
}
