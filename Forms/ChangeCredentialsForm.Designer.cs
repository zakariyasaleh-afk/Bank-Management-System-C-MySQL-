namespace BankManagementSystem.Forms
{
    partial class ChangeCredentialsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMain = new Panel();
            this.lblTitle = new Label();
            this.lblInfo = new Label();
            this.lblNewUsername = new Label();
            this.txtNewUsername = new TextBox();
            this.lblNewPassword = new Label();
            this.txtNewPassword = new TextBox();
            this.lblConfirmPassword = new Label();
            this.txtConfirmPassword = new TextBox();
            this.btnSave = new Button();
            this.lblStatus = new Label();

            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Padding = new Padding(40);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblInfo);
            this.pnlMain.Controls.Add(this.lblNewUsername);
            this.pnlMain.Controls.Add(this.txtNewUsername);
            this.pnlMain.Controls.Add(this.lblNewPassword);
            this.pnlMain.Controls.Add(this.txtNewPassword);
            this.pnlMain.Controls.Add(this.lblConfirmPassword);
            this.pnlMain.Controls.Add(this.txtConfirmPassword);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.lblStatus);

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(40, 20);
            this.lblTitle.Size = new System.Drawing.Size(420, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "🔐 Change Your Credentials";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblInfo
            this.lblInfo.AutoSize = false;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(240, 180, 40);
            this.lblInfo.Location = new System.Drawing.Point(40, 65);
            this.lblInfo.Size = new System.Drawing.Size(420, 45);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Text = "⚠ For security, you must change both your username and password before continuing. Choose strong credentials.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblNewUsername
            this.lblNewUsername.AutoSize = true;
            this.lblNewUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNewUsername.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblNewUsername.Location = new System.Drawing.Point(60, 125);
            this.lblNewUsername.Name = "lblNewUsername";
            this.lblNewUsername.Text = "New Username (min 4 characters)";

            // txtNewUsername
            this.txtNewUsername.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.txtNewUsername.BorderStyle = BorderStyle.FixedSingle;
            this.txtNewUsername.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNewUsername.ForeColor = System.Drawing.Color.White;
            this.txtNewUsername.Location = new System.Drawing.Point(60, 150);
            this.txtNewUsername.Size = new System.Drawing.Size(380, 34);
            this.txtNewUsername.Name = "txtNewUsername";

            // lblNewPassword
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblNewPassword.Location = new System.Drawing.Point(60, 200);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Text = "New Password (min 8 characters)";

            // txtNewPassword
            this.txtNewPassword.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNewPassword.ForeColor = System.Drawing.Color.White;
            this.txtNewPassword.Location = new System.Drawing.Point(60, 225);
            this.txtNewPassword.Size = new System.Drawing.Size(380, 34);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.UseSystemPasswordChar = true;

            // lblConfirmPassword
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblConfirmPassword.Location = new System.Drawing.Point(60, 275);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Text = "Confirm New Password";

            // txtConfirmPassword
            this.txtConfirmPassword.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.txtConfirmPassword.Location = new System.Drawing.Point(60, 300);
            this.txtConfirmPassword.Size = new System.Drawing.Size(380, 34);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.UseSystemPasswordChar = true;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(40, 180, 100);
            this.btnSave.Cursor = Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(60, 360);
            this.btnSave.Size = new System.Drawing.Size(380, 45);
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = "Update Credentials";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // lblStatus
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(220, 60, 60);
            this.lblStatus.Location = new System.Drawing.Point(60, 410);
            this.lblStatus.Size = new System.Drawing.Size(380, 60);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // ChangeCredentialsForm
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 480);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeCredentialsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Change Credentials — First Login";
            this.ControlBox = false; // Prevent closing without changing

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Label lblTitle;
        private Label lblInfo;
        private Label lblNewUsername;
        private TextBox txtNewUsername;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnSave;
        private Label lblStatus;
    }
}
