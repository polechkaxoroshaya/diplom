using System;
using System.Drawing;
using System.Windows.Forms;

namespace EVS
{
    public partial class RegistrationChoiceForm : Form
    {
        private Panel headerPanel;
        private Label lblTitle;
        private Label lblSubtitle;
        private Button btnEmployee;
        private Button btnClient;
        private Button btnLogin;

        public RegistrationChoiceForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.headerPanel = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.btnEmployee = new Button();
            this.btnClient = new Button();
            this.btnLogin = new Button();

            this.SuspendLayout();

            // headerPanel
            this.headerPanel.BackColor = Color.FromArgb(0, 80, 131);
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Height = 120;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(40, 30);
            this.lblTitle.Text = "Столичная Логистика";

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new Font("Segoe UI", 12F);
            this.lblSubtitle.ForeColor = Color.FromArgb(200, 200, 255);
            this.lblSubtitle.Location = new Point(45, 75);
            this.lblSubtitle.Text = "Выберите тип регистрации";

            // btnEmployee - РЕГИСТРАЦИЯ СОТРУДНИКА
            this.btnEmployee.BackColor = Color.FromArgb(0, 120, 200);
            this.btnEmployee.FlatStyle = FlatStyle.Flat;
            this.btnEmployee.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnEmployee.ForeColor = Color.White;
            this.btnEmployee.Location = new Point(80, 160);
            this.btnEmployee.Size = new Size(250, 60);
            this.btnEmployee.Text = "👨‍💼 Я сотрудник";
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Cursor = Cursors.Hand;
            this.btnEmployee.Click += new EventHandler(this.btnEmployee_Click);

            // btnClient - РЕГИСТРАЦИЯ КЛИЕНТА
            this.btnClient.BackColor = Color.White;
            this.btnClient.FlatStyle = FlatStyle.Flat;
            this.btnClient.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnClient.ForeColor = Color.FromArgb(0, 80, 131);
            this.btnClient.Location = new Point(370, 160);
            this.btnClient.Size = new Size(250, 60);
            this.btnClient.Text = "👤 Я клиент";
            this.btnClient.UseVisualStyleBackColor = false;
            this.btnClient.Cursor = Cursors.Hand;
            this.btnClient.Click += new EventHandler(this.btnClient_Click);

            // btnLogin - КНОПКА "УЖЕ ЕСТЬ АККАУНТ? ВОЙТИ"
            this.btnLogin.BackColor = Color.Transparent;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Font = new Font("Segoe UI", 11F);
            this.btnLogin.ForeColor = Color.FromArgb(0, 80, 131);
            this.btnLogin.Location = new Point(250, 260);
            this.btnLogin.Size = new Size(200, 40);
            this.btnLogin.Text = "Уже есть аккаунт? Войти";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // RegistrationChoiceForm
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.lblSubtitle);

            this.BackColor = Color.FromArgb(240, 248, 255);
            this.ClientSize = new Size(700, 350);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrationChoiceForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Столичная Логистика - Добро пожаловать";

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new RegisterEmployeeForm())
            {
                form.ShowDialog();
            }
            this.Close();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new RegisterClientForm())
            {
                form.ShowDialog();
            }
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}