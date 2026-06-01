
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PremiumLivingManagementSystem
{
    public class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;

        public LoginForm()
        {
            this.Text = "Premium Living Login";
            this.Size = new System.Drawing.Size(320, 200);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            Label lblUsername = new Label() { Text = "Username:", Left = 30, Top = 30, Width = 70 };
            txtUsername = new TextBox() { Left = 110, Top = 27, Width = 150 };

            Label lblPassword = new Label() { Text = "Password:", Left = 30, Top = 70, Width = 70 };
            txtPassword = new TextBox() { Left = 110, Top = 67, Width = 150, UseSystemPasswordChar = true };

            btnLogin = new Button() { Text = "Login", Left = 80, Top = 110, Width = 80, Height = 30 };
            btnExit = new Button() { Text = "Exit", Left = 180, Top = 110, Width = 80, Height = 30 };

            btnLogin.Click += BtnLogin_Click;
            btnExit.Click += (s, e) => Application.Exit();

            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnExit);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Enter username and password");
                return;
            }

            string hashedPassword = DatabaseHelper.HashPassword(password);
            string query = $"SELECT user_id, full_name, role FROM users WHERE username='{username}' AND password_hash='{hashedPassword}'";

            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        DatabaseHelper.CurrentUserID = reader.GetInt32("user_id");
                        DatabaseHelper.CurrentUserName = reader.GetString("full_name");
                        DatabaseHelper.CurrentUserRole = reader.GetString("role");
                        reader.Close();

                        MessageBox.Show("Welcome " + DatabaseHelper.CurrentUserName);

                        MainMenuForm mainMenu = new MainMenuForm();
                        mainMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(812, 572);
            this.Name = "LoginForm";
            this.ResumeLayout(false);

        }
    }
}