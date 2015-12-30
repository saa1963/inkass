using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inkass
{
    public enum VidDoc
    {
        внутренний,
        межфилиальный,
        электронный
    }

    public class clsBatch
    {
        private static int nn = 1;
        //private DateTime GetDate(SAADBFLib.t34DBF dbf, string field)
        //{
        //    object o = dbf.FieldGet(field);
        //    if (o is System.DBNull)
        //        return DateTime.MinValue;
        //    else
        //        return (DateTime)o;
        //}
        //private int GetInt(SAADBFLib.t34DBF dbf, string field)
        //{
        //    return Convert.ToInt32(dbf.FieldGet(field));
        //}
        //private decimal GetDecimal(SAADBFLib.t34DBF dbf, string field)
        //{
        //    return Convert.ToDecimal(dbf.FieldGet(field));
        //}

        public clsBatch(string chapter, DateTime dt, string docno, decimal payment, 
            string debetinn, string creditinn,
            string debetkpp, string creditkpp,
            string debetbik, string creditbik,
            string debetcor, string creditcor,
            string debetacc, string creditacc, string debetname, string creditname, string symbol, string info, int _batchno)
        {
            this.chapter = chapter;
            docdate = dt;
            workdate = dt;
            begdate = dt;
            dppdate = dt;
            group = "5";		//1
            batchno = _batchno;
            this.docno = docno;
            this.payment = payment;
            cur_dpaym = payment;
            cur_cpaym = payment;
            opertype = "01";	//2
            Operator = 0;
            debetmfo = debetbik;	//9
            creditmfo = creditbik;	//9
            debetcorr = debetcor; //"     30101810600000000755";	//25
            creditcorr = creditcor;	//25
            this.debetacc = "     " + debetacc;	//25
            this.creditacc = "     " + creditacc;	//25
            //this.realdbacc = "     " + debetacc;	//25
            //this.realcracc = "     " + creditacc;	//25
            kass_sym = symbol;
            if (debetbik == creditbik)
            {
                code = 0;
                codepay = 0;
                viddoc = VidDoc.внутренний;
            }
            else
            {
                code = 17;
                codepay = 129;
                viddoc = VidDoc.электронный;
            }
            id = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss") + nn.ToString("000000");
            nn++;
            this.debetname = debetname;
            debet_inn = debetinn;
            this.creditname = creditname;
            credit_inn = creditinn;
            debet_kpp = debetkpp;
            credit_kpp = creditkpp;
            this.info = info;
        }

        //public clsBatch(SAADBFLib.t34DBF dbf, string description)
        //{
        //    object ob;
        //    chapter = (string)dbf.FieldGet("chapter");
        //    docdate = GetDate(dbf, "docdate");
        //    workdate = GetDate(dbf, "workdate");
        //    paydate = GetDate(dbf, "paydate");
        //    begdate = GetDate(dbf, "begdate");
        //    dppdate = GetDate(dbf, "dppdate");
        //    group = (string)dbf.FieldGet("group");		//1
        //    batchno = GetInt(dbf, "batchno");
        //    docno = (string)dbf.FieldGet("docno");		//6
        //    payment = GetDecimal(dbf, "payment");
        //    cur_dpaym = GetDecimal(dbf, "cur_dpaym");
        //    cur_cpaym = GetDecimal(dbf, "cur_cpaym");
        //    opertype = (string)dbf.FieldGet("opertype");	//2
        //    Operator = GetInt(dbf, "operator");
        //    debetmfo = (string)dbf.FieldGet("debetmfo");	//9
        //    creditmfo = (string)dbf.FieldGet("creditmfo");	//9
        //    ob = dbf.FieldGet("dbankinn");
        //    if (ob != System.DBNull.Value)
        //        dbankinn = (string)dbf.FieldGet("dbankinn");	//12
        //    else
        //        dbankinn = "";
        //    ob = dbf.FieldGet("cbankinn");
        //    if (ob != System.DBNull.Value)
        //        cbankinn = (string)dbf.FieldGet("cbankinn");	//12
        //    else
        //        cbankinn = "";
        //    debetcorr = (string)dbf.FieldGet("debetcorr");	//25
        //    creditcorr = (string)dbf.FieldGet("creditcorr");	//25
        //    debetacc = (string)dbf.FieldGet("debetacc");	//25
        //    creditacc = (string)dbf.FieldGet("creditacc");	//25
        //    realdbacc = (string)dbf.FieldGet("realdbacc");	//25
        //    realcracc = (string)dbf.FieldGet("realcracc");	//25
        //    kass_sym = (string)dbf.FieldGet("kass_sym");	//2
        //    kass_sym2 = (string)dbf.FieldGet("kass_sym2");	//2
        //    error_c = GetInt(dbf, "error_c");
        //    ob = dbf.FieldGet("checks");
        //    if (ob != System.DBNull.Value)
        //        checks = (string)dbf.FieldGet("checks");		//20
        //    else
        //        checks = "";
        //    paysign = (string)dbf.FieldGet("paysign");	//1
        //    code = GetInt(dbf, "code");
        //    codepay = GetInt(dbf, "codepay");
        //    ob = dbf.FieldGet("debcred");
        //    if (ob != System.DBNull.Value)
        //        debcred = (string)dbf.FieldGet("debcred");	//1
        //    else
        //        debcred = "";
        //    istransit = (bool)dbf.FieldGet("istransit");
        //    parent_id = (string)dbf.FieldGet("parent_id");	//20
        //    id = (string)dbf.FieldGet("id");			//20
        //    ob = dbf.FieldGet("isoldcard");
        //    if (ob != System.DBNull.Value)
        //        isoldcard = (bool)dbf.FieldGet("isoldcard");
        //    else
        //        isoldcard = false;
        //    laccount = (string)dbf.FieldGet("laccount");	//25
        //    lacccred = (string)dbf.FieldGet("lacccred");	//25
        //    cargo = (string)dbf.FieldGet("cargo");		//254
        //    source = GetInt(dbf, "source");
        //    debetname = (string)dbf.FieldGet("debetname");	//160
        //    debet_inn = (string)dbf.FieldGet("debet_inn");	//12
        //    creditname = (string)dbf.FieldGet("creditname");	//160
        //    credit_inn = (string)dbf.FieldGet("credit_inn");	//12
        //    debet_kpp = (string)dbf.FieldGet("debet_kpp");	//9
        //    credit_kpp = (string)dbf.FieldGet("credit_kpp");	//9
        //    statusdrw = (string)dbf.FieldGet("statusdrw");	//2
        //    kbk = (string)dbf.FieldGet("kbk");		//20
        //    okato = (string)dbf.FieldGet("okato");		//11
        //    basenlgpay = (string)dbf.FieldGet("basenlgpay");	//2
        //    nlgperiod = (string)dbf.FieldGet("nlgperiod");	//10
        //    numnlgdoc = (string)dbf.FieldGet("numnlgdoc");	//15
        //    datenlgdoc = GetDate(dbf, "datenlgdoc");
        //    typenlgpay = (string)dbf.FieldGet("typenlgpay");	//2
        //    info = (string)dbf.FieldGet("info");		//210
        //    ob = dbf.FieldGet("markdate");
        //    if (ob != System.DBNull.Value)
        //        markdate = GetDate(dbf, "markdate");
        //    else
        //        markdate = DateTime.MinValue;
        //    ob = dbf.FieldGet("sop");
        //    if (ob != System.DBNull.Value)
        //        sop = (string)dbf.FieldGet("sop");
        //    else
        //        sop = "";
        //    ob = dbf.FieldGet("spod");
        //    if (ob != System.DBNull.Value)
        //        spod = (bool)dbf.FieldGet("spod");	//2
        //    else
        //        spod = false;

        //    if (debetmfo != creditmfo)
        //        viddoc = VidDoc.электронный;
        //    else
        //    {
        //        if (debetacc.Substring(16, 1) != creditacc.Substring(16, 1))
        //            viddoc = VidDoc.межфилиальный;
        //        else
        //            viddoc = VidDoc.внутренний;
        //    }
        //    this.description = description;
        //}
        public string chapter
        {
            get { return _chapter; }
            set { _chapter = value; }
        }
        public DateTime docdate
        {
            get { return _docdate; }
            set { _docdate = value; }
        }
        public DateTime workdate
        {
            get { return _workdate; }
            set { _workdate = value; }
        }
        public DateTime paydate
        {
            get { return _paydate; }
            set { _paydate = value; }
        }
        public DateTime begdate
        {
            get { return _begdate; }
            set { _begdate = value; }
        }
        public DateTime dppdate
        {
            get { return _dppdate; }
            set { _dppdate = value; }
        }
        public string group
        {
            get { return _group; }
            set { _group = value; }
        }
        public int batchno
        {
            get { return _batchno; }
            set { _batchno = value; }
        }
        public string docno
        {
            get { return _docno; }
            set { _docno = value; }
        }
        public decimal payment
        {
            get { return _payment; }
            set { _payment = value; }
        }
        public decimal cur_dpaym
        {
            get { return _cur_dpaym; }
            set { _cur_dpaym = value; }
        }
        public decimal cur_cpaym
        {
            get { return _cur_cpaym; }
            set { _cur_cpaym = value; }
        }
        public string opertype
        {
            get { return _opertype; }
            set { _opertype = value; }
        }
        public int Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }
        public string debetmfo
        {
            get { return _debetmfo; }
            set { _debetmfo = value; }
        }
        public string creditmfo
        {
            get { return _creditmfo; }
            set { _creditmfo = value; }
        }
        public string dbankinn
        {
            get { return _dbankinn; }
            set { _dbankinn = value; }
        }
        public string cbankinn
        {
            get { return _cbankinn; }
            set { _cbankinn = value; }
        }
        public string debetcorr
        {
            get { return _debetcorr; }
            set { _debetcorr = value; }
        }
        public string creditcorr
        {
            get { return _creditcorr; }
            set { _creditcorr = value; }
        }
        public string debetacc
        {
            get { return _debetacc; }
            set { _debetacc = value; }
        }
        public string creditacc
        {
            get { return _creditacc; }
            set { _creditacc = value; }
        }
        public string realdbacc
        {
            get { return _realdbacc; }
            set { _realdbacc = value; }
        }
        public string realcracc
        {
            get { return _realcracc; }
            set { _realcracc = value; }
        }
        public string kass_sym
        {
            get { return _kass_sym; }
            set { _kass_sym = value; }
        }
        public string kass_sym2
        {
            get { return _kass_sym2; }
            set { _kass_sym2 = value; }
        }
        public int error_c
        {
            get { return _error_c; }
            set { _error_c = value; }
        }
        public string checks
        {
            get { return _checks; }
            set { _checks = value; }
        }
        public string paysign
        {
            get { return _paysign; }
            set { _paysign = value; }
        }
        public int code
        {
            get { return _code; }
            set { _code = value; }
        }
        public int codepay
        {
            get { return _codepay; }
            set { _codepay = value; }
        }
        public string debcred
        {
            get { return _debcred; }
            set { _debcred = value; }
        }
        public bool istransit
        {
            get { return _istransit; }
            set { _istransit = value; }
        }
        public string parent_id
        {
            get { return _parent_id; }
            set { _parent_id = value; }
        }
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        public bool isoldcard
        {
            get { return _isoldcard; }
            set { _isoldcard = value; }
        }
        public string laccount
        {
            get { return _laccount; }
            set { _laccount = value; }
        }
        public string lacccred
        {
            get { return _lacccred; }
            set { _lacccred = value; }
        }
        public string cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }
        public int source
        {
            get { return _source; }
            set { _source = value; }
        }
        public string debetname
        {
            get { return _debetname; }
            set { _debetname = value; }
        }
        public string debet_inn
        {
            get { return _debet_inn; }
            set { _debet_inn = value; }
        }
        public string creditname
        {
            get { return _creditname; }
            set { _creditname = value; }
        }
        public string credit_inn
        {
            get { return _credit_inn; }
            set { _credit_inn = value; }
        }
        public string debet_kpp
        {
            get { return _debet_kpp; }
            set { _debet_kpp = value; }
        }
        public string credit_kpp
        {
            get { return _credit_kpp; }
            set { _credit_kpp = value; }
        }
        public string statusdrw
        {
            get { return _statusdrw; }
            set { _statusdrw = value; }
        }
        public string kbk
        {
            get { return _kbk; }
            set { _kbk = value; }
        }
        public string okato
        {
            get { return _okato; }
            set { _okato = value; }
        }
        public string basenlgpay
        {
            get { return _basenlgpay; }
            set { _basenlgpay = value; }
        }
        public string nlgperiod
        {
            get { return _nlgperiod; }
            set { _nlgperiod = value; }
        }
        public string numnlgdoc
        {
            get { return _numnlgdoc; }
            set { _numnlgdoc = value; }
        }
        public DateTime datenlgdoc
        {
            get { return _datenlgdoc; }
            set { _datenlgdoc = value; }
        }
        public string typenlgpay
        {
            get { return _typenlgpay; }
            set { _typenlgpay = value; }
        }
        public string info
        {
            get { return _info; }
            set { _info = value; }
        }
        public DateTime markdate
        {
            get { return _markdate; }
            set { _markdate = value; }
        }
        public string sop
        {
            get { return _sop; }
            set { _sop = value; }
        }
        public bool spod
        {
            get { return _spod; }
            set { _spod = value; }
        }
        public bool issend
        {
            get { return _issend; }
            set { _issend = value; }
        }
        public VidDoc viddoc
        {
            get { return _viddoc; }
            set { _viddoc = value; }
        }
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string view
        {
            get
            {
                return "№" + docno + " " + debetacc.Trim() + " " + creditacc.Trim() +
                    " " + payment.ToString().PadLeft(10) + " " + description;
            }
        }
        //public static void FillCardbnew(SAADBFLib.t34DBF dbf, DateTime dt, decimal sm, int batchno, int code)
        //{
        //    object ob;
        //    dbf.Append();
        //    ob = "1";
        //    dbf.FieldPut2("chapter", ref ob);
        //    ob = batchno;
        //    dbf.FieldPut2("batchno", ref ob);
        //    ob = dt;
        //    dbf.FieldPut2("workdate", ref ob);
        //    ob = sm;
        //    dbf.FieldPut2("entry", ref ob);
        //    ob = sm;
        //    dbf.FieldPut2("comput", ref ob);
        //    ob = code;
        //    dbf.FieldPut2("code", ref ob);
        //}
        //public static void FillDbf(SAADBFLib.t34DBF batchnew, List<clsBatch> lst)
        //{
        //    object ob;
        //    foreach (clsBatch b in lst)
        //    {
        //        batchnew.Append();
        //        ob = b.chapter;
        //        batchnew.FieldPut2("chapter", ref ob);
        //        ob = b.docdate;
        //        batchnew.FieldPut2("docdate", ref ob);
        //        ob = b.workdate;
        //        batchnew.FieldPut2("workdate", ref ob);
        //        ob = b.begdate;
        //        batchnew.FieldPut2("begdate", ref ob);
        //        ob = b.dppdate;
        //        batchnew.FieldPut2("dppdate", ref ob);
        //        ob = b.group;
        //        batchnew.FieldPut2("group", ref ob);
        //        ob = b.batchno;
        //        batchnew.FieldPut2("batchno", ref ob);
        //        ob = b.docno;
        //        batchnew.FieldPut2("docno", ref ob);
        //        ob = b.payment;
        //        batchnew.FieldPut2("payment", ref ob);
        //        ob = b.cur_dpaym;
        //        batchnew.FieldPut2("cur_dpaym", ref ob);
        //        ob = b.cur_cpaym;
        //        batchnew.FieldPut2("cur_cpaym", ref ob);
        //        ob = b.opertype;
        //        batchnew.FieldPut2("opertype", ref ob);
        //        ob = b.Operator;
        //        batchnew.FieldPut2("operator", ref ob);
        //        ob = b.debetmfo;
        //        batchnew.FieldPut2("debetmfo", ref ob);
        //        ob = b.creditmfo;
        //        batchnew.FieldPut2("creditmfo", ref ob);
        //        ob = b.dbankinn;
        //        batchnew.FieldPut2("dbankinn", ref ob);
        //        ob = b.cbankinn;
        //        batchnew.FieldPut2("cbankinn", ref ob);
        //        ob = b.debetcorr;
        //        batchnew.FieldPut2("debetcorr", ref ob);
        //        ob = b.creditcorr;
        //        batchnew.FieldPut2("creditcorr", ref ob);
        //        ob = b.debetacc;
        //        batchnew.FieldPut2("debetacc", ref ob);
        //        ob = b.creditacc;
        //        batchnew.FieldPut2("creditacc", ref ob);
        //        ob = b.realdbacc;
        //        batchnew.FieldPut2("realdbacc", ref ob);
        //        ob = b.realcracc;
        //        batchnew.FieldPut2("realcracc", ref ob);
        //        ob = b.debcred;
        //        batchnew.FieldPut2("debcred", ref ob);
        //        ob = b.debetname;
        //        batchnew.FieldPut2("debetname", ref ob);
        //        ob = b.creditname;
        //        batchnew.FieldPut2("creditname", ref ob);
        //        ob = b.kass_sym;
        //        batchnew.FieldPut2("kass_sym", ref ob);
        //        ob = b.kass_sym2;
        //        batchnew.FieldPut2("kass_sym2", ref ob);
        //        ob = b.error_c;
        //        batchnew.FieldPut2("error_c", ref ob);
        //        ob = b.checks;
        //        batchnew.FieldPut2("checks", ref ob);
        //        ob = b.paysign;
        //        batchnew.FieldPut2("paysign", ref ob);
        //        ob = b.code;
        //        batchnew.FieldPut2("code", ref ob);
        //        ob = b.codepay;
        //        batchnew.FieldPut2("codepay", ref ob);

        //        ob = b.istransit;
        //        batchnew.FieldPut2("istransit", ref ob);
        //        ob = b.parent_id;
        //        batchnew.FieldPut2("parent_id", ref ob);
        //        ob = b.id;
        //        batchnew.FieldPut2("id", ref ob);
        //        ob = b.isoldcard;
        //        batchnew.FieldPut2("isoldcard", ref ob);
        //        ob = b.laccount;
        //        batchnew.FieldPut2("laccount", ref ob);
        //        ob = b.lacccred;
        //        batchnew.FieldPut2("lacccred", ref ob);
        //        ob = b.cargo;
        //        batchnew.FieldPut2("cargo", ref ob);
        //        ob = b.source;
        //        batchnew.FieldPut2("source", ref ob);
        //        ob = b.debetname;
        //        batchnew.FieldPut2("debetname", ref ob);
        //        ob = b.debet_inn;
        //        batchnew.FieldPut2("debet_inn", ref ob);
        //        ob = b.creditname;
        //        batchnew.FieldPut2("creditname", ref ob);
        //        ob = b.credit_inn;
        //        batchnew.FieldPut2("credit_inn", ref ob);
        //        ob = b.debet_kpp;
        //        batchnew.FieldPut2("debet_kpp", ref ob);
        //        ob = b.credit_kpp;
        //        batchnew.FieldPut2("credit_kpp", ref ob);
        //        ob = b.statusdrw;
        //        batchnew.FieldPut2("statusdrw", ref ob);
        //        ob = b.kbk;
        //        batchnew.FieldPut2("kbk", ref ob);
        //        ob = b.okato;
        //        batchnew.FieldPut2("okato", ref ob);
        //        ob = b.basenlgpay;
        //        batchnew.FieldPut2("basenlgpay", ref ob);
        //        ob = b.nlgperiod;
        //        batchnew.FieldPut2("nlgperiod", ref ob);
        //        ob = b.numnlgdoc;
        //        batchnew.FieldPut2("numnlgdoc", ref ob);
        //        ob = b.datenlgdoc;
        //        batchnew.FieldPut2("datenlgdoc", ref ob);
        //        ob = b.typenlgpay;
        //        batchnew.FieldPut2("typenlgpay", ref ob);
        //        ob = b.info;
        //        batchnew.FieldPut2("info", ref ob);
        //        ob = b.markdate;
        //        batchnew.FieldPut2("markdate", ref ob);
        //        ob = b.sop;
        //        batchnew.FieldPut2("sop", ref ob);
        //        ob = b.spod;
        //        batchnew.FieldPut2("spod", ref ob);
        //    }
        //}
        private bool _issend = false;
        private VidDoc _viddoc;
        private string _description = "";

        private string _chapter;	//1
        private DateTime _docdate;
        private DateTime _workdate;
        private DateTime _paydate;
        private DateTime _begdate;
        private DateTime _dppdate;
        private string _group;		//1
        private int _batchno;
        private string _docno;		//6
        private decimal _payment;
        private decimal _cur_dpaym;
        private decimal _cur_cpaym;
        private string _opertype;	//2
        private int _operator;
        private string _debetmfo;	//9
        private string _creditmfo;	//9
        private string _dbankinn;	//12
        private string _cbankinn;	//12
        private string _debetcorr;	//25
        private string _creditcorr;	//25
        private string _debetacc;	//25
        private string _creditacc;	//25
        private string _realdbacc;	//25
        private string _realcracc;	//25
        private string _kass_sym;	//2
        private string _kass_sym2;	//2
        private int _error_c;
        private string _checks;		//20
        private string _paysign;	//1
        private int _code;
        private int _codepay;
        private string _debcred;	//1
        private bool _istransit;
        private string _parent_id;	//20
        private string _id;			//20
        private bool _isoldcard;
        private string _laccount;	//25
        private string _lacccred;	//25
        private string _cargo;		//254
        private int _source;
        private string _debetname;	//160
        private string _debet_inn;	//12
        private string _creditname;	//160
        private string _credit_inn;	//12
        private string _debet_kpp;	//9
        private string _credit_kpp;	//9
        private string _statusdrw;	//2
        private string _kbk;		//20
        private string _okato;		//11
        private string _basenlgpay;	//2
        private string _nlgperiod;	//10
        private string _numnlgdoc;	//10
        private DateTime _datenlgdoc;
        private string _typenlgpay;	//2
        private string _info;		//210
        private DateTime _markdate;
        private string _sop;		//16
        private bool _spod;
    }
}
