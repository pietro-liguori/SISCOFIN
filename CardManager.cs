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
    public partial class CardManager : Form
    {
        #region Declaração de variáveis
        private static long BootMode;
        #endregion
        #region Inicialização do formulário
        /// <summary>
        /// 
        /// </summary>
        public CardManager(long bootMode)
        {
            InitializeComponent();
            BootMode = bootMode;
            Globals.IsRunning = true;
            Text = "SISCOFIN v" + Globals.Version;
            //
            // cbAccount 
            //
            var accountList = from accounts in DataBase.Tables.Accounts.AsEnumerable()
                           join accountTypes in DataBase.Types.AccountTypes.AsEnumerable()
                           on (long)accounts["Class"] equals (long)accountTypes["Id"]
                           where (bool)accountTypes["Card"]
                           orderby accounts["Name"]
                           select new
                           {
                               Id = (long)accounts["Id"],
                               Name = (string)accounts["Name"],
                           };
            cbAccount.DataSource = accountList.ToList();
            cbAccount.DisplayMember = "Name";
            cbAccount.ValueMember = "Id";
            cbAccount.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbAccount.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbAccount.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbAccount.Validated += new EventHandler(AccountValidated);
            //
            // cbFeeUnit 
            //
            SortedDictionary<string, string> list = new SortedDictionary<string, string>
            {
                { "A", "% AO ANO" },
                { "D", "% AO DIA" },
                { "M", "% AO MÊS" }
            };
            cbFeeUnit.DataSource = new BindingSource(list, null);
            cbFeeUnit.ValueMember = "Key";
            cbFeeUnit.DisplayMember = "Value";
            cbFeeUnit.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbFeeUnit.Validated += new EventHandler(FeeUnitValidated);
            //
            // cbFilterType
            //
            SortedDictionary<string, string> filter = new SortedDictionary<string, string>()
            {
                {"Bandeira", "BANDEIRA"},
                {"Tipo", "TIPO"},
                {"Número,", "NÚMERO"}
            };
            cbFilterType.DataSource = new BindingSource(filter, null);
            cbFilterType.DisplayMember = "Value";
            cbFilterType.ValueMember = "Key";
            cbFilterType.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbFilterType.SelectedValue = "Número";
            //
            // cbFlag 
            //
            cbFlag.DataSource = DataBase.Types.CardFlags.Copy();
            cbFlag.DisplayMember = "Name";
            cbFlag.ValueMember = "Id";
            cbFlag.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbFlag.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbFlag.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbFlag.Validated += new EventHandler(FlagValidated);
            //
            // cbType 
            //
            cbType.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbType.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbType.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            cbType.Validated += new EventHandler(TypeValidated);
            //
            // ckSearch
            //
            ckSearch.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            //
            // dgSearch 
            //
            dgSearch.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgSearch.CellMouseDown += new DataGridViewCellMouseEventHandler(EditCard);
            //
            // dpExpiration 
            //
            dpExpiration.Validated += new EventHandler(ExpirationValidated);
            //
            // mbNumber 
            //
            mbNumber.Validated += new EventHandler(NumberValidated);
            //
            // spSearch
            //
            spSearch.MaximumSize = new Size(750, 466);
            spSearch.MinimumSize = new Size(750, 50);
            spSearch.SplitterDistance = 49;
            spSearch.SplitterWidth = 1;
            //
            // tbClosingDay 
            //
            tbClosingDay.KeyPress += new KeyPressEventHandler(MyEvents.OnlyNumbers); 
            tbClosingDay.Validated += new EventHandler(ClosingDayValidated);
            //
            // tbCVV
            //
            tbCVV.Validated += new EventHandler(CvvValidated);
            //
            // tbDueDay 
            //
            tbDueDay.KeyPress += new KeyPressEventHandler(MyEvents.OnlyNumbers);
            tbDueDay.Validated += new EventHandler(DueDayValidated);
            //
            // tbFee 
            //
            tbFee.Enter += new EventHandler(MyEvents.SelectionStartOnEnd);
            tbFee.KeyDown += new KeyEventHandler(MyEvents.DecimalMask);
            tbFee.Validated += new EventHandler(FeeValidated);
            //
            // tbOverdraft 
            //
            tbCreditLimit.Enter += new EventHandler(MyEvents.SelectionStartOnEnd);
            tbCreditLimit.KeyDown += new KeyEventHandler(MyEvents.DecimalMask);
            tbCreditLimit.Validated += new EventHandler(CreditLimitValidated);
            Globals.IsRunning = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadManager(object sender, EventArgs e)
        {
            SuspendLayout();
            Globals.IsRunning = true;
            Setup(BootMode);
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        #region Métodos
        /// <summary>
        /// 
        /// </summary>
        public void Setup(long mode)
        {
            bool isSearch = false;
            if (mode.Equals(0)) isSearch = true;
            Card.Clear();
            cbFilterType.SelectedIndex = 1;
            cbType.DataSource = DataBase.Types.CardTypes.Copy();
            cbType.DisplayMember = "Name";
            cbType.ValueMember = "Id";
            ckSearch.Checked = false;
            pnManager.Visible = !isSearch;
            spSearch.Visible = isSearch;
            spSearch.Panel2Collapsed = true;
            spSearch.Size = spSearch.MinimumSize;
            tbFilter.Text = string.Empty;
            switch (Globals.SelectedCard)
            {
                case -1:
                    if (!Globals.SelectedAccount.Equals(-1))
                    {
                        cbAccount.SelectedValue = Globals.SelectedAccount;
                        cbAccount.Enabled = false;
                        Card.Account = (long)cbAccount.SelectedValue;
                    }
                    else
                    {
                        cbAccount.SelectedIndex = -1;
                        cbAccount.Enabled = true;
                    }
                    brTools.Size = new Size(650, 0);
                    brTools.Visible = false;
                    cbFeeUnit.SelectedValue = "M";
                    cbFeeUnit.Enabled = true;
                    cbFlag.SelectedIndex = -1;
                    cbFlag.Enabled = true;
                    cbType.DisplayMember = "Name";
                    cbType.ValueMember = "Id";
                    cbType.SelectedIndex = -1;
                    cbType.Enabled = true;
                    dpExpiration.Value = DateTime.Today;
                    dpExpiration.Enabled = true;
                    dpExpiration.BackColor = SystemColors.Window;
                    dgSearch.Size = dgSearch.MinimumSize;
                    lbTitle.Text = "Novo Cartão";
                    mbNumber.Text = string.Empty;
                    mbNumber.Enabled = true;
                    mbNumber.BackColor = SystemColors.Window;
                    tbClosingDay.Text = string.Empty;
                    tbCVV.Text = string.Empty;
                    tbCVV.Enabled = true;
                    tbCVV.BackColor = SystemColors.Window;
                    tbDueDay.Text = string.Empty;
                    tbFee.Text = "0,00";
                    tbCreditLimit.Text = "0,00";
                    if (mode.Equals(0)) tbFilter.Select();
                    else cbAccount.Select();
                    break;
                default:
                    brTools.Size = new Size(650, 40);
                    brTools.Visible = true;
                    if (!Globals.SelectedAccount.Equals(-1))
                    {
                        cbAccount.SelectedValue = Globals.SelectedAccount;
                        cbAccount.Enabled = false;
                        Card.Account = (long)cbAccount.SelectedValue;
                    }
                    else
                    {
                        cbAccount.SelectedIndex = -1;
                        cbAccount.Enabled = true;
                    }
                    cbType.Enabled = false;
                    cbType.SelectedValue = DataBase.Tables.Cards.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedCard))
                        .CopyToDataTable().Rows[0].Field<long>("Type");
                    Card.Type = (long)cbType.SelectedValue;
                    bool hasCreditLimit = DataBase.Types.CardTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Card.Type))
                        .CopyToDataTable().Rows[0].Field<bool>("CreditLimit");
                    bool hasExpiration = DataBase.Types.CardTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Card.Type))
                        .CopyToDataTable().Rows[0].Field<bool>("Expiration");
                    bool hasFee = DataBase.Types.CardTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Card.Type))
                        .CopyToDataTable().Rows[0].Field<bool>("Fee");
                    bool hasFlag = DataBase.Types.CardTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Card.Type))
                        .CopyToDataTable().Rows[0].Field<bool>("Flag");
                    bool hasDueDay = DataBase.Types.CardTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Card.Type))
                        .CopyToDataTable().Rows[0].Field<bool>("DueDay");
                    bool hasClosingDay = DataBase.Types.CardTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Card.Type))
                        .CopyToDataTable().Rows[0].Field<bool>("ClosingDay");
                    bool hasCVV = DataBase.Types.CardTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Card.Type))
                        .CopyToDataTable().Rows[0].Field<bool>("CVV");
                    cbFeeUnit.Enabled = hasFee;
                    cbFeeUnit.SelectedValue = DataBase.Tables.Cards.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedCard))
                        .CopyToDataTable().Rows[0].Field<string>("FeeUnit");
                    Card.FeeUnit = cbFeeUnit.SelectedValue.ToString();
                    cbFlag.Enabled = false;
                    if (!hasFlag)
                    {
                        cbFlag.SelectedIndex = -1;
                        Card.Flag = 0;
                    }
                    else
                    {
                        cbFlag.SelectedValue = DataBase.Tables.Cards.AsEnumerable()
                            .Where(row => row.Field<long>("Id").Equals(Globals.SelectedCard))
                            .CopyToDataTable().Rows[0].Field<long>("Flag");
                        Card.Flag = (long)cbFlag.SelectedValue;
                    }
                    dpExpiration.BackColor = SystemColors.Control;
                    dpExpiration.Enabled = false;
                    if (!hasExpiration)
                    {
                        dpExpiration.Text = string.Empty;
                        Card.Expiration = string.Empty;
                    }
                    else
                    {
                        dpExpiration.Value = DataBase.Tables.Cards.AsEnumerable()
                            .Where(row => row.Field<long>("Id").Equals(Globals.SelectedCard))
                            .CopyToDataTable().Rows[0].Field<DateTime>("Expiration");
                        Card.Expiration = dpExpiration.Value.ToString("yyyy-MM-dd");
                    }
                    dgSearch.Size = dgSearch.MinimumSize;
                    lbTitle.Text = "Editar Cartão";
                    mbNumber.BackColor = SystemColors.Control;
                    mbNumber.Enabled = false;
                    mbNumber.Text = DataBase.Tables.Cards.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedCard))
                        .CopyToDataTable().Rows[0].Field<string>("Name");
                    pnManager.Visible = true;
                    spSearch.Panel2Collapsed = true;
                    spSearch.Size = new Size(750, 50);
                    var statusList = from cards in DataBase.Tables.Cards.AsEnumerable()
                                      join status in DataBase.Types.Status.AsEnumerable()
                                      on (long)cards["Status"] equals (long)status["Id"]
                                      where cards["Id"].Equals(Globals.SelectedCard)
                                      select new
                                      {
                                          Status = (long)cards["Status"],
                                          Name = (string)status["MName"]
                                      };
                    tbStatus.Text = statusList.ToList()[0].Name;
                    Card.Status = statusList.ToList()[0].Status;
                    if (!hasClosingDay)
                    {
                        tbClosingDay.BackColor = SystemColors.Control;
                        tbClosingDay.Text = string.Empty;
                        Card.ClosingDay = 0;
                    }
                    else
                    {
                        tbClosingDay.BackColor = SystemColors.Window;
                        tbClosingDay.Text = DataBase.Tables.Cards.AsEnumerable()
                            .Where(row => row.Field<long>("Id").Equals(Globals.SelectedCard))
                            .CopyToDataTable().Rows[0].Field<long>("ClosingDay").ToString();
                        Card.ClosingDay = long.Parse(tbClosingDay.Text);
                    }
                    if (!hasCreditLimit)
                    {
                        tbCreditLimit.BackColor = SystemColors.Control;
                        tbCreditLimit.Text = "0,00";
                        Card.CreditLimit = 0;
                    }
                    else
                    {
                        tbCreditLimit.BackColor = SystemColors.Window;
                        tbCreditLimit.Text = DataBase.Tables.Cards.AsEnumerable()
                            .Where(row => row.Field<long>("Id").Equals(Globals.SelectedCard))
                            .CopyToDataTable().Rows[0].Field<decimal>("CreditLimit").ToString("#,##0.00");
                        Card.CreditLimit = decimal.Parse(tbCreditLimit.Text);
                    }
                    tbCVV.BackColor = SystemColors.Control;
                    tbCVV.Enabled = false;
                    if (!hasCVV)
                    {
                        tbCVV.Text = string.Empty;
                        Card.CVV = 0;
                    }
                    else
                    {
                        tbCVV.Text = DataBase.Tables.Cards.AsEnumerable()
                            .Where(row => row.Field<long>("Id").Equals(Globals.SelectedCard))
                            .CopyToDataTable().Rows[0].Field<long>("CVV").ToString();
                        Card.CVV = long.Parse(tbCVV.Text);
                    }
                    if (!hasDueDay)
                    {
                        tbDueDay.BackColor = SystemColors.Control;
                        tbDueDay.Text = string.Empty;
                        Card.DueDay = 0;
                    }
                    else
                    {
                        tbDueDay.BackColor = SystemColors.Window;
                        tbDueDay.Text = DataBase.Tables.Cards.AsEnumerable()
                            .Where(row => row.Field<long>("Id").Equals(Globals.SelectedCard))
                            .CopyToDataTable().Rows[0].Field<long>("DueDay").ToString();
                        Card.DueDay = long.Parse(tbDueDay.Text);
                    }
                    if (!hasFee)
                    {
                        tbFee.BackColor = SystemColors.Control;
                        tbFee.Text = "0,00";
                        Card.Fee = 0;
                    }
                    else
                    {
                        tbFee.BackColor = SystemColors.Window;
                        tbFee.Text = (DataBase.Tables.Cards.AsEnumerable()
                            .Where(row => row.Field<long>("Id").Equals(Globals.SelectedCard))
                            .CopyToDataTable().Rows[0].Field<decimal>("Fee") * 100).ToString("#,##0.00");
                        Card.Fee = decimal.Parse(tbFee.Text) / 100;
                    }
                    break;
            }
            Card.HasChanges = false;
        }
        #endregion
        #region Eventos
        #region Configuração do formulário
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountTextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning || BootMode.Equals(1)) return;
            Globals.IsRunning = true;
            SuspendLayout();
            ComboBox me = (ComboBox)sender;
            Card.Clear();
            cbFlag.SelectedIndex = -1;
            cbFeeUnit.SelectedValue = "M";
            cbType.SelectedIndex = -1;
            dpExpiration.Value = DateTime.Today;
            mbNumber.Text = string.Empty;
            tbClosingDay.Text = string.Empty;
            tbCreditLimit.Text = "0,00";
            tbCVV.Text = string.Empty;
            tbDueDay.Text = string.Empty;
            tbFee.Text = "0,00";
            Card.HasChanges = true;
            if (me.SelectedIndex.Equals(-1))
            {
                cbType.DataSource = DataBase.Types.CardTypes.Copy();
                cbType.DisplayMember = "Name";
                cbType.ValueMember = "Id";
                cbType.Enabled = false;
            }
            else
            {
                DataTable dataSource = DataBase.Types.CardTypes.Copy();
                long accountType = DataBase.Tables.Accounts.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                    .CopyToDataTable().Rows[0].Field<long>("Type");
                string[] cardType = DataBase.Types.AccountTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals(accountType))
                    .CopyToDataTable().Rows[0].Field<string>("CardType").Split(char.Parse(";"));
                foreach (DataRow row in dataSource.Rows)
                {
                    for (int i = 0; i < cardType.Length; i++)
                    {
                        if (row.Field<long>("Id").Equals(long.Parse(cardType[i]))) break;
                        if (i.Equals(cardType.Length - 1)) row.Delete();
                    }
                }
                cbType.DataSource = dataSource;
                cbType.DisplayMember = "Name";
                cbType.ValueMember = "Id";
                cbType.Enabled = true;
                cbType.SelectedIndex = -1;
            }
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeTextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning || BootMode.Equals(1)) return;
            Globals.IsRunning = true;
            SuspendLayout();
            ComboBox me = (ComboBox)sender;
            Globals.SelectedAccount = Card.Account;
            Card.Clear();
            Card.Account = Globals.SelectedAccount;
            cbFlag.SelectedIndex = -1;
            cbFeeUnit.SelectedValue = "M";
            dpExpiration.Value = DateTime.Today;
            mbNumber.Text = string.Empty;
            tbClosingDay.Text = string.Empty;
            tbCreditLimit.Text = "0,00";
            tbCVV.Text = string.Empty;
            tbDueDay.Text = string.Empty;
            tbFee.Text = "0,00";
            if (me.SelectedIndex.Equals(-1))
            {
                cbFlag.Enabled = false;
                cbFeeUnit.Enabled = false;
                dpExpiration.BackColor = SystemColors.Control;
                dpExpiration.Enabled = false;
                mbNumber.BackColor = SystemColors.Control;
                mbNumber.Enabled = false;
                tbClosingDay.BackColor = SystemColors.Control;
                tbClosingDay.Enabled = false;
                tbCreditLimit.BackColor = SystemColors.Control;
                tbCreditLimit.Enabled = false;
                tbCVV.BackColor = SystemColors.Control;
                tbCVV.Enabled = false;
                tbDueDay.BackColor = SystemColors.Control;
                tbDueDay.Enabled = false;
                tbFee.BackColor = SystemColors.Control;
                tbFee.Enabled = false;
            }
            else
            {
                bool hasCreditLimit = DataBase.Types.CardTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                    .CopyToDataTable().Rows[0].Field<bool>("CreditLimit");
                bool hasExpiration = DataBase.Types.CardTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                    .CopyToDataTable().Rows[0].Field<bool>("Expiration");
                bool hasFee = DataBase.Types.CardTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                    .CopyToDataTable().Rows[0].Field<bool>("Fee");
                bool hasFlag = DataBase.Types.CardTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                    .CopyToDataTable().Rows[0].Field<bool>("Flag");
                bool hasDueDay = DataBase.Types.CardTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                    .CopyToDataTable().Rows[0].Field<bool>("DueDay");
                bool hasClosingDay = DataBase.Types.CardTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                    .CopyToDataTable().Rows[0].Field<bool>("ClosingDay");
                bool hasCVV = DataBase.Types.CardTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                    .CopyToDataTable().Rows[0].Field<bool>("CVV");
                if (!hasCreditLimit) tbCreditLimit.BackColor = SystemColors.Control;
                else tbCreditLimit.BackColor = SystemColors.Window;
                tbCreditLimit.Enabled = hasCreditLimit;
                if (!hasExpiration) dpExpiration.BackColor = SystemColors.Control;
                else dpExpiration.BackColor = SystemColors.Window;
                dpExpiration.Enabled = hasExpiration;
                if (!hasFee) tbFee.BackColor = SystemColors.Control;
                else tbFee.BackColor = SystemColors.Window;
                tbFee.Enabled = hasFee;
                cbFlag.Enabled = hasFlag;
                if (!hasDueDay) tbDueDay.BackColor = SystemColors.Control;
                else tbDueDay.BackColor = SystemColors.Window;
                tbDueDay.Enabled = hasDueDay;
                if (!hasClosingDay) tbClosingDay.BackColor = SystemColors.Control;
                else tbClosingDay.BackColor = SystemColors.Window;
                tbClosingDay.Enabled = hasClosingDay;
                if (!hasCVV) tbCVV.BackColor = SystemColors.Control;
                else tbCVV.BackColor = SystemColors.Window;
                tbCVV.Enabled = hasCVV;
            }
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        #region Botões
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelClick(object sender, EventArgs e)
        {
            if (Globals.SelectedCard.Equals(-1) && Card.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            if (!Globals.SelectedCard.Equals(-1) && Card.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("Existem alterações não salvas! As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            switch (BootMode)
            {
                case 1:
                    Close();
                    break;
                default:
                    SuspendLayout();
                    Globals.IsRunning = true;
                    Globals.SelectedAccount = -1;
                    Globals.SelectedCard = -1;
                    Globals.SelectedPerson = -1;
                    Globals.SelectedUser = -1;
                    Setup(0);
                    Globals.IsRunning = false;
                    ResumeLayout(false);
                    PerformLayout();
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseClick(object sender, EventArgs e)
        {
            if (Globals.SelectedCard.Equals(-1) && Card.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            if (!Globals.SelectedCard.Equals(-1) && Card.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("Existem alterações não salvas! As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            Globals.SelectedAccount = -1;
            Globals.SelectedCard = -1;
            Globals.SelectedPerson = -1;
            Globals.SelectedUser = -1;
            Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCard(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Globals.IsRunning || e.ColumnIndex < 4) return;
            Globals.IsRunning = true;
            Globals.SelectedCard = (long)dgSearch.Rows[e.RowIndex].Cells[0].Value;
            Globals.SelectedAccount = DataBase.Tables.Cards.AsEnumerable()
                .Where(row => row.Field<long>("Id").Equals(Globals.SelectedCard))
                .CopyToDataTable().Rows[0].Field<long>("Account");
            Setup(1);
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCard(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            SuspendLayout();
            Globals.IsRunning = true;
            Globals.SelectedCard = -1;
            Setup(1);
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveClick(object sender, EventArgs e)
        {
            if (Globals.IsRunning || !Card.HasChanges) return;
            if (Card.Account.Equals(-1) || Card.Type.Equals(-1) || Card.Flag.Equals(-1) ||
                string.IsNullOrWhiteSpace(Card.Number) || Card.ClosingDay.Equals(-1) || 
                Card.DueDay.Equals(-1) || Card.CVV.Equals(-1) || Card.CreditLimit.Equals(0) || 
                Card.Fee.Equals(0) || string.IsNullOrWhiteSpace(Card.Expiration))
            {
                MessageBox.Show("Campos obrigatórios em branco.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyMethods.SelectFirstControl(cbAccount, true, 15);
                return;
            }
            DialogResult dialogResult;
            switch (Globals.SelectedCard)
            {
                case -1:
                    dialogResult = MessageBox.Show("Confirmar o cadastro do cartão?\n\n" +
                        "Final " + Card.Number.Substring(14) + "\n" + cbAccount.Text,
                        "Novo cartão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
                default:
                    dialogResult = MessageBox.Show("Deseja atualizar os dados do cartão?\n\n" +
                        "Final " + Card.Number.Substring(14) + "\n" + cbAccount.Text,
                        "Editar cartão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
            }
            if (!dialogResult.Equals(DialogResult.Yes)) return;
            Globals.IsRunning = true;
            SuspendLayout();
            if (!Globals.SelectedCard.Equals(-1)) Card.Update();
            else
            {
                Card.Insert();
                long standardCard = DataBase.Tables.Accounts.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals(Card.Account))
                    .CopyToDataTable().Rows[0].Field<long>("StandardCard");
                string account = DataBase.Tables.Accounts.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals(Card.Account))
                    .CopyToDataTable().Rows[0].Field<string>("Name");
                if (standardCard.Equals(-1)) Account.ChangeStandardCard();
                else
                {
                    dialogResult = MessageBox.Show("Deseja tornar este cartão em o cartão padrão " +
                        "para a conta: " + account + "?",
                        "Novo cartão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult.Equals(DialogResult.Yes)) Account.ChangeStandardCard();
                }
            }
            MessageBox.Show("Cadastro do cartão realizado com sucesso!", "Novo cartão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (BootMode.Equals(2)) Close();
            Setup(1);
            Globals.IsError = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchClick(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            if (!ckSearch.Checked) ckSearch.Checked = true;
            Globals.IsRunning = true;
            SuspendLayout();
            DataTable filterData = DataBase.Populate(Properties.Resources.sql_dgCards);
            if (!string.IsNullOrWhiteSpace(tbFilter.Text) && cbFilterType.SelectedIndex != -1)
            {
                try
                {
                    filterData = filterData.AsEnumerable()
                        .OrderBy(row => row.Field<string>(cbFilterType.SelectedValue.ToString()))
                        .Where(row => row.Field<string>(cbFilterType.ValueMember).Contains(tbFilter.Text.Trim()))
                        .CopyToDataTable();
                }
                catch { filterData = null; }
            }
            if (filterData != null)
            {
                if (filterData.Rows.Count > 0)
                {
                    dgSearch.Rows.Clear();
                    dgSearch.Size = dgSearch.MaximumSize;
                    for (int i = 0; i < filterData.Rows.Count; i++)
                    {
                        dgSearch.Rows.Add();
                        dgSearch.Rows[i].Cells[0].Value = filterData.Rows[i].Field<long>("Id");
                        string card = filterData.Rows[i].Field<string>("Número");
                        dgSearch.Rows[i].Cells[1].Value = "****" + card.Substring(card.Length - 4, 4);
                        dgSearch.Rows[i].Cells[2].Value = filterData.Rows[i].Field<string>("Tipo");
                        dgSearch.Rows[i].Cells[3].Value = filterData.Rows[i].Field<string>("Bandeira");
                    }
                    lbNoCard.Visible = false;
                    goto Found;
                }
            }
            dgSearch.Rows.Clear();
            dgSearch.Size = dgSearch.MinimumSize;
            lbNoCard.Visible = true;
            tbFilter.Select();
Found:
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        #region Validação de dados
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Card.Account = (long)(sender as ComboBox).SelectedValue;
            else Card.Account = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClosingDayValidated(object sender, EventArgs e)
        {
            if (long.TryParse((sender as TextBox).Text, out long value)) Card.ClosingDay = value;
            else Card.ClosingDay = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CvvValidated(object sender, EventArgs e)
        {
            if (long.TryParse((sender as TextBox).Text, out long value)) Card.CVV = value;
            else Card.CVV = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DueDayValidated(object sender, EventArgs e)
        {
            if (long.TryParse((sender as TextBox).Text, out long value)) Card.DueDay = value;
            else Card.DueDay = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpirationValidated(object sender, EventArgs e)
        {
            Card.Expiration = (sender as DateTimePicker).Value.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FeeValidated(object sender, EventArgs e)
        {
            if (decimal.TryParse((sender as TextBox).Text, out decimal value)) Card.Fee = value;
            else Card.Fee = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FeeUnitValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Card.FeeUnit = (string)(sender as ComboBox).SelectedValue;
            else Card.FeeUnit = "M";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlagValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Card.Flag = (long)(sender as ComboBox).SelectedValue;
            else Card.Flag = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidated(object sender, EventArgs e)
        {
            Card.Number = (sender as MaskedTextBox).Text;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreditLimitValidated(object sender, EventArgs e)
        {
            if (decimal.TryParse((sender as TextBox).Text, out decimal value)) Card.CreditLimit = value;
            else Card.CreditLimit = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Card.Type = (long)(sender as ComboBox).SelectedValue;
            else Card.Type = -1;
        }
        #endregion
        #endregion

    }
}
