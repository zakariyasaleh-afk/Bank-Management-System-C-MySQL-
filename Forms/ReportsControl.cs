using BankManagementSystem.BLL;
using BankManagementSystem.Helpers;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BankManagementSystem.Forms
{
    public partial class ReportsControl : UserControl
    {
        private readonly TransactionBLL _transactionBLL = new();
        private readonly AuditLogBLL _auditLogBLL = new();
        private readonly AccountBLL _accountBLL = new();
        private readonly LoanBLL _loanBLL = new();

        public ReportsControl()
        {
            InitializeComponent();
            this.Load += (s, e) => {
                dtpTo.Value = DateTime.Today;
                LoadReport();
            };
        }

        private void LoadReport()
        {
            try
            {
                DateTime from = dtpFrom.Value.Date;
                DateTime to = dtpTo.Value.Date.AddDays(1);
                string type = cmbReportType.SelectedItem?.ToString() ?? "Transactions";

                object dataSource = type switch
                {
                    "Transactions" => _transactionBLL.GetByDateRange(from, to).Select(t => new {
                        t.TransactionID, t.Type, Amount = t.Amount.ToString("C"),
                        From = t.FromAccountID?.ToString() ?? "-", To = t.ToAccountID?.ToString() ?? "-",
                        t.Description, Date = t.DateTime.ToString("yyyy-MM-dd HH:mm")
                    }).ToList(),
                    "Audit Logs" => (object)_auditLogBLL.GetByDateRange(from, to).Select(l => new {
                        l.Action, User = l.Username, Time = l.Timestamp.ToString("yyyy-MM-dd HH:mm"), l.Details
                    }).ToList(),
                    "Account Summary" => (object)_accountBLL.GetAll().Select(a => new {
                        a.AccountID, Customer = a.CustomerName, a.AccountType, Balance = a.Balance.ToString("C"),
                        a.Status, Created = a.CreatedAt.ToString("yyyy-MM-dd")
                    }).ToList(),
                    "Loan Summary" => (object)_loanBLL.GetAll().Select(l => new {
                        l.LoanID, Customer = l.CustomerName, Amount = l.Amount.ToString("C"),
                        Rate = $"{l.InterestRate}%", l.Status, Start = l.StartDate.ToString("yyyy-MM-dd"),
                        End = l.EndDate.ToString("yyyy-MM-dd")
                    }).ToList(),
                    _ => new List<object>()
                };

                dgvReport.DataSource = dataSource;
                StyleGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleGrid()
        {
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.ReadOnly = true;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.RowHeadersVisible = false;
            dgvReport.BackgroundColor = ThemeManager.Surface;
            dgvReport.DefaultCellStyle.BackColor = ThemeManager.Surface;
            dgvReport.DefaultCellStyle.ForeColor = ThemeManager.TextColor;
            dgvReport.ColumnHeadersDefaultCellStyle.BackColor = ThemeManager.CardColor;
            dgvReport.ColumnHeadersDefaultCellStyle.ForeColor = ThemeManager.TextColor;
            dgvReport.EnableHeadersVisualStyles = false;
            dgvReport.BorderStyle = BorderStyle.None;
        }

        private void ExportExcel()
        {
            if (dgvReport.Rows.Count == 0) { MessageBox.Show("No data to export. Load a report first."); return; }

            using var sfd = new SaveFileDialog { Filter = "Excel Files|*.xlsx", FileName = "BankReport.xlsx" };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Report");

                for (int i = 0; i < dgvReport.Columns.Count; i++)
                    worksheet.Cell(1, i + 1).Value = dgvReport.Columns[i].HeaderText;

                for (int r = 0; r < dgvReport.Rows.Count; r++)
                    for (int c = 0; c < dgvReport.Columns.Count; c++)
                        worksheet.Cell(r + 2, c + 1).Value = dgvReport.Rows[r].Cells[c].Value?.ToString() ?? "";

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(sfd.FileName);
                MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show($"Export failed: {ex.Message}"); }
        }

        private void ExportPdf()
        {
            if (dgvReport.Rows.Count == 0) { MessageBox.Show("No data to export. Load a report first."); return; }

            using var sfd = new SaveFileDialog { Filter = "PDF Files|*.pdf", FileName = "BankReport.pdf" };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var stream = new FileStream(sfd.FileName, FileMode.Create);
                var doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
                PdfWriter.GetInstance(doc, stream);
                doc.Open();

                doc.Add(new Paragraph("Bank Management System — Report",
                    FontFactory.GetFont(FontFactory.HELVETICA, 16, iTextSharp.text.Font.BOLD)));
                doc.Add(new Paragraph($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}\n\n"));

                var table = new PdfPTable(dgvReport.Columns.Count);
                table.WidthPercentage = 100;

                foreach (DataGridViewColumn col in dgvReport.Columns)
                    table.AddCell(new PdfPCell(new Phrase(col.HeaderText,
                        FontFactory.GetFont(FontFactory.HELVETICA, 9, iTextSharp.text.Font.BOLD)))
                    { BackgroundColor = new BaseColor(60, 80, 230), Padding = 5 });

                for (int r = 0; r < dgvReport.Rows.Count; r++)
                    for (int c = 0; c < dgvReport.Columns.Count; c++)
                        table.AddCell(new PdfPCell(new Phrase(dgvReport.Rows[r].Cells[c].Value?.ToString() ?? "",
                            FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL))) { Padding = 4 });

                doc.Add(table);
                doc.Close();
                MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show($"Export failed: {ex.Message}"); }
        }
    }
}
