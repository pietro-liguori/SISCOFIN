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
    public partial class AccountManager : Form
    {
        #region Declarações de variáveis
        /// <summary>
        /// 
        /// </summary>
        private static long BootMode;
        #endregion
        #region Inicialização da classe AccountManager
        /// <summary>
        /// 
        /// </summary>
        public AccountManager(long bootMode)
        {
            InitializeComponent();
            BootMode = bootMode;
            Text = "SISCOFIN v" + Globals.Version;
            Globals.IsRunning = true;
            //
            // cbAccountClass
            //
            cbClass.DataSource = DataBase.Types.AccountClass;
            cbClass.DisplayMember = "Name";
            cbClass.ValueMember = "Id";
            cbClass.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbClass.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbClass.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            //
            // cbType
            //
            cbType.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbType.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbType.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            //
            // cbFilterType
            //
            SortedDictionary<string, string> filter = new SortedDictionary<string, string>()
            {
                {"Nome", "NOME"},
                {"Classe", "CLASSE"},
                {"Conta", "CONTA"},
                {"Número,", "NÚMERO"}
            };
            cbFilterType.DataSource = new BindingSource(filter, null);
            cbFilterType.DisplayMember = "Value";
            cbFilterType.ValueMember = "Key";
            cbFilterType.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbFilterType.SelectedValue = "Nome";
            //
            // cbBank
            //
            var bankList = from banks in DataBase.Tables.Banks.AsEnumerable()
                           join people in DataBase.Tables.People.AsEnumerable()
                           on (long)banks["Person"] equals (long)people["Id"]
                           orderby people["Name"]
                           select new
                           {
                               Id = (long)banks["Id"],
                               Name = (string)people["Name"],
                               BankCode = (string)banks["BankCode"]
                           };
            cbBank.DataSource = bankList.ToList();
            cbBank.DisplayMember = "Name";
            cbBank.ValueMember = "Id";
            cbBank.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbBank.KeyPress += new KeyPressEventHandler(MyEvents.UpperCharChasing);
            cbBank.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            //
            // cbFeeUnit
            //
            SortedDictionary<string, string> list = new SortedDictionary<string, string>
            {
                { "A", "% AO ANO" },
                { "D", "% AO DIA" },
                { "M", "% AO MÊS" }
            };
            cbFeeUnit.DataSource = new BindingSource(list,null);
            cbFeeUnit.ValueMember = "Key";
            cbFeeUnit.DisplayMember = "Value";
            cbFeeUnit.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            //
            // cbFilterType
            //
            cbFilterType.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            //
            // cbGraceUnit
            //
            list = new SortedDictionary<string, string>
            {
                { "A", "ANOS" },
                { "D", "DIAS" },
                { "M", "MESES" }
            };
            cbGraceUnit.DataSource = new BindingSource(list, null);
            cbGraceUnit.ValueMember = "Key";
            cbGraceUnit.DisplayMember = "Value";
            cbGraceUnit.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            //
            // cbUser
            //
            var userList = from users in DataBase.Tables.Users.AsEnumerable()
                         join people in DataBase.Tables.People.AsEnumerable()
                         on (long)users["Person"] equals (long)people["Id"]
                         orderby people["Name"]
                         select new
                         {
                             Id = (long)users["Id"],
                             Name = (string)people["Name"]
                         };
            cbUser.DataSource = userList.ToList();
            cbUser.DisplayMember = "Name";
            cbUser.ValueMember = "Id";
            //
            // ckAccountInfo
            //
            ckGenInfo.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            //
            // ckCards
            //
            ckCards.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            //
            // ckSearch
            //
            ckSearch.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            //
            // dgCards
            //
            dgCards.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgCards.CellMouseDown += new DataGridViewCellMouseEventHandler(EditCard);
            //
            // dgSearch
            //
            dgSearch.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgSearch.CellMouseDown += new DataGridViewCellMouseEventHandler(EditAccount);
            //
            // spAccountInfo
            //
            spGenInfo.MaximumSize = new Size(746, 380);
            spGenInfo.MinimumSize = new Size(746, 40);
            spGenInfo.SplitterDistance = 39;
            spGenInfo.SplitterWidth = 1;
            //
            // spCards
            //
            spCards.MaximumSize = new Size(746, 350);
            spCards.MinimumSize = new Size(746, 40);
            spCards.SplitterDistance = 39;
            spCards.SplitterWidth = 1;
            //
            // spSearch
            //
            spSearch.MaximumSize = new Size(750, 466);
            spSearch.MinimumSize = new Size(750, 50);
            spSearch.SplitterDistance = 49;
            spSearch.SplitterWidth = 1;
            //
            // tbAgency
            //
            tbAgency.KeyPress += new KeyPressEventHandler(MyEvents.NoLetters);
            //
            // tbBalance
            //
            tbBalance.Enter += new EventHandler(MyEvents.SelectionStartOnEnd);
            tbBalance.KeyDown += new KeyEventHandler(MyEvents.DecimalMask);
            //
            // tbFee
            //
            tbFee.Enter += new EventHandler(MyEvents.SelectionStartOnEnd);
            tbFee.KeyDown += new KeyEventHandler(MyEvents.DecimalMask);
            //
            // tbGrace
            //
            tbGrace.KeyPress += new KeyPressEventHandler(MyEvents.OnlyNumbers);
            //
            // tbNumber
            //
            tbNumber.KeyPress += new KeyPressEventHandler(MyEvents.NoLetters);
            //
            // tbOverdraft
            //
            tbOverdraft.Enter += new EventHandler(MyEvents.SelectionStartOnEnd);
            tbOverdraft.KeyDown += new KeyEventHandler(MyEvents.DecimalMask);
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
            bool isSearch;
            if (mode.Equals(0)) isSearch = true;
            else isSearch = false;
            Account.Clear();
            cbType.DataSource = DataBase.Types.AccountTypes;
            cbType.DisplayMember = "Name";
            cbType.ValueMember = "Id";
            cbFilterType.SelectedIndex = 1;
            ckSearch.Checked = false;
            dgSearch.Rows.Clear();
            dgSearch.Size = dgSearch.MinimumSize;
            dgCards.Rows.Clear();
            pnManager.Visible = !isSearch;
            spSearch.Visible = isSearch;
            spSearch.Panel2Collapsed = true;
            spSearch.Size = spSearch.MinimumSize;
            tbFilter.Text = string.Empty;
            switch (Globals.SelectedAccount)
            {
                case -1:
                    brTools.Size = new Size(644, 0);
                    brTools.Visible = false;
                    cbClass.Enabled = true;
                    cbClass.SelectedIndex = -1;
                    cbType.Enabled = false;
                    cbType.SelectedIndex = -1;
                    cbFeeUnit.Enabled = true;
                    cbFeeUnit.SelectedValue = "M";
                    cbGraceUnit.Enabled = true;
                    cbGraceUnit.SelectedValue = "D";
                    cbBank.Enabled = true;
                    cbBank.SelectedIndex = -1;
                    cbUser.Enabled = true;
                    cbUser.SelectedIndex = -1;
                    ckGenInfo.Checked = true;
                    ckCards.Checked = false;
                    dgCards.Size = dgCards.MinimumSize;
                    lbTitle.Text = "Nova Conta";
                    tbName.Text = string.Empty;
                    tbAgency.BackColor = SystemColors.Control;
                    tbAgency.Enabled = false;
                    tbAgency.Text = string.Empty;
                    tbBalance.BackColor = SystemColors.Window;
                    tbBalance.Enabled = true;
                    tbBalance.Text = "0,00";
                    tbBankCode.Text = string.Empty;
                    tbFee.BackColor = SystemColors.Control;
                    tbFee.Enabled = false;
                    tbFee.Text = "0,00";
                    tbGrace.BackColor = SystemColors.Control;
                    tbGrace.Enabled = false;
                    tbGrace.Text = string.Empty;
                    tbNumber.BackColor = SystemColors.Control;
                    tbNumber.Enabled = false;
                    tbNumber.Text = string.Empty;
                    tbOverdraft.BackColor = SystemColors.Control;
                    tbOverdraft.Enabled = false;
                    tbOverdraft.Text = "0,00";
                    lbNoAccount.Visible = false;
                    lbNoCard.Visible = false;
                    spGenInfo.Panel2Collapsed = false;
                    spGenInfo.Size = spGenInfo.MaximumSize;
                    spCards.Panel2Collapsed = true;
                    spCards.Size = spCards.MinimumSize;
                    spCards.Visible = false;
                    if (isSearch) tbFilter.Select();
                    else cbClass.Select();
                    break;
                default:
                    brTools.Size = new Size(644, 40);
                    brTools.Visible = true;
                    cbBank.Enabled = false;
                    try
                    {
                        cbBank.SelectedValue = DataBase.Tables.Accounts.AsEnumerable()
                                                    .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                                                    .CopyToDataTable().Rows[0].Field<long>("Bank");
                        Account.Bank = (long)cbBank.SelectedValue;
                    }
                    catch
                    {
                        cbBank.SelectedIndex = -1;
                        Account.Bank = 0;
                    }
                    cbClass.Enabled = false;
                    cbClass.SelectedValue = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                        .CopyToDataTable().Rows[0].Field<long>("Class");
                    Account.Class = (long)cbClass.SelectedValue;
                    cbType.Enabled = false;
                    cbType.SelectedValue = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                        .CopyToDataTable().Rows[0].Field<long>("Type");
                    Account.Type = (long)cbType.SelectedValue;
                    bool hasCard = DataBase.Types.AccountTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Account.Type))
                        .CopyToDataTable().Rows[0].Field<bool>("Card");
                    bool hasFee = DataBase.Types.AccountTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Account.Type))
                        .CopyToDataTable().Rows[0].Field<bool>("Fee");
                    bool hasGrace = DataBase.Types.AccountTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Account.Type))
                        .CopyToDataTable().Rows[0].Field<bool>("Grace");
                    bool hasOverdraft = DataBase.Types.AccountTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Account.Type))
                        .CopyToDataTable().Rows[0].Field<bool>("Overdraft");
                    cbFeeUnit.Enabled = hasFee;
                    cbFeeUnit.SelectedValue = DataBase.Tables.Accounts.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                    .CopyToDataTable().Rows[0].Field<string>("FeeUnit");
                    Account.FeeUnit = cbFeeUnit.SelectedValue.ToString();
                    cbGraceUnit.Enabled = hasGrace;
                    cbGraceUnit.SelectedValue = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                        .CopyToDataTable().Rows[0].Field<string>("GraceUnit");
                    Account.GraceUnit = cbGraceUnit.SelectedValue.ToString();
                    cbUser.Enabled = false;
                    cbUser.SelectedValue = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                        .CopyToDataTable().Rows[0].Field<long>("User");
                    Account.User = (long)cbUser.SelectedValue;
                    ckGenInfo.Checked = true;
                    lbTitle.Text = "Editar Conta";
                    tbAgency.BackColor = SystemColors.Control;
                    tbAgency.Enabled = false;
                    tbAgency.Text = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                        .CopyToDataTable().Rows[0].Field<string>("Agency");
                    Account.Agency = tbAgency.Text.Replace("'", "''").Trim();
                    tbBalance.BackColor = SystemColors.Control;
                    tbBalance.Enabled = false;
                    tbBalance.Text = DataBase.Tables.CashFlow.AsEnumerable()
                        .Where(row => row.Field<long>("Account").Equals(Globals.SelectedAccount))
                        .OrderByDescending(row => row.Field<long>("Id")).Take(1)
                        .CopyToDataTable().Rows[0].Field<decimal>("Balance").ToString("#,##0.00");
                    Account.Balance = decimal.Parse(tbBalance.Text);
                    tbBankCode.Visible = false;
                    var bankCodes = from accounts in DataBase.Tables.Accounts.AsEnumerable()
                                    join banks in DataBase.Tables.Banks.AsEnumerable()
                                    on (long)accounts["Bank"] equals (long)banks["Id"]
                                    select new
                                    {
                                        Id = (long)accounts["Id"],
                                        BankCode = (string)banks["BankCode"]
                                    };
                    if (bankCodes.ToList().Count > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(bankCodes.ToList()[0].BankCode))
                        {
                            tbBankCode.Visible = true;
                            int index = bankCodes.ToList().FindIndex(a => a.Id.Equals(Globals.SelectedAccount));
                            if (!index.Equals(-1)) tbBankCode.Text = bankCodes.ToList()[index].BankCode;
                        }
                    }
                    tbFee.Enabled = hasFee;
                    if (!hasFee)
                    {
                        tbFee.BackColor = SystemColors.Control;
                        tbFee.Text = "0,00";
                        Account.Fee = 0;
                    }
                    else
                    {
                        tbFee.BackColor = SystemColors.Window;
                        tbFee.Text = (DataBase.Tables.Accounts.AsEnumerable()
                            .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                            .CopyToDataTable().Rows[0].Field<decimal>("Fee") * 100).ToString("#,##0.00");
                        Account.Fee = decimal.Parse(tbFee.Text) / 100;
                    }
                    tbGrace.Enabled = hasGrace;
                    if (!hasGrace)
                    {
                        tbGrace.BackColor = SystemColors.Control;
                        tbGrace.Text = string.Empty;
                        Account.Grace = 0;
                    }
                    else
                    {
                        tbGrace.BackColor = SystemColors.Window;
                        tbGrace.Text = DataBase.Tables.Accounts.AsEnumerable()
                            .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                            .CopyToDataTable().Rows[0].Field<long>("Grace").ToString();
                        Account.Grace = long.Parse(tbGrace.Text);
                    }
                    tbNumber.BackColor = SystemColors.Control;
                    tbNumber.Enabled = false;
                    tbNumber.Text = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                        .CopyToDataTable().Rows[0].Field<string>("Account");
                    Account.Number = tbNumber.Text.Replace("'", "''").Trim();
                    tbOverdraft.Enabled = hasOverdraft;
                    if (!hasOverdraft)
                    {
                        tbOverdraft.BackColor = SystemColors.Control;
                        tbOverdraft.Text = "0,00";
                        Account.Overdraft = 0;
                    }
                    else
                    {
                        tbOverdraft.BackColor = SystemColors.Window;
                        tbOverdraft.Text = DataBase.Tables.Accounts.AsEnumerable()
                            .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                            .CopyToDataTable().Rows[0].Field<decimal>("Overdraft").ToString("#,##0.00");
                        Account.Overdraft = decimal.Parse(tbOverdraft.Text);
                    }
                    tbName.Text = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                        .CopyToDataTable().Rows[0].Field<string>("Name");
                    Account.Name = tbName.Text.Replace("'", "''").Trim();
                    tbStatus.Tag = DataBase.Tables.Accounts.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedAccount))
                        .CopyToDataTable().Rows[0].Field<long>("Status");
                    tbStatus.Text = DataBase.Types.Status.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals((long)tbStatus.Tag))
                        .CopyToDataTable().Rows[0].Field<string>("FName");
                    Account.Status = (long)tbStatus.Tag;
                    spGenInfo.Panel2Collapsed = false;
                    spGenInfo.Size = spGenInfo.MaximumSize;
                    spCards.Visible = hasCard;
                    if (hasCard)
                    {
                        try
                        {
                            DataTable cards = DataBase.Populate(Properties.Resources.sql_dgCards).AsEnumerable()
                            .Where(row => row.Field<long>("IdConta").Equals(Globals.SelectedAccount))
                            .CopyToDataTable();
                            ckCards.Checked = true;
                            dgCards.Size = dgCards.MaximumSize;
                            dgCards.Rows.Clear();
                            for (int i = 0; i < cards.Rows.Count; i++)
                            {
                                dgCards.Rows.Add();
                                dgCards.Rows[i].Cells[0].Value = cards.Rows[i].Field<long>("Id");
                                string card = cards.Rows[i].Field<string>("Número");
                                dgCards.Rows[i].Cells[1].Value = "****" + card.Substring(card.Length - 4, 4);
                                dgCards.Rows[i].Cells[2].Value = cards.Rows[i].Field<string>("Tipo");
                                dgCards.Rows[i].Cells[3].Value = cards.Rows[i].Field<string>("Bandeira");
                            }
                            lbNoCard.Visible = false;
                            spCards.Panel2Collapsed = false;
                            spCards.Size = spCards.MaximumSize;
                        }
                        catch
                        {
                            ckCards.Checked = false;
                            dgCards.Size = dgCards.MinimumSize;
                            lbNoCard.Visible = true;
                            spCards.Panel2Collapsed = true;
                            spCards.Size = spCards.MinimumSize;
                        }
                    }
                    tbName.Select();
                    break;
            }
            Account.HasChanges = false;
        }
        #endregion
        #region Eventos
        #region Validação de dados
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountClassValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Account.Class = (long)(sender as ComboBox).SelectedValue;
            else Account.Class = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountTypeValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Account.Type = (long)(sender as ComboBox).SelectedValue;
            else Account.Type = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgencyValidated(object sender, EventArgs e)
        {
            Account.Agency = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BalanceValidated(object sender, EventArgs e)
        {
            if (decimal.TryParse((sender as TextBox).Text, out decimal value)) Account.Balance = value;
            else Account.Balance = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BankValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Account.Bank = (long)(sender as ComboBox).SelectedValue;
            else if (Account.Class.Equals(1)) Account.Bank = 0;
            else Account.Bank = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidated(object sender, EventArgs e)
        {
            Account.Number = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FeeValidated(object sender, EventArgs e)
        {
            if (decimal.TryParse((sender as TextBox).Text, out decimal value)) Account.Fee = value / 100;
            else Account.Fee = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FeeUnitValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Account.FeeUnit = (string)(sender as ComboBox).SelectedValue;
            else Account.FeeUnit = "D";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraceValidated(object sender, EventArgs e)
        {
            if (long.TryParse((sender as TextBox).Text, out long value)) Account.Grace = value / 100;
            else Account.Grace = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraceUnitValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Account.GraceUnit = (string)(sender as ComboBox).SelectedValue;
            else Account.GraceUnit = "D";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameValidated(object sender, EventArgs e)
        {
            Account.Name = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OverdraftValidated(object sender, EventArgs e)
        {
            if (decimal.TryParse((sender as TextBox).Text, out decimal value)) Account.Overdraft = value;
            else Account.Overdraft = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Account.User = (long)(sender as ComboBox).SelectedValue;
            else Account.User = -1;
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
            if (Globals.SelectedAccount.Equals(-1) && Account.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            if (!Globals.SelectedAccount.Equals(-1) && Account.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("Existem alterações não salvas! As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult.Equals(DialogResult.Yes)) return;
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
            if (Globals.SelectedAccount.Equals(-1) && Account.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            if (!Globals.SelectedAccount.Equals(-1) && Account.HasChanges)
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
        private void EditAccount(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Globals.IsRunning || e.ColumnIndex < 4) return;
            Globals.IsRunning = true;
            Globals.SelectedAccount = (long)dgSearch.Rows[e.RowIndex].Cells[0].Value;
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
        private void EditCard(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Globals.IsRunning || e.ColumnIndex < 4) return;
            Globals.SelectedCard = (long)dgCards.Rows[e.RowIndex].Cells[0].Value;
            Globals.SelectedAccount = DataBase.Tables.Cards.AsEnumerable()
                .Where(row => row.Field<long>("Id").Equals(Globals.SelectedCard))
                .CopyToDataTable().Rows[0].Field<long>("Account");
            CardManager cardManager = new CardManager(1);
            cardManager.ShowDialog();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewAccount(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            SuspendLayout();
            Globals.IsRunning = true;
            Globals.SelectedAccount = -1;
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
        private void NewCard(object sender, EventArgs e)
        {
            Globals.SelectedCard = -1;
            CardManager cardManager = new CardManager(1);
            cardManager.ShowDialog();
            SuspendLayout();
            Globals.IsRunning = true;
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
            if (Globals.IsRunning || !Account.HasChanges) return;
            DialogResult dialogResult;
            if (Account.Type.Equals(-1))
            {
                MessageBox.Show("Campos obrigatórios em branco.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyMethods.SelectFirstControl(cbClass, true, 15);
                return;
            }
            bool hasAgency = DataBase.Types.AccountTypes.AsEnumerable()
                .Where(row => row.Field<long>("Id").Equals(Account.Type))
                .CopyToDataTable().Rows[0].Field<bool>("Agency");
            bool hasAccount = DataBase.Types.AccountTypes.AsEnumerable()
                .Where(row => row.Field<long>("Id").Equals(Account.Type))
                .CopyToDataTable().Rows[0].Field<bool>("Account");
            if (string.IsNullOrWhiteSpace(Account.Name) || Account.Class.Equals(-1) ||
                Account.User.Equals(-1) || Account.Bank.Equals(-1) ||
                (hasAgency && string.IsNullOrWhiteSpace(Account.Agency)) ||
                (hasAccount && string.IsNullOrWhiteSpace(Account.Number)))
            {
                MessageBox.Show("Campos obrigatórios em branco.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyMethods.SelectFirstControl(cbClass, true, 15);
                return;
            }
            if (!Globals.SelectedAccount.Equals(-1))
            {
                dialogResult = MessageBox.Show("Deseja atualizar os dados da conta?\n\n" +
                    Account.Name, "Editar conta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                dialogResult = MessageBox.Show("Confirmar o cadastro da conta?\n\n" +
                    Account.Name, "Nova conta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (!dialogResult.Equals(DialogResult.Yes))
            {
                MyMethods.SelectFirstControl(cbClass, true, 15);
                return;
            }
            Globals.IsRunning = true;
            SuspendLayout();
            if (!Globals.SelectedAccount.Equals(-1)) Account.Update();
            else
            {
                Account.Insert();
                bool hasCard = DataBase.Types.AccountTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals(Account.Type))
                    .CopyToDataTable().Rows[0].Field<bool>("Card");
                if (hasCard)
                {
                    dialogResult = MessageBox.Show("Deseja cadastrar um ou mais cartões para essa conta agora?", "Nova conta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult.Equals(DialogResult.Yes))
                    {
                        CardManager cardManager = new CardManager(2);
                        cardManager.ShowDialog();
                    }
                }
                Debt.Account = Globals.SelectedAccount;
                Debt.Card = 0;
                Debt.Category = 1;
                Debt.Date = DateTime.Today.ToString("yyyy-MM-dd");
                Debt.Description = "SALDO INICIAL DA CONTA";
                Debt.Observation = string.Empty;
                Debt.Opperation = 0;
                Debt.Parcels = 1;
                if (Account.Class.Equals(1)) Debt.Person = Globals.SelectedPerson;
                else Debt.Person = DataBase.Tables.Banks.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals(Account.Bank))
                    .CopyToDataTable().Rows[0].Field<long>("Person");
                Debt.Subcategory1 = 0;
                Debt.DebtClass = 1;
                Debt.User = Account.User;
                Debt.DebtValue = Account.Balance;
                Debt.Insert();
            }
            MessageBox.Show("Cadastro da conta realizado com sucesso!", "Nova conta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (BootMode.Equals(2)) Close();
            Card.Clear();
            Debt.Clear();
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
            DataTable filterData = DataBase.Populate(Properties.Resources.sql_dgSearchAccount);
            if (!string.IsNullOrWhiteSpace(tbFilter.Text) && !cbFilterType.SelectedIndex.Equals(-1))
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
                        dgSearch.Rows[i].Cells[1].Value = filterData.Rows[i].Field<string>("Conta");
                        dgSearch.Rows[i].Cells[2].Value = filterData.Rows[i].Field<string>("Nome");
                        dgSearch.Rows[i].Cells[3].Value = filterData.Rows[i].Field<string>("Classe");
                    }
                    lbNoAccount.Visible = false;
                    goto Found;
                }
            }
            dgSearch.Rows.Clear();
            dgSearch.Size = dgSearch.MinimumSize;
            lbNoAccount.Visible = true;
            tbFilter.Select();
Found:
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        #region Configuração do formulário
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountClassTextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning || BootMode.Equals(1)) return;
            Globals.IsRunning = true;
            SuspendLayout();
            ComboBox me = (ComboBox)sender;
            Account.Clear();
            cbBank.SelectedIndex = -1;
            cbFeeUnit.SelectedValue = "M";
            cbGraceUnit.SelectedValue = "D";
            tbAgency.BackColor = SystemColors.Control;
            tbAgency.Enabled = false;
            tbAgency.Text = string.Empty;
            tbBalance.Text = "0,00";
            tbBankCode.Text = string.Empty;
            tbBankCode.Visible = false;
            tbFee.BackColor = SystemColors.Control;
            tbFee.Enabled = false;
            tbFee.Text = "0,00";
            tbGrace.Text = string.Empty;
            tbGrace.BackColor = SystemColors.Control;
            tbGrace.Enabled = false;
            tbNumber.BackColor = SystemColors.Control;
            tbNumber.Enabled = false;
            tbNumber.Text = string.Empty;
            tbOverdraft.BackColor = SystemColors.Control;
            tbOverdraft.Enabled = false;
            tbOverdraft.Text = "0,00";
            if (me.SelectedIndex.Equals(-1))
            {
                cbType.Enabled = false;
            }
            else
            {
                cbType.DataSource = DataBase.Types.AccountTypes.AsEnumerable()
                        .Where(row => row.Field<long>("Class").Equals((long)me.SelectedValue))
                        .OrderBy(row => row.Field<string>("Name")).CopyToDataTable();
                cbType.DisplayMember = "Name";
                cbType.ValueMember = "Id";
                cbType.Enabled = true;
            }
            cbType.SelectedIndex = -1;
            Account.HasChanges = true;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountTypeTextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning || BootMode.Equals(1)) return;
            Globals.IsRunning = true;
            SuspendLayout();
            ComboBox me = (ComboBox)sender;
            Account.Clear();
            cbBank.SelectedIndex = -1;
            cbFeeUnit.SelectedValue = "M";
            cbGraceUnit.SelectedValue = "D";
            tbAgency.Text = string.Empty;
            tbBalance.Text = "0,00";
            tbBankCode.Text = string.Empty;
            tbFee.Text = "0,00";
            tbGrace.Text = string.Empty;
            tbNumber.Text = string.Empty;
            tbOverdraft.Text = "0,00";
            Account.HasChanges = true;
            if (me.SelectedIndex.Equals(-1))
            {
                tbAgency.BackColor = SystemColors.Control;
                tbAgency.Enabled = false;
                tbBankCode.Visible = false;
                tbFee.BackColor = SystemColors.Control;
                tbFee.Enabled = false;
                tbGrace.BackColor = SystemColors.Control;
                tbGrace.Enabled = false;
                tbNumber.BackColor = SystemColors.Control;
                tbNumber.Enabled = false;
                tbOverdraft.BackColor = SystemColors.Control;
                tbOverdraft.Enabled = false;
            }
            else
            {
                cbBank.Enabled = !((long)me.SelectedValue).Equals(1);
                bool hasAgency = DataBase.Types.AccountTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                    .CopyToDataTable().Rows[0].Field<bool>("Agency");
                bool hasAccount = DataBase.Types.AccountTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                    .CopyToDataTable().Rows[0].Field<bool>("Account");
                bool hasFee = DataBase.Types.AccountTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                    .CopyToDataTable().Rows[0].Field<bool>("Fee");
                bool hasGrace = DataBase.Types.AccountTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                    .CopyToDataTable().Rows[0].Field<bool>("Grace");
                bool hasOverdraft = DataBase.Types.AccountTypes.AsEnumerable()
                    .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                    .CopyToDataTable().Rows[0].Field<bool>("Overdraft");
                if (!hasAgency) tbAgency.BackColor = SystemColors.Control;
                else tbAgency.BackColor = SystemColors.Window;
                tbAgency.Enabled = hasAgency;
                tbBalance.BackColor = SystemColors.Window;
                tbBalance.Enabled = true;
                tbBankCode.Visible = !((long)me.SelectedValue).Equals(1);
                if (!hasAccount) tbNumber.BackColor = SystemColors.Control;
                else tbNumber.BackColor = SystemColors.Window;
                tbNumber.Enabled = hasAccount;
                if (!hasFee) tbFee.BackColor = SystemColors.Control;
                else tbFee.BackColor = SystemColors.Window;
                cbFeeUnit.Enabled = hasFee;
                tbFee.Enabled = hasFee;
                if (!hasGrace) tbGrace.BackColor = SystemColors.Control;
                else tbGrace.BackColor = SystemColors.Window;
                cbGraceUnit.Enabled = hasGrace;
                tbGrace.Enabled = hasGrace;
                if (!hasOverdraft) tbOverdraft.BackColor = SystemColors.Control;
                else tbOverdraft.BackColor = SystemColors.Window;
                tbOverdraft.Enabled = hasOverdraft;
                if (((long)me.SelectedValue).Equals(1)) Account.Bank = 0;
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
        private void PersonTextChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            ComboBox me = (ComboBox)sender;
            if (me.SelectedIndex.Equals(-1))
            {
                tbBankCode.Text = string.Empty;
                return;
            }
            tbBankCode.Text = DataBase.Tables.Banks.AsEnumerable()
                .Where(row => row.Field<long>("Id").Equals((long)me.SelectedValue))
                .CopyToDataTable().Rows[0].Field<string>("BankCode"); 
       }
        #endregion
        #endregion
    }
}
