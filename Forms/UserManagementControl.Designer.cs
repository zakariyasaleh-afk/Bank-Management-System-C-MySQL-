namespace BankManagementSystem.Forms
{
    partial class UserManagementControl
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
            this.pnlTop = new Panel();
            this.btnAdd = new Button();
            this.btnDeactivate = new Button();
            this.btnReactivate = new Button();
            this.dgvUsers = new DataGridView();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvUsers).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.Transparent; // Set to transparent to let ThemeManager handle it or use a specific property
            this.pnlTop.Tag = "card";
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.Padding = new Padding(15, 12, 15, 12);
            this.pnlTop.Controls.Add(this.btnReactivate);
            this.pnlTop.Controls.Add(this.btnDeactivate);
            this.pnlTop.Controls.Add(this.btnAdd);

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(46, 160, 67);
            this.btnAdd.Tag = "success";
            this.btnAdd.Dock = DockStyle.Left;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Size = new System.Drawing.Size(160, 36);
            this.btnAdd.Text = "+ Add New User";
            this.btnAdd.Cursor = Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // btnDeactivate
            this.btnDeactivate.BackColor = System.Drawing.Color.FromArgb(220, 60, 60);
            this.btnDeactivate.Tag = "danger";
            this.btnDeactivate.Dock = DockStyle.Left;
            this.btnDeactivate.FlatAppearance.BorderSize = 0;
            this.btnDeactivate.FlatStyle = FlatStyle.Flat;
            this.btnDeactivate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeactivate.ForeColor = System.Drawing.Color.White;
            this.btnDeactivate.Location = new System.Drawing.Point(155, 12);
            this.btnDeactivate.Margin = new Padding(15, 0, 0, 0);
            this.btnDeactivate.Size = new System.Drawing.Size(140, 36);
            this.btnDeactivate.Text = "🚫 Deactivate";
            this.btnDeactivate.Cursor = Cursors.Hand;
            this.btnDeactivate.Click += new System.EventHandler(this.BtnDeactivate_Click);

            // btnReactivate
            this.btnReactivate.BackColor = System.Drawing.Color.FromArgb(50, 120, 230);
            this.btnReactivate.Dock = DockStyle.Left;
            this.btnReactivate.FlatAppearance.BorderSize = 0;
            this.btnReactivate.FlatStyle = FlatStyle.Flat;
            this.btnReactivate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReactivate.ForeColor = System.Drawing.Color.White;
            this.btnReactivate.Location = new System.Drawing.Point(295, 12);
            this.btnReactivate.Margin = new Padding(15, 0, 0, 0);
            this.btnReactivate.Size = new System.Drawing.Size(140, 36);
            this.btnReactivate.Text = "✓ Reactivate";
            this.btnReactivate.Cursor = Cursors.Hand;
            this.btnReactivate.Click += new System.EventHandler(this.BtnReactivate_Click);

            // dgvUsers
            this.dgvUsers.Dock = DockStyle.Fill;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 46);

            // UserManagementControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 46);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.pnlTop);
            this.Name = "UserManagementControl";
            this.Size = new System.Drawing.Size(1060, 660);

            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvUsers).EndInit();
            this.ResumeLayout(false);
        }

        private Panel pnlTop;
        private Button btnAdd;
        private Button btnDeactivate;
        private Button btnReactivate;
        private DataGridView dgvUsers;
    }
}
