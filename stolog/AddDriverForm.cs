using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace EVS
{
    public partial class AddDriverForm : Form
    {
        private string connectionString = "Host=localhost;Database=www2;Username=postgres;Password=root";

        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtPhone;
        private TextBox txtPassportData;
        private TextBox txtDriverLicenseNumber;
        private ComboBox cmbDolzhnost;
        private DateTimePicker dtpBirthDate;
        private DateTimePicker dtpHireDate;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnSave;
        private Button btnCancel;
        private Panel headerPanel;
        private Label lblHeader;
        private Panel mainPanel;
        private GroupBox gbPersonal;
        private Label lblLastName;
        private Label lblFirstName;
        private Label lblMiddleName;
        private Label lblPhone;
        private Label lblBirthDate;
        private GroupBox gbDocuments;
        private Label lblPassportData;
        private Label lblDriverLicenseNumber;
        private GroupBox gbWork;
        private Label lblDolzhnost;
        private Label lblHireDate;
        private GroupBox gbLogin;
        private Label lblLogin;
        private Label lblPassword;
        private Label lblConfirm;
        private Label lblRequiredInfo;

        public AddDriverForm()
        {
            InitializeComponent();
            LoadDolzhnosti();
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            lblHeader = new Label();
            mainPanel = new Panel();
            gbPersonal = new GroupBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblMiddleName = new Label();
            txtMiddleName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblBirthDate = new Label();
            dtpBirthDate = new DateTimePicker();
            gbDocuments = new GroupBox();
            lblPassportData = new Label();
            txtPassportData = new TextBox();
            lblDriverLicenseNumber = new Label();
            txtDriverLicenseNumber = new TextBox();
            gbWork = new GroupBox();
            lblDolzhnost = new Label();
            cmbDolzhnost = new ComboBox();
            lblHireDate = new Label();
            dtpHireDate = new DateTimePicker();
            gbLogin = new GroupBox();
            lblLogin = new Label();
            txtLogin = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirm = new Label();
            txtConfirmPassword = new TextBox();
            lblRequiredInfo = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            headerPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            gbPersonal.SuspendLayout();
            gbDocuments.SuspendLayout();
            gbWork.SuspendLayout();
            gbLogin.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(0, 80, 131);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(600, 60);
            headerPanel.TabIndex = 1;
            // 
            // lblHeader
            // 
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(20, 15);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(400, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Регистрация нового водителя";
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(gbPersonal);
            mainPanel.Controls.Add(gbDocuments);
            mainPanel.Controls.Add(gbWork);
            mainPanel.Controls.Add(gbLogin);
            mainPanel.Controls.Add(lblRequiredInfo);
            mainPanel.Controls.Add(btnSave);
            mainPanel.Controls.Add(btnCancel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 60);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(600, 770);
            mainPanel.TabIndex = 0;
            // 
            // gbPersonal
            // 
            gbPersonal.BackColor = Color.White;
            gbPersonal.Controls.Add(lblLastName);
            gbPersonal.Controls.Add(txtLastName);
            gbPersonal.Controls.Add(lblFirstName);
            gbPersonal.Controls.Add(txtFirstName);
            gbPersonal.Controls.Add(lblMiddleName);
            gbPersonal.Controls.Add(txtMiddleName);
            gbPersonal.Controls.Add(lblPhone);
            gbPersonal.Controls.Add(txtPhone);
            gbPersonal.Controls.Add(lblBirthDate);
            gbPersonal.Controls.Add(dtpBirthDate);
            gbPersonal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            gbPersonal.Location = new Point(5, 10);
            gbPersonal.Name = "gbPersonal";
            gbPersonal.Size = new Size(540, 250);
            gbPersonal.TabIndex = 0;
            gbPersonal.TabStop = false;
            gbPersonal.Text = "Личные данные";
            // 
            // lblLastName
            // 
            lblLastName.Font = new Font("Segoe UI", 10F);
            lblLastName.ForeColor = Color.FromArgb(0, 80, 131);
            lblLastName.Location = new Point(15, 30);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(150, 28);
            lblLastName.TabIndex = 0;
            lblLastName.Text = "Фамилия:*";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(180, 30);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(330, 25);
            txtLastName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            lblFirstName.Font = new Font("Segoe UI", 10F);
            lblFirstName.ForeColor = Color.FromArgb(0, 80, 131);
            lblFirstName.Location = new Point(15, 75);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(150, 28);
            lblFirstName.TabIndex = 2;
            lblFirstName.Text = "Имя:*";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(180, 75);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(330, 25);
            txtFirstName.TabIndex = 3;
            // 
            // lblMiddleName
            // 
            lblMiddleName.Font = new Font("Segoe UI", 10F);
            lblMiddleName.Location = new Point(15, 120);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(150, 28);
            lblMiddleName.TabIndex = 4;
            lblMiddleName.Text = "Отчество:";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Font = new Font("Segoe UI", 10F);
            txtMiddleName.Location = new Point(180, 120);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(330, 25);
            txtMiddleName.TabIndex = 5;
            // 
            // lblPhone
            // 
            lblPhone.Font = new Font("Segoe UI", 10F);
            lblPhone.ForeColor = Color.FromArgb(0, 80, 131);
            lblPhone.Location = new Point(15, 165);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(150, 28);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Телефон:*";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(180, 165);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(330, 25);
            txtPhone.TabIndex = 7;
            // 
            // lblBirthDate
            // 
            lblBirthDate.Font = new Font("Segoe UI", 10F);
            lblBirthDate.ForeColor = Color.FromArgb(0, 80, 131);
            lblBirthDate.Location = new Point(15, 210);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(150, 28);
            lblBirthDate.TabIndex = 8;
            lblBirthDate.Text = "Дата рождения:*";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Font = new Font("Segoe UI", 10F);
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(180, 210);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(150, 25);
            dtpBirthDate.TabIndex = 9;
            dtpBirthDate.Value = new DateTime(1996, 5, 13, 19, 8, 40, 731);
            // 
            // gbDocuments
            // 
            gbDocuments.BackColor = Color.White;
            gbDocuments.Controls.Add(lblPassportData);
            gbDocuments.Controls.Add(txtPassportData);
            gbDocuments.Controls.Add(lblDriverLicenseNumber);
            gbDocuments.Controls.Add(txtDriverLicenseNumber);
            gbDocuments.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            gbDocuments.Location = new Point(5, 270);
            gbDocuments.Name = "gbDocuments";
            gbDocuments.Size = new Size(540, 120);
            gbDocuments.TabIndex = 1;
            gbDocuments.TabStop = false;
            gbDocuments.Text = "Документы";
            // 
            // lblPassportData
            // 
            lblPassportData.Font = new Font("Segoe UI", 10F);
            lblPassportData.ForeColor = Color.FromArgb(0, 80, 131);
            lblPassportData.Location = new Point(15, 30);
            lblPassportData.Name = "lblPassportData";
            lblPassportData.Size = new Size(150, 28);
            lblPassportData.TabIndex = 0;
            lblPassportData.Text = "Паспортные данные:*";
            // 
            // txtPassportData
            // 
            txtPassportData.Font = new Font("Segoe UI", 10F);
            txtPassportData.Location = new Point(202, 30);
            txtPassportData.Name = "txtPassportData";
            txtPassportData.Size = new Size(308, 25);
            txtPassportData.TabIndex = 1;
            // 
            // lblDriverLicenseNumber
            // 
            lblDriverLicenseNumber.Font = new Font("Segoe UI", 10F);
            lblDriverLicenseNumber.ForeColor = Color.FromArgb(0, 80, 131);
            lblDriverLicenseNumber.Location = new Point(15, 75);
            lblDriverLicenseNumber.Name = "lblDriverLicenseNumber";
            lblDriverLicenseNumber.Size = new Size(181, 28);
            lblDriverLicenseNumber.TabIndex = 2;
            lblDriverLicenseNumber.Text = "Вод. удостоверение №:*";
            // 
            // txtDriverLicenseNumber
            // 
            txtDriverLicenseNumber.Font = new Font("Segoe UI", 10F);
            txtDriverLicenseNumber.Location = new Point(202, 78);
            txtDriverLicenseNumber.Name = "txtDriverLicenseNumber";
            txtDriverLicenseNumber.Size = new Size(308, 25);
            txtDriverLicenseNumber.TabIndex = 3;
            // 
            // gbWork
            // 
            gbWork.BackColor = Color.White;
            gbWork.Controls.Add(lblDolzhnost);
            gbWork.Controls.Add(cmbDolzhnost);
            gbWork.Controls.Add(lblHireDate);
            gbWork.Controls.Add(dtpHireDate);
            gbWork.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            gbWork.Location = new Point(5, 400);
            gbWork.Name = "gbWork";
            gbWork.Size = new Size(540, 120);
            gbWork.TabIndex = 2;
            gbWork.TabStop = false;
            gbWork.Text = "Рабочие данные";
            // 
            // lblDolzhnost
            // 
            lblDolzhnost.Font = new Font("Segoe UI", 10F);
            lblDolzhnost.ForeColor = Color.FromArgb(0, 80, 131);
            lblDolzhnost.Location = new Point(15, 30);
            lblDolzhnost.Name = "lblDolzhnost";
            lblDolzhnost.Size = new Size(150, 28);
            lblDolzhnost.TabIndex = 0;
            lblDolzhnost.Text = "Должность:*";
            // 
            // cmbDolzhnost
            // 
            cmbDolzhnost.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDolzhnost.Font = new Font("Segoe UI", 10F);
            cmbDolzhnost.Location = new Point(180, 30);
            cmbDolzhnost.Name = "cmbDolzhnost";
            cmbDolzhnost.Size = new Size(200, 25);
            cmbDolzhnost.TabIndex = 1;
            // 
            // lblHireDate
            // 
            lblHireDate.Font = new Font("Segoe UI", 10F);
            lblHireDate.ForeColor = Color.FromArgb(0, 80, 131);
            lblHireDate.Location = new Point(15, 75);
            lblHireDate.Name = "lblHireDate";
            lblHireDate.Size = new Size(150, 28);
            lblHireDate.TabIndex = 2;
            lblHireDate.Text = "Дата приема:*";
            // 
            // dtpHireDate
            // 
            dtpHireDate.Font = new Font("Segoe UI", 10F);
            dtpHireDate.Format = DateTimePickerFormat.Short;
            dtpHireDate.Location = new Point(180, 75);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(150, 25);
            dtpHireDate.TabIndex = 3;
            dtpHireDate.Value = new DateTime(2026, 5, 13, 19, 8, 40, 758);
            // 
            // gbLogin
            // 
            gbLogin.BackColor = Color.White;
            gbLogin.Controls.Add(lblLogin);
            gbLogin.Controls.Add(txtLogin);
            gbLogin.Controls.Add(lblPassword);
            gbLogin.Controls.Add(txtPassword);
            gbLogin.Controls.Add(lblConfirm);
            gbLogin.Controls.Add(txtConfirmPassword);
            gbLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            gbLogin.Location = new Point(5, 530);
            gbLogin.Name = "gbLogin";
            gbLogin.Size = new Size(540, 150);
            gbLogin.TabIndex = 3;
            gbLogin.TabStop = false;
            gbLogin.Text = "Данные для входа";
            // 
            // lblLogin
            // 
            lblLogin.Font = new Font("Segoe UI", 10F);
            lblLogin.ForeColor = Color.FromArgb(0, 80, 131);
            lblLogin.Location = new Point(15, 30);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(150, 28);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Логин:*";
            // 
            // txtLogin
            // 
            txtLogin.Font = new Font("Segoe UI", 10F);
            txtLogin.Location = new Point(180, 30);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(330, 25);
            txtLogin.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.ForeColor = Color.FromArgb(0, 80, 131);
            lblPassword.Location = new Point(15, 75);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(150, 28);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Пароль:*";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(180, 75);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(330, 25);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirm
            // 
            lblConfirm.Font = new Font("Segoe UI", 10F);
            lblConfirm.ForeColor = Color.FromArgb(0, 80, 131);
            lblConfirm.Location = new Point(15, 115);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(150, 28);
            lblConfirm.TabIndex = 4;
            lblConfirm.Text = "Подтверждение:*";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(180, 115);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(330, 25);
            txtConfirmPassword.TabIndex = 5;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblRequiredInfo
            // 
            lblRequiredInfo.Font = new Font("Segoe UI", 9F);
            lblRequiredInfo.ForeColor = Color.Gray;
            lblRequiredInfo.Location = new Point(15, 695);
            lblRequiredInfo.Name = "lblRequiredInfo";
            lblRequiredInfo.Size = new Size(140, 20);
            lblRequiredInfo.TabIndex = 4;
            lblRequiredInfo.Text = "* - обязательные поля";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 120, 200);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(146, 718);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 5;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.FromArgb(0, 80, 131);
            btnCancel.Location = new Point(272, 718);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddDriverForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(600, 830);
            Controls.Add(mainPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddDriverForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавить водителя";
            headerPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            gbPersonal.ResumeLayout(false);
            gbPersonal.PerformLayout();
            gbDocuments.ResumeLayout(false);
            gbDocuments.PerformLayout();
            gbWork.ResumeLayout(false);
            gbLogin.ResumeLayout(false);
            gbLogin.PerformLayout();
            ResumeLayout(false);
        }

        private void LoadDolzhnosti()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    // ИСПРАВЛЕНО: используем INTEGER вместо BIGINT
                    string sql = "SELECT id_dolznosti, nazvanie_dolznosti FROM sortydnikis.dolznosti WHERE nazvanie_dolznosti = 'Водитель' OR nazvanie_dolznosti = 'Стажер' ORDER BY id_dolznosti";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbDolzhnost.Items.Clear();
                        while (reader.Read())
                        {
                            cmbDolzhnost.Items.Add(new DolzhnostItem
                            {
                                Id = reader.GetInt32(0),  // ИСПРАВЛЕНО: GetInt32 вместо GetInt64
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Введите фамилию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Введите имя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Введите телефон!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassportData.Text))
            {
                MessageBox.Show("Введите паспортные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassportData.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDriverLicenseNumber.Text))
            {
                MessageBox.Show("Введите номер водительского удостоверения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDriverLicenseNumber.Focus();
                return;
            }

            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите логин!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            if (password != confirm)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        // ИСПРАВЛЕНО: используем int вместо long
                        int dolzhnostId = ((DolzhnostItem)cmbDolzhnost.SelectedItem).Id;

                        string sqlEmployee = @"
                            INSERT INTO sortydnikis.sotrydniki 
                            (s_familiya, s_imya, s_otchestvo, s_nomer_telephona, dolzhnost, s_data_rozdeniya, data_priema)
                            VALUES (@fam, @name, @otch, @phone, @dolzhnost, @birth, @hire)
                            RETURNING id_sotrydnika";

                        // ИСПРАВЛЕНО: используем int для employeeId
                        int employeeId;
                        using (var cmd = new NpgsqlCommand(sqlEmployee, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("fam", txtLastName.Text.Trim());
                            cmd.Parameters.AddWithValue("name", txtFirstName.Text.Trim());
                            cmd.Parameters.AddWithValue("otch", string.IsNullOrWhiteSpace(txtMiddleName.Text) ? "" : txtMiddleName.Text.Trim());
                            cmd.Parameters.AddWithValue("phone", txtPhone.Text.Trim());
                            cmd.Parameters.AddWithValue("dolzhnost", dolzhnostId);
                            cmd.Parameters.AddWithValue("birth", dtpBirthDate.Value);
                            cmd.Parameters.AddWithValue("hire", dtpHireDate.Value);
                            // ИСПРАВЛЕНО: Convert.ToInt32 вместо (long)
                            employeeId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Добавляем запись в таблицу водителей
                        string sqlDriver = @"
                            INSERT INTO sortydnikis.voditeli 
                            (id_sotrydnika, passport_data, driver_license_number)
                            VALUES (@employeeId, @passport, @license)
                            RETURNING id_voditelya";

                        using (var cmd = new NpgsqlCommand(sqlDriver, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("employeeId", employeeId);
                            cmd.Parameters.AddWithValue("passport", txtPassportData.Text.Trim());
                            cmd.Parameters.AddWithValue("license", txtDriverLicenseNumber.Text.Trim());
                            cmd.ExecuteScalar();  // Нам не нужно сохранять driverId, если не используется
                        }

                        string salt = PasswordHelper.GenerateSalt();
                        string hash = PasswordHelper.HashPassword(password, salt);

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

                MessageBox.Show($"Водитель {txtLastName.Text} {txtFirstName.Text} успешно добавлен!",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
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

        // ИСПРАВЛЕНО: Id имеет тип int вместо long
        private class DolzhnostItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}