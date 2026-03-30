namespace BankManagementSystem.Forms
{
    partial class FirstRunSetupForm
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
            this.lblTitle = new Label();
            this.lblDesc = new Label();
            this.lblFull = new Label();
            this.txtFullName = new TextBox();
            this.lblUser = new Label();
            this.txtUsername = new TextBox();
            this.lblPass = new Label();
            this.txtPassword = new TextBox();
            this.btnCreate = new Button();

            this.SuspendLayout();

            // FirstRunSetupForm
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.ClientSize = new System.Drawing.Size(400, 480);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstRunSetupForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Initial System Setup";

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 30);
            this.lblTitle.Size = new System.Drawing.Size(400, 40);
            this.lblTitle.Text = "Welcome to Management";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblDesc
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblDesc.Location = new System.Drawing.Point(50, 70);
            this.lblDesc.Size = new System.Drawing.Size(300, 40);
            this.lblDesc.Text = "Setup your initial administrator account to begin.";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            int x = 60, w = 280, y = 140;

            this.lblFull.Text = "Administrator Full Name";
            this.lblFull.ForeColor = System.Drawing.Color.Silver;
            this.lblFull.Location = new System.Drawing.Point(x, y);
            this.lblFull.Size = new System.Drawing.Size(w, 20);

            this.txtFullName.Location = new System.Drawing.Point(x, y + 25);
            this.txtFullName.Size = new System.Drawing.Size(w, 25); y += 70;

            this.lblUser.Text = "Set Administrator Username";
            this.lblUser.ForeColor = System.Drawing.Color.Silver;
            this.lblUser.Location = new System.Drawing.Point(x, y);
            this.lblUser.Size = new System.Drawing.Size(w, 20);

            this.txtUsername.Location = new System.Drawing.Point(x, y + 25);
            this.txtUsername.Size = new System.Drawing.Size(w, 25); y += 70;

            this.lblPass.Text = "Set Administrator Password";
            this.lblPass.ForeColor = System.Drawing.Color.Silver;
            this.lblPass.Location = new System.Drawing.Point(x, y);
            this.lblPass.Size = new System.Drawing.Size(w, 20);

            this.txtPassword.Location = new System.Drawing.Point(x, y + 25);
            this.txtPassword.Size = new System.Drawing.Size(w, 25);
            this.txtPassword.UseSystemPasswordChar = true;

            // btnCreate
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnCreate.FlatStyle = FlatStyle.Flat;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(60, 360);
            this.btnCreate.Size = new System.Drawing.Size(280, 45);
            this.btnCreate.Text = "COMPLETE SETUP";
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);

            this.Controls.AddRange(new Control[] { lblTitle, lblDesc, lblFull, txtFullName, lblUser, txtUsername, lblPass, txtPassword, btnCreate });
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTitle, lblDesc, lblFull, lblUser, lblPass;
        private TextBox txtFullName, txtUsername, txtPassword;
        private Button btnCreate;
    }
}
