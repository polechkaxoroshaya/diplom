using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace EVS
{
    public partial class AddCompanyForm : Form
    {
        private string connectionString = "Host=localhost;Database=www2;Username=postgres;Password=root";

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
        private CheckBox chkIsDefault;
        private Button btnSave;
        private Button btnCancel;
        private Panel headerPanel;
        private Label lblHeader;
        private Panel mainPanel;
        private GroupBox gbMain;
        private Label lblName;
        private Label lblInn;
        private Label lblKpp;
        private Label lblOgrn;
        private Label lblLegalAddress;
        private Label lblActualAddress;
        private GroupBox gbContact;
        private Label lblPhone;
        private Label lblEmail;
        private Label lblDirector;
        private GroupBox gbBank;
        private Label lblBankName;
        private Label lblBik;
        private Label lblCorrespondentAccount;
        private Label lblCheckingAccount;
        private Label lblRequiredInfo;

        public AddCompanyForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            lblHeader = new Label();
            mainPanel = new Panel();
            gbMain = new GroupBox();
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
            gbContact = new GroupBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDirector = new Label();
            txtDirector = new TextBox();
            gbBank = new GroupBox();
            lblBankName = new Label();
            txtBankName = new TextBox();
            lblBik = new Label();
            txtBik = new TextBox();
            lblCorrespondentAccount = new Label();
            txtCorrespondentAccount = new TextBox();
            lblCheckingAccount = new Label();
            txtCheckingAccount = new TextBox();
            chkIsDefault = new CheckBox();
            lblRequiredInfo = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            headerPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            gbMain.SuspendLayout();
            gbContact.SuspendLayout();
            gbBank.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(0, 80, 131);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(594, 60);
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
            lblHeader.Text = "Регистрация новой компании";
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(gbMain);
            mainPanel.Controls.Add(gbContact);
            mainPanel.Controls.Add(gbBank);
            mainPanel.Controls.Add(chkIsDefault);
            mainPanel.Controls.Add(lblRequiredInfo);
            mainPanel.Controls.Add(btnSave);
            mainPanel.Controls.Add(btnCancel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 60);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(594, 814);
            mainPanel.TabIndex = 0;
            // 
            // gbMain
            // 
            gbMain.BackColor = Color.White;
            gbMain.Controls.Add(lblName);
            gbMain.Controls.Add(txtName);
            gbMain.Controls.Add(lblInn);
            gbMain.Controls.Add(txtInn);
            gbMain.Controls.Add(lblKpp);
            gbMain.Controls.Add(txtKpp);
            gbMain.Controls.Add(lblOgrn);
            gbMain.Controls.Add(txtOgrn);
            gbMain.Controls.Add(lblLegalAddress);
            gbMain.Controls.Add(txtLegalAddress);
            gbMain.Controls.Add(lblActualAddress);
            gbMain.Controls.Add(txtActualAddress);
            gbMain.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            gbMain.Location = new Point(5, 10);
            gbMain.Name = "gbMain";
            gbMain.Size = new Size(540, 280);
            gbMain.TabIndex = 0;
            gbMain.TabStop = false;
            gbMain.Text = "Основная информация";
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 10F);
            lblName.ForeColor = Color.FromArgb(0, 80, 131);
            lblName.Location = new Point(15, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(150, 28);
            lblName.TabIndex = 0;
            lblName.Text = "Название компании:*";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(171, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(349, 25);
            txtName.TabIndex = 1;
            // 
            // lblInn
            // 
            lblInn.Font = new Font("Segoe UI", 10F);
            lblInn.Location = new Point(15, 75);
            lblInn.Name = "lblInn";
            lblInn.Size = new Size(150, 28);
            lblInn.TabIndex = 2;
            lblInn.Text = "ИНН:";
            // 
            // txtInn
            // 
            txtInn.Font = new Font("Segoe UI", 10F);
            txtInn.Location = new Point(171, 75);
            txtInn.Name = "txtInn";
            txtInn.Size = new Size(169, 25);
            txtInn.TabIndex = 3;
            // 
            // lblKpp
            // 
            lblKpp.Font = new Font("Segoe UI", 10F);
            lblKpp.Location = new Point(15, 120);
            lblKpp.Name = "lblKpp";
            lblKpp.Size = new Size(150, 28);
            lblKpp.TabIndex = 4;
            lblKpp.Text = "КПП:";
            // 
            // txtKpp
            // 
            txtKpp.Font = new Font("Segoe UI", 10F);
            txtKpp.Location = new Point(171, 120);
            txtKpp.Name = "txtKpp";
            txtKpp.Size = new Size(169, 25);
            txtKpp.TabIndex = 5;
            // 
            // lblOgrn
            // 
            lblOgrn.Font = new Font("Segoe UI", 10F);
            lblOgrn.Location = new Point(15, 165);
            lblOgrn.Name = "lblOgrn";
            lblOgrn.Size = new Size(150, 28);
            lblOgrn.TabIndex = 6;
            lblOgrn.Text = "ОГРН:";
            // 
            // txtOgrn
            // 
            txtOgrn.Font = new Font("Segoe UI", 10F);
            txtOgrn.Location = new Point(171, 165);
            txtOgrn.Name = "txtOgrn";
            txtOgrn.Size = new Size(239, 25);
            txtOgrn.TabIndex = 7;
            // 
            // lblLegalAddress
            // 
            lblLegalAddress.Font = new Font("Segoe UI", 10F);
            lblLegalAddress.Location = new Point(15, 210);
            lblLegalAddress.Name = "lblLegalAddress";
            lblLegalAddress.Size = new Size(150, 28);
            lblLegalAddress.TabIndex = 8;
            lblLegalAddress.Text = "Юридический адрес:";
            // 
            // txtLegalAddress
            // 
            txtLegalAddress.Font = new Font("Segoe UI", 10F);
            txtLegalAddress.Location = new Point(171, 210);
            txtLegalAddress.Name = "txtLegalAddress";
            txtLegalAddress.Size = new Size(349, 25);
            txtLegalAddress.TabIndex = 9;
            // 
            // lblActualAddress
            // 
            lblActualAddress.Font = new Font("Segoe UI", 10F);
            lblActualAddress.Location = new Point(15, 249);
            lblActualAddress.Name = "lblActualAddress";
            lblActualAddress.Size = new Size(150, 28);
            lblActualAddress.TabIndex = 10;
            lblActualAddress.Text = "Фактический адрес:";
            // 
            // txtActualAddress
            // 
            txtActualAddress.Font = new Font("Segoe UI", 10F);
            txtActualAddress.Location = new Point(171, 246);
            txtActualAddress.Name = "txtActualAddress";
            txtActualAddress.Size = new Size(349, 25);
            txtActualAddress.TabIndex = 11;
            // 
            // gbContact
            // 
            gbContact.BackColor = Color.White;
            gbContact.Controls.Add(lblPhone);
            gbContact.Controls.Add(txtPhone);
            gbContact.Controls.Add(lblEmail);
            gbContact.Controls.Add(txtEmail);
            gbContact.Controls.Add(lblDirector);
            gbContact.Controls.Add(txtDirector);
            gbContact.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            gbContact.Location = new Point(5, 300);
            gbContact.Name = "gbContact";
            gbContact.Size = new Size(540, 170);
            gbContact.TabIndex = 1;
            gbContact.TabStop = false;
            gbContact.Text = "Контактная информация";
            // 
            // lblPhone
            // 
            lblPhone.Font = new Font("Segoe UI", 10F);
            lblPhone.ForeColor = Color.FromArgb(0, 80, 131);
            lblPhone.Location = new Point(15, 30);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(150, 28);
            lblPhone.TabIndex = 0;
            lblPhone.Text = "Телефон:*";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(171, 30);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(189, 25);
            txtPhone.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(15, 75);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(150, 28);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(171, 75);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(239, 25);
            txtEmail.TabIndex = 3;
            // 
            // lblDirector
            // 
            lblDirector.Font = new Font("Segoe UI", 10F);
            lblDirector.Location = new Point(15, 120);
            lblDirector.Name = "lblDirector";
            lblDirector.Size = new Size(162, 28);
            lblDirector.TabIndex = 4;
            lblDirector.Text = "Генеральный директор:";
            // 
            // txtDirector
            // 
            txtDirector.Font = new Font("Segoe UI", 10F);
            txtDirector.Location = new Point(183, 120);
            txtDirector.Name = "txtDirector";
            txtDirector.Size = new Size(257, 25);
            txtDirector.TabIndex = 5;
            // 
            // gbBank
            // 
            gbBank.BackColor = Color.White;
            gbBank.Controls.Add(lblBankName);
            gbBank.Controls.Add(txtBankName);
            gbBank.Controls.Add(lblBik);
            gbBank.Controls.Add(txtBik);
            gbBank.Controls.Add(lblCorrespondentAccount);
            gbBank.Controls.Add(txtCorrespondentAccount);
            gbBank.Controls.Add(lblCheckingAccount);
            gbBank.Controls.Add(txtCheckingAccount);
            gbBank.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            gbBank.Location = new Point(5, 480);
            gbBank.Name = "gbBank";
            gbBank.Size = new Size(540, 220);
            gbBank.TabIndex = 2;
            gbBank.TabStop = false;
            gbBank.Text = "Банковские реквизиты";
            // 
            // lblBankName
            // 
            lblBankName.Font = new Font("Segoe UI", 10F);
            lblBankName.Location = new Point(15, 30);
            lblBankName.Name = "lblBankName";
            lblBankName.Size = new Size(150, 28);
            lblBankName.TabIndex = 0;
            lblBankName.Text = "Банк:";
            // 
            // txtBankName
            // 
            txtBankName.Font = new Font("Segoe UI", 10F);
            txtBankName.Location = new Point(171, 30);
            txtBankName.Name = "txtBankName";
            txtBankName.Size = new Size(289, 25);
            txtBankName.TabIndex = 1;
            // 
            // lblBik
            // 
            lblBik.Font = new Font("Segoe UI", 10F);
            lblBik.Location = new Point(15, 75);
            lblBik.Name = "lblBik";
            lblBik.Size = new Size(150, 28);
            lblBik.TabIndex = 2;
            lblBik.Text = "БИК:";
            // 
            // txtBik
            // 
            txtBik.Font = new Font("Segoe UI", 10F);
            txtBik.Location = new Point(171, 75);
            txtBik.Name = "txtBik";
            txtBik.Size = new Size(139, 25);
            txtBik.TabIndex = 3;
            // 
            // lblCorrespondentAccount
            // 
            lblCorrespondentAccount.Font = new Font("Segoe UI", 10F);
            lblCorrespondentAccount.Location = new Point(15, 120);
            lblCorrespondentAccount.Name = "lblCorrespondentAccount";
            lblCorrespondentAccount.Size = new Size(150, 28);
            lblCorrespondentAccount.TabIndex = 4;
            lblCorrespondentAccount.Text = "Корр. счет:";
            // 
            // txtCorrespondentAccount
            // 
            txtCorrespondentAccount.Font = new Font("Segoe UI", 10F);
            txtCorrespondentAccount.Location = new Point(171, 120);
            txtCorrespondentAccount.Name = "txtCorrespondentAccount";
            txtCorrespondentAccount.Size = new Size(239, 25);
            txtCorrespondentAccount.TabIndex = 5;
            // 
            // lblCheckingAccount
            // 
            lblCheckingAccount.Font = new Font("Segoe UI", 10F);
            lblCheckingAccount.Location = new Point(15, 165);
            lblCheckingAccount.Name = "lblCheckingAccount";
            lblCheckingAccount.Size = new Size(150, 28);
            lblCheckingAccount.TabIndex = 6;
            lblCheckingAccount.Text = "Расчетный счет:";
            // 
            // txtCheckingAccount
            // 
            txtCheckingAccount.Font = new Font("Segoe UI", 10F);
            txtCheckingAccount.Location = new Point(171, 165);
            txtCheckingAccount.Name = "txtCheckingAccount";
            txtCheckingAccount.Size = new Size(239, 25);
            txtCheckingAccount.TabIndex = 7;
            // 
            // chkIsDefault
            // 
            chkIsDefault.Font = new Font("Segoe UI", 10F);
            chkIsDefault.ForeColor = Color.FromArgb(0, 80, 131);
            chkIsDefault.Location = new Point(20, 710);
            chkIsDefault.Name = "chkIsDefault";
            chkIsDefault.Size = new Size(300, 30);
            chkIsDefault.TabIndex = 3;
            chkIsDefault.Text = "Сделать компанией по умолчанию";
            // 
            // lblRequiredInfo
            // 
            lblRequiredInfo.Font = new Font("Segoe UI", 9F);
            lblRequiredInfo.ForeColor = Color.Gray;
            lblRequiredInfo.Location = new Point(20, 745);
            lblRequiredInfo.Name = "lblRequiredInfo";
            lblRequiredInfo.Size = new Size(395, 19);
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
            btnSave.Location = new Point(140, 767);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 35);
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
            btnCancel.Location = new Point(266, 767);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddCompanyForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(594, 874);
            Controls.Add(mainPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddCompanyForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавить компанию";
            headerPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            gbMain.ResumeLayout(false);
            gbMain.PerformLayout();
            gbContact.ResumeLayout(false);
            gbContact.PerformLayout();
            gbBank.ResumeLayout(false);
            gbBank.PerformLayout();
            ResumeLayout(false);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название компании!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Введите телефон компании!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            try
            {
                int userId = (int)AppSession.CurrentUser.UserId;

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        if (chkIsDefault.Checked)
                        {
                            string sqlReset = "UPDATE prog.user_companies SET is_default = FALSE WHERE id_polzovatelya = @userId";
                            using (var cmd = new NpgsqlCommand(sqlReset, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("userId", userId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        string sqlCompany = @"
                            INSERT INTO prog.companies (
                                name, inn, kpp, ogrn, legal_address, actual_address, 
                                phone, email, director_name, bank_name, bik, 
                                correspondent_account, checking_account
                            ) VALUES (
                                @name, @inn, @kpp, @ogrn, @legal, @actual,
                                @phone, @email, @director, @bank, @bik,
                                @corr, @check
                            ) RETURNING id_company";

                        int companyId;
                        using (var cmd = new NpgsqlCommand(sqlCompany, conn, transaction))
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

                            companyId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        string sqlLink = @"
                            INSERT INTO prog.user_companies (id_polzovatelya, id_company, is_default)
                            VALUES (@userId, @companyId, @isDefault)";

                        using (var cmd = new NpgsqlCommand(sqlLink, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("userId", userId);
                            cmd.Parameters.AddWithValue("companyId", companyId);
                            cmd.Parameters.AddWithValue("isDefault", chkIsDefault.Checked);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                MessageBox.Show("Компания успешно зарегистрирована!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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