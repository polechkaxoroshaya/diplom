using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Npgsql;

namespace EVS
{
    public partial class ClientMainForm : Form
    {
        private string connectionString = "Host=localhost;Database=www2;Username=postgres;Password=root";

        private Panel headerPanel;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblWelcome;
        private Label lblDateTime;
        private System.Windows.Forms.Timer timerDateTime;
        private Panel sidePanel;
        private Button btnNewOrder;
        private Button btnMyOrders;
        private Button btnArchive;
        private Button btnCompanies;
        private Button btnLogout;
        private Panel contentPanel;
        private DataGridView dgvRequests;
        private DataGridView dgvArchive;
        private GroupBox groupBoxOrder;
        private TabControl tabControlMain;
        private TabPage tabPageActive;
        private TabPage tabPageArchive;

        private WebView2 webViewMap;
        private Panel rightPanel;
        private Panel leftPanel;
        private bool isMapInitialized = false;

        private int editingRequestId = -1;
        private int selectedCompanyId = 0;

        // Поля формы заявки
        private ComboBox cmbCompany;
        private Label lblNoCompanyWarning;
        private Button btnAddCompany;

        private TextBox txtFrom;
        private TextBox txtTo;
        private DateTimePicker dtpMachineDate;
        private DateTimePicker dtpDeliveryTime;
        private TextBox txtWishes;

        private TextBox txtContactPerson;
        private TextBox txtContactPhone;
        private TextBox txtCargoName;
        private TextBox txtWeight;
        private TextBox txtVolume;
        private TextBox txtLength;
        private TextBox txtWidth;
        private TextBox txtHeight;
        private CheckBox chkSenderList;
        private CheckBox chkExportList;
        private TextBox txtInsuranceValue;
        private ComboBox cmbTransportType;
        private CheckBox chkRearLoading;
        private CheckBox chkSideLoading;
        private CheckBox chkTopLoading;
        private CheckBox chkMozhd;
        private CheckBox chkTtk;
        private CheckBox chkSadovoe;
        private TextBox txtReceiverOrg;
        private TextBox txtReceiverAddress;
        private TextBox txtReceiverContact;
        private TextBox txtReceiverPhone;
        private TextBox txtPayer;

        private Button btnSubmit;
        private Button btnCancel;
        private Button btnShowRoute;
        private ComboBox cmbStatusFilter;
        private Label lblStatusInfo;

        private TabControl tabControlOrder;
        private TabPage tabPageMain;
        private TabPage tabPageCargo;
        private TabPage tabPageTransport;
        private TabPage tabPageReceiver;

        private Panel companyPanel;
        private Label lblCompany;
        private Label lblMachineDate;
        private Label lblDeliveryTime;
        private Label lblFrom;
        private Label lblTo;
        private Label lblContactPerson;
        private Label lblContactPhone;
        private Label lblWishes;
        private Label lblCargoName;
        private Label lblWeight;
        private Label lblVolume;
        private Label lblLength;
        private Label lblDimensions;
        private Label lblHeight;
        private Label lblWidthDim;
        private Label lblInsurance;
        private Label lblTransportType;
        private Label lblLoading;
        private Label lblPasses;
        private Label lblReceiverOrg;
        private Label lblReceiverAddress;
        private Label lblReceiverContact;
        private Label lblReceiverPhone;
        private Label lblPayer;
        private Panel filterPanel;
        private Label lblFilter;

        private System.ComponentModel.IContainer components;
        private bool isFormInitialized = false;

        public ClientMainForm()
        {
            InitializeComponent();
            isFormInitialized = true;
            LoadCompanies();
            LoadActiveRequests();
            LoadArchiveRequests();
            LoadCurrentUserInfo();
            this.Shown += async (s, e) => await InitializeMap();
        }

