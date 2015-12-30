using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using inkass.Properties;

namespace inkass
{
    public partial class frmOptions : Form
    {
        private clsOptions o = new clsOptions();
        public frmOptions()
        {
            InitializeComponent();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            pg.SelectedObject = o;
        }

        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.num = o.num;
            Settings.Default.acc = o.acc;
            Settings.Default.accname = o.accname;
        }
    }
}
