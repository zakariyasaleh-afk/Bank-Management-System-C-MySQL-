using BankManagementSystem.BLL;
using BankManagementSystem.Helpers;
using BankManagementSystem.DAL;

namespace BankManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserBLL _userBLL = new();

        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;
        }

        private void LoginForm_Load(object? sender, EventArgs e)
        {
            ThemeManager.SetRoundedRegion(pnlLoginCard, 10);
            
            // Test connection silently
            Task.Run(() => {
                string error;
                if (!DbConnectionManager.TestConnection(out error))
                {
                    this.Invoke(() => {
                        lblStatus.Text = "Database Connection Error. Check config.json.";
                        lblStatus.ForeColor = ThemeManager.WarningColor;
                    });
                }
            });
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            try 
            {
                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Authenticating...";
                lblStatus.ForeColor = ThemeManager.TextColor;
                
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    lblStatus.Text = "Please enter credentials.";
                    lblStatus.ForeColor = ThemeManager.WarningColor;
                    return;
                }

                var (user, message) = _userBLL.Authenticate(username, password);

                if (user != null)
                {
                    SessionManager.Login(user);
                    
                    if (user.MustChangePassword)
                    {
                        var changeForm = new ChangeCredentialsForm();
                        if (changeForm.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    lblStatus.Text = message;
                    lblStatus.ForeColor = ThemeManager.DangerColor;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Critical Error: " + ex.Message;
                lblStatus.ForeColor = ThemeManager.DangerColor;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
