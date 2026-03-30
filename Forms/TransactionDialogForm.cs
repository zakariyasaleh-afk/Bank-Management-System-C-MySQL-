using BankManagementSystem.BLL;
using BankManagementSystem.Models;
using BankManagementSystem.Helpers;

namespace BankManagementSystem.Forms
{
    public partial class TransactionDialogForm : Form
    {
        private readonly TransactionBLL _transactionBLL = new();
        private readonly string _transactionType;
        private readonly Account _account;

        public TransactionDialogForm(Account account, string type)
        {
            InitializeComponent();
            _account = account;
            _transactionType = type;
            
            lblTitle.Text = $"{type} from Account #{account.AccountID}";
            lblBalance.Text = $"Current Balance: {account.Balance:C}";
            btnConfirm.Text = $"Confirm {type}";

            if (type == "Withdraw")
            {
                btnConfirm.BackColor = System.Drawing.Color.FromArgb(220, 60, 60);
            }
        }

        private void BtnConfirm_Click(object? sender, EventArgs e)
        {
            decimal amount = nudAmount.Value;
            string description = txtDescription.Text.Trim();

            if (amount <= 0)
            {
                lblStatus.Text = "Amount must be greater than zero.";
                return;
            }

            var (success, message) = _transactionType == "Deposit" 
                ? _transactionBLL.Deposit(_account.AccountID, amount, description)
                : _transactionBLL.Withdraw(_account.AccountID, amount, description);

            if (success)
            {
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblStatus.Text = message;
            }
        }
    }
}
