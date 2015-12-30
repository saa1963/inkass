using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using inkass.Properties;
using System.ComponentModel;

namespace inkass
{
    class clsOptions
    {
        private string _num = Settings.Default.num;
        private string _acc = Settings.Default.acc;
        private string _accname = Settings.Default.accname;

        [DisplayName("01.Начальный номер платежки")]
        [Description("Начальный номер платежки")]
        [Category("Общие")]
        public string num
        {
            get
            {
                return _num;
            }
            set { _num = value; }
        }
        [DisplayName("02.Номер счета (дебет)")]
        [Description("Номер счета (дебет)")]
        [Category("Общие")]
        public string acc
        {
            get
            {
                return _acc;
            }
            set { _acc = value; }
        }
        [DisplayName("03.Наименование счета (дебет)")]
        [Description("Наименование счета (дебет)")]
        [Category("Общие")]
        public string accname
        {
            get
            {
                return _accname;
            }
            set { _accname = value; }
        }
    }
}