        private async Task InitializeMap()
        {
            try
            {
                webViewMap = new WebView2();
                webViewMap.Dock = DockStyle.Fill;
                webViewMap.Visible = true;



                string mapHtml = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='utf-8'>
                    <title>Карта маршрута</title>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <style>
                        html, body {{ margin: 0; padding: 0; height: 100%; width: 100%; }}
                        #map {{ height: 100%; width: 100%; }}
                    </style>
                    <script src='https://api-maps.yandex.ru/2.1/?apikey={apiKey}&lang=ru_RU' type='text/javascript'></script>
                    <script>
                        var map;
                        var multiRoute;
                        
                        ymaps.ready(function() {{
                            map = new ymaps.Map('map', {{
                                center: [55.751574, 37.573856],
                                zoom: 12,
                                controls: ['zoomControl', 'fullscreenControl']
                            }});
                            
                            var searchControl = new ymaps.control.SearchControl({{
                                options: {{ size: 'large', placeholderContent: 'Поиск адреса...' }}
                            }});
                            map.controls.add(searchControl);
                        }});
                        
                        function showRoute(from, to) {{
                            if (multiRoute) {{
                                map.geoObjects.remove(multiRoute);
                            }}
                            
                            multiRoute = new ymaps.multiRouter.MultiRoute({{
                                referencePoints: [from, to],
                                params: {{ results: 1 }}
                            }}, {{
                                boundsAutoApply: true,
                                wayPointDraggable: false
                            }});
                            
                            map.geoObjects.add(multiRoute);
                        }}
                    </script>
                </head>
                <body>
                    <div id='map'></div>
                </body>
                </html>";

                await webViewMap.EnsureCoreWebView2Async();
                webViewMap.NavigateToString(mapHtml);
                await Task.Delay(2000);
                isMapInitialized = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка инициализации карты: " + ex.Message);
            }
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            companyPanel = new Panel();
            lblCompany = new Label();
            cmbCompany = new ComboBox();
            lblNoCompanyWarning = new Label();
            btnAddCompany = new Button();
            headerPanel = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblWelcome = new Label();
            lblDateTime = new Label();
            timerDateTime = new System.Windows.Forms.Timer(components);
            sidePanel = new Panel();
            btnNewOrder = new Button();
            btnMyOrders = new Button();
            btnArchive = new Button();
            btnCompanies = new Button();
            btnLogout = new Button();
            contentPanel = new Panel();
            rightPanel = new Panel();
            leftPanel = new Panel();
            groupBoxOrder = new GroupBox();
            tabControlOrder = new TabControl();
            tabPageMain = new TabPage();
            lblMachineDate = new Label();
            dtpMachineDate = new DateTimePicker();
            lblDeliveryTime = new Label();
            dtpDeliveryTime = new DateTimePicker();
            lblFrom = new Label();
            txtFrom = new TextBox();
            lblTo = new Label();
            txtTo = new TextBox();
            btnShowRoute = new Button();
            lblContactPerson = new Label();
            txtContactPerson = new TextBox();
            lblContactPhone = new Label();
            txtContactPhone = new TextBox();
            lblWishes = new Label();
            txtWishes = new TextBox();
            tabPageCargo = new TabPage();
            lblCargoName = new Label();
            txtCargoName = new TextBox();
            lblWeight = new Label();
            txtWeight = new TextBox();
            lblVolume = new Label();
            txtVolume = new TextBox();
            lblDimensions = new Label();
            lblLength = new Label();
            txtLength = new TextBox();
            lblWidthDim = new Label();
            txtWidth = new TextBox();
            lblHeight = new Label();
            txtHeight = new TextBox();
            chkSenderList = new CheckBox();
            chkExportList = new CheckBox();
            lblInsurance = new Label();
            txtInsuranceValue = new TextBox();
            tabPageTransport = new TabPage();
            lblTransportType = new Label();
            cmbTransportType = new ComboBox();
            lblLoading = new Label();
            chkRearLoading = new CheckBox();
            chkSideLoading = new CheckBox();
            chkTopLoading = new CheckBox();
            lblPasses = new Label();
            chkMozhd = new CheckBox();
            chkTtk = new CheckBox();
            chkSadovoe = new CheckBox();
            tabPageReceiver = new TabPage();
            lblReceiverOrg = new Label();
            txtReceiverOrg = new TextBox();
            lblReceiverAddress = new Label();
            txtReceiverAddress = new TextBox();
            lblReceiverContact = new Label();
            txtReceiverContact = new TextBox();
            lblReceiverPhone = new Label();
            txtReceiverPhone = new TextBox();
            lblPayer = new Label();
            txtPayer = new TextBox();
            btnSubmit = new Button();
            btnCancel = new Button();
            tabControlMain = new TabControl();
            tabPageActive = new TabPage();
            dgvRequests = new DataGridView();
            filterPanel = new Panel();
            lblFilter = new Label();
            cmbStatusFilter = new ComboBox();
            lblStatusInfo = new Label();
            tabPageArchive = new TabPage();
            dgvArchive = new DataGridView();
            companyPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            sidePanel.SuspendLayout();
            contentPanel.SuspendLayout();
            leftPanel.SuspendLayout();
            groupBoxOrder.SuspendLayout();
            tabControlOrder.SuspendLayout();
            tabPageMain.SuspendLayout();
            tabPageCargo.SuspendLayout();
            tabPageTransport.SuspendLayout();
            tabPageReceiver.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageActive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            filterPanel.SuspendLayout();
            tabPageArchive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArchive).BeginInit();
            SuspendLayout();
            // 
            // companyPanel
            // 
            companyPanel.BackColor = Color.FromArgb(240, 248, 255);
            companyPanel.BorderStyle = BorderStyle.FixedSingle;
            companyPanel.Controls.Add(lblCompany);
            companyPanel.Controls.Add(cmbCompany);
            companyPanel.Controls.Add(lblNoCompanyWarning);
            companyPanel.Controls.Add(btnAddCompany);
            companyPanel.Location = new Point(10, 40);
            companyPanel.Name = "companyPanel";
            companyPanel.Size = new Size(806, 59);
            companyPanel.TabIndex = 0;
            // 
            // lblCompany
            // 
            lblCompany.AutoSize = true;
            lblCompany.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCompany.ForeColor = Color.FromArgb(0, 80, 131);
            lblCompany.Location = new Point(15, 15);
            lblCompany.Name = "lblCompany";
            lblCompany.Size = new Size(186, 20);
            lblCompany.TabIndex = 0;
            lblCompany.Text = "Компания-отправитель:";
            // 
            // cmbCompany
            // 
            cmbCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCompany.Font = new Font("Segoe UI", 11F);
            cmbCompany.Location = new Point(221, 12);
            cmbCompany.Name = "cmbCompany";
            cmbCompany.Size = new Size(314, 28);
            cmbCompany.TabIndex = 1;
            cmbCompany.SelectedIndexChanged += CmbCompany_SelectedIndexChanged;
            // 
            // lblNoCompanyWarning
            // 
            lblNoCompanyWarning.AutoSize = true;
            lblNoCompanyWarning.Font = new Font("Segoe UI", 10F);
            lblNoCompanyWarning.ForeColor = Color.Red;
            lblNoCompanyWarning.Location = new Point(5, 38);
            lblNoCompanyWarning.Name = "lblNoCompanyWarning";
            lblNoCompanyWarning.Size = new Size(434, 19);
            lblNoCompanyWarning.TabIndex = 2;
            lblNoCompanyWarning.Text = "⚠️ У вас нет зарегистрированных компаний. Добавьте компанию!";
            lblNoCompanyWarning.Visible = false;
            // 
            // btnAddCompany
            // 
            btnAddCompany.BackColor = Color.FromArgb(0, 120, 200);
            btnAddCompany.Cursor = Cursors.Hand;
            btnAddCompany.FlatStyle = FlatStyle.Flat;
            btnAddCompany.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddCompany.ForeColor = Color.White;
            btnAddCompany.Location = new Point(550, 10);
            btnAddCompany.Name = "btnAddCompany";
            btnAddCompany.Size = new Size(180, 32);
            btnAddCompany.TabIndex = 3;
            btnAddCompany.Text = "+ Добавить компанию";
            btnAddCompany.UseVisualStyleBackColor = false;
            btnAddCompany.Click += BtnAddCompany_Click;
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
            headerPanel.Size = new Size(1275, 110);
            headerPanel.TabIndex = 0;
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
            lblSubtitle.Size = new Size(147, 21);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Клиентский портал";
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
            sidePanel.Controls.Add(btnNewOrder);
            sidePanel.Controls.Add(btnMyOrders);
            sidePanel.Controls.Add(btnArchive);
            sidePanel.Controls.Add(btnCompanies);
            sidePanel.Controls.Add(btnLogout);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.Location = new Point(0, 110);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(230, 757);
            sidePanel.TabIndex = 1;
            // 
            // btnNewOrder
            // 
            btnNewOrder.BackColor = Color.FromArgb(0, 120, 200);
            btnNewOrder.Cursor = Cursors.Hand;
            btnNewOrder.FlatStyle = FlatStyle.Flat;
            btnNewOrder.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNewOrder.ForeColor = Color.White;
            btnNewOrder.Location = new Point(10, 20);
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.Size = new Size(210, 45);
            btnNewOrder.TabIndex = 0;
            btnNewOrder.Text = "✏️ Создать заявку";
            btnNewOrder.UseVisualStyleBackColor = false;
            btnNewOrder.Click += btnNewOrder_Click;
            // 
            // btnMyOrders
            // 
            btnMyOrders.BackColor = Color.White;
            btnMyOrders.Cursor = Cursors.Hand;
            btnMyOrders.FlatStyle = FlatStyle.Flat;
            btnMyOrders.Font = new Font("Segoe UI", 11F);
            btnMyOrders.ForeColor = Color.FromArgb(0, 80, 131);
            btnMyOrders.Location = new Point(10, 75);
            btnMyOrders.Name = "btnMyOrders";
            btnMyOrders.Size = new Size(210, 45);
            btnMyOrders.TabIndex = 1;
            btnMyOrders.Text = "📋 Активные заявки";
            btnMyOrders.UseVisualStyleBackColor = false;
            btnMyOrders.Click += btnMyOrders_Click;
            // 
            // btnArchive
            // 
            btnArchive.BackColor = Color.White;
            btnArchive.Cursor = Cursors.Hand;
            btnArchive.FlatStyle = FlatStyle.Flat;
            btnArchive.Font = new Font("Segoe UI", 11F);
            btnArchive.ForeColor = Color.FromArgb(0, 80, 131);
            btnArchive.Location = new Point(10, 130);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(210, 45);
            btnArchive.TabIndex = 2;
            btnArchive.Text = "📦 Архив заявок";
            btnArchive.UseVisualStyleBackColor = false;
            btnArchive.Click += btnArchive_Click;
            // 
            // btnCompanies
            // 
            btnCompanies.BackColor = Color.White;
            btnCompanies.Cursor = Cursors.Hand;
            btnCompanies.FlatStyle = FlatStyle.Flat;
            btnCompanies.Font = new Font("Segoe UI", 11F);
            btnCompanies.ForeColor = Color.FromArgb(0, 80, 131);
            btnCompanies.Location = new Point(10, 185);
            btnCompanies.Name = "btnCompanies";
            btnCompanies.Size = new Size(210, 45);
            btnCompanies.TabIndex = 3;
            btnCompanies.Text = "🏢 Мои компании";
            btnCompanies.UseVisualStyleBackColor = false;
            btnCompanies.Click += btnCompanies_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(220, 230, 240);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.ForeColor = Color.FromArgb(200, 50, 50);
            btnLogout.Location = new Point(10, 275);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(210, 45);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "🚪 Выход";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // contentPanel
            // 
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.White;
            contentPanel.Controls.Add(rightPanel);
            contentPanel.Controls.Add(leftPanel);
            contentPanel.Controls.Add(tabControlMain);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(230, 110);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(20);
            contentPanel.Size = new Size(1045, 757);
            contentPanel.TabIndex = 0;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.FromArgb(240, 248, 255);
            rightPanel.BorderStyle = BorderStyle.FixedSingle;
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(870, 20);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(6);
            rightPanel.Size = new Size(155, 717);
            rightPanel.TabIndex = 1;
            // 
            // leftPanel
            // 
            leftPanel.AutoScroll = true;
            leftPanel.BackColor = Color.White;
            leftPanel.Controls.Add(groupBoxOrder);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(20, 20);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(10);
            leftPanel.Size = new Size(850, 717);
            leftPanel.TabIndex = 0;
            // 
            // groupBoxOrder
            // 
            groupBoxOrder.BackColor = Color.FromArgb(248, 249, 252);
            groupBoxOrder.Controls.Add(companyPanel);
            groupBoxOrder.Controls.Add(tabControlOrder);
            groupBoxOrder.Controls.Add(btnSubmit);
            groupBoxOrder.Controls.Add(btnCancel);
            groupBoxOrder.Dock = DockStyle.Fill;
            groupBoxOrder.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            groupBoxOrder.Location = new Point(10, 10);
            groupBoxOrder.Name = "groupBoxOrder";
            groupBoxOrder.Size = new Size(830, 697);
            groupBoxOrder.TabIndex = 0;
            groupBoxOrder.TabStop = false;
            groupBoxOrder.Text = "Новая заявка на перевозку";
            // 
            // tabControlOrder
            // 
            tabControlOrder.Controls.Add(tabPageMain);
            tabControlOrder.Controls.Add(tabPageCargo);
            tabControlOrder.Controls.Add(tabPageTransport);
            tabControlOrder.Controls.Add(tabPageReceiver);
            tabControlOrder.Location = new Point(10, 105);
            tabControlOrder.Name = "tabControlOrder";
            tabControlOrder.SelectedIndex = 0;
            tabControlOrder.Size = new Size(810, 520);
            tabControlOrder.TabIndex = 1;
            // 
            // tabPageMain
            // 
            tabPageMain.BackColor = Color.White;
            tabPageMain.Controls.Add(lblMachineDate);
            tabPageMain.Controls.Add(dtpMachineDate);
            tabPageMain.Controls.Add(lblDeliveryTime);
            tabPageMain.Controls.Add(dtpDeliveryTime);
            tabPageMain.Controls.Add(lblFrom);
            tabPageMain.Controls.Add(txtFrom);
            tabPageMain.Controls.Add(lblTo);
            tabPageMain.Controls.Add(txtTo);
            tabPageMain.Controls.Add(btnShowRoute);
            tabPageMain.Controls.Add(lblContactPerson);
            tabPageMain.Controls.Add(txtContactPerson);
            tabPageMain.Controls.Add(lblContactPhone);
            tabPageMain.Controls.Add(txtContactPhone);
            tabPageMain.Controls.Add(lblWishes);
            tabPageMain.Controls.Add(txtWishes);
            tabPageMain.Location = new Point(4, 34);
            tabPageMain.Name = "tabPageMain";
            tabPageMain.Size = new Size(802, 482);
            tabPageMain.TabIndex = 0;
            tabPageMain.Text = "📋 Основная";
            // 
            // lblMachineDate
            // 
            lblMachineDate.Font = new Font("Segoe UI", 10F);
            lblMachineDate.ForeColor = Color.FromArgb(0, 80, 131);
            lblMachineDate.Location = new Point(20, 15);
            lblMachineDate.Name = "lblMachineDate";
            lblMachineDate.Size = new Size(150, 30);
            lblMachineDate.TabIndex = 0;
            lblMachineDate.Text = "Дата подачи машины:*";
            // 
            // dtpMachineDate
            // 
            dtpMachineDate.Font = new Font("Segoe UI", 10F);
            dtpMachineDate.Format = DateTimePickerFormat.Short;
            dtpMachineDate.Location = new Point(180, 15);
            dtpMachineDate.MinDate = new DateTime(2000, 1, 1);  // Устанавливаем минимальную дату в прошлое
            dtpMachineDate.Name = "dtpMachineDate";
            dtpMachineDate.Size = new Size(180, 25);
            dtpMachineDate.TabIndex = 1;
            dtpMachineDate.MaxDate = new DateTime(2030, 12, 31); // Устанавливаем максимальную дату
            dtpMachineDate.Value = DateTime.Now.AddDays(1);      // Устанавливаем значение по умолчанию
            // 
            // lblDeliveryTime
            // 
            lblDeliveryTime.Font = new Font("Segoe UI", 10F);
            lblDeliveryTime.Location = new Point(20, 60);
            lblDeliveryTime.Name = "lblDeliveryTime";
            lblDeliveryTime.Size = new Size(150, 30);
            lblDeliveryTime.TabIndex = 2;
            lblDeliveryTime.Text = "Время доставки:";
            // 
            // dtpDeliveryTime
            // 
            dtpDeliveryTime.Font = new Font("Segoe UI", 10F);
            dtpDeliveryTime.Format = DateTimePickerFormat.Time;
            dtpDeliveryTime.Location = new Point(180, 60);
            dtpDeliveryTime.Name = "dtpDeliveryTime";
            dtpDeliveryTime.ShowUpDown = true;
            dtpDeliveryTime.Size = new Size(120, 25);
            dtpDeliveryTime.TabIndex = 3;
            dtpDeliveryTime.Value = new DateTime(2026, 5, 13, 14, 0, 0, 0);
            // 
            // lblFrom
            // 
            lblFrom.Font = new Font("Segoe UI", 10F);
            lblFrom.ForeColor = Color.FromArgb(0, 80, 131);
            lblFrom.Location = new Point(20, 105);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(150, 30);
            lblFrom.TabIndex = 4;
            lblFrom.Text = "Адрес отправления:*";
            // 
            // txtFrom
            // 
            txtFrom.Font = new Font("Segoe UI", 11F);
            txtFrom.Location = new Point(180, 105);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new Size(350, 27);
            txtFrom.TabIndex = 5;
            // 
            // lblTo
            // 
            lblTo.Font = new Font("Segoe UI", 10F);
            lblTo.ForeColor = Color.FromArgb(0, 80, 131);
            lblTo.Location = new Point(20, 150);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(150, 30);
            lblTo.TabIndex = 6;
            lblTo.Text = "Адрес доставки:*";
            // 
            // txtTo
            // 
            txtTo.Font = new Font("Segoe UI", 11F);
            txtTo.Location = new Point(180, 150);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(350, 27);
            txtTo.TabIndex = 7;
            // 
            // btnShowRoute
            // 
            btnShowRoute.BackColor = Color.FromArgb(0, 120, 200);
            btnShowRoute.Cursor = Cursors.Hand;
            btnShowRoute.FlatStyle = FlatStyle.Flat;
            btnShowRoute.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnShowRoute.ForeColor = Color.White;
            btnShowRoute.Location = new Point(180, 195);
            btnShowRoute.Name = "btnShowRoute";
            btnShowRoute.Size = new Size(180, 35);
            btnShowRoute.TabIndex = 8;
            btnShowRoute.Text = "🗺️ Показать маршрут";
            btnShowRoute.UseVisualStyleBackColor = false;
            btnShowRoute.Click += BtnShowRoute_Click;
            // 
            // lblContactPerson
            // 
            lblContactPerson.Font = new Font("Segoe UI", 10F);
            lblContactPerson.Location = new Point(20, 245);
            lblContactPerson.Name = "lblContactPerson";
            lblContactPerson.Size = new Size(150, 30);
            lblContactPerson.TabIndex = 9;
            lblContactPerson.Text = "Контактное лицо:";
            // 
            // txtContactPerson
            // 
            txtContactPerson.BackColor = Color.FromArgb(240, 248, 255);
            txtContactPerson.Font = new Font("Segoe UI", 11F);
            txtContactPerson.Location = new Point(180, 245);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.ReadOnly = true;
            txtContactPerson.Size = new Size(350, 27);
            txtContactPerson.TabIndex = 10;
            // 
            // lblContactPhone
            // 
            lblContactPhone.Font = new Font("Segoe UI", 10F);
            lblContactPhone.ForeColor = Color.FromArgb(0, 80, 131);
            lblContactPhone.Location = new Point(20, 290);
            lblContactPhone.Name = "lblContactPhone";
            lblContactPhone.Size = new Size(150, 30);
            lblContactPhone.TabIndex = 11;
            lblContactPhone.Text = "Телефон:*";
            // 
            // txtContactPhone
            // 
            txtContactPhone.Font = new Font("Segoe UI", 11F);
            txtContactPhone.Location = new Point(180, 290);
            txtContactPhone.Name = "txtContactPhone";
            txtContactPhone.Size = new Size(350, 27);
            txtContactPhone.TabIndex = 12;
            // 
            // lblWishes
            // 
            lblWishes.Font = new Font("Segoe UI", 10F);
            lblWishes.Location = new Point(20, 335);
            lblWishes.Name = "lblWishes";
            lblWishes.Size = new Size(150, 30);
            lblWishes.TabIndex = 13;
            lblWishes.Text = "Пожелания:";
            // 
            // txtWishes
            // 
            txtWishes.Font = new Font("Segoe UI", 11F);
            txtWishes.Location = new Point(180, 335);
            txtWishes.Multiline = true;
            txtWishes.Name = "txtWishes";
            txtWishes.Size = new Size(350, 80);
            txtWishes.TabIndex = 14;
            // 
            // tabPageCargo
            // 
            tabPageCargo.BackColor = Color.White;
            tabPageCargo.Controls.Add(lblCargoName);
            tabPageCargo.Controls.Add(txtCargoName);
            tabPageCargo.Controls.Add(lblWeight);
            tabPageCargo.Controls.Add(txtWeight);
            tabPageCargo.Controls.Add(lblVolume);
            tabPageCargo.Controls.Add(txtVolume);
            tabPageCargo.Controls.Add(lblDimensions);
            tabPageCargo.Controls.Add(lblLength);
            tabPageCargo.Controls.Add(txtLength);
            tabPageCargo.Controls.Add(lblWidthDim);
            tabPageCargo.Controls.Add(txtWidth);
            tabPageCargo.Controls.Add(lblHeight);
            tabPageCargo.Controls.Add(txtHeight);
            tabPageCargo.Controls.Add(chkSenderList);
            tabPageCargo.Controls.Add(chkExportList);
            tabPageCargo.Controls.Add(lblInsurance);
            tabPageCargo.Controls.Add(txtInsuranceValue);
            tabPageCargo.Location = new Point(4, 34);
            tabPageCargo.Name = "tabPageCargo";
            tabPageCargo.Size = new Size(802, 482);
            tabPageCargo.TabIndex = 1;
            tabPageCargo.Text = "📦 Груз";
            // 
            // lblCargoName
            // 
            lblCargoName.Font = new Font("Segoe UI", 10F);
            lblCargoName.ForeColor = Color.FromArgb(0, 80, 131);
            lblCargoName.Location = new Point(20, 15);
            lblCargoName.Name = "lblCargoName";
            lblCargoName.Size = new Size(150, 30);
            lblCargoName.TabIndex = 0;
            lblCargoName.Text = "Наименование груза:*";
            // 
            // txtCargoName
            // 
            txtCargoName.Font = new Font("Segoe UI", 11F);
            txtCargoName.Location = new Point(180, 15);
            txtCargoName.Name = "txtCargoName";
            txtCargoName.Size = new Size(350, 27);
            txtCargoName.TabIndex = 1;
            // 
            // lblWeight
            // 
            lblWeight.Font = new Font("Segoe UI", 10F);
            lblWeight.Location = new Point(20, 60);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(150, 30);
            lblWeight.TabIndex = 2;
            lblWeight.Text = "Общий вес (кг):";
            // 
            // txtWeight
            // 
            txtWeight.Font = new Font("Segoe UI", 11F);
            txtWeight.Location = new Point(180, 60);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(120, 27);
            txtWeight.TabIndex = 3;
            // 
            // lblVolume
            // 
            lblVolume.Font = new Font("Segoe UI", 10F);
            lblVolume.Location = new Point(320, 60);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(138, 30);
            lblVolume.TabIndex = 4;
            lblVolume.Text = "Общий объём (м³):";
            // 
            // txtVolume
            // 
            txtVolume.Font = new Font("Segoe UI", 11F);
            txtVolume.Location = new Point(460, 60);
            txtVolume.Name = "txtVolume";
            txtVolume.Size = new Size(120, 27);
            txtVolume.TabIndex = 5;
            // 
            // lblDimensions
            // 
            lblDimensions.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDimensions.ForeColor = Color.FromArgb(0, 80, 131);
            lblDimensions.Location = new Point(20, 155);
            lblDimensions.Name = "lblDimensions";
            lblDimensions.Size = new Size(150, 30);
            lblDimensions.TabIndex = 8;
            lblDimensions.Text = "Размеры груза (м):";
            // 
            // lblLength
            // 
            lblLength.Font = new Font("Segoe UI", 10F);
            lblLength.Location = new Point(35, 190);
            lblLength.Name = "lblLength";
            lblLength.Size = new Size(60, 30);
            lblLength.TabIndex = 9;
            lblLength.Text = "Длина:";
            // 
            // txtLength
            // 
            txtLength.Font = new Font("Segoe UI", 11F);
            txtLength.Location = new Point(95, 190);
            txtLength.Name = "txtLength";
            txtLength.Size = new Size(80, 27);
            txtLength.TabIndex = 10;
            // 
            // lblWidthDim
            // 
            lblWidthDim.Font = new Font("Segoe UI", 10F);
            lblWidthDim.Location = new Point(181, 190);
            lblWidthDim.Name = "lblWidthDim";
            lblWidthDim.Size = new Size(74, 30);
            lblWidthDim.TabIndex = 11;
            lblWidthDim.Text = "Ширина:";
            // 
            // txtWidth
            // 
            txtWidth.Font = new Font("Segoe UI", 11F);
            txtWidth.Location = new Point(259, 190);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(80, 27);
            txtWidth.TabIndex = 12;
            // 
            // lblHeight
            // 
            lblHeight.Font = new Font("Segoe UI", 10F);
            lblHeight.Location = new Point(345, 190);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(60, 30);
            lblHeight.TabIndex = 13;
            lblHeight.Text = "Высота:";
            // 
            // txtHeight
            // 
            txtHeight.Font = new Font("Segoe UI", 11F);
            txtHeight.Location = new Point(405, 190);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(80, 27);
            txtHeight.TabIndex = 14;
            // 
            // chkSenderList
            // 
            chkSenderList.Font = new Font("Segoe UI", 10F);
            chkSenderList.Location = new Point(30, 240);
            chkSenderList.Name = "chkSenderList";
            chkSenderList.Size = new Size(150, 30);
            chkSenderList.TabIndex = 15;
            chkSenderList.Text = "Лист отправителя";
            // 
            // chkExportList
            // 
            chkExportList.Font = new Font("Segoe UI", 10F);
            chkExportList.Location = new Point(200, 240);
            chkExportList.Name = "chkExportList";
            chkExportList.Size = new Size(150, 30);
            chkExportList.TabIndex = 16;
            chkExportList.Text = "Лист экспорта";
            // 
            // lblInsurance
            // 
            lblInsurance.Font = new Font("Segoe UI", 10F);
            lblInsurance.Location = new Point(20, 280);
            lblInsurance.Name = "lblInsurance";
            lblInsurance.Size = new Size(180, 30);
            lblInsurance.TabIndex = 17;
            lblInsurance.Text = "Страховая стоимость (руб.):";
            // 
            // txtInsuranceValue
            // 
            txtInsuranceValue.Font = new Font("Segoe UI", 11F);
            txtInsuranceValue.Location = new Point(210, 280);
            txtInsuranceValue.Name = "txtInsuranceValue";
            txtInsuranceValue.Size = new Size(150, 27);
            txtInsuranceValue.TabIndex = 18;
            // 
            // tabPageTransport
            // 
            tabPageTransport.BackColor = Color.White;
            tabPageTransport.Controls.Add(lblTransportType);
            tabPageTransport.Controls.Add(cmbTransportType);
            tabPageTransport.Controls.Add(lblLoading);
            tabPageTransport.Controls.Add(chkRearLoading);
            tabPageTransport.Controls.Add(chkSideLoading);
            tabPageTransport.Controls.Add(chkTopLoading);
            tabPageTransport.Controls.Add(lblPasses);
            tabPageTransport.Controls.Add(chkMozhd);
            tabPageTransport.Controls.Add(chkTtk);
            tabPageTransport.Controls.Add(chkSadovoe);
            tabPageTransport.Location = new Point(4, 34);
            tabPageTransport.Name = "tabPageTransport";
            tabPageTransport.Size = new Size(802, 482);
            tabPageTransport.TabIndex = 2;
            tabPageTransport.Text = "🚚 Транспорт";
            // 
            // lblTransportType
            // 
            lblTransportType.Font = new Font("Segoe UI", 10F);
            lblTransportType.Location = new Point(20, 15);
            lblTransportType.Name = "lblTransportType";
            lblTransportType.Size = new Size(150, 30);
            lblTransportType.TabIndex = 0;
            lblTransportType.Text = "Тип транспорта:";
            // 
            // cmbTransportType
            // 
            cmbTransportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTransportType.Font = new Font("Segoe UI", 10F);
            cmbTransportType.Items.AddRange(new object[] { "1.5 т, 10 м³", "1.5 т, 16 м³", "3 т, 16 м³", "5 т, 30 м³", "10 т, 35 м³", "20 т, 82 м³" });
            cmbTransportType.Location = new Point(180, 15);
            cmbTransportType.Name = "cmbTransportType";
            cmbTransportType.Size = new Size(200, 25);
            cmbTransportType.TabIndex = 1;
            // 
            // lblLoading
            // 
            lblLoading.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLoading.ForeColor = Color.FromArgb(0, 80, 131);
            lblLoading.Location = new Point(20, 65);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(150, 30);
            lblLoading.TabIndex = 2;
            lblLoading.Text = "Тип загрузки:";
            // 
            // chkRearLoading
            // 
            chkRearLoading.Font = new Font("Segoe UI", 10F);
            chkRearLoading.Location = new Point(35, 95);
            chkRearLoading.Name = "chkRearLoading";
            chkRearLoading.Size = new Size(80, 30);
            chkRearLoading.TabIndex = 3;
            chkRearLoading.Text = "Задняя";
            // 
            // chkSideLoading
            // 
            chkSideLoading.Font = new Font("Segoe UI", 10F);
            chkSideLoading.Location = new Point(140, 95);
            chkSideLoading.Name = "chkSideLoading";
            chkSideLoading.Size = new Size(80, 30);
            chkSideLoading.TabIndex = 4;
            chkSideLoading.Text = "Боковая";
            // 
            // chkTopLoading
            // 
            chkTopLoading.Font = new Font("Segoe UI", 10F);
            chkTopLoading.Location = new Point(245, 95);
            chkTopLoading.Name = "chkTopLoading";
            chkTopLoading.Size = new Size(80, 30);
            chkTopLoading.TabIndex = 5;
            chkTopLoading.Text = "Верхняя";
            // 
            // lblPasses
            // 
            lblPasses.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPasses.ForeColor = Color.FromArgb(0, 80, 131);
            lblPasses.Location = new Point(20, 140);
            lblPasses.Name = "lblPasses";
            lblPasses.Size = new Size(150, 30);
            lblPasses.TabIndex = 6;
            lblPasses.Text = "Пропуска:";
            // 
            // chkMozhd
            // 
            chkMozhd.Font = new Font("Segoe UI", 10F);
            chkMozhd.Location = new Point(35, 170);
            chkMozhd.Name = "chkMozhd";
            chkMozhd.Size = new Size(80, 30);
            chkMozhd.TabIndex = 7;
            chkMozhd.Text = "МОЖД";
            // 
            // chkTtk
            // 
            chkTtk.Font = new Font("Segoe UI", 10F);
            chkTtk.Location = new Point(130, 170);
            chkTtk.Name = "chkTtk";
            chkTtk.Size = new Size(80, 30);
            chkTtk.TabIndex = 8;
            chkTtk.Text = "ТТК";
            // 
            // chkSadovoe
            // 
            chkSadovoe.Font = new Font("Segoe UI", 10F);
            chkSadovoe.Location = new Point(225, 170);
            chkSadovoe.Name = "chkSadovoe";
            chkSadovoe.Size = new Size(130, 30);
            chkSadovoe.TabIndex = 9;
            chkSadovoe.Text = "Садовое кольцо";
            // 
            // tabPageReceiver
            // 
            tabPageReceiver.BackColor = Color.White;
            tabPageReceiver.Controls.Add(lblReceiverOrg);
            tabPageReceiver.Controls.Add(txtReceiverOrg);
            tabPageReceiver.Controls.Add(lblReceiverAddress);
            tabPageReceiver.Controls.Add(txtReceiverAddress);
            tabPageReceiver.Controls.Add(lblReceiverContact);
            tabPageReceiver.Controls.Add(txtReceiverContact);
            tabPageReceiver.Controls.Add(lblReceiverPhone);
            tabPageReceiver.Controls.Add(txtReceiverPhone);
            tabPageReceiver.Controls.Add(lblPayer);
            tabPageReceiver.Controls.Add(txtPayer);
            tabPageReceiver.Location = new Point(4, 34);
            tabPageReceiver.Name = "tabPageReceiver";
            tabPageReceiver.Size = new Size(802, 482);
            tabPageReceiver.TabIndex = 3;
            tabPageReceiver.Text = "🏢 Получатель";
            // 
            // lblReceiverOrg
            // 
            lblReceiverOrg.Font = new Font("Segoe UI", 10F);
            lblReceiverOrg.Location = new Point(20, 15);
            lblReceiverOrg.Name = "lblReceiverOrg";
            lblReceiverOrg.Size = new Size(150, 30);
            lblReceiverOrg.TabIndex = 0;
            lblReceiverOrg.Text = "Организация:";
            // 
            // txtReceiverOrg
            // 
            txtReceiverOrg.Font = new Font("Segoe UI", 11F);
            txtReceiverOrg.Location = new Point(180, 15);
            txtReceiverOrg.Name = "txtReceiverOrg";
            txtReceiverOrg.Size = new Size(350, 27);
            txtReceiverOrg.TabIndex = 1;
            // 
            // lblReceiverAddress
            // 
            lblReceiverAddress.Font = new Font("Segoe UI", 10F);
            lblReceiverAddress.Location = new Point(20, 60);
            lblReceiverAddress.Name = "lblReceiverAddress";
            lblReceiverAddress.Size = new Size(150, 30);
            lblReceiverAddress.TabIndex = 2;
            lblReceiverAddress.Text = "Адрес доставки:";
            // 
            // txtReceiverAddress
            // 
            txtReceiverAddress.Font = new Font("Segoe UI", 11F);
            txtReceiverAddress.Location = new Point(180, 60);
            txtReceiverAddress.Name = "txtReceiverAddress";
            txtReceiverAddress.Size = new Size(350, 27);
            txtReceiverAddress.TabIndex = 3;
            // 
            // lblReceiverContact
            // 
            lblReceiverContact.Font = new Font("Segoe UI", 10F);
            lblReceiverContact.Location = new Point(20, 105);
            lblReceiverContact.Name = "lblReceiverContact";
            lblReceiverContact.Size = new Size(150, 30);
            lblReceiverContact.TabIndex = 4;
            lblReceiverContact.Text = "Контактное лицо:";
            // 
            // txtReceiverContact
            // 
            txtReceiverContact.Font = new Font("Segoe UI", 11F);
            txtReceiverContact.Location = new Point(180, 105);
            txtReceiverContact.Name = "txtReceiverContact";
            txtReceiverContact.Size = new Size(350, 27);
            txtReceiverContact.TabIndex = 5;
            // 
            // lblReceiverPhone
            // 
            lblReceiverPhone.Font = new Font("Segoe UI", 10F);
            lblReceiverPhone.Location = new Point(20, 150);
            lblReceiverPhone.Name = "lblReceiverPhone";
            lblReceiverPhone.Size = new Size(150, 30);
            lblReceiverPhone.TabIndex = 6;
            lblReceiverPhone.Text = "Телефон получателя:";
            // 
            // txtReceiverPhone
            // 
            txtReceiverPhone.Font = new Font("Segoe UI", 11F);
            txtReceiverPhone.Location = new Point(180, 150);
            txtReceiverPhone.Name = "txtReceiverPhone";
            txtReceiverPhone.Size = new Size(350, 27);
            txtReceiverPhone.TabIndex = 7;
            // 
            // lblPayer
            // 
            lblPayer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPayer.ForeColor = Color.FromArgb(0, 80, 131);
            lblPayer.Location = new Point(20, 200);
            lblPayer.Name = "lblPayer";
            lblPayer.Size = new Size(150, 30);
            lblPayer.TabIndex = 8;
            lblPayer.Text = "Плательщик:";
            // 
            // txtPayer
            // 
            txtPayer.Font = new Font("Segoe UI", 11F);
            txtPayer.Location = new Point(180, 200);
            txtPayer.Name = "txtPayer";
            txtPayer.Size = new Size(350, 27);
            txtPayer.TabIndex = 9;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(0, 120, 200);
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(250, 640);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(200, 45);
            btnSubmit.TabIndex = 2;
            btnSubmit.Text = "📤 Сохранить заявку";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += BtnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F);
            btnCancel.ForeColor = Color.FromArgb(0, 80, 131);
            btnCancel.Location = new Point(480, 640);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 45);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "❌ Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageActive);
            tabControlMain.Controls.Add(tabPageArchive);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Font = new Font("Segoe UI", 10F);
            tabControlMain.Location = new Point(20, 20);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1005, 717);
            tabControlMain.TabIndex = 2;
            // 
            // tabPageActive
            // 
            tabPageActive.Controls.Add(dgvRequests);
            tabPageActive.Controls.Add(filterPanel);
            tabPageActive.Location = new Point(4, 26);
            tabPageActive.Name = "tabPageActive";
            tabPageActive.Size = new Size(997, 687);
            tabPageActive.TabIndex = 0;
            tabPageActive.Text = "📋 Активные заявки";
            // 
            // dgvRequests
            // 
            dgvRequests.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(240, 248, 255);
            dgvRequests.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.BackgroundColor = Color.White;
            dgvRequests.Dock = DockStyle.Fill;
            dgvRequests.Font = new Font("Segoe UI", 10F);
            dgvRequests.Location = new Point(0, 45);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.ReadOnly = true;
            dgvRequests.RowHeadersVisible = false;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.Size = new Size(997, 642);
            dgvRequests.TabIndex = 0;
            dgvRequests.CellClick += DgvRequests_CellClick;
            // 
            // filterPanel
            // 
            filterPanel.BackColor = Color.FromArgb(248, 249, 252);
            filterPanel.Controls.Add(lblFilter);
            filterPanel.Controls.Add(cmbStatusFilter);
            filterPanel.Controls.Add(lblStatusInfo);
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Location = new Point(0, 0);
            filterPanel.Name = "filterPanel";
            filterPanel.Padding = new Padding(10);
            filterPanel.Size = new Size(997, 45);
            filterPanel.TabIndex = 1;
            // 
            // lblFilter
            // 
            lblFilter.Font = new Font("Segoe UI", 10F);
            lblFilter.Location = new Point(10, 12);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(120, 25);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "Фильтр по статусу:";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Font = new Font("Segoe UI", 10F);
            cmbStatusFilter.Items.AddRange(new object[] { "Все статусы", "На рассмотрении", "Принята", "Подтверждена", "В работе" });
            cmbStatusFilter.Location = new Point(140, 10);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(180, 25);
            cmbStatusFilter.TabIndex = 1;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // lblStatusInfo
            // 
            lblStatusInfo.Font = new Font("Segoe UI", 9F);
            lblStatusInfo.ForeColor = Color.Gray;
            lblStatusInfo.Location = new Point(340, 12);
            lblStatusInfo.Name = "lblStatusInfo";
            lblStatusInfo.Size = new Size(250, 25);
            lblStatusInfo.TabIndex = 2;
            // 
            // tabPageArchive
            // 
            tabPageArchive.Controls.Add(dgvArchive);
            tabPageArchive.Location = new Point(4, 26);
            tabPageArchive.Name = "tabPageArchive";
            tabPageArchive.Size = new Size(997, 687);
            tabPageArchive.TabIndex = 1;
            tabPageArchive.Text = "📦 Архив";
            // 
            // dgvArchive
            // 
            dgvArchive.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(240, 248, 255);
            dgvArchive.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvArchive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchive.BackgroundColor = Color.White;
            dgvArchive.Dock = DockStyle.Fill;
            dgvArchive.Font = new Font("Segoe UI", 10F);
            dgvArchive.Location = new Point(0, 0);
            dgvArchive.Name = "dgvArchive";
            dgvArchive.ReadOnly = true;
            dgvArchive.RowHeadersVisible = false;
            dgvArchive.Size = new Size(997, 687);
            dgvArchive.TabIndex = 0;
            // 
            // ClientMainForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1275, 867);
            Controls.Add(contentPanel);
            Controls.Add(sidePanel);
            Controls.Add(headerPanel);
            Name = "ClientMainForm";
            Text = "Столичная Логистика - Клиентский портал";
            WindowState = FormWindowState.Maximized;
            Resize += ClientMainForm_Resize;
            companyPanel.ResumeLayout(false);
            companyPanel.PerformLayout();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            sidePanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            groupBoxOrder.ResumeLayout(false);
            tabControlOrder.ResumeLayout(false);
            tabPageMain.ResumeLayout(false);
            tabPageMain.PerformLayout();
            tabPageCargo.ResumeLayout(false);
            tabPageCargo.PerformLayout();
            tabPageTransport.ResumeLayout(false);
            tabPageReceiver.ResumeLayout(false);
            tabPageReceiver.PerformLayout();
            tabControlMain.ResumeLayout(false);
            tabPageActive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            filterPanel.ResumeLayout(false);
            tabPageArchive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvArchive).EndInit();
            ResumeLayout(false);
        }

        // ==================== ОБРАБОТЧИКИ СОБЫТИЙ ====================

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            AdjustHeaderLayout();
        }

        private void ClientMainForm_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadActiveRequests();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AppSession.Logout();
            this.Close();
            Application.Restart();
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
                btnLogout.Location = new Point(10, this.ClientSize.Height - 80);
            }
        }

        // ==================== ЗАГРУЗКА КОМПАНИЙ ====================

        private void LoadCompanies()
        {

            try
            {
                int userId = GetClientId();
                string sql = @"
                    SELECT c.id_company, c.name, uc.is_default
                    FROM prog.companies c
                    JOIN prog.user_companies uc ON c.id_company = uc.id_company
                    WHERE uc.id_polzovatelya = @userId AND c.is_active = true
                    ORDER BY uc.is_default DESC, c.name";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("userId", userId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            cmbCompany.Items.Clear();
                            while (reader.Read())
                            {
                                int companyId = Convert.ToInt32(reader.GetValue(0));
                                cmbCompany.Items.Add(new CompanyItem
                                {
                                    Id = companyId,
                                    Name = reader.GetString(1),
                                    IsDefault = reader.GetBoolean(2)
                                });
                            }
                        }
                    }
                }

                cmbCompany.DisplayMember = "DisplayName";

                if (cmbCompany.Items.Count > 0)
                {
                    cmbCompany.Visible = true;
                    lblNoCompanyWarning.Visible = false;

                    for (int i = 0; i < cmbCompany.Items.Count; i++)
                    {
                        var item = (CompanyItem)cmbCompany.Items[i];
                        if (item.IsDefault)
                        {
                            cmbCompany.SelectedIndex = i;
                            selectedCompanyId = item.Id;
                            break;
                        }
                    }

                    if (cmbCompany.SelectedIndex == -1 && cmbCompany.Items.Count > 0)
                    {
                        cmbCompany.SelectedIndex = 0;
                        selectedCompanyId = ((CompanyItem)cmbCompany.Items[0]).Id;
                    }
                }
                else
                {
                    cmbCompany.Visible = false;
                    lblNoCompanyWarning.Visible = true;
                    selectedCompanyId = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки компаний: " + ex.Message);
            }
        }

        private void CmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCompany.SelectedItem != null)
            {
                selectedCompanyId = ((CompanyItem)cmbCompany.SelectedItem).Id;
            }
        }

        private void BtnAddCompany_Click(object sender, EventArgs e)
        {
            using (var form = new AddCompanyForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCompanies();
                    MessageBox.Show("Компания успешно добавлена! Теперь вы можете создавать заявки от этой компании.",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // ==================== КАРТА ====================

        private async void BtnShowRoute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFrom.Text) || string.IsNullOrWhiteSpace(txtTo.Text))
            {
                MessageBox.Show("Введите адрес отправления и доставки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isMapInitialized || webViewMap?.CoreWebView2 == null)
            {
                MessageBox.Show("Карта ещё не загружена, подождите...", "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!rightPanel.Controls.Contains(webViewMap))
            {
                rightPanel.Controls.Clear();
                rightPanel.Controls.Add(webViewMap);
                webViewMap.Dock = DockStyle.Fill;
                webViewMap.Visible = true;
            }

            try
            {
                string script = $"showRoute('{EscapeJsString(txtFrom.Text)}', '{EscapeJsString(txtTo.Text)}');";
                await webViewMap.CoreWebView2.ExecuteScriptAsync(script);
                rightPanel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private string EscapeJsString(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "");
        }

        // ==================== УПРАВЛЕНИЕ ВИДИМОСТЬЮ ====================

        private void ShowRequestsView()
        {
            groupBoxOrder.Visible = false;
            leftPanel.Visible = false;
            rightPanel.Visible = false;
            tabControlMain.Visible = true;
        }

        private void ShowOrderForm()
        {
            tabControlMain.Visible = false;
            groupBoxOrder.Visible = true;
            leftPanel.Visible = true;
            rightPanel.Visible = true;
        }

        private void ShowCompaniesView()
        {
            using (var form = new MyCompaniesForm())
            {
                form.ShowDialog();
            }
            LoadCompanies();
        }
        private void LoadCurrentUserInfo()
        {
            try
            {
                if (AppSession.CurrentUser != null)
                {
                    // Берем ФИО из сессии
                    string fullName = AppSession.CurrentUser.FullName;
                    if (!string.IsNullOrEmpty(fullName))
                    {
                        txtContactPerson.Text = fullName;
                    }
                    else
                    {
                        // Если в сессии нет - берем из базы
                        int userId = GetClientId();
                        string sql = "SELECT s_familiya || ' ' || s_imya FROM sortydnikis.sotrydniki WHERE id_sotrydnika = @userId";
                        using (var conn = new NpgsqlConnection(connectionString))
                        {
                            conn.Open();
                            using (var cmd = new NpgsqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("userId", userId);
                                txtContactPerson.Text = cmd.ExecuteScalar()?.ToString() ?? "Пользователь";
                            }
                        }
                    }
                }
                else
                {
                    txtContactPerson.Text = "Пользователь";
                }

                // Делаем поле только для чтения
                txtContactPerson.ReadOnly = true;
                txtContactPerson.BackColor = Color.FromArgb(240, 248, 255);
            }
            catch (Exception ex)
            {
                txtContactPerson.Text = "Пользователь";
                System.Diagnostics.Debug.WriteLine("Ошибка: " + ex.Message);
            }
        }
        // ==================== ЗАГРУЗКА АКТИВНЫХ ЗАЯВОК ====================

        private void LoadActiveRequests()
        {
            try
            {
                int clientId = GetClientId();
                string statusFilter = cmbStatusFilter.SelectedItem?.ToString() ?? "Все статусы";

                string sql = @"
                    SELECT 
                        z.id_zayavki AS id,
                        c.name AS company,
                        z.adress_ot AS from_addr, 
                        z.adress_do AS to_addr, 
                        z.data_podachi_mashiny AS order_date,
                        z.naimenovanie_gruza AS cargo,
                        z.tip_transporta AS transport,
                        s.status_name AS status,
                        s.color_code AS status_color
                    FROM zakazzs.zayavki z
                    JOIN prog.companies c ON z.id_company = c.id_company
                    JOIN zakazzs.zayavki_status s ON z.id_status = s.id_status
                    WHERE z.id_zakazchika = @clientId 
                        AND (z.is_archived = FALSE OR z.is_archived IS NULL)";

                if (statusFilter != "Все статусы")
                {
                    sql += " AND s.status_name = @statusFilter";
                }

                sql += " ORDER BY z.created_at DESC";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        cmd.Parameters.AddWithValue("clientId", clientId);
                        if (statusFilter != "Все статусы")
                        {
                            cmd.Parameters.AddWithValue("statusFilter", statusFilter);
                        }

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvRequests.DataSource = dt;

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
                        if (dgvRequests.Columns["cargo"] != null)
                            dgvRequests.Columns["cargo"].HeaderText = "Груз";
                        if (dgvRequests.Columns["transport"] != null)
                            dgvRequests.Columns["transport"].HeaderText = "Транспорт";
                        if (dgvRequests.Columns["status"] != null)
                            dgvRequests.Columns["status"].HeaderText = "Статус";

                        if (dgvRequests.Columns["status_color"] != null)
                        {
                            dgvRequests.Columns["status_color"].Visible = false;
                        }

                        foreach (DataGridViewRow row in dgvRequests.Rows)
                        {
                            if (row.Cells["status_color"].Value != null)
                            {
                                string colorCode = row.Cells["status_color"].Value.ToString();
                                Color statusColor = ColorTranslator.FromHtml(colorCode);
                                row.Cells["status"].Style.ForeColor = statusColor;
                                row.Cells["status"].Style.Font = new Font(dgvRequests.Font, FontStyle.Bold);
                            }
                        }

                        if (!dgvRequests.Columns.Contains("edit_button"))
                        {
                            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                            editButton.Name = "edit_button";
                            editButton.HeaderText = "";
                            editButton.Text = "✏️";
                            editButton.UseColumnTextForButtonValue = true;
                            editButton.Width = 40;
                            dgvRequests.Columns.Add(editButton);
                        }

                        if (!dgvRequests.Columns.Contains("delete_button"))
                        {
                            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                            deleteButton.Name = "delete_button";
                            deleteButton.HeaderText = "";
                            deleteButton.Text = "🗑️";
                            deleteButton.UseColumnTextForButtonValue = true;
                            deleteButton.Width = 40;
                            dgvRequests.Columns.Add(deleteButton);
                        }

                        if (!dgvRequests.Columns.Contains("history_button"))
                        {
                            DataGridViewButtonColumn historyButton = new DataGridViewButtonColumn();
                            historyButton.Name = "history_button";
                            historyButton.HeaderText = "";
                            historyButton.Text = "📜";
                            historyButton.UseColumnTextForButtonValue = true;
                            historyButton.Width = 40;
                            dgvRequests.Columns.Add(historyButton);
                        }

                        int activeCount = dgvRequests.Rows.Count;
                        int totalCount = GetTotalActiveCount();
                        lblStatusInfo.Text = $"Показано: {activeCount} из {totalCount} активных заявок";
                    }
                }

                dgvRequests.CellClick -= DgvRequests_CellClick;
                dgvRequests.CellClick += DgvRequests_CellClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки заявок: " + ex.Message);
            }
        }

        private int GetTotalActiveCount()
        {
            try
            {
                int clientId = GetClientId();
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM zakazzs.zayavki WHERE id_zakazchika = @clientId AND (is_archived = FALSE OR is_archived IS NULL)";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("clientId", clientId);
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch { return 0; }
        }

        // ==================== ЗАГРУЗКА АРХИВА ====================

        private void LoadArchiveRequests()
        {
            try
            {
                int clientId = GetClientId();

                string sql = @"
                    SELECT 
                        z.id_zayavki AS id,
                        c.name AS company,
                        z.adress_ot AS from_addr, 
                        z.adress_do AS to_addr, 
                        z.data_podachi_mashiny AS order_date,
                        z.naimenovanie_gruza AS cargo,
                        z.tip_transporta AS transport,
                        s.status_name AS status,
                        z.archived_date AS archived_date
                    FROM zakazzs.zayavki z
                    JOIN prog.companies c ON z.id_company = c.id_company
                    JOIN zakazzs.zayavki_status s ON z.id_status = s.id_status
                    WHERE z.id_zakazchika = @clientId AND z.is_archived = TRUE
                    ORDER BY z.archived_date DESC";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        cmd.Parameters.AddWithValue("clientId", clientId);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvArchive.DataSource = dt;

                        if (dgvArchive.Columns["id"] != null)
                            dgvArchive.Columns["id"].HeaderText = "№";
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
                        if (dgvArchive.Columns["transport"] != null)
                            dgvArchive.Columns["transport"].HeaderText = "Транспорт";
                        if (dgvArchive.Columns["status"] != null)
                            dgvArchive.Columns["status"].HeaderText = "Статус";
                        if (dgvArchive.Columns["archived_date"] != null)
                        {
                            dgvArchive.Columns["archived_date"].HeaderText = "Дата архивации";
                            dgvArchive.Columns["archived_date"].DefaultCellStyle.Format = "dd.MM.yyyy";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки архива: " + ex.Message);
            }
        }

        // ==================== РАБОТА С ДАННЫМИ ====================

        private int GetClientId()
        {
            if (AppSession.CurrentUser != null)
            {
                return Convert.ToInt32(AppSession.CurrentUser.UserId);
            }
            return 1;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (selectedCompanyId == 0)
            {
                MessageBox.Show("Добавьте компанию-отправителя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BtnAddCompany_Click(sender, e);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFrom.Text))
            {
                MessageBox.Show("Заполните адрес отправления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFrom.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTo.Text))
            {
                MessageBox.Show("Заполните адрес доставки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTo.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCargoName.Text))
            {
                MessageBox.Show("Заполните наименование груза!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCargoName.Focus();
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                        INSERT INTO zakazzs.zayavki (
                            data_podachi, data_podachi_mashiny, vremya_dostavki,
                            adress_ot, adress_do,
                            kontaktnoe_lico_otpravitel, telefon_otpravitel,
                            naimenovanie_gruza, obschiy_ves_kg, obschiy_obem_m3,
                            dlina_m, shirina_m, vysota_m,
                            list_otpravitelya, list_eksporta, stoimost_grupa_dlya_strahovaniya,
                            tip_transporta,
                            zagruzka_zadnyaya, zagruzka_bokovaya, zagruzka_verhnyaya,
                            propusk_mozhd, propusk_ttk, propusk_sadovoe_koltso,
                            poluchatel_organizatsiya, poluchatel_adress, poluchatel_kontakt, poluchatel_telefon,
                            plateltschik,
                            prochee, id_zakazchika, id_company, id_status
                        ) VALUES (
                            @data_podachi, @data_podachi_mashiny, @vremya_dostavki,
                            @adress_ot, @adress_do,
                            @kontaktnoe_lico, @telefon,
                            @naimenovanie_gruza, @ves, @obem, 
                            @dlina, @shirina, @vysota,
                            @list_otpravitelya, @list_eksporta, @stoimost,
                            @tip_transporta,
                            @zagruzka_zadnyaya, @zagruzka_bokovaya, @zagruzka_verhnyaya,
                            @propusk_mozhd, @propusk_ttk, @propusk_sadovoe,
                            @poluchatel_organizatsiya, @poluchatel_adress, @poluchatel_kontakt, @poluchatel_telefon,
                            @plateltschik,
                            @prochee, @clientId, @companyId, 1
                        )";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("data_podachi", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("data_podachi_mashiny", dtpMachineDate.Value.Date);
                        cmd.Parameters.AddWithValue("vremya_dostavki", dtpDeliveryTime.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("adress_ot", txtFrom.Text.Trim());
                        cmd.Parameters.AddWithValue("adress_do", txtTo.Text.Trim());
                        string kontaktnoeLico = AppSession.CurrentUser?.FullName ?? "Системный пользователь";
                        cmd.Parameters.AddWithValue("kontaktnoe_lico", kontaktnoeLico);
                        cmd.Parameters.AddWithValue("telefon", txtContactPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("naimenovanie_gruza", txtCargoName.Text.Trim());
                        cmd.Parameters.AddWithValue("ves", string.IsNullOrWhiteSpace(txtWeight.Text) ? 0 : Convert.ToDecimal(txtWeight.Text));
                        cmd.Parameters.AddWithValue("obem", string.IsNullOrWhiteSpace(txtVolume.Text) ? 0 : Convert.ToDecimal(txtVolume.Text));
                        cmd.Parameters.AddWithValue("dlina", string.IsNullOrWhiteSpace(txtLength.Text) ? 0 : Convert.ToDecimal(txtLength.Text));
                        cmd.Parameters.AddWithValue("shirina", string.IsNullOrWhiteSpace(txtWidth.Text) ? 0 : Convert.ToDecimal(txtWidth.Text));
                        cmd.Parameters.AddWithValue("vysota", string.IsNullOrWhiteSpace(txtHeight.Text) ? 0 : Convert.ToDecimal(txtHeight.Text));
                        cmd.Parameters.AddWithValue("list_otpravitelya", chkSenderList.Checked);
                        cmd.Parameters.AddWithValue("list_eksporta", chkExportList.Checked);
                        cmd.Parameters.AddWithValue("stoimost", string.IsNullOrWhiteSpace(txtInsuranceValue.Text) ? 0 : Convert.ToDecimal(txtInsuranceValue.Text));
                        cmd.Parameters.AddWithValue("tip_transporta", cmbTransportType.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("zagruzka_zadnyaya", chkRearLoading.Checked);
                        cmd.Parameters.AddWithValue("zagruzka_bokovaya", chkSideLoading.Checked);
                        cmd.Parameters.AddWithValue("zagruzka_verhnyaya", chkTopLoading.Checked);
                        cmd.Parameters.AddWithValue("propusk_mozhd", chkMozhd.Checked);
                        cmd.Parameters.AddWithValue("propusk_ttk", chkTtk.Checked);
                        cmd.Parameters.AddWithValue("propusk_sadovoe", chkSadovoe.Checked);
                        cmd.Parameters.AddWithValue("poluchatel_organizatsiya", txtReceiverOrg.Text.Trim());
                        cmd.Parameters.AddWithValue("poluchatel_adress", txtReceiverAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("poluchatel_kontakt", txtReceiverContact.Text.Trim());
                        cmd.Parameters.AddWithValue("poluchatel_telefon", txtReceiverPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("plateltschik", txtPayer.Text.Trim());
                        cmd.Parameters.AddWithValue("prochee", txtWishes.Text.Trim());
                        cmd.Parameters.AddWithValue("clientId", GetClientId());
                        cmd.Parameters.AddWithValue("companyId", selectedCompanyId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Заявка успешно создана! Статус: На рассмотрении", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearOrderForm();
                ShowRequestsView();
                LoadActiveRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void DeleteRequest(int requestId)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту заявку?\nЭто действие нельзя отменить.",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "DELETE FROM zakazzs.zayavki WHERE id_zayavki = @requestId AND id_zakazchika = @clientId";
                        using (var cmd = new NpgsqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("requestId", requestId);
                            cmd.Parameters.AddWithValue("clientId", GetClientId());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Заявка успешно удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadActiveRequests();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message);
                }
            }
        }

        private void ShowStatusHistory(int requestId)
        {
            try
            {
                string sql = @"
            SELECT 
                h.data_izmeneniya AS ""Дата изменения"",
                COALESCE(s1.status_name, 'Создана') AS ""Предыдущий статус"",
                s2.status_name AS ""Новый статус"",
                COALESCE(h.izmenil_kto, 'Система') AS ""Кто изменил"",
                COALESCE(h.kommentariy, '') AS ""Комментарий""
            FROM zakazzs.istoriya_statusov h
            LEFT JOIN zakazzs.zayavki_status s1 ON h.stariy_status = s1.id_status
            JOIN zakazzs.zayavki_status s2 ON h.noviy_status = s2.id_status
            WHERE h.id_zayavki = @requestId
            ORDER BY h.data_izmeneniya DESC";

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
                            historyForm.Size = new Size(900, 400);
                            historyForm.StartPosition = FormStartPosition.CenterParent;

                            DataGridView dgvHistory = new DataGridView();
                            dgvHistory.Dock = DockStyle.Fill;
                            dgvHistory.DataSource = dt;
                            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvHistory.ReadOnly = true;
                            dgvHistory.AllowUserToAddRows = false;
                            dgvHistory.RowHeadersVisible = false;

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

        private void LoadRequestForEditing(int requestId)
        {
            try
            {
                string sql = @"
            SELECT 
                id_company, adress_ot, adress_do, data_podachi_mashiny, vremya_dostavki,
                naimenovanie_gruza, obschiy_ves_kg, obschiy_obem_m3,
                dlina_m, shirina_m, vysota_m,
                list_otpravitelya, list_eksporta, stoimost_grupa_dlya_strahovaniya,
                tip_transporta, zagruzka_zadnyaya, zagruzka_bokovaya, zagruzka_verhnyaya,
                propusk_mozhd, propusk_ttk, propusk_sadovoe_koltso,
                poluchatel_organizatsiya, poluchatel_adress, poluchatel_kontakt, poluchatel_telefon,
                plateltschik, prochee, id_status
            FROM zakazzs.zayavki
            WHERE id_zayavki = @requestId AND id_zakazchika = @clientId";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("requestId", requestId);
                        cmd.Parameters.AddWithValue("clientId", GetClientId());

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int companyId = Convert.ToInt32(reader.GetValue(0));
                                for (int i = 0; i < cmbCompany.Items.Count; i++)
                                {
                                    var item = (CompanyItem)cmbCompany.Items[i];
                                    if (item.Id == companyId)
                                    {
                                        cmbCompany.SelectedIndex = i;
                                        break;
                                    }
                                }

                                txtFrom.Text = reader.GetString(1);
                                txtTo.Text = reader.GetString(2);

                                // ИСПРАВЛЕНО: проверяем дату перед установкой в DateTimePicker
                                DateTime machineDate = reader.GetDateTime(3);
                                if (machineDate >= dtpMachineDate.MinDate && machineDate <= dtpMachineDate.MaxDate)
                                {
                                    dtpMachineDate.Value = machineDate;
                                }
                                else
                                {
                                    // Если дата вне диапазона, устанавливаем текущую дату + 1 день
                                    dtpMachineDate.Value = DateTime.Now.AddDays(1);
                                }

                                // ИСПРАВЛЕНО: для времени также проверяем
                                try
                                {
                                    dtpDeliveryTime.Value = DateTime.Today.Add(reader.GetTimeSpan(4));
                                }
                                catch
                                {
                                    dtpDeliveryTime.Value = DateTime.Today.AddHours(14);
                                }

                                txtCargoName.Text = reader.GetString(5);
                                txtWeight.Text = reader.IsDBNull(6) ? "" : reader.GetDecimal(6).ToString();
                                txtVolume.Text = reader.IsDBNull(7) ? "" : reader.GetDecimal(7).ToString();

                                txtLength.Text = reader.IsDBNull(9) ? "" : reader.GetDecimal(9).ToString();
                                txtWidth.Text = reader.IsDBNull(10) ? "" : reader.GetDecimal(10).ToString();
                                txtHeight.Text = reader.IsDBNull(11) ? "" : reader.GetDecimal(11).ToString();

                                chkSenderList.Checked = reader.GetBoolean(12);
                                chkExportList.Checked = reader.GetBoolean(13);
                                txtInsuranceValue.Text = reader.IsDBNull(14) ? "" : reader.GetDecimal(14).ToString();

                                string transport = reader.IsDBNull(15) ? "" : reader.GetString(15);
                                if (!string.IsNullOrEmpty(transport))
                                {
                                    // Ищем соответствующий элемент в ComboBox
                                    int index = cmbTransportType.FindStringExact(transport);
                                    if (index >= 0)
                                        cmbTransportType.SelectedIndex = index;
                                }

                                chkRearLoading.Checked = reader.GetBoolean(16);
                                chkSideLoading.Checked = reader.GetBoolean(17);
                                chkTopLoading.Checked = reader.GetBoolean(18);
                                chkMozhd.Checked = reader.GetBoolean(19);
                                chkTtk.Checked = reader.GetBoolean(20);
                                chkSadovoe.Checked = reader.GetBoolean(21);

                                txtReceiverOrg.Text = reader.IsDBNull(22) ? "" : reader.GetString(22);
                                txtReceiverAddress.Text = reader.IsDBNull(23) ? "" : reader.GetString(23);
                                txtReceiverContact.Text = reader.IsDBNull(24) ? "" : reader.GetString(24);
                                txtReceiverPhone.Text = reader.IsDBNull(25) ? "" : reader.GetString(25);
                                txtPayer.Text = reader.IsDBNull(26) ? "" : reader.GetString(26);
                                txtWishes.Text = reader.IsDBNull(27) ? "" : reader.GetString(27);
                            }
                        }
                    }
                }

                editingRequestId = requestId;
                groupBoxOrder.Text = "✏️ Редактирование заявки №" + requestId;
                btnSubmit.Text = "💾 Сохранить изменения";

                int currentStatus = GetCurrentStatus(requestId);
                if (currentStatus != 1)
                {
                    MessageBox.Show("Внимание: Редактирование заявки может быть ограничено, так как текущий статус: " + GetStatusNameById(currentStatus),
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки заявки: " + ex.Message);
            }
        }

        private int GetCurrentStatus(int requestId)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT id_status FROM zakazzs.zayavki WHERE id_zayavki = @id";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("id", requestId);
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch { return 1; }
        }

        private string GetStatusNameById(int statusId)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT status_name FROM zakazzs.zayavki_status WHERE id_status = @id";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("id", statusId);
                        return cmd.ExecuteScalar()?.ToString() ?? "Неизвестно";
                    }
                }
            }
            catch { return "Неизвестно"; }
        }

        private void DgvRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int requestId = Convert.ToInt32(dgvRequests.Rows[e.RowIndex].Cells["id"].Value);

            if (dgvRequests.Columns[e.ColumnIndex].Name == "edit_button")
            {
                string status = dgvRequests.Rows[e.RowIndex].Cells["status"].Value?.ToString();
                if (status == "На рассмотрении")
                {
                    LoadRequestForEditing(requestId);
                    ShowOrderForm();
                }
                else
                {
                    MessageBox.Show($"Заявка со статусом \"{status}\" не может быть отредактирована.",
                        "Доступ запрещен", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (dgvRequests.Columns[e.ColumnIndex].Name == "delete_button")
            {
                DeleteRequest(requestId);
            }
            else if (dgvRequests.Columns[e.ColumnIndex].Name == "history_button")
            {
                ShowStatusHistory(requestId);
            }
        }

        private void ClearOrderForm()
        {
            if (!isFormInitialized) return;
            if (txtContactPerson != null) txtContactPerson.Clear();
            if (txtFrom != null) txtFrom.Clear();
            if (txtTo != null) txtTo.Clear();
            if (txtContactPhone != null) txtContactPhone.Clear();
            if (txtWishes != null) txtWishes.Clear();
            if (txtCargoName != null) txtCargoName.Clear();
            if (txtWeight != null) txtWeight.Clear();
            if (txtVolume != null) txtVolume.Clear();
            if (txtLength != null) txtLength.Clear();
            if (txtWidth != null) txtWidth.Clear();
            if (txtHeight != null) txtHeight.Clear();
            if (txtInsuranceValue != null) txtInsuranceValue.Clear();
            if (txtReceiverOrg != null) txtReceiverOrg.Clear();
            if (txtReceiverAddress != null) txtReceiverAddress.Clear();
            if (txtReceiverContact != null) txtReceiverContact.Clear();
            if (txtReceiverPhone != null) txtReceiverPhone.Clear();
            if (txtPayer != null) txtPayer.Clear();

            if (chkSenderList != null) chkSenderList.Checked = false;
            if (chkExportList != null) chkExportList.Checked = false;

            if (cmbTransportType != null && cmbTransportType.Items.Count > 0)
                cmbTransportType.SelectedIndex = -1;

            if (chkRearLoading != null) chkRearLoading.Checked = false;
            if (chkSideLoading != null) chkSideLoading.Checked = false;
            if (chkTopLoading != null) chkTopLoading.Checked = false;
            if (chkMozhd != null) chkMozhd.Checked = false;
            if (chkTtk != null) chkTtk.Checked = false;
            if (chkSadovoe != null) chkSadovoe.Checked = false;

            if (dtpMachineDate != null) dtpMachineDate.Value = DateTime.Now.AddDays(1);
            if (dtpDeliveryTime != null) dtpDeliveryTime.Value = DateTime.Today.AddHours(14);

            editingRequestId = -1;
            if (groupBoxOrder != null) groupBoxOrder.Text = "Новая заявка на перевозку";
            if (btnSubmit != null) btnSubmit.Text = "📤 Сохранить заявку";
        }

        // ==================== ОБРАБОТЧИКИ КНОПОК ====================

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            ClearOrderForm();
            ShowOrderForm();
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            ShowRequestsView();
            tabControlMain.SelectedTab = tabPageActive;
            LoadActiveRequests();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            ShowRequestsView();
            tabControlMain.SelectedTab = tabPageArchive;
            LoadArchiveRequests();
        }

        private void btnCompanies_Click(object sender, EventArgs e)
        {
            ShowCompaniesView();
        }

        // Класс для элемента ComboBox
        public class CompanyItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsDefault { get; set; }

            public string DisplayName => Name + (IsDefault ? " ✓" : "");

            public override string ToString()
            {
                return DisplayName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Click += (s, e) => { ClearOrderForm(); ShowRequestsView(); };
        }
    }
}