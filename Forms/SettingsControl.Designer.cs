using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    partial class SettingsControl
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
            this.pnlPassword = new Panel();
            this.lblPasswordTitle = new Label();
            this.lblCurrent = new Label();
            this.txtCurrentPassword = new TextBox();
            this.lblNew = new Label();
            this.txtNewPassword = new TextBox();
            this.lblConfirm = new Label();
            this.txtConfirmPassword = new TextBox();
            this.btnChangePassword = new Button();
            this.lblPasswordStatus = new Label();
            this.pnlTheme = new Panel();
            this.lblThemeTitle = new Label();
            this.chkDarkMode = new CheckBox();
            this.pnlBackup = new Panel();
            this.lblBackupTitle = new Label();
            this.btnBackup = new Button();
            this.btnLogout = new Button();

            this.pnlPassword.SuspendLayout();
            this.pnlTheme.SuspendLayout();
            this.pnlBackup.SuspendLayout();
            this.SuspendLayout();

            // Title
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 15);
            this.lblTitle.Size = new System.Drawing.Size(300, 35);
            this.lblTitle.Text = "⚙ Settings";

            // Password Change Panel
            this.pnlPassword.BackColor = System.Drawing.Color.FromArgb(40, 45, 70);
            this.pnlPassword.Location = new System.Drawing.Point(30, 60);
            this.pnlPassword.Size = new System.Drawing.Size(550, 310);
            this.pnlPassword.Controls.AddRange(new Control[] { lblPasswordTitle, lblCurrent, txtCurrentPassword,
                lblNew, txtNewPassword, lblConfirm, txtConfirmPassword, btnChangePassword, lblPasswordStatus });

            this.lblPasswordTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPasswordTitle.ForeColor = System.Drawing.Color.White;
            this.lblPasswordTitle.Location = new System.Drawing.Point(20, 15); this.lblPasswordTitle.AutoSize = true;
            this.lblPasswordTitle.Text = "🔑 Change Password";

            int py = 50;
            this.lblCurrent.Text = "Current Password"; this.lblCurrent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCurrent.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblCurrent.Location = new System.Drawing.Point(20, py); this.lblCurrent.AutoSize = true;
            this.txtCurrentPassword.Location = new System.Drawing.Point(20, py + 22); this.txtCurrentPassword.Size = new System.Drawing.Size(510, 30);
            this.txtCurrentPassword.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtCurrentPassword.UseSystemPasswordChar = true;
            this.txtCurrentPassword.BackColor = System.Drawing.Color.FromArgb(55, 55, 80); this.txtCurrentPassword.ForeColor = System.Drawing.Color.White;
            this.txtCurrentPassword.BorderStyle = BorderStyle.FixedSingle;

            py += 65;
            this.lblNew.Text = "New Password (min 8 chars)"; this.lblNew.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNew.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblNew.Location = new System.Drawing.Point(20, py); this.lblNew.AutoSize = true;
            this.txtNewPassword.Location = new System.Drawing.Point(20, py + 22); this.txtNewPassword.Size = new System.Drawing.Size(510, 30);
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtNewPassword.BackColor = System.Drawing.Color.FromArgb(55, 55, 80); this.txtNewPassword.ForeColor = System.Drawing.Color.White;
            this.txtNewPassword.BorderStyle = BorderStyle.FixedSingle;

            py += 65;
            this.lblConfirm.Text = "Confirm Password"; this.lblConfirm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConfirm.ForeColor = System.Drawing.Color.FromArgb(200, 205, 220);
            this.lblConfirm.Location = new System.Drawing.Point(20, py); this.lblConfirm.AutoSize = true;
            this.txtConfirmPassword.Location = new System.Drawing.Point(20, py + 22); this.txtConfirmPassword.Size = new System.Drawing.Size(510, 30);
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.BackColor = System.Drawing.Color.FromArgb(55, 55, 80); this.txtConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;

            py += 60;
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(100, 120, 255);
            this.btnChangePassword.FlatAppearance.BorderSize = 0; this.btnChangePassword.FlatStyle = FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(20, py); this.btnChangePassword.Size = new System.Drawing.Size(200, 40);
            this.btnChangePassword.Text = "Change Password"; this.btnChangePassword.Cursor = Cursors.Hand;
            this.btnChangePassword.Click += (s, e) => ChangePassword();

            this.lblPasswordStatus.ForeColor = System.Drawing.Color.FromArgb(220, 60, 60);
            this.lblPasswordStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblPasswordStatus.Location = new System.Drawing.Point(230, py); this.lblPasswordStatus.Size = new System.Drawing.Size(310, 50);
            this.lblPasswordStatus.TextAlign = ContentAlignment.MiddleLeft;
            this.lblPasswordStatus.AutoEllipsis = true;

            // Theme Panel
            this.pnlTheme.BackColor = System.Drawing.Color.FromArgb(40, 45, 70);
            this.pnlTheme.Location = new System.Drawing.Point(610, 60);
            this.pnlTheme.Size = new System.Drawing.Size(350, 100);
            this.pnlTheme.Controls.AddRange(new Control[] { lblThemeTitle, chkDarkMode });

            this.lblThemeTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblThemeTitle.ForeColor = System.Drawing.Color.White;
            this.lblThemeTitle.Location = new System.Drawing.Point(20, 15); this.lblThemeTitle.AutoSize = true;
            this.lblThemeTitle.Text = "🎨 Theme";

            this.chkDarkMode.Text = "Dark Mode";
            this.chkDarkMode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkDarkMode.ForeColor = System.Drawing.Color.White;
            this.chkDarkMode.Location = new System.Drawing.Point(20, 55); this.chkDarkMode.AutoSize = true;

            // Backup Panel
            this.pnlBackup.BackColor = System.Drawing.Color.FromArgb(40, 45, 70);
            this.pnlBackup.Location = new System.Drawing.Point(610, 180);
            this.pnlBackup.Size = new System.Drawing.Size(350, 100);
            this.pnlBackup.Controls.AddRange(new Control[] { lblBackupTitle, btnBackup });

            this.lblBackupTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblBackupTitle.ForeColor = System.Drawing.Color.White;
            this.lblBackupTitle.Location = new System.Drawing.Point(20, 15); this.lblBackupTitle.AutoSize = true;
            this.lblBackupTitle.Text = "💾 Database Backup";

            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(160, 100, 230);
            this.btnBackup.FlatAppearance.BorderSize = 0; this.btnBackup.FlatStyle = FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(20, 50); this.btnBackup.Size = new System.Drawing.Size(200, 35);
            this.btnBackup.Text = "Export Backup"; this.btnBackup.Cursor = Cursors.Hand;
            this.btnBackup.Click += (s, e) => BackupDatabase();

            // btnLogout (Settings)
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(220, 60, 60);
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(610, 300);
            this.btnLogout.Size = new System.Drawing.Size(200, 40);
            this.btnLogout.Text = "🚪 LOGOUT SYSTEM";
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.Click += (s, e) => {
                if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SessionManager.Logout();
                    this.FindForm()?.Close();
                }
            };

            // SettingsControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.AddRange(new Control[] { lblTitle, pnlPassword, pnlTheme, pnlBackup, btnLogout });
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(1060, 660);

            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlTheme.ResumeLayout(false);
            this.pnlTheme.PerformLayout();
            this.pnlBackup.ResumeLayout(false);
            this.pnlBackup.PerformLayout();
            this.ResumeLayout(false);
        }

        private Label lblTitle, lblPasswordTitle, lblCurrent, lblNew, lblConfirm, lblPasswordStatus, lblThemeTitle, lblBackupTitle;
        private Panel pnlPassword, pnlTheme, pnlBackup;
        private TextBox txtCurrentPassword, txtNewPassword, txtConfirmPassword;
        private Button btnChangePassword, btnBackup;
        private Button btnLogout;
        private CheckBox chkDarkMode;
    }
}
