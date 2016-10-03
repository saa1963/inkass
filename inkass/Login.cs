using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace inkass
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbLogin.Text) || String.IsNullOrWhiteSpace(tbPassword.Text)) return;
            DialogResult = DialogResult.OK;
            Close();
        }
        public string LoginField
        {
            get { return tbLogin.Text; }
            set { tbLogin.Text = value; }
        }

        public string PasswordField
        {
            get { return tbPassword.Text; }
            set { tbPassword.Text = value; }
        }
    }
}
