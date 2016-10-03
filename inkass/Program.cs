using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using inkass.Properties;

namespace inkass
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var f = new Login();
            f.LoginField = Settings.Default.Login ?? "";
            f.PasswordField = Settings.Default.Password ?? "";
            if (f.ShowDialog() != DialogResult.OK) return;
            Settings.Default.Login = f.LoginField;
            Settings.Default.Password = f.PasswordField;
            Settings.Default.Save();
            Application.Run(new frmMain());
        }
    }
}
