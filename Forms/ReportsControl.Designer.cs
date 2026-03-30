namespace BankManagementSystem.Forms
{
    partial class ReportsControl
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
            this.lblFrom = new Label();
            this.dtpFrom = new DateTimePicker();
            this.lblTo = new Label();
            this.dtpTo = new DateTimePicker();
            this.btnLoadReport = new Button();
            this.btnExportExcel = new Button();
            this.btnExportPdf = new Button();
            this.cmbReportType = new ComboBox();
            this.dgvReport = new DataGridView();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvReport).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(35, 40, 65);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 65;
            this.pnlTop.Padding = new Padding(15);
            this.pnlTop.Controls.AddRange(new Control[] { cmbReportType, lblFrom, dtpFrom, lblTo, dtpTo,
                btnLoadReport, btnExportExcel, btnExportPdf });

            // cmbReportType
            this.cmbReportType.Location = new System.Drawing.Point(15, 18);
            this.cmbReportType.Size = new System.Drawing.Size(180, 28);
            this.cmbReportType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbReportType.Items.AddRange(new object[] { "Transactions", "Audit Logs", "Account Summary", "Loan Summary" });
            this.cmbReportType.SelectedIndex = 0;
            this.cmbReportType.BackColor = System.Drawing.Color.FromArgb(55, 55, 80);
            this.cmbReportType.ForeColor = System.Drawing.Color.White;

            // Date Pickers
            this.lblFrom.Text = "From:"; this.lblFrom.ForeColor = System.Drawing.Color.White;
            this.lblFrom.Location = new System.Drawing.Point(210, 20); this.lblFrom.AutoSize = true;
            this.dtpFrom.Location = new System.Drawing.Point(260, 17); this.dtpFrom.Size = new System.Drawing.Size(140, 28);
            this.dtpFrom.Value = DateTime.Today.AddMonths(-1);

            this.lblTo.Text = "To:"; this.lblTo.ForeColor = System.Drawing.Color.White;
            this.lblTo.Location = new System.Drawing.Point(410, 20); this.lblTo.AutoSize = true;
            this.dtpTo.Location = new System.Drawing.Point(440, 17); this.dtpTo.Size = new System.Drawing.Size(140, 28);

            // Buttons
            this.btnLoadReport.BackColor = System.Drawing.Color.FromArgb(100, 120, 255);
            this.btnLoadReport.FlatStyle = FlatStyle.Flat;
            this.btnLoadReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoadReport.ForeColor = System.Drawing.Color.White;
            this.btnLoadReport.Location = new System.Drawing.Point(600, 14);
            this.btnLoadReport.Size = new System.Drawing.Size(120, 35);
            this.btnLoadReport.Text = "📊 Load";
            this.btnLoadReport.Click += (s, e) => LoadReport();

            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(40, 140, 80);
            this.btnExportExcel.FlatStyle = FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(730, 14);
            this.btnExportExcel.Size = new System.Drawing.Size(130, 35);
            this.btnExportExcel.Text = "📁 Excel";
            this.btnExportExcel.Click += (s, e) => ExportExcel();

            this.btnExportPdf.BackColor = System.Drawing.Color.FromArgb(200, 60, 50);
            this.btnExportPdf.FlatStyle = FlatStyle.Flat;
            this.btnExportPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportPdf.Location = new System.Drawing.Point(870, 14);
            this.btnExportPdf.Size = new System.Drawing.Size(120, 35);
            this.btnExportPdf.Text = "📄 PDF";
            this.btnExportPdf.Click += (s, e) => ExportPdf();

            // Grid
            this.dgvReport.Dock = DockStyle.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 46);

            // ReportsControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.pnlTop);
            this.Name = "ReportsControl";
            this.Size = new System.Drawing.Size(1060, 660);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvReport).EndInit();
            this.ResumeLayout(false);
        }

        private Panel pnlTop;
        private Label lblFrom, lblTo;
        private DateTimePicker dtpFrom, dtpTo;
        private ComboBox cmbReportType;
        private Button btnLoadReport, btnExportExcel, btnExportPdf;
        private DataGridView dgvReport;
    }
}
