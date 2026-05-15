using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace EVS
{
    public partial class LoginForm : Form
    {
        private string connectionString = "Host=localhost;Database=www2;Username=postgres;Password=root";

        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblLogin;
        private Label lblPassword;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel headerPanel;
        private Button btnRegister;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblLogin = new Label();
            txtLogin = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(0, 80, 131);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblSubtitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(520, 100);
            headerPanel.TabIndex = 6;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(36, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(281, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Вход в систему";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 12F);
            lblSubtitle.ForeColor = Color.FromArgb(200, 200, 255);
            lblSubtitle.Location = new Point(45, 65);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(165, 21);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Столичная Логистика";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLogin.ForeColor = Color.FromArgb(0, 80, 131);
            lblLogin.Location = new Point(60, 150);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(63, 21);
            lblLogin.TabIndex = 5;
            lblLogin.Text = "Логин:";
            // 
            // txtLogin
            // 
            txtLogin.BackColor = Color.White;
            txtLogin.BorderStyle = BorderStyle.FixedSingle;
            txtLogin.Font = new Font("Segoe UI", 12F);
            txtLogin.Location = new Point(180, 147);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(250, 29);
            txtLogin.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(0, 80, 131);
            lblPassword.Location = new Point(60, 210);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(74, 21);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(180, 207);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 29);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 120, 200);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(180, 280);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(250, 50);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.White;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 11F);
            btnRegister.ForeColor = Color.FromArgb(0, 80, 131);
            btnRegister.Location = new Point(180, 350);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(250, 40);
            btnRegister.TabIndex = 0;
            btnRegister.Text = "Нет аккаунта? Зарегистрироваться";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // LoginForm
            // 
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(520, 450);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtLogin);
            Controls.Add(lblLogin);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Столичная Логистика - Вход";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // Проверяем сотрудников
                    string sqlEmployee = @"
                        SELECT u.password_hash, u.password_salt, u.id_sotrydnika, 
                               s.s_familiya, s.s_imya, s.dolzhnost, 'employee' as user_type,
                               d.nazvanie_dolznosti
                        FROM security.users u
                        JOIN sortydnikis.sotrydniki s ON u.id_sotrydnika = s.id_sotrydnika
                        JOIN sortydnikis.dolznosti d ON s.dolzhnost = d.id_dolznosti
                        WHERE u.login = @login";

                    bool userFound = false;
                    string storedHash = "";
                    string storedSalt = "";
                    long userId = 0;
                    string userType = "";
                    string fullName = "";
                    string role = "";

                    using (var cmd = new NpgsqlCommand(sqlEmployee, conn))
                    {
                        cmd.Parameters.AddWithValue("login", login);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userFound = true;
                                storedHash = reader.GetString(0);
                                storedSalt = reader.GetString(1);
                                userId = reader.GetInt64(2);
                                userType = reader.GetString(6);
                                fullName = reader.GetString(3) + " " + reader.GetString(4);
                                role = reader.GetString(7); // Должность = роль
                            }
                        }
                    }

                    // Если не нашли в сотрудниках, проверяем клиентов
                    if (!userFound)
                    {
                        string sqlClient = @"
                            SELECT u.password_hash_user, u.password_salt_user, u.id_polzovatelya, 
                                   p.p_familiya, p.p_name, 'client' as user_type, 'client' as role
                            FROM security.users_polz u
                            JOIN prog.polzovateli p ON u.id_polzovatelya = p.id_polzovatelya
                            WHERE u.login_p = @login";

                        using (var cmd = new NpgsqlCommand(sqlClient, conn))
                        {
                            cmd.Parameters.AddWithValue("login", login);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    userFound = true;
                                    storedHash = reader.GetString(0);
                                    storedSalt = reader.GetString(1);
                                    userId = reader.GetInt64(2);
                                    userType = reader.GetString(5);
                                    fullName = reader.GetString(3) + " " + reader.GetString(4);
                                    role = "client";
                                }
                            }
                        }
                    }

                    if (userFound)
                    {
                        if (PasswordHelper.VerifyPassword(password, storedSalt, storedHash))
                        {
                            AppSession.CurrentUser = new UserSession
                            {
                                Login = login,
                                UserId = userId,
                                UserType = userType,
                                FullName = fullName,
                                Role = GetRoleByDolzhnost(role),
                                LoginTime = DateTime.Now
                            };

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден.", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка входа: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetRoleByDolzhnost(string dolzhnost)
        {
            if (dolzhnost == "client") return "client";
            if (dolzhnost.Contains("Генеральный директор")) return "director";
            if (dolzhnost.Contains("Логист")) return "manager";
            if (dolzhnost.Contains("Водитель")) return "driver";
            return "user";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }
    }
}