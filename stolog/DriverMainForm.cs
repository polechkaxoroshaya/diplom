using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace EVS
{
    public partial class DriverMainForm : Form
    {
        private string connectionString = "Host=localhost;Database=www2;Username=postgres;Password=root";
        private RouteDocumentGenerator docGenerator = new RouteDocumentGenerator();

        private Panel headerPanel;
        private Label lblTitle;
        private Label lblWelcome;
        private Label lblDateTime;
        private System.Windows.Forms.Timer timerDateTime;
        private Panel sidePanel;
        private Button btnMyOrders;
        private Button btnPrintRoute;
        private Button btnLogout;
        private Panel contentPanel;
        private DataGridView dgvOrders;
        private ComboBox cmbStatus;
        private Button btnSaveStatus;
        private Label lblSelectedOrderInfo;
        private System.ComponentModel.IContainer components;
        private GroupBox gbOrderDetails;

        public DriverMainForm()
        {
            InitializeComponent();
            LoadMyOrders();
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            headerPanel = new Panel();
            lblTitle = new Label();
            lblWelcome = new Label();
            lblDateTime = new Label();
            timerDateTime = new System.Windows.Forms.Timer(components);
            sidePanel = new Panel();
            btnMyOrders = new Button();
            btnPrintRoute = new Button();
            btnLogout = new Button();
            contentPanel = new Panel();
            gbOrderDetails = new GroupBox();
            lblSelectedOrderInfo = new Label();
            dgvOrders = new DataGridView();
            cmbStatus = new ComboBox();
            btnSaveStatus = new Button();
            headerPanel.SuspendLayout();
            sidePanel.SuspendLayout();
            contentPanel.SuspendLayout();
            gbOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(0, 80, 131);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblWelcome);
            headerPanel.Controls.Add(lblDateTime);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1020, 90);
            headerPanel.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(732, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Столичная Логистика - Водительский портал";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 11F);
            lblWelcome.ForeColor = Color.FromArgb(200, 220, 255);
            lblWelcome.Location = new Point(35, 55);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(0, 20);
            lblWelcome.TabIndex = 1;
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDateTime.ForeColor = Color.White;
            lblDateTime.Location = new Point(284, 35);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(0, 21);
            lblDateTime.TabIndex = 2;
            lblDateTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timerDateTime
            // 
            timerDateTime.Enabled = true;
            timerDateTime.Interval = 1000;
            timerDateTime.Tick += timerDateTime_Tick;
            // 
            // sidePanel
            // 
            sidePanel.BackColor = Color.FromArgb(248, 249, 252);
            sidePanel.Controls.Add(btnMyOrders);
            sidePanel.Controls.Add(btnPrintRoute);
            sidePanel.Controls.Add(btnLogout);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.Location = new Point(0, 90);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(230, 576);
            sidePanel.TabIndex = 1;
            // 
            // btnMyOrders
            // 
            btnMyOrders.BackColor = Color.FromArgb(0, 120, 200);
            btnMyOrders.Cursor = Cursors.Hand;
            btnMyOrders.FlatStyle = FlatStyle.Flat;
            btnMyOrders.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMyOrders.ForeColor = Color.White;
            btnMyOrders.Location = new Point(15, 25);
            btnMyOrders.Name = "btnMyOrders";
            btnMyOrders.Size = new Size(200, 45);
            btnMyOrders.TabIndex = 0;
            btnMyOrders.Text = "📋 Мои заказы";
            btnMyOrders.UseVisualStyleBackColor = false;
            btnMyOrders.Click += btnMyOrders_Click;
            // 
            // btnPrintRoute
            // 
            btnPrintRoute.BackColor = Color.White;
            btnPrintRoute.Cursor = Cursors.Hand;
            btnPrintRoute.FlatStyle = FlatStyle.Flat;
            btnPrintRoute.Font = new Font("Segoe UI", 12F);
            btnPrintRoute.ForeColor = Color.FromArgb(0, 80, 131);
            btnPrintRoute.Location = new Point(15, 85);
            btnPrintRoute.Name = "btnPrintRoute";
            btnPrintRoute.Size = new Size(200, 45);
            btnPrintRoute.TabIndex = 1;
            btnPrintRoute.Text = "🖨️ Печать маршрута";
            btnPrintRoute.UseVisualStyleBackColor = false;
            btnPrintRoute.Click += btnPrintRoute_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(220, 230, 240);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.ForeColor = Color.FromArgb(200, 50, 50);
            btnLogout.Location = new Point(15, 250);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(200, 45);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "🚪 Выход";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.Controls.Add(gbOrderDetails);
            contentPanel.Controls.Add(dgvOrders);
            contentPanel.Controls.Add(cmbStatus);
            contentPanel.Controls.Add(btnSaveStatus);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(230, 90);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(20);
            contentPanel.Size = new Size(790, 576);
            contentPanel.TabIndex = 0;
            // 
            // gbOrderDetails
            // 
            gbOrderDetails.BackColor = Color.FromArgb(248, 249, 252);
            gbOrderDetails.Controls.Add(lblSelectedOrderInfo);
            gbOrderDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbOrderDetails.Location = new Point(20, 20);
            gbOrderDetails.Name = "gbOrderDetails";
            gbOrderDetails.Size = new Size(500, 120);
            gbOrderDetails.TabIndex = 0;
            gbOrderDetails.TabStop = false;
            gbOrderDetails.Text = "📋 Информация о выбранном заказе";
            gbOrderDetails.Visible = false;
            // 
            // lblSelectedOrderInfo
            // 
            lblSelectedOrderInfo.Font = new Font("Segoe UI", 10F);
            lblSelectedOrderInfo.Location = new Point(10, 25);
            lblSelectedOrderInfo.Name = "lblSelectedOrderInfo";
            lblSelectedOrderInfo.Size = new Size(470, 80);
            lblSelectedOrderInfo.TabIndex = 0;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 248, 255);
            dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.Font = new Font("Segoe UI", 10F);
            dgvOrders.Location = new Point(20, 150);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(747, 467);
            dgvOrders.TabIndex = 1;
            dgvOrders.CellClick += DgvOrders_CellClick;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 11F);
            cmbStatus.Items.AddRange(new object[] { "В пути", "Доставлен", "Проблемы" });
            cmbStatus.Location = new Point(20, 610);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 28);
            cmbStatus.TabIndex = 2;
            cmbStatus.Visible = false;
            // 
            // btnSaveStatus
            // 
            btnSaveStatus.BackColor = Color.FromArgb(0, 120, 200);
            btnSaveStatus.Cursor = Cursors.Hand;
            btnSaveStatus.FlatStyle = FlatStyle.Flat;
            btnSaveStatus.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSaveStatus.ForeColor = Color.White;
            btnSaveStatus.Location = new Point(230, 610);
            btnSaveStatus.Name = "btnSaveStatus";
            btnSaveStatus.Size = new Size(150, 28);
            btnSaveStatus.TabIndex = 3;
            btnSaveStatus.Text = "Сохранить статус";
            btnSaveStatus.UseVisualStyleBackColor = false;
            btnSaveStatus.Visible = false;
            btnSaveStatus.Click += BtnSaveStatus_Click;
            // 
            // DriverMainForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1020, 666);
            Controls.Add(contentPanel);
            Controls.Add(sidePanel);
            Controls.Add(headerPanel);
            Name = "DriverMainForm";
            Text = "Столичная Логистика - Водительский портал";
            WindowState = FormWindowState.Maximized;
            Resize += DriverMainForm_Resize;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            sidePanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            gbOrderDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
        }

        private long GetDriverId()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT id_voditelya FROM sortydnikis.voditeli WHERE id_sotrydnika = @empId";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("empId", AppSession.CurrentUser.UserId);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt64(result) : 0;
                    }
                }
            }
            catch { return 0; }
        }

        // ИСПРАВЛЕННЫЙ МЕТОД ЗАГРУЗКИ ЗАКАЗОВ
        private void LoadMyOrders()
        {
            try
            {
                long driverId = GetDriverId();
                if (driverId == 0)
                {
                    MessageBox.Show("Водитель не найден в системе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Явно преобразуем дату в текст, чтобы избежать DateTimeOnly ошибок
                string sql = @"
                    SELECT 
                        z.id_zayavki AS id,
                        c.name AS company,
                        z.adress_ot AS from_addr, 
                        z.adress_do AS to_addr, 
                        TO_CHAR(z.data_podachi_mashiny, 'DD.MM.YYYY HH24:MI') AS order_date,
                        z.naimenovanie_gruza AS cargo,
                        COALESCE(m.marka || ' ' || m.polnoe_nazvanie || ' (' || nm.nomer_mashini || ')', 'Не назначен') AS truck
                    FROM zakazzs.zayavki z
                    LEFT JOIN prog.companies c ON z.id_company = c.id_company
                    LEFT JOIN mashini.mashinki m ON z.id_mashina = m.id_mashini
                    LEFT JOIN mashini.nomeramashin nm ON m.nomer = nm.id_nomera
                    WHERE z.id_voditel = @driverId
                    ORDER BY z.data_podachi_mashiny DESC";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("driverId", driverId);

                        DataTable dt = new DataTable();
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        dgvOrders.DataSource = dt;

                        // НАСТРОЙКА СТОЛБЦОВ - ВСЕ ВМЕЩАЮТСЯ
                        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        if (dgvOrders.Columns["id"] != null)
                        {
                            dgvOrders.Columns["id"].HeaderText = "№";
                            dgvOrders.Columns["id"].FillWeight = 5;  // 5% ширины
                        }

                        if (dgvOrders.Columns["company"] != null)
                        {
                            dgvOrders.Columns["company"].HeaderText = "Компания";
                            dgvOrders.Columns["company"].FillWeight = 15; // 15% ширины
                        }

                        if (dgvOrders.Columns["from_addr"] != null)
                        {
                            dgvOrders.Columns["from_addr"].HeaderText = "Откуда";
                            dgvOrders.Columns["from_addr"].FillWeight = 20; // 20% ширины
                        }

                        if (dgvOrders.Columns["to_addr"] != null)
                        {
                            dgvOrders.Columns["to_addr"].HeaderText = "Куда";
                            dgvOrders.Columns["to_addr"].FillWeight = 20; // 20% ширины
                        }

                        if (dgvOrders.Columns["order_date"] != null)
                        {
                            dgvOrders.Columns["order_date"].HeaderText = "Дата подачи";
                            dgvOrders.Columns["order_date"].FillWeight = 12; // 12% ширины
                        }

                        if (dgvOrders.Columns["cargo"] != null)
                        {
                            dgvOrders.Columns["cargo"].HeaderText = "Груз";
                            dgvOrders.Columns["cargo"].FillWeight = 13; // 13% ширины
                        }

                        if (dgvOrders.Columns["truck"] != null)
                        {
                            dgvOrders.Columns["truck"].HeaderText = "Автомобиль";
                            dgvOrders.Columns["truck"].FillWeight = 15; // 15% ширины
                        }
                        // Запрещаем изменение размеров столбцов пользователем (опционально)
                        foreach (DataGridViewColumn col in dgvOrders.Columns)
                        {
                            col.Resizable = DataGridViewTriState.False;
                        }
                    }           
                }

                UpdateOrderCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки заказов: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       private void btnPrintRoute_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите заказ из списка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dgvOrders.SelectedRows[0];

                long requestId = Convert.ToInt64(selectedRow.Cells["id"].Value);
                string from = selectedRow.Cells["from_addr"].Value?.ToString() ?? "";
                string to = selectedRow.Cells["to_addr"].Value?.ToString() ?? "";
                string cargoName = selectedRow.Cells["cargo"].Value?.ToString() ?? "";
                string driverName = AppSession.CurrentUser?.FullName ?? "Водитель";
                string truckInfo = selectedRow.Cells["truck"].Value?.ToString() ?? "Не назначен";
                string companyName = selectedRow.Cells["company"].Value?.ToString() ?? "";
                
                // Безопасное получение даты из строки (она уже отформатирована TO_CHAR)
                DateTime orderDate = DateTime.Now;
                string dateStr = selectedRow.Cells["order_date"].Value?.ToString();
                if (!string.IsNullOrEmpty(dateStr))
                {
                    try
                    {
                        orderDate = DateTime.Parse(dateStr);
                    }
                    catch
                    {
                        orderDate = DateTime.Now;
                    }
                }
                
                string wishes = "";
                string receiverOrg = "";
                string receiverAddress = "";
                string receiverContact = "";

                if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
                {
                    MessageBox.Show("Недостаточно данных для печати маршрутного листа!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                docGenerator.ExportToPDF(requestId, from, to, cargoName, driverName, truckInfo,
                    companyName, orderDate, wishes, receiverOrg, receiverAddress, receiverContact);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при печати маршрутного листа: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOrderCount()
        {
            try
            {
                int rowCount = dgvOrders.Rows.Count;
                this.Text = $"Столичная Логистика - Водительский портал ({rowCount} заказов)";
            }
            catch { }
        }

        // Обработчик выбора заказа в таблице
        private void DgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow selectedRow = dgvOrders.Rows[e.RowIndex];

            gbOrderDetails.Visible = true;

            string dateTime = "";
            if (selectedRow.Cells["order_date"].Value != null)
            {
                try
                {
                    DateTime dt = Convert.ToDateTime(selectedRow.Cells["order_date"].Value);
                    dateTime = dt.ToString("dd.MM.yyyy HH:mm");
                }
                catch
                {
                    dateTime = selectedRow.Cells["order_date"].Value.ToString();
                }
            }

            lblSelectedOrderInfo.Text =
                $"Заказ №{selectedRow.Cells["id"].Value}\n" +
                $"Компания: {selectedRow.Cells["company"].Value}\n" +
                $"Откуда: {selectedRow.Cells["from_addr"].Value}\n" +
                $"Куда: {selectedRow.Cells["to_addr"].Value}\n" +
                $"Дата подачи: {dateTime}\n" +
                $"Автомобиль: {selectedRow.Cells["truck"].Value}\n" +
                $"Груз: {selectedRow.Cells["cargo"].Value}";

            cmbStatus.Visible = true;
            btnSaveStatus.Visible = true;
            cmbStatus.SelectedIndex = -1;
        }
       
        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            LoadMyOrders();
            gbOrderDetails.Visible = false;
            cmbStatus.Visible = false;
            btnSaveStatus.Visible = false;
        }

        private void BtnSaveStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long orderId = Convert.ToInt64(dgvOrders.SelectedRows[0].Cells["id"].Value);
            string newStatus = cmbStatus.SelectedItem.ToString();
            int statusId = newStatus == "В пути" ? 5 : (newStatus == "Доставлен" ? 7 : 9);

            string userName = AppSession.CurrentUser?.FullName ?? "Водитель";

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // Устанавливаем имя пользователя для сессии
                    using (var cmdSetUser = new NpgsqlCommand("SET app.current_user_name = @userName", conn))
                    {
                        cmdSetUser.Parameters.AddWithValue("userName", userName);
                        cmdSetUser.ExecuteNonQuery();
                    }

                    string sql = "UPDATE zakazzs.zayavki SET id_status = @status WHERE id_zayavki = @id";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("status", statusId);
                        cmd.Parameters.AddWithValue("id", orderId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Статус заказа №{orderId} изменен на \"{newStatus}\"!",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadMyOrders();
                cmbStatus.Visible = false;
                btnSaveStatus.Visible = false;
                gbOrderDetails.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            AdjustHeaderLayout();
        }

        private void DriverMainForm_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            AdjustHeaderLayout();
        }

        private void AdjustHeaderLayout()
        {
            lblDateTime.Location = new Point(this.ClientSize.Width - lblDateTime.Width - 30, 35);
            if (btnLogout != null)
            {
                btnLogout.Location = new Point(15, this.ClientSize.Height - 80);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AppSession.Logout();
            this.Close();
            Application.Restart();
        }
    }
}