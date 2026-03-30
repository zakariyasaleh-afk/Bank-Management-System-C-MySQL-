namespace BankManagementSystem.Forms
{
    partial class LoginForm
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
            this.pnlLoginCard = new Panel();
            this.lblTitle = new Label();
            this.lblUser = new Label();
            this.txtUsername = new TextBox();
            this.lblPass = new Label();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.lblStatus = new Label();
            this.btnClose = new Button();
            this.lblBankName = new Label();

            this.pnlLoginCard.SuspendLayout();
            this.SuspendLayout();

            // LoginForm
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.pnlLoginCard);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;

            // btnClose
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Gray;
            this.btnClose.Location = new System.Drawing.Point(365, 5);
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);

            // pnlLoginCard
            this.pnlLoginCard.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.pnlLoginCard.Controls.AddRange(new Control[] {
                this.lblBankName, this.lblUser, this.txtUsername,
                this.lblPass, this.txtPassword, this.btnLogin, this.lblStatus
            });
            this.pnlLoginCard.Location = new System.Drawing.Point(40, 50);
            this.pnlLoginCard.Size = new System.Drawing.Size(320, 400);

            // lblBankName
            this.lblBankName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.lblBankName.Location = new System.Drawing.Point(0, 40);
            this.lblBankName.Size = new System.Drawing.Size(320, 30);
            this.lblBankName.Text = "MANAGEMENT SYSTEM";
            this.lblBankName.TextAlign = ContentAlignment.MiddleCenter;

            // Fields Styling
            int fieldX = 35;
            int fieldWidth = 250;
            
            this.lblUser.Text = "Username";
            this.lblUser.ForeColor = System.Drawing.Color.Silver;
            this.lblUser.Location = new System.Drawing.Point(fieldX, 125);
            this.lblUser.Size = new System.Drawing.Size(fieldWidth, 20);

            this.txtUsername.Location = new System.Drawing.Point(fieldX, 145);
            this.txtUsername.Size = new System.Drawing.Size(fieldWidth, 25);
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.txtUsername.ForeColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = BorderStyle.FixedSingle;

            this.lblPass.Text = "Password";
            this.lblPass.ForeColor = System.Drawing.Color.Silver;
            this.lblPass.Location = new System.Drawing.Point(fieldX, 190);
            this.lblPass.Size = new System.Drawing.Size(fieldWidth, 20);

            this.txtPassword.Location = new System.Drawing.Point(fieldX, 210);
            this.txtPassword.Size = new System.Drawing.Size(fieldWidth, 25);
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.UseSystemPasswordChar = true;

            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(fieldX, 260);
            this.btnLogin.Size = new System.Drawing.Size(fieldWidth, 40);
            this.btnLogin.Text = "Sign In";
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);

            // lblStatus
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(20, 315);
            this.lblStatus.Size = new System.Drawing.Size(280, 60);
            this.lblStatus.TextAlign = ContentAlignment.TopCenter;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            this.pnlLoginCard.ResumeLayout(false);
            this.pnlLoginCard.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel pnlLoginCard;
        private Label lblTitle, lblUser, lblPass, lblStatus, lblBankName;
        private TextBox txtUsername, txtPassword;
        private Button btnLogin, btnClose;
    }
}
