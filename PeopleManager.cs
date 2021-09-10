using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SISCOFIN_v1
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PeopleManager : Form
    {
        #region Declaração de variáveis
        /// <summary>
        /// 
        /// </summary>
        private static long BootMode;
        #endregion
        #region Inicialização do formulário
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Form"></param>
        public PeopleManager(long bootMode)
        {
            InitializeComponent();
            BootMode = bootMode;
            Text = "SISCOFIN v" + Globals.Version;
            Globals.IsRunning = true;
            //
            // cbBranch
            //
            cbBranch.DataSource = DataBase.Types.Branches;
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember = "Id";
            cbBranch.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbBranch.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbBranch.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            //
            // cbFilterType
            //
            SortedDictionary<string, string> filter = new SortedDictionary<string, string>()
            {
                {"Nome", "NOME"},
                {"Ramo", "RAMO"}
            };
            cbFilterType.DataSource = new BindingSource(filter, null);
            cbFilterType.DisplayMember = "Value";
            cbFilterType.ValueMember = "Key";
            cbFilterType.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbFilterType.SelectedValue = "Nome";
            //
            // cbStatus
            //
            cbStatus.DataSource = DataBase.Types.Status.AsEnumerable()
                .Where(row => row.Field<bool>("People"))
                .CopyToDataTable();
            cbStatus.DisplayMember = "MName";
            cbStatus.ValueMember = "Id";
            cbStatus.SelectedValue = 3;
            cbStatus.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbStatus.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbStatus.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            //
            // ckAddress
            //
            ckAddress.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            //
            // ckAdvanced
            //
            ckAdvanced.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            //
            // ckEmail
            //
            ckEmail.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            //
            // ckGenInfo
            //
            ckGenInfo.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            //
            // ckPhone
            //
            ckPhone.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            //
            // ckSearch
            //
            ckSearch.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            //
            // dgAddress
            //
            dgAddress.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgAddress.CellMouseDown += new DataGridViewCellMouseEventHandler(EditAddress);
            //
            // dgEmail
            //
            dgEmail.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgEmail.CellMouseDown += new DataGridViewCellMouseEventHandler(EditEmail);
            //
            // dgPhone
            //
            dgPhone.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgPhone.CellMouseDown += new DataGridViewCellMouseEventHandler(EditPhone);
            //
            // dgSearch
            //
            dgSearch.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgSearch.CellMouseDown += new DataGridViewCellMouseEventHandler(EditPerson);
            //
            // spAddress
            //
            spAddress.MaximumSize = new Size(750, 334);
            spAddress.MinimumSize = new Size(742, 40);
            spAddress.SplitterDistance = 39;
            spAddress.SplitterWidth = 1;
            //
            // spAdvanced
            //
            spAdvanced.MaximumSize = new Size(750, 164);
            spAdvanced.MinimumSize = new Size(742, 40);
            spAdvanced.SplitterDistance = 39;
            spAdvanced.SplitterWidth = 1;
            //
            // spEmail
            //
            spEmail.MaximumSize = new Size(750, 258);
            spEmail.MinimumSize = new Size(742, 40);
            spEmail.SplitterDistance = 39;
            spEmail.SplitterWidth = 1;
            //
            // spGenInfo
            //
            spGenInfo.MaximumSize = new Size(750, 235);
            spGenInfo.MinimumSize = new Size(742, 40);
            spGenInfo.SplitterDistance = 39;
            spGenInfo.SplitterWidth = 1;
            //
            // spPhone
            //
            spPhone.MaximumSize = new Size(750, 258);
            spPhone.MinimumSize = new Size(742, 40);
            spPhone.SplitterDistance = 39;
            spPhone.SplitterWidth = 1;
            //
            // spSearch
            //
            spSearch.MaximumSize = new Size(750, 466);
            spSearch.MinimumSize = new Size(750, 50);
            spSearch.SplitterDistance = 49;
            spSearch.SplitterWidth = 1;
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
        private void Setup(long mode)
        {
            bool isSearch = false;
            if (mode.Equals(0)) isSearch = true;
            if (mode.Equals(2)) btSave.Text = "Continuar";
            else Person.Clear();
            cbFilterType.SelectedIndex = 1;
            ckSearch.Checked = false;
            dgAddress.Rows.Clear();
            dgEmail.Rows.Clear();
            dgPhone.Rows.Clear();
            dgSearch.Rows.Clear();
            dgSearch.Size = dgSearch.MinimumSize;
            pnManager.Visible = !isSearch;
            spSearch.Visible = isSearch;
            spSearch.Panel2Collapsed = true;
            spSearch.Size = spSearch.MinimumSize;
            tbFilter.Text = string.Empty;
            switch (Globals.SelectedPerson)
            {
                case -1:
                    btNewAddress.Enabled = false;
                    btNewEmail.Enabled = false;
                    btNewPhone.Enabled = false;
                    if (mode.Equals(2))
                    {
                        cbBranch.Text = Person.BranchText;
                        tbName.Text = Person.Name;
                    }
                    else
                    {
                        cbBranch.SelectedIndex = -1;
                        tbName.Text = string.Empty;
                    }
                    cbStatus.SelectedValue = 3;
                    ckAddress.Checked = false;
                    ckAdvanced.Checked = false;
                    ckEmail.Checked = false;
                    ckGenInfo.Checked = false;
                    ckPhone.Checked = false;
                    dgAddress.Size = dgAddress.MinimumSize;
                    dgEmail.Size = dgEmail.MinimumSize;
                    dgPhone.Size = dgPhone.MinimumSize;
                    lbDocument.Text = "CNPJ";
                    lbTitle.Text = "Nova Pessoa";
                    mbDocument.Mask = "00,000,000/0000-00";
                    rbNo.Checked = true;
                    rbPJ.Checked = true;
                    spAddress.Panel2Collapsed = true;
                    spAddress.Size = spAdvanced.MinimumSize;
                    spAdvanced.Panel2Collapsed = true;
                    spAdvanced.Size = spAdvanced.MinimumSize;
                    spEmail.Panel2Collapsed = true;
                    spEmail.Size = spAdvanced.MinimumSize;
                    spPhone.Panel2Collapsed = true;
                    spPhone.Size = spAdvanced.MinimumSize;
                    if (isSearch) tbFilter.Select();
                    else tbName.Select();
                    break;
                default:
                    btNewAddress.Enabled = true;
                    btNewEmail.Enabled = true;
                    btNewPhone.Enabled = true;
                    cbBranch.SelectedValue = DataBase.Tables.People.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedPerson))
                        .CopyToDataTable().Rows[0].Field<long>("Branch");
                    Person.Branch = (long)cbBranch.SelectedValue;
                    Person.BranchText = cbBranch.Text;
                    cbStatus.SelectedValue = DataBase.Tables.People.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedPerson))
                        .CopyToDataTable().Rows[0].Field<long>("Status");
                    Person.Status = (long)cbStatus.SelectedValue;
                    ckAdvanced.Checked = false;
                    lbTitle.Text = "Editar Pessoa";
                    string type = DataBase.Tables.People.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedPerson))
                        .CopyToDataTable().Rows[0].Field<string>("Type");
                    switch (type)
                    {
                        case "PF":
                            lbDocument.Text = "CPF";
                            mbDocument.Mask = "000,000,000-00";
                            rbPF.Checked = true;
                            break;
                        case "PJ":
                            lbDocument.Text = "CNPJ";
                            mbDocument.Mask = "00,000,000/0000-00";
                            rbPJ.Checked = true;
                            break;
                    }
                    Person.Type = type;
                    mbDocument.Text = DataBase.Tables.People.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedPerson))
                        .CopyToDataTable().Rows[0].Field<string>("Document");
                    Person.Document = mbDocument.Text;
                    tbName.Text = DataBase.Tables.People.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedPerson))
                        .CopyToDataTable().Rows[0].Field<string>("Name");
                    Person.Name = tbName.Text.Replace("'", "''").Trim();
                    bool isUser = DataBase.Tables.People.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedPerson))
                        .CopyToDataTable().Rows[0].Field<bool>("IsUser");
                    Person.IsUser = isUser;
                    if (isUser) rbYes.Checked = true;
                    else rbNo.Checked = true;
                    spAdvanced.Panel2Collapsed = true;
                    spAdvanced.Size = spAdvanced.MinimumSize;
                    try
                    {
                        DataTable addresses = DataBase.Populate(Properties.Resources.sql_dgAddress).AsEnumerable()
                            .Where(row => row.Field<long>("IdPessoa").Equals(Globals.SelectedPerson))
                            .CopyToDataTable();
                        ckAddress.Checked = true;
                        dgAddress.Size = dgAddress.MaximumSize;
                        for (int i = 0; i < addresses.Rows.Count; i++)
                        {
                            dgAddress.Rows.Add();
                            dgAddress.Rows[i].Cells[0].Value = addresses.Rows[i].Field<long>("Id");
                            dgAddress.Rows[i].Cells[1].Value = addresses.Rows[i].Field<string>("Endereço");
                            dgAddress.Rows[i].Cells[2].Value = addresses.Rows[i].Field<bool>("Corresp");
                        }
                        lbNoAddress.Visible = false;
                        spAddress.Panel2Collapsed = false;
                        spAddress.Size = spAddress.MaximumSize;
                    }
                    catch
                    {
                        ckAddress.Checked = false;
                        dgAddress.Size = dgAddress.MinimumSize;
                        lbNoAddress.Visible = true;
                        spAddress.Panel2Collapsed = true;
                        spAddress.Size = spAddress.MinimumSize;
                    }
                    try
                    {
                        DataTable emails = DataBase.Populate(Properties.Resources.sql_dgEmail).AsEnumerable()
                            .Where(row => row.Field<long>("IdPessoa").Equals(Globals.SelectedPerson))
                            .CopyToDataTable();
                        ckEmail.Checked = true;
                        dgEmail.Size = dgEmail.MaximumSize;
                        for (int i = 0; i < emails.Rows.Count; i++)
                        {
                            dgEmail.Rows.Add();
                            dgEmail.Rows[i].Cells[0].Value = emails.Rows[i].Field<long>("Id");
                            dgEmail.Rows[i].Cells[1].Value = emails.Rows[i].Field<string>("Email");
                            dgEmail.Rows[i].Cells[2].Value = emails.Rows[i].Field<bool>("Corresp");
                        }
                        lbNoEmail.Visible = false;
                        spEmail.Panel2Collapsed = false;
                        spEmail.Size = spEmail.MaximumSize;
                    }
                    catch
                    {
                        ckEmail.Checked = false;
                        dgEmail.Size = dgEmail.MinimumSize;
                        lbNoEmail.Visible = true;
                        spEmail.Panel2Collapsed = true;
                        spEmail.Size = spEmail.MinimumSize;
                    }
                    try
                    {
                        DataTable phones = DataBase.Populate(Properties.Resources.sql_dgPhone).AsEnumerable()
                            .Where(row => row.Field<long>("IdPessoa").Equals(Globals.SelectedPerson))
                            .CopyToDataTable();
                        ckPhone.Checked = true;
                        dgPhone.Size = dgPhone.MaximumSize;
                        for (int i = 0; i < phones.Rows.Count; i++)
                        {
                            dgPhone.Rows.Add();
                            dgPhone.Rows[i].Cells[0].Value = phones.Rows[i].Field<long>("Id");
                            dgPhone.Rows[i].Cells[1].Value = phones.Rows[i].Field<string>("Telefone");
                            dgPhone.Rows[i].Cells[2].Value = phones.Rows[i].Field<string>("Tipo");
                        }
                        lbNoPhone.Visible = false;
                        spPhone.Panel2Collapsed = false;
                        spPhone.Size = spPhone.MaximumSize;
                    }
                    catch
                    {
                        ckPhone.Checked = false;
                        dgPhone.Size = dgPhone.MinimumSize;
                        lbNoPhone.Visible = true;
                        spPhone.Panel2Collapsed = true;
                        spPhone.Size = spPhone.MinimumSize;
                    }
                    break;
            }
            Person.HasChanges = false;
        }
        #endregion
        #region Eventos
        #region Validação de dados
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BranchValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) Person.Branch = (long)(sender as ComboBox).SelectedValue;
            else Person.Branch = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentValidated(object sender, EventArgs e)
        {
            Person.Document = (sender as MaskedTextBox).Text.Replace(".", "").Replace("-", "").Replace("/", "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsUserValidated(object sender, EventArgs e)
        {
            Person.IsUser = (sender as RadioButton).Checked;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameValidated(object sender, EventArgs e)
        {
            Person.Name = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PFValidated(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked) Person.Type = "PF";
            else Person.Type = "PJ";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusValidated(object sender, EventArgs e)
        {
            ComboBox me = sender as ComboBox;
            if (me.SelectedValue != null) Person.Status = (long)me.SelectedValue;
            else Person.Status = -1;
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
            if (Globals.SelectedPerson.Equals(-1) && Person.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            if (!Globals.SelectedPerson.Equals(-1) && Person.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("Existem alterações não salvas! As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            switch (BootMode)
            {
                case 1:
                    Close();
                    break;
                case 2:
                    if (string.IsNullOrWhiteSpace(Person.BranchText) || string.IsNullOrWhiteSpace(Person.Name))
                    {
                        MessageBox.Show("Campos obrigatórios em branco.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbName.Select();
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("Cancelando a operação, serão cadastrados apenas o nome e ramo desta pessoa.\nDeseja sair do assistente de cadastro de pessoas?", "Atenção!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult.Equals(DialogResult.OK)) Close();
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
            if (Globals.SelectedPerson.Equals(-1) && Person.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            if (!Globals.SelectedPerson.Equals(-1) && Person.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("Existem alterações não salvas! As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            switch (BootMode)
            {
                case 2:
                    if (string.IsNullOrWhiteSpace(Person.BranchText) || string.IsNullOrWhiteSpace(Person.Name))
                    {
                        MessageBox.Show("Campos obrigatórios em branco.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbName.Select();
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("Cancelando a operação, serão cadastrados apenas o nome e ramo desta pessoa.\nDeseja sair do assistente de cadastro de pessoas?", "Atenção!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult.Equals(DialogResult.OK)) Close();
                    break;
                default:
                    Globals.SelectedAccount = -1;
                    Globals.SelectedCard = -1;
                    Globals.SelectedPerson = -1;
                    Globals.SelectedUser = -1;
                    Close();
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditAddress(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Globals.IsRunning || e.ColumnIndex < 3) return;
            long id = (long)dgAddress.Rows[e.RowIndex].Cells[0].Value;
            AddressAssistent addressAssistent = new AddressAssistent(id);
            addressAssistent.ShowDialog();
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
        private void EditEmail(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Globals.IsRunning || e.ColumnIndex < 3) return;
            long id = (long)dgEmail.Rows[e.RowIndex].Cells[0].Value;
            EmailAssistent emailAssistent = new EmailAssistent(id);
            emailAssistent.ShowDialog();
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
        private void EditPerson(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Globals.IsRunning || e.ColumnIndex < 3) return;
            SuspendLayout();
            Globals.IsRunning = true;
            Globals.SelectedPerson = (long)dgSearch.Rows[e.RowIndex].Cells[0].Value;
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
        private void EditPhone(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Globals.IsRunning || e.ColumnIndex < 3) return;
            long id = (long)dgPhone.Rows[e.RowIndex].Cells[0].Value;
            PhoneAssistent phoneAssistent = new PhoneAssistent(id);
            phoneAssistent.ShowDialog();
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
        private void NewAddress(object sender, EventArgs e)
        {
            AddressAssistent addressAssistent = new AddressAssistent(-1);
            addressAssistent.ShowDialog();
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
        private void NewEmail(object sender, EventArgs e)
        {
            EmailAssistent emailAssistent = new EmailAssistent(-1);
            emailAssistent.ShowDialog();
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
        private void NewPerson(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            SuspendLayout();
            Globals.IsRunning = true;
            Globals.SelectedPerson = -1;
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
        private void NewPhone(object sender, EventArgs e)
        {
            PhoneAssistent phoneAssistent = new PhoneAssistent(-1);
            phoneAssistent.ShowDialog();
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
            if (Globals.IsRunning) return;
            DataTable filterData = DataBase.Tables.People.Copy();
            try
            {
                filterData = DataBase.Tables.People.AsEnumerable()
                                .Where(row => row.Field<string>("Document").Contains(Person.Document) &&
                                !string.IsNullOrWhiteSpace(Person.Document))
                                .CopyToDataTable();
            }
            catch { filterData.Rows.Clear(); }
            if (Globals.SelectedPerson.Equals(-1) && !filterData.Rows.Count.Equals(0))
            {
                MessageBox.Show("Já existe uma pessoa cadastrada com esse CPF/CNPJ.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mbDocument.Select();
                return;
            }
            if (string.IsNullOrWhiteSpace(Person.Name) || string.IsNullOrWhiteSpace(Person.BranchText))
            {
                MessageBox.Show("Campos obrigatórios não preenchidos.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbName.Select();
                return;
            }
            if (!Person.CheckBranch())
            {
                cbBranch.Select();
                return;
            }
            Globals.IsRunning = true;
            SuspendLayout();
            if (!Globals.SelectedPerson.Equals(-1)) Person.Update();
            else Person.Insert();
            if (Person.IsUser && Globals.SelectedUser.Equals(-1))
            {
                    DialogResult dialogResult = MessageBox.Show("É necessário fazer o cadastro do usuário.",
                                                "Novo usuário indentificado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UserManager userManager = new UserManager(2);
                userManager.ShowDialog();
                if (Globals.SelectedUser.Equals(-1)) User.Insert();
            }
            MessageBox.Show("Cadastro da pessoa/estabelecimento realizado com sucesso!", "Nova pessoa/estabelecimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (BootMode.Equals(2)) Close();
            User.Clear();
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
        private void SearchClick(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            if (!ckSearch.Checked) ckSearch.Checked = true;
            Globals.IsRunning = true;
            SuspendLayout();
            DataTable filterData = DataBase.Populate(Properties.Resources.sql_dgSearchPerson);
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
                        dgSearch.Rows[i].Cells[1].Value = filterData.Rows[i].Field<string>("Nome");
                        dgSearch.Rows[i].Cells[2].Value = filterData.Rows[i].Field<string>("Ramo");
                    }
                    lbNoPerson.Visible = false;
                    goto Found;
                }
            }
            dgSearch.Rows.Clear();
            dgSearch.Size = dgSearch.MinimumSize;
            lbNoPerson.Visible = true;
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
        private void PFCheckedChanged(object sender, EventArgs e)
        {
            mbDocument.Text = string.Empty;
            if ((sender as RadioButton).Checked)
            {
                lbDocument.Text = "CPF";
                mbDocument.Mask = "000,000,000-00";
            }
            else
            {
                lbDocument.Text = "CNPJ";
                mbDocument.Mask = "00,000,000/0000-00";
            }
        }
        #endregion
        #endregion
    }
}
