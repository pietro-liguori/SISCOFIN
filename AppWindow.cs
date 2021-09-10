using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.CodeDom;
using System.IO.MemoryMappedFiles;
using System.Globalization;

namespace SISCOFIN_v1
{
    public partial class AppWindow : Form
    {
        public static int ListPages;
        public static bool IsFiltered = false;
        public static bool IsSorted = true;
        public static bool IsLimited = true;
        private static readonly List<CheckBox> CheckList = new List<CheckBox>();
        private static readonly List<Panel> PanelsList = new List<Panel>();
        public enum Reload
        {
            AccountDropItems = 0,
            BKACAccountPanel = 1,
            BKACCardPanel = 2,
            BKACBalancePanel = 3,
            BKACFlowPanel = 4,
            CREDBillsPanel = 5,
            CREDDetailPanel = 6
        }
        public enum Filters
        {
            CRED = 0
        }
        #region AppWindow
        public AppWindow()
        {
            InitializeComponent();
            Globals.IsRunning = true;
            Text = "SISCOFIN v" + Globals.Version;
            DataBase.Tables.Accounts = DataBase.Populate(Properties.Resources.sqlAccounts);
            DataBase.Tables.AddressBook = DataBase.Populate(Properties.Resources.sqlAddressBook);
            DataBase.Tables.Banks = DataBase.Populate(Properties.Resources.sqlBanks);
            DataBase.Tables.Cards = DataBase.Populate(Properties.Resources.sqlCards);
            DataBase.Tables.CashFlow = DataBase.Populate(Properties.Resources.sqlCashFlow);
            DataBase.Tables.CreditBills = DataBase.Populate(Properties.Resources.sqlCreditBills);
            DataBase.Tables.CreditFlow = DataBase.Populate(Properties.Resources.sqlCreditFlow);
            DataBase.Tables.Documents = DataBase.Populate(Properties.Resources.sqlDocuments);
            DataBase.Tables.EmailBook = DataBase.Populate(Properties.Resources.sqlEmailBook);
            DataBase.Tables.Groups = DataBase.Populate(Properties.Resources.sqlGroups);
            DataBase.Tables.People = DataBase.Populate(Properties.Resources.sqlPeople);
            DataBase.Tables.PhoneBook = DataBase.Populate(Properties.Resources.sqlPhoneBook);
            DataBase.Tables.Users = DataBase.Populate(Properties.Resources.sqlUsers);
            DataBase.Types.AccountClass = DataBase.Populate(Properties.Resources.sqlAccountClass);
            DataBase.Types.AccountTypes = DataBase.Populate(Properties.Resources.sqlAccountTypes);
            DataBase.Types.Branches = DataBase.Populate(Properties.Resources.sqlBranches);
            DataBase.Types.CardFlags = DataBase.Populate(Properties.Resources.sqlCardFlags);
            DataBase.Types.CardTypes = DataBase.Populate(Properties.Resources.sqlCardTypes);
            DataBase.Types.DebtCategory = DataBase.Populate(Properties.Resources.sqlDebtCategory);
            DataBase.Types.DebtSubcategories = DataBase.Populate(Properties.Resources.sqlDebtSubcategories);
            DataBase.Types.DebtSubcategory1 = DataBase.Populate(Properties.Resources.sqlDebtSubcategory1);
            DataBase.Types.DebtSubcategory2 = DataBase.Populate(Properties.Resources.sqlDebtSubcategory2);
            DataBase.Types.DebtSubcategory3 = DataBase.Populate(Properties.Resources.sqlDebtSubcategory3);
            DataBase.Types.DebtTypes = DataBase.Populate(Properties.Resources.sqlDebtTypes);
            DataBase.Types.DebtClass = DataBase.Populate(Properties.Resources.sqlDebtClass);
            DataBase.Types.DocumentTypes = DataBase.Populate(Properties.Resources.sqlDocumentTypes);
            DataBase.Types.OpperationTypes = DataBase.Populate(Properties.Resources.sqlOpperationTypes);
            DataBase.Types.Status = DataBase.Populate(Properties.Resources.sqlStatus);
            if (!DataBase.Tables.Users.Rows.Count.Equals(0))
            {
                dmTOOLAccounts.Enabled = true;
                if (DataBase.Tables.Accounts.Rows.Count > 0) dmTOOLFinAdd.Enabled = dmTOOLFinCtl.Enabled = true;
            }
            if (!DataBase.Tables.CashFlow.Rows.Count.Equals(0))
            {
                Debt.CurrentId = DataBase.Tables.CashFlow.AsEnumerable()
                    .OrderByDescending(row => row.Field<long>("Id"))
                    .Take(1).CopyToDataTable().Rows[0].Field<long>("Id");
            }
            PanelsList.Add(pnBKAC);
            PanelsList.Add(pnCFLW);
            PanelsList.Add(pnCRED);
            PanelsList.Add(pnDRAW);
            PanelsList.Add(pnFBAL);
            PanelsList.Add(pnIVST);
            PanelsList.Add(pnNDBT);
            PanelsList.Add(pnVCHS);
            PanelsList.Add(pnWLLT);
            foreach(Panel panel in PanelsList) panel.Dock = DockStyle.None;
            Populate(null, Reload.AccountDropItems);
            cbCREDAccountFilter.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbCREDAccountFilter.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbCREDCardFilter.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbCREDCardFilter.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbBKACChooseAccount.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbBKACChooseAccount.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDRAWAccount.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbDRAWAccount.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDRAWUser.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbDRAWUser.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbNDBTAccount.TextChanged += new EventHandler(NDBTAccountTextChanged);
            cbNDBTAccount.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbNDBTAccount.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbNDBTBranch.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbNDBTBranch.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbNDBTBranch.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbNDBTCard.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbNDBTCard.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbNDBTCategory.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbNDBTCategory.TextChanged += new EventHandler(NDBTCategoryTextChanged);
            cbNDBTCategory.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbNDBTCategory.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbNDBTCategory.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbNDBTItensPerPage.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbNDBTItensPerPage.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbNDBTOpperation.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbNDBTOpperation.TextChanged += new EventHandler(NDBTOpperationTextChanged);
            cbNDBTOpperation.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbNDBTOpperation.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbNDBTPerson.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbNDBTPerson.TextChanged += new EventHandler(NDBTPersonTextChanged);
            cbNDBTPerson.KeyPress += new KeyPressEventHandler(MyEvents.UpperCharChasing);
            cbNDBTPerson.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbNDBTSubcategory1.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbNDBTSubcategory1.KeyPress += new KeyPressEventHandler(MyEvents.UpperCharChasing);
            cbNDBTSubcategory1.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbNDBTSubcategory2.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbNDBTSubcategory2.KeyPress += new KeyPressEventHandler(MyEvents.UpperCharChasing);
            cbNDBTSubcategory2.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbNDBTSubcategory3.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbNDBTSubcategory3.KeyPress += new KeyPressEventHandler(MyEvents.UpperCharChasing);
            cbNDBTSubcategory3.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbNDBTClass.TextChanged += new EventHandler(NDBTTDebtClassTextChanged);
            cbNDBTClass.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbNDBTClass.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbNDBTUser.TextChanged += new EventHandler(NDBTUserTextChanged);
            cbNDBTUser.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbNDBTUser.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbWLLTChooseAccount.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbWLLTChooseAccount.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            ckCREDFilter.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            dgBKACBills.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgBKACFlow.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgCREDBills.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgCREDBills.CellMouseDown += new DataGridViewCellMouseEventHandler(CREDBillsCellMouseDown);
            dgCREDBills.KeyDown += new KeyEventHandler(CREDBillsKeyDown);
            dgCREDDetails.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgDRAWHistoric.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgNDBTList.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            tbDRAWValue.KeyDown += new KeyEventHandler(MyEvents.DecimalMask);
            tbNDBTValue.KeyDown += new KeyEventHandler(MyEvents.DecimalMask);
            pnBKACFlow.SplitterWidth = 2;
            pnBKACInfo.SplitterWidth = 2;
            pnCREDDetails.SplitterWidth = 2;
            pnCREDFilter.MaximumSize = new Size(474, 185);
            pnCREDFilter.MinimumSize = new Size(474, 35);
            pnCREDFilter.SplitterDistance = 35;
            pnCREDFilter.SplitterWidth = 1;
            Globals.IsRunning = false;
        }
        public bool Populate(DataTable dataSource, params Reload[] item)
        {
            foreach (Reload obj in item)
            {
                if (obj.Equals(Reload.AccountDropItems))
                {
                    smTOOLBank.DropDownItems.Clear();
                    smTOOLVoucher.DropDownItems.Clear();
                    smTOOLWallet.DropDownItems.Clear();
                    ToolStripItem button;
                    ToolStripMenuItem sideMenu;
                    Image btImage;
                    string btName, btText, imgName;
                    foreach (DataRow row in DataBase.Tables.Accounts.Rows)
                    {
                        btText = row.Field<string>("Name");
                        try
                        {
                            imgName = DataBase.Tables.Banks.AsEnumerable().
                                Where(bnk => bnk.Field<long>("Id").Equals(row.Field<long>("Bank"))).
                                CopyToDataTable().Rows[0].Field<string>("Image") + "_24x24";
                            btImage = (Image)Properties.Resources.ResourceManager.GetObject(imgName);
                        }
                        catch { btImage = Properties.Resources.Wallets_24x24; }
                        switch (row.Field<long>("Class"))
                        {
                            case 1:
                                sideMenu = smTOOLWallet;
                                btName = "btWLLT" + row.Field<long>("Id");
                                break;
                            case 2:
                                sideMenu = smTOOLBank;
                                btName = "btBKAC" + row.Field<long>("Id");
                                break;
                            case 3:
                                sideMenu = smTOOLVoucher;
                                btName = "btVCHR" + row.Field<long>("Id");
                                break;
                            default: continue;
                        }
                        button = sideMenu.DropDownItems.Add(btText, btImage, ShowPanel);
                        button.Name = btName;
                        button.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
                        button.ForeColor = Color.DarkGreen;
                        button.Tag = row.Field<long>("Id").ToString();
                        button.ImageScaling = ToolStripItemImageScaling.None;
                    }
                    if (smTOOLBank.DropDownItems.Count > 0) smTOOLBank.Enabled = true;
                    if (smTOOLVoucher.DropDownItems.Count > 0) smTOOLVoucher.Enabled = true;
                    if (smTOOLWallet.DropDownItems.Count > 0) smTOOLWallet.Enabled = true;
                }
                else if (obj.Equals(Reload.BKACAccountPanel))
                {
                    dataSource = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                        .CopyToDataTable();
                    lbBKACSubTitle.Text = dataSource.Rows[0].Field<string>("Name");
                    long idBank = dataSource.Rows[0].Field<long>("Bank");
                    long idType = dataSource.Rows[0].Field<long>("Type");
                    long idUser = dataSource.Rows[0].Field<long>("User");
                    long idPerson = DataBase.Tables.Banks.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idBank))
                        .CopyToDataTable().Rows[0].Field<long>("Person");
                    tbBKACBank.Text = DataBase.Tables.People.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idPerson))
                        .CopyToDataTable().Rows[0].Field<string>("Name");
                    tbBKACBankNumber.Text = DataBase.Tables.Banks.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idBank))
                        .CopyToDataTable().Rows[0].Field<string>("BankCode");
                    tbBKACAgency.Text = dataSource.Rows[0].Field<string>("Agency");
                    tbBKACAccountNumber.Text = dataSource.Rows[0].Field<string>("Account");
                    tbBKACAccountType.Text = DataBase.Types.AccountTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idType))
                        .CopyToDataTable().Rows[0].Field<string>("Name");
                    tbBKACUser.Text = DataBase.Tables.Users.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idUser))
                        .CopyToDataTable().Rows[0].Field<string>("Name");
                    tbBKACOverdraft.Text = dataSource.Rows[0].Field<decimal>("Overdraft").ToString("C");
                    tbBKACAccountFee.Text = dataSource.Rows[0].Field<decimal>("Fee").ToString("P") + " A." + dataSource.Rows[0].Field<string>("FeeUnit") + ".";
                }
                else if (obj.Equals(Reload.BKACCardPanel))
                {
                    dataSource = DataBase.Tables.Cards.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedCard))
                        .CopyToDataTable();
                    string card = dataSource.Rows[0].Field<string>("Name");
                    long idFlag = dataSource.Rows[0].Field<long>("Flag");
                    tbBKACCardNumber.Text = "****" + card.Substring(card.Length - 4, 4);
                    tbBKACCardExpiration.Text = dataSource.Rows[0].Field<DateTime>("Expiration").ToString("dd/MM/yyyy");
                    tbBKACCardFlag.Text = DataBase.Types.CardFlags.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idFlag))
                        .CopyToDataTable().Rows[0].Field<string>("Name");
                    decimal creditLimit = dataSource.Rows[0].Field<decimal>("CreditLimit");
                    tbBKACCardLimit.Text = creditLimit.ToString("C");
                    tbBKACCardFee.Text = dataSource.Rows[0].Field<decimal>("Fee").ToString("P") + " A." + dataSource.Rows[dataSource.Rows.Count - 1].Field<string>("FeeUnit").ToString() + ".";
                    string filter = "Status <> 11 AND Status <> 12 AND Status <> 14 AND Card = " + Globals.SelectedCard;
                    tbBKACCardDispLimit.Text = (creditLimit - (decimal)DataBase.Tables.CreditBills.Compute("Sum(BillValue)", filter)).ToString("C");
                    dataSource = DataBase.Populate(Properties.Resources.sql_dgBKACBills);
                    try
                    {
                        dataSource = dataSource.AsEnumerable()
                            .Where(row => row.Field<long>("Cartão").Equals(Globals.SelectedCard) &&
                                          row.Field<long>("Conta").Equals(Globals.SelectedAccount))
                            .OrderByDescending(row => row.Field<DateTime>("Vencimento"))
                            .Take(12).CopyToDataTable();
                        btBKACBills.Enabled = true;
                    }
                    catch
                    {
                        dataSource.Rows.Clear();
                        btBKACBills.Enabled = false;
                    }
                    Dictionary<string, int> dgConfig = new Dictionary<string, int>
                    {
                        { "Referência", (int)(dgBKACBills.Width * 0.3) },
                        { "Vencimento", (int)(dgBKACBills.Width * 0.2) },
                        { "Valor", (int)(dgBKACBills.Width * 0.2) },
                        { "Situação", (int)(dgBKACBills.Width * 0.3) }
                    };
                    MyMethods.DataGridViewConfig(dgBKACBills, dataSource, dgConfig, 2);
                }
                else if (obj.Equals(Reload.BKACBalancePanel))
                {
                    dataSource = DataBase.Populate(Properties.Resources.sql_dgBKACFlow).AsEnumerable()
                        .Where(row => row.Field<long>("Conta").Equals(Globals.SelectedAccount))
                        .CopyToDataTable();
                    decimal balance = dataSource.AsEnumerable()
                        .OrderByDescending(row => row.Field<long>("Id")).Take(1)
                        .CopyToDataTable().Rows[0].Field<decimal>("DecSaldo");
                    tbBKACAccountBalance.Text = balance.ToString("C");
                    tbBKACDispBalance.Text = (balance + decimal.Parse(tbBKACOverdraft.Text.Substring(3))).ToString("C");
                }
                else if (obj.Equals(Reload.BKACFlowPanel))
                {
                    dataSource = DataBase.Populate(Properties.Resources.sql_dgBKACFlow);
                    DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    DateTime endDate = startDate.AddMonths(1).AddDays(-1);
                    try
                    {
                        dataSource = dataSource.AsEnumerable()
                            .Where(row => !row.Field<long>("Operação").Equals(0) &&
                                          !row.Field<long>("Operação").Equals(4) &&
                                          row.Field<long>("Conta").Equals(Globals.SelectedAccount))
                            .OrderByDescending(row => row.Field<long>("Id"))
                            .CopyToDataTable();
                        DateTime minDate = dataSource.Rows[dataSource.Rows.Count - 1].Field<DateTime>("Data");
                        DateTime maxDate = dataSource.Rows[0].Field<DateTime>("Data");
                        startDate = new DateTime(maxDate.Year, maxDate.Month, 1);
                        endDate = startDate.AddMonths(1).AddDays(-1);
                    }
                    catch { }
                    dpBKACFlowStart.Value = startDate;
                    dpBKACFlowEnd.Value = endDate;
                    try
                    {
                        dataSource = dataSource.AsEnumerable()
                            .Where(row => !row.Field<long>("Operação").Equals(0) &&
                                          !row.Field<long>("Operação").Equals(4) &&
                                          row.Field<long>("Conta").Equals(Globals.SelectedAccount) &&
                                          row.Field<DateTime>("Data").CompareTo(startDate) >= 0 &&
                                          row.Field<DateTime>("Data").CompareTo(endDate) <= 0)
                            .OrderByDescending(row => row.Field<long>("Id"))
                            .CopyToDataTable();
                        decimal periodBalance = (decimal)dataSource.Compute("Sum(DecValor)", "");
                        tbBKACPeriodBalance.Text = periodBalance.ToString("C");
                        Color color;
                        switch (periodBalance.CompareTo(0))
                        {
                            case -1:
                                color = Color.Red;
                                break;
                            case 1:
                                color = Color.Blue;
                                break;
                            default:
                                color = Color.Black;
                                break;
                        }
                        tbBKACPeriodBalance.ForeColor = color;
                    }
                    catch
                    {
                        dataSource.Rows.Clear();
                        tbBKACPeriodBalance.Text = 0.ToString("C");
                        tbBKACPeriodBalance.ForeColor = Color.Black;
                    }
                    Dictionary<string, int> dgConfig = new Dictionary<string, int>
                    {
                        { "Data", (int)(dgBKACFlow.Width * 0.1) },
                        { "Beneficiário/Pagador", (int)(dgBKACFlow.Width * 0.6) },
                        { "Valor", (int)(dgBKACFlow.Width * 0.15) },
                        { "Saldo", (int)(dgBKACFlow.Width * 0.15) }
                    };
                    MyMethods.DataGridViewConfig(dgBKACFlow, dataSource, dgConfig, 2);
                }
                else if (obj.Equals(Reload.CREDBillsPanel))
                {
                    Dictionary<string, int> dgConfig = new Dictionary<string, int>
                    {
                        { "Descrição", (int)(dgCREDBills.Width * 0.4) },
                        { "Vencimento", (int)(dgCREDBills.Width * 0.2) },
                        { "Valor", (int)(dgCREDBills.Width * 0.2) },
                        { "Situação", (int)(dgCREDBills.Width * 0.2) }
                    };
                    MyMethods.DataGridViewConfig(dgCREDBills, dataSource, dgConfig, 2);
                    if (dgCREDBills.RowCount.Equals(0)) return true;
                    foreach (DataGridViewRow dataRow in dgCREDBills.Rows)
                    {
                        if (dataRow.Cells["Vencimento"].Value != null)
                        {
                            long sts = DataBase.Types.Status.AsEnumerable()
                                .Where(row => row["FName"].Equals(dataRow.Cells["Situação"].Value))
                                .CopyToDataTable().Rows[0].Field<long>("Id");
                            if (sts.Equals(1) || sts.Equals(7) || sts.Equals(15))
                            {
                                Globals.SelectedIndex = dataRow.Index;
                                int month = DateTime.Parse(dataRow.Cells["Vencimento"].Value.ToString()).Month;
                                int year = DateTime.Parse(dataRow.Cells["Vencimento"].Value.ToString()).Year;
                                if (month <= DateTime.Today.Month && year <= DateTime.Today.Year) break;
                            }
                        }
                    }
                }
                else if (obj.Equals(Reload.CREDDetailPanel))
                {
                    long idBill = (long)dgCREDBills.Rows[Globals.SelectedIndex].Cells["Id"].Value;
                    string imageSize = imCREDAccountLogo.Size.Width.ToString() + "x" + imCREDAccountLogo.Size.Height.ToString();
                    long idCard = DataBase.Tables.CreditBills.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idBill))
                        .CopyToDataTable().Rows[0].Field<long>("Card");
                    long idAccount = DataBase.Tables.CreditBills.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idBill))
                        .CopyToDataTable().Rows[0].Field<long>("Account");
                    long idBank = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idAccount))
                        .CopyToDataTable().Rows[0].Field<long>("Bank");
                    long idUser = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idAccount))
                        .CopyToDataTable().Rows[0].Field<long>("User");
                    long idPerson = DataBase.Tables.Banks.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idBank))
                        .CopyToDataTable().Rows[0].Field<long>("Person");
                    string image = DataBase.Tables.Banks.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idBank))
                        .CopyToDataTable().Rows[0].Field<string>("Image") + "_" + imageSize;
                    string status = dgCREDBills.Rows[Globals.SelectedIndex].Cells["Situação"].Value.ToString();
                    string user = DataBase.Tables.Users.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idUser))
                        .CopyToDataTable().Rows[0].Field<string>("Name");
                    string account = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idAccount))
                        .CopyToDataTable().Rows[0].Field<string>("Name");
                    string bank = DataBase.Tables.People.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idPerson))
                        .CopyToDataTable().Rows[0].Field<string>("Name");
                    string card = DataBase.Tables.Cards.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idCard))
                        .CopyToDataTable().Rows[0].Field<string>("Name");
                    card = "****" + card.Substring(card.Length - 4, 4);
                    string desc = DataBase.Tables.CreditBills.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idBill))
                        .CopyToDataTable().Rows[0].Field<string>("BillDescription");
                    string dueDate = Convert.ToDateTime(dgCREDBills.Rows[Globals.SelectedIndex].Cells["Vencimento"].Value).ToString("dd/MM/yyyy");
                    string value = dgCREDBills.Rows[Globals.SelectedIndex].Cells["Valor"].Value.ToString();
                    string paid = "R$ 0,00";
                    string payDate = string.Empty;
                    string closeDate = string.Empty;
                    try
                    {
                        paid = DataBase.Tables.CreditBills.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idBill))
                        .CopyToDataTable().Rows[0].Field<decimal>("PaidValue").ToString("C");
                    }
                    catch { }
                    try
                    {
                        closeDate = DataBase.Tables.CreditBills.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idBill))
                        .CopyToDataTable().Rows[0].Field<DateTime>("ClosingDate").ToString("dd/MM/yyyy");
                    }
                    catch
                    {
                        closeDate = DataBase.Tables.Cards.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idCard))
                        .CopyToDataTable().Rows[0].Field<long>("ClosingDay")
                        + "/" + Convert.ToDateTime(dgCREDBills.Rows[Globals.SelectedIndex].Cells["Vencimento"].Value).ToString("MM/yyyy");
                    }
                    try
                    {
                        payDate = DataBase.Tables.CreditBills.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idBill))
                        .CopyToDataTable().Rows[0].Field<DateTime>("PayDate").ToString("dd/MM/yyyy");
                        lbCREDPayDate.Visible = true;
                    }
                    catch { lbCREDPayDate.Visible = false; }
                    if (!paid.Equals("R$ 0,00")) lbCREDPaidValue.Visible = true;
                    else
                    {
                        paid = string.Empty;
                        lbCREDPaidValue.Visible = false;
                    }
                    imCREDAccountLogo.Image = (Image)Properties.Resources.ResourceManager.GetObject(image);
                    tbCREDPayDate.Text = payDate;
                    tbCREDCloseDate.Text = closeDate;
                    tbCREDBillAccount.Text = account;
                    tbCREDBillBank.Text = bank;
                    tbCREDBillDescription.Text = desc;
                    tbCREDBillUser.Text = user;
                    tbCREDBillCard.Text = card;
                    tbCREDBillStatus.Text = status;
                    tbCREDPaidValue.Text = paid;
                    lbCREDCellValue.Text = value;
                    lbCREDCellDue.Text = dueDate;
                    if (status.StartsWith("P")) btCREDPayBill.Enabled = false;
                    else btCREDPayBill.Enabled = true;
                    if (status.StartsWith("A")) btCREDPayBill.Text = "Fechar Fatura";
                    else btCREDPayBill.Text = "Pagar Fatura";
                    if (status.StartsWith("V"))
                    {
                        tbCREDBillStatus.ForeColor = Color.Red;
                        lbCREDCellDue.ForeColor = Color.Red;
                    }
                    else
                    {
                        tbCREDBillStatus.ForeColor = Color.Black;
                        lbCREDCellDue.ForeColor = Color.Black;
                    }
                    dataSource = DataBase.Populate(Properties.Resources.sql_dgCREDDetails).AsEnumerable()
                        .Where(row => row.Field<long>("Fatura").Equals(idBill))
                        .CopyToDataTable();
                    Dictionary<string, int> dgConfig = new Dictionary<string, int>
                    {
                        {"Descrição", (int)(dgCREDDetails.Width * 0.6)},
                        {"Parcela", (int)(dgCREDDetails.Width * 0.1)},
                        {"Valor", (int)(dgCREDDetails.Width * 0.3)}
                    };
                    MyMethods.DataGridViewConfig(dgCREDDetails, dataSource, dgConfig, 2);
                    dgCREDBills.Rows[Globals.SelectedIndex].Selected = true;
                }
                else return true;
            }
            return false;
        }
        public DataTable Filter(Filters filter, DataTable filterSource)
        {
            if (filter.Equals(Filters.CRED))
            {
                ckCREDFilter.Checked = true;
                pnCREDFilter.Panel2Collapsed = false;
                pnCREDFilter.Size = pnCREDFilter.MaximumSize;
                if (!Globals.SelectedAccount.Equals(-1))
                {
                    cbCREDCardFilter.Enabled = true;
                    try
                    {
                        filterSource = filterSource.AsEnumerable()
                            .Where(row => ((long)row["Account"]).Equals(Globals.SelectedAccount))
                            .CopyToDataTable();
                        cbCREDAccountFilter.SelectedValue = Globals.SelectedAccount;
                    }
                    catch { goto NoMatch; }
                }
                if (!Globals.SelectedCard.Equals(-1))
                {
                    try
                    {
                        filterSource = filterSource.AsEnumerable()
                            .Where(row => ((long)row["Card"]).Equals(Globals.SelectedCard))
                            .CopyToDataTable();
                        cbCREDCardFilter.SelectedValue = Globals.SelectedCard;
                    }
                    catch { goto NoMatch; }
                }
                if (dpCREDStartFilter.Checked)
                {
                    try
                    {
                        filterSource = filterSource.AsEnumerable()
                            .Where(row => ((DateTime)row["DueDate"]).CompareTo(dpCREDStartFilter.Value) >= 0)
                            .CopyToDataTable();
                    }
                    catch { goto NoMatch; }
                }
                if (dpCREDEndFilter.Checked)
                {
                    try
                    {
                        filterSource = filterSource.AsEnumerable()
                            .Where(row => ((DateTime)row["DueDate"]).CompareTo(dpCREDEndFilter.Value) <= 0)
                            .CopyToDataTable();
                    }
                    catch { goto NoMatch; }
                }
                foreach (CheckBox ck in CheckList)
                {
                    if (!ck.Checked)
                    {
                        try
                        {
                            filterSource = filterSource.AsEnumerable()
                                .Where(row => !((long)row["Status"]).Equals(long.Parse(ck.Tag.ToString())))
                                .CopyToDataTable();
                        }
                        catch { goto NoMatch; }
                    }
                }
                return filterSource;
            NoMatch:
                MessageBox.Show("Nenhum registro encontrado para os filtros aplicados.");
                filterSource = DataBase.Tables.CreditBills.Copy();
                cbCREDAccountFilter.SelectedIndex = -1;
                cbCREDCardFilter.SelectedIndex = -1;
                cbCREDCardFilter.Enabled = false;
                CheckList.Clear();
                CheckList.Add(ckCREDStatusClosed);
                CheckList.Add(ckCREDStatusOpen);
                CheckList.Add(ckCREDStatusPaid);
                CheckList.Add(ckCREDStatusOverdue);
                CheckList.Add(ckCREDStatusPaidLess);
                CheckList.Add(ckCREDStatusParceled);
                foreach (CheckBox ck1 in CheckList) ck1.Checked = true;
                dpCREDEndFilter.Checked = false;
                dpCREDStartFilter.Checked = false;
                return filterSource;
            }
            else return null;
        }
        public DataTable Sort(DataTable sortData, string sortKey = "Id", bool sortOrder = true)
        {
            switch (sortOrder)
            {
                case true:
                    try
                    {
                        sortData = sortData.AsEnumerable()
                            .OrderBy(row => row[sortKey])
                            .CopyToDataTable();
                    }
                    catch { }
                    break;
                case false:
                    try
                    {
                        sortData = sortData.AsEnumerable()
                            .OrderByDescending(row => row[sortKey])
                            .CopyToDataTable();
                    }
                    catch { }
                    break;
            }
            return sortData;
        }
        public DataTable Take(DataTable dataSource, int maxRows = 50)
        {
            try { dataSource = dataSource.AsEnumerable().Take(maxRows).CopyToDataTable(); }
            catch { }
            return dataSource;
        }
        private void AccountManagerClick(object sender, EventArgs e)
        {
            Globals.SelectedAccount = -1;
            Globals.SelectedCard = -1;
            AccountManager accountManager = new AccountManager(0);
            accountManager.ShowDialog();
            Populate(null, Reload.AccountDropItems);
        }
        private void CardManagerClick(object sender, EventArgs e)
        {
            Globals.SelectedAccount = -1;
            Globals.SelectedCard = -1;
            CardManager cardManager = new CardManager(0);
            cardManager.ShowDialog();
        }
        private void CheckBills()
        {
            Dictionary<int, long> toCloseBills = new Dictionary<int, long>();
            Dictionary<int, long> expiredBills = new Dictionary<int, long>();
            try
            {
                DataTable billData = DataBase.Populate(Properties.Resources.sqlCheckBills);
                int i = 0;
                foreach (DataRow row in billData.Rows)
                {
                    long status = row.Field<long>("Status");
                    DateTime closingDate = DateTime.Parse(row.Field<long>("ClosingDay") + "/" + DateTime.Today.ToString("MM/yyyy"));
                    if (status.Equals(1) && closingDate.CompareTo(DateTime.Today) < 0) toCloseBills.Add(i, row.Field<long>("Id"));
                    if (status.Equals(15)) expiredBills.Add(i, row.Field<long>("Id"));
                    i++;
                }
                if (expiredBills.Count > 0) MessageBox.Show("Existem faturas de cartão de crédito vencidas.\nVerifique se o pagamento já foi feito.", "ATENÇÃO!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (toCloseBills.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Existem faturas de cartão de crédito abertas com fechamento previsto.\nDeseja realizar o fechamento das faturas agora?", "ATENÇÃO!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult.Equals(DialogResult.Yes))
                    {
                        CloseCreditBills newWindow = new CloseCreditBills(toCloseBills, billData);
                        newWindow.ShowDialog();
                    }
                }
            }
            catch { }
        }
        private void ClosePanel(object sender, EventArgs e)
        {
            int panelIndex = -1;
            if (sender.GetType().Equals(typeof(ToolStripButton)))
            {
                ToolStripButton ts = (ToolStripButton)sender;
                panelIndex = Controls.IndexOfKey("pn" + ts.Name.Substring(2, 4));
            }
            else if (sender.GetType().Equals(typeof(Button)))
            {
                Button bt = (Button)sender;
                panelIndex = Controls.IndexOfKey("pn" + bt.Name.Substring(2, 4));
            }
            Panel panel = (Panel)Controls[panelIndex];
            Globals.SelectedIndex = -1;
            Globals.SelectedAccount = -1;
            Globals.SelectedCard = -1;
            Globals.SelectedPerson = -1;
            Globals.SelectedUser = -1;
            panel.Visible = false;
            panel.Dock = DockStyle.None;
            panel.Location = new Point(0, 1000);
        }
        private void CreditBillsDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in (sender as DataGridView).Rows)
            {
                string txt = row.Cells["Situação"].Value.ToString();
                if (txt.Equals("VENCIDA"))
                {
                    row.DefaultCellStyle.SelectionForeColor = row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }
        private void PeopleManagerClick(object sender, EventArgs e)
        {
            Globals.SelectedPerson = -1;
            Globals.SelectedUser = -1;
            PeopleManager peopleManager = new PeopleManager(0);
            peopleManager.ShowDialog();
            Populate(null, Reload.AccountDropItems);
        }
        private void SettingsClick(object sender, EventArgs e)
        {
            DataSettings dataSettings = new DataSettings();
            dataSettings.ShowDialog();
        }
        private void Setup(Panel panel, int mode = 0)
        {
            DataTable dataSource = null;
            if (panel.Equals(pnBKAC)) 
            {
                int index = ((string)btBKACBills.Tag).IndexOf(";");
                btBKACBills.Tag = Globals.SelectedAccount + ((string)btBKACBills.Tag).Substring(index);
                if (!DataBase.Tables.Accounts.Rows.Count.Equals(0))
                {
                    try
                    {
                        dataSource = DataBase.Tables.Accounts.AsEnumerable()
                            .Where(row => row.Field<long>("Class").Equals(2))
                            .OrderBy(row => row.Field<long>("Id")).CopyToDataTable();
                        cbBKACChooseAccount.DataSource = dataSource;
                        cbBKACChooseAccount.DisplayMember = "Name";
                        cbBKACChooseAccount.ValueMember = "Id";
                    }
                    catch { }
                }
                Populate(null, Reload.BKACAccountPanel);
                Globals.SelectedCard = dataSource.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                    .CopyToDataTable().Rows[0].Field<long>("StandardCard");
                if (Globals.SelectedCard.Equals(0))
                {
                    try
                    {
                        Globals.SelectedCard = DataBase.Tables.Cards.AsEnumerable()
                        .Where(row => row.Field<long>("Account").Equals(Globals.SelectedAccount))
                        .OrderByDescending(row => row["Id"]).Take(1)
                        .CopyToDataTable().Rows[0].Field<long>("Card");
                        btBKACNextCard.Enabled = true;
                        btBKACPreviousCard.Enabled = true;
                    }
                    catch 
                    {
                        btBKACNextCard.Enabled = false;
                        btBKACPreviousCard.Enabled = false;
                        goto NoCards; 
                    }
                }
                else
                {
                    btBKACNextCard.Enabled = true;
                    btBKACPreviousCard.Enabled = true;
                }
                Populate(null, Reload.BKACCardPanel);
            NoCards:
                Populate(null, Reload.BKACBalancePanel, Reload.BKACFlowPanel);
                dpBKACFlowStart.Select();
                return;
            }
            if (panel.Equals(pnCFLW))
            {
                return;
            }
            if (panel.Equals(pnCRED))
            {
                Debt.Clear();
                if (mode.Equals(0))
                {
                    if (!DataBase.Tables.Accounts.Rows.Count.Equals(0))
                    {
                        try
                        {
                            dataSource = DataBase.Tables.Accounts.AsEnumerable()
                                .Where(row => row.Field<long>("Class").Equals(2))
                                .OrderBy(row => row.Field<long>("Id")).CopyToDataTable();
                            cbCREDAccountFilter.DataSource = dataSource;
                            cbCREDAccountFilter.DisplayMember = "Name";
                            cbCREDAccountFilter.ValueMember = "Id";
                            cbCREDAccountFilter.SelectedIndex = -1;
                        }
                        catch { }
                    }
                    SortedDictionary<long, string> creditCards = new SortedDictionary<long, string>();
                    var creditCardList = from cards in DataBase.Tables.Cards.AsEnumerable()
                                         join cardTypes in DataBase.Types.CardTypes.AsEnumerable()
                                         on (long)cards["Type"] equals (long)cardTypes["Id"]
                                         where ((string)cardTypes["Opperation"]).Split(char.Parse(";")).Contains("4")
                                         select new
                                         {
                                             Id = (long)cards["Id"],
                                             Card = (string)cards["Name"],
                                             Opperation = (string)cardTypes["Opperation"]
                                         };
                    for (int i = 0; i < creditCardList.Count(); i++)
                    {
                        string maskedCard = creditCardList.ToList()[i].Card;
                        creditCards.Add(creditCardList.ToList()[i].Id, "****" + maskedCard.Substring(maskedCard.Length - 4, 4));
                    }
                    if (!creditCards.Count.Equals(0))
                    {
                        cbCREDCardFilter.DataSource = new BindingSource(creditCards, null);
                        cbCREDCardFilter.DisplayMember = "Value";
                        cbCREDCardFilter.ValueMember = "Key";
                        cbCREDCardFilter.SelectedIndex = -1;
                    }
                }
                bool collapse = !ckCREDFilter.Checked;
                dataSource = DataBase.Populate(Properties.Resources.sql_dgCREDBills);
                dataSource = Sort(dataSource, "Vencimento", false);
                DataTable filterSource = DataBase.Tables.CreditBills.Copy();
                if (IsFiltered) filterSource = Filter(Filters.CRED, filterSource);
                else
                {
                    cbCREDAccountFilter.SelectedValue = Globals.SelectedAccount;
                    cbCREDCardFilter.SelectedValue = Globals.SelectedCard;
                    ckCREDFilter.Checked = !collapse;
                    pnCREDFilter.Panel2Collapsed = collapse;
                    if (collapse) pnCREDFilter.Size = pnCREDFilter.MinimumSize;
                    else pnCREDFilter.Size = pnCREDFilter.MaximumSize;
                    CheckList.Clear();
                    CheckList.Add(ckCREDStatusClosed);
                    CheckList.Add(ckCREDStatusOpen);
                    CheckList.Add(ckCREDStatusPaid);
                    CheckList.Add(ckCREDStatusOverdue);
                    CheckList.Add(ckCREDStatusPaidLess);
                    CheckList.Add(ckCREDStatusParceled);
                    foreach (CheckBox ck in CheckList) ck.Checked = true;
                    dpCREDEndFilter.Value = DateTime.Today;
                    dpCREDEndFilter.Checked = false;
                    dpCREDStartFilter.Value = DateTime.Parse("01/01/2018");
                    dpCREDStartFilter.Checked = false;
                }
                if (IsSorted) filterSource = Sort(filterSource, "DueDate", false);
                if (IsLimited) filterSource = Take(filterSource, 20);
                foreach (DataRow dataRow in dataSource.Rows)
                {
                    int rowCount = 0;
                    rowCount = filterSource.AsEnumerable()
                        .Where(filterRow => filterRow["Id"].Equals(dataRow["Id"]))
                        .Count();
                    if (rowCount.Equals(1)) continue;
                    dataRow.Delete();
                }
                dataSource.AcceptChanges();
                Globals.SelectedIndex = 0;
                bool exit = Populate(dataSource, Reload.CREDBillsPanel);
                if (exit) return;
                Populate(null, Reload.CREDDetailPanel);
            }
            if (panel.Equals(pnDRAW))
            {
                Debt.Clear();
                if (!DataBase.Tables.Accounts.Rows.Count.Equals(0))
                {
                    try
                    {
                        dataSource = DataBase.Tables.Accounts.AsEnumerable()
                            .Where(row => row.Field<long>("Class").Equals(2))
                            .OrderBy(row => row.Field<long>("Id")).CopyToDataTable();
                        cbDRAWAccount.DataSource = dataSource;
                        cbDRAWAccount.DisplayMember = "Name";
                        cbDRAWAccount.ValueMember = "Id";
                        cbDRAWAccount.SelectedIndex = -1;
                    }
                    catch { }
                }
                if (!DataBase.Tables.Users.Rows.Count.Equals(0))
                {
                    var userList = from users in DataBase.Tables.Users.AsEnumerable()
                                   join people in DataBase.Tables.People.AsEnumerable()
                                   on (long)users["Person"] equals (long)people["Id"]
                                   orderby people["Name"]
                                   select new
                                   {
                                       Id = (long)users["Id"],
                                       Name = (string)people["Name"]
                                   };
                    cbDRAWUser.DataSource = userList.ToList();
                    cbDRAWUser.DisplayMember = "Name";
                    cbDRAWUser.ValueMember = "Id";
                    cbDRAWUser.SelectedIndex = -1;
                }
                DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                DateTime endDate = startDate.AddMonths(1).AddDays(-1);
                dataSource = DataBase.Populate(Properties.Resources.sql_dgDRAWHistoric);
                try
                {
                    dataSource = dataSource.AsEnumerable()
                    .Where(row => row.Field<long>("IdOperação").Equals(10) &&
                            row.Field<DateTime>("Data").CompareTo(startDate) >= 0 &&
                            row.Field<DateTime>("Data").CompareTo(endDate) <= 0)
                    .OrderByDescending(row => row["Data"])
                    .ThenByDescending(row => row["Id"])
                    .CopyToDataTable();
                }
                catch
                {
                    try
                    {
                        dataSource = dataSource.AsEnumerable()
                        .Where(row => row.Field<long>("IdOperação").Equals(10))
                        .OrderByDescending(row => row.Field<DateTime>("Data"))
                        .ThenByDescending(row => row["Id"]).Take(25)
                        .CopyToDataTable();
                    }
                    catch { dataSource.Rows.Clear(); }
                }
                Dictionary<string, int> dgConfig = new Dictionary<string, int>
                {
                    { "Data", (int)(dgDRAWHistoric.Width * 0.2) },
                    { "Conta", (int)(dgDRAWHistoric.Width * 0.6) },
                    { "Valor", (int)(dgDRAWHistoric.Width * 0.2) }
                };
                MyMethods.DataGridViewConfig(dgDRAWHistoric, dataSource, dgConfig, 2);
                dpDRAWStart.Value = startDate;
                dpDRAWEnd.Value = endDate;
                Debt.Card = 0;
                Debt.Category = 1;
                Debt.Subcategory1 = 1;
                Debt.Opperation = 11;
                Debt.Parcels = 1;
                Debt.DebtClass = 2;
                Debt.Description = "SAQUE EM DINHEIRO";
                tbDRAWValue.Text = "0,00";
                mbDRAWDate.Text = string.Empty;
                mbDRAWDate.Select();
                return;
            }
            if (panel.Equals(pnFBAL))
            {
                return;
            }
            if (panel.Equals(pnIVST))
            {
                return;
            }
            if (panel.Equals(pnNDBT))
            {
                double nPages = 1;
                Debt.Clear();
                Person.Clear();
                User.Clear();
                cbNDBTAccount.DataSource = null;
                cbNDBTAccount.Enabled = false;
                cbNDBTBranch.DataSource = null;
                cbNDBTBranch.Enabled = false;
                cbNDBTCard.DataSource = null;
                cbNDBTCard.Enabled = false;
                cbNDBTCategory.DataSource = null;
                cbNDBTOpperation.DataSource = null;
                cbNDBTOpperation.Enabled = false;
                cbNDBTPerson.DataSource = null;
                cbNDBTSubcategory1.DataSource = null;
                cbNDBTSubcategory1.Enabled = false;
                cbNDBTSubcategory2.DataSource = null;
                cbNDBTSubcategory2.Enabled = false;
                cbNDBTSubcategory3.DataSource = null;
                cbNDBTSubcategory3.Enabled = false;
                cbNDBTClass.DataSource = null;
                cbNDBTClass.Enabled = false;
                cbNDBTUser.DataSource = null;
                dgNDBTList.DataSource = null;
                udNDBTParcels.Enabled = false;
                if (panel.Dock.Equals(DockStyle.Fill))
                {
                    dataSource = DataBase.Types.Branches.AsEnumerable()
                        .OrderBy(row => row.Field<string>("Name")).CopyToDataTable();
                    cbNDBTBranch.DataSource = dataSource;
                    cbNDBTBranch.DisplayMember = "Name";
                    cbNDBTBranch.ValueMember = "Id";
                    cbNDBTBranch.SelectedIndex = -1;
                    cbNDBTCard.SelectedIndex = -1;
                    dataSource = DataBase.Types.DebtCategory.AsEnumerable()
                        .Where(row => row.Field<bool>("EnableSelection"))
                        .OrderBy(row => row.Field<string>("Name"))
                        .CopyToDataTable();
                    cbNDBTCategory.DataSource = dataSource;
                    cbNDBTCategory.DisplayMember = "Name";
                    cbNDBTCategory.ValueMember = "Id";
                    cbNDBTCategory.SelectedIndex = -1;
                    cbNDBTPerson.DataSource = DataBase.Tables.People.AsEnumerable()
                        .Where(row => !row.Field<long>("Id").Equals(0))
                        .OrderBy(row => row.Field<string>("Name")).CopyToDataTable();
                    cbNDBTPerson.DisplayMember = "Name";
                    cbNDBTPerson.ValueMember = "Id";
                    cbNDBTPerson.SelectedIndex = -1;
                    cbNDBTClass.DataSource = DataBase.Types.DebtClass.AsEnumerable()
                        .OrderBy(row => row.Field<string>("Name")).CopyToDataTable();
                    cbNDBTClass.DisplayMember = "Name";
                    cbNDBTClass.ValueMember = "Id";
                    cbNDBTClass.SelectedIndex = -1;
                    var userList = from users in DataBase.Tables.Users.AsEnumerable()
                                   join people in DataBase.Tables.People.AsEnumerable()
                                   on (long)users["Person"] equals (long)people["Id"]
                                   orderby people["Name"]
                                   select new
                                   {
                                       Id = (long)users["Id"],
                                       Name = (string)people["Name"]
                                   };
                    cbNDBTUser.DataSource = userList.ToList();
                    cbNDBTUser.DisplayMember = "Name";
                    cbNDBTUser.ValueMember = "Id";
                    cbNDBTUser.SelectedIndex = -1;
                    dataSource = DataBase.Populate(Properties.Resources.sql_dgNDBTList);
                    try
                    {
                        dataSource = dataSource.AsEnumerable()
                            .Where(row => !row.Field<long>("IdOperação").Equals(0) &&
                                   !row.Field<long>("IdOperação").Equals(4))
                            .OrderByDescending(row => row.Field<long>("Id"))
                            .ThenByDescending(row => row.Field<DateTime>("Data"))
                            .Take(int.Parse(cbNDBTItensPerPage.Text))
                            .CopyToDataTable();
                    }
                    catch { dataSource.Rows.Clear(); }
                    Dictionary<string, int> dgConfig = new Dictionary<string, int>
                    {
                        { "Data", (int)(dgNDBTList.Width * 0.1) },
                        { "Beneficiário/Pagador", (int)(dgNDBTList.Width * 0.5) },
                        { "Operação", (int)(dgNDBTList.Width * 0.15) },
                        { "Conta", (int)(dgNDBTList.Width * 0.15) },
                        { "Valor", (int)(dgNDBTList.Width * 0.1) }
                    };
                    MyMethods.DataGridViewConfig(dgNDBTList, dataSource, dgConfig, 2);
                    if (!Debt.CurrentId.Equals(-1)) nPages = (double)Debt.CurrentId / int.Parse(cbNDBTItensPerPage.Text);
                    ListPages = (int)Math.Ceiling(nPages);
                }
                cbNDBTAccount.SelectedIndex = -1;
                cbNDBTBranch.SelectedIndex = -1;
                cbNDBTCard.SelectedIndex = -1;
                cbNDBTCategory.SelectedIndex = -1;
                cbNDBTItensPerPage.SelectedIndex = 0;
                cbNDBTOpperation.SelectedIndex = -1;
                cbNDBTPerson.SelectedIndex = -1;
                cbNDBTSubcategory1.Text = "(SELECIONE A CATEGORIA)";
                cbNDBTSubcategory2.Text = "(SELECIONE A SUBCATEGORIA 1)";
                cbNDBTSubcategory3.Text = "(SELECIONE A SUBCATEGORIA 2)";
                cbNDBTClass.SelectedIndex = -1;
                cbNDBTUser.SelectedIndex = -1;
                mbNDBTDate.Text = string.Empty;
                tbNDBTDescription.Text = string.Empty;
                tbNDBTObservation.Text = string.Empty;
                tbNDBTPage.Text = "1";
                tbNDBTValue.Text = "0,00";
                udNDBTParcels.Value = 1;
                Debt.HasChanges = false;
                return;
            }
            if (panel.Equals(pnVCHS))
            {
                return;
            }
            if (panel.Equals(pnWLLT))
            {
                return;
            }
        }
        private void ShowPanel(object sender, EventArgs e)
        {
            /** Evento ShowPanel
            *   - recebe o objeto 'sender'
            *   - recebe os argumentos de evento 'e'
            *
            *   Evento Click para os botões diversos.
            *   Desoculta o painel associado ao botão e oculta os outros painéis.
            */
            int panelIndex = -1;
            string panelName = string.Empty;
            IsFiltered = false;
            IsSorted = true;
            IsLimited = true;
            if (sender.GetType().Equals(typeof(ToolStripMenuItem)))
            {
                ToolStripMenuItem ts = (ToolStripMenuItem)sender;
                panelIndex = Controls.IndexOfKey("pn" + ts.Name.Substring(2, 4));
                if (ts.Tag != null)
                {
                    Globals.SelectedAccount = long.Parse(((string)ts.Tag).Split(char.Parse(";"))[0]);
                    try { panelName = ((string)ts.Tag).Split(char.Parse(";"))[1]; }
                    catch { }
                }
            }
            else if (sender.GetType().Equals(typeof(Button)))
            {
                Button bt = (Button)sender;
                panelIndex = Controls.IndexOfKey("pn" + bt.Name.Substring(2, 4));
                if (bt.Name.Equals("btBKACBills")) IsFiltered = true;
                if (bt.Tag != null)
                {
                    if (long.TryParse(((string)bt.Tag).Split(char.Parse(";"))[0], out long result))
                    {
                        Globals.SelectedAccount = result;
                    }
                    try { panelName = "pn" + ((string)bt.Tag).Split(char.Parse(";"))[1]; }
                    catch { }
                }
            }
            if (panelIndex.Equals(-1)) return;
            Panel panel;
            if (string.IsNullOrWhiteSpace(panelName)) panel = (Panel)Controls[panelIndex];
            else panel = (Panel)Controls[panelName];
            for (int i = 0; i < PanelsList.Count; i++)
            {
                if (PanelsList[i].Name.Substring(2, 4).Equals(panel.Name.Substring(2, 4)))
                {
                    PanelsList[i].Dock = DockStyle.Fill;
                    PanelsList[i].Visible = true;
                    if (PanelsList[i].Equals(pnCRED)) CheckBills();
                }
                else
                {
                    PanelsList[i].Visible = false;
                    PanelsList[i].Dock = DockStyle.None;
                    PanelsList[i].Location = new Point(0, 1000);
                }
            }
        }
        private void UserManagerClick(object sender, EventArgs e)
        {
            Globals.SelectedPerson = -1;
            Globals.SelectedUser = -1;
            UserManager userManager = new UserManager(0);
            userManager.ShowDialog();
            Populate(null, Reload.AccountDropItems);
        }
        #endregion
        #region Painel pnBKAC
        private void BKACDockChanged(object sender, EventArgs e)
        {
            Panel me = (Panel)sender;
            if (me.Dock.Equals(DockStyle.Fill))
            {
                Globals.IsRunning = true;
                SuspendLayout();
                Setup(me);
                Globals.IsError = false;
                Globals.IsRunning = false;
                ResumeLayout(false);
                PerformLayout();
            }
        }
        private void BKACEditAccountClick(object sender, EventArgs e)
        {
            long account = Globals.SelectedAccount;
            long card = Globals.SelectedCard;
            AccountManager accountManager = new AccountManager(1);
            accountManager.ShowDialog();
            Populate(null, Reload.AccountDropItems);
            Globals.SelectedAccount = account;
            Globals.SelectedCard = card;
        }
        private void BKACEditCardClick(object sender, EventArgs e)
        {
            long account = Globals.SelectedAccount;
            long card = Globals.SelectedCard;
            CardManager cardManager = new CardManager(1);
            cardManager.ShowDialog();
            Globals.SelectedAccount = account;
            Globals.SelectedCard = card;
        }
        private void BKACChooseAccountClick(object sender, EventArgs e)
        {
            try
            {
                Globals.SelectedAccount = (long)cbBKACChooseAccount.Tag;
                Globals.IsRunning = true;
                SuspendLayout();
                Setup(pnBKAC);
                Globals.IsError = false;
                Globals.IsRunning = false;
                ResumeLayout(false);
                PerformLayout();
            }
            catch
            {
                MessageBox.Show("Escolha uma conta.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbBKACChooseAccount.Select();
                return;
            }
        }
        private void BKACFlowFilterClick(object sender, EventArgs e)
        {
            DateTime startDate = dpBKACFlowStart.Value;
            DateTime endDate = dpBKACFlowEnd.Value;
            try
            {
                DataTable dataSource = DataBase.Populate(Properties.Resources.sql_dgBKACFlow).AsEnumerable()
                        .Where(row => !row.Field<long>("Operação").Equals(4) &&
                                      !row.Field<long>("Operação").Equals(0) &&
                                      row.Field<long>("Conta").Equals(Globals.SelectedAccount) &&
                                      row.Field<DateTime>("Data").CompareTo(startDate) >= 0 &&
                                      row.Field<DateTime>("Data").CompareTo(endDate) <= 0)
                    .OrderByDescending(row => row.Field<long>("Id")).CopyToDataTable();
                Dictionary<string, int> dgConfig = new Dictionary<string, int>
                {
                    { "Data", (int)(dgBKACFlow.Width * 0.1) },
                    { "Beneficiário/Pagador", (int)(dgBKACFlow.Width * 0.6) },
                    { "Valor", (int)(dgBKACFlow.Width * 0.15) },
                    { "Saldo", (int)(dgBKACFlow.Width * 0.15) }
                };
                MyMethods.DataGridViewConfig(dgBKACFlow, dataSource, dgConfig, 2);
                decimal periodBalance = (decimal)dataSource.Compute("Sum(DecValor)", "");
                tbBKACPeriodBalance.Text = periodBalance.ToString("C");
                Color color;
                switch (periodBalance.CompareTo(0))
                {
                    case -1:
                        color = Color.Red;
                        break;
                    case 1:
                        color = Color.Blue;
                        break;
                    default:
                        color = Color.Black;
                        break;
                }
                tbBKACPeriodBalance.ForeColor = color;
            }
            catch 
            {
                MessageBox.Show("Nenhuma entrada encontrada para os filtros selecionados" +
                    "\n\nOs filtros não foram aplicados.");
                DateTime lastDate = DataBase.Tables.CashFlow.AsEnumerable()
                    .Where(row => !row.Field<long>("Opperation").Equals(4) &&
                                  !row.Field<long>("Opperation").Equals(0) &&
                                  row.Field<long>("Account").Equals(Globals.SelectedAccount))
                    .OrderByDescending(row => row.Field<long>("Id")).Take(1)
                    .CopyToDataTable().Rows[0].Field<DateTime>("Date");
                dpBKACFlowStart.Value = new DateTime(lastDate.Year, lastDate.Month, 1);
                dpBKACFlowEnd.Value = startDate.AddMonths(1).AddDays(-1);
            }
            Globals.IsError = false;
            dpBKACFlowStart.Select();
        }
        private void BKACNextCardClick(object sender, EventArgs e)
        {
            try
            {
                Globals.SelectedCard = DataBase.Tables.Cards.AsEnumerable()
                    .Where(row => row.Field<long>("Account").Equals(Globals.SelectedAccount) &&
                                  row.Field<long>("Id").CompareTo(Globals.SelectedCard) > 0)
                    .Take(1).CopyToDataTable().Rows[0].Field<long>("Id");
            }
            catch
            {
                Globals.SelectedCard = DataBase.Tables.Cards.AsEnumerable()
                                    .Where(row => row.Field<long>("Account").Equals(Globals.SelectedAccount))
                                    .Take(1).CopyToDataTable().Rows[0].Field<long>("Id");
            }
            Populate(null, Reload.BKACCardPanel);
        }
        private void BKACPreviousCardClick(object sender, EventArgs e)
        {
            try
            {
                Globals.SelectedCard = DataBase.Tables.Cards.AsEnumerable()
                    .Where(row => row.Field<long>("Account").Equals(Globals.SelectedAccount) &&
                                  row.Field<long>("Id").CompareTo(Globals.SelectedCard) < 0)
                    .Take(1).CopyToDataTable().Rows[0].Field<long>("Id");
            }
            catch
            {
                Globals.SelectedCard = DataBase.Tables.Cards.AsEnumerable()
                                    .Where(row => row.Field<long>("Account").Equals(Globals.SelectedAccount))
                                    .OrderByDescending(row => row["Id"]).Take(1)
                                    .CopyToDataTable().Rows[0].Field<long>("Id");
            }
            Populate(null, Reload.BKACCardPanel);
        }
        private void BKACChooseAccountValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) (sender as ComboBox).Tag = (long)(sender as ComboBox).SelectedValue;
            else (sender as ComboBox).Tag = -1;
        }
        #endregion
        #region Painel pnCFLW
        #endregion
        #region Painel pnCRED
        private void CREDDockChanged(object sender, EventArgs e)
        {
            Panel me = (Panel)sender;
            if (me.Dock.Equals(DockStyle.Fill))
            {
                Globals.IsRunning = true;
                SuspendLayout();
                Setup(me);
                Globals.IsError = false;
                Globals.IsRunning = false;
                ResumeLayout(false);
                PerformLayout();
            }
        }
        private void CREDAccountFilterTextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            ComboBox me = (ComboBox)sender;
            if (me.SelectedIndex.Equals(-1)) cbCREDCardFilter.Enabled = false;
            else
            {
                SortedDictionary<long, string> cards = new SortedDictionary<long, string>();
                DataTable dataSource = DataBase.Tables.Cards.AsEnumerable()
                    .Where(row => row.Field<long>("Account").Equals((long)me.SelectedValue))
                    .OrderByDescending(row => row.Field<long>("Id"))
                    .CopyToDataTable();
                foreach (DataRow row in dataSource.Rows)
                {
                    string card = row.Field<string>("Name");
                    cards.Add(row.Field<long>("Id"), "****" + card.Substring(card.Length - 4, 4));
                }
                cbCREDCardFilter.DataSource = new BindingSource(cards, null);
                cbCREDCardFilter.DisplayMember = "Value";
                cbCREDCardFilter.ValueMember = "Key";
                cbCREDCardFilter.Enabled = true;
            }
            cbCREDCardFilter.SelectedIndex = -1;
            Globals.SelectedCard = -1;
        }
        private void CREDBillsCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Globals.IsRunning || dgCREDBills.Rows.Count < 1 || e.RowIndex < 0) return;
            Globals.SelectedIndex = e.RowIndex;
            Globals.IsRunning = true;
            SuspendLayout();
            IsFiltered = false;
            IsSorted = true;
            IsLimited = true;
            Populate(null, Reload.CREDDetailPanel);
            Globals.IsError = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        private void CREDBillsKeyDown(object sender, KeyEventArgs e)
        {
            if (Globals.IsRunning || dgCREDBills.Rows.Count < 1) return;
            if ((e.KeyCode.Equals(Keys.Up) && dgCREDBills.CurrentCell.RowIndex > 0) ||
               (e.KeyCode.Equals(Keys.Down) && dgCREDBills.CurrentCell.RowIndex < dgCREDBills.Rows.Count - 1))
            {
                int i = 0;
                if (e.KeyCode.Equals(Keys.Up)) i = -1;
                if (e.KeyCode.Equals(Keys.Down)) i = 1;
                Globals.SelectedIndex = dgCREDBills.CurrentCell.RowIndex + i;
                Globals.IsRunning = true;
                SuspendLayout();
                IsFiltered = false;
                IsSorted = true;
                IsLimited = true;
                Populate(null, Reload.CREDDetailPanel);
                Globals.IsError = false;
                Globals.IsRunning = false;
                ResumeLayout(false);
                PerformLayout();
            }
        }
        private void CREDApplyFiltersClick(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            Globals.IsRunning = true;
            SuspendLayout();
            IsFiltered = true;
            IsSorted = true;
            IsLimited = true;
            Setup(pnCRED, 1);
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
            Globals.IsError = false;
        }
        private void CREDClearFiltersClick(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            Globals.IsRunning = true;
            SuspendLayout();
            cbCREDAccountFilter.SelectedIndex = -1;
            cbCREDCardFilter.SelectedIndex = -1;
            cbCREDCardFilter.Enabled = false;
            foreach (CheckBox ck in CheckList) ck.Checked = true;
            dpCREDEndFilter.Checked = false;
            dpCREDStartFilter.Checked = false;
            IsFiltered = false;
            IsSorted = true;
            IsLimited = true;
            Globals.SelectedAccount = -1;
            Globals.SelectedCard = -1;
            Setup(pnCRED, 1);
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
            Globals.IsError = false;
        }
        private void CREDPayBillClick(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            long idBill = (long)dgCREDBills.Rows[Globals.SelectedIndex].Cells["Id"].Value;
            DataTable billData;
            switch (btCREDPayBill.Text)
            {
                case "Pagar Fatura":
                    Debt.Card = DataBase.Tables.CreditBills.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idBill))
                        .CopyToDataTable().Rows[0].Field<long>("Card");
                    Debt.Account = DataBase.Tables.Cards.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Debt.Card))
                        .CopyToDataTable().Rows[0].Field<long>("Account");
                    Debt.Person = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Debt.Account))
                        .CopyToDataTable().Rows[0].Field<long>("Bank");
                    Debt.User = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Debt.Account))
                        .CopyToDataTable().Rows[0].Field<long>("User");
                    Debt.Category = 6;
                    Debt.Subcategory1 = 15;
                    Debt.Subcategory2 = 19;
                    Debt.Subcategory2 = 0;
                    Debt.DebtClass = 2;
                    Debt.Parcels = 1;
                    Debt.Opperation = 6;
                    billData = (DataTable)dgCREDBills.DataSource;
                    CreditBillPayment creditBillPayment = new CreditBillPayment(billData);
                    creditBillPayment.ShowDialog();
                    break;
                case "Fechar Fatura":
                    billData = DataBase.Tables.CreditBills.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idBill))
                        .CopyToDataTable();
                    string billDescription = billData.Rows[0].Field<string>("BillDescription");
                    long idCard = DataBase.Tables.CreditBills.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idBill))
                        .CopyToDataTable().Rows[0].Field<long>("Card");
                    long closingDay = DataBase.Tables.Cards.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(idCard))
                        .CopyToDataTable().Rows[0].Field<long>("ClosingDay");
                    DateTime forecastDate = DateTime.Parse(closingDay + "/" +
                        DateTime.Parse(dgCREDBills.Rows[Globals.SelectedIndex].Cells["Vencimento"]
                        .Value.ToString()).ToString("MM/yyyy"));
                    BillClosingDate billClosingDate = new BillClosingDate(forecastDate);
                    billClosingDate.ShowDialog();
                    string closingDate = Debt.Date;
                    try
                    {
                        var sqlConn = DataBase.DataBaseConnection();
                        var sqlCmd = sqlConn.CreateCommand();
                        sqlCmd.CommandText = Properties.Resources.sqlCloseCreditBill;
                        sqlCmd.Parameters.AddWithValue("@ClosingDate", closingDate);
                        sqlCmd.Parameters.AddWithValue("@Id", idBill);
                        sqlCmd.ExecuteNonQuery();
                        sqlConn.Close();
                        DataBase.Tables.CreditBills = DataBase.Populate(Properties.Resources.sqlCreditBills);
                    }
                    catch (Exception exErr)
                    {
                        MessageBox.Show("Erro ao fechar a fatura " + billDescription + ".\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Globals.IsError = true;
                        return;
                    }
                    break;
            }
            Globals.IsRunning = true;
            SuspendLayout();
            IsFiltered = false;
            IsSorted = true;
            IsLimited = true;
            Setup(pnCRED, 1);
            Debt.Clear();
            Globals.IsRunning = false;
            Globals.IsError = false;
            ResumeLayout(false);
            PerformLayout();
        }
        private void CREDAccountFilterValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Globals.SelectedAccount = (long)(sender as ComboBox).SelectedValue;
            else Globals.SelectedAccount = -1;
        }
        private void CREDCardFilterValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Globals.SelectedCard = (long)(sender as ComboBox).SelectedValue;
            else Globals.SelectedCard = -1;
        }
        #endregion
        #region Painel pnDRAW
        private void DRAWDockChanged(object sender, EventArgs e)
        {
            Panel me = (Panel)sender;
            if (me.Dock.Equals(DockStyle.Fill))
            {
                Globals.IsRunning = true;
                SuspendLayout();
                Setup(me);
                Globals.IsError = false;
                Globals.IsRunning = false;
                ResumeLayout(false);
                PerformLayout();
            }
        }
        private void DRAWClearClick(object sender, EventArgs e) { Setup(pnDRAW); }
        private void DRAWFilterClick(object sender, EventArgs e)
        {
            DateTime startDate = dpDRAWStart.Value;
            DateTime endDate = dpDRAWEnd.Value;
            DataTable dataSource = DataBase.Populate(Properties.Resources.sql_dgDRAWHistoric);
            try
            {
                dataSource = dataSource.AsEnumerable()
                .Where(row => row.Field<long>("IdOperação").Equals(10) &&
                        row.Field<DateTime>("Data").CompareTo(startDate) >= 0 &&
                        row.Field<DateTime>("Data").CompareTo(endDate) <= 0)
                .OrderByDescending(row => row.Field<DateTime>("Data"))
                .CopyToDataTable();
            }
            catch
            {
                try
                {
                    dataSource = dataSource.AsEnumerable()
                    .Where(row => row.Field<long>("IdOperação").Equals(10))
                    .OrderByDescending(row => row.Field<DateTime>("Data")).Take(25)
                    .CopyToDataTable();
                }
                catch { dataSource.Rows.Clear(); }
            }
            Dictionary<string, int> dgConfig = new Dictionary<string, int>
                {
                    { "Data", (int)(dgDRAWHistoric.Width * 0.2) },
                    { "Conta", (int)(dgDRAWHistoric.Width * 0.6) },
                    { "Valor", (int)(dgDRAWHistoric.Width * 0.2) }
                };
            MyMethods.DataGridViewConfig(dgDRAWHistoric, dataSource, dgConfig, 2);
            Globals.IsError = false;
            dpDRAWStart.Select();
        }
        private void DRAWSaveClick(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            if (string.IsNullOrWhiteSpace(Debt.Date) || Debt.User.Equals(-1) || Debt.DebtClass.Equals(-1) ||
               Debt.Account.Equals(-1) || Debt.Opperation.Equals(-1) || Debt.DebtValue.Equals(0) ||
               Debt.Person.Equals(-1) || Debt.Category.Equals(-1) ||
               Debt.Subcategory1.Equals(-1))
            {
                MessageBox.Show("Campos obrigatórios em branco.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mbNDBTDate.Select();
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Confirmar cadastro do saque?", "Novo saque", MessageBoxButtons.YesNo);
            if (!dialogResult.Equals(DialogResult.Yes))
            {
                mbNDBTDate.Select();
                return;
            }
            Globals.IsRunning = true;
            SuspendLayout();
            Debt.Insert();
            int wallet = (int)DataBase.Tables.Accounts.AsEnumerable()
                .Where(row => row.Field<long>("User").Equals(Debt.User) &&
                        row.Field<long>("Class").Equals(1))
                .CopyToDataTable().Rows[0].Field<long>("Id");
            Debt.Account = wallet;
            Debt.Opperation = 7;
            Debt.DebtClass = 1;
            Debt.Insert();
            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            DataTable dataSource;
            try
            {
                dataSource = DataBase.Populate(Properties.Resources.sql_dgDRAWHistoric).AsEnumerable()
                .Where(row => row.Field<long>("IdOperação").Equals(10) &&
                        row.Field<DateTime>("Data").CompareTo(startDate) >= 0 &&
                        row.Field<DateTime>("Data").CompareTo(endDate) <= 0)
                .OrderByDescending(row => row.Field<DateTime>("Data"))
                .CopyToDataTable();
            }
            catch
            {
                dataSource = DataBase.Populate(Properties.Resources.sql_dgDRAWHistoric).AsEnumerable()
                .Where(row => row.Field<long>("IdOperação").Equals(10))
                .OrderByDescending(row => row.Field<DateTime>("Data")).Take(25)
                .CopyToDataTable();
            }
            Dictionary<string, int> dgConfig = new Dictionary<string, int>
                {
                    { "Data", (int)(dgDRAWHistoric.Width * 0.2) },
                    { "Conta", (int)(dgDRAWHistoric.Width * 0.6) },
                    { "Valor", (int)(dgDRAWHistoric.Width * 0.2) }
                };
            MyMethods.DataGridViewConfig(dgDRAWHistoric, dataSource, dgConfig, 2);
            Setup(pnDRAW);
            Globals.IsError = false;
            ResumeLayout(false);
            PerformLayout();
            Globals.IsRunning = false;
            mbDRAWDate.Select();
        }
        private void DRAWAccountValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null)
            {
                Debt.Account = (long)(sender as ComboBox).SelectedValue;
                Debt.Person = (from accounts in DataBase.Tables.Accounts.AsEnumerable()
                               join banks in DataBase.Tables.Banks.AsEnumerable()
                               on (long)accounts["Bank"] equals (long)banks["Id"]
                               where accounts["Id"].Equals(Debt.Account)
                               select new { Id = (long)banks["Person"] }).ToList()[0].Id;
            }
            else
            {
                Debt.Account = -1;
                Debt.Person = -1;
            }
        }
        private void DRAWUserValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Debt.User = (long)(sender as ComboBox).SelectedValue;
            else Debt.User = -1;
            Globals.SelectedUser = Debt.User;
        }
        private void DRAWDateValidated(object sender, EventArgs e)
        {
            if (DateTime.TryParse((sender as MaskedTextBox).Text, out DateTime date)) Debt.Date = date.ToString("yyyy-MM-dd");
            else Debt.Date = string.Empty;
        }
        private void DRAWValueValidated(object sender, EventArgs e)
        {
            if (decimal.TryParse((sender as TextBox).Text, out decimal value)) Debt.DebtValue = value;
            else Debt.DebtValue = 0;
        }
        #endregion
        #region Painel pnFBAL
        #endregion Painel pnFBAL
        #region Painel pnIVST
        #endregion
        #region Painel pnNDBT
        private void NDBTDockChanged(object sender, EventArgs e)
        {
            Panel me = (Panel)sender;
            if (me.Dock.Equals(DockStyle.Fill))
            {
                Globals.IsRunning = true;
                SuspendLayout();
                Setup(me);
                Globals.IsError = false;
                Globals.IsRunning = false;
                ResumeLayout(false);
                PerformLayout();
                mbNDBTDate.Select();
            }
        }
        private void NDBTAccountTextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            ComboBox me = (ComboBox)sender;
            if (me.SelectedIndex.Equals(-1))
            {
                cbNDBTOpperation.SelectedIndex = -1;
                cbNDBTOpperation.Enabled = false;
                cbNDBTCard.SelectedIndex = -1;
                cbNDBTCard.Enabled = false;
                udNDBTParcels.Value = 1;
                udNDBTParcels.Enabled = false;
                Debt.Opperation = -1;
                Debt.Card = -1;
                Debt.Parcels = 1;
                Globals.IsBackspace = false;
                Globals.IsDelete = false;
                return;
            }
            Globals.IsRunning = true;
            SuspendLayout();
            Account.Type = DataBase.Tables.Accounts.AsEnumerable()
                .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                .CopyToDataTable().Rows[0].Field<long>("Type");
            string [] opperationType = DataBase.Types.AccountTypes.AsEnumerable()
                .Where(row => row.Field<long>("Id").Equals(Account.Type))
                .CopyToDataTable().Rows[0].Field<string>("OpperationType").Split(char.Parse(";"));
            DataTable filterSource = DataBase.Types.OpperationTypes.Copy();
            DataTable opperationSource = new DataTable();
            opperationSource.Columns.Add("Id", typeof(long));
            opperationSource.Columns.Add("Name", typeof(string));
            opperationSource.Rows.Clear();
            foreach (string opperationId in opperationType)
            {
                long id = long.Parse(opperationId);
                DataRow dataRow = filterSource.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals(id))
                    .AsDataView().ToTable(true, "Id", "Name").Rows[0];
                opperationSource.Rows.Add();
                opperationSource.Rows[opperationSource.Rows.Count - 1].SetField(opperationSource.Columns["Id"], dataRow.Field<long>("Id"));
                opperationSource.Rows[opperationSource.Rows.Count - 1].SetField(opperationSource.Columns["Name"], dataRow.Field<string>("Name"));
            }
            cbNDBTOpperation.DataSource = opperationSource;
            cbNDBTOpperation.DisplayMember = "Name";
            cbNDBTOpperation.ValueMember = "Id";
            var opperationSettings = (from accountTypes in DataBase.Types.AccountTypes.AsEnumerable()
                                     where ((long)accountTypes["Id"]).Equals(Account.Type)
                                     select new
                                     {
                                         Enable = (bool)accountTypes["OpperationEnable"],
                                         Value = (long)accountTypes["OpperationValue"]
                                     }).ToList();
            cbNDBTOpperation.SelectedValue = Debt.Opperation = opperationSettings[0].Value;
            cbNDBTOpperation.Enabled = opperationSettings[0].Enable;
            try
            {
                SortedDictionary<long, string> cards = new SortedDictionary<long, string>();
                DataTable dataSource = DataBase.Tables.Cards.AsEnumerable()
                    .Where(row => row.Field<long>("Account").Equals((long)me.SelectedValue))
                    .OrderByDescending(row => row.Field<long>("Id"))
                    .CopyToDataTable();
                foreach (DataRow row in dataSource.Rows)
                {
                    string card = row.Field<string>("Name");
                    cards.Add(row.Field<long>("Id"), "****" + card.Substring(card.Length - 4, 4));
                }
                cbNDBTCard.DataSource = new BindingSource(cards, null);
                cbNDBTCard.DisplayMember = "Value";
                cbNDBTCard.ValueMember = "Key";
                cbNDBTCard.Enabled = DataBase.Types.AccountTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals(Account.Type))
                    .CopyToDataTable().Rows[0].Field<bool>("CardEnable");
                if (cbNDBTCard.Enabled)
                {
                    cbNDBTCard.SelectedValue = Debt.Card = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                        .CopyToDataTable().Rows[0].Field<long>("StandardCard");
                }
                else cbNDBTCard.SelectedValue = Debt.Card = -1;
                if (Account.Type.Equals(1)) Debt.Card = 0;
            }
            catch
            {
                cbNDBTCard.DataSource = null;
                cbNDBTCard.SelectedIndex = -1;
                cbNDBTCard.Enabled = false;
                Debt.Card = 0;
            }
            udNDBTParcels.Enabled = false;
            Globals.IsBackspace = false;
            Globals.IsDelete = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        private void NDBTCategoryTextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            ComboBox cb = cbNDBTSubcategory1;
            ComboBox me = (ComboBox)sender;
            Globals.IsRunning = true;
            SuspendLayout();
            try
            {
                cb.DataSource = DataBase.Types.DebtSubcategory1.AsEnumerable()
                    .Where(row => row.Field<long>("Parent").Equals((long)me.SelectedValue))
                    .CopyToDataTable();
                cb.DisplayMember = "Name";
                cb.ValueMember = "Id";
            }
            catch { cb.DataSource = null; }
            cb.SelectedIndex = -1;
            cb.Enabled = true;
            cbNDBTSubcategory2.Text = "(SELECIONE A SUBCATEGORIA 1)";
            cbNDBTSubcategory3.Text = "(SELECIONE A SUBCATEGORIA 2)";
            cbNDBTSubcategory2.Enabled = cbNDBTSubcategory3.Enabled = false;
            Debt.Subcategory1 = Debt.Subcategory2 = Debt.Subcategory3 = -1;
            Globals.IsError = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();

        }
        private void NDBTOpperationTextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            ComboBox me = (ComboBox)sender;
            if (me.SelectedIndex.Equals(-1))
            {
                cbNDBTCard.SelectedIndex = -1;
                cbNDBTCard.Enabled = false;
                udNDBTParcels.Value = 1;
                udNDBTParcels.Enabled = false;
                Debt.Card = -1;
                Debt.Parcels = 1;
                Globals.IsBackspace = false;
                Globals.IsDelete = false;
                return;
            }
            Globals.IsRunning = true;
            SuspendLayout();
            cbNDBTCard.Enabled = DataBase.Types.OpperationTypes.AsEnumerable()
                .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                .CopyToDataTable().Rows[0].Field<bool>("CardEnable");
            if (cbNDBTCard.Enabled)
            {
                cbNDBTCard.SelectedValue = Debt.Card = DataBase.Tables.Accounts.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                    .CopyToDataTable().Rows[0].Field<long>("StandardCard");
            }
            else cbNDBTCard.SelectedValue = Debt.Card = -1;
            if (Account.Type.Equals(1)) Debt.Card = 0;
            udNDBTParcels.Enabled = DataBase.Types.OpperationTypes.AsEnumerable()
                .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                .CopyToDataTable().Rows[0].Field<bool>("ParcelsEnable");
            udNDBTParcels.Value = 1;
            Debt.Parcels = (long)udNDBTParcels.Value;
            Globals.IsBackspace = false;
            Globals.IsDelete = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        private void NDBTPersonTextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            ComboBox cb = cbNDBTBranch;
            ComboBox me = (ComboBox)sender;
            if (string.IsNullOrWhiteSpace(me.Text))
            {
                cb.SelectedIndex = -1;
                Globals.IsDelete = false;
                Globals.IsBackspace = false;
                return;
            }
            Globals.IsRunning = true;
            SuspendLayout();
            cb.Enabled = true;
            if (me.SelectedIndex.Equals(-1))
            {
                cb.SelectedIndex = -1;
                Person.Branch = -1;
                Person.BranchText = string.Empty;
            }
            else
            {
                cb.SelectedValue = (me.DataSource as DataTable).Rows[me.SelectedIndex].Field<long>("Branch");
                cb.Enabled = false;
                Person.Branch = (long)cb.SelectedValue;
                Person.BranchText = cb.Text.Replace("'", "''").Trim();
            }
            Globals.IsBackspace = false;
            Globals.IsDelete = false;
            Globals.IsError = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        private void NDBTSubcategory1TextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            ComboBox cb = cbNDBTSubcategory2;
            ComboBox me = (ComboBox)sender;
            Globals.IsRunning = true;
            SuspendLayout();
            try
            {
                cb.DataSource = DataBase.Types.DebtSubcategory2.AsEnumerable()
                    .Where(row => row.Field<long>("Parent").Equals((long)me.SelectedValue))
                    .CopyToDataTable();
                cb.DisplayMember = "Name";
                cb.ValueMember = "Id";
            }
            catch { cb.DataSource = null; }
            cb.Enabled = true;
            cb.Text = string.Empty;
            cbNDBTSubcategory3.Text = "(SELECIONE A SUBCATEGORIA 2)";
            cbNDBTSubcategory3.Enabled = false;
            Debt.Subcategory2 = Debt.Subcategory3 = -1;
            Globals.IsError = false;
            Globals.IsBackspace = false;
            Globals.IsDelete = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        private void NDBTSubcategory2TextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            ComboBox cb = cbNDBTSubcategory3;
            ComboBox me = (ComboBox)sender;
            Globals.IsRunning = true;
            SuspendLayout();
            try
            {
                cb.DataSource = DataBase.Types.DebtSubcategory3.AsEnumerable()
                    .Where(row => row.Field<long>("Parent").Equals((long)me.SelectedValue))
                    .CopyToDataTable();
                cb.DisplayMember = "Name";
                cb.ValueMember = "Id";
            }
            catch { cb.DataSource = null; }
            cb.Enabled = true;
            cb.Text = string.Empty;
            Debt.Subcategory3 = -1;
            Globals.IsError = false;
            Globals.IsBackspace = false;
            Globals.IsDelete = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        private void NDBTTDebtClassTextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            ComboBox cb = cbNDBTAccount;
            ComboBox me = (ComboBox)sender;
            Globals.IsRunning = true;
            SuspendLayout();
            if (me.SelectedIndex.Equals(-1))
            {
                cb.Enabled = false;
                cb.SelectedIndex = -1;
                Globals.IsBackspace = false;
                Globals.IsDelete = false;
                Globals.IsRunning = false;
                ResumeLayout(false);
                PerformLayout();
                return;
            }
            cb.Enabled = true;
            Globals.IsBackspace = false;
            Globals.IsDelete = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        private void NDBTUserTextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            ComboBox me = (ComboBox)sender;
            Globals.IsRunning = true;
            SuspendLayout();
            if (me.SelectedIndex.Equals(-1))
            {
                cbNDBTClass.Enabled = false;
                cbNDBTClass.SelectedIndex = -1;
                Globals.IsBackspace = false;
                Globals.IsDelete = false;
                Globals.IsRunning = false;
                ResumeLayout(false);
                PerformLayout();
                return;
            }
            try
            {
                cbNDBTAccount.DataSource = DataBase.Tables.Accounts.AsEnumerable()
                    .Where(row => row.Field<long>("User").Equals((long)me.SelectedValue))
                    .OrderBy(row => row.Field<string>("Name"))
                    .CopyToDataTable();
                cbNDBTAccount.DisplayMember = "Name";
                cbNDBTAccount.ValueMember = "Id";
            }
            catch { cbNDBTAccount.DataSource = null; }
            cbNDBTAccount.SelectedIndex = -1;
            cbNDBTClass.Enabled = true;
            Globals.IsBackspace = false;
            Globals.IsDelete = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        private void NDBTClearClick(object sender, EventArgs e)
        {
            Globals.IsRunning = true;
            SuspendLayout();
            Setup(pnNDBT);
            Globals.IsError = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
            mbNDBTDate.Select();
        }
        private void NDBTFirstClick(object sender, EventArgs e)
        {
            if (tbNDBTPage.Text.Equals("1")) return;
            DataTable dataSource = DataBase.Populate(Properties.Resources.sql_dgNDBTList);
            try
            {
                dataSource = dataSource.AsEnumerable()
                    .Where(row => !row.Field<long>("IdOperação").Equals(0) && 
                                  !row.Field<long>("IdOperação").Equals(4))
                    .OrderByDescending(row => row.Field<long>("Id"))
                    .ThenByDescending(row => row.Field<DateTime>("Data"))
                    .Take(int.Parse(cbNDBTItensPerPage.Text))
                    .CopyToDataTable();
            }
            catch { dataSource.Rows.Clear(); }
            Dictionary<string, int> dgConfig = new Dictionary<string, int>
                    {
                        { "Data", (int)(dgNDBTList.Width * 0.1) },
                        { "Beneficiário/Pagador", (int)(dgNDBTList.Width * 0.5) },
                        { "Operação", (int)(dgNDBTList.Width * 0.15) },
                        { "Conta", (int)(dgNDBTList.Width * 0.15) },
                        { "Valor", (int)(dgNDBTList.Width * 0.1) }
                    };
            MyMethods.DataGridViewConfig(dgNDBTList, dataSource, dgConfig, 2);
            tbNDBTPage.Text = "1";
        }
        private void NDBTLastClick(object sender, EventArgs e)
        {
            if (tbNDBTPage.Text.Equals(ListPages.ToString())) return;
            DataTable dataSource = DataBase.Populate(Properties.Resources.sql_dgNDBTList);
            try
            {
                dataSource = dataSource.AsEnumerable()
                    .Where(row => !row.Field<long>("IdOperação").Equals(0) && 
                                  !row.Field<long>("IdOperação").Equals(4))
                    .Take(int.Parse(cbNDBTItensPerPage.Text)).CopyToDataTable().AsEnumerable()
                    .OrderByDescending(row => row.Field<long>("Id"))
                    .ThenByDescending(row => row.Field<DateTime>("Data"))
                    .CopyToDataTable();
            }
            catch { dataSource.Rows.Clear(); }
            Dictionary<string, int> dgConfig = new Dictionary<string, int>
                    {
                        { "Data", (int)(dgNDBTList.Width * 0.1) },
                        { "Beneficiário/Pagador", (int)(dgNDBTList.Width * 0.5) },
                        { "Operação", (int)(dgNDBTList.Width * 0.15) },
                        { "Conta", (int)(dgNDBTList.Width * 0.15) },
                        { "Valor", (int)(dgNDBTList.Width * 0.1) }
                    };
            MyMethods.DataGridViewConfig(dgNDBTList, dataSource, dgConfig, 2);
            tbNDBTPage.Text = ListPages.ToString();
        }
        private void NDBTFilterClick(object sender, EventArgs e)
        {
            SuspendLayout();
            DataTable dataSource = DataBase.Populate(Properties.Resources.sql_dgNDBTList);
            try
            {
                dataSource = dataSource.AsEnumerable()
                    .Where(row => !row.Field<long>("IdOperação").Equals(0) &&
                                  !row.Field<long>("IdOperação").Equals(4))
                    .OrderByDescending(row => row.Field<long>("Id"))
                    .ThenByDescending(row => row.Field<DateTime>("Data"))
                    .Take(int.Parse(cbNDBTItensPerPage.Text))
                    .CopyToDataTable();
            }
            catch { dataSource.Rows.Clear(); }
            Dictionary<string, int> dgConfig = new Dictionary<string, int>
                    {
                        { "Data", (int)(dgNDBTList.Width * 0.1) },
                        { "Beneficiário/Pagador", (int)(dgNDBTList.Width * 0.5) },
                        { "Operação", (int)(dgNDBTList.Width * 0.15) },
                        { "Conta", (int)(dgNDBTList.Width * 0.15) },
                        { "Valor", (int)(dgNDBTList.Width * 0.1) }
                    };
            MyMethods.DataGridViewConfig(dgNDBTList, dataSource, dgConfig, 2);
            double nPages = (double)Debt.CurrentId / int.Parse(cbNDBTItensPerPage.Text);
            ListPages = Convert.ToInt32(Math.Ceiling(nPages));
            ResumeLayout(false);
            PerformLayout();
        }
        private void NDBTNextClick(object sender, EventArgs e)
        {
            if (int.Parse(tbNDBTPage.Text).Equals(ListPages)) return;
            long lastId;
            try { lastId = (long)dgNDBTList.Rows[dgNDBTList.Rows.Count - 1].Cells["Id"].Value; }
            catch { return; }
            DataTable dataSource = DataBase.Populate(Properties.Resources.sql_dgNDBTList);
            try
            {
                dataSource = DataBase.Populate(Properties.Resources.sql_dgNDBTList).AsEnumerable()
                    .Where(row => !row.Field<long>("IdOperação").Equals(0) &&
                                  !row.Field<long>("IdOperação").Equals(4) &&
                                  row.Field<long>("Id").CompareTo(lastId) < 0)
                    .OrderByDescending(row => row.Field<long>("Id"))
                    .ThenByDescending(row => row.Field<DateTime>("Data"))
                    .Take(int.Parse(cbNDBTItensPerPage.Text))
                    .CopyToDataTable();
            }
            catch { dataSource.Rows.Clear(); }
            Dictionary<string, int> dgConfig = new Dictionary<string, int>
                {
                    { "Data", (int)(dgNDBTList.Width * 0.1) },
                    { "Beneficiário/Pagador", (int)(dgNDBTList.Width * 0.5) },
                    { "Operação", (int)(dgNDBTList.Width * 0.15) },
                    { "Conta", (int)(dgNDBTList.Width * 0.15) },
                    { "Valor", (int)(dgNDBTList.Width * 0.1) }
                };
            MyMethods.DataGridViewConfig(dgNDBTList, dataSource, dgConfig, 2);
            tbNDBTPage.Text = (int.Parse(tbNDBTPage.Text) + 1).ToString();
        }
        private void NDBTPreviousClick(object sender, EventArgs e)
        {
            if (tbNDBTPage.Text.Equals("1")) return;
            int firstId;
            try { firstId = (int)dgNDBTList.Rows[0].Cells["Id"].Value; }
            catch { return; }
            DataTable dataSource = DataBase.Populate(Properties.Resources.sql_dgNDBTList);
            try
            {
                dataSource = DataBase.Populate(Properties.Resources.sql_dgNDBTList).AsEnumerable()
                    .Where(row => !row.Field<long>("IdOperação").Equals(0) &&
                                  !row.Field<long>("IdOperação").Equals(4) &&
                                  row.Field<long>("Id").CompareTo(firstId) > 0)
                    .Take(int.Parse(cbNDBTItensPerPage.Text)).CopyToDataTable().AsEnumerable()
                    .OrderByDescending(row => row.Field<long>("Id"))
                    .ThenByDescending(row => row.Field<DateTime>("Data"))
                    .CopyToDataTable();
            }
            catch { dataSource.Rows.Clear(); }
            Dictionary<string, int> dgConfig = new Dictionary<string, int>
                {
                    { "Data", (int)(dgNDBTList.Width * 0.1) },
                    { "Beneficiário/Pagador", (int)(dgNDBTList.Width * 0.5) },
                    { "Operação", (int)(dgNDBTList.Width * 0.15) },
                    { "Conta", (int)(dgNDBTList.Width * 0.15) },
                    { "Valor", (int)(dgNDBTList.Width * 0.1) }
                };
            MyMethods.DataGridViewConfig(dgNDBTList, dataSource, dgConfig, 2);
            tbNDBTPage.Text = Convert.ToString(int.Parse(tbNDBTPage.Text) - 1);
        }
        private void NDBTSaveClick(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            if (string.IsNullOrWhiteSpace(Debt.Date) || Debt.User.Equals(-1) || Debt.DebtClass.Equals(-1) ||
               Debt.Account.Equals(-1) || Debt.Opperation.Equals(-1) || Debt.DebtValue.Equals(0) ||
               Debt.Category.Equals(-1) || Debt.Subcategory1.Equals(-1) ||
               string.IsNullOrWhiteSpace(Person.Name) || string.IsNullOrWhiteSpace(Person.BranchText))
            {
                MessageBox.Show("Campos obrigatórios em branco.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mbNDBTDate.Select();
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Confirmar cadastro da " + cbNDBTClass.Text.ToLower() + "?", "Novo gasto ou recebimento", MessageBoxButtons.YesNo);
            if (!dialogResult.Equals(DialogResult.Yes))
            {
                mbNDBTDate.Select();
                return;
            }
            if (Debt.Person.Equals(-1))
            {
                dialogResult = MessageBox.Show("Este estabelecimento/pessoa será cadastrada no sistema." +
                                               "\nDeseja abrir o assistente de cadastro de pessoas?" +
                                               "\n\nCaso a resposta seja não, serão cadastrados apenas o nome, ramo e a pessoa será cadastrada como PJ.",
                                               "Novo estabelecimento/pessoa indentificado!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult.Equals(DialogResult.Yes))
                {
                    PeopleManager peopleManager = new PeopleManager(2);
                    peopleManager.ShowDialog();
                    Debt.Person = Globals.SelectedPerson;
                }
                if (Debt.Person.Equals(-1))
                {
                    if (!Person.CheckBranch())
                    {
                        cbNDBTBranch.Select();
                        return;
                    }
                    Person.Insert();
                    Debt.Person = Globals.SelectedPerson;
                }
                if (Person.IsUser) Populate(null, Reload.AccountDropItems);
            }
            Globals.IsRunning = true;
            SuspendLayout();
            Debt.CheckSubcategory(cbNDBTSubcategory1.Text, cbNDBTSubcategory2.Text, cbNDBTSubcategory3.Text);
            Debt.Insert();
            if (Debt.Opperation.Equals(4)) Debt.Credit();
            Setup(pnNDBT);
            Globals.IsError = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        private void NDBTAccountValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Debt.Account = (long)(sender as ComboBox).SelectedValue;
            else Debt.Account = -1;
            Globals.SelectedAccount = Debt.Account;
        }
        private void NDBTBranchValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Person.Branch = (long)(sender as ComboBox).SelectedValue;
            else Person.Branch = -1;
            Person.BranchText = cbNDBTBranch.Text.Replace("'", "''").Trim();
        }
        private void NDBTCategoryValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Debt.Category = (long)(sender as ComboBox).SelectedValue;
            else Debt.Category = -1;
        }
        private void NDBTCardValidated(object sender, EventArgs e)
        {
            if (!(sender as ComboBox).SelectedIndex.Equals(-1)) Debt.Card = (long)(sender as ComboBox).SelectedValue;
            else Debt.Card = -1;
            Globals.SelectedCard = Debt.Card;
        }
        private void NDBTOpperationValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Debt.Opperation = (long)(sender as ComboBox).SelectedValue;
            else Debt.Opperation = -1;
        }
        private void NDBTPersonValidated(object sender, EventArgs e)
        {
            Person.Name = (sender as ComboBox).Text.Replace("'", "''").Trim();
            if ((sender as ComboBox).SelectedValue != null) Debt.Person = (long)(sender as ComboBox).SelectedValue;
            else Debt.Person = -1;
            Globals.SelectedPerson = Debt.Person;
        }
        private void NDBTSubcategory1Validated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null)  Debt.Subcategory1 = (long)(sender as ComboBox).SelectedValue;
            else Debt.Subcategory1 = -1;
        }
        private void NDBTSubcategory2Validated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Debt.Subcategory2 = (long)(sender as ComboBox).SelectedValue;
            else Debt.Subcategory2 = -1;
        }
        private void NDBTSubcategory3Validated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Debt.Subcategory3 = (long)(sender as ComboBox).SelectedValue;
            else Debt.Subcategory3 = -1;
        }
        private void NDBTDebtClassValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Debt.DebtClass = (long)(sender as ComboBox).SelectedValue;
            else Debt.DebtClass = -1;
        }
        private void NDBTUserValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Debt.User = (long)(sender as ComboBox).SelectedValue;
            else Debt.User = -1;
            Globals.SelectedUser = Debt.User;
        }
        private void NDBTDateValidated(object sender, EventArgs e)
        {
            if (DateTime.TryParse((sender as MaskedTextBox).Text, out DateTime date)) Debt.Date = date.ToString("yyyy-MM-dd");
            else Debt.Date = string.Empty;
        }
        private void NDBTDescriptionValidated(object sender, EventArgs e)
        {
            Debt.Description = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        private void NDBTObservationValidated(object sender, EventArgs e)
        {
            Debt.Observation = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        private void NDBTValueValidated(object sender, EventArgs e)
        {
            if (decimal.TryParse((sender as TextBox).Text, out decimal value)) Debt.DebtValue = value;
            else Debt.DebtValue = 0;
        }
        private void NDBTParcelsValidated(object sender, EventArgs e)
        {
            Debt.Parcels = (long)(sender as NumericUpDown).Value;
        }
        #endregion
        #region Painel pnVCHS
        #endregion
        #region Painel pnWLLT
        #endregion
    }
}