using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace EVS
{
    public partial class AddTruckForm : Form
    {
        private string connectionString = "Host=localhost;Database=www2;Username=postgres;Password=root";

        private TextBox txtMarka;
        private TextBox txtModel;
        private TextBox txtNumber;
        private ComboBox cmbRegion;
        private ComboBox cmbGruzopodemnost;
        private ComboBox cmbObem;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnCancel;
        private Panel headerPanel;
        private Label lblHeader;
        private Panel mainPanel;
        private GroupBox gbMain;
        private Label lblMarka;
        private Label lblModel;
        private Label lblNumber;
        private Label lblRegion;
        private Label lblGruz;
        private Label lblObem;
        private Label lblStatus;
        private Label lblRequiredInfo;

        public AddTruckForm()
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            lblHeader = new Label();
            mainPanel = new Panel();
            gbMain = new GroupBox();
            lblMarka = new Label();
            txtMarka = new TextBox();
            lblModel = new Label();
            txtModel = new TextBox();
            lblNumber = new Label();
            txtNumber = new TextBox();
            lblRegion = new Label();
            cmbRegion = new ComboBox();
            lblGruz = new Label();
            cmbGruzopodemnost = new ComboBox();
            lblObem = new Label();
            cmbObem = new ComboBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblRequiredInfo = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            headerPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            gbMain.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(0, 80, 131);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(534, 60);
            headerPanel.TabIndex = 1;
            // 
            // lblHeader
            // 
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(20, 15);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(475, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Добавление нового автомобиля";
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(gbMain);
            mainPanel.Controls.Add(lblRequiredInfo);
            mainPanel.Controls.Add(btnSave);
            mainPanel.Controls.Add(btnCancel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 60);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(534, 460);
            mainPanel.TabIndex = 0;
            // 
            // gbMain
            // 
            gbMain.BackColor = Color.White;
            gbMain.Controls.Add(lblMarka);
            gbMain.Controls.Add(txtMarka);
            gbMain.Controls.Add(lblModel);
            gbMain.Controls.Add(txtModel);
            gbMain.Controls.Add(lblNumber);
            gbMain.Controls.Add(txtNumber);
            gbMain.Controls.Add(lblRegion);
            gbMain.Controls.Add(cmbRegion);
            gbMain.Controls.Add(lblGruz);
            gbMain.Controls.Add(cmbGruzopodemnost);
            gbMain.Controls.Add(lblObem);
            gbMain.Controls.Add(cmbObem);
            gbMain.Controls.Add(lblStatus);
            gbMain.Controls.Add(cmbStatus);
            gbMain.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            gbMain.Location = new Point(5, 10);
            gbMain.Name = "gbMain";
            gbMain.Size = new Size(506, 344);
            gbMain.TabIndex = 0;
            gbMain.TabStop = false;
            gbMain.Text = "Основные данные";
            // 
            // lblMarka
            // 
            lblMarka.Font = new Font("Segoe UI", 10F);
            lblMarka.ForeColor = Color.FromArgb(0, 80, 131);
            lblMarka.Location = new Point(15, 30);
            lblMarka.Name = "lblMarka";
            lblMarka.Size = new Size(150, 28);
            lblMarka.TabIndex = 0;
            lblMarka.Text = "Марка:*";
            // 
            // txtMarka
            // 
            txtMarka.Font = new Font("Segoe UI", 10F);
            txtMarka.Location = new Point(171, 30);
            txtMarka.Name = "txtMarka";
            txtMarka.Size = new Size(300, 25);
            txtMarka.TabIndex = 1;
            // 
            // lblModel
            // 
            lblModel.Font = new Font("Segoe UI", 10F);
            lblModel.ForeColor = Color.FromArgb(0, 80, 131);
            lblModel.Location = new Point(15, 70);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(150, 28);
            lblModel.TabIndex = 2;
            lblModel.Text = "Модель:*";
            // 
            // txtModel
            // 
            txtModel.Font = new Font("Segoe UI", 10F);
            txtModel.Location = new Point(171, 70);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(300, 25);
            txtModel.TabIndex = 3;
            // 
            // lblNumber
            // 
            lblNumber.Font = new Font("Segoe UI", 10F);
            lblNumber.ForeColor = Color.FromArgb(0, 80, 131);
            lblNumber.Location = new Point(15, 110);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(150, 28);
            lblNumber.TabIndex = 4;
            lblNumber.Text = "Гос. номер:*";
            // 
            // txtNumber
            // 
            txtNumber.Font = new Font("Segoe UI", 10F);
            txtNumber.Location = new Point(171, 110);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(200, 25);
            txtNumber.TabIndex = 5;
            // 
            // lblRegion
            // 
            lblRegion.Font = new Font("Segoe UI", 10F);
            lblRegion.ForeColor = Color.FromArgb(0, 80, 131);
            lblRegion.Location = new Point(15, 150);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new Size(150, 28);
            lblRegion.TabIndex = 6;
            lblRegion.Text = "Регион номера:*";
            // 
            // cmbRegion
            // 
            cmbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRegion.Font = new Font("Segoe UI", 10F);
            cmbRegion.Location = new Point(171, 150);
            cmbRegion.Name = "cmbRegion";
            cmbRegion.Size = new Size(250, 25);
            cmbRegion.TabIndex = 7;
            // 
            // lblGruz
            // 
            lblGruz.Font = new Font("Segoe UI", 10F);
            lblGruz.ForeColor = Color.FromArgb(0, 80, 131);
            lblGruz.Location = new Point(15, 195);
            lblGruz.Name = "lblGruz";
            lblGruz.Size = new Size(150, 28);
            lblGruz.TabIndex = 8;
            lblGruz.Text = "Грузоподъемность:*";
            // 
            // cmbGruzopodemnost
            // 
            cmbGruzopodemnost.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGruzopodemnost.Font = new Font("Segoe UI", 10F);
            cmbGruzopodemnost.Location = new Point(171, 195);
            cmbGruzopodemnost.Name = "cmbGruzopodemnost";
            cmbGruzopodemnost.Size = new Size(250, 25);
            cmbGruzopodemnost.TabIndex = 9;
            // 
            // lblObem
            // 
            lblObem.Font = new Font("Segoe UI", 10F);
            lblObem.ForeColor = Color.FromArgb(0, 80, 131);
            lblObem.Location = new Point(15, 240);
            lblObem.Name = "lblObem";
            lblObem.Size = new Size(150, 28);
            lblObem.TabIndex = 10;
            lblObem.Text = "Объем кузова:*";
            // 
            // cmbObem
            // 
            cmbObem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbObem.Font = new Font("Segoe UI", 10F);
            cmbObem.Location = new Point(171, 240);
            cmbObem.Name = "cmbObem";
            cmbObem.Size = new Size(250, 25);
            cmbObem.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.FromArgb(0, 80, 131);
            lblStatus.Location = new Point(15, 285);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(150, 28);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Статус:*";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.Location = new Point(171, 285);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 25);
            cmbStatus.TabIndex = 13;
            // 
            // lblRequiredInfo
            // 
            lblRequiredInfo.Font = new Font("Segoe UI", 9F);
            lblRequiredInfo.ForeColor = Color.Gray;
            lblRequiredInfo.Location = new Point(11, 357);
            lblRequiredInfo.Name = "lblRequiredInfo";
            lblRequiredInfo.Size = new Size(500, 25);
            lblRequiredInfo.TabIndex = 1;
            lblRequiredInfo.Text = "* - обязательные поля";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 120, 200);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(154, 397);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 2;
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
            btnCancel.Location = new Point(289, 397);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddTruckForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(534, 520);
            Controls.Add(mainPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddTruckForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавить автомобиль";
            headerPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            gbMain.ResumeLayout(false);
            gbMain.PerformLayout();
            ResumeLayout(false);
        }

        private void LoadComboBoxes()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // ============ ЗАГРУЗКА РЕГИОНОВ (НОВЫЙ КОМБОБОКС) ============
                    string sqlRegion = @"
                        SELECT id_regiona, region_gorod || ' (' || region_chifra || ')' AS display_name
                        FROM mashini.regioninomerovmashin 
                        ORDER BY region_gorod, region_chifra";

                    using (var cmd = new NpgsqlCommand(sqlRegion, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbRegion.Items.Clear();
                        while (reader.Read())
                        {
                            cmbRegion.Items.Add(new RegionItem
                            {
                                Id = reader.GetInt64(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }

                    // Загружаем грузоподъемность
                    string sqlGruz = "SELECT id_gryz, tip FROM mashini.gryzopodemnostimashin ORDER BY id_gryz";
                    using (var cmd = new NpgsqlCommand(sqlGruz, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbGruzopodemnost.Items.Clear();
                        while (reader.Read())
                        {
                            cmbGruzopodemnost.Items.Add(new ComboItem
                            {
                                Id = reader.GetInt64(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }

                    // Загружаем объем кузова
                    string sqlObem = "SELECT id_obema, obem_v_paletax || ' паллет (' || obem_ot || '-' || obem_do || ' м³)' AS name FROM mashini.obemikyzova ORDER BY id_obema";
                    using (var cmd = new NpgsqlCommand(sqlObem, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbObem.Items.Clear();
                        while (reader.Read())
                        {
                            cmbObem.Items.Add(new ComboItem
                            {
                                Id = reader.GetInt64(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }

                    // Загружаем статусы
                    string sqlStatus = "SELECT id_statysa_mashini, nazvanie_statysa FROM mashini.statysimashin ORDER BY id_statysa_mashini";
                    using (var cmd = new NpgsqlCommand(sqlStatus, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbStatus.Items.Clear();
                        while (reader.Read())
                        {
                            cmbStatus.Items.Add(new ComboItem
                            {
                                Id = reader.GetInt64(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }

                // Настройка отображения
                cmbRegion.DisplayMember = "Name";
                cmbRegion.ValueMember = "Id";
                cmbGruzopodemnost.DisplayMember = "Name";
                cmbGruzopodemnost.ValueMember = "Id";
                cmbObem.DisplayMember = "Name";
                cmbObem.ValueMember = "Id";
                cmbStatus.DisplayMember = "Name";
                cmbStatus.ValueMember = "Id";

                // Выбираем значения по умолчанию
                if (cmbRegion.Items.Count > 0) cmbRegion.SelectedIndex = 0;
                if (cmbGruzopodemnost.Items.Count > 0) cmbGruzopodemnost.SelectedIndex = 0;
                if (cmbObem.Items.Count > 0) cmbObem.SelectedIndex = 0;
                if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки справочников: " + ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(txtMarka.Text))
            {
                MessageBox.Show("Введите марку автомобиля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMarka.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtModel.Text))
            {
                MessageBox.Show("Введите модель автомобиля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModel.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("Введите госномер автомобиля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumber.Focus();
                return;
            }
            if (cmbRegion.SelectedItem == null)
            {
                MessageBox.Show("Выберите регион!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbGruzopodemnost.SelectedItem == null)
            {
                MessageBox.Show("Выберите грузоподъемность!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbObem.SelectedItem == null)
            {
                MessageBox.Show("Выберите объем кузова!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        // 1. Получаем ID региона из ComboBox
                        long regionId = ((RegionItem)cmbRegion.SelectedItem).Id;

                        // 2. Добавляем номер в таблицу номеров
                        string sqlNumber = @"
                            INSERT INTO mashini.nomeramashin (region, nomer_mashini)
                            VALUES (@region, @number) RETURNING id_nomera";

                        long numberId;
                        using (var cmd = new NpgsqlCommand(sqlNumber, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("region", regionId);
                            cmd.Parameters.AddWithValue("number", txtNumber.Text.Trim().ToUpper());
                            numberId = (long)cmd.ExecuteScalar();
                        }

                        // 3. Добавляем автомобиль
                        long gruzId = ((ComboItem)cmbGruzopodemnost.SelectedItem).Id;
                        long obemId = ((ComboItem)cmbObem.SelectedItem).Id;
                        long statusId = ((ComboItem)cmbStatus.SelectedItem).Id;

                        string sqlTruck = @"
                            INSERT INTO mashini.mashinki (marka, polnoe_nazvanie, nomer, gryzopodemnost, obem_kyzova, statys_mashini)
                            VALUES (@marka, @model, @numberId, @gruz, @obem, @status)
                            RETURNING id_mashini";

                        using (var cmd = new NpgsqlCommand(sqlTruck, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("marka", txtMarka.Text.Trim());
                            cmd.Parameters.AddWithValue("model", txtModel.Text.Trim());
                            cmd.Parameters.AddWithValue("numberId", numberId);
                            cmd.Parameters.AddWithValue("gruz", gruzId);
                            cmd.Parameters.AddWithValue("obem", obemId);
                            cmd.Parameters.AddWithValue("status", statusId);
                            long truckId = (long)cmd.ExecuteScalar();
                        }

                        transaction.Commit();
                    }
                }

                string regionName = ((RegionItem)cmbRegion.SelectedItem).Name;
                MessageBox.Show($"Автомобиль {txtMarka.Text} {txtModel.Text} ({txtNumber.Text.Trim().ToUpper()}) успешно добавлен!\nРегион: {regionName}",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Классы для элементов ComboBox
        public class RegionItem
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

        public class ComboItem
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}