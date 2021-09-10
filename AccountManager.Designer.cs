
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    partial class AccountManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountManager));
            this.spSearch = new System.Windows.Forms.SplitContainer();
            this.ckSearch = new System.Windows.Forms.CheckBox();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btNewAccount = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.cbFilterType = new System.Windows.Forms.ComboBox();
            this.lbNoAccount = new System.Windows.Forms.Label();
            this.dgSearch = new System.Windows.Forms.DataGridView();
            this.clId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.flHeadersSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.lbHeaderName = new System.Windows.Forms.Label();
            this.lbHeaderUser = new System.Windows.Forms.Label();
            this.lbHeaderClass = new System.Windows.Forms.Label();
            this.lbEditAccount = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbBankCode = new System.Windows.Forms.Label();
            this.lbFee = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbAgency = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.lbPerson = new System.Windows.Forms.Label();
            this.tbBankCode = new System.Windows.Forms.TextBox();
            this.tbOverdraft = new System.Windows.Forms.TextBox();
            this.tbAgency = new System.Windows.Forms.TextBox();
            this.lbOverdraft = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.tbFee = new System.Windows.Forms.TextBox();
            this.cbFeeUnit = new System.Windows.Forms.ComboBox();
            this.pnCommand = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.pnManager = new System.Windows.Forms.Panel();
            this.pnControls = new System.Windows.Forms.Panel();
            this.spCards = new System.Windows.Forms.SplitContainer();
            this.ckCards = new System.Windows.Forms.CheckBox();
            this.flCards = new System.Windows.Forms.FlowLayoutPanel();
            this.btNewCard = new System.Windows.Forms.PictureBox();
            this.flHeadersCard = new System.Windows.Forms.FlowLayoutPanel();
            this.lbHeaderCard = new System.Windows.Forms.Label();
            this.lbHeaderCardType = new System.Windows.Forms.Label();
            this.lbHeaderCardFlag = new System.Windows.Forms.Label();
            this.lbEditPhone = new System.Windows.Forms.Label();
            this.dgCards = new System.Windows.Forms.DataGridView();
            this.clIdCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCardFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCardEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lbNoCard = new System.Windows.Forms.Label();
            this.spGenInfo = new System.Windows.Forms.SplitContainer();
            this.ckGenInfo = new System.Windows.Forms.CheckBox();
            this.flAccountInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.brTools = new System.Windows.Forms.ToolStrip();
            this.btActions = new System.Windows.Forms.ToolStripDropDownButton();
            this.btCloseAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.btDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.tbStatus = new System.Windows.Forms.ToolStripLabel();
            this.lbStatus = new System.Windows.Forms.ToolStripLabel();
            this.lbClass = new System.Windows.Forms.Label();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.cbBank = new System.Windows.Forms.ComboBox();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.lbGrace = new System.Windows.Forms.Label();
            this.tbGrace = new System.Windows.Forms.TextBox();
            this.cbGraceUnit = new System.Windows.Forms.ComboBox();
            this.lbAccountName = new System.Windows.Forms.Label();
            this.lbBalance = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbBalance = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tpAccountManager = new System.Windows.Forms.ToolTip(this.components);
            this.pnWindow = new System.Windows.Forms.Panel();
            this.brMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.imMenu = new System.Windows.Forms.PictureBox();
            this.lbMenu = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spSearch)).BeginInit();
            this.spSearch.Panel1.SuspendLayout();
            this.spSearch.Panel2.SuspendLayout();
            this.spSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSearch)).BeginInit();
            this.flHeadersSearch.SuspendLayout();
            this.pnCommand.SuspendLayout();
            this.pnManager.SuspendLayout();
            this.pnControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spCards)).BeginInit();
            this.spCards.Panel1.SuspendLayout();
            this.spCards.Panel2.SuspendLayout();
            this.spCards.SuspendLayout();
            this.flCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btNewCard)).BeginInit();
            this.flHeadersCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGenInfo)).BeginInit();
            this.spGenInfo.Panel1.SuspendLayout();
            this.spGenInfo.Panel2.SuspendLayout();
            this.spGenInfo.SuspendLayout();
            this.flAccountInfo.SuspendLayout();
            this.brTools.SuspendLayout();
            this.pnWindow.SuspendLayout();
            this.brMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // spSearch
            // 
            this.spSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.spSearch.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spSearch.IsSplitterFixed = true;
            this.spSearch.Location = new System.Drawing.Point(0, 0);
            this.spSearch.Margin = new System.Windows.Forms.Padding(0);
            this.spSearch.MaximumSize = new System.Drawing.Size(750, 466);
            this.spSearch.MinimumSize = new System.Drawing.Size(750, 50);
            this.spSearch.Name = "spSearch";
            this.spSearch.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spSearch.Panel1
            // 
            this.spSearch.Panel1.Controls.Add(this.ckSearch);
            this.spSearch.Panel1.Controls.Add(this.tbFilter);
            this.spSearch.Panel1.Controls.Add(this.btNewAccount);
            this.spSearch.Panel1.Controls.Add(this.btSearch);
            this.spSearch.Panel1.Controls.Add(this.cbFilterType);
            this.spSearch.Panel1.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.spSearch.Panel1MinSize = 0;
            // 
            // spSearch.Panel2
            // 
            this.spSearch.Panel2.Controls.Add(this.lbNoAccount);
            this.spSearch.Panel2.Controls.Add(this.dgSearch);
            this.spSearch.Panel2.Controls.Add(this.flHeadersSearch);
            this.spSearch.Panel2.Padding = new System.Windows.Forms.Padding(58, 45, 32, 45);
            this.spSearch.Panel2MinSize = 0;
            this.spSearch.Size = this.spSearch.MinimumSize;
            this.spSearch.SplitterDistance = 25;
            this.spSearch.SplitterWidth = 1;
            this.spSearch.TabIndex = 0;
            // 
            // ckSearch
            // 
            this.ckSearch.AutoSize = true;
            this.ckSearch.Location = new System.Drawing.Point(18, 17);
            this.ckSearch.Name = "ckSearch";
            this.ckSearch.Size = new System.Drawing.Size(15, 14);
            this.ckSearch.TabIndex = 4;
            this.ckSearch.TabStop = false;
            this.ckSearch.UseVisualStyleBackColor = true;
            this.ckSearch.Visible = false;
            // 
            // tbFilter
            // 
            this.tbFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilter.Location = new System.Drawing.Point(97, 12);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(292, 25);
            this.tbFilter.TabIndex = 0;
            // 
            // btNewAccount
            // 
            this.btNewAccount.AutoSize = true;
            this.btNewAccount.BackColor = System.Drawing.SystemColors.Control;
            this.btNewAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNewAccount.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btNewAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(234)))), ((int)(((byte)(249)))));
            this.btNewAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNewAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNewAccount.ForeColor = System.Drawing.Color.DarkGreen;
            this.btNewAccount.Image = global::SISCOFIN_v1.Properties.Resources.AddFile_24x24;
            this.btNewAccount.Location = new System.Drawing.Point(571, 8);
            this.btNewAccount.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btNewAccount.Name = "btNewAccount";
            this.btNewAccount.Size = new System.Drawing.Size(82, 32);
            this.btNewAccount.TabIndex = 3;
            this.btNewAccount.Text = "Novo";
            this.btNewAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btNewAccount.UseVisualStyleBackColor = false;
            this.btNewAccount.Click += new System.EventHandler(this.NewAccount);
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(234)))), ((int)(((byte)(249)))));
            this.btSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearch.Image = global::SISCOFIN_v1.Properties.Resources.Search_24x24;
            this.btSearch.Location = new System.Drawing.Point(536, 8);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(32, 32);
            this.btSearch.TabIndex = 2;
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.SearchClick);
            // 
            // cbFilterType
            // 
            this.cbFilterType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterType.FormattingEnabled = true;
            this.cbFilterType.Location = new System.Drawing.Point(392, 12);
            this.cbFilterType.Margin = new System.Windows.Forms.Padding(0);
            this.cbFilterType.Name = "cbFilterType";
            this.cbFilterType.Size = new System.Drawing.Size(141, 25);
            this.cbFilterType.Sorted = true;
            this.cbFilterType.TabIndex = 1;
            // 
            // lbNoAccount
            // 
            this.lbNoAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbNoAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoAccount.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbNoAccount.Location = new System.Drawing.Point(58, 390);
            this.lbNoAccount.Margin = new System.Windows.Forms.Padding(0);
            this.lbNoAccount.Name = "lbNoAccount";
            this.lbNoAccount.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.lbNoAccount.Size = new System.Drawing.Size(660, 34);
            this.lbNoAccount.TabIndex = 56;
            this.lbNoAccount.Text = "NENHUMA CONTA ENCONTRADA";
            this.lbNoAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbNoAccount.Visible = false;
            // 
            // dgSearch
            // 
            this.dgSearch.AllowUserToAddRows = false;
            this.dgSearch.AllowUserToDeleteRows = false;
            this.dgSearch.AllowUserToResizeColumns = false;
            this.dgSearch.AllowUserToResizeRows = false;
            this.dgSearch.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSearch.ColumnHeadersVisible = false;
            this.dgSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clId,
            this.clName,
            this.clUser,
            this.clClass,
            this.clEdit});
            this.dgSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgSearch.GridColor = System.Drawing.SystemColors.Window;
            this.dgSearch.Location = new System.Drawing.Point(58, 82);
            this.dgSearch.Margin = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.dgSearch.MaximumSize = new System.Drawing.Size(660, 308);
            this.dgSearch.MinimumSize = new System.Drawing.Size(660, 0);
            this.dgSearch.MultiSelect = false;
            this.dgSearch.Name = "dgSearch";
            this.dgSearch.ReadOnly = true;
            this.dgSearch.RowHeadersVisible = false;
            this.dgSearch.RowTemplate.DividerHeight = 2;
            this.dgSearch.RowTemplate.ReadOnly = true;
            this.dgSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSearch.Size = new System.Drawing.Size(660, 308);
            this.dgSearch.TabIndex = 54;
            this.dgSearch.TabStop = false;
            // 
            // clId
            // 
            this.clId.HeaderText = "Id";
            this.clId.Name = "clId";
            this.clId.ReadOnly = true;
            this.clId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clId.Visible = false;
            // 
            // clName
            // 
            this.clName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.clName.DefaultCellStyle = dataGridViewCellStyle1;
            this.clName.DividerWidth = 2;
            this.clName.HeaderText = "Nome da conta";
            this.clName.Name = "clName";
            this.clName.ReadOnly = true;
            this.clName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clName.Width = 202;
            // 
            // clUser
            // 
            this.clUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.clUser.DefaultCellStyle = dataGridViewCellStyle2;
            this.clUser.DividerWidth = 2;
            this.clUser.HeaderText = "Titular";
            this.clUser.Name = "clUser";
            this.clUser.ReadOnly = true;
            this.clUser.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clUser.Width = 203;
            // 
            // clClass
            // 
            this.clClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.clClass.DefaultCellStyle = dataGridViewCellStyle3;
            this.clClass.DividerWidth = 2;
            this.clClass.HeaderText = "Classe da conta";
            this.clClass.Name = "clClass";
            this.clClass.ReadOnly = true;
            this.clClass.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clClass.Width = 179;
            // 
            // clEdit
            // 
            this.clEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkGreen;
            this.clEdit.DefaultCellStyle = dataGridViewCellStyle4;
            this.clEdit.DividerWidth = 2;
            this.clEdit.HeaderText = "Editar";
            this.clEdit.Name = "clEdit";
            this.clEdit.ReadOnly = true;
            this.clEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clEdit.Text = "Editar";
            this.clEdit.UseColumnTextForButtonValue = true;
            this.clEdit.Width = 60;
            // 
            // flHeadersSearch
            // 
            this.flHeadersSearch.Controls.Add(this.lbHeaderName);
            this.flHeadersSearch.Controls.Add(this.lbHeaderUser);
            this.flHeadersSearch.Controls.Add(this.lbHeaderClass);
            this.flHeadersSearch.Controls.Add(this.lbEditAccount);
            this.flHeadersSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.flHeadersSearch.Location = new System.Drawing.Point(58, 45);
            this.flHeadersSearch.Margin = new System.Windows.Forms.Padding(0);
            this.flHeadersSearch.Name = "flHeadersSearch";
            this.flHeadersSearch.Padding = new System.Windows.Forms.Padding(0, 0, 19, 0);
            this.flHeadersSearch.Size = new System.Drawing.Size(660, 37);
            this.flHeadersSearch.TabIndex = 55;
            // 
            // lbHeaderName
            // 
            this.lbHeaderName.BackColor = System.Drawing.Color.DarkGreen;
            this.lbHeaderName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeaderName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbHeaderName.Location = new System.Drawing.Point(0, 0);
            this.lbHeaderName.Margin = new System.Windows.Forms.Padding(0);
            this.lbHeaderName.Name = "lbHeaderName";
            this.lbHeaderName.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbHeaderName.Size = new System.Drawing.Size(200, 35);
            this.lbHeaderName.TabIndex = 0;
            this.lbHeaderName.Text = "Nome da Conta";
            this.lbHeaderName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHeaderUser
            // 
            this.lbHeaderUser.BackColor = System.Drawing.Color.DarkGreen;
            this.lbHeaderUser.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeaderUser.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbHeaderUser.Location = new System.Drawing.Point(203, 0);
            this.lbHeaderUser.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbHeaderUser.Name = "lbHeaderUser";
            this.lbHeaderUser.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbHeaderUser.Size = new System.Drawing.Size(200, 35);
            this.lbHeaderUser.TabIndex = 1;
            this.lbHeaderUser.Text = "Titular";
            this.lbHeaderUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHeaderClass
            // 
            this.lbHeaderClass.BackColor = System.Drawing.Color.DarkGreen;
            this.lbHeaderClass.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeaderClass.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbHeaderClass.Location = new System.Drawing.Point(406, 0);
            this.lbHeaderClass.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbHeaderClass.Name = "lbHeaderClass";
            this.lbHeaderClass.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbHeaderClass.Size = new System.Drawing.Size(177, 35);
            this.lbHeaderClass.TabIndex = 2;
            this.lbHeaderClass.Text = "Classe";
            this.lbHeaderClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbEditAccount
            // 
            this.lbEditAccount.BackColor = System.Drawing.Color.DarkGreen;
            this.lbEditAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEditAccount.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbEditAccount.Location = new System.Drawing.Point(586, 0);
            this.lbEditAccount.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbEditAccount.Name = "lbEditAccount";
            this.lbEditAccount.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbEditAccount.Size = new System.Drawing.Size(55, 35);
            this.lbEditAccount.TabIndex = 3;
            this.lbEditAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbUser
            // 
            this.lbUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbUser.Location = new System.Drawing.Point(53, 165);
            this.lbUser.Margin = new System.Windows.Forms.Padding(53, 7, 2, 1);
            this.lbUser.Name = "lbUser";
            this.lbUser.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbUser.Size = new System.Drawing.Size(322, 21);
            this.lbUser.TabIndex = 63;
            this.lbUser.Text = "Usuário";
            this.lbUser.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbBankCode
            // 
            this.lbBankCode.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBankCode.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbBankCode.Location = new System.Drawing.Point(570, 108);
            this.lbBankCode.Margin = new System.Windows.Forms.Padding(0, 7, 0, 1);
            this.lbBankCode.Name = "lbBankCode";
            this.lbBankCode.Size = new System.Drawing.Size(127, 21);
            this.lbBankCode.TabIndex = 65;
            this.lbBankCode.Text = "Código";
            this.lbBankCode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lbFee
            // 
            this.lbFee.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFee.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbFee.Location = new System.Drawing.Point(219, 222);
            this.lbFee.Margin = new System.Windows.Forms.Padding(0, 7, 2, 1);
            this.lbFee.Name = "lbFee";
            this.lbFee.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbFee.Size = new System.Drawing.Size(219, 21);
            this.lbFee.TabIndex = 80;
            this.lbFee.Text = "Juros";
            this.lbFee.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbNumber
            // 
            this.lbNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumber.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbNumber.Location = new System.Drawing.Point(488, 165);
            this.lbNumber.Margin = new System.Windows.Forms.Padding(0, 7, 2, 1);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbNumber.Size = new System.Drawing.Size(209, 21);
            this.lbNumber.TabIndex = 66;
            this.lbNumber.Text = "Conta";
            this.lbNumber.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbAgency
            // 
            this.lbAgency.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAgency.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbAgency.Location = new System.Drawing.Point(377, 165);
            this.lbAgency.Margin = new System.Windows.Forms.Padding(0, 7, 2, 1);
            this.lbAgency.Name = "lbAgency";
            this.lbAgency.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbAgency.Size = new System.Drawing.Size(109, 21);
            this.lbAgency.TabIndex = 67;
            this.lbAgency.Text = "Agência";
            this.lbAgency.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbType
            // 
            this.lbType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbType.Location = new System.Drawing.Point(377, 51);
            this.lbType.Margin = new System.Windows.Forms.Padding(0, 3, 0, 1);
            this.lbType.Name = "lbType";
            this.lbType.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbType.Size = new System.Drawing.Size(305, 21);
            this.lbType.TabIndex = 68;
            this.lbType.Text = "Tipo da conta";
            this.lbType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbPerson
            // 
            this.lbPerson.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPerson.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbPerson.Location = new System.Drawing.Point(53, 108);
            this.lbPerson.Margin = new System.Windows.Forms.Padding(53, 7, 2, 1);
            this.lbPerson.Name = "lbPerson";
            this.lbPerson.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbPerson.Size = new System.Drawing.Size(515, 21);
            this.lbPerson.TabIndex = 64;
            this.lbPerson.Text = "Instituição financeira";
            this.lbPerson.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbBankCode
            // 
            this.tbBankCode.BackColor = System.Drawing.SystemColors.Window;
            this.tbBankCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBankCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBankCode.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbBankCode.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBankCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbBankCode.Location = new System.Drawing.Point(570, 130);
            this.tbBankCode.Margin = new System.Windows.Forms.Padding(0);
            this.tbBankCode.Name = "tbBankCode";
            this.tbBankCode.ReadOnly = true;
            this.tbBankCode.Size = new System.Drawing.Size(127, 26);
            this.tbBankCode.TabIndex = 3;
            this.tbBankCode.TabStop = false;
            this.tbBankCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOverdraft
            // 
            this.tbOverdraft.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbOverdraft.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbOverdraft.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbOverdraft.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOverdraft.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbOverdraft.Location = new System.Drawing.Point(53, 244);
            this.tbOverdraft.Margin = new System.Windows.Forms.Padding(53, 0, 2, 0);
            this.tbOverdraft.Name = "tbOverdraft";
            this.tbOverdraft.Size = new System.Drawing.Size(164, 27);
            this.tbOverdraft.TabIndex = 6;
            this.tbOverdraft.Text = "0,00";
            this.tbOverdraft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbOverdraft.Validated += new System.EventHandler(this.OverdraftValidated);
            // 
            // tbAgency
            // 
            this.tbAgency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbAgency.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAgency.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAgency.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbAgency.Location = new System.Drawing.Point(377, 187);
            this.tbAgency.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tbAgency.Name = "tbAgency";
            this.tbAgency.Size = new System.Drawing.Size(109, 27);
            this.tbAgency.TabIndex = 4;
            this.tbAgency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbAgency.Validated += new System.EventHandler(this.AgencyValidated);
            // 
            // lbOverdraft
            // 
            this.lbOverdraft.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOverdraft.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbOverdraft.Location = new System.Drawing.Point(53, 222);
            this.lbOverdraft.Margin = new System.Windows.Forms.Padding(53, 7, 2, 1);
            this.lbOverdraft.Name = "lbOverdraft";
            this.lbOverdraft.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbOverdraft.Size = new System.Drawing.Size(164, 21);
            this.lbOverdraft.TabIndex = 75;
            this.lbOverdraft.Text = "Limite";
            this.lbOverdraft.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbNumber
            // 
            this.tbNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbNumber.Location = new System.Drawing.Point(488, 187);
            this.tbNumber.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(209, 27);
            this.tbNumber.TabIndex = 5;
            this.tbNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbNumber.Validated += new System.EventHandler(this.NumberValidated);
            // 
            // tbFee
            // 
            this.tbFee.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbFee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbFee.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFee.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFee.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbFee.Location = new System.Drawing.Point(219, 244);
            this.tbFee.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tbFee.Name = "tbFee";
            this.tbFee.Size = new System.Drawing.Size(102, 27);
            this.tbFee.TabIndex = 7;
            this.tbFee.Text = "0,00";
            this.tbFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbFee.Validated += new System.EventHandler(this.FeeValidated);
            // 
            // cbFeeUnit
            // 
            this.cbFeeUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFeeUnit.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cbFeeUnit.FormattingEnabled = true;
            this.cbFeeUnit.Location = new System.Drawing.Point(323, 244);
            this.cbFeeUnit.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.cbFeeUnit.Name = "cbFeeUnit";
            this.cbFeeUnit.Size = new System.Drawing.Size(115, 28);
            this.cbFeeUnit.TabIndex = 8;
            this.cbFeeUnit.Text = "% AO DIA";
            this.cbFeeUnit.Validated += new System.EventHandler(this.FeeUnitValidated);
            // 
            // pnCommand
            // 
            this.pnCommand.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnCommand.Controls.Add(this.btCancel);
            this.pnCommand.Controls.Add(this.btSave);
            this.pnCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnCommand.Location = new System.Drawing.Point(0, 358);
            this.pnCommand.Name = "pnCommand";
            this.pnCommand.Size = new System.Drawing.Size(748, 53);
            this.pnCommand.TabIndex = 83;
            this.pnCommand.TabStop = true;
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.DarkGreen;
            this.btCancel.Location = new System.Drawing.Point(509, 15);
            this.btCancel.Margin = new System.Windows.Forms.Padding(15, 15, 2, 15);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(111, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancelar";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btSave.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.ForeColor = System.Drawing.Color.DarkGreen;
            this.btSave.Location = new System.Drawing.Point(624, 15);
            this.btSave.Margin = new System.Windows.Forms.Padding(2, 15, 15, 15);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(111, 23);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "Salvar";
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.SaveClick);
            // 
            // cbType
            // 
            this.cbType.BackColor = System.Drawing.SystemColors.Window;
            this.cbType.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbType.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "AO ANO(%)",
            "AO DIA(%)",
            "AO MÊS(%)"});
            this.cbType.Location = new System.Drawing.Point(377, 73);
            this.cbType.Margin = new System.Windows.Forms.Padding(0);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(320, 28);
            this.cbType.TabIndex = 1;
            this.cbType.TextChanged += new System.EventHandler(this.AccountTypeTextChanged);
            this.cbType.Validated += new System.EventHandler(this.AccountTypeValidated);
            // 
            // pnManager
            // 
            this.pnManager.AutoScroll = true;
            this.pnManager.Controls.Add(this.pnControls);
            this.pnManager.Controls.Add(this.pnCommand);
            this.pnManager.Controls.Add(this.lbTitle);
            this.pnManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnManager.Location = new System.Drawing.Point(0, 54);
            this.pnManager.Name = "pnManager";
            this.pnManager.Size = new System.Drawing.Size(748, 411);
            this.pnManager.TabIndex = 84;
            // 
            // pnControls
            // 
            this.pnControls.AutoScroll = true;
            this.pnControls.Controls.Add(this.spCards);
            this.pnControls.Controls.Add(this.spGenInfo);
            this.pnControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnControls.Location = new System.Drawing.Point(0, 28);
            this.pnControls.Margin = new System.Windows.Forms.Padding(0);
            this.pnControls.Name = "pnControls";
            this.pnControls.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnControls.Size = new System.Drawing.Size(748, 330);
            this.pnControls.TabIndex = 101;
            // 
            // spCards
            // 
            this.spCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.spCards.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spCards.IsSplitterFixed = true;
            this.spCards.Location = new System.Drawing.Point(3, 380);
            this.spCards.Margin = new System.Windows.Forms.Padding(0);
            this.spCards.MaximumSize = new System.Drawing.Size(746, 341);
            this.spCards.MinimumSize = new System.Drawing.Size(746, 40);
            this.spCards.Name = "spCards";
            this.spCards.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spCards.Panel1
            // 
            this.spCards.Panel1.Controls.Add(this.ckCards);
            this.spCards.Panel1MinSize = 0;
            // 
            // spCards.Panel2
            // 
            this.spCards.Panel2.Controls.Add(this.flCards);
            this.spCards.Panel2MinSize = 0;
            this.spCards.Size = new System.Drawing.Size(746, 341);
            this.spCards.SplitterDistance = 38;
            this.spCards.SplitterWidth = 1;
            this.spCards.TabIndex = 100;
            // 
            // ckCards
            // 
            this.ckCards.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckCards.BackColor = System.Drawing.Color.DarkGreen;
            this.ckCards.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckCards.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.ckCards.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
            this.ckCards.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.ckCards.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.ckCards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckCards.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckCards.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ckCards.Image = global::SISCOFIN_v1.Properties.Resources.MenuButtonWhite_16x16;
            this.ckCards.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ckCards.Location = new System.Drawing.Point(0, 0);
            this.ckCards.Margin = new System.Windows.Forms.Padding(0);
            this.ckCards.Name = "ckCards";
            this.ckCards.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ckCards.Size = new System.Drawing.Size(746, 38);
            this.ckCards.TabIndex = 2;
            this.ckCards.Text = " Cartões";
            this.ckCards.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ckCards.UseVisualStyleBackColor = false;
            // 
            // flCards
            // 
            this.flCards.Controls.Add(this.btNewCard);
            this.flCards.Controls.Add(this.flHeadersCard);
            this.flCards.Controls.Add(this.dgCards);
            this.flCards.Controls.Add(this.lbNoCard);
            this.flCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flCards.Location = new System.Drawing.Point(0, 0);
            this.flCards.Name = "flCards";
            this.flCards.Size = new System.Drawing.Size(746, 302);
            this.flCards.TabIndex = 98;
            // 
            // btNewCard
            // 
            this.btNewCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNewCard.Image = global::SISCOFIN_v1.Properties.Resources.AddCard_32x32;
            this.btNewCard.Location = new System.Drawing.Point(51, 17);
            this.btNewCard.Margin = new System.Windows.Forms.Padding(51, 17, 663, 0);
            this.btNewCard.Name = "btNewCard";
            this.btNewCard.Size = new System.Drawing.Size(32, 32);
            this.btNewCard.TabIndex = 98;
            this.btNewCard.TabStop = false;
            this.tpAccountManager.SetToolTip(this.btNewCard, "Novo cartão");
            this.btNewCard.Click += new System.EventHandler(this.NewCard);
            // 
            // flHeadersCard
            // 
            this.flHeadersCard.Controls.Add(this.lbHeaderCard);
            this.flHeadersCard.Controls.Add(this.lbHeaderCardType);
            this.flHeadersCard.Controls.Add(this.lbHeaderCardFlag);
            this.flHeadersCard.Controls.Add(this.lbEditPhone);
            this.flHeadersCard.Location = new System.Drawing.Point(51, 52);
            this.flHeadersCard.Margin = new System.Windows.Forms.Padding(51, 3, 32, 0);
            this.flHeadersCard.Name = "flHeadersCard";
            this.flHeadersCard.Size = new System.Drawing.Size(663, 30);
            this.flHeadersCard.TabIndex = 105;
            // 
            // lbHeaderCard
            // 
            this.lbHeaderCard.BackColor = System.Drawing.Color.DarkGreen;
            this.lbHeaderCard.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeaderCard.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbHeaderCard.Location = new System.Drawing.Point(0, 0);
            this.lbHeaderCard.Margin = new System.Windows.Forms.Padding(0);
            this.lbHeaderCard.Name = "lbHeaderCard";
            this.lbHeaderCard.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbHeaderCard.Size = new System.Drawing.Size(194, 30);
            this.lbHeaderCard.TabIndex = 1;
            this.lbHeaderCard.Text = "Final";
            this.lbHeaderCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHeaderCardType
            // 
            this.lbHeaderCardType.BackColor = System.Drawing.Color.DarkGreen;
            this.lbHeaderCardType.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeaderCardType.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbHeaderCardType.Location = new System.Drawing.Point(197, 0);
            this.lbHeaderCardType.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbHeaderCardType.Name = "lbHeaderCardType";
            this.lbHeaderCardType.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbHeaderCardType.Size = new System.Drawing.Size(193, 30);
            this.lbHeaderCardType.TabIndex = 2;
            this.lbHeaderCardType.Text = "Tipo";
            this.lbHeaderCardType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHeaderCardFlag
            // 
            this.lbHeaderCardFlag.BackColor = System.Drawing.Color.DarkGreen;
            this.lbHeaderCardFlag.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeaderCardFlag.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbHeaderCardFlag.Location = new System.Drawing.Point(393, 0);
            this.lbHeaderCardFlag.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbHeaderCardFlag.Name = "lbHeaderCardFlag";
            this.lbHeaderCardFlag.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbHeaderCardFlag.Size = new System.Drawing.Size(193, 30);
            this.lbHeaderCardFlag.TabIndex = 97;
            this.lbHeaderCardFlag.Text = "Bandeira";
            this.lbHeaderCardFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbEditPhone
            // 
            this.lbEditPhone.BackColor = System.Drawing.Color.DarkGreen;
            this.lbEditPhone.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEditPhone.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbEditPhone.Location = new System.Drawing.Point(589, 0);
            this.lbEditPhone.Margin = new System.Windows.Forms.Padding(3, 0, 19, 0);
            this.lbEditPhone.Name = "lbEditPhone";
            this.lbEditPhone.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbEditPhone.Size = new System.Drawing.Size(55, 30);
            this.lbEditPhone.TabIndex = 104;
            this.lbEditPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgCards
            // 
            this.dgCards.AllowUserToAddRows = false;
            this.dgCards.AllowUserToDeleteRows = false;
            this.dgCards.AllowUserToResizeColumns = false;
            this.dgCards.AllowUserToResizeRows = false;
            this.dgCards.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgCards.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgCards.ColumnHeadersVisible = false;
            this.dgCards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clIdCard,
            this.clCard,
            this.clCardType,
            this.clCardFlag,
            this.clCardEdit});
            this.dgCards.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgCards.GridColor = System.Drawing.SystemColors.Window;
            this.dgCards.Location = new System.Drawing.Point(51, 85);
            this.dgCards.Margin = new System.Windows.Forms.Padding(51, 3, 32, 0);
            this.dgCards.MaximumSize = new System.Drawing.Size(663, 182);
            this.dgCards.MinimumSize = new System.Drawing.Size(663, 0);
            this.dgCards.MultiSelect = false;
            this.dgCards.Name = "dgCards";
            this.dgCards.ReadOnly = true;
            this.dgCards.RowHeadersVisible = false;
            this.dgCards.RowTemplate.DividerHeight = 2;
            this.dgCards.RowTemplate.ReadOnly = true;
            this.dgCards.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCards.Size = new System.Drawing.Size(663, 182);
            this.dgCards.TabIndex = 94;
            this.dgCards.TabStop = false;
            this.dgCards.Tag = "4";
            // 
            // clIdCard
            // 
            this.clIdCard.HeaderText = "Id";
            this.clIdCard.Name = "clIdCard";
            this.clIdCard.ReadOnly = true;
            this.clIdCard.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clIdCard.Visible = false;
            // 
            // clCard
            // 
            this.clCard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.clCard.DefaultCellStyle = dataGridViewCellStyle5;
            this.clCard.DividerWidth = 2;
            this.clCard.HeaderText = "Final";
            this.clCard.Name = "clCard";
            this.clCard.ReadOnly = true;
            this.clCard.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clCard.Width = 196;
            // 
            // clCardType
            // 
            this.clCardType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clCardType.DefaultCellStyle = dataGridViewCellStyle6;
            this.clCardType.DividerWidth = 2;
            this.clCardType.HeaderText = "Tipo";
            this.clCardType.Name = "clCardType";
            this.clCardType.ReadOnly = true;
            this.clCardType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clCardType.Width = 196;
            // 
            // clCardFlag
            // 
            this.clCardFlag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clCardFlag.DefaultCellStyle = dataGridViewCellStyle7;
            this.clCardFlag.DividerWidth = 2;
            this.clCardFlag.HeaderText = "Bandeira";
            this.clCardFlag.Name = "clCardFlag";
            this.clCardFlag.ReadOnly = true;
            this.clCardFlag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clCardFlag.Width = 195;
            // 
            // clCardEdit
            // 
            this.clCardEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DarkGreen;
            this.clCardEdit.DefaultCellStyle = dataGridViewCellStyle8;
            this.clCardEdit.DividerWidth = 2;
            this.clCardEdit.HeaderText = "Editar";
            this.clCardEdit.Name = "clCardEdit";
            this.clCardEdit.ReadOnly = true;
            this.clCardEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clCardEdit.Text = "Editar";
            this.clCardEdit.UseColumnTextForButtonValue = true;
            this.clCardEdit.Width = 60;
            // 
            // lbNoCard
            // 
            this.lbNoCard.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoCard.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbNoCard.Location = new System.Drawing.Point(51, 267);
            this.lbNoCard.Margin = new System.Windows.Forms.Padding(51, 0, 51, 0);
            this.lbNoCard.Name = "lbNoCard";
            this.lbNoCard.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.lbNoCard.Size = new System.Drawing.Size(644, 34);
            this.lbNoCard.TabIndex = 96;
            this.lbNoCard.Text = "NENHUM CARTÃO ENCONTRADO";
            this.lbNoCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbNoCard.Visible = false;
            // 
            // spGenInfo
            // 
            this.spGenInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.spGenInfo.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spGenInfo.IsSplitterFixed = true;
            this.spGenInfo.Location = new System.Drawing.Point(3, 0);
            this.spGenInfo.Margin = new System.Windows.Forms.Padding(0);
            this.spGenInfo.MaximumSize = new System.Drawing.Size(746, 380);
            this.spGenInfo.MinimumSize = new System.Drawing.Size(746, 40);
            this.spGenInfo.Name = "spGenInfo";
            this.spGenInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spGenInfo.Panel1
            // 
            this.spGenInfo.Panel1.Controls.Add(this.ckGenInfo);
            this.spGenInfo.Panel1MinSize = 0;
            // 
            // spGenInfo.Panel2
            // 
            this.spGenInfo.Panel2.Controls.Add(this.flAccountInfo);
            this.spGenInfo.Panel2MinSize = 0;
            this.spGenInfo.Size = new System.Drawing.Size(746, 380);
            this.spGenInfo.SplitterDistance = 38;
            this.spGenInfo.SplitterWidth = 1;
            this.spGenInfo.TabIndex = 99;
            // 
            // ckGenInfo
            // 
            this.ckGenInfo.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckGenInfo.BackColor = System.Drawing.Color.DarkGreen;
            this.ckGenInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckGenInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckGenInfo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.ckGenInfo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
            this.ckGenInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.ckGenInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.ckGenInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckGenInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckGenInfo.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ckGenInfo.Image = global::SISCOFIN_v1.Properties.Resources.MenuButtonWhite_16x16;
            this.ckGenInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ckGenInfo.Location = new System.Drawing.Point(0, 0);
            this.ckGenInfo.Name = "ckGenInfo";
            this.ckGenInfo.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ckGenInfo.Size = new System.Drawing.Size(746, 38);
            this.ckGenInfo.TabIndex = 3;
            this.ckGenInfo.Text = " Dados Gerais";
            this.ckGenInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ckGenInfo.UseVisualStyleBackColor = false;
            // 
            // flAccountInfo
            // 
            this.flAccountInfo.Controls.Add(this.brTools);
            this.flAccountInfo.Controls.Add(this.lbClass);
            this.flAccountInfo.Controls.Add(this.lbType);
            this.flAccountInfo.Controls.Add(this.cbClass);
            this.flAccountInfo.Controls.Add(this.cbType);
            this.flAccountInfo.Controls.Add(this.lbPerson);
            this.flAccountInfo.Controls.Add(this.lbBankCode);
            this.flAccountInfo.Controls.Add(this.cbBank);
            this.flAccountInfo.Controls.Add(this.tbBankCode);
            this.flAccountInfo.Controls.Add(this.lbUser);
            this.flAccountInfo.Controls.Add(this.lbAgency);
            this.flAccountInfo.Controls.Add(this.lbNumber);
            this.flAccountInfo.Controls.Add(this.cbUser);
            this.flAccountInfo.Controls.Add(this.tbAgency);
            this.flAccountInfo.Controls.Add(this.tbNumber);
            this.flAccountInfo.Controls.Add(this.lbOverdraft);
            this.flAccountInfo.Controls.Add(this.lbFee);
            this.flAccountInfo.Controls.Add(this.lbGrace);
            this.flAccountInfo.Controls.Add(this.tbOverdraft);
            this.flAccountInfo.Controls.Add(this.tbFee);
            this.flAccountInfo.Controls.Add(this.cbFeeUnit);
            this.flAccountInfo.Controls.Add(this.tbGrace);
            this.flAccountInfo.Controls.Add(this.cbGraceUnit);
            this.flAccountInfo.Controls.Add(this.lbAccountName);
            this.flAccountInfo.Controls.Add(this.lbBalance);
            this.flAccountInfo.Controls.Add(this.tbName);
            this.flAccountInfo.Controls.Add(this.tbBalance);
            this.flAccountInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flAccountInfo.Location = new System.Drawing.Point(0, 0);
            this.flAccountInfo.Margin = new System.Windows.Forms.Padding(0);
            this.flAccountInfo.Name = "flAccountInfo";
            this.flAccountInfo.Size = new System.Drawing.Size(746, 341);
            this.flAccountInfo.TabIndex = 88;
            // 
            // brTools
            // 
            this.brTools.AutoSize = false;
            this.brTools.BackColor = System.Drawing.SystemColors.Window;
            this.brTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.brTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btActions,
            this.tbStatus,
            this.lbStatus});
            this.brTools.Location = new System.Drawing.Point(53, 8);
            this.brTools.Margin = new System.Windows.Forms.Padding(53, 8, 0, 0);
            this.brTools.Name = "brTools";
            this.brTools.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.brTools.Size = new System.Drawing.Size(644, 40);
            this.brTools.TabIndex = 92;
            // 
            // btActions
            // 
            this.btActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btCloseAccount,
            this.btDisable});
            this.btActions.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActions.ForeColor = System.Drawing.Color.DarkGreen;
            this.btActions.Image = global::SISCOFIN_v1.Properties.Resources.MenuButton_24x24;
            this.btActions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btActions.Name = "btActions";
            this.btActions.ShowDropDownArrow = false;
            this.btActions.Size = new System.Drawing.Size(68, 37);
            this.btActions.Text = " Ações";
            // 
            // btCloseAccount
            // 
            this.btCloseAccount.BackColor = System.Drawing.SystemColors.Control;
            this.btCloseAccount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCloseAccount.ForeColor = System.Drawing.Color.DarkGreen;
            this.btCloseAccount.Image = global::SISCOFIN_v1.Properties.Resources.RemoveFile_16x16;
            this.btCloseAccount.Name = "btCloseAccount";
            this.btCloseAccount.Size = new System.Drawing.Size(156, 22);
            this.btCloseAccount.Text = "Encerrar conta";
            // 
            // btDisable
            // 
            this.btDisable.BackColor = System.Drawing.SystemColors.Window;
            this.btDisable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDisable.ForeColor = System.Drawing.Color.DarkGreen;
            this.btDisable.Image = global::SISCOFIN_v1.Properties.Resources.Disable_16x16;
            this.btDisable.Name = "btDisable";
            this.btDisable.Size = new System.Drawing.Size(156, 22);
            this.btDisable.Text = "Desativar conta";
            // 
            // tbStatus
            // 
            this.tbStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbStatus.AutoSize = false;
            this.tbStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(130, 37);
            this.tbStatus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lbStatus
            // 
            this.lbStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(76, 37);
            this.lbStatus.Text = "Situação:";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbClass
            // 
            this.lbClass.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClass.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbClass.Location = new System.Drawing.Point(53, 51);
            this.lbClass.Margin = new System.Windows.Forms.Padding(53, 3, 2, 1);
            this.lbClass.Name = "lbClass";
            this.lbClass.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbClass.Size = new System.Drawing.Size(322, 21);
            this.lbClass.TabIndex = 86;
            this.lbClass.Text = "Classe";
            this.lbClass.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbClass
            // 
            this.cbClass.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbClass.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(53, 73);
            this.cbClass.Margin = new System.Windows.Forms.Padding(53, 0, 2, 0);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(322, 28);
            this.cbClass.TabIndex = 0;
            this.cbClass.TextChanged += new System.EventHandler(this.AccountClassTextChanged);
            this.cbClass.Validated += new System.EventHandler(this.AccountClassValidated);
            // 
            // cbBank
            // 
            this.cbBank.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbBank.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cbBank.FormattingEnabled = true;
            this.cbBank.Location = new System.Drawing.Point(53, 130);
            this.cbBank.Margin = new System.Windows.Forms.Padding(53, 0, 2, 0);
            this.cbBank.Name = "cbBank";
            this.cbBank.Size = new System.Drawing.Size(515, 28);
            this.cbBank.TabIndex = 2;
            this.cbBank.TextChanged += new System.EventHandler(this.PersonTextChanged);
            this.cbBank.Validated += new System.EventHandler(this.BankValidated);
            // 
            // cbUser
            // 
            this.cbUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbUser.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(53, 187);
            this.cbUser.Margin = new System.Windows.Forms.Padding(53, 0, 2, 0);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(322, 28);
            this.cbUser.TabIndex = 3;
            this.cbUser.Validated += new System.EventHandler(this.UserValidated);
            // 
            // lbGrace
            // 
            this.lbGrace.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGrace.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbGrace.Location = new System.Drawing.Point(440, 222);
            this.lbGrace.Margin = new System.Windows.Forms.Padding(0, 7, 0, 1);
            this.lbGrace.Name = "lbGrace";
            this.lbGrace.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbGrace.Size = new System.Drawing.Size(257, 21);
            this.lbGrace.TabIndex = 91;
            this.lbGrace.Text = "Carência";
            this.lbGrace.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbGrace
            // 
            this.tbGrace.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbGrace.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbGrace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbGrace.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrace.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbGrace.Location = new System.Drawing.Point(440, 244);
            this.tbGrace.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tbGrace.Name = "tbGrace";
            this.tbGrace.Size = new System.Drawing.Size(128, 27);
            this.tbGrace.TabIndex = 9;
            this.tbGrace.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbGrace.Validated += new System.EventHandler(this.GraceValidated);
            // 
            // cbGraceUnit
            // 
            this.cbGraceUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGraceUnit.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cbGraceUnit.FormattingEnabled = true;
            this.cbGraceUnit.Location = new System.Drawing.Point(570, 244);
            this.cbGraceUnit.Margin = new System.Windows.Forms.Padding(0);
            this.cbGraceUnit.Name = "cbGraceUnit";
            this.cbGraceUnit.Size = new System.Drawing.Size(127, 28);
            this.cbGraceUnit.TabIndex = 10;
            this.cbGraceUnit.Text = "DIAS";
            this.cbGraceUnit.Validated += new System.EventHandler(this.GraceUnitValidated);
            // 
            // lbAccountName
            // 
            this.lbAccountName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAccountName.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbAccountName.Location = new System.Drawing.Point(53, 279);
            this.lbAccountName.Margin = new System.Windows.Forms.Padding(53, 7, 2, 1);
            this.lbAccountName.Name = "lbAccountName";
            this.lbAccountName.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbAccountName.Size = new System.Drawing.Size(433, 21);
            this.lbAccountName.TabIndex = 88;
            this.lbAccountName.Text = "Nome da conta";
            this.lbAccountName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbBalance
            // 
            this.lbBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBalance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbBalance.Location = new System.Drawing.Point(488, 279);
            this.lbBalance.Margin = new System.Windows.Forms.Padding(0, 7, 0, 1);
            this.lbBalance.Name = "lbBalance";
            this.lbBalance.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbBalance.Size = new System.Drawing.Size(209, 21);
            this.lbBalance.TabIndex = 90;
            this.lbBalance.Text = "Saldo atual";
            this.lbBalance.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbName
            // 
            this.tbName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbName.Location = new System.Drawing.Point(53, 301);
            this.tbName.Margin = new System.Windows.Forms.Padding(53, 0, 2, 15);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(433, 27);
            this.tbName.TabIndex = 11;
            this.tbName.Validated += new System.EventHandler(this.NameValidated);
            // 
            // tbBalance
            // 
            this.tbBalance.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBalance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbBalance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBalance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbBalance.Location = new System.Drawing.Point(488, 301);
            this.tbBalance.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.Size = new System.Drawing.Size(209, 27);
            this.tbBalance.TabIndex = 12;
            this.tbBalance.Text = "0,00";
            this.tbBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbBalance.Validated += new System.EventHandler(this.BalanceValidated);
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(53, 15, 0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(748, 28);
            this.lbTitle.TabIndex = 89;
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnWindow
            // 
            this.pnWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnWindow.Controls.Add(this.pnManager);
            this.pnWindow.Controls.Add(this.spSearch);
            this.pnWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnWindow.Location = new System.Drawing.Point(0, 33);
            this.pnWindow.Name = "pnWindow";
            this.pnWindow.Size = new System.Drawing.Size(750, 467);
            this.pnWindow.TabIndex = 85;
            // 
            // brMenu
            // 
            this.brMenu.BackColor = System.Drawing.Color.DarkGreen;
            this.brMenu.Controls.Add(this.imMenu);
            this.brMenu.Controls.Add(this.lbMenu);
            this.brMenu.Controls.Add(this.btClose);
            this.brMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.brMenu.Location = new System.Drawing.Point(0, 0);
            this.brMenu.Margin = new System.Windows.Forms.Padding(0);
            this.brMenu.Name = "brMenu";
            this.brMenu.Size = new System.Drawing.Size(750, 33);
            this.brMenu.TabIndex = 86;
            // 
            // imMenu
            // 
            this.imMenu.Image = global::SISCOFIN_v1.Properties.Resources.Accounts_24x24;
            this.imMenu.Location = new System.Drawing.Point(5, 5);
            this.imMenu.Margin = new System.Windows.Forms.Padding(5, 5, 253, 5);
            this.imMenu.Name = "imMenu";
            this.imMenu.Size = new System.Drawing.Size(24, 24);
            this.imMenu.TabIndex = 0;
            this.imMenu.TabStop = false;
            // 
            // lbMenu
            // 
            this.lbMenu.AutoSize = true;
            this.lbMenu.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMenu.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbMenu.Location = new System.Drawing.Point(282, 2);
            this.lbMenu.Margin = new System.Windows.Forms.Padding(0, 2, 239, 2);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(195, 30);
            this.lbMenu.TabIndex = 1;
            this.lbMenu.Text = "Contas Financeiras";
            // 
            // btClose
            // 
            this.btClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Image = global::SISCOFIN_v1.Properties.Resources.Close_16x16;
            this.btClose.Location = new System.Drawing.Point(716, 0);
            this.btClose.Margin = new System.Windows.Forms.Padding(0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(34, 34);
            this.btClose.TabIndex = 2;
            this.btClose.TabStop = false;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.CloseClick);
            // 
            // AccountManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(750, 500);
            this.Controls.Add(this.pnWindow);
            this.Controls.Add(this.brMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SISCOFIN";
            this.Load += new System.EventHandler(this.LoadManager);
            this.spSearch.Panel1.ResumeLayout(false);
            this.spSearch.Panel1.PerformLayout();
            this.spSearch.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spSearch)).EndInit();
            this.spSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSearch)).EndInit();
            this.flHeadersSearch.ResumeLayout(false);
            this.pnCommand.ResumeLayout(false);
            this.pnManager.ResumeLayout(false);
            this.pnControls.ResumeLayout(false);
            this.spCards.Panel1.ResumeLayout(false);
            this.spCards.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spCards)).EndInit();
            this.spCards.ResumeLayout(false);
            this.flCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btNewCard)).EndInit();
            this.flHeadersCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCards)).EndInit();
            this.spGenInfo.Panel1.ResumeLayout(false);
            this.spGenInfo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spGenInfo)).EndInit();
            this.spGenInfo.ResumeLayout(false);
            this.flAccountInfo.ResumeLayout(false);
            this.flAccountInfo.PerformLayout();
            this.brTools.ResumeLayout(false);
            this.brTools.PerformLayout();
            this.pnWindow.ResumeLayout(false);
            this.brMenu.ResumeLayout(false);
            this.brMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer spSearch;
        private System.Windows.Forms.Button btNewAccount;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.ComboBox cbFilterType;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbBankCode;
        private System.Windows.Forms.Label lbFee;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbAgency;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbPerson;
        private System.Windows.Forms.TextBox tbBankCode;
        private System.Windows.Forms.Label lbOverdraft;
        private System.Windows.Forms.Panel pnCommand;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Panel pnManager;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ToolTip tpAccountManager;
        private System.Windows.Forms.FlowLayoutPanel flAccountInfo;
        private System.Windows.Forms.Label lbClass;
        private System.Windows.Forms.Label lbAccountName;
        private System.Windows.Forms.Label lbBalance;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.DataGridView dgSearch;
        private System.Windows.Forms.FlowLayoutPanel flHeadersSearch;
        private System.Windows.Forms.Label lbHeaderName;
        private System.Windows.Forms.Label lbHeaderUser;
        private System.Windows.Forms.Label lbHeaderClass;
        private System.Windows.Forms.CheckBox ckSearch;
        private System.Windows.Forms.Label lbNoAccount;
        private System.Windows.Forms.Label lbGrace;
        private System.Windows.Forms.Label lbHeaderCard;
        private System.Windows.Forms.Label lbHeaderCardType;
        private System.Windows.Forms.DataGridView dgCards;
        private System.Windows.Forms.Label lbNoCard;
        private System.Windows.Forms.Label lbHeaderCardFlag;
        private System.Windows.Forms.SplitContainer spGenInfo;
        private System.Windows.Forms.Panel pnControls;
        private System.Windows.Forms.SplitContainer spCards;
        private System.Windows.Forms.CheckBox ckCards;
        private System.Windows.Forms.FlowLayoutPanel flCards;
        private System.Windows.Forms.CheckBox ckGenInfo;
        private System.Windows.Forms.PictureBox btNewCard;
        internal System.Windows.Forms.ComboBox cbClass;
        internal System.Windows.Forms.TextBox tbOverdraft;
        internal System.Windows.Forms.TextBox tbAgency;
        internal System.Windows.Forms.TextBox tbNumber;
        internal System.Windows.Forms.TextBox tbFee;
        internal System.Windows.Forms.ComboBox cbType;
        internal System.Windows.Forms.ComboBox cbUser;
        internal System.Windows.Forms.ComboBox cbBank;
        internal System.Windows.Forms.TextBox tbName;
        internal System.Windows.Forms.TextBox tbBalance;
        internal System.Windows.Forms.TextBox tbGrace;
        internal System.Windows.Forms.ComboBox cbFeeUnit;
        internal System.Windows.Forms.ComboBox cbGraceUnit;
        private System.Windows.Forms.ToolStrip brTools;
        private System.Windows.Forms.ToolStripDropDownButton btActions;
        private System.Windows.Forms.ToolStripLabel tbStatus;
        private System.Windows.Forms.ToolStripLabel lbStatus;
        private ToolStripMenuItem btCloseAccount;
        private ToolStripMenuItem btDisable;
        private Panel pnWindow;
        private FlowLayoutPanel brMenu;
        private PictureBox imMenu;
        private Label lbMenu;
        private Button btClose;
        private Label lbEditAccount;
        private DataGridViewTextBoxColumn clId;
        private DataGridViewTextBoxColumn clName;
        private DataGridViewTextBoxColumn clUser;
        private DataGridViewTextBoxColumn clClass;
        private DataGridViewButtonColumn clEdit;
        private Label lbEditPhone;
        private FlowLayoutPanel flHeadersCard;
        private DataGridViewTextBoxColumn clIdCard;
        private DataGridViewTextBoxColumn clCard;
        private DataGridViewTextBoxColumn clCardType;
        private DataGridViewTextBoxColumn clCardFlag;
        private DataGridViewButtonColumn clCardEdit;
    }
}