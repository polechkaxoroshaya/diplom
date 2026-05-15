using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace EVS
{
    public partial class MyCompaniesForm : Form
    {
        private string connectionString = "Host=localhost;Database=www2;Username=postgres;Password=root";
        private DataGridView dgvCompanies;
        private Button btnAddCompany;
        private Button btnEditCompany;
        private Button btnSetDefault;
        private Button btnClose;
        private Panel buttonPanel;
        private int userId;

        public MyCompaniesForm()
        {
            userId = (int)AppSession.CurrentUser.UserId;
            InitializeComponent();
            LoadCompanies();
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvCompanies = new DataGridView();
            buttonPanel = new Panel();
            btnAddCompany = new Button();
            btnEditCompany = new Button();
            btnSetDefault = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCompanies).BeginInit();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCompanies
            // 
            dgvCompanies.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 248, 255);
            dgvCompanies.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCompanies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompanies.BackgroundColor = Color.White;
            dgvCompanies.Dock = DockStyle.Fill;
            dgvCompanies.Font = new Font("Segoe UI", 10F);
            dgvCompanies.Location = new Point(0, 0);
            dgvCompanies.Name = "dgvCompanies";
            dgvCompanies.ReadOnly = true;
            dgvCompanies.RowHeadersVisible = false;
            dgvCompanies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompanies.Size = new Size(784, 411);
            dgvCompanies.TabIndex = 0;
            // 
            // buttonPanel
            // 
            buttonPanel.BackColor = Color.FromArgb(248, 249, 252);
            buttonPanel.Controls.Add(btnAddCompany);
            buttonPanel.Controls.Add(btnEditCompany);
            buttonPanel.Controls.Add(btnSetDefault);
            buttonPanel.Controls.Add(btnClose);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Location = new Point(0, 411);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(784, 50);
            buttonPanel.TabIndex = 1;
            // 
            // btnAddCompany
            // 
            btnAddCompany.BackColor = Color.FromArgb(0, 120, 200);
            btnAddCompany.Cursor = Cursors.Hand;
            btnAddCompany.FlatStyle = FlatStyle.Flat;
            btnAddCompany.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddCompany.ForeColor = Color.White;
            btnAddCompany.Location = new Point(10, 8);
            btnAddCompany.Name = "btnAddCompany";
            btnAddCompany.Size = new Size(150, 35);
            btnAddCompany.TabIndex = 0;
            btnAddCompany.Text = "+ Добавить компанию";
            btnAddCompany.UseVisualStyleBackColor = false;
            btnAddCompany.Click += BtnAddCompany_Click;
            // 
            // btnEditCompany
            // 
            btnEditCompany.BackColor = Color.White;
            btnEditCompany.Cursor = Cursors.Hand;
            btnEditCompany.FlatStyle = FlatStyle.Flat;
            btnEditCompany.Font = new Font("Segoe UI", 10F);
            btnEditCompany.ForeColor = Color.FromArgb(0, 80, 131);
            btnEditCompany.Location = new Point(170, 8);
            btnEditCompany.Name = "btnEditCompany";
            btnEditCompany.Size = new Size(56, 35);
            btnEditCompany.TabIndex = 1;
            btnEditCompany.Text = "✏️ Редактировать";
            btnEditCompany.UseVisualStyleBackColor = false;
            btnEditCompany.Click += BtnEditCompany_Click;
            // 
            // btnSetDefault
            // 
            btnSetDefault.BackColor = Color.White;
            btnSetDefault.Cursor = Cursors.Hand;
            btnSetDefault.FlatStyle = FlatStyle.Flat;
            btnSetDefault.Font = new Font("Segoe UI", 10F);
            btnSetDefault.ForeColor = Color.FromArgb(0, 80, 131);
            btnSetDefault.Location = new Point(357, 8);
            btnSetDefault.Name = "btnSetDefault";
            btnSetDefault.Size = new Size(296, 35);
            btnSetDefault.TabIndex = 2;
            btnSetDefault.Text = "⭐ Сделать компанией по умолчанию";
            btnSetDefault.UseVisualStyleBackColor = false;
            btnSetDefault.Click += BtnSetDefault_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.LightGray;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.ForeColor = Color.FromArgb(0, 80, 131);
            btnClose.Location = new Point(242, 8);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 35);
            btnClose.TabIndex = 3;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // MyCompaniesForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(784, 461);
            Controls.Add(dgvCompanies);
            Controls.Add(buttonPanel);
            Name = "MyCompaniesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Мои компании";
            ((System.ComponentModel.ISupportInitialize)dgvCompanies).EndInit();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void LoadCompanies()
        {
            try
            {
                string sql = @"
                    SELECT 
                        c.id_company,
                        c.name,
                        c.inn,
                        c.legal_address,
                        c.phone,
                        c.director_name,
                        uc.is_default
                    FROM prog.companies c
                    JOIN prog.user_companies uc ON c.id_company = uc.id_company
                    WHERE uc.id_polzovatelya = @userId
                    ORDER BY uc.is_default DESC, c.name";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        cmd.Parameters.AddWithValue("userId", userId);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvCompanies.DataSource = dt;

                        if (dgvCompanies.Columns["id_company"] != null)
                            dgvCompanies.Columns["id_company"].Visible = false;
                        if (dgvCompanies.Columns["name"] != null)
                            dgvCompanies.Columns["name"].HeaderText = "Название компании";
                        if (dgvCompanies.Columns["inn"] != null)
                            dgvCompanies.Columns["inn"].HeaderText = "ИНН";
                        if (dgvCompanies.Columns["legal_address"] != null)
                            dgvCompanies.Columns["legal_address"].HeaderText = "Юридический адрес";
                        if (dgvCompanies.Columns["phone"] != null)
                            dgvCompanies.Columns["phone"].HeaderText = "Телефон";
                        if (dgvCompanies.Columns["director_name"] != null)
                            dgvCompanies.Columns["director_name"].HeaderText = "Директор";
                        if (dgvCompanies.Columns["is_default"] != null)
                            dgvCompanies.Columns["is_default"].HeaderText = "По умолчанию";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки компаний: " + ex.Message);
            }
        }

        private void BtnAddCompany_Click(object sender, EventArgs e)
        {
            using (var form = new AddCompanyForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCompanies();
                }
            }
        }

        private void BtnEditCompany_Click(object sender, EventArgs e)
        {
            if (dgvCompanies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите компанию для редактирования!");
                return;
            }

            long companyId = Convert.ToInt64(dgvCompanies.SelectedRows[0].Cells["id_company"].Value);
            string companyName = dgvCompanies.SelectedRows[0].Cells["name"].Value.ToString();

            using (var form = new EditCompanyForm(companyId, companyName))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCompanies();
                }
            }
        }

        private void BtnSetDefault_Click(object sender, EventArgs e)
        {
            if (dgvCompanies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите компанию, которую хотите сделать компанией по умолчанию!");
                return;
            }

            long companyId = Convert.ToInt64(dgvCompanies.SelectedRows[0].Cells["id_company"].Value);

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        // Сбрасываем is_default для всех компаний пользователя
                        string sqlReset = "UPDATE prog.user_companies SET is_default = FALSE WHERE id_polzovatelya = @userId";
                        using (var cmd = new NpgsqlCommand(sqlReset, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("userId", userId);
                            cmd.ExecuteNonQuery();
                        }

                        // Устанавливаем is_default для выбранной компании
                        string sqlSet = "UPDATE prog.user_companies SET is_default = TRUE WHERE id_polzovatelya = @userId AND id_company = @companyId";
                        using (var cmd = new NpgsqlCommand(sqlSet, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("userId", userId);
                            cmd.Parameters.AddWithValue("companyId", companyId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                MessageBox.Show("Компания успешно установлена как компания по умолчанию!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCompanies();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}