using EVS;
using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EVS
{
    public partial class ManagerMainForm : Form
    {
        private string connectionString = "Host=localhost;Database=www2;Username=postgres;Password=root";

        private Panel headerPanel;
        private Label lblTitle;
        private Label lblWelcome;
        private Label lblDateTime;
        private System.Windows.Forms.Timer timerDateTime;
        private Panel sidePanel;
        private Button btnRequests;
        private Button btnAssign;
        private Button btnDrivers;
        private Button btnAddDriver;
        private Button btnAddTruck;
        private Button btnLogout;
        private Panel contentPanel;
        private DataGridView dgvRequests;
        private DataGridView dgvDrivers;
        private Panel assignPanel;
        private ComboBox cmbDrivers;
        private ComboBox cmbTrucks;
        private ComboBox cmbNewStatus;
        private Button btnAssignDriver;
        private Button btnChangeStatus;
        private Button btnRefresh;
        private Label lblSelectedRequest;
        private Label lblRequestInfo;
        private Label lblCurrentDriver;
        private Label lblCurrentTruck;

        private long selectedRequestId = -1;
        private int currentRequestStatus = 1;
        private long currentDriverId = 0;
        private Label lblSubtitle;
        private System.ComponentModel.IContainer components;
        private Label lblDriver;
        private Label lblTruck;
        private Label lblStatus;
        private long currentTruckId = 0;
        private Button btnPrintRoute;
        // 
        private Button btnPrintOrder;
        private Button btnCloseAssignPanel;
        public ManagerMainForm()
        {
            InitializeComponent();
            LoadRequests();
            LoadDrivers();
            LoadTrucks();
            LoadStatuses();
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            headerPanel = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblWelcome = new Label();
            lblDateTime = new Label();
            timerDateTime = new System.Windows.Forms.Timer(components);
            sidePanel = new Panel();
            btnPrintOrder = new Button();
            btnRequests = new Button();
            btnAssign = new Button();
            btnDrivers = new Button();
            btnAddDriver = new Button();
            btnAddTruck = new Button();
            btnLogout = new Button();
            contentPanel = new Panel();
            assignPanel = new Panel();
            btnCloseAssignPanel = new Button();
            lblSelectedRequest = new Label();
            lblRequestInfo = new Label();
            lblCurrentDriver = new Label();
            lblCurrentTruck = new Label();
            lblDriver = new Label();
            cmbDrivers = new ComboBox();
            lblTruck = new Label();
            cmbTrucks = new ComboBox();
            lblStatus = new Label();
            cmbNewStatus = new ComboBox();
            btnAssignDriver = new Button();
            btnChangeStatus = new Button();
            btnRefresh = new Button();
            dgvRequests = new DataGridView();
            dgvDrivers = new DataGridView();
            btnPrintRoute = new Button();
            headerPanel.SuspendLayout();
            sidePanel.SuspendLayout();
            contentPanel.SuspendLayout();
            assignPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDrivers).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(0, 80, 131);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblSubtitle);
            headerPanel.Controls.Add(lblWelcome);
            headerPanel.Controls.Add(lblDateTime);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1522, 110);
            headerPanel.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(390, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Столичная Логистика";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 12F);
            lblSubtitle.ForeColor = Color.FromArgb(200, 220, 255);
            lblSubtitle.Location = new Point(35, 67);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(236, 21);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Панель управления менеджера";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 11F);
            lblWelcome.ForeColor = Color.FromArgb(200, 220, 255);
            lblWelcome.Location = new Point(35, 80);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(0, 20);
            lblWelcome.TabIndex = 2;
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDateTime.ForeColor = Color.White;
            lblDateTime.Location = new Point(284, 40);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(0, 21);
            lblDateTime.TabIndex = 3;
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
            sidePanel.Controls.Add(btnPrintOrder);
            sidePanel.Controls.Add(btnRequests);
            sidePanel.Controls.Add(btnAssign);
            sidePanel.Controls.Add(btnDrivers);
            sidePanel.Controls.Add(btnAddDriver);
            sidePanel.Controls.Add(btnAddTruck);
            sidePanel.Controls.Add(btnLogout);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.Location = new Point(0, 110);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(259, 951);
            sidePanel.TabIndex = 1;
            // 
            // btnPrintOrder
            // 
            btnPrintOrder.BackColor = Color.White;
            btnPrintOrder.Cursor = Cursors.Hand;
            btnPrintOrder.FlatStyle = FlatStyle.Flat;
            btnPrintOrder.Font = new Font("Segoe UI", 11F);
            btnPrintOrder.ForeColor = Color.FromArgb(0, 80, 131);
            btnPrintOrder.Location = new Point(10, 295);
            btnPrintOrder.Name = "btnPrintOrder";
            btnPrintOrder.Size = new Size(210, 45);
            btnPrintOrder.TabIndex = 0;
            btnPrintOrder.Text = "📄 Печать заявки";
            btnPrintOrder.UseVisualStyleBackColor = false;
            btnPrintOrder.Click += btnPrintOrder_Click;
            // 
            // btnRequests
            // 
            btnRequests.BackColor = Color.FromArgb(0, 120, 200);
            btnRequests.Cursor = Cursors.Hand;
            btnRequests.FlatStyle = FlatStyle.Flat;
            btnRequests.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRequests.ForeColor = Color.White;
            btnRequests.Location = new Point(10, 20);
            btnRequests.Name = "btnRequests";
            btnRequests.Size = new Size(210, 45);
            btnRequests.TabIndex = 0;
            btnRequests.Text = "📋 Все заявки";
            btnRequests.UseVisualStyleBackColor = false;
            btnRequests.Click += btnRequests_Click;
            // 
            // btnAssign
            // 
            btnAssign.BackColor = Color.White;
            btnAssign.Cursor = Cursors.Hand;
            btnAssign.FlatStyle = FlatStyle.Flat;
            btnAssign.Font = new Font("Segoe UI", 11F);
            btnAssign.ForeColor = Color.FromArgb(0, 80, 131);
            btnAssign.Location = new Point(10, 75);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new Size(210, 45);
            btnAssign.TabIndex = 1;
            btnAssign.Text = "👨‍✈️ Назначить водителя";
            btnAssign.UseVisualStyleBackColor = false;
            btnAssign.Click += btnAssign_Click;
            // 
            // btnDrivers
            // 
            btnDrivers.BackColor = Color.White;
            btnDrivers.Cursor = Cursors.Hand;
            btnDrivers.FlatStyle = FlatStyle.Flat;
            btnDrivers.Font = new Font("Segoe UI", 11F);
            btnDrivers.ForeColor = Color.FromArgb(0, 80, 131);
            btnDrivers.Location = new Point(10, 130);
            btnDrivers.Name = "btnDrivers";
            btnDrivers.Size = new Size(210, 45);
            btnDrivers.TabIndex = 2;
            btnDrivers.Text = "🚚 Список водителей";
            btnDrivers.UseVisualStyleBackColor = false;
            btnDrivers.Click += btnDrivers_Click;
            // 
            // btnAddDriver
            // 
            btnAddDriver.BackColor = Color.White;
            btnAddDriver.Cursor = Cursors.Hand;
            btnAddDriver.FlatStyle = FlatStyle.Flat;
            btnAddDriver.Font = new Font("Segoe UI", 11F);
            btnAddDriver.ForeColor = Color.FromArgb(0, 80, 131);
            btnAddDriver.Location = new Point(10, 185);
            btnAddDriver.Name = "btnAddDriver";
            btnAddDriver.Size = new Size(210, 45);
            btnAddDriver.TabIndex = 3;
            btnAddDriver.Text = "➕ Добавить водителя";
            btnAddDriver.UseVisualStyleBackColor = false;
            btnAddDriver.Click += btnAddDriver_Click;
            // 
            // btnAddTruck
            // 
            btnAddTruck.BackColor = Color.White;
            btnAddTruck.Cursor = Cursors.Hand;
            btnAddTruck.FlatStyle = FlatStyle.Flat;
            btnAddTruck.Font = new Font("Segoe UI", 11F);
            btnAddTruck.ForeColor = Color.FromArgb(0, 80, 131);
            btnAddTruck.Location = new Point(10, 240);
            btnAddTruck.Name = "btnAddTruck";
            btnAddTruck.Size = new Size(210, 45);
            btnAddTruck.TabIndex = 4;
            btnAddTruck.Text = "➕ Добавить автомобиль";
            btnAddTruck.UseVisualStyleBackColor = false;
            btnAddTruck.Click += btnAddTruck_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(220, 230, 240);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.ForeColor = Color.FromArgb(200, 50, 50);
            btnLogout.Location = new Point(10, 391);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(210, 45);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "🚪 Выход";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // contentPanel
            // 
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.White;
            contentPanel.Controls.Add(assignPanel);
            contentPanel.Controls.Add(dgvRequests);
            contentPanel.Controls.Add(dgvDrivers);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(259, 110);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(20);
            contentPanel.Size = new Size(1263, 951);
            contentPanel.TabIndex = 0;
            // 
            // assignPanel
            // 
            assignPanel.BackColor = Color.FromArgb(248, 249, 252);
            assignPanel.BorderStyle = BorderStyle.FixedSingle;
            assignPanel.Controls.Add(btnCloseAssignPanel);
            assignPanel.Controls.Add(lblSelectedRequest);
            assignPanel.Controls.Add(lblRequestInfo);
            assignPanel.Controls.Add(lblCurrentDriver);
            assignPanel.Controls.Add(lblCurrentTruck);
            assignPanel.Controls.Add(lblDriver);
            assignPanel.Controls.Add(cmbDrivers);
            assignPanel.Controls.Add(lblTruck);
            assignPanel.Controls.Add(cmbTrucks);
            assignPanel.Controls.Add(lblStatus);
            assignPanel.Controls.Add(cmbNewStatus);
            assignPanel.Controls.Add(btnAssignDriver);
            assignPanel.Controls.Add(btnChangeStatus);
            assignPanel.Controls.Add(btnRefresh);
            assignPanel.Location = new Point(20, 20);
            assignPanel.Name = "assignPanel";
            assignPanel.Size = new Size(650, 470);
            assignPanel.TabIndex = 0;
            assignPanel.Visible = false;
            // 
            // btnCloseAssignPanel
            // 
            btnCloseAssignPanel.BackColor = Color.Transparent;
            btnCloseAssignPanel.Cursor = Cursors.Hand;
            btnCloseAssignPanel.FlatAppearance.BorderSize = 0;
            btnCloseAssignPanel.FlatStyle = FlatStyle.Flat;
            btnCloseAssignPanel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCloseAssignPanel.ForeColor = Color.Gray;
            btnCloseAssignPanel.Location = new Point(605, 6);
            btnCloseAssignPanel.Name = "btnCloseAssignPanel";
            btnCloseAssignPanel.Size = new Size(30, 30);
            btnCloseAssignPanel.TabIndex = 0;
            btnCloseAssignPanel.Text = "✖";
            btnCloseAssignPanel.UseVisualStyleBackColor = false;
            btnCloseAssignPanel.Click += BtnCloseAssignPanel_Click;
            // 
            // lblSelectedRequest
            // 
            lblSelectedRequest.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSelectedRequest.ForeColor = Color.FromArgb(0, 80, 131);
            lblSelectedRequest.Location = new Point(20, 20);
            lblSelectedRequest.Name = "lblSelectedRequest";
            lblSelectedRequest.Size = new Size(600, 30);
            lblSelectedRequest.TabIndex = 0;
            // 
            // lblRequestInfo
            // 
            lblRequestInfo.Font = new Font("Segoe UI", 10F);
            lblRequestInfo.ForeColor = Color.FromArgb(80, 80, 80);
            lblRequestInfo.Location = new Point(20, 60);
            lblRequestInfo.Name = "lblRequestInfo";
            lblRequestInfo.Size = new Size(600, 80);
            lblRequestInfo.TabIndex = 1;
            // 
            // lblCurrentDriver
            // 
            lblCurrentDriver.Font = new Font("Segoe UI", 10F);
            lblCurrentDriver.ForeColor = Color.FromArgb(0, 120, 200);
            lblCurrentDriver.Location = new Point(20, 155);
            lblCurrentDriver.Name = "lblCurrentDriver";
            lblCurrentDriver.Size = new Size(350, 25);
            lblCurrentDriver.TabIndex = 2;
            lblCurrentDriver.Text = "Текущий водитель: не назначен";
            // 
            // lblCurrentTruck
            // 
            lblCurrentTruck.Font = new Font("Segoe UI", 10F);
            lblCurrentTruck.ForeColor = Color.FromArgb(0, 120, 200);
            lblCurrentTruck.Location = new Point(20, 185);
            lblCurrentTruck.Name = "lblCurrentTruck";
            lblCurrentTruck.Size = new Size(350, 25);
            lblCurrentTruck.TabIndex = 3;
            lblCurrentTruck.Text = "Текущий автомобиль: не назначен";
            // 
            // lblDriver
            // 
            lblDriver.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDriver.Location = new Point(20, 225);
            lblDriver.Name = "lblDriver";
            lblDriver.Size = new Size(150, 30);
            lblDriver.TabIndex = 4;
            lblDriver.Text = "Назначить водителя:";
            // 
            // cmbDrivers
            // 
            cmbDrivers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrivers.Font = new Font("Segoe UI", 10F);
            cmbDrivers.Location = new Point(180, 225);
            cmbDrivers.Name = "cmbDrivers";
            cmbDrivers.Size = new Size(280, 25);
            cmbDrivers.TabIndex = 5;
            // 
            // lblTruck
            // 
            lblTruck.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTruck.Location = new Point(20, 270);
            lblTruck.Name = "lblTruck";
            lblTruck.Size = new Size(150, 30);
            lblTruck.TabIndex = 6;
            lblTruck.Text = "Назначить автомобиль:";
            // 
            // cmbTrucks
            // 
            cmbTrucks.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrucks.Font = new Font("Segoe UI", 10F);
            cmbTrucks.Location = new Point(180, 270);
            cmbTrucks.Name = "cmbTrucks";
            cmbTrucks.Size = new Size(280, 25);
            cmbTrucks.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(20, 315);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(150, 30);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Изменить статус:";
            // 
            // cmbNewStatus
            // 
            cmbNewStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNewStatus.Font = new Font("Segoe UI", 10F);
            cmbNewStatus.Location = new Point(180, 315);
            cmbNewStatus.Name = "cmbNewStatus";
            cmbNewStatus.Size = new Size(200, 25);
            cmbNewStatus.TabIndex = 9;
            // 
            // btnAssignDriver
            // 
            btnAssignDriver.BackColor = Color.FromArgb(0, 120, 200);
            btnAssignDriver.Cursor = Cursors.Hand;
            btnAssignDriver.FlatStyle = FlatStyle.Flat;
            btnAssignDriver.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAssignDriver.ForeColor = Color.White;
            btnAssignDriver.Location = new Point(180, 360);
            btnAssignDriver.Name = "btnAssignDriver";
            btnAssignDriver.Size = new Size(280, 45);
            btnAssignDriver.TabIndex = 10;
            btnAssignDriver.Text = "✅ Назначить водителя и автомобиль";
            btnAssignDriver.UseVisualStyleBackColor = false;
            btnAssignDriver.Click += btnAssignDriver_Click;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.BackColor = Color.FromArgb(0, 150, 100);
            btnChangeStatus.Cursor = Cursors.Hand;
            btnChangeStatus.FlatStyle = FlatStyle.Flat;
            btnChangeStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChangeStatus.ForeColor = Color.White;
            btnChangeStatus.Location = new Point(400, 312);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(150, 35);
            btnChangeStatus.TabIndex = 11;
            btnChangeStatus.Text = "🔄 Изменить статус";
            btnChangeStatus.UseVisualStyleBackColor = false;
            btnChangeStatus.Click += btnChangeStatus_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(100, 100, 100);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(20, 420);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 30);
            btnRefresh.TabIndex = 12;
            btnRefresh.Text = "🔄 Обновить список";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvRequests
            // 
            dgvRequests.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 248, 255);
            dgvRequests.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.BackgroundColor = Color.White;
            dgvRequests.Dock = DockStyle.Fill;
            dgvRequests.Font = new Font("Segoe UI", 10F);
            dgvRequests.Location = new Point(20, 20);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.ReadOnly = true;
            dgvRequests.RowHeadersVisible = false;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.Size = new Size(1223, 911);
            dgvRequests.TabIndex = 1;
            dgvRequests.CellClick += DgvRequests_CellClick;
            // 
            // dgvDrivers
            // 
            dgvDrivers.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(240, 248, 255);
            dgvDrivers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDrivers.BackgroundColor = Color.White;
            dgvDrivers.Dock = DockStyle.Fill;
            dgvDrivers.Font = new Font("Segoe UI", 10F);
            dgvDrivers.Location = new Point(20, 20);
            dgvDrivers.Name = "dgvDrivers";
            dgvDrivers.ReadOnly = true;
            dgvDrivers.RowHeadersVisible = false;
            dgvDrivers.Size = new Size(1223, 511);
            dgvDrivers.TabIndex = 2;
            dgvDrivers.Visible = false;
            // 
            // btnPrintRoute
            // 
            btnPrintRoute.BackColor = Color.White;
            btnPrintRoute.Cursor = Cursors.Hand;
            btnPrintRoute.FlatStyle = FlatStyle.Flat;
            btnPrintRoute.Font = new Font("Segoe UI", 11F);
            btnPrintRoute.ForeColor = Color.FromArgb(0, 80, 131);
            btnPrintRoute.Location = new Point(10, 316);
            btnPrintRoute.Name = "btnPrintRoute";
            btnPrintRoute.Size = new Size(210, 45);
            btnPrintRoute.TabIndex = 0;
            btnPrintRoute.Text = "🖨️ Маршрутный лист";
            btnPrintRoute.UseVisualStyleBackColor = false;
            btnPrintRoute.Click += btnPrintRoute_Click;
            // 
            // ManagerMainForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1522, 1061);
            Controls.Add(contentPanel);
            Controls.Add(sidePanel);
            Controls.Add(headerPanel);
            Name = "ManagerMainForm";
            Text = "Столичная Логистика - Панель менеджера";
            WindowState = FormWindowState.Maximized;
            Resize += ManagerMainForm_Resize;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            sidePanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            assignPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDrivers).EndInit();
            ResumeLayout(false);
        }

        // ==================== ОБРАБОТЧИКИ СОБЫТИЙ ====================
        private void BtnCloseAssignPanel_Click(object sender, EventArgs e)
        {
            assignPanel.Visible = false;
        }

        private RouteDocumentGenerator docGenerator = new RouteDocumentGenerator();

        private void btnPrintRoute_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку из списка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgvRequests.SelectedRows[0];

            long requestId = Convert.ToInt64(selectedRow.Cells["id"].Value);
            string from = selectedRow.Cells["from_addr"].Value?.ToString() ?? "";
            string to = selectedRow.Cells["to_addr"].Value?.ToString() ?? "";
            string cargoName = selectedRow.Cells["cargo"].Value?.ToString() ?? "";
            string driverName = selectedRow.Cells["driver"].Value?.ToString() ?? "Не назначен";
            string truckInfo = selectedRow.Cells["truck"].Value?.ToString() ?? "Не назначен";
            string companyName = selectedRow.Cells["company"].Value?.ToString() ?? "";
            DateTime orderDate = Convert.ToDateTime(selectedRow.Cells["order_date"].Value);
            string wishes = selectedRow.Cells["prochee"].Value?.ToString() ?? "";

            // Получаем данные получателя (нужно добавить в запрос LoadRequests)
            string receiverOrg = "", receiverAddress = "", receiverContact = "";

            DialogResult result = MessageBox.Show(
                "Выберите действие:\n\n" +
                "Да - Сохранить маршрутный лист в PDF\n" +
                "Нет - Отмена",
                "Печать маршрутного листа",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                docGenerator.ExportToPDF(requestId, from, to, cargoName, driverName, truckInfo,
                    companyName, orderDate, wishes, receiverOrg, receiverAddress, receiverContact);
            }
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            AdjustHeaderLayout();
        }

        private void ManagerMainForm_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
            if (assignPanel.Visible && btnCloseAssignPanel != null)
            {
                btnCloseAssignPanel.Location = new Point(assignPanel.Width - 35, 5);
            }
        }

        private void btnRequests_Click(object sender, EventArgs e)
        {
            ShowRequestsView();
            LoadRequests();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (selectedRequestId == -1)
            {
                MessageBox.Show("Сначала выберите заявку из списка!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShowAssignView();
            UpdateRequestInfo(selectedRequestId);
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            ShowDriversView();
            LoadDrivers();
        }

        private void btnAddDriver_Click(object sender, EventArgs e)
        {
            using (var form = new AddDriverForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadDrivers();
                    LoadRequests();
                    MessageBox.Show("Водитель успешно добавлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAddTruck_Click(object sender, EventArgs e)
        {
            using (var form = new AddTruckForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTrucks();
                    LoadRequests();
                    MessageBox.Show("Автомобиль успешно добавлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AppSession.Logout();
            this.Close();
            Application.Restart();
        }

        private void btnAssignDriver_Click(object sender, EventArgs e)
        {
            if (selectedRequestId == -1)
            {
                MessageBox.Show("Выберите заявку из списка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbDrivers.SelectedItem == null)
            {
                MessageBox.Show("Выберите водителя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTrucks.SelectedItem == null)
            {
                MessageBox.Show("Выберите автомобиль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long driverId = ((DriverItem)cmbDrivers.SelectedItem).Id;
            long truckId = ((TruckItem)cmbTrucks.SelectedItem).Id;
            int newStatusId = currentRequestStatus;

            if (currentRequestStatus == 1)
            {
                newStatusId = 2;
            }

            DialogResult result = MessageBox.Show(
                $"Назначить:\n" +
                $"Водитель: {((DriverItem)cmbDrivers.SelectedItem).Name}\n" +
                $"Автомобиль: {((TruckItem)cmbTrucks.SelectedItem).Name}\n\n" +
                $"на заявку №{selectedRequestId}?",
                "Подтверждение назначения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                        UPDATE zakazzs.zayavki 
                        SET id_voditel = @driverId,
                            id_mashina = @truckId,
                            id_status = @statusId
                        WHERE id_zayavki = @requestId";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("driverId", driverId);
                        cmd.Parameters.AddWithValue("truckId", truckId);
                        cmd.Parameters.AddWithValue("statusId", newStatusId);
                        cmd.Parameters.AddWithValue("requestId", selectedRequestId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Заявка не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                MessageBox.Show("Водитель и автомобиль успешно назначены!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRequests();
                UpdateRequestInfo(selectedRequestId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при назначении: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (selectedRequestId == -1)
            {
                MessageBox.Show("Выберите заявку из списка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbNewStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите новый статус!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedStatus = (StatusItem)cmbNewStatus.SelectedItem;
            int newStatusId = selectedStatus.Id;

            if (newStatusId == currentRequestStatus)
            {
                MessageBox.Show("Статус не изменился. Выберите другой статус.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string oldStatusName = "";
            for (int i = 0; i < cmbNewStatus.Items.Count; i++)
            {
                var item = (StatusItem)cmbNewStatus.Items[i];
                if (item.Id == currentRequestStatus)
                {
                    oldStatusName = item.Name;
                    break;
                }
            }

            DialogResult result = MessageBox.Show(
                $"Изменить статус заявки №{selectedRequestId}\n" +
                $"с \"{oldStatusName}\" на \"{selectedStatus.Name}\"?\n\n" +
                $"Изменение будет записано в историю с указанием вашего имени.",
                "Подтверждение изменения статуса", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                // Получаем ID текущего пользователя (логиста)
                long currentUserId = GetCurrentUserId();

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // Обновляем статус с указанием пользователя (триггер запишет в историю)
                    string sql = @"
                UPDATE zakazzs.zayavki 
                SET id_status = @statusId
                WHERE id_zayavki = @requestId";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("statusId", newStatusId);
                        cmd.Parameters.AddWithValue("requestId", selectedRequestId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Получаем имя текущего пользователя для сообщения
                string userName = AppSession.CurrentUser?.FullName ?? "Логист";

                MessageBox.Show($"✅ Статус заявки №{selectedRequestId} изменен на \"{selectedStatus.Name}\"!\n\n" +
                                $"Изменение внес: {userName}",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRequests();
                UpdateRequestInfo(selectedRequestId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Ошибка при изменении статуса: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для получения ID текущего пользователя
        private long GetCurrentUserId()
        {
            if (AppSession.CurrentUser != null)
            {
                return AppSession.CurrentUser.UserId;
            }
            return 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRequests();
            LoadDrivers();
            LoadTrucks();
        }

        private void AdjustLayout()
        {
            AdjustHeaderLayout();
        }

        private void AdjustHeaderLayout()
        {
            lblDateTime.Location = new Point(this.ClientSize.Width - lblDateTime.Width - 30, 40);
            if (btnLogout != null)
            {
                // Измените Y координату с this.ClientSize.Height - 80 на 400
                btnLogout.Location = new Point(10, 350);
            }
        }
        // печать заявки 
        // печать заявки 
        private OrderPrintGenerator orderPrinter = new OrderPrintGenerator();
        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRequests.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Пожалуйста, сначала выберите заявку из списка!",
                        "Выбор заявки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dgvRequests.SelectedRows[0];

                // Получаем все данные из выбранной строки
                long requestId = Convert.ToInt64(selectedRow.Cells["id"].Value);
                string companyName = selectedRow.Cells["company"].Value?.ToString() ?? "";
                string from = selectedRow.Cells["from_addr"].Value?.ToString() ?? "";
                string to = selectedRow.Cells["to_addr"].Value?.ToString() ?? "";

                // ========== ОБЪЕДИНЯЕМ ДАТУ И ВРЕМЯ ИЗ ЗАЯВКИ ==========
                DateTime orderDate = DateTime.Now; // значение по умолчанию

                try
                {
                    // Получаем дату из data_podachi_mashiny (тип DATE в PostgreSQL)
                    DateTime dateOnly = DateTime.Now.Date;
                    if (selectedRow.Cells["order_date"].Value != null &&
                        selectedRow.Cells["order_date"].Value != DBNull.Value)
                    {
                        object dateValue = selectedRow.Cells["order_date"].Value;

                        // Обработка разных типов даты
                        if (dateValue is DateTime dt)
                        {
                            dateOnly = dt.Date;
                        }
                        else if (dateValue is DateOnly dateOnlyValue)
                        {
                            dateOnly = dateOnlyValue.ToDateTime(TimeOnly.MinValue);
                        }
                        else
                        {
                            dateOnly = Convert.ToDateTime(dateValue).Date;
                        }
                    }

                    // Получаем время из vremya_dostavki (тип TIME в PostgreSQL)
                    TimeSpan timeOnly = TimeSpan.Zero;
                    if (selectedRow.Cells["delivery_time"].Value != null &&
                        selectedRow.Cells["delivery_time"].Value != DBNull.Value)
                    {
                        object timeValue = selectedRow.Cells["delivery_time"].Value;

                        // Обработка разных типов времени
                        if (timeValue is TimeSpan ts)
                        {
                            timeOnly = ts;
                        }
                        else if (timeValue is TimeOnly timeOnlyValue)
                        {
                            timeOnly = timeOnlyValue.ToTimeSpan();
                        }
                        else
                        {
                            timeOnly = TimeSpan.Parse(timeValue.ToString());
                        }
                    }

                    // Объединяем дату и время
                    orderDate = dateOnly.Add(timeOnly);

                    // Для отладки - показываем пользователю какая дата будет в PDF
                    MessageBox.Show($"Дата и время из заявки:\n\n" +
                        $"📅 Дата: {dateOnly:dd.MM.yyyy}\n" +
                        $"⏰ Время: {timeOnly:hh\\:mm}\n\n" +
                        $"✅ В PDF будет: {orderDate:dd.MM.yyyy HH:mm}",
                        "Проверка даты и времени",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Ошибка преобразования даты/времени: {ex.Message}");
                    System.Diagnostics.Debug.WriteLine($"Тип order_date: {selectedRow.Cells["order_date"].Value?.GetType()}");
                    System.Diagnostics.Debug.WriteLine($"Тип delivery_time: {selectedRow.Cells["delivery_time"].Value?.GetType()}");

                    orderDate = DateTime.Now;
                    MessageBox.Show($"Ошибка при чтении даты/времени из заявки. Будет использована текущая дата.\n\nОшибка: {ex.Message}",
                        "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                // ========== КОНЕЦ ОБЪЕДИНЕНИЯ ДАТЫ И ВРЕМЕНИ ==========

                string cargoName = selectedRow.Cells["cargo"].Value?.ToString() ?? "";
                string transportType = selectedRow.Cells["transport"].Value?.ToString() ?? "";
                string driverName = selectedRow.Cells["driver"].Value?.ToString() ?? "Не назначен";
                string truckInfo = selectedRow.Cells["truck"].Value?.ToString() ?? "Не назначен";

                // Получаем остальные данные
                string wishes = selectedRow.Cells["wishes"].Value?.ToString() ?? "";
                string receiverOrg = selectedRow.Cells["receiver_org"].Value?.ToString() ?? "";
                string receiverAddress = selectedRow.Cells["receiver_address"].Value?.ToString() ?? "";
                string receiverContact = selectedRow.Cells["receiver_contact"].Value?.ToString() ?? "";
                string contactPerson = selectedRow.Cells["contact_person"].Value?.ToString() ?? "";
                string contactPhone = selectedRow.Cells["contact_phone"].Value?.ToString() ?? "";
                string weight = selectedRow.Cells["weight"].Value?.ToString() ?? "";
                string volume = selectedRow.Cells["volume"].Value?.ToString() ?? "";
                string places = selectedRow.Cells["places"].Value?.ToString() ?? "";
                string payer = selectedRow.Cells["payer"].Value?.ToString() ?? "";

                // Данные о загрузке и пропусках
                bool rearLoading = false, sideLoading = false, topLoading = false;
                bool mozhd = false, ttk = false, sadovoe = false;

                if (dgvRequests.Columns["zagruzka_zadnyaya"] != null)
                    rearLoading = Convert.ToBoolean(selectedRow.Cells["zagruzka_zadnyaya"].Value ?? false);
                if (dgvRequests.Columns["zagruzka_bokovaya"] != null)
                    sideLoading = Convert.ToBoolean(selectedRow.Cells["zagruzka_bokovaya"].Value ?? false);
                if (dgvRequests.Columns["zagruzka_verhnyaya"] != null)
                    topLoading = Convert.ToBoolean(selectedRow.Cells["zagruzka_verhnyaya"].Value ?? false);
                if (dgvRequests.Columns["propusk_mozhd"] != null)
                    mozhd = Convert.ToBoolean(selectedRow.Cells["propusk_mozhd"].Value ?? false);
                if (dgvRequests.Columns["propusk_ttk"] != null)
                    ttk = Convert.ToBoolean(selectedRow.Cells["propusk_ttk"].Value ?? false);
                if (dgvRequests.Columns["propusk_sadovoe"] != null)
                    sadovoe = Convert.ToBoolean(selectedRow.Cells["propusk_sadovoe"].Value ?? false);

                // Подтверждение печати
                DialogResult result = MessageBox.Show(
                    $"Печать заявки №{requestId}\n\n" +
                    $"Компания: {companyName}\n" +
                    $"Груз: {cargoName}\n" +
                    $"Дата подачи машины: {orderDate:dd.MM.yyyy}\n" +
                    $"Время доставки: {orderDate:HH:mm}\n\n" +
                    $"Продолжить?",
                    "Подтверждение печати",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    orderPrinter.ExportOrderToPDF(requestId, from, to, cargoName, driverName, truckInfo,
                        companyName, orderDate, wishes, receiverOrg, receiverAddress, receiverContact,
                        contactPerson, contactPhone, weight, volume, places, transportType, payer,
                        rearLoading, sideLoading, topLoading, mozhd, ttk, sadovoe);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при печати заявки: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== ЗАГРУЗКА ДАННЫХ ====================

        private void LoadStatuses()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT id_status, status_name FROM zakazzs.zayavki_status ORDER BY status_order";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbNewStatus.Items.Clear();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки статусов: " + ex.Message);
            }
        }

        private void LoadRequests()
        {
            try
            {
                string sql = @"
            SELECT 
                z.id_zayavki AS id,
                c.name AS company,
                z.adress_ot AS from_addr, 
                z.adress_do AS to_addr, 
                z.data_podachi_mashiny AS order_date,
                z.vremya_dostavki AS delivery_time,
                z.created_at AS created_date,
                z.naimenovanie_gruza AS cargo,
                z.tip_transporta AS transport,
                s.status_name AS status,
                COALESCE(dr.s_familiya || ' ' || dr.s_imya, 'Не назначен') AS driver,
                COALESCE(m.marka || ' (' || nm.nomer_mashini || ')', 'Не назначен') AS truck,
                z.id_voditel,
                z.id_mashina,
                z.prochee AS wishes,
                z.poluchatel_organizatsiya AS receiver_org,
                z.poluchatel_adress AS receiver_address,
                z.poluchatel_kontakt AS receiver_contact,
                z.kontaktnoe_lico_otpravitel AS contact_person,
                z.telefon_otpravitel AS contact_phone,
                COALESCE(z.obschiy_ves_kg::text, '') AS weight,
                COALESCE(z.obschiy_obem_m3::text, '') AS volume,
                COALESCE(z.kolvo_mest, '') AS places,
                COALESCE(z.plateltschik, '') AS payer
            FROM zakazzs.zayavki z
            LEFT JOIN prog.companies c ON z.id_company = c.id_company
            LEFT JOIN zakazzs.zayavki_status s ON z.id_status = s.id_status
            LEFT JOIN sortydnikis.voditeli v ON z.id_voditel = v.id_voditelya
            LEFT JOIN sortydnikis.sotrydniki dr ON v.id_sotrydnika = dr.id_sotrydnika
            LEFT JOIN mashini.mashinki m ON z.id_mashina = m.id_mashini
            LEFT JOIN mashini.nomeramashin nm ON m.nomer = nm.id_nomera
            WHERE (z.is_archived = FALSE OR z.is_archived IS NULL)
            ORDER BY z.created_at DESC";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvRequests.DataSource = dt;

                        // Настройка видимых столбцов
                        if (dgvRequests.Columns["id"] != null)
                            dgvRequests.Columns["id"].HeaderText = "№";
                        if (dgvRequests.Columns["company"] != null)
                            dgvRequests.Columns["company"].HeaderText = "Компания";
                        if (dgvRequests.Columns["from_addr"] != null)
                            dgvRequests.Columns["from_addr"].HeaderText = "Откуда";
                        if (dgvRequests.Columns["to_addr"] != null)
                            dgvRequests.Columns["to_addr"].HeaderText = "Куда";
                        if (dgvRequests.Columns["order_date"] != null)
                        {
                            dgvRequests.Columns["order_date"].HeaderText = "Дата подачи";
                            dgvRequests.Columns["order_date"].DefaultCellStyle.Format = "dd.MM.yyyy";
                        }
                        if (dgvRequests.Columns["delivery_time"] != null)
                        {
                            dgvRequests.Columns["delivery_time"].HeaderText = "Время доставки";
                            // Для TIME формата
                            dgvRequests.Columns["delivery_time"].DefaultCellStyle.Format = "hh\\:mm";
                        }
                        if (dgvRequests.Columns["cargo"] != null)
                            dgvRequests.Columns["cargo"].HeaderText = "Груз";
                        if (dgvRequests.Columns["transport"] != null)
                            dgvRequests.Columns["transport"].HeaderText = "Транспорт";
                        if (dgvRequests.Columns["status"] != null)
                            dgvRequests.Columns["status"].HeaderText = "Статус";
                        if (dgvRequests.Columns["driver"] != null)
                            dgvRequests.Columns["driver"].HeaderText = "Водитель";
                        if (dgvRequests.Columns["truck"] != null)
                            dgvRequests.Columns["truck"].HeaderText = "Автомобиль";

                        // Делаем все дополнительные столбцы НЕвидимыми
                        string[] hiddenColumns = { "id_voditel", "id_mashina", "wishes", "receiver_org",
                    "receiver_address", "receiver_contact", "contact_person", "contact_phone",
                    "weight", "volume", "places", "payer", "delivery_time",
                    "zagruzka_zadnyaya", "zagruzka_bokovaya", "zagruzka_verhnyaya",
                    "propusk_mozhd", "propusk_ttk", "propusk_sadovoe", "created_date" };
                        foreach (string col in hiddenColumns)
                        {
                            if (dgvRequests.Columns[col] != null)
                                dgvRequests.Columns[col].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки заявок: " + ex.Message);
            }
        }

        private void LoadDrivers()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                SELECT 
                    v.id_voditelya AS id,
                    s.s_familiya || ' ' || s.s_imya AS name,
                    s.s_nomer_telephona AS phone,
                    v.passport_data AS passport,
                    v.driver_license_number AS license
                FROM sortydnikis.voditeli v
                JOIN sortydnikis.sotrydniki s ON v.id_sotrydnika = s.id_sotrydnika
                ORDER BY s.s_familiya";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvDrivers.DataSource = dt;

                        if (dgvDrivers.Columns["id"] != null)
                            dgvDrivers.Columns["id"].Visible = false;
                        if (dgvDrivers.Columns["name"] != null)
                            dgvDrivers.Columns["name"].HeaderText = "ФИО водителя";
                        if (dgvDrivers.Columns["phone"] != null)
                            dgvDrivers.Columns["phone"].HeaderText = "Телефон";
                        if (dgvDrivers.Columns["experience"] != null)
                            dgvDrivers.Columns["experience"].HeaderText = "Стаж (лет)";
                        if (dgvDrivers.Columns["passport"] != null)
                            dgvDrivers.Columns["passport"].HeaderText = "Паспортные данные";
                        if (dgvDrivers.Columns["license"] != null)
                            dgvDrivers.Columns["license"].HeaderText = "Вод. удостоверение №";
                    }
                }

                // Загружаем водителей в ComboBox для назначения
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlCombo = @"
                SELECT v.id_voditelya, s.s_familiya || ' ' || s.s_imya AS name
                FROM sortydnikis.voditeli v
                JOIN sortydnikis.sotrydniki s ON v.id_sotrydnika = s.id_sotrydnika
                ORDER BY s.s_familiya";
                    using (var cmd = new NpgsqlCommand(sqlCombo, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbDrivers.Items.Clear();
                        while (reader.Read())
                        {
                            cmbDrivers.Items.Add(new DriverItem
                            {
                                Id = reader.GetInt64(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
                cmbDrivers.DisplayMember = "Name";
                cmbDrivers.ValueMember = "Id";
                if (cmbDrivers.Items.Count > 0)
                    cmbDrivers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки водителей: " + ex.Message);
            }
        }

        private void LoadTrucks()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            m.id_mashini, 
                            m.marka || ' ' || m.polnoe_nazvanie || ' (' || nm.nomer_mashini || ')' AS name,
                            sm.nazvanie_statysa AS status
                        FROM mashini.mashinki m
                        JOIN mashini.nomeramashin nm ON m.nomer = nm.id_nomera
                        JOIN mashini.statysimashin sm ON m.statys_mashini = sm.id_statysa_mashini
                        ORDER BY m.marka";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbTrucks.Items.Clear();
                        while (reader.Read())
                        {
                            cmbTrucks.Items.Add(new TruckItem
                            {
                                Id = reader.GetInt64(0),
                                Name = reader.GetString(1),
                                Status = reader.GetString(2)
                            });
                        }
                    }
                }

                cmbTrucks.DisplayMember = "DisplayName";
                cmbTrucks.ValueMember = "Id";

                if (cmbTrucks.Items.Count > 0)
                    cmbTrucks.SelectedIndex = 0;
                else
                    MessageBox.Show("В базе данных нет автомобилей!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки автомобилей: " + ex.Message);
            }
        }

        // ==================== УПРАВЛЕНИЕ ВИДИМОСТЬЮ ====================

        private void ShowRequestsView()
        {
            dgvRequests.Visible = true;
            dgvDrivers.Visible = false;
            assignPanel.Visible = false;
            selectedRequestId = -1;
        }

        private void ShowAssignView()
        {
            dgvRequests.Visible = true;
            dgvDrivers.Visible = false;
            assignPanel.Visible = true;

            if (selectedRequestId != -1)
            {
                UpdateRequestInfo(selectedRequestId);
            }
            else
            {
                lblSelectedRequest.Text = "Выберите заявку из списка";
                lblRequestInfo.Text = "Нажмите на заявку в таблице ниже, чтобы назначить водителя";
                lblCurrentDriver.Text = "Текущий водитель: не назначен";
                lblCurrentTruck.Text = "Текущий автомобиль: не назначен";
            }
        }

        private void ShowDriversView()
        {
            dgvRequests.Visible = false;
            dgvDrivers.Visible = true;
            assignPanel.Visible = false;
        }

        // ==================== ОБРАБОТЧИКИ СОБЫТИЙ ТАБЛИЦ ====================

        private void DgvRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRequestId = Convert.ToInt64(dgvRequests.Rows[e.RowIndex].Cells["id"].Value);

                this.Text = $"Столичная Логистика - Панель менеджера (Выбрана заявка №{selectedRequestId})";
            }
        }

        private void UpdateRequestInfo(long requestId)
        {
            try
            {
                string sql = @"
                    SELECT 
                        z.id_zayavki,
                        c.name AS company,
                        z.adress_ot,
                        z.adress_do,
                        z.data_podachi_mashiny,
                        z.naimenovanie_gruza,
                        s.status_name,
                        s.id_status,
                        z.id_voditel,
                        z.id_mashina,
                        dr.s_familiya || ' ' || dr.s_imya AS driver_name,
                        m.marka || ' ' || m.polnoe_nazvanie || ' (' || nm.nomer_mashini || ')' AS truck_name
                    FROM zakazzs.zayavki z
                    LEFT JOIN prog.companies c ON z.id_company = c.id_company
                    LEFT JOIN zakazzs.zayavki_status s ON z.id_status = s.id_status
                    LEFT JOIN sortydnikis.voditeli v ON z.id_voditel = v.id_voditelya
                    LEFT JOIN sortydnikis.sotrydniki dr ON v.id_sotrydnika = dr.id_sotrydnika
                    LEFT JOIN mashini.mashinki m ON z.id_mashina = m.id_mashini
                    LEFT JOIN mashini.nomeramashin nm ON m.nomer = nm.id_nomera
                    WHERE z.id_zayavki = @requestId";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("requestId", requestId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblSelectedRequest.Text = $"Заявка №{reader.GetInt64(0)} от {reader.GetString(1)}";
                                lblRequestInfo.Text = $"📍 Откуда: {reader.GetString(2)}\n" +
                                                     $"📍 Куда: {reader.GetString(3)}\n" +
                                                     $"📦 Груз: {reader.GetString(5)}\n" +
                                                     $"📅 Дата подачи: {reader.GetDateTime(4):dd.MM.yyyy}";

                                currentRequestStatus = reader.GetInt32(7);
                                currentDriverId = reader.IsDBNull(8) ? 0 : reader.GetInt64(8);
                                currentTruckId = reader.IsDBNull(9) ? 0 : reader.GetInt64(9);

                                string driverName = reader.IsDBNull(10) ? "не назначен" : reader.GetString(10);
                                string truckName = reader.IsDBNull(11) ? "не назначен" : reader.GetString(11);

                                lblCurrentDriver.Text = $"🚚 Текущий водитель: {driverName}";
                                lblCurrentTruck.Text = $"🚛 Текущий автомобиль: {truckName}";

                                for (int i = 0; i < cmbNewStatus.Items.Count; i++)
                                {
                                    var item = (StatusItem)cmbNewStatus.Items[i];
                                    if (item.Id == currentRequestStatus)
                                    {
                                        cmbNewStatus.SelectedIndex = i;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        // ==================== ПРОСМОТР ИСТОРИИ СТАТУСОВ ====================

        private void ShowStatusHistory(int requestId)
        {
            try
            {
                // Используем представление с русскими заголовками
                string sql = @"
            SELECT 
                ""ID записи"",
                ""№ заявки"",
                ""Маршрут"",
                ""Было"",
                ""Стало"",
                ""Дата изменения"",
                ""Кто изменил"",
                ""Комментарий""
            FROM zakazzs.v_zayavka_history
            WHERE ""№ заявки"" = @requestId
            ORDER BY ""Дата изменения"" DESC";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        cmd.Parameters.AddWithValue("requestId", requestId);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            Form historyForm = new Form();
                            historyForm.Text = $"📜 История статусов заявки №{requestId}";
                            historyForm.Size = new Size(950, 450);
                            historyForm.StartPosition = FormStartPosition.CenterParent;
                            historyForm.BackColor = Color.White;
                            historyForm.Font = new Font("Segoe UI", 10F);

                            DataGridView dgvHistory = new DataGridView();
                            dgvHistory.Dock = DockStyle.Fill;
                            dgvHistory.DataSource = dt;
                            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvHistory.ReadOnly = true;
                            dgvHistory.AllowUserToAddRows = false;
                            dgvHistory.RowHeadersVisible = false;
                            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dgvHistory.BackgroundColor = Color.White;
                            dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);

                            // Настройка столбцов
                            if (dgvHistory.Columns["ID записи"] != null)
                                dgvHistory.Columns["ID записи"].Width = 80;
                            if (dgvHistory.Columns["№ заявки"] != null)
                                dgvHistory.Columns["№ заявки"].Width = 80;
                            if (dgvHistory.Columns["Маршрут"] != null)
                                dgvHistory.Columns["Маршрут"].Width = 200;
                            if (dgvHistory.Columns["Было"] != null)
                                dgvHistory.Columns["Было"].Width = 120;
                            if (dgvHistory.Columns["Стало"] != null)
                                dgvHistory.Columns["Стало"].Width = 120;
                            if (dgvHistory.Columns["Дата изменения"] != null)
                            {
                                dgvHistory.Columns["Дата изменения"].Width = 160;
                                dgvHistory.Columns["Дата изменения"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
                            }
                            if (dgvHistory.Columns["Кто изменил"] != null)
                                dgvHistory.Columns["Кто изменил"].Width = 150;
                            if (dgvHistory.Columns["Комментарий"] != null)
                                dgvHistory.Columns["Комментарий"].Width = 150;

                            historyForm.Controls.Add(dgvHistory);
                            historyForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("📭 История изменений отсутствует.", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Ошибка загрузки истории: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== КЛАССЫ ДЛЯ КОМБОБОКСОВ ====================

        public class DriverItem
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

        public class TruckItem
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
            public string DisplayName => $"{Name} [{Status}]";
            public override string ToString() => DisplayName;
        }

        public class StatusItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }
    }
}