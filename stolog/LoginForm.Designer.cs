namespace EVS
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        // ✅ ИСПРАВЛЕНО: убран override, так как это не переопределение, а очистка компонентов
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}