using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace EVS
{
    public partial class RegisterClientForm : Form
    {
        private string connectionString = "Host=localhost;Database=www2;Username=postgres;Password=root";

        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtMiddleName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private Button btnBack;

        private Label lblTitle;
        private Label lblSubtitle;
        private Panel headerPanel;

        public RegisterClientForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblMiddleName = new Label();
            txtMiddleName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblLogin = new Label();
            txtLogin = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            btnBack = new Button();
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
            headerPanel.Size = new Size(750, 100);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(45, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(351, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Регистрация клиента";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.FromArgb(200, 200, 255);
            lblSubtitle.Location = new Point(45, 65);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(253, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Заполните данные нового клиента";
            lblSubtitle.Click += lblSubtitle_Click;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(0, 80, 131);
            lblLastName.Location = new Point(40, 130);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(82, 20);
            lblLastName.TabIndex = 1;
            lblLastName.Text = "Фамилия:";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 11F);
            txtLastName.Location = new Point(160, 127);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(200, 27);
            txtLastName.TabIndex = 2;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(0, 80, 131);
            lblFirstName.Location = new Point(400, 130);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(46, 20);
            lblFirstName.TabIndex = 3;
            lblFirstName.Text = "Имя:";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 11F);
            txtFirstName.Location = new Point(480, 127);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(200, 27);
            txtFirstName.TabIndex = 4;
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMiddleName.ForeColor = Color.FromArgb(0, 80, 131);
            lblMiddleName.Location = new Point(40, 175);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(80, 20);
            lblMiddleName.TabIndex = 5;
            lblMiddleName.Text = "Отчество:";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Font = new Font("Segoe UI", 11F);
            txtMiddleName.Location = new Point(160, 172);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(200, 27);
            txtMiddleName.TabIndex = 6;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(0, 80, 131);
            lblPhone.Location = new Point(400, 175);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(76, 20);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Телефон:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 11F);
            txtPhone.Location = new Point(480, 172);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 27);
            txtPhone.TabIndex = 8;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(0, 80, 131);
            lblEmail.Location = new Point(40, 220);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 20);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(160, 217);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 27);
            txtEmail.TabIndex = 10;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogin.ForeColor = Color.FromArgb(0, 80, 131);
            lblLogin.Location = new Point(40, 280);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(57, 20);
            lblLogin.TabIndex = 11;
            lblLogin.Text = "Логин:";
            // 
            // txtLogin
            // 
            txtLogin.Font = new Font("Segoe UI", 11F);
            txtLogin.Location = new Point(160, 277);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(200, 27);
            txtLogin.TabIndex = 12;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(0, 80, 131);
            lblPassword.Location = new Point(400, 280);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(67, 20);
            lblPassword.TabIndex = 13;
            lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(480, 277);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 27);
            txtPassword.TabIndex = 14;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(0, 80, 131);
            lblConfirmPassword.Location = new Point(40, 325);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(131, 20);
            lblConfirmPassword.TabIndex = 15;
            lblConfirmPassword.Text = "Подтверждение:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 11F);
            txtConfirmPassword.Location = new Point(177, 322);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(200, 27);
            txtConfirmPassword.TabIndex = 16;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(0, 120, 200);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(300, 390);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(200, 45);
            btnRegister.TabIndex = 17;
            btnRegister.Text = "Зарегистрировать";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.White;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 11F);
            btnBack.ForeColor = Color.FromArgb(0, 80, 131);
            btnBack.Location = new Point(530, 390);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(150, 45);
            btnBack.TabIndex = 18;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // RegisterClientForm
            // 
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(750, 490);
            Controls.Add(headerPanel);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(lblMiddleName);
            Controls.Add(txtMiddleName);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblLogin);
            Controls.Add(txtLogin);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(btnRegister);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Столичная Логистика - Регистрация клиента";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        // РЕГИСТРАЦИЯ КЛИЕНТА В ТАБЛИЦУ users_polz
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;

            // Валидация
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Введите фамилию!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Введите имя!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Введите телефон!");
                return;
            }
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Логин и пароль обязательны!");
                return;
            }
            if (password != confirm)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        // 1. Вставляем данные клиента в таблицу polzovateli
                        string sqlUser = @"
                            INSERT INTO prog.polzovateli 
                            (p_familiya, p_name, p_otchestvo, phone, email)
                            VALUES (@lastName, @firstName, @middleName, @phone, @email)
                            RETURNING id_polzovatelya";

                        int userId;
                        using (var cmd = new NpgsqlCommand(sqlUser, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("lastName", txtLastName.Text.Trim());
                            cmd.Parameters.AddWithValue("firstName", txtFirstName.Text.Trim());
                            cmd.Parameters.AddWithValue("middleName", string.IsNullOrWhiteSpace(txtMiddleName.Text) ? "" : txtMiddleName.Text.Trim());
                            cmd.Parameters.AddWithValue("phone", txtPhone.Text.Trim());
                            cmd.Parameters.AddWithValue("email", string.IsNullOrWhiteSpace(txtEmail.Text) ? "" : txtEmail.Text.Trim());

                            object result = cmd.ExecuteScalar();
                            userId = Convert.ToInt32(result);
                        }

                        // 2. Генерируем соль и хэш
                        string salt = PasswordHelper.GenerateSalt();
                        string hash = PasswordHelper.HashPassword(password, salt);

                        // 3. Вставляем данные для входа в таблицу users_polz (для клиентов)
                        string sqlAccount = @"
                            INSERT INTO security.users_polz (login_p, password_hash_user, password_salt_user, id_polzovatelya)
                            VALUES (@login, @hash, @salt, @userId)";

                        using (var cmd = new NpgsqlCommand(sqlAccount, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("login", login);
                            cmd.Parameters.AddWithValue("hash", hash);
                            cmd.Parameters.AddWithValue("salt", salt);
                            cmd.Parameters.AddWithValue("userId", userId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                MessageBox.Show($"Клиент {txtLastName.Text} {txtFirstName.Text} успешно зарегистрирован!\nЛогин: {login}",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "23505")
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Ошибка БД: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private Label lblLastName, lblFirstName, lblMiddleName, lblPhone, lblEmail;
        private Label lblLogin, lblPassword, lblConfirmPassword;

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }
    }
}