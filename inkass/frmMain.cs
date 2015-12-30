using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using inkass.Properties;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace inkass
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tranzitDataSet.BNKSEEK' table. You can move, or remove it, as needed.
            tbDt.Value = DateTime.Today;
            ofd.InitialDirectory = Settings.Default.path1 ?? "";
            tbPath2.Text = Settings.Default.path2 ?? "";
            tbPath3.Text = Settings.Default.path3 ?? "";
            tbUserName.Text = Settings.Default.username ?? "";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Directory.Exists(tbPath1.Text))
                Settings.Default.path1 = Path.GetDirectoryName(tbPath1.Text);
            if (Directory.Exists(tbPath2.Text))
                Settings.Default.path2 = tbPath2.Text;
            if (Directory.Exists(tbPath3.Text))
                Settings.Default.path3 = tbPath3.Text;
            Settings.Default.username = tbUserName.Text;
            Settings.Default.Save();
        }

        private void btnPath1_Click(object sender, EventArgs e)
        {
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                tbPath1.Text = ofd.FileName;
            }
        }

        private void btnPath2_Click(object sender, EventArgs e)
        {
            DialogResult dr = fbd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                tbPath2.Text = fbd.SelectedPath;
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            var f = new frmOptions();
            f.ShowDialog();
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    int num;
        //    if (!File.Exists(tbPath1.Text))
        //    {
        //        MessageBox.Show("Файл " + tbPath1.Text + " не существует");
        //        return;
        //    }
        //    if (!Directory.Exists(tbPath2.Text))
        //    {
        //        MessageBox.Show("Папка " + tbPath2.Text + " не существует");
        //        return;
        //    }
        //    if (!Int32.TryParse(Settings.Default.num, out num))
        //    {
        //        MessageBox.Show("Не введен начальный номер платежки");
        //        return;
        //    }
        //    if (String.IsNullOrWhiteSpace(Settings.Default.acc))
        //    {
        //        MessageBox.Show("Не введен номер счета (дебет)");
        //        return;
        //    }
        //    if (String.IsNullOrWhiteSpace(Settings.Default.accname))
        //    {
        //        MessageBox.Show("Не введено наименование счета (дебет)");
        //        return;
        //    }
        //    SaveFile(tbPath1.Text, tbPath2.Text);
        //}

//        private void SaveFile(string path1, string path2)
//        {
//            List<clsBatch> lst = new List<clsBatch>();
//            XmlTextReader reader = null;

// //           try
////            {
//                reader = new XmlTextReader(path1);
//                reader.WhitespaceHandling = WhitespaceHandling.None; // пропускаем пустые узлы 
//                int nm = Int32.Parse(Settings.Default.num);
//                card[] cards = new card[2];
//                string bik;
//                decimal sm;
//                int batchno;

//                cards[0] = new card();
//                cards[1] = new card();
//                cards[0].sm = 0;
//                cards[1].sm = 0;
//                while (reader.Read())
//                    if (reader.NodeType == XmlNodeType.Element)
//                        if (reader.Name == "Deposit")
//                        {
//                            bik = reader.GetAttribute("BIK");
//                            var txtsm = reader.GetAttribute("Value").Replace('.', ',');
//                            sm = Decimal.Parse(txtsm);
//                            if (bik == "046850755")
//                            {
//                                cards[0].batchno = 1;
//                                cards[0].code = 0;
//                                cards[0].sm += sm;
//                                batchno = 1;
//                            }
//                            else
//                            {
//                                cards[1].batchno = 2;
//                                cards[1].code = 17;
//                                cards[1].sm += sm;
//                                batchno = 2;
//                            }
//                            lst.Add(new clsBatch("1", tbDt.Value, nm.ToString(), 
//                                sm, "6829000028",
//                                reader.GetAttribute("INN"), "682901001",
//                                reader.GetAttribute("KPP"), "046850755",
//                                bik, "     30101810600000000755",
//                                "     " + getCorr(bik),
//                                    Settings.Default.acc, reader.GetAttribute("Account"),
//                                    Settings.Default.accname, reader.GetAttribute("Name"),
//                                    "", reader.GetAttribute("MEMO"), batchno));
//                            nm++;
//                        }

//                CreateDbfs(path2);
//                var bname = Path.Combine(path2, "batchnew.dbf");
//                var cname = Path.Combine(path2, "cardbnew.dbf");
//                var b = new SAADBFLib.t34DBF();
//                var c = new SAADBFLib.t34DBF();
//                if (b.Open(bname))
//                {
//                    clsBatch.FillDbf(b, lst);
//                    b.Close();
//                }
//                else
//                    throw new Exception("Ошибка открытия файла " + bname);
//                if (c.Open(cname))
//                {
//                    for (int i = 0; i < 2; i++)
//                    {
//                        if (cards[i].sm > 0)
//                            clsBatch.FillCardbnew(c, tbDt.Value, cards[i].sm, cards[i].batchno, cards[i].code);
//                    }
//                    c.Close();
//                    MessageBox.Show("Выгрузка закончена");
//                }
//                else
//                    throw new Exception("Ошибка открытия файла " + cname);

////            }
////            catch (Exception ex)
////            {
////                MessageBox.Show("Ошибка: " + ex.Message);
////            }
////            finally
////            {
//                if (reader != null)
//                    reader.Close();
////            }
//        }


        private void CreateDbfs(string path2)
        {
            using (FileStream fs = new FileStream(Path.Combine(path2, "cardbnew.dbf"),
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.Write(Resource1.cardbnew, 0, Resource1.cardbnew.Length);
            }
            using (FileStream fs = new FileStream(Path.Combine(path2, "batchnew.dbf"),
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.Write(Resource1.batchnew, 0, Resource1.batchnew.Length);
            }
        }

        private const string CONNECTIONSTRING =
            @"Data Source = 
                (DESCRIPTION = 
                    (ADDRESS = 
                        (PROTOCOL = TCP)
                        (HOST = 192.168.20.217)
                        (PORT = 1521)
                    )
                    (CONNECT_DATA = 
                        (SERVER = DEDICATED)
                        (SERVICE_NAME = ODB)
                    )
                );User Id=XXI;Password=xdr5^&*(";

        private string getCorr(string bik)
        {
            string rt = "";
            using (OracleConnection cn = new OracleConnection(CONNECTIONSTRING))
            {
                try
                {
                    cn.Open();
                    OracleCommand cmd = new OracleCommand(
                        @"select IFOGCORACC_NEW from FOG_BNKSEEK where CFOGMFO8 = :bik", cn);
                    cmd.Parameters.Add("bik", OracleDbType.Varchar2).Value = bik;
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            rt = dr["IFOGCORACC_NEW"].ToString();
                        }
                    }
                }
                catch (OracleException e1)
                {
                    MessageBox.Show(e1.Message);
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            return rt;
        }

        //private string getCorr(string bik)
        //{
        //    string rt = "";
        //    string connstr = "Data Source=192.168.20.221;Initial Catalog=tranzit;Persist Security Info=True;User ID=sa;Password=zxc";
        //    using (var cn = new SqlConnection(connstr))
        //    {
        //        try
        //        {
        //            cn.Open();
        //            var cmd = new SqlCommand("select ksnp from bnkseek where newnum = '" + bik + "'", cn);
        //            var dr = cmd.ExecuteReader();
        //            if (dr.Read())
        //            {
        //                rt = dr.GetString(0);
        //            }
        //            return rt.Trim();
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(e.Message);
        //            Close();
        //            return rt;
        //        }
        //    }
        //}

        private void btnPath3_Click(object sender, EventArgs e)
        {
            DialogResult dr = fbd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                tbPath3.Text = fbd.SelectedPath;
            }
        }

        private void btnSaveXXI_Click(object sender, EventArgs e)
        {
            int num;
            if (!File.Exists(tbPath1.Text))
            {
                MessageBox.Show("Файл " + tbPath1.Text + " не существует");
                return;
            }
            if (!Directory.Exists(tbPath3.Text))
            {
                MessageBox.Show("Папка " + tbPath3.Text + " не существует");
                return;
            }
            if (!Int32.TryParse(Settings.Default.num, out num))
            {
                MessageBox.Show("Не введен начальный номер платежки");
                return;
            }
            if (String.IsNullOrWhiteSpace(Settings.Default.acc))
            {
                MessageBox.Show("Не введен номер счета (дебет)");
                return;
            }
            if (String.IsNullOrWhiteSpace(Settings.Default.accname))
            {
                MessageBox.Show("Не введено наименование счета (дебет)");
                return;
            }
            SaveFileXXI(tbPath1.Text, tbPath3.Text);
        }

        private void SaveFileXXI(string path1, string path3)
        {
            List<clsBatch> lst = new List<clsBatch>();
            XmlTextReader reader = null;

            //           try
            //            {
            reader = new XmlTextReader(path1);
            reader.WhitespaceHandling = WhitespaceHandling.None; // пропускаем пустые узлы 
            int nm = Int32.Parse(Settings.Default.num);
            card[] cards = new card[2];
            string bik;
            decimal sm;
            int batchno;

            cards[0] = new card();
            cards[1] = new card();
            cards[0].sm = 0;
            cards[1].sm = 0;
            while (reader.Read())
                if (reader.NodeType == XmlNodeType.Element)
                    if (reader.Name == "Deposit")
                    {
                        bik = reader.GetAttribute("BIK");
                        var txtsm = reader.GetAttribute("Value").Replace('.', ',');
                        sm = Decimal.Parse(txtsm);
                        if (bik == "046850755")
                        {
                            cards[0].batchno = 1;
                            cards[0].code = 0;
                            cards[0].sm += sm;
                            batchno = 1;
                        }
                        else
                        {
                            cards[1].batchno = 2;
                            cards[1].code = 17;
                            cards[1].sm += sm;
                            batchno = 2;
                        }
                        lst.Add(new clsBatch("1", tbDt.Value, nm.ToString(),
                            sm, "6829000028",
                            reader.GetAttribute("INN"), "682901001",
                            reader.GetAttribute("KPP"), "046850755",
                            bik, "     30101810600000000755",
                            "     " + getCorr(bik),
                                Settings.Default.acc, reader.GetAttribute("Account"),
                                Settings.Default.accname, reader.GetAttribute("Name"),
                                "", reader.GetAttribute("MEMO"), batchno));
                        nm++;
                    }

            var bname = Path.Combine(path3, "inkass_doc.txt");

            string s = "";
            foreach (clsBatch batch in lst)
            {
                if (batch.creditmfo.Trim() != "046850755")
                {
                    s += "# Doc Begin" + "\r\n";
                    s += "BO1=" + "4" + "\r\n";
                    s += "Date_Reg=" + batch.workdate.ToString("dd.MM.yyyy") + "\r\n";
                    s += "Date_Doc=" + batch.workdate.ToString("dd.MM.yyyy") + "\r\n";
                    s += "Date_Val=" + batch.workdate.ToString("dd.MM.yyyy") + "\r\n";
                    s += "Doc_Num=" + batch.docno.Trim() + "\r\n";
                    s += "Batch_Num=" + "7080" + "\r\n";
                    s += "Priority=" + batch.group + "\r\n";
                    s += "Purpose=" + batch.info + "\r\n";
                    s += "Summa=" + batch.payment.ToString("##########0.00") + "\r\n";
                    s += "Currency=" + "RUR" + "\r\n";
                    s += "Date_Shadow=" + batch.workdate.ToString("dd.MM.yyyy") + "\r\n";
                    s += "DWay_Type=" + "E" + "\r\n";
                    s += "VO=" + "01" + "\r\n";
                    s += "Payer_Acc=" + batch.debetacc.Trim() + "\r\n";
                    s += "Recipient_Acc=" + batch.creditacc.Trim() + "\r\n";
                    s += "Client_Name=" + batch.debetname.Trim() + "\r\n";
                    s += "Client_INN=" + batch.debet_inn.Trim() + "\r\n";
                    s += "Corr_RBIC=" + batch.creditmfo.Trim() + "\r\n";
                    s += "Corr_CorAcc=" + batch.creditcorr.Trim() + "\r\n";
                    //s += "Corr_Bank_Name=" + GetBankName(batch.creditmfo.Trim()) + "\r\n";
                    s += "Corr_Name=" + batch.creditname.Trim() + "\r\n";
                    s += "Corr_INN=" + batch.credit_inn.Trim() + "\r\n";
                    s += "User=" + Settings.Default.username + "\r\n";
                    s += "# Doc End" + "\r\n";
                    s += "\r\n";
                }
                else
                {
                    s += "# Doc Begin" + "\r\n";
                    s += "Deb_Acc=" + batch.debetacc.Trim() + "\r\n";
                    s += "Deb_Cur=" + "RUR" + "\r\n";
                    s += "Deb_Sum=" + batch.payment.ToString("##########0.00") + "\r\n";
                    s += "Cre_Acc=" + batch.creditacc.Trim() + "\r\n";
                    s += "Cre_Cur=" + "RUR" + "\r\n";
                    s += "Cre_Sum=" + batch.payment.ToString("##########0.00") + "\r\n";
                    s += "BO1=" + "1" + "\r\n";
                    s += "Date_Reg=" + batch.workdate.ToString("dd.MM.yyyy") + "\r\n";
                    s += "Date_Doc=" + batch.workdate.ToString("dd.MM.yyyy") + "\r\n";
                    s += "Date_Val=" + batch.workdate.ToString("dd.MM.yyyy") + "\r\n";
                    s += "Date_Trn=" + batch.workdate.ToString("dd.MM.yyyy") + "\r\n";
                    s += "Doc_Num=" + batch.docno.Trim() + "\r\n";
                    s += "Batch_Num=" + "7080" + "\r\n";
                    s += "Client_Name=" + batch.debetname.Trim() + "\r\n";
                    s += "Client_INN=" + batch.debet_inn.Trim() + "\r\n";
                    s += "Corr_Name=" + batch.creditname.Trim() + "\r\n";
                    s += "Corr_INN=" + batch.credit_inn.Trim() + "\r\n";
                    s += "Purpose=" + batch.info + "\r\n";
                    s += "VO=" + "01" + "\r\n";
                    s += "User=" + Settings.Default.username + "\r\n";
                    s += "# Doc End" + "\r\n";
                    s += "\r\n";
                }
            }

            File.WriteAllText(bname, s, Encoding.GetEncoding(1251));
            
            if (reader != null)
                reader.Close();
            //            }
        }
    }
}
