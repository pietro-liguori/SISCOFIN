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

namespace SISCOFIN_v1
{
    public partial class UserManager : Form
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
        /// <param name="BootMode"></param>
        public UserManager(long bootMode)
        {
            InitializeComponent();
            Person.IsUser = true;
            BootMode = bootMode;
            Text = "SISCOFIN v" + Globals.Version;
            Globals.IsRunning = true;
            //
            // cbFilterType
            //
            SortedDictionary<string, string> filter = new SortedDictionary<string, string>()
            {
                {"Nome", "NOME"},
                {"Usuário", "USUÁRIO"}
            };
            cbFilterType.DataSource = new BindingSource(filter, null);
            cbFilterType.DisplayMember = "Value";
            cbFilterType.ValueMember = "Key";
            cbFilterType.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            cbFilterType.SelectedValue = "Nome";
            //
            // cbMaritalStatus
            //
            cbMaritalStatus.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbMaritalStatus.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbMaritalStatus.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            //
            // cbSex
            //
            cbSex.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbSex.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbSex.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            //
            // cbStatus
            //
            cbStatus.DataSource = DataBase.Types.Status.AsEnumerable()
                .Where(row => row.Field<bool>("Users"))
                .CopyToDataTable();
            cbStatus.DisplayMember = "MName";
            cbStatus.ValueMember = "Id";
            cbStatus.SelectedValue = 3;
            cbStatus.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbStatus.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbStatus.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            //
            // cbUF
            //
            cbUF.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbUF.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbUF.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
            //
            // ckAddress
            //
            ckAddress.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            //
            // ckAdvanced
            //
            ckAdvanced.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
            //
            // ckDocument
            //
            ckDocument.CheckedChanged += new EventHandler(MyEvents.CollapsePanel);
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
            // dgDocument
            //
            dgDocument.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgDocument.CellMouseDown += new DataGridViewCellMouseEventHandler(EditDocument);
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
            dgSearch.CellMouseDown += new DataGridViewCellMouseEventHandler(EditUser);
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
            spAdvanced.MaximumSize = new Size(750, 90);
            spAdvanced.MinimumSize = new Size(742, 40);
            spAdvanced.SplitterDistance = 39;
            spAdvanced.SplitterWidth = 1;
            //
            // spDocument
            //
            spDocument.MaximumSize = new Size(750, 258);
            spDocument.MinimumSize = new Size(742, 40);
            spDocument.SplitterDistance = 39;
            spDocument.SplitterWidth = 1;
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
            spGenInfo.MaximumSize = new Size(750, 369);
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
            string[] sex =
            {
                "FEMININO",
                "MASCULINO",
                "OUTRO"
            };
            string type;
            bool isSearch = false;
            if (mode.Equals(0)) isSearch = true;
            if (mode.Equals(2)) btSave.Text = "Continuar";
            else
            {
                Person.Clear();
                User.Clear();
            }
            Person.IsUser = true;
            cbFilterType.SelectedIndex = 1;
            ckSearch.Checked = false;
            dgAddress.Rows.Clear();
            dgDocument.Rows.Clear();
            dgEmail.Rows.Clear();
            dgPhone.Rows.Clear();
            dgSearch.Rows.Clear();
            dgSearch.Size = dgSearch.MinimumSize;
            pnManager.Visible = !isSearch;
            spSearch.Visible = isSearch;
            spSearch.Panel2Collapsed = true;
            spSearch.Size = spSearch.MinimumSize;
            tbFilter.Text = string.Empty;
            switch (Globals.SelectedUser)
            {
                case -1:
                    btNewDocument.Enabled = false;
                    spDocument.Panel2Collapsed = true;
                    spDocument.Size = spAdvanced.MinimumSize;
                    switch (Globals.SelectedPerson)
                    {
                        case -1:
                            btNewAddress.Enabled = false;
                            btNewEmail.Enabled = false;
                            btNewPhone.Enabled = false;
                            mbDocument.Text = string.Empty;
                            tbName.Text = string.Empty;
                            cbMaritalStatus.SelectedIndex = -1;
                            cbMaritalStatus.Visible = true;
                            cbSex.DataSource = null;
                            cbSex.Items.Clear();
                            cbSex.Items.AddRange(sex);
                            cbSex.SelectedIndex = -1;
                            cbStatus.SelectedValue = 3;
                            cbUF.SelectedIndex = -1;
                            cbUF.Visible = true;
                            ckAddress.Checked = false;
                            ckAdvanced.Checked = false;
                            ckDocument.Checked = false;
                            ckEmail.Checked = false;
                            ckGenInfo.Checked = false;
                            ckPhone.Checked = false;
                            dgAddress.Size = dgAddress.MinimumSize;
                            dgDocument.Size = dgDocument.MinimumSize;
                            dgEmail.Size = dgEmail.MinimumSize;
                            dgPhone.Size = dgPhone.MinimumSize;
                            dpBirth.Value = DateTime.Now;
                            lbDocument.Text = "CPF";
                            lbSex.Text = "Sexo";
                            lbTitle.Text = "Novo Usuário";
                            mbDocument.Mask = "000,000,000-00";
                            rbPF.Checked = true;
                            Person.Type = "PF";
                            Person.Branch = 0;
                            Person.BranchText = "PESSOA FÍSICA";
                            spAddress.Panel2Collapsed = true;
                            spAddress.Size = spAdvanced.MinimumSize;
                            spAdvanced.Panel2Collapsed = true;
                            spAdvanced.Size = spAdvanced.MinimumSize;
                            spEmail.Panel2Collapsed = true;
                            spEmail.Size = spAdvanced.MinimumSize;
                            spPhone.Panel2Collapsed = true;
                            spPhone.Size = spPhone.MinimumSize;
                            tbName.Text = string.Empty;
                            tbNationality.Text = string.Empty;
                            tbNationality.Visible = true;
                            tbNaturality.Text = string.Empty;
                            tbNaturality.Visible = true;
                            tbPassword.Text = string.Empty;
                            tbUsername.Text = string.Empty;
                            if (isSearch) tbFilter.Select();
                            else tbName.Select();
                            break;
                        default:
                            btNewAddress.Enabled = true;
                            btNewEmail.Enabled = true;
                            btNewPhone.Enabled = true;
                            cbMaritalStatus.SelectedIndex = -1;
                            cbStatus.SelectedValue = DataBase.Tables.People.AsEnumerable()
                                .Where(row => row.Field<long>("Id").Equals(Globals.SelectedPerson))
                                .CopyToDataTable().Rows[0].Field<long>("Status");
                            User.Status = (long)cbStatus.SelectedValue;
                            cbUF.SelectedIndex = -1;
                            ckAdvanced.Checked = false;
                            dpBirth.Value = DateTime.Now;
                            lbTitle.Text = "Novo Usuário";
                            type = DataBase.Tables.People.AsEnumerable()
                                .Where(row => row.Field<long>("Id").Equals(Globals.SelectedPerson))
                                .CopyToDataTable().Rows[0].Field<string>("Type");
                            switch (type)
                            {
                                case "PF":
                                    Person.Branch = 0;
                                    Person.BranchText = "PESSOA FÍSICA";
                                    cbMaritalStatus.Visible = true;
                                    cbSex.DataSource = null;
                                    cbSex.Items.Clear();
                                    cbSex.Items.AddRange(sex);
                                    cbSex.SelectedIndex = -1;
                                    cbUF.Visible = true;
                                    lbDocument.Text = "CPF";
                                    lbSex.Text = "Sexo";
                                    mbDocument.Mask = "000,000,000-00";
                                    rbPF.Checked = true;
                                    tbNationality.Visible = true;
                                    tbNaturality.Visible = true;
                                    break;
                                case "PJ":
                                    cbMaritalStatus.Visible = false;
                                    cbSex.DataSource = null;
                                    cbSex.DataSource = DataBase.Types.Branches;
                                    cbSex.DisplayMember = "Name";
                                    cbSex.ValueMember = "Id";
                                    cbSex.SelectedIndex = -1;
                                    cbUF.Visible = false;
                                    lbDocument.Text = "CNPJ";
                                    lbSex.Text = "Ramo";
                                    mbDocument.Mask = "00,000,000/0000-00";
                                    rbPJ.Checked = true;
                                    tbNationality.Visible = false;
                                    tbNaturality.Visible = false;
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
                            tbNationality.Text = string.Empty;
                            tbNaturality.Text = string.Empty;
                            tbPassword.Text = string.Empty;
                            tbUsername.Text = string.Empty;
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
                                DataTable documents = DataBase.Populate(Properties.Resources.sql_dgDocument).AsEnumerable()
                                    .Where(row => row.Field<long>("IdUsuário").Equals(Globals.SelectedUser))
                                    .CopyToDataTable();
                                ckDocument.Checked = true;
                                dgDocument.Size = dgDocument.MaximumSize;
                                for (int i = 0; i < documents.Rows.Count; i++)
                                {
                                    dgDocument.Rows.Add();
                                    dgDocument.Rows[i].Cells[0].Value = documents.Rows[i].Field<long>("Id");
                                    dgDocument.Rows[i].Cells[1].Value = documents.Rows[i].Field<string>("Tipo");
                                    dgDocument.Rows[i].Cells[2].Value = documents.Rows[i].Field<string>("Número");
                                }
                                lbNoDocument.Visible = false;
                                spDocument.Panel2Collapsed = false;
                                spDocument.Size = spDocument.MaximumSize;
                            }
                            catch
                            {
                                ckDocument.Checked = false;
                                dgDocument.Size = dgDocument.MinimumSize;
                                lbNoDocument.Visible = true;
                                spDocument.Panel2Collapsed = true;
                                spDocument.Size = spDocument.MinimumSize;
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
                    break;
                default:
                    btNewAddress.Enabled = true;
                    btNewDocument.Enabled = true;
                    btNewEmail.Enabled = true;
                    btNewPhone.Enabled = true;
                    cbStatus.SelectedValue = DataBase.Tables.Users.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedUser))
                        .CopyToDataTable().Rows[0].Field<long>("Status");
                    User.Status = (long)cbStatus.SelectedValue;
                    ckAdvanced.Checked = true;
                    dpBirth.Value = DataBase.Tables.Users.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedUser))
                        .CopyToDataTable().Rows[0].Field<DateTime>("Birth");
                    User.Birth = dpBirth.Value.ToString("yyyy-MM-dd");
                    lbTitle.Text = "Editar Usuário";
                    type = DataBase.Tables.People.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedPerson))
                        .CopyToDataTable().Rows[0].Field<string>("Type");
                    switch (type)
                    {
                        case "PF":
                            cbMaritalStatus.Text = DataBase.Tables.Users.AsEnumerable()
                                .Where(row => row.Field<long>("Id").Equals(Globals.SelectedUser))
                                .CopyToDataTable().Rows[0].Field<string>("MaritalStatus");
                            User.MaritalStatus = cbMaritalStatus.Text.Replace("'", "''").Trim();
                            cbMaritalStatus.Visible = true;
                            cbSex.Items.Clear();
                            cbSex.Items.AddRange(sex);
                            cbSex.Text = DataBase.Tables.Users.AsEnumerable()
                                .Where(row => row.Field<long>("Id").Equals(Globals.SelectedUser))
                                .CopyToDataTable().Rows[0].Field<string>("Sex");
                            User.Sex = cbSex.Text.Replace("'", "''").Trim();
                            Person.Branch = 0;
                            Person.BranchText = "PESSOA FÍSICA";
                            cbUF.Text = DataBase.Tables.Users.AsEnumerable()
                                .Where(row => row.Field<long>("Id").Equals(Globals.SelectedUser))
                                .CopyToDataTable().Rows[0].Field<string>("Estate");
                            User.Estate = cbUF.Text.Replace("'", "''").Trim();
                            cbUF.Visible = true;
                            lbDocument.Text = "CPF";
                            lbSex.Text = "Sexo";
                            mbDocument.Mask = "000,000,000-00";
                            rbPF.Checked = true;
                            tbNationality.Text = DataBase.Tables.Users.AsEnumerable()
                                .Where(row => row.Field<long>("Id").Equals(Globals.SelectedUser))
                                .CopyToDataTable().Rows[0].Field<string>("Country");
                            User.Country = tbNationality.Text.Replace("'", "''").Trim();
                            tbNationality.Visible = true;
                            tbNaturality.Text = DataBase.Tables.Users.AsEnumerable()
                                .Where(row => row.Field<long>("Id").Equals(Globals.SelectedUser))
                                .CopyToDataTable().Rows[0].Field<string>("City");
                            User.City = tbNaturality.Text.Replace("'", "''").Trim();
                            tbNaturality.Visible = true;
                            break;
                        case "PJ":
                            cbMaritalStatus.Text = string.Empty;
                            cbMaritalStatus.Visible = false;
                            cbSex.DataSource = null;
                            cbSex.DataSource = DataBase.Types.Branches;
                            cbSex.DisplayMember = "Name";
                            cbSex.ValueMember = "Id";
                            cbSex.SelectedValue = DataBase.Tables.People.AsEnumerable()
                                .Where(row => row.Field<long>("Id").Equals(Globals.SelectedPerson))
                                .CopyToDataTable().Rows[0].Field<long>("Branch");
                            Person.Branch = (long)cbSex.SelectedValue;
                            Person.BranchText = cbSex.Text.Replace("'", "''").Trim();
                            cbUF.Text = string.Empty;
                            cbUF.Visible = false;
                            lbDocument.Text = "CNPJ";
                            lbSex.Text = "Ramo";
                            mbDocument.Mask = "00,000,000/0000-00";
                            rbPJ.Checked = true;
                            tbNationality.Text = string.Empty;
                            tbNationality.Visible = false;
                            tbNaturality.Text = string.Empty;
                            tbNaturality.Visible = false;
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
                    tbPassword.Text = DataBase.Tables.Users.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedUser))
                        .CopyToDataTable().Rows[0].Field<string>("Password");
                    User.Password = tbPassword.Text.Replace("'", "''").Trim();
                    tbUsername.Text = DataBase.Tables.Users.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(Globals.SelectedUser))
                        .CopyToDataTable().Rows[0].Field<string>("Username");
                    User.Username = tbUsername.Text.Replace("'", "''").Trim();
                    spAdvanced.Panel2Collapsed = false;
                    spAdvanced.Size = spAdvanced.MaximumSize;
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
                        DataTable documents = DataBase.Populate(Properties.Resources.sql_dgDocument).AsEnumerable()
                            .Where(row => row.Field<long>("IdUsuário").Equals(Globals.SelectedUser))
                            .CopyToDataTable();
                        ckDocument.Checked = true;
                        dgDocument.Size = dgDocument.MaximumSize;
                        for (int i = 0; i < documents.Rows.Count; i++)
                        {
                            dgDocument.Rows.Add();
                            dgDocument.Rows[i].Cells[0].Value = documents.Rows[i].Field<long>("Id");
                            dgDocument.Rows[i].Cells[1].Value = documents.Rows[i].Field<string>("Tipo");
                            dgDocument.Rows[i].Cells[2].Value = documents.Rows[i].Field<string>("Número");
                        }
                        lbNoDocument.Visible = false;
                        spDocument.Panel2Collapsed = false;
                        spDocument.Size = spDocument.MaximumSize;
                    }
                    catch
                    {
                        ckDocument.Checked = false;
                        dgDocument.Size = dgDocument.MinimumSize;
                        lbNoDocument.Visible = true;
                        spDocument.Panel2Collapsed = true;
                        spDocument.Size = spDocument.MinimumSize;
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
            User.HasChanges = false;
        }
        #endregion
        #region Eventos
        #region Validação de dados
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BirthValidated(object sender, EventArgs e)
        {
            if (DateTime.TryParse((sender as DateTimePicker).Text, out DateTime date)) User.Birth = date.ToString("yyyy-MM-dd");
            else User.Birth = string.Empty;
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
        private void MaritalStatusValidated(object sender, EventArgs e)
        {
            User.MaritalStatus = (sender as ComboBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameValidated(object sender, EventArgs e)
        {
            Person.Name = User.Name = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NationalityValidated(object sender, EventArgs e)
        {
            User.Country = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NaturalityValidated(object sender, EventArgs e)
        {
            User.City = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordValidated(object sender, EventArgs e)
        {
            User.Password = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PFValidated(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                Person.Type = "PF";
                Person.Branch = 0;
                Person.BranchText = "PESSOA FÍSICA";
            }
            else
            {
                Person.Type = "PJ";
                Person.Branch = -1;
                Person.BranchText = string.Empty;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SexValidated(object sender, EventArgs e)
        {
            if (rbPF.Checked) User.Sex = (sender as ComboBox).Text.Replace("'", "''").Trim();
            if (rbPJ.Checked)
            {
                if ((sender as ComboBox).SelectedValue != null)
                {
                    Person.Branch = (long)(sender as ComboBox).SelectedValue;
                }
                else
                {
                    Person.Branch = -1;
                    Person.BranchText = (sender as ComboBox).Text.Replace("'", "''").Trim();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusValidated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null) User.Status = (long)(sender as ComboBox).SelectedValue;
            else User.Status = 3;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UFValidated(object sender, EventArgs e)
        {
            User.Estate = (sender as ComboBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsernameValidated(object sender, EventArgs e)
        {
            User.Username = (sender as TextBox).Text.Replace("'", "''").Trim();
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
            if (Globals.SelectedUser.Equals(-1) && User.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            if (!Globals.SelectedUser.Equals(-1) && User.HasChanges)
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
                    if (string.IsNullOrWhiteSpace(Person.Name) || string.IsNullOrWhiteSpace(User.Username) ||
                        string.IsNullOrWhiteSpace(Person.Document) || string.IsNullOrWhiteSpace(Person.BranchText) ||
                        string.IsNullOrWhiteSpace(User.Password))
                    {
                        MessageBox.Show("Campos obrigatórios em branco.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbName.Select();
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("Cancelando a operação, serão cadastrados apenas o nome, nome de usuário e senha deste usuário.\nDeseja sair do assistente de cadastro de usuários?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
            if (Globals.SelectedUser.Equals(-1) && User.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            if (!Globals.SelectedUser.Equals(-1) && User.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("Existem alterações não salvas! As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            switch (BootMode)
            {
                case 2:
                    if (string.IsNullOrWhiteSpace(Person.Name) || string.IsNullOrWhiteSpace(User.Username) ||
                        string.IsNullOrWhiteSpace(Person.Document) || string.IsNullOrWhiteSpace(Person.BranchText) ||
                        string.IsNullOrWhiteSpace(User.Password))
                    {
                        MessageBox.Show("Campos obrigatórios em branco.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbName.Select();
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("Cancelando a operação, serão cadastrados apenas o nome, nome de usuário e senha deste usuário.\nDeseja sair do assistente de cadastro de usuários?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
        private void DisplayPasswordClick(object sender, EventArgs e)
        {
            if (tbPassword.PasswordChar.Equals(Convert.ToChar("*")))
            {
                tbPassword.PasswordChar = (char)0;
                btDisplayPassword.Image = Properties.Resources.VisibilityOn_24x24;
            }
            else
            {
                tbPassword.PasswordChar = Convert.ToChar("*");
                btDisplayPassword.Image = Properties.Resources.VisibilityOff_24x24;
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
        private void EditDocument(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (Globals.IsRunning || e.ColumnIndex < 3) return;
            //long id = (long)dgDocument.Rows[e.RowIndex].Cells[0].Value;
            //DocumentAssistent documentAssistent = new DocumentAssistent(id);
            //documentAssistent.ShowDialog();
            //SuspendLayout();
            //Globals.IsRunning = true;
            //Setup(1);
            //Globals.IsRunning = false;
            //ResumeLayout(false);
            //PerformLayout();
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
        private void EditUser(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Globals.IsRunning || e.ColumnIndex < 3) return;
            SuspendLayout();
            Globals.IsRunning = true;
            Globals.SelectedUser = (long)dgSearch.Rows[e.RowIndex].Cells[0].Value;
            Globals.SelectedPerson = DataBase.Tables.Users.AsEnumerable().
                Where(row => row.Field<long>("Id").Equals(Globals.SelectedUser)).
                CopyToDataTable().Rows[0].Field<long>("Person");
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
        private void NewDocument(object sender, EventArgs e)
        {
            //DocumentAssistent documentAssistent = new DocumentAssistent(-1);
            //documentAssistent.ShowDialog();
            //SuspendLayout();
            //Globals.IsRunning = true;
            //Setup(1);
            //Globals.IsRunning = false;
            //ResumeLayout(false);
            //PerformLayout();
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
        private void NewUser(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            SuspendLayout();
            Globals.IsRunning = true;
            Globals.SelectedPerson = -1;
            Globals.SelectedUser = -1;
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
                filterData = filterData.AsEnumerable()
                              .Where(row => row.Field<string>("Document").Contains(Person.Document))
                              .CopyToDataTable();
            }
            catch { filterData.Rows.Clear(); }
            if (Globals.SelectedUser.Equals(-1) && filterData.Rows.Count > 0)
            {
                MessageBox.Show("Já existe uma pessoa cadastrada com esse CPF/CNPJ.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mbDocument.Select();
                return;
            }
            if (string.IsNullOrWhiteSpace(Person.Name) || string.IsNullOrWhiteSpace(User.Username) ||
                string.IsNullOrWhiteSpace(Person.Document) || string.IsNullOrWhiteSpace(Person.BranchText) ||
                string.IsNullOrWhiteSpace(User.Password))
            {
                MessageBox.Show("Campos obrigatórios não preenchidos.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbName.Select();
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Confirmar cadastro do usuário?",
                "Novo usuário", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (!dialogResult.Equals(DialogResult.Yes))
            {
                tbName.Select();
                return;
            }
            if (Person.Branch.Equals(-1))
            {
                dialogResult = MessageBox.Show("Deseja cadastrar o ramo: \"" + Person.BranchText + "\" no sistema?",
                    "Novo ramo encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult.Equals(DialogResult.Yes))
                {
                    SQLiteConnection sqlConn = DataBase.DataBaseConnection();
                    SQLiteCommand sqlCmd = sqlConn.CreateCommand();
                    sqlCmd.CommandText = Properties.Resources.sqlNewBranch;
                    sqlCmd.Parameters.AddWithValue("@Name", Person.BranchText);
                    sqlCmd.ExecuteNonQuery();
                    sqlConn.Close();
                    DataBase.Types.Branches = DataBase.Populate(Properties.Resources.sqlBranches);
                    Person.Branch = DataBase.Types.Branches.AsEnumerable()
                        .OrderByDescending(row => row.Field<long>("Id")).Take(1)
                        .CopyToDataTable().Rows[0].Field<long>("Id");
                }
                else
                {
                    Globals.IsRunning = false;
                    ResumeLayout(false);
                    PerformLayout();
                    cbSex.Select();
                    return;
                }
            }
            Globals.IsRunning = true;
            SuspendLayout();
            switch (Globals.SelectedPerson)
            {
                case -1:
                    Person.Insert();
                    User.Person = Globals.SelectedPerson;
                    User.Insert();
                    Account.Name = "CARTEIRA " + User.Username;
                    Account.Class = 1;
                    Account.Bank = 0;
                    Account.Status = 3;
                    Account.Type = 1;
                    Account.User = Globals.SelectedUser;
                    MessageBox.Show("Será criada uma carteira para o usuário com nome: CARTEIRA " +
                        User.Username + "\n\n O nome da carteira poderá ser alterado no Gerenciador de Contas",
                        "Novo usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Account.Insert();
                    Debt.Account = Globals.SelectedAccount;
                    Debt.Card = 0;
                    Debt.Category = 1;
                    Debt.Date = DateTime.Today.ToString("yyyy-MM-dd");
                    Debt.Description = "SALDO INICIAL DA CONTA";
                    Debt.Observation = string.Empty;
                    Debt.Opperation = 0;
                    Debt.Parcels = 1;
                    Debt.Person = Globals.SelectedPerson;
                    Debt.Subcategory1 = 0;
                    Debt.DebtClass = 1;
                    Debt.User = Account.User;
                    Debt.DebtValue = 0;
                    Debt.Insert();
                    break;
                default:
                    if (!Globals.SelectedUser.Equals(-1)) User.Update();
                    else
                    {
                        User.Insert();
                        Account.Name = "CARTEIRA " + User.Username;
                        Account.Class = 1;
                        Account.Bank = 0;
                        Account.Status = 3;
                        Account.Type = 1;
                        Account.User = Globals.SelectedUser;
                        MessageBox.Show("Será criada uma carteira para o usuário com nome: " +
                            User.Username + "\n\n O nome da carteira poderá ser alterado no Gerenciador de Contas",
                            "Novo usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Account.Insert();
                        Debt.Account = Globals.SelectedAccount;
                        Debt.Card = 0;
                        Debt.Category = 1;
                        Debt.Date = DateTime.Today.ToString("yyyy-MM-dd");
                        Debt.Description = "SALDO INICIAL DA CONTA";
                        Debt.Observation = string.Empty;
                        Debt.Opperation = 0;
                        Debt.Parcels = 1;
                        Debt.Person = Globals.SelectedPerson;
                        Debt.Subcategory1 = 0;
                        Debt.DebtClass = 1;
                        Debt.User = Account.User;
                        Debt.DebtValue = 0;
                        Debt.Insert();
                    }
                    break;
            }
            MessageBox.Show("Cadastro do usuário realizado com sucesso!", "Novo usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (BootMode.Equals(2)) Close();
            Account.Clear();
            Person.Clear();
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
            DataTable filterData = DataBase.Populate(Properties.Resources.sql_dgSearchUser);
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
                        dgSearch.Rows[i].Cells[2].Value = filterData.Rows[i].Field<string>("Usuário");
                    }
                    lbNoUser.Visible = false;
                    goto Found;
                }
            }
            dgSearch.Rows.Clear();
            dgSearch.Size = dgSearch.MinimumSize;
            lbNoUser.Visible = true;
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
            string[] sex =
            {
                "FEMININO",
                "MASCULINO",
                "OUTRO"
            };
            mbDocument.Text = string.Empty;
            if ((sender as RadioButton).Checked)
            {
                Person.Branch = 0;
                Person.BranchText = "PESSOA FÍSICA";
                cbMaritalStatus.Visible = true;
                cbSex.DataSource = null;
                cbSex.Items.Clear();
                cbSex.Items.AddRange(sex);
                cbSex.SelectedIndex = -1;
                cbUF.Visible = true;
                lbDocument.Text = "CPF";
                lbSex.Text = "Sexo";
                mbDocument.Mask = "000,000,000-00";
                rbPF.Checked = true;
                tbNationality.Visible = true;
                tbNaturality.Visible = true;
            }
            else
            {
                cbMaritalStatus.Visible = false;
                User.MaritalStatus = string.Empty;
                cbSex.DataSource = null;
                cbSex.DataSource = DataBase.Types.Branches;
                cbSex.DisplayMember = "Name";
                cbSex.ValueMember = "Id";
                cbSex.SelectedIndex = -1;
                Person.Branch = -1;
                Person.BranchText = string.Empty;
                User.Sex = string.Empty;
                cbUF.Visible = false;
                User.Estate = string.Empty;
                lbDocument.Text = "CNPJ";
                lbSex.Text = "Ramo";
                mbDocument.Mask = "00,000,000/0000-00";
                rbPJ.Checked = true;
                tbNationality.Visible = false;
                User.Country = string.Empty;
                tbNaturality.Visible = false;
                User.City = string.Empty;
            }
        }
        #endregion
        #endregion

    }
}
