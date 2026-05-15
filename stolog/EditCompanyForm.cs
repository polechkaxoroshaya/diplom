using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace EVS
{
    public partial class EditCompanyForm : Form
    {
        private string connectionString = "Host=localhost;Database=www2;Username=postgres;Password=root";
        private long companyId;

        private TextBox txtName;
        private TextBox txtInn;
        private TextBox txtKpp;
        private TextBox txtOgrn;
        private TextBox txtLegalAddress;
        private TextBox txtActualAddress;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtDirector;
        private TextBox txtBankName;
        private TextBox txtBik;
        private TextBox txtCorrespondentAccount;
        private TextBox txtCheckingAccount;
        private Button btnSave;
        private Panel mainPanel;
        private Label lblName;
        private Label lblInn;
        private Label lblKpp;
        private Label lblOgrn;
        private Label lblLegalAddress;
        private Label lblActualAddress;
        private Label lblPhone;
        private Label lblEmail;
        private Label lblDirector;
        private Label lblBankName;
        private Label lblBik;
        private Label lblCorrespondentAccount;
        private Label lblCheckingAccount;
        private Button btnCancel;

        public EditCompanyForm(long id, string name)
        {
            companyId = id;
            this.Text = $"Редактирование компании: {name}";
            InitializeComponent();
            LoadCompanyData();
        }

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            lblName = new Label();
            txtName = new TextBox();
            lblInn = new Label();
            txtInn = new TextBox();
            lblKpp = new Label();
            txtKpp = new TextBox();
            lblOgrn = new Label();
            txtOgrn = new TextBox();
            lblLegalAddress = new Label();
            txtLegalAddress = new TextBox();
            lblActualAddress = new Label();
            txtActualAddress = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDirector = new Label();
            txtDirector = new TextBox();
            lblBankName = new Label();
            txtBankName = new TextBox();
            lblBik = new Label();
            txtBik = new TextBox();
            lblCorrespondentAccount = new Label();
            txtCorrespondentAccount = new TextBox();
            lblCheckingAccount = new Label();
            txtCheckingAccount = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.AutoScrollMinSize = new Size(0, 660);
            mainPanel.Controls.Add(lblName);
            mainPanel.Controls.Add(txtName);
            mainPanel.Controls.Add(lblInn);
            mainPanel.Controls.Add(txtInn);
            mainPanel.Controls.Add(lblKpp);
            mainPanel.Controls.Add(txtKpp);
            mainPanel.Controls.Add(lblOgrn);
            mainPanel.Controls.Add(txtOgrn);
            mainPanel.Controls.Add(lblLegalAddress);
            mainPanel.Controls.Add(txtLegalAddress);
            mainPanel.Controls.Add(lblActualAddress);
            mainPanel.Controls.Add(txtActualAddress);
            mainPanel.Controls.Add(lblPhone);
            mainPanel.Controls.Add(txtPhone);
            mainPanel.Controls.Add(lblEmail);
            mainPanel.Controls.Add(txtEmail);
            mainPanel.Controls.Add(lblDirector);
            mainPanel.Controls.Add(txtDirector);
            mainPanel.Controls.Add(lblBankName);
            mainPanel.Controls.Add(txtBankName);
            mainPanel.Controls.Add(lblBik);
            mainPanel.Controls.Add(txtBik);
            mainPanel.Controls.Add(lblCorrespondentAccount);
            mainPanel.Controls.Add(txtCorrespondentAccount);
            mainPanel.Controls.Add(lblCheckingAccount);
            mainPanel.Controls.Add(txtCheckingAccount);
            mainPanel.Controls.Add(btnSave);
            mainPanel.Controls.Add(btnCancel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(544, 652);
            mainPanel.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 10F);
            lblName.ForeColor = Color.FromArgb(0, 80, 131);
            lblName.Location = new Point(10, 10);
            lblName.Name = "lblName";
            lblName.Size = new Size(150, 28);
            lblName.TabIndex = 0;
            lblName.Text = "Название компании:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(160, 10);
            txtName.Name = "txtName";
            txtName.Size = new Size(340, 25);
            txtName.TabIndex = 1;
            // 
            // lblInn
            // 
            lblInn.Font = new Font("Segoe UI", 10F);
            lblInn.Location = new Point(10, 55);
            lblInn.Name = "lblInn";
            lblInn.Size = new Size(150, 28);
            lblInn.TabIndex = 2;
            lblInn.Text = "ИНН:";
            // 
            // txtInn
            // 
            txtInn.Font = new Font("Segoe UI", 10F);
            txtInn.Location = new Point(160, 55);
            txtInn.Name = "txtInn";
            txtInn.Size = new Size(340, 25);
            txtInn.TabIndex = 3;
            // 
            // lblKpp
            // 
            lblKpp.Font = new Font("Segoe UI", 10F);
            lblKpp.Location = new Point(10, 100);
            lblKpp.Name = "lblKpp";
            lblKpp.Size = new Size(150, 28);
            lblKpp.TabIndex = 4;
            lblKpp.Text = "КПП:";
            // 
            // txtKpp
            // 
            txtKpp.Font = new Font("Segoe UI", 10F);
            txtKpp.Location = new Point(160, 100);
            txtKpp.Name = "txtKpp";
            txtKpp.Size = new Size(340, 25);
            txtKpp.TabIndex = 5;
            // 
            // lblOgrn
            // 
            lblOgrn.Font = new Font("Segoe UI", 10F);
            lblOgrn.Location = new Point(10, 145);
            lblOgrn.Name = "lblOgrn";
            lblOgrn.Size = new Size(150, 28);
            lblOgrn.TabIndex = 6;
            lblOgrn.Text = "ОГРН:";
            // 
            // txtOgrn
            // 
            txtOgrn.Font = new Font("Segoe UI", 10F);
            txtOgrn.Location = new Point(160, 145);
            txtOgrn.Name = "txtOgrn";
            txtOgrn.Size = new Size(340, 25);
            txtOgrn.TabIndex = 7;
            // 
            // lblLegalAddress
            // 
            lblLegalAddress.Font = new Font("Segoe UI", 10F);
            lblLegalAddress.Location = new Point(10, 190);
            lblLegalAddress.Name = "lblLegalAddress";
            lblLegalAddress.Size = new Size(150, 28);
            lblLegalAddress.TabIndex = 8;
            lblLegalAddress.Text = "Юридический адрес:";
            // 
            // txtLegalAddress
            // 
            txtLegalAddress.Font = new Font("Segoe UI", 10F);
            txtLegalAddress.Location = new Point(160, 190);
            txtLegalAddress.Name = "txtLegalAddress";
            txtLegalAddress.Size = new Size(340, 25);
            txtLegalAddress.TabIndex = 9;
            // 
            // lblActualAddress
            // 
            lblActualAddress.Font = new Font("Segoe UI", 10F);
            lblActualAddress.Location = new Point(10, 235);
            lblActualAddress.Name = "lblActualAddress";
            lblActualAddress.Size = new Size(150, 28);
            lblActualAddress.TabIndex = 10;
            lblActualAddress.Text = "Фактический адрес:";
            // 
            // txtActualAddress
            // 
            txtActualAddress.Font = new Font("Segoe UI", 10F);
            txtActualAddress.Location = new Point(160, 235);
            txtActualAddress.Name = "txtActualAddress";
            txtActualAddress.Size = new Size(340, 25);
            txtActualAddress.TabIndex = 11;
            // 
            // lblPhone
            // 
            lblPhone.Font = new Font("Segoe UI", 10F);
            lblPhone.ForeColor = Color.FromArgb(0, 80, 131);
            lblPhone.Location = new Point(10, 280);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(150, 28);
            lblPhone.TabIndex = 12;
            lblPhone.Text = "Телефон:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(160, 280);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(340, 25);
            txtPhone.TabIndex = 13;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(10, 325);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(150, 28);
            lblEmail.TabIndex = 14;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(160, 325);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(340, 25);
            txtEmail.TabIndex = 15;
            // 
            // lblDirector
            // 
            lblDirector.Font = new Font("Segoe UI", 10F);
            lblDirector.Location = new Point(10, 370);
            lblDirector.Name = "lblDirector";
            lblDirector.Size = new Size(150, 28);
            lblDirector.TabIndex = 16;
            lblDirector.Text = "Генеральный директор:";
            // 
            // txtDirector
            // 
            txtDirector.Font = new Font("Segoe UI", 10F);
            txtDirector.Location = new Point(160, 370);
            txtDirector.Name = "txtDirector";
            txtDirector.Size = new Size(340, 25);
            txtDirector.TabIndex = 17;
            // 
            // lblBankName
            // 
            lblBankName.Font = new Font("Segoe UI", 10F);
            lblBankName.Location = new Point(10, 415);
            lblBankName.Name = "lblBankName";
            lblBankName.Size = new Size(150, 28);
            lblBankName.TabIndex = 18;
            lblBankName.Text = "Банк:";
            // 
            // txtBankName
            // 
            txtBankName.Font = new Font("Segoe UI", 10F);
            txtBankName.Location = new Point(160, 415);
            txtBankName.Name = "txtBankName";
            txtBankName.Size = new Size(340, 25);
            txtBankName.TabIndex = 19;
            // 
            // lblBik
            // 
            lblBik.Font = new Font("Segoe UI", 10F);
            lblBik.Location = new Point(10, 460);
            lblBik.Name = "lblBik";
            lblBik.Size = new Size(150, 28);
            lblBik.TabIndex = 20;
            lblBik.Text = "БИК:";
            // 
            // txtBik
            // 
            txtBik.Font = new Font("Segoe UI", 10F);
            txtBik.Location = new Point(160, 460);
            txtBik.Name = "txtBik";
            txtBik.Size = new Size(340, 25);
            txtBik.TabIndex = 21;
            // 
            // lblCorrespondentAccount
            // 
            lblCorrespondentAccount.Font = new Font("Segoe UI", 10F);
            lblCorrespondentAccount.Location = new Point(10, 505);
            lblCorrespondentAccount.Name = "lblCorrespondentAccount";
            lblCorrespondentAccount.Size = new Size(150, 28);
            lblCorrespondentAccount.TabIndex = 22;
            lblCorrespondentAccount.Text = "Корр. счет:";
            // 
            // txtCorrespondentAccount
            // 
            txtCorrespondentAccount.Font = new Font("Segoe UI", 10F);
            txtCorrespondentAccount.Location = new Point(160, 505);
            txtCorrespondentAccount.Name = "txtCorrespondentAccount";
            txtCorrespondentAccount.Size = new Size(340, 25);
            txtCorrespondentAccount.TabIndex = 23;
            // 
            // lblCheckingAccount
            // 
            lblCheckingAccount.Font = new Font("Segoe UI", 10F);
            lblCheckingAccount.Location = new Point(10, 550);
            lblCheckingAccount.Name = "lblCheckingAccount";
            lblCheckingAccount.Size = new Size(150, 28);
            lblCheckingAccount.TabIndex = 24;
            lblCheckingAccount.Text = "Расчетный счет:";
            // 
            // txtCheckingAccount
            // 
            txtCheckingAccount.Font = new Font("Segoe UI", 10F);
            txtCheckingAccount.Location = new Point(160, 550);
            txtCheckingAccount.Name = "txtCheckingAccount";
            txtCheckingAccount.Size = new Size(340, 25);
            txtCheckingAccount.TabIndex = 25;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 120, 200);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(105, 595);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 26;
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
            btnCancel.Location = new Point(240, 595);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 27;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // EditCompanyForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(544, 652);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditCompanyForm";
            StartPosition = FormStartPosition.CenterParent;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }

        private void LoadCompanyData()
        {
            try
            {
                string sql = @"
                    SELECT name, inn, kpp, ogrn, legal_address, actual_address, 
                           phone, email, director_name, bank_name, bik, 
                           correspondent_account, checking_account
                    FROM prog.companies
                    WHERE id_company = @companyId";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("companyId", companyId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader.GetString(0);
                                txtInn.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                txtKpp.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                txtOgrn.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                                txtLegalAddress.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                                txtActualAddress.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);
                                txtPhone.Text = reader.IsDBNull(6) ? "" : reader.GetString(6);
                                txtEmail.Text = reader.IsDBNull(7) ? "" : reader.GetString(7);
                                txtDirector.Text = reader.IsDBNull(8) ? "" : reader.GetString(8);
                                txtBankName.Text = reader.IsDBNull(9) ? "" : reader.GetString(9);
                                txtBik.Text = reader.IsDBNull(10) ? "" : reader.GetString(10);
                                txtCorrespondentAccount.Text = reader.IsDBNull(11) ? "" : reader.GetString(11);
                                txtCheckingAccount.Text = reader.IsDBNull(12) ? "" : reader.GetString(12);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных компании: " + ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название компании!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            try
            {
                string sql = @"
                    UPDATE prog.companies SET
                        name = @name,
                        inn = @inn,
                        kpp = @kpp,
                        ogrn = @ogrn,
                        legal_address = @legal,
                        actual_address = @actual,
                        phone = @phone,
                        email = @email,
                        director_name = @director,
                        bank_name = @bank,
                        bik = @bik,
                        correspondent_account = @corr,
                        checking_account = @check
                    WHERE id_company = @companyId";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("inn", txtInn.Text.Trim());
                        cmd.Parameters.AddWithValue("kpp", txtKpp.Text.Trim());
                        cmd.Parameters.AddWithValue("ogrn", txtOgrn.Text.Trim());
                        cmd.Parameters.AddWithValue("legal", txtLegalAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("actual", txtActualAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("director", txtDirector.Text.Trim());
                        cmd.Parameters.AddWithValue("bank", txtBankName.Text.Trim());
                        cmd.Parameters.AddWithValue("bik", txtBik.Text.Trim());
                        cmd.Parameters.AddWithValue("corr", txtCorrespondentAccount.Text.Trim());
                        cmd.Parameters.AddWithValue("check", txtCheckingAccount.Text.Trim());
                        cmd.Parameters.AddWithValue("companyId", companyId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Данные компании успешно обновлены!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}