using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace EVS
{
    public partial class RegisterEmployeeForm : Form
    {
        private string connectionString = "Host=localhost;Database=www2;Username=postgres;Password=root";

        private ComboBox cmbDolzhnost;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtMiddleName;
        private TextBox txtPhone;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private DateTimePicker dtpBirthDate;
        private DateTimePicker dtpHireDate;
        private Button btnRegister;
        private Button btnBack;

        private Label lblTitle;
        private Label lblSubtitle;
        private Panel headerPanel;
        private Label lblLastName, lblFirstName, lblMiddleName, lblPhone, lblDolzhnost, lblBirthDate, lblHireDate;
        private Label lblLogin, lblPassword, lblConfirmPassword;

        public RegisterEmployeeForm()
        {
            InitializeComponent();
            LoadDolzhnosti();
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
            lblDolzhnost = new Label();
            lblBirthDate = new Label();
            dtpBirthDate = new DateTimePicker();
            lblHireDate = new Label();
            dtpHireDate = new DateTimePicker();
            lblLogin = new Label();
            txtLogin = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            btnBack = new Button();
            cmbDolzhnost = new ComboBox();
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
            lblTitle.Location = new Point(41, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(405, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Регистрация сотрудника";
            lblTitle.Click += lblTitle_Click;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.FromArgb(200, 200, 255);
            lblSubtitle.Location = new Point(45, 65);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(277, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Заполните данные нового сотрудника";
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
            // lblDolzhnost
            // 
            lblDolzhnost.AutoSize = true;
            lblDolzhnost.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDolzhnost.ForeColor = Color.FromArgb(0, 80, 131);
            lblDolzhnost.Location = new Point(40, 220);
            lblDolzhnost.Name = "lblDolzhnost";
            lblDolzhnost.Size = new Size(96, 20);
            lblDolzhnost.TabIndex = 9;
            lblDolzhnost.Text = "Должность:";
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBirthDate.ForeColor = Color.FromArgb(0, 80, 131);
            lblBirthDate.Location = new Point(400, 220);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(127, 20);
            lblBirthDate.TabIndex = 11;
            lblBirthDate.Text = "Дата рождения:";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(530, 217);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(150, 23);
            dtpBirthDate.TabIndex = 12;
            // 
            // lblHireDate
            // 
            lblHireDate.AutoSize = true;
            lblHireDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHireDate.ForeColor = Color.FromArgb(0, 80, 131);
            lblHireDate.Location = new Point(40, 265);
            lblHireDate.Name = "lblHireDate";
            lblHireDate.Size = new Size(107, 20);
            lblHireDate.TabIndex = 13;
            lblHireDate.Text = "Дата приема:";
            // 
            // dtpHireDate
            // 
            dtpHireDate.Format = DateTimePickerFormat.Short;
            dtpHireDate.Location = new Point(160, 262);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(150, 23);
            dtpHireDate.TabIndex = 14;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogin.ForeColor = Color.FromArgb(0, 80, 131);
            lblLogin.Location = new Point(40, 320);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(57, 20);
            lblLogin.TabIndex = 15;
            lblLogin.Text = "Логин:";
            // 
            // txtLogin
            // 
            txtLogin.Font = new Font("Segoe UI", 11F);
            txtLogin.Location = new Point(160, 317);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(200, 27);
            txtLogin.TabIndex = 16;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(0, 80, 131);
            lblPassword.Location = new Point(400, 320);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(67, 20);
            lblPassword.TabIndex = 17;
            lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(480, 317);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 27);
            txtPassword.TabIndex = 18;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(0, 80, 131);
            lblConfirmPassword.Location = new Point(40, 365);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(131, 20);
            lblConfirmPassword.TabIndex = 19;
            lblConfirmPassword.Text = "Подтверждение:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 11F);
            txtConfirmPassword.Location = new Point(177, 362);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(200, 27);
            txtConfirmPassword.TabIndex = 20;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.TextChanged += txtConfirmPassword_TextChanged;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(0, 120, 200);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(300, 430);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(200, 45);
            btnRegister.TabIndex = 21;
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
            btnBack.Location = new Point(530, 430);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(150, 45);
            btnBack.TabIndex = 22;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // cmbDolzhnost
            // 
            cmbDolzhnost.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDolzhnost.Font = new Font("Segoe UI", 11F);
            cmbDolzhnost.Location = new Point(160, 217);
            cmbDolzhnost.Name = "cmbDolzhnost";
            cmbDolzhnost.Size = new Size(200, 28);
            cmbDolzhnost.TabIndex = 10;
            // 
            // RegisterEmployeeForm
            // 
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(750, 530);
            Controls.Add(headerPanel);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(lblMiddleName);
            Controls.Add(txtMiddleName);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(lblDolzhnost);
            Controls.Add(cmbDolzhnost);
            Controls.Add(lblBirthDate);
            Controls.Add(dtpBirthDate);
            Controls.Add(lblHireDate);
            Controls.Add(dtpHireDate);
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
            Name = "RegisterEmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Столичная Логистика - Регистрация сотрудника";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void LoadDolzhnosti()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT id_dolznosti, nazvanie_dolznosti FROM sortydnikis.dolznosti ORDER BY id_dolznosti";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbDolzhnost.Items.Add(new DolzhnostItem
                            {
                                Id = reader.GetInt64(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
                cmbDolzhnost.DisplayMember = "Name";
                cmbDolzhnost.ValueMember = "Id";
                if (cmbDolzhnost.Items.Count > 0)
                    cmbDolzhnost.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки должностей: " + ex.Message);
            }
        }

        // ==================== ИСПРАВЛЕННАЯ РЕГИСТРАЦИЯ ====================
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;

            // Валидация
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Введите фамилию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Введите имя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Введите телефон!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbDolzhnost.SelectedItem == null)
            {
                MessageBox.Show("Выберите должность!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Логин и пароль обязательны!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password != confirm)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        // 1. Вставляем данные сотрудника
                        string sqlEmployee = @"
                            INSERT INTO sortydnikis.sotrydniki 
                            (s_familiya, s_imya, s_otchestvo, s_nomer_telephona, dolzhnost, s_data_rozdeniya, data_priema)
                            VALUES (@lastName, @firstName, @middleName, @phone, @dolzhnost, @birthDate, @hireDate)
                            RETURNING id_sotrydnika";

                        // ✅ ИСПРАВЛЕНО: используем Convert.ToInt32()
                        int employeeId;
                        using (var cmd = new NpgsqlCommand(sqlEmployee, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("lastName", txtLastName.Text.Trim());
                            cmd.Parameters.AddWithValue("firstName", txtFirstName.Text.Trim());
                            cmd.Parameters.AddWithValue("middleName", string.IsNullOrWhiteSpace(txtMiddleName.Text) ? "" : txtMiddleName.Text.Trim());
                            cmd.Parameters.AddWithValue("phone", txtPhone.Text.Trim());
                            cmd.Parameters.AddWithValue("dolzhnost", ((DolzhnostItem)cmbDolzhnost.SelectedItem).Id);
                            cmd.Parameters.AddWithValue("birthDate", dtpBirthDate.Value);
                            cmd.Parameters.AddWithValue("hireDate", dtpHireDate.Value);

                            object result = cmd.ExecuteScalar();
                            employeeId = Convert.ToInt32(result);
                        }

                        // 2. Генерация соли и хэша
                        string salt = PasswordHelper.GenerateSalt();
                        string hash = PasswordHelper.HashPassword(password, salt);

                        // 3. Вставляем данные в security.users
                        string sqlUser = @"
                            INSERT INTO security.users (login, password_hash, password_salt, id_sotrydnika)
                            VALUES (@login, @hash, @salt, @employeeId)";

                        using (var cmd = new NpgsqlCommand(sqlUser, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("login", login);
                            cmd.Parameters.AddWithValue("hash", hash);
                            cmd.Parameters.AddWithValue("salt", salt);
                            cmd.Parameters.AddWithValue("employeeId", employeeId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                MessageBox.Show($"Сотрудник {txtLastName.Text} {txtFirstName.Text} успешно зарегистрирован!\nЛогин: {login}",
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
        // ==================== КОНЕЦ ====================

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private class DolzhnostItem
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}