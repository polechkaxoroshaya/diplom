using System;
using System.Windows.Forms;

namespace EVS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (var loginForm = new LoginForm())
                {
                    DialogResult result = loginForm.ShowDialog();

                    if (result == DialogResult.OK && AppSession.IsAuthenticated)
                    {
                        // Открываем форму в зависимости от роли
                        if (AppSession.CurrentUser.IsManager)
                        {
                            Application.Run(new ManagerMainForm());
                        }
                        else if (AppSession.CurrentUser.IsDriver)
                        {
                            Application.Run(new DriverMainForm());
                        }
                        else if (AppSession.CurrentUser.IsClientUser)
                        {
                            Application.Run(new ClientMainForm());
                        }
                        break;
                    }
                    else if (result == DialogResult.Retry)
                    {
                        using (var choiceForm = new RegistrationChoiceForm())
                        {
                            choiceForm.ShowDialog();
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}