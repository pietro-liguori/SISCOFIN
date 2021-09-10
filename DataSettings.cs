using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    public partial class DataSettings : Form
    {
        /*
         A propriedade Tag dos controles será usada para armazenar informações em pares chave/valor no formato 'chave:valor'.
         Os pares de informação serão separados por um ponto e vírgula ';'. Se não houver nenhuma informação a ser carregada pela Tag
         basta deixar vazio.
        
            Modelo de Tag => "Enum:1;Table:OpperationTypes;DisplayMember:Name;ValueMember:Id;Property:OpperationTypes;Class:DebtType.Custom;Value:6"

            Enum - Valor do enumerador DataSource do controle (para controles com DataSource)
            Table - Tabela do banco de dado associado (para controles com DataSource)
            Display - Nome da coluna da tabela com os valores a serem mostrados no controle (para controles com DataSource)
            ValueMember - Nome da coluna da tabela com os valores associados ao controle (para controles com DataSource)
            Property - Propriedade ou campo de validação do controle
            Class - Classe da propriedade ou campo de validação do controle (Caminho completo da classe. Ex. "DebtType.Custom")
            Value - Valor padrão da propriedade Value ou SelectedValue do controle
            Mask - Nome da máscara aplicada ao controle => Valores possíveis: CPF, CNPJ, CEP, Decimal, None
            Text - Texto associado ao controle
            Account - Valor da conta financeira associada ao controle

        - Utilização através de um dicionário com os pares chave/valor da Tag do controle:
        </>
            Dictionary<string, string> tags = new Dictionary<string, string>();
            string[] tagValue = (sender as TextBox).Tag.ToString().Split(';');
            foreach (string tag in tagValue) tags.Add(tag.Split(':')[0], tag.Split(':')[1]);
            long enumValue = long.Parse(tags["Enum"]);
            string args = tags["Args"];
            string column = tags["Column"];
            string displayMember = tags["DisplayMember"];
            string valueMember = tags["ValueMember"];
            string propertyName = tags["Property"];
            string className = tags["Class"];
        </>
         */
        private static Panel ActivePanel = null;
        public static long SearchValue = -1;
        public DataSettings()
        {
            InitializeComponent();
            Globals.IsRunning = true;
            ActivePanel = null;
            foreach (Control ctl in pnSettings.Controls)
            {
                if (ctl.GetType().Equals(typeof(Panel)))
                {
                    if ((ctl as Panel).Name.Equals("pnCommand")) continue;
                    (ctl as Panel).Visible = false;
                    (ctl as Panel).Dock = DockStyle.None;
                    (ctl as Panel).Location = new Point(0, 1000);
                }
            }
            spLayout.SplitterWidth = 1;
            spMENUFinance.MaximumSize = new Size(186, 243);
            spMENUFinance.MinimumSize = new Size(186, 42);
            spMENUFinance.SplitterDistance = 41;
            spMENUFinance.Size = spMENUFinance.MinimumSize;
            spMENUFinance.Panel2Collapsed = true;
            spMENUGeneral.MaximumSize = new Size(186, 111);
            spMENUGeneral.MinimumSize = new Size(186, 42);
            spMENUGeneral.SplitterDistance = 41;
            spMENUGeneral.Size = spMENUGeneral.MinimumSize;
            spMENUGeneral.Panel2Collapsed = true;
            spMENURegister.MaximumSize = new Size(186, 276);
            spMENURegister.MinimumSize = new Size(186, 42);
            spMENURegister.SplitterDistance = 41;
            spMENURegister.Size = spMENURegister.MinimumSize;
            spMENURegister.Panel2Collapsed = true;
            cbACTPAccountClass.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbACTPAccountClass.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbACTPAccountClass.Validated += new EventHandler(MyEvents.ControlValidation);
            cbACTPSearch.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbACTPSearch.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbACTPSearch.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbACTPStandardOpperation.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbACTPStandardOpperation.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbACTPStandardOpperation.Validated += new EventHandler(MyEvents.ControlValidation);
            cbCDTPSearch.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbCDTPSearch.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbCDTPSearch.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbDBCTSearch.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDBCTSearch.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbDBCTSearch.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbDBTPAccounts.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDBTPAccounts.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbDBTPAccounts.Validated += new EventHandler(MyEvents.ControlValidation);
            cbDBTPCards.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDBTPCards.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbDBTPCards.Validated += new EventHandler(MyEvents.ControlValidation);
            cbDBTPDebtCategories.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDBTPDebtCategories.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbDBTPDebtCategories.Validated += new EventHandler(MyEvents.ControlValidation);
            cbDBTPDebtClass.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDBTPDebtClass.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbDBTPDebtClass.Validated += new EventHandler(MyEvents.ControlValidation);
            cbDBTPDebtSubcategories1.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDBTPDebtSubcategories1.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbDBTPDebtSubcategories1.Validated += new EventHandler(MyEvents.ControlValidation);
            cbDBTPDebtSubcategories2.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDBTPDebtSubcategories2.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbDBTPDebtSubcategories2.Validated += new EventHandler(MyEvents.ControlValidation);
            cbDBTPDebtSubcategories3.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDBTPDebtSubcategories3.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbDBTPDebtSubcategories3.Validated += new EventHandler(MyEvents.ControlValidation);
            cbDBTPOpperationTypes.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDBTPOpperationTypes.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbDBTPOpperationTypes.Validated += new EventHandler(MyEvents.ControlValidation);
            cbDBTPPeople.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDBTPPeople.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbDBTPPeople.Validated += new EventHandler(MyEvents.ControlValidation);
            cbDBTPStatus.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDBTPStatus.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbDBTPStatus.Validated += new EventHandler(MyEvents.ControlValidation);
            cbDBTPUsers.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDBTPUsers.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbDBTPUsers.Validated += new EventHandler(MyEvents.ControlValidation);
            cbDBTPSearch.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbDBTPSearch.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbDBTPSearch.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbOPTPSearch.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbOPTPSearch.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbOPTPSearch.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            ckACTPAgency.Validated += new EventHandler(MyEvents.ControlValidation);
            ckACTPEnableCard.Validated += new EventHandler(MyEvents.ControlValidation);
            ckACTPEnableOpperation.Validated += new EventHandler(MyEvents.ControlValidation);
            ckACTPFee.Validated += new EventHandler(MyEvents.ControlValidation);
            ckACTPGrace.Validated += new EventHandler(MyEvents.ControlValidation);
            ckACTPNumber.Validated += new EventHandler(MyEvents.ControlValidation);
            ckACTPOverdraft.Validated += new EventHandler(MyEvents.ControlValidation);
            ckCDTPClosingDay.Validated += new EventHandler(MyEvents.ControlValidation);
            ckCDTPCVV.Validated += new EventHandler(MyEvents.ControlValidation);
            ckCDTPDueDay.Validated += new EventHandler(MyEvents.ControlValidation);
            ckCDTPExpiration.Validated += new EventHandler(MyEvents.ControlValidation);
            ckCDTPFee.Validated += new EventHandler(MyEvents.ControlValidation);
            ckCDTPFlag.Validated += new EventHandler(MyEvents.ControlValidation);
            ckCDTPLimit.Validated += new EventHandler(MyEvents.ControlValidation);
            ckDBCTEnableSelection.Validated += new EventHandler(MyEvents.ControlValidation);
            ckDBTPAccountsInherit.Validated += new EventHandler(MyEvents.ControlValidation);
            ckDBTPCardsInherit.Validated += new EventHandler(MyEvents.ControlValidation);
            ckDBTPDebtSubcategoriesInherit.Validated += new EventHandler(MyEvents.ControlValidation);
            ckDBTPEnableSelection.Validated += new EventHandler(MyEvents.ControlValidation);
            ckDBTPOpperationTypesInherit.Validated += new EventHandler(MyEvents.ControlValidation);
            ckDBTPParcels.Validated += new EventHandler(MyEvents.ControlValidation);
            ckDBTPParcelsInherit.Validated += new EventHandler(MyEvents.ControlValidation);
            ckDBTPValue.Validated += new EventHandler(MyEvents.ControlValidation);
            ckMENUFinance.CheckedChanged += new EventHandler(MenuCheckedChanged);
            ckMENUFinance.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            ckMENUGeneral.CheckedChanged += new EventHandler(MenuCheckedChanged);
            ckMENUGeneral.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            ckMENURegister.CheckedChanged += new EventHandler(MenuCheckedChanged);
            ckMENURegister.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            ckOPTPCardEnable.Validated += new EventHandler(MyEvents.ControlValidation);
            ckOPTPParcelsEnable.Validated += new EventHandler(MyEvents.ControlValidation);
            dgDBCTSubcategory1.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgDBCTSubcategory2.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgDBCTSubcategory3.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            tbACTPName.Validated += new EventHandler(MyEvents.ControlValidation);
            tbCDTPName.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBCTName.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBTPAccounts.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBTPCards.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBTPDebtCategories.Validated += new EventHandler(MyEvents.ControlValidation); ;
            tbDBTPDebtClass.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBTPDebtSubcategories1.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBTPDebtSubcategories2.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBTPDebtSubcategories3.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBTPDescription.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBTPName.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBTPObservation.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBTPOpperationTypes.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBTPPeople.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBTPUsers.Validated += new EventHandler(MyEvents.ControlValidation);
            tbDBTPValue.KeyDown += new KeyEventHandler(MyEvents.DecimalMask);
            tbDBTPValue.Validated += new EventHandler(MyEvents.ControlValidation);
            tbOPTPName.Validated += new EventHandler(MyEvents.ControlValidation);
            tgACTPCardTypes.TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            tgACTPCardTypes.TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            tgACTPCardTypes.Validated += new EventHandler(MyEvents.ControlValidation);
            tgACTPOpperationTypes.TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            tgACTPOpperationTypes.TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            tgACTPOpperationTypes.Validated += new EventHandler(MyEvents.ControlValidation);
            tgCDTPOpperationTypes.TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            tgCDTPOpperationTypes.TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            tgCDTPOpperationTypes.Validated += new EventHandler(MyEvents.ControlValidation);
            tgDBTPAccounts.TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            tgDBTPAccounts.TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            tgDBTPAccounts.Validated += new EventHandler(MyEvents.ControlValidation);
            tgDBTPCards.TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            tgDBTPCards.TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            tgDBTPCards.Validated += new EventHandler(MyEvents.ControlValidation);
            tgDBTPDebtCategories.TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            tgDBTPDebtCategories.TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            tgDBTPDebtCategories.Validated += new EventHandler(MyEvents.ControlValidation);
            tgDBTPDebtClass.TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            tgDBTPDebtClass.TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            tgDBTPDebtClass.Validated += new EventHandler(MyEvents.ControlValidation);
            tgDBTPDebtSubcategories1.TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            tgDBTPDebtSubcategories1.TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            tgDBTPDebtSubcategories1.Validated += new EventHandler(MyEvents.ControlValidation);
            tgDBTPDebtSubcategories2.TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            tgDBTPDebtSubcategories2.TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            tgDBTPDebtSubcategories2.Validated += new EventHandler(MyEvents.ControlValidation);
            tgDBTPDebtSubcategories3.TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            tgDBTPDebtSubcategories3.TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            tgDBTPDebtSubcategories3.Validated += new EventHandler(MyEvents.ControlValidation);
            tgDBTPOpperationTypes.TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            tgDBTPOpperationTypes.TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            tgDBTPOpperationTypes.Validated += new EventHandler(MyEvents.ControlValidation);
            tgDBTPPeople.TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            tgDBTPPeople.TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            tgDBTPPeople.Validated += new EventHandler(MyEvents.ControlValidation);
            tgDBTPUsers.TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            tgDBTPUsers.TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            tgDBTPUsers.Validated += new EventHandler(MyEvents.ControlValidation);
            Globals.IsRunning = false;
        }
        private void Setup(object panel, int mode = 0)
        {
            long enumValue;
            long id;
            string tableName;
            string displayMember;
            string valueMember;
            string sqlCommand;
            string[] args = null;
            DataTable dataSource;
            Dictionary<string, int> dgConfig;
            lbSettings.Visible = true;
            lnSettings.Visible = true;
            pnCommand.Visible = Convert.ToBoolean(mode);
            if (panel.Equals(pnACTP))
            {
                if (mode.Equals(0))
                {
                    cbACTPAccountClass.DataSource = DataBase.Types.AccountClass.Copy();
                    cbACTPAccountClass.DisplayMember = "Name";
                    cbACTPAccountClass.ValueMember = "Id";
                    cbACTPSearch.DataSource = DataBase.Types.AccountTypes.Copy();
                    cbACTPSearch.DisplayMember = "Name";
                    cbACTPSearch.ValueMember = "Id";
                    cbACTPStandardOpperation.DataSource = DataBase.Types.OpperationTypes.Copy();
                    cbACTPStandardOpperation.DisplayMember = "Name";
                    cbACTPStandardOpperation.ValueMember = "Id";
                    tgACTPCardTypes.DataSource = DataBase.Types.CardTypes.Copy();
                    tgACTPCardTypes.DisplayMember = "Name";
                    tgACTPCardTypes.ValueMember = "Id";
                    tgACTPOpperationTypes.DataSource = DataBase.Types.OpperationTypes.Copy();
                    tgACTPOpperationTypes.DisplayMember = "Name";
                    tgACTPOpperationTypes.ValueMember = "Id";
                    cbACTPSearch.SelectedIndex = -1;
                    gbACTPAttributes.Visible = false;
                    gbACTPFormBehavior.Visible = false;
                }
                if (mode.Equals(1))
                {
                    cbACTPAccountClass.SelectedIndex = -1;
                    cbACTPStandardOpperation.SelectedIndex = -1;
                    ckACTPAgency.Checked = false; 
                    ckACTPCard.Checked = false; 
                    ckACTPEnableCard.Checked = false; 
                    ckACTPEnableOpperation.Checked = false;
                    ckACTPFee.Checked = false;
                    ckACTPFee.Enabled = false;
                    ckACTPGrace.Checked = false;
                    ckACTPGrace.Enabled = false;
                    ckACTPNumber.Checked = false; 
                    ckACTPOverdraft.Checked = false;
                    gbACTPAttributes.Visible = true;
                    gbACTPFormBehavior.Visible = true;
                    gbACTPFormBehavior.BringToFront();
                    tgACTPCardTypes.Clear();
                    tgACTPCardTypes.Enabled = false;
                    tgACTPCardTypes.SelectedIndex = -1;
                    tgACTPOpperationTypes.Clear();
                    tgACTPOpperationTypes.SelectedIndex = -1;
                    tbACTPName.Enabled = true;
                    tbACTPName.Text = string.Empty;
                }
                if (mode.Equals(2))
                {
                    SearchValue = (long)cbACTPSearch.SelectedValue;
                    DataTable accountType = DataBase.Types.AccountTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(SearchValue))
                        .CopyToDataTable();
                    cbACTPAccountClass.SelectedValue = (long)accountType.Rows[0]["Class"];
                    cbACTPStandardOpperation.SelectedValue = (long)accountType.Rows[0]["OpperationValue"];
                    ckACTPAgency.Checked = (bool)accountType.Rows[0]["Agency"];
                    ckACTPCard.Checked = (bool)accountType.Rows[0]["Card"]; 
                    ckACTPEnableCard.Checked = (bool)accountType.Rows[0]["CardEnable"];
                    ckACTPEnableOpperation.Checked = (bool)accountType.Rows[0]["OpperationEnable"];
                    ckACTPOverdraft.Checked = (bool)accountType.Rows[0]["Overdraft"];
                    ckACTPFee.Checked = (bool)accountType.Rows[0]["Fee"];
                    ckACTPFee.Enabled = ckACTPOverdraft.Checked;
                    ckACTPGrace.Checked = (bool)accountType.Rows[0]["Grace"];
                    ckACTPGrace.Enabled = ckACTPOverdraft.Checked;
                    ckACTPNumber.Checked = (bool)accountType.Rows[0]["Account"];
                    gbACTPAttributes.Visible = true;
                    gbACTPFormBehavior.Visible = true;
                    gbACTPFormBehavior.BringToFront();
                    string[] opperationType = DataBase.Types.AccountTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(SearchValue))
                        .CopyToDataTable().Rows[0].Field<string>("OpperationType").Split(char.Parse(";"));
                    DataTable filterSource = DataBase.Types.OpperationTypes.Copy();
                    DataTable opperationSource = new DataTable();
                    opperationSource.Columns.Add("Id", typeof(long));
                    opperationSource.Columns.Add("Name", typeof(string));
                    opperationSource.Rows.Clear();
                    foreach (string opperationId in opperationType)
                    {
                        id = long.Parse(opperationId);
                        DataRow dataRow = filterSource.AsEnumerable()
                            .Where(row => row.Field<long>("Id").Equals(id))
                            .AsDataView().ToTable(true, "Id", "Name").Rows[0];
                        opperationSource.Rows.Add();
                        opperationSource.Rows[opperationSource.Rows.Count - 1].SetField(opperationSource.Columns["Id"], dataRow.Field<long>("Id"));
                        opperationSource.Rows[opperationSource.Rows.Count - 1].SetField(opperationSource.Columns["Name"], dataRow.Field<string>("Name"));
                    }
                    tgACTPOpperationTypes.Clear();
                    tgACTPOpperationTypes.Add(opperationSource);
                    tgACTPOpperationTypes.SelectedIndex = -1;
                    tbACTPName.Enabled = false;
                    tbACTPName.Text = (string)accountType.Rows[0]["Name"];
                    tgACTPCardTypes.Enabled = ckACTPCard.Checked;
                    string[] cardType = DataBase.Types.AccountTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(SearchValue))
                        .CopyToDataTable().Rows[0].Field<string>("CardType").Split(char.Parse(";"));
                    if (cardType.Length.Equals(1) && cardType[0].Equals(string.Empty)) return;
                    filterSource = DataBase.Types.CardTypes.Copy();
                    DataTable cardSource = new DataTable();
                    cardSource.Columns.Add("Id", typeof(long));
                    cardSource.Columns.Add("Name", typeof(string));
                    cardSource.Rows.Clear();
                    foreach (string cardId in cardType)
                    {
                        id = long.Parse(cardId);
                        DataRow dataRow = filterSource.AsEnumerable()
                            .Where(row => row.Field<long>("Id").Equals(id))
                            .AsDataView().ToTable(true, "Id", "Name").Rows[0];
                        cardSource.Rows.Add();
                        cardSource.Rows[cardSource.Rows.Count - 1].SetField(cardSource.Columns["Id"], dataRow.Field<long>("Id"));
                        cardSource.Rows[cardSource.Rows.Count - 1].SetField(cardSource.Columns["Name"], dataRow.Field<string>("Name"));
                    }
                    tgACTPCardTypes.Clear();
                    tgACTPCardTypes.Add(cardSource);
                    tgACTPCardTypes.SelectedIndex = -1;
                }
                return;
            }
            if (panel.Equals(pnCDTP))
            {
                if (mode.Equals(0))
                {
                    cbCDTPSearch.DataSource = DataBase.Types.CardTypes.Copy();
                    cbCDTPSearch.DisplayMember = "Name";
                    cbCDTPSearch.ValueMember = "Id";
                    tgCDTPOpperationTypes.DataSource = DataBase.Types.OpperationTypes.Copy();
                    tgCDTPOpperationTypes.DisplayMember = "Name";
                    tgCDTPOpperationTypes.ValueMember = "Id";
                    cbCDTPSearch.SelectedIndex = -1;
                    gbCDTPAttributes.Visible = false;
                }
                if (mode.Equals(1))
                {
                    ckCDTPClosingDay.Checked = false;
                    ckCDTPCVV.Checked = false;
                    ckCDTPDueDay.Checked = false;
                    ckCDTPExpiration.Checked = false;
                    ckCDTPFee.Checked = false;
                    ckCDTPFlag.Checked = false;
                    ckCDTPLimit.Checked = false;
                    gbCDTPAttributes.Visible = true;
                    tgCDTPOpperationTypes.Clear();
                    tgCDTPOpperationTypes.SelectedIndex = -1;
                    tbCDTPName.Text = string.Empty;
                }
                if (mode.Equals(2))
                {
                    SearchValue = (long)cbCDTPSearch.SelectedValue;
                    DataTable cardType = DataBase.Types.CardTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(SearchValue))
                        .CopyToDataTable();
                    ckCDTPClosingDay.Checked = (bool)cardType.Rows[0]["ClosingDay"];
                    ckCDTPCVV.Checked = (bool)cardType.Rows[0]["CVV"];
                    ckCDTPDueDay.Checked = (bool)cardType.Rows[0]["DueDay"];
                    ckCDTPExpiration.Checked = (bool)cardType.Rows[0]["Expiration"];
                    ckCDTPFee.Checked = (bool)cardType.Rows[0]["Fee"];
                    ckCDTPFlag.Checked = (bool)cardType.Rows[0]["Flag"];
                    ckCDTPLimit.Checked = (bool)cardType.Rows[0]["CreditLimit"];
                    gbCDTPAttributes.Visible = true;
                    tbCDTPName.Text = string.Empty;
                    string[] opperationType = DataBase.Types.CardTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(SearchValue))
                        .CopyToDataTable().Rows[0].Field<string>("OpperationType").Split(char.Parse(";"));
                    DataTable filterSource = DataBase.Types.OpperationTypes.Copy();
                    DataTable opperationSource = new DataTable();
                    opperationSource.Columns.Add("Id", typeof(long));
                    opperationSource.Columns.Add("Name", typeof(string));
                    opperationSource.Rows.Clear();
                    foreach (string opperationId in opperationType)
                    {
                        id = long.Parse(opperationId);
                        DataRow dataRow = filterSource.AsEnumerable()
                            .Where(row => row.Field<long>("Id").Equals(id))
                            .AsDataView().ToTable(true, "Id", "Name").Rows[0];
                        opperationSource.Rows.Add();
                        opperationSource.Rows[opperationSource.Rows.Count - 1].SetField(opperationSource.Columns["Id"], dataRow.Field<long>("Id"));
                        opperationSource.Rows[opperationSource.Rows.Count - 1].SetField(opperationSource.Columns["Name"], dataRow.Field<string>("Name"));
                    }
                    tgCDTPOpperationTypes.Clear();
                    tgCDTPOpperationTypes.Add(opperationSource);
                    tgCDTPOpperationTypes.SelectedIndex = -1;
                    tbCDTPName.Enabled = false;
                    tbCDTPName.Text = (string)cardType.Rows[0]["Name"];
                }
                return;
            }
            if (panel.Equals(pnDBCT))
            {
                if (mode.Equals(0))
                {
                    cbDBCTSearch.DataSource = DataBase.Types.DebtCategory.Copy();
                    cbDBCTSearch.DisplayMember = "Name";
                    cbDBCTSearch.ValueMember = "Id";
                    cbDBCTSearch.SelectedIndex = -1;
                    gbDBCTAtributes.Visible = false;
                    gbDBCTSubcategory.Visible = false;
                }
                if (mode.Equals(1))
                {
                    cbDBCTSearch.SelectedIndex = -1;
                    ckDBCTEnableSelection.Checked = false;
                    gbDBCTAtributes.Visible = true;
                    gbDBCTSubcategory.Visible = true;
                    gbDBCTSubcategory.BringToFront();
                    tbDBCTName.Enabled = true;
                    tbDBCTName.Text = string.Empty;
                }
                if (mode.Equals(2))
                {
                    SearchValue = (long)cbDBCTSearch.SelectedValue;
                    DataTable debtCategory = DataBase.Types.DebtCategory.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(SearchValue))
                        .CopyToDataTable();
                    ckDBCTEnableSelection.Checked = (bool)debtCategory.Rows[0]["EnableSelection"];
                    gbDBCTAtributes.Visible = true;
                    gbDBCTSubcategory.Visible = true;
                    gbDBCTSubcategory.BringToFront();
                    try
                    {
                        dataSource = DataBase.Types.DebtSubcategory1.AsEnumerable()
                            .Where(row => row.Field<long>("Parent").Equals(SearchValue))
                            .CopyToDataTable();
                        dgConfig = new Dictionary<string, int> { { "Name", dgDBCTSubcategory1.Width } };
                        MyMethods.DataGridViewConfig(dgDBCTSubcategory1, dataSource, dgConfig, 2);
                        dgDBCTSubcategory1.Rows[0].Selected = true;
                        btDBCTDeleteSub1.Enabled = true;
                        btDBCTNewSub2.Enabled = true;
                        id = (long)dgDBCTSubcategory1.SelectedRows[0].Cells["Id"].Value;
                        try
                        {
                            dataSource = DataBase.Types.DebtSubcategory2.AsEnumerable()
                                .Where(row => row.Field<long>("Parent").Equals(id))
                                .CopyToDataTable();
                            dgConfig = new Dictionary<string, int> { { "Name", dgDBCTSubcategory2.Width } };
                            MyMethods.DataGridViewConfig(dgDBCTSubcategory2, dataSource, dgConfig, 2);
                            dgDBCTSubcategory2.Rows[0].Selected = true;
                            btDBCTDeleteSub2.Enabled = true;
                            btDBCTNewSub3.Enabled = true;
                            id = (long)dgDBCTSubcategory2.SelectedRows[0].Cells["Id"].Value;
                            try
                            {
                                dataSource = DataBase.Types.DebtSubcategory3.AsEnumerable()
                                    .Where(row => row.Field<long>("Parent").Equals(id))
                                    .CopyToDataTable();
                                dgConfig = new Dictionary<string, int> { { "Name", dgDBCTSubcategory3.Width } };
                                MyMethods.DataGridViewConfig(dgDBCTSubcategory3, dataSource, dgConfig, 2);
                                dgDBCTSubcategory3.Rows[0].Selected = true;
                                btDBCTDeleteSub3.Enabled = true;
                            }
                            catch
                            {
                                dgDBCTSubcategory3.DataSource = null;
                                btDBCTDeleteSub3.Enabled = false;
                            }
                        }
                        catch
                        {
                            btDBCTDeleteSub2.Enabled = false;
                            btDBCTDeleteSub3.Enabled = false;
                            btDBCTNewSub3.Enabled = false;
                            dgDBCTSubcategory2.DataSource = null;
                            dgDBCTSubcategory3.DataSource = null;
                        }
                    }
                    catch
                    {
                        btDBCTDeleteSub1.Enabled = false;
                        btDBCTDeleteSub2.Enabled = false;
                        btDBCTDeleteSub3.Enabled = false;
                        btDBCTNewSub2.Enabled = false;
                        btDBCTNewSub3.Enabled = false;
                        dgDBCTSubcategory2.DataSource = null;
                        dgDBCTSubcategory3.DataSource = null;
                    }
                    tbDBCTName.Enabled = false;
                    tbDBCTName.Text = (string)debtCategory.Rows[0]["Name"];
                }
                return;
            }
            if (panel.Equals(pnDBTP))
            {
                if (mode.Equals(0))
                {
                    dataSource = DataBase.Populate("SELECT * FROM DataSources");
                    DataTable dataTable;
                    List<FlowLayoutPanel> groupFlows = new List<FlowLayoutPanel>
                    { flDBTPAccounts, flDBTPCards, flDBTPDebtCategories, flDBTPDebtClass, flDBTPOpperationTypes, flDBTPPeople,
                      flDBTPDebtSubcategories1, flDBTPDebtSubcategories2, flDBTPDebtSubcategories3, flDBTPUsers };
                    foreach (FlowLayoutPanel flow in groupFlows)
                    {
                        (flow.Parent as GroupBox).Visible = false;
                        ComboBox cb = flow.Controls["cb" + flow.Name.Substring(2)] as ComboBox;
                        displayMember = MyMethods.GetTag<string>(cb, "DisplayMember") is null ? "Name": MyMethods.GetTag<string>(cb, "DisplayMember");
                        valueMember = MyMethods.GetTag<string>(cb, "ValueMember") is null ? "EnumValue" : MyMethods.GetTag<string>(cb, "ValueMember");
                        dataTable = new DataTable();
                        dataTable.Columns.Add(valueMember, typeof(long));
                        dataTable.Columns.Add(displayMember, typeof(string));
                        dataTable.Rows.Clear();
                        tableName = MyMethods.GetTag<string>(cb, "DataSource") is null ? string.Empty : MyMethods.GetTag<string>(cb, "DataSource");
                        foreach (DataRow row in dataSource.Rows)
                        {
                            string[] tableList = ((string)row["Tables"]).Split(';');
                            if (string.IsNullOrWhiteSpace(tableList[0]))
                            {
                                dataTable.Rows.Add();
                                dataTable.Rows[dataTable.Rows.Count - 1].SetField(dataTable.Columns[valueMember], row.Field<long>(valueMember));
                                dataTable.Rows[dataTable.Rows.Count - 1].SetField(dataTable.Columns[displayMember], row.Field<string>(displayMember));
                            }
                            else if (((string)row["Tables"]).Split(char.Parse(";")).Contains(tableName))
                            {
                                foreach (string table in tableList)
                                {
                                    if (table.Contains(tableName) && !table.StartsWith("!"))
                                    {
                                        dataTable.Rows.Add();
                                        dataTable.Rows[dataTable.Rows.Count - 1].SetField(dataTable.Columns[valueMember], row.Field<long>(valueMember));
                                        dataTable.Rows[dataTable.Rows.Count - 1].SetField(dataTable.Columns[displayMember], row.Field<string>(displayMember));
                                    }
                                }
                            }
                        }
                        cb.DataSource = dataTable;
                        cb.DisplayMember = displayMember;
                        cb.ValueMember = valueMember;
                        cb.SelectedIndex = -1;
                        TagBox tg = flow.Controls["tg" + flow.Name.Substring(2)] as TagBox;
                        args = MyMethods.GetTag<string>(tg, "Args").Split(',');
                        enumValue = MyMethods.GetTag<long>(tg, "Enum");
                        displayMember = MyMethods.GetTag<string>(tg, "DisplayMember") is null ? "Name" : MyMethods.GetTag<string>(tg, "DisplayMember");
                        valueMember = MyMethods.GetTag<string>(tg, "ValueMember") is null ? "Id" : MyMethods.GetTag<string>(tg, "ValueMember");
                        sqlCommand = DataBase.BuildCommand((DataSource)enumValue, args);
                        tg.DataSource = DataBase.Populate(sqlCommand);
                        tg.DisplayMember = displayMember;
                        tg.ValueMember = valueMember;
                        tg.SelectedIndex = -1;
                    }
                    args = MyMethods.GetTag<string>(cbDBTPSearch, "Args").Split(',');
                    enumValue = MyMethods.GetTag<long>(cbDBTPSearch, "Enum");
                    displayMember = MyMethods.GetTag<string>(cbDBTPSearch, "DisplayMember") is null ? "Name" : MyMethods.GetTag<string>(cbDBTPSearch, "DisplayMember");
                    valueMember = MyMethods.GetTag<string>(cbDBTPSearch, "ValueMember") is null ? "Id" : MyMethods.GetTag<string>(cbDBTPSearch, "ValueMember");
                    sqlCommand = DataBase.BuildCommand((DataSource)enumValue, args);
                    cbDBTPSearch.DataSource = DataBase.Populate(sqlCommand);
                    cbDBTPSearch.DisplayMember = displayMember;
                    cbDBTPSearch.ValueMember = valueMember;
                    cbDBTPSearch.SelectedIndex = -1;
                    args = MyMethods.GetTag<string>(cbDBTPStatus, "Args").Split(',');
                    enumValue = MyMethods.GetTag<long>(cbDBTPStatus, "Enum");
                    displayMember = MyMethods.GetTag<string>(cbDBTPStatus, "DisplayMember") is null ? "Name" : MyMethods.GetTag<string>(cbDBTPStatus, "DisplayMember");
                    valueMember = MyMethods.GetTag<string>(cbDBTPStatus, "ValueMember") is null ? "Id" : MyMethods.GetTag<string>(cbDBTPStatus, "ValueMember");
                    sqlCommand = DataBase.BuildCommand((DataSource)enumValue, args);
                    cbDBTPStatus.DataSource = DataBase.Populate(sqlCommand);
                    cbDBTPStatus.DisplayMember = displayMember;
                    cbDBTPStatus.ValueMember = valueMember;
                    gbDBTPAttributes.Visible = false;
                }
                if (mode.Equals(1))
                {
                    cbDBTPStatus.SelectedIndex = -1;
                    gbDBTPAttributes.Visible = true;
                    tbDBTPDescription.Text = string.Empty;
                    tbDBTPName.Enabled = true;
                    tbDBTPName.Text = string.Empty;
                    tbDBTPObservation.Text = string.Empty;
                    tbDBTPValue.Text = "0,00";
                    udDBTPMaxParcels.Value = 1;
                    udDBTPParcels.Value = 1;
                    List<CheckBox> checks = new List<CheckBox>
                    { ckDBTPAccountsInherit, ckDBTPCardsInherit, ckDBTPEnableSelection, ckDBTPOpperationTypesInherit,
                      ckDBTPParcels, ckDBTPParcelsInherit, ckDBTPDebtSubcategoriesInherit, ckDBTPValue };
                    foreach (CheckBox check in checks) check.Checked = true;
                    List<FlowLayoutPanel> groupFlows = new List<FlowLayoutPanel>
                    { flDBTPDebtClass, flDBTPUsers, flDBTPPeople, flDBTPAccounts, flDBTPOpperationTypes, flDBTPCards,
                      flDBTPDebtCategories, flDBTPDebtSubcategories1, flDBTPDebtSubcategories2, flDBTPDebtSubcategories3 };
                    foreach (FlowLayoutPanel flow in groupFlows)
                    {
                        string ck;
                        string txt = flow.Name.Substring(2);
                        if (int.TryParse(flow.Name.Substring(flow.Name.Length - 1), out int result))
                        {
                            ck = "ck" + txt.Substring(0, txt.Length - 1) + "Inherit";
                        }
                        else ck = "ck" + txt + "Inherit";
                        Control[] ctl = flDBTPAttributes.Controls.Find(ck, false);
                        if (ctl.Length > 0)
                        {
                            bool inherit = (flDBTPAttributes.Controls[ck] as CheckBox).Checked;
                            (flow.Parent as GroupBox).Visible = !inherit;
                        }
                        else (flow.Parent as GroupBox).Visible = true;
                        (flow.Controls["cb" + txt] as ComboBox).SelectedIndex = -1;
                        (flow.Controls["lb" + txt] as Label).Enabled = false;
                        (flow.Controls["tg" + txt] as TagBox).Clear();
                        (flow.Controls["tg" + txt] as TagBox).Enabled = false;
                        (flow.Controls["tg" + txt] as TagBox).SelectedIndex = -1;
                        (flow.Controls["tb" + txt] as TextBox).Enabled = false;
                        (flow.Controls["rb" + txt + "List"] as RadioButton).Enabled = false;
                        (flow.Controls["rb" + txt + "Command"] as RadioButton).Enabled = false;
                    }
                }
                if (mode.Equals(2))
                {
                    SearchValue = (long)cbDBTPSearch.SelectedValue;
                    sqlCommand = DataBase.BuildCommand(DataSource.FullTable, new string[] { "DebtTypes" });
                    DataTable debtType = DataBase.Populate(sqlCommand).AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(SearchValue))
                        .CopyToDataTable();
                    cbDBTPStatus.SelectedValue = (long)debtType.Rows[0]["Status"];
                    gbDBTPAttributes.Visible = true;
                    tbDBTPDescription.Text = (string)debtType.Rows[0]["Description"];
                    tbDBTPName.Enabled = false;
                    tbDBTPName.Text = (string)debtType.Rows[0]["Name"];
                    tbDBTPObservation.Text = (string)debtType.Rows[0]["Observation"];
                    tbDBTPValue.Text = ((decimal)debtType.Rows[0]["DebtValue"]).ToString("N");
                    udDBTPMaxParcels.Value = (long)debtType.Rows[0]["MaxParcels"];
                    udDBTPParcels.Value = (long)debtType.Rows[0]["Parcels"];
                    List<CheckBox> checks = new List<CheckBox>
                    { ckDBTPAccountsInherit, ckDBTPCardsInherit, ckDBTPEnableSelection, ckDBTPOpperationTypesInherit,
                      ckDBTPParcels, ckDBTPParcelsInherit, ckDBTPDebtSubcategoriesInherit, ckDBTPValue };
                    foreach (CheckBox check in checks) check.Checked = (bool)debtType.Rows[0][MyMethods.GetTag<string>(check, "Column")];
                    List<FlowLayoutPanel> groupFlows = new List<FlowLayoutPanel>
                    { flDBTPDebtClass, flDBTPUsers, flDBTPPeople, flDBTPAccounts, flDBTPOpperationTypes, flDBTPCards,
                      flDBTPDebtCategories, flDBTPDebtSubcategories1, flDBTPDebtSubcategories2, flDBTPDebtSubcategories3 };
                    foreach (FlowLayoutPanel flow in groupFlows)
                    {
                        string ck, table = MyMethods.GetTag<string>(flow, "Table");
                        if (int.TryParse(flow.Name.Substring(flow.Name.Length - 1), out int result))
                        {
                            ck = "ckDBTP" + table.Substring(0, table.Length - 1) + "Inherit";
                        }
                        else ck = "ckDBTP" + table + "Inherit";
                        Control[] ctl = flDBTPAttributes.Controls.Find(ck, false);
                        if (ctl.Length > 0)
                        {
                            bool inherit = (flDBTPAttributes.Controls[ck] as CheckBox).Checked;
                            (flow.Parent as GroupBox).Visible = !inherit;
                        }
                        else (flow.Parent as GroupBox).Visible = true;
                        (flow.Controls["tgDBTP" + table] as TagBox).Clear();
                        enumValue = (long)debtType.Rows[0][table + "Enum"];
                        (flow.Controls["cbDBTP" + table] as ComboBox).SelectedValue = enumValue;
                        string[] customValue = ((string)debtType.Rows[0][table + "Custom"]).Split(char.Parse(";"));
                        if (customValue.Length > 0)
                        {
                            if (customValue[0].StartsWith("[") && customValue[0].EndsWith("]"))
                            {
                                args = customValue[0].Replace("[", "").Replace("]", "").Split(char.Parse(";"));
                                DataTable filterSource = DataBase.Populate(DataBase.BuildCommand(DataSource.FullTable, new string[] { table }));
                                DataTable tagFlowSource = new DataTable();
                                tagFlowSource.Columns.Add("Id", typeof(long));
                                tagFlowSource.Columns.Add("Name", typeof(string));
                                tagFlowSource.Rows.Clear();
                                foreach (string arg in args)
                                {
                                    id = long.Parse(arg);
                                    DataRow dataRow = filterSource.AsEnumerable()
                                        .Where(row => row.Field<long>("Id").Equals(id))
                                        .AsDataView().ToTable(true, "Id", "Name").Rows[0];
                                    tagFlowSource.Rows.Add();
                                    tagFlowSource.Rows[tagFlowSource.Rows.Count - 1].SetField(tagFlowSource.Columns["Id"], dataRow.Field<long>("Id"));
                                    tagFlowSource.Rows[tagFlowSource.Rows.Count - 1].SetField(tagFlowSource.Columns["Name"], dataRow.Field<string>("Name"));
                                }
                                (flow.Controls["tgDBTP" + table] as TagBox).Add(tagFlowSource);
                            }
                            else
                            {
                                (flow.Controls["tbDBTP" + table] as TextBox).Text = customValue[0];
                            }
                        }
                        else
                        {
                            (flow.Controls["tbDBTP" + table] as TextBox).Text = string.Empty;
                        }
                        if (enumValue.Equals(-1))
                        {
                            (flow.Controls["rbDBTP" + table + "List"] as RadioButton).Enabled = true;
                            (flow.Controls["rbDBTP" + table + "Command"] as RadioButton).Enabled = true;
                            if (customValue[0].StartsWith("[") && customValue[0].EndsWith("]"))
                            {
                                (flow.Controls["rbDBTP" + table + "List"] as RadioButton).Checked = true;
                                (flow.Controls["lbDBTP" + table] as Label).Enabled = false;
                                (flow.Controls["tbDBTP" + table] as TextBox).Enabled = false;
                                (flow.Controls["tgDBTP" + table] as TagBox).Enabled = true;
                            }
                            else
                            {
                                (flow.Controls["rbDBTP" + table + "Command"] as RadioButton).Checked = true;
                                (flow.Controls["lbDBTP" + table] as Label).Enabled = true;
                                (flow.Controls["tgDBTP" + table] as TagBox).Enabled = false;
                                (flow.Controls["tbDBTP" + table] as TextBox).Enabled = true;
                            }
                        }
                        else
                        {
                            (flow.Controls["lbDBTP" + table] as Label).Enabled = false;
                            (flow.Controls["tgDBTP" + table] as TagBox).Enabled = false;
                            (flow.Controls["tbDBTP" + table] as TextBox).Enabled = false;
                            (flow.Controls["rbDBTP" + table + "List"] as RadioButton).Enabled = false;
                            (flow.Controls["rbDBTP" + table + "Command"] as RadioButton).Enabled = false;
                        }
                        (flow.Controls["tgDBTP" + table] as TagBox).SelectedIndex = -1;
                    }
                }
                return;
            }
            if (panel.Equals(pnOPTP))
            {
                if (mode.Equals(0))
                {
                    cbOPTPSearch.DataSource = DataBase.Types.OpperationTypes.Copy();
                    cbOPTPSearch.DisplayMember = "Name";
                    cbOPTPSearch.ValueMember = "Id";
                    cbOPTPSearch.SelectedIndex = -1;
                    gbACTPAttributes.Visible = false;
                    gbACTPFormBehavior.Visible = false;
                }
                if (mode.Equals(1))
                {
                    ckOPTPCardEnable.Checked = false;
                    ckOPTPParcelsEnable.Checked = false;
                    gbOPTPAttributes.Visible = true;
                    gbOPTPFormBehavior.Visible = true;
                    gbOPTPFormBehavior.BringToFront();
                    tbOPTPName.Enabled = true;
                    tbOPTPName.Text = string.Empty;
                }
                if (mode.Equals(2))
                {
                    SearchValue = (long)cbOPTPSearch.SelectedValue;
                    DataTable opperationType = DataBase.Types.OpperationTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(SearchValue))
                        .CopyToDataTable();
                    ckOPTPCardEnable.Checked = (bool)opperationType.Rows[0]["CardEnable"];
                    ckOPTPParcelsEnable.Checked = (bool)opperationType.Rows[0]["ParcelsEnable"];
                    gbOPTPAttributes.Visible = true;
                    gbOPTPFormBehavior.Visible = true;
                    gbOPTPFormBehavior.BringToFront();
                    tbOPTPName.Enabled = false;
                    tbOPTPName.Text = (string)opperationType.Rows[0]["Name"];
                }
                return;
            }
        }
        private void CloseClick(object sender, EventArgs e)
        {
            Close();
        }
        private void ClosePanel(object sender, EventArgs e)
        {
            ActivePanel.Visible = false;
            ActivePanel.Dock = DockStyle.None;
            ActivePanel.Location = new Point(0, 1000);
            ActivePanel = null;
            lbSettings.Text = string.Empty;
            lbSettings.Visible = false;
            lnSettings.Visible = false;
            pnCommand.Visible = false;
        }
        private void MenuCheckedChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            Globals.IsRunning = true;
            CheckBox me = sender as CheckBox;
            foreach(SplitContainer sp in flMenu.Controls)
            {
                CheckBox ck = (CheckBox)sp.Panel1.Controls["ck" + sp.Name.Substring(2)];
                if (!me.Equals(ck))
                {
                    ck.Checked = false;
                    sp.Size = sp.MinimumSize;
                    sp.Panel2Collapsed = true;
                }
            }
            Globals.IsRunning = false;
        }
        private void NewClick(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)Controls.Find("cb" + (sender as Button).Name.Substring(2, 4) + "Search", true)[0];
            Panel pn = (Panel)Controls.Find("pn" + (sender as Button).Name.Substring(2, 4), true)[0];
            TextBox tb = (TextBox)Controls.Find("tb" + (sender as Button).Name.Substring(2, 4) + "Name", true)[0];
            Globals.IsRunning = true;
            cb.SelectedIndex = -1;
            SuspendLayout();
            Setup(pn, 1);
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
            tb.Select();
        }
        private void PanelDockChanged(object sender, EventArgs e)
        {
            if ((sender as Panel).Dock.Equals(DockStyle.Fill))
            {
                Globals.IsRunning = true;
                SuspendLayout();
                Setup(sender);
                lbSettings.Text = MyMethods.GetTag<string>(sender, "Text");
                Globals.IsError = false;
                Globals.IsRunning = false;
                ResumeLayout(false);
                PerformLayout();
            }
        }
        private void SearchClick(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)Controls.Find("cb" + (sender as Button).Name.Substring(2), true)[0];
            Panel pn = (Panel)Controls.Find("pn" + (sender as Button).Name.Substring(2, 4), true)[0];
            if (cb.SelectedIndex.Equals(-1)) return;
            Globals.IsRunning = true;
            SuspendLayout();
            Setup(pn, 2);
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        private void ShowPanel(object sender, EventArgs e)
        {
            if (ActivePanel != null) ClosePanel(sender, e);
            Panel panel = null;
            if (sender.GetType().Equals(typeof(ToolStripMenuItem)))
            {
                panel = (Panel)Controls.Find("pn" + (sender as ToolStripMenuItem).Name.Substring(2, 4), true)[0];
            }
            else if (sender.GetType().Equals(typeof(Button)))
            {
                panel = (Panel)Controls.Find("pn" + (sender as Button).Name.Substring(2, 4), true)[0];
            }
            if (panel == null) return;
            ActivePanel = panel;
            panel.Dock = DockStyle.Fill;
            panel.Visible = true;
        }
        private void ACTPOverdraftCheckedChanged(object sender, EventArgs e)
        {
            ckACTPGrace.Enabled = ckACTPFee.Enabled = ckACTPOverdraft.Checked;
            if (!ckACTPOverdraft.Checked) ckACTPGrace.Checked = ckACTPFee.Checked = false; 
        }
        private void ACTPCardCheckedChanged(object sender, EventArgs e)
        {
            tgACTPCardTypes.Enabled = ckACTPCard.Checked;
        }
        private void ACTPEnableOpperationCheckedChanged(object sender, EventArgs e)
        {
            ckACTPEnableCard.Enabled = !ckACTPEnableOpperation.Checked;
            if (ckACTPEnableOpperation.Checked) ckACTPEnableCard.Checked = false;
        }
        private void DBCTSubcategory1CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Globals.IsRunning) return;
            Globals.IsRunning = true;
            DataTable dataSource;
            Dictionary<string, int> dgConfig;
            long id = (long)dgDBCTSubcategory1.SelectedRows[0].Cells["Id"].Value;
            try
            {
                dataSource = DataBase.Types.DebtSubcategory2.AsEnumerable()
                    .Where(row => row.Field<long>("Parent").Equals(id))
                    .CopyToDataTable();
                dgConfig = new Dictionary<string, int> { { "Name", dgDBCTSubcategory2.Width } };
                MyMethods.DataGridViewConfig(dgDBCTSubcategory2, dataSource, dgConfig, 2);
                dgDBCTSubcategory2.Rows[0].Selected = true;
                btDBCTDeleteSub2.Enabled = true;
                btDBCTNewSub3.Enabled = true;
                id = (long)dgDBCTSubcategory2.SelectedRows[0].Cells["Id"].Value;
                try
                {
                    dataSource = DataBase.Types.DebtSubcategory3.AsEnumerable()
                        .Where(row => row.Field<long>("Parent").Equals(id))
                        .CopyToDataTable();
                    dgConfig = new Dictionary<string, int> { { "Name", dgDBCTSubcategory3.Width } };
                    MyMethods.DataGridViewConfig(dgDBCTSubcategory3, dataSource, dgConfig, 2);
                    dgDBCTSubcategory3.Rows[0].Selected = true;
                    btDBCTDeleteSub3.Enabled = true;
                }
                catch
                {
                    btDBCTDeleteSub3.Enabled = false;
                    dgDBCTSubcategory3.DataSource = null;
                }
            }
            catch
            {
                btDBCTDeleteSub2.Enabled = false;
                btDBCTDeleteSub3.Enabled = false;
                btDBCTNewSub3.Enabled = false;
                dgDBCTSubcategory2.DataSource = null;
                dgDBCTSubcategory3.DataSource = null;
            }
            Globals.IsRunning = false;
        }
        private void DBCTSubcategory2CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Globals.IsRunning) return;
            Globals.IsRunning = true;
            long id = (long)dgDBCTSubcategory2.SelectedRows[0].Cells["Id"].Value;
            try
            {
                DataTable dataSource = DataBase.Types.DebtSubcategory3.AsEnumerable()
                    .Where(row => row.Field<long>("Parent").Equals(id))
                    .CopyToDataTable();
                Dictionary<string, int> dgConfig = new Dictionary<string, int> { { "Name", dgDBCTSubcategory3.Width } };
                MyMethods.DataGridViewConfig(dgDBCTSubcategory3, dataSource, dgConfig);
                dgDBCTSubcategory3.Rows[0].Selected = true;
                btDBCTDeleteSub3.Enabled = true;
            }
            catch
            {
                btDBCTDeleteSub3.Enabled = false;
                dgDBCTSubcategory3.DataSource = null;
            }
            Globals.IsRunning = false;
        }
        private void DBTPComboBoxTextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            string txt = (sender as ComboBox).Name.Substring(2);
            if ((sender as ComboBox).SelectedIndex.Equals(-1))
            {
                ((RadioButton)Controls.Find("rb" + txt + "List", true)[0]).Enabled = false;
                ((RadioButton)Controls.Find("rb" + txt + "List", true)[0]).Checked = false;
                ((RadioButton)Controls.Find("rb" + txt + "Command", true)[0]).Enabled = false;
                ((RadioButton)Controls.Find("rb" + txt + "Command", true)[0]).Checked = false;
                ((Label)Controls.Find("lb" + txt, true)[0]).Enabled = false;
                ((TextBox)Controls.Find("tb" + txt, true)[0]).Enabled = false;
                return;
            }
            if (((long)(sender as ComboBox).SelectedValue).Equals(-1))
            {
                ((RadioButton)Controls.Find("rb" + txt + "List", true)[0]).Enabled = true;
                ((RadioButton)Controls.Find("rb" + txt + "List", true)[0]).Checked = true;
                ((RadioButton)Controls.Find("rb" + txt + "Command", true)[0]).Enabled = true;
            }
            else
            {
                ((RadioButton)Controls.Find("rb" + txt + "List", true)[0]).Enabled = false;
                ((RadioButton)Controls.Find("rb" + txt + "List", true)[0]).Checked = false;
                ((RadioButton)Controls.Find("rb" + txt + "Command", true)[0]).Enabled = false;
                ((RadioButton)Controls.Find("rb" + txt + "Command", true)[0]).Checked = false;
                ((Label)Controls.Find("lb" + txt, true)[0]).Enabled = false;
                ((TextBox)Controls.Find("tb" + txt, true)[0]).Enabled = false;
            }
        }
        private void DBTPListButtonCheckedChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            string txt = (sender as RadioButton).Name.Substring(2).Replace("List", "");
            ((TagBox)Controls.Find("tg" + txt, true)[0]).Enabled = (sender as RadioButton).Checked;
            ((Label)Controls.Find("lb" + txt, true)[0]).Enabled = !(sender as RadioButton).Checked;
            ((TextBox)Controls.Find("tb" + txt, true)[0]).Enabled = !(sender as RadioButton).Checked;
        }
        private void DBTPInheritedCheckedChanged(object sender, EventArgs e)
        {
            if (MyMethods.TryGetTag(sender, "Column", out string table))
            {
                table = table.Replace("Inherit", "");
                if (table.Equals("DebtSubcategories"))
                {
                    gbDBTPDebtSubcategories3.Visible = gbDBTPDebtSubcategories2.Visible = gbDBTPDebtSubcategories1.Visible = !(sender as CheckBox).Checked;
                }
                else ((GroupBox)Controls.Find("gbDBTP" + table, true)[0]).Visible = !(sender as CheckBox).Checked;
            }
        }
        private void DBTPMaxParcelsValueChanged(object sender, EventArgs e)
        {
            udDBTPParcels.Maximum = (sender as NumericUpDown).Value;
        }
        private void DBTPParcelsCheckedChanged(object sender, EventArgs e)
        {
            udDBTPMaxParcels.Enabled = (sender as CheckBox).Checked;
            if (!(sender as CheckBox).Checked) udDBTPParcels.Maximum = 100;
            else udDBTPParcels.Maximum = udDBTPMaxParcels.Value;
        }
        private void DBTPTagBoxResize(object sender, EventArgs e)
        {
            TagBox tg = sender as TagBox;
            GroupBox gb = (GroupBox)Controls.Find("gb" + tg.Name.Substring(2), true)[0];
            gb.Size = new Size(gb.Width, 180 + tg.Height);
        }
    }
}
