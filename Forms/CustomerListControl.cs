using BankManagementSystem.BLL;
using BankManagementSystem.Models;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    public partial class CustomerListControl : UserControl
    {
        private bool _isProcessing = false;
        private readonly CustomerBLL _customerBLL = new();

        public CustomerListControl()
        {
            InitializeComponent();
            this.Load += CustomerListControl_Load;
            
            // Wire events missing in Designer
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
        }

        private void CustomerListControl_Load(object? sender, EventArgs e)
        {
            LoadCustomers();
            LoadHubStats();
        }

        private void LoadHubStats()
        {
            try
            {
                var customers = _customerBLL.GetAll();
                lblTotalCount.Text = customers.Count.ToString("N0");
                lblNewThisMonth.Text = customers.Count(c => c.CreatedAt > DateTime.Now.AddDays(-30)).ToString("N0");
            }
            catch { }
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = _customerBLL.GetAll();
                dgvCustomers.DataSource = customers.Select(c => new
                {
                    ID = c.CustomerID,
                    c.FullName,
                    c.NationalID,
                    c.Phone,
                    c.Email,
                    DOB = c.DOB.ToString("yyyy-MM-dd")
                }).ToList();

                StyleGrid();
            }
            catch { }
        }

        private void StyleGrid()
        {
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = ThemeManager.Background;
            dgvCustomers.DefaultCellStyle.BackColor = ThemeManager.Surface;
            dgvCustomers.DefaultCellStyle.ForeColor = ThemeManager.TextColor;
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 45);
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.GridColor = Color.FromArgb(45, 45, 45);
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (_isProcessing) return;
            _isProcessing = true;
            try
            {
                var form = new CustomerDetailForm();
                if (form.ShowDialog() == DialogResult.OK) { LoadCustomers(); LoadHubStats(); }
            }
            finally { _isProcessing = false; }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (_isProcessing) return;
            if (dgvCustomers.SelectedRows.Count == 0) return;
            
            _isProcessing = true;
            try
            {
                int id = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["ID"].Value);
                var customer = _customerBLL.GetById(id);
                if (customer != null)
                {
                    var form = new CustomerDetailForm(customer);
                    if (form.ShowDialog() == DialogResult.OK) { LoadCustomers(); LoadHubStats(); }
                }
            }
            finally { _isProcessing = false; }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string term = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(term)) { LoadCustomers(); return; }
            try
            {
                var results = _customerBLL.Search(term);
                dgvCustomers.DataSource = results.Select(c => new { ID = c.CustomerID, c.FullName, c.NationalID, c.Phone, c.Email }).ToList();
            }
            catch { }
        }
    }
}
