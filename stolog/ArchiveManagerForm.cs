using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace EVS
{
    public partial class ArchiveManagerForm : Form
    {
        private string connectionString = "Host=localhost;Database=www2;Username=postgres;Password=root";
        private DataGridView dgvArchive;
        private ComboBox cmbStatusFilter;
        private ComboBox cmbNewStatus;
        private Button btnRestore;
        private Button btnRefresh;
        private Button btnClose;
        private Label lblFilter;
        private Label lblNewStatus;
        private Label lblTitle;
        private Panel headerPanel;
        private Panel filterPanel;
        private Panel buttonPanel;
        private Label lblCount;

        public ArchiveManagerForm()
        {
            InitializeComponent();
            LoadArchiveRequests();
            LoadStatuses();
        }

        private void InitializeComponent()
        {
            dgvArchive = new DataGridView();
            cmbStatusFilter = new ComboBox();
            btnRestore = new Button();
            btnRefresh = new Button();
            btnClose = new Button();
            lblFilter = new Label();
            lblNewStatus = new Label();
            lblTitle = new Label();
            headerPanel = new Panel();
            filterPanel = new Panel();
            cmbNewStatus = new ComboBox();
            lblCount = new Label();
            buttonPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvArchive).BeginInit();
            headerPanel.SuspendLayout();
            filterPanel.SuspendLayout();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dgvArchive
            // 
            dgvArchive.AllowUserToAddRows = false;
            dgvArchive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchive.BackgroundColor = Color.White;
            dgvArchive.Dock = DockStyle.Fill;
            dgvArchive.Font = new Font("Segoe UI", 10F);
            dgvArchive.Location = new Point(0, 110);
            dgvArchive.Name = "dgvArchive";
            dgvArchive.ReadOnly = true;
            dgvArchive.RowHeadersVisible = false;
            dgvArchive.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchive.Size = new Size(1100, 440);
            dgvArchive.TabIndex = 0;
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Font = new Font("Segoe UI", 10F);
            cmbStatusFilter.Items.AddRange(new object[] { "Все статусы", "Выполнена", "Отменена", "Архив" });
            cmbStatusFilter.Location = new Point(148, 13);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(150, 25);
            cmbStatusFilter.TabIndex = 1;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // btnRestore
            // 
            btnRestore.BackColor = Color.FromArgb(0, 120, 200);
            btnRestore.Cursor = Cursors.Hand;
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRestore.ForeColor = Color.White;
            btnRestore.Location = new Point(350, 10);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(200, 40);
            btnRestore.TabIndex = 0;
            btnRestore.Text = "🔄 Вернуть из архива";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += btnRestore_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(100, 100, 100);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(570, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 40);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "🔄 Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(220, 230, 240);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.ForeColor = Color.FromArgb(200, 50, 50);
            btnClose.Location = new Point(710, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 2;
            btnClose.Text = "✖ Закрыть";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI", 10F);
            lblFilter.Location = new Point(15, 15);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(127, 19);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "Фильтр по статусу:";
            // 
            // lblNewStatus
            // 
            lblNewStatus.AutoSize = true;
            lblNewStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNewStatus.ForeColor = Color.FromArgb(0, 80, 131);
            lblNewStatus.Location = new Point(320, 15);
            lblNewStatus.Name = "lblNewStatus";
            lblNewStatus.Size = new Size(107, 19);
            lblNewStatus.TabIndex = 2;
            lblNewStatus.Text = "Новый статус:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(217, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📦 Архив заявок";
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(0, 80, 131);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1100, 60);
            headerPanel.TabIndex = 3;
            // 
            // filterPanel
            // 
            filterPanel.BackColor = Color.FromArgb(248, 249, 252);
            filterPanel.BorderStyle = BorderStyle.FixedSingle;
            filterPanel.Controls.Add(lblFilter);
            filterPanel.Controls.Add(cmbStatusFilter);
            filterPanel.Controls.Add(lblNewStatus);
            filterPanel.Controls.Add(cmbNewStatus);
            filterPanel.Controls.Add(lblCount);
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Location = new Point(0, 60);
            filterPanel.Name = "filterPanel";
            filterPanel.Padding = new Padding(10);
            filterPanel.Size = new Size(1100, 50);
            filterPanel.TabIndex = 1;
            // 
            // cmbNewStatus
            // 
            cmbNewStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNewStatus.Font = new Font("Segoe UI", 10F);
            cmbNewStatus.Location = new Point(433, 13);
            cmbNewStatus.Name = "cmbNewStatus";
            cmbNewStatus.Size = new Size(180, 25);
            cmbNewStatus.TabIndex = 3;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Segoe UI", 9F);
            lblCount.ForeColor = Color.Gray;
            lblCount.Location = new Point(650, 16);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(0, 15);
            lblCount.TabIndex = 4;
            // 
            // buttonPanel
            // 
            buttonPanel.BackColor = Color.White;
            buttonPanel.Controls.Add(btnRestore);
            buttonPanel.Controls.Add(btnRefresh);
            buttonPanel.Controls.Add(btnClose);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Location = new Point(0, 550);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Padding = new Padding(10);
            buttonPanel.Size = new Size(1100, 60);
            buttonPanel.TabIndex = 2;
            // 
            // ArchiveManagerForm
            // 
            ClientSize = new Size(1100, 610);
            Controls.Add(dgvArchive);
            Controls.Add(filterPanel);
            Controls.Add(buttonPanel);
            Controls.Add(headerPanel);
            Name = "ArchiveManagerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Управление архивом заявок - Столичная Логистика";
            ((System.ComponentModel.ISupportInitialize)dgvArchive).EndInit();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        // Загрузка статусов в ComboBox
        private void LoadStatuses()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT id_status, status_name 
                                   FROM zakazzs.zayavki_status 
                                   WHERE is_active = true AND id_status NOT IN (5,6,7)
                                   ORDER BY status_order";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbNewStatus.Items.Clear();
                        cmbNewStatus.Items.Add(new StatusItem { Id = 0, Name = "Выберите статус" });
                        while (reader.Read())
                        {
                            cmbNewStatus.Items.Add(new StatusItem
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
                cmbNewStatus.DisplayMember = "Name";
                cmbNewStatus.ValueMember = "Id";
                cmbNewStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки статусов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка архивных заявок
        private void LoadArchiveRequests()
        {
            try
            {
                string statusFilter = cmbStatusFilter.SelectedItem?.ToString() ?? "Все статусы";

                string sql = @"
                    SELECT 
                        z.id_zayavki AS id,
                        p.p_familiya || ' ' || p.p_name AS client,
                        c.name AS company,
                        z.adress_ot AS from_addr, 
                        z.adress_do AS to_addr, 
                        z.data_podachi_mashiny AS order_date,
                        z.naimenovanie_gruza AS cargo,
                        s.status_name AS status,
                        z.archived_date AS archived_date,
                        z.id_status,
                        COALESCE(dr.s_familiya || ' ' || dr.s_imya, 'Не назначен') AS driver,
                        COALESCE(m.marka || ' (' || nm.nomer_mashini || ')', 'Не назначен') AS truck
                    FROM zakazzs.zayavki z
                    JOIN prog.polzovateli p ON z.id_zakazchika = p.id_polzovatelya
                    LEFT JOIN prog.companies c ON z.id_company = c.id_company
                    JOIN zakazzs.zayavki_status s ON z.id_status = s.id_status
                    LEFT JOIN sortydnikis.voditeli v ON z.id_voditel = v.id_voditelya
                    LEFT JOIN sortydnikis.sotrydniki dr ON v.id_sotrydnika = dr.id_sotrydnika
                    LEFT JOIN mashini.mashinki m ON z.id_mashina = m.id_mashini
                    LEFT JOIN mashini.nomeramashin nm ON m.nomer = nm.id_nomera
                    WHERE (z.is_archived = TRUE OR z.id_status IN (5,6,7))";

                if (statusFilter != "Все статусы")
                {
                    sql += " AND s.status_name = @statusFilter";
                }

                sql += " ORDER BY z.archived_date DESC, z.created_at DESC";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        if (statusFilter != "Все статусы")
                        {
                            cmd.Parameters.AddWithValue("statusFilter", statusFilter);
                        }

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvArchive.DataSource = dt;

                        // Настройка столбцов
                        if (dgvArchive.Columns["id"] != null)
                            dgvArchive.Columns["id"].HeaderText = "№";
                        if (dgvArchive.Columns["client"] != null)
                            dgvArchive.Columns["client"].HeaderText = "Клиент";
                        if (dgvArchive.Columns["company"] != null)
                            dgvArchive.Columns["company"].HeaderText = "Компания";
                        if (dgvArchive.Columns["from_addr"] != null)
                            dgvArchive.Columns["from_addr"].HeaderText = "Откуда";
                        if (dgvArchive.Columns["to_addr"] != null)
                            dgvArchive.Columns["to_addr"].HeaderText = "Куда";
                        if (dgvArchive.Columns["order_date"] != null)
                        {
                            dgvArchive.Columns["order_date"].HeaderText = "Дата подачи";
                            dgvArchive.Columns["order_date"].DefaultCellStyle.Format = "dd.MM.yyyy";
                        }
                        if (dgvArchive.Columns["cargo"] != null)
                            dgvArchive.Columns["cargo"].HeaderText = "Груз";
                        if (dgvArchive.Columns["status"] != null)
                            dgvArchive.Columns["status"].HeaderText = "Статус";
                        if (dgvArchive.Columns["archived_date"] != null)
                        {
                            dgvArchive.Columns["archived_date"].HeaderText = "Дата архивации";
                            dgvArchive.Columns["archived_date"].DefaultCellStyle.Format = "dd.MM.yyyy";
                        }
                        if (dgvArchive.Columns["driver"] != null)
                            dgvArchive.Columns["driver"].HeaderText = "Водитель";
                        if (dgvArchive.Columns["truck"] != null)
                            dgvArchive.Columns["truck"].HeaderText = "Автомобиль";

                        // Скрываем служебные столбцы
                        if (dgvArchive.Columns["id_status"] != null)
                            dgvArchive.Columns["id_status"].Visible = false;

                        // Подсчёт количества
                        lblCount.Text = $"Всего в архиве: {dgvArchive.Rows.Count} заявок";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки архива: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Возврат заявки из архива
        private void RestoreRequest(int requestId, int newStatusId)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // Обновляем статус и снимаем флаг архивации
                    string sql = @"
                        UPDATE zakazzs.zayavki 
                        SET id_status = @statusId,
                            is_archived = FALSE,
                            archived_date = NULL
                        WHERE id_zayavki = @requestId";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("statusId", newStatusId);
                        cmd.Parameters.AddWithValue("requestId", requestId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Заявка не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Получаем название статуса для сообщения
                string statusName = "";
                foreach (StatusItem item in cmbNewStatus.Items)
                {
                    if (item.Id == newStatusId)
                    {
                        statusName = item.Name;
                        break;
                    }
                }

                MessageBox.Show($"Заявка №{requestId} успешно восстановлена из архива со статусом «{statusName}».",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadArchiveRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при восстановлении заявки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик кнопки восстановления
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dgvArchive.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку из архива!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbNewStatus.SelectedItem == null || ((StatusItem)cmbNewStatus.SelectedItem).Id == 0)
            {
                MessageBox.Show("Выберите новый статус для заявки!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgvArchive.SelectedRows[0];
            int requestId = Convert.ToInt32(selectedRow.Cells["id"].Value);
            string currentStatus = selectedRow.Cells["status"].Value?.ToString() ?? "Неизвестно";
            int newStatusId = ((StatusItem)cmbNewStatus.SelectedItem).Id;
            string newStatusName = ((StatusItem)cmbNewStatus.SelectedItem).Name;

            DialogResult result = MessageBox.Show(
                $"Восстановить заявку №{requestId}?\n\n" +
                $"Текущий статус: {currentStatus}\n" +
                $"Новый статус: {newStatusName}\n\n" +
                $"Заявка будет перемещена в активные.",
                "Подтверждение восстановления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                RestoreRequest(requestId, newStatusId);
            }
        }

        // Обработчик обновления списка
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadArchiveRequests();
        }

        // Обработчик фильтра по статусу
        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadArchiveRequests();
        }

        // Закрытие формы
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Класс для элементов ComboBox
        public class StatusItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }
    }
}