
namespace SISCOFIN_v1
{
    partial class CardManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardManager));
            this.spSearch = new System.Windows.Forms.SplitContainer();
            this.ckSearch = new System.Windows.Forms.CheckBox();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btNewCard = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.cbFilterType = new System.Windows.Forms.ComboBox();
            this.lbNoCard = new System.Windows.Forms.Label();
            this.dgSearch = new System.Windows.Forms.DataGridView();
            this.clId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.flHeaders = new System.Windows.Forms.FlowLayoutPanel();
            this.lbHeaderName = new System.Windows.Forms.Label();
            this.lbHeaderUser = new System.Windows.Forms.Label();
            this.lbHeaderClass = new System.Windows.Forms.Label();
            this.lbEditCard = new System.Windows.Forms.Label();
            this.pnManager = new System.Windows.Forms.Panel();
            this.pnControls = new System.Windows.Forms.Panel();
            this.flCard = new System.Windows.Forms.FlowLayoutPanel();
            this.brTools = new System.Windows.Forms.ToolStrip();
            this.tbStatus = new System.Windows.Forms.ToolStripLabel();
            this.lbStatus = new System.Windows.Forms.ToolStripLabel();
            this.btActions = new System.Windows.Forms.ToolStripDropDownButton();
            this.btUnblock = new System.Windows.Forms.ToolStripMenuItem();
            this.btDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.lbAccount = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.cbAccount = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lbAccountType = new System.Windows.Forms.Label();
            this.lbCVV = new System.Windows.Forms.Label();
            this.lbExpiration = new System.Windows.Forms.Label();
            this.lbFlag = new System.Windows.Forms.Label();
            this.mbNumber = new System.Windows.Forms.MaskedTextBox();
            this.tbCVV = new System.Windows.Forms.TextBox();
            this.dpExpiration = new System.Windows.Forms.DateTimePicker();
            this.cbFlag = new System.Windows.Forms.ComboBox();
            this.lbClosingDay = new System.Windows.Forms.Label();
            this.lbDueDay = new System.Windows.Forms.Label();
            this.lbOverdraft = new System.Windows.Forms.Label();
            this.lbFee = new System.Windows.Forms.Label();
            this.tbClosingDay = new System.Windows.Forms.TextBox();
            this.tbDueDay = new System.Windows.Forms.TextBox();
            this.tbCreditLimit = new System.Windows.Forms.TextBox();
            this.tbFee = new System.Windows.Forms.TextBox();
            this.cbFeeUnit = new System.Windows.Forms.ComboBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pnCommand = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
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
            this.flHeaders.SuspendLayout();
            this.pnManager.SuspendLayout();
            this.pnControls.SuspendLayout();
            this.flCard.SuspendLayout();
            this.brTools.SuspendLayout();
            this.pnCommand.SuspendLayout();
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
            this.spSearch.Panel1.Controls.Add(this.btNewCard);
            this.spSearch.Panel1.Controls.Add(this.btSearch);
            this.spSearch.Panel1.Controls.Add(this.cbFilterType);
            this.spSearch.Panel1.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.spSearch.Panel1MinSize = 0;
            // 
            // spSearch.Panel2
            // 
            this.spSearch.Panel2.Controls.Add(this.lbNoCard);
            this.spSearch.Panel2.Controls.Add(this.dgSearch);
            this.spSearch.Panel2.Controls.Add(this.flHeaders);
            this.spSearch.Panel2.Padding = new System.Windows.Forms.Padding(58, 45, 32, 45);
            this.spSearch.Panel2MinSize = 0;
            this.spSearch.Size = this.spSearch.MinimumSize;
            this.spSearch.SplitterDistance = 25;
            this.spSearch.SplitterWidth = 1;
            this.spSearch.TabIndex = 92;
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
            // btNewCard
            // 
            this.btNewCard.AutoSize = true;
            this.btNewCard.BackColor = System.Drawing.SystemColors.Control;
            this.btNewCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNewCard.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btNewCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(234)))), ((int)(((byte)(249)))));
            this.btNewCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNewCard.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNewCard.ForeColor = System.Drawing.Color.DarkGreen;
            this.btNewCard.Image = global::SISCOFIN_v1.Properties.Resources.AddCard_24x24;
            this.btNewCard.Location = new System.Drawing.Point(571, 8);
            this.btNewCard.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btNewCard.Name = "btNewCard";
            this.btNewCard.Size = new System.Drawing.Size(82, 32);
            this.btNewCard.TabIndex = 3;
            this.btNewCard.Text = "Novo";
            this.btNewCard.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btNewCard.UseVisualStyleBackColor = false;
            this.btNewCard.Click += new System.EventHandler(this.NewCard);
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
            this.cbFilterType.Items.AddRange(new object[] {
            "BANDEIRA",
            "FINAL",
            "TIPO"});
            this.cbFilterType.Location = new System.Drawing.Point(392, 12);
            this.cbFilterType.Margin = new System.Windows.Forms.Padding(0);
            this.cbFilterType.Name = "cbFilterType";
            this.cbFilterType.Size = new System.Drawing.Size(141, 25);
            this.cbFilterType.Sorted = true;
            this.cbFilterType.TabIndex = 1;
            // 
            // lbNoCard
            // 
            this.lbNoCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbNoCard.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoCard.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbNoCard.Location = new System.Drawing.Point(58, 390);
            this.lbNoCard.Margin = new System.Windows.Forms.Padding(0);
            this.lbNoCard.Name = "lbNoCard";
            this.lbNoCard.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.lbNoCard.Size = new System.Drawing.Size(660, 34);
            this.lbNoCard.TabIndex = 56;
            this.lbNoCard.Text = "NENHUM CARTÃO ENCONTRADO";
            this.lbNoCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbNoCard.Visible = false;
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
            this.clCard,
            this.clType,
            this.clFlag,
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
            this.dgSearch.RowHeadersVisible = false;
            this.dgSearch.RowTemplate.DividerHeight = 2;
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
            this.clId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clId.Visible = false;
            // 
            // clCard
            // 
            this.clCard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.clCard.DefaultCellStyle = dataGridViewCellStyle1;
            this.clCard.DividerWidth = 2;
            this.clCard.HeaderText = "Final";
            this.clCard.Name = "clCard";
            this.clCard.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clCard.Width = 202;
            // 
            // clType
            // 
            this.clType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.clType.DefaultCellStyle = dataGridViewCellStyle2;
            this.clType.DividerWidth = 2;
            this.clType.HeaderText = "Tipo";
            this.clType.Name = "clType";
            this.clType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clType.Width = 189;
            // 
            // clFlag
            // 
            this.clFlag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.clFlag.DefaultCellStyle = dataGridViewCellStyle3;
            this.clFlag.DividerWidth = 2;
            this.clFlag.HeaderText = "Bandeira";
            this.clFlag.Name = "clFlag";
            this.clFlag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clFlag.Width = 193;
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
            this.clEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clEdit.Text = "Editar";
            this.clEdit.UseColumnTextForButtonValue = true;
            this.clEdit.Width = 60;
            // 
            // flHeaders
            // 
            this.flHeaders.Controls.Add(this.lbHeaderName);
            this.flHeaders.Controls.Add(this.lbHeaderUser);
            this.flHeaders.Controls.Add(this.lbHeaderClass);
            this.flHeaders.Controls.Add(this.lbEditCard);
            this.flHeaders.Dock = System.Windows.Forms.DockStyle.Top;
            this.flHeaders.Location = new System.Drawing.Point(58, 45);
            this.flHeaders.Margin = new System.Windows.Forms.Padding(0);
            this.flHeaders.Name = "flHeaders";
            this.flHeaders.Padding = new System.Windows.Forms.Padding(0, 0, 19, 0);
            this.flHeaders.Size = new System.Drawing.Size(660, 37);
            this.flHeaders.TabIndex = 55;
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
            this.lbHeaderName.Text = "Final";
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
            this.lbHeaderUser.Size = new System.Drawing.Size(186, 35);
            this.lbHeaderUser.TabIndex = 1;
            this.lbHeaderUser.Text = "Tipo";
            this.lbHeaderUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHeaderClass
            // 
            this.lbHeaderClass.BackColor = System.Drawing.Color.DarkGreen;
            this.lbHeaderClass.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeaderClass.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbHeaderClass.Location = new System.Drawing.Point(392, 0);
            this.lbHeaderClass.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbHeaderClass.Name = "lbHeaderClass";
            this.lbHeaderClass.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbHeaderClass.Size = new System.Drawing.Size(191, 35);
            this.lbHeaderClass.TabIndex = 2;
            this.lbHeaderClass.Text = "Bandeira";
            this.lbHeaderClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbEditCard
            // 
            this.lbEditCard.BackColor = System.Drawing.Color.DarkGreen;
            this.lbEditCard.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEditCard.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbEditCard.Location = new System.Drawing.Point(586, 0);
            this.lbEditCard.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbEditCard.Name = "lbEditCard";
            this.lbEditCard.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbEditCard.Size = new System.Drawing.Size(55, 35);
            this.lbEditCard.TabIndex = 3;
            this.lbEditCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnManager
            // 
            this.pnManager.Controls.Add(this.pnControls);
            this.pnManager.Controls.Add(this.lbTitle);
            this.pnManager.Controls.Add(this.pnCommand);
            this.pnManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnManager.Location = new System.Drawing.Point(0, 466);
            this.pnManager.Name = "pnManager";
            this.pnManager.Size = new System.Drawing.Size(748, 0);
            this.pnManager.TabIndex = 93;
            // 
            // pnControls
            // 
            this.pnControls.Controls.Add(this.flCard);
            this.pnControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnControls.Location = new System.Drawing.Point(0, 28);
            this.pnControls.Name = "pnControls";
            this.pnControls.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnControls.Size = new System.Drawing.Size(748, 0);
            this.pnControls.TabIndex = 0;
            // 
            // flCard
            // 
            this.flCard.Controls.Add(this.brTools);
            this.flCard.Controls.Add(this.lbAccount);
            this.flCard.Controls.Add(this.lbType);
            this.flCard.Controls.Add(this.cbAccount);
            this.flCard.Controls.Add(this.cbType);
            this.flCard.Controls.Add(this.lbAccountType);
            this.flCard.Controls.Add(this.lbCVV);
            this.flCard.Controls.Add(this.lbExpiration);
            this.flCard.Controls.Add(this.lbFlag);
            this.flCard.Controls.Add(this.mbNumber);
            this.flCard.Controls.Add(this.tbCVV);
            this.flCard.Controls.Add(this.dpExpiration);
            this.flCard.Controls.Add(this.cbFlag);
            this.flCard.Controls.Add(this.lbClosingDay);
            this.flCard.Controls.Add(this.lbDueDay);
            this.flCard.Controls.Add(this.lbOverdraft);
            this.flCard.Controls.Add(this.lbFee);
            this.flCard.Controls.Add(this.tbClosingDay);
            this.flCard.Controls.Add(this.tbDueDay);
            this.flCard.Controls.Add(this.tbCreditLimit);
            this.flCard.Controls.Add(this.tbFee);
            this.flCard.Controls.Add(this.cbFeeUnit);
            this.flCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flCard.Location = new System.Drawing.Point(3, 0);
            this.flCard.Margin = new System.Windows.Forms.Padding(0);
            this.flCard.Name = "flCard";
            this.flCard.Size = new System.Drawing.Size(742, 0);
            this.flCard.TabIndex = 90;
            // 
            // brTools
            // 
            this.brTools.AutoSize = false;
            this.brTools.BackColor = System.Drawing.SystemColors.Window;
            this.brTools.Dock = System.Windows.Forms.DockStyle.None;
            this.brTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.brTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbStatus,
            this.lbStatus,
            this.btActions});
            this.brTools.Location = new System.Drawing.Point(45, 15);
            this.brTools.Margin = new System.Windows.Forms.Padding(45, 15, 45, 0);
            this.brTools.Name = "brTools";
            this.brTools.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.brTools.Size = new System.Drawing.Size(650, 40);
            this.brTools.TabIndex = 101;
            // 
            // tbStatus
            // 
            this.tbStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbStatus.AutoSize = false;
            this.tbStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // btActions
            // 
            this.btActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btUnblock,
            this.btDelete});
            this.btActions.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActions.ForeColor = System.Drawing.Color.DarkGreen;
            this.btActions.Image = global::SISCOFIN_v1.Properties.Resources.MenuButton_24x24;
            this.btActions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btActions.Name = "btActions";
            this.btActions.Size = new System.Drawing.Size(77, 37);
            this.btActions.Text = " Ações";
            // 
            // btUnblock
            // 
            this.btUnblock.BackColor = System.Drawing.SystemColors.Window;
            this.btUnblock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUnblock.ForeColor = System.Drawing.Color.DarkGreen;
            this.btUnblock.Image = global::SISCOFIN_v1.Properties.Resources.Lock_16x16;
            this.btUnblock.Name = "btUnblock";
            this.btUnblock.Size = new System.Drawing.Size(229, 22);
            this.btUnblock.Text = "Bloquear/Desbloquear cartão";
            // 
            // btDelete
            // 
            this.btDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelete.ForeColor = System.Drawing.Color.DarkGreen;
            this.btDelete.Image = global::SISCOFIN_v1.Properties.Resources.DeleteCard_16x16;
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(229, 22);
            this.btDelete.Text = "Excluir cartão";
            // 
            // lbAccount
            // 
            this.lbAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAccount.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbAccount.Location = new System.Drawing.Point(45, 58);
            this.lbAccount.Margin = new System.Windows.Forms.Padding(45, 3, 2, 0);
            this.lbAccount.Name = "lbAccount";
            this.lbAccount.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbAccount.Size = new System.Drawing.Size(214, 21);
            this.lbAccount.TabIndex = 86;
            this.lbAccount.Text = "Conta";
            this.lbAccount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbType
            // 
            this.lbType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbType.Location = new System.Drawing.Point(261, 58);
            this.lbType.Margin = new System.Windows.Forms.Padding(0, 3, 45, 0);
            this.lbType.Name = "lbType";
            this.lbType.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbType.Size = new System.Drawing.Size(434, 21);
            this.lbType.TabIndex = 98;
            this.lbType.Text = "Tipo do cartão";
            this.lbType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbAccount
            // 
            this.cbAccount.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbAccount.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cbAccount.FormattingEnabled = true;
            this.cbAccount.Location = new System.Drawing.Point(45, 79);
            this.cbAccount.Margin = new System.Windows.Forms.Padding(45, 0, 2, 0);
            this.cbAccount.Name = "cbAccount";
            this.cbAccount.Size = new System.Drawing.Size(214, 28);
            this.cbAccount.TabIndex = 0;
            this.cbAccount.TextChanged += new System.EventHandler(this.AccountTextChanged);
            // 
            // cbType
            // 
            this.cbType.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbType.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(261, 79);
            this.cbType.Margin = new System.Windows.Forms.Padding(0, 0, 45, 0);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(434, 28);
            this.cbType.TabIndex = 1;
            this.cbType.TextChanged += new System.EventHandler(this.TypeTextChanged);
            // 
            // lbAccountType
            // 
            this.lbAccountType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAccountType.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbAccountType.Location = new System.Drawing.Point(45, 109);
            this.lbAccountType.Margin = new System.Windows.Forms.Padding(45, 2, 2, 0);
            this.lbAccountType.Name = "lbAccountType";
            this.lbAccountType.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbAccountType.Size = new System.Drawing.Size(214, 21);
            this.lbAccountType.TabIndex = 68;
            this.lbAccountType.Text = "Nº do Cartão";
            this.lbAccountType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbCVV
            // 
            this.lbCVV.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCVV.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbCVV.Location = new System.Drawing.Point(261, 109);
            this.lbCVV.Margin = new System.Windows.Forms.Padding(0, 2, 2, 0);
            this.lbCVV.Name = "lbCVV";
            this.lbCVV.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbCVV.Size = new System.Drawing.Size(71, 21);
            this.lbCVV.TabIndex = 64;
            this.lbCVV.Text = "CVV";
            this.lbCVV.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbExpiration
            // 
            this.lbExpiration.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExpiration.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbExpiration.Location = new System.Drawing.Point(334, 109);
            this.lbExpiration.Margin = new System.Windows.Forms.Padding(0, 2, 2, 0);
            this.lbExpiration.Name = "lbExpiration";
            this.lbExpiration.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbExpiration.Size = new System.Drawing.Size(117, 21);
            this.lbExpiration.TabIndex = 65;
            this.lbExpiration.Text = "Validade";
            this.lbExpiration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFlag
            // 
            this.lbFlag.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFlag.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbFlag.Location = new System.Drawing.Point(453, 109);
            this.lbFlag.Margin = new System.Windows.Forms.Padding(0, 2, 45, 0);
            this.lbFlag.Name = "lbFlag";
            this.lbFlag.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbFlag.Size = new System.Drawing.Size(242, 21);
            this.lbFlag.TabIndex = 63;
            this.lbFlag.Text = "Bandeira";
            this.lbFlag.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // mbNumber
            // 
            this.mbNumber.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mbNumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mbNumber.Location = new System.Drawing.Point(45, 130);
            this.mbNumber.Margin = new System.Windows.Forms.Padding(45, 0, 2, 0);
            this.mbNumber.Mask = "0000 0000 0000 0000";
            this.mbNumber.Name = "mbNumber";
            this.mbNumber.Size = new System.Drawing.Size(214, 27);
            this.mbNumber.TabIndex = 2;
            this.mbNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mbNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // tbCVV
            // 
            this.tbCVV.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbCVV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCVV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCVV.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCVV.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCVV.Location = new System.Drawing.Point(261, 130);
            this.tbCVV.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tbCVV.Name = "tbCVV";
            this.tbCVV.Size = new System.Drawing.Size(71, 27);
            this.tbCVV.TabIndex = 3;
            this.tbCVV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dpExpiration
            // 
            this.dpExpiration.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpExpiration.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpExpiration.Location = new System.Drawing.Point(334, 130);
            this.dpExpiration.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.dpExpiration.Name = "dpExpiration";
            this.dpExpiration.Size = new System.Drawing.Size(117, 27);
            this.dpExpiration.TabIndex = 4;
            // 
            // cbFlag
            // 
            this.cbFlag.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbFlag.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cbFlag.FormattingEnabled = true;
            this.cbFlag.Location = new System.Drawing.Point(453, 130);
            this.cbFlag.Margin = new System.Windows.Forms.Padding(0, 0, 45, 0);
            this.cbFlag.Name = "cbFlag";
            this.cbFlag.Size = new System.Drawing.Size(242, 28);
            this.cbFlag.TabIndex = 5;
            // 
            // lbClosingDay
            // 
            this.lbClosingDay.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClosingDay.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbClosingDay.Location = new System.Drawing.Point(45, 160);
            this.lbClosingDay.Margin = new System.Windows.Forms.Padding(45, 2, 2, 0);
            this.lbClosingDay.Name = "lbClosingDay";
            this.lbClosingDay.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbClosingDay.Size = new System.Drawing.Size(156, 21);
            this.lbClosingDay.TabIndex = 67;
            this.lbClosingDay.Text = "Dia de fechamento";
            this.lbClosingDay.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbDueDay
            // 
            this.lbDueDay.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDueDay.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbDueDay.Location = new System.Drawing.Point(203, 160);
            this.lbDueDay.Margin = new System.Windows.Forms.Padding(0, 2, 2, 0);
            this.lbDueDay.Name = "lbDueDay";
            this.lbDueDay.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbDueDay.Size = new System.Drawing.Size(156, 21);
            this.lbDueDay.TabIndex = 66;
            this.lbDueDay.Text = "Dia de vencimento";
            this.lbDueDay.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbOverdraft
            // 
            this.lbOverdraft.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOverdraft.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbOverdraft.Location = new System.Drawing.Point(361, 160);
            this.lbOverdraft.Margin = new System.Windows.Forms.Padding(0, 2, 2, 0);
            this.lbOverdraft.Name = "lbOverdraft";
            this.lbOverdraft.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbOverdraft.Size = new System.Drawing.Size(160, 21);
            this.lbOverdraft.TabIndex = 75;
            this.lbOverdraft.Text = "Limite";
            this.lbOverdraft.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbFee
            // 
            this.lbFee.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFee.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbFee.Location = new System.Drawing.Point(523, 160);
            this.lbFee.Margin = new System.Windows.Forms.Padding(0, 2, 45, 0);
            this.lbFee.Name = "lbFee";
            this.lbFee.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbFee.Size = new System.Drawing.Size(172, 21);
            this.lbFee.TabIndex = 80;
            this.lbFee.Text = "Juros";
            this.lbFee.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbClosingDay
            // 
            this.tbClosingDay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbClosingDay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbClosingDay.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClosingDay.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbClosingDay.Location = new System.Drawing.Point(45, 181);
            this.tbClosingDay.Margin = new System.Windows.Forms.Padding(45, 0, 2, 0);
            this.tbClosingDay.Name = "tbClosingDay";
            this.tbClosingDay.Size = new System.Drawing.Size(156, 27);
            this.tbClosingDay.TabIndex = 6;
            this.tbClosingDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbDueDay
            // 
            this.tbDueDay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDueDay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDueDay.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDueDay.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbDueDay.Location = new System.Drawing.Point(203, 181);
            this.tbDueDay.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tbDueDay.Name = "tbDueDay";
            this.tbDueDay.Size = new System.Drawing.Size(156, 27);
            this.tbDueDay.TabIndex = 7;
            this.tbDueDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbCreditLimit
            // 
            this.tbCreditLimit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbCreditLimit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCreditLimit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCreditLimit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCreditLimit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCreditLimit.Location = new System.Drawing.Point(361, 181);
            this.tbCreditLimit.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tbCreditLimit.Name = "tbCreditLimit";
            this.tbCreditLimit.Size = new System.Drawing.Size(160, 27);
            this.tbCreditLimit.TabIndex = 8;
            this.tbCreditLimit.Text = "0,00";
            this.tbCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbFee
            // 
            this.tbFee.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbFee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbFee.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFee.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFee.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbFee.Location = new System.Drawing.Point(523, 181);
            this.tbFee.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tbFee.Name = "tbFee";
            this.tbFee.Size = new System.Drawing.Size(76, 27);
            this.tbFee.TabIndex = 9;
            this.tbFee.Text = "0,00";
            this.tbFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbFeeUnit
            // 
            this.cbFeeUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFeeUnit.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cbFeeUnit.FormattingEnabled = true;
            this.cbFeeUnit.Location = new System.Drawing.Point(601, 181);
            this.cbFeeUnit.Margin = new System.Windows.Forms.Padding(0, 0, 45, 0);
            this.cbFeeUnit.Name = "cbFeeUnit";
            this.cbFeeUnit.Size = new System.Drawing.Size(94, 28);
            this.cbFeeUnit.TabIndex = 10;
            this.cbFeeUnit.Text = "% AO MÊS";
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(748, 28);
            this.lbTitle.TabIndex = 100;
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnCommand
            // 
            this.pnCommand.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnCommand.Controls.Add(this.btCancel);
            this.pnCommand.Controls.Add(this.btSave);
            this.pnCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnCommand.Location = new System.Drawing.Point(0, -53);
            this.pnCommand.Name = "pnCommand";
            this.pnCommand.Size = new System.Drawing.Size(748, 53);
            this.pnCommand.TabIndex = 101;
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
            this.btCancel.TabIndex = 3;
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
            this.btSave.TabIndex = 2;
            this.btSave.Text = "Salvar";
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.SaveClick);
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
            this.pnWindow.TabIndex = 94;
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
            this.brMenu.TabIndex = 95;
            // 
            // imMenu
            // 
            this.imMenu.Image = global::SISCOFIN_v1.Properties.Resources.CreditCard_24x24;
            this.imMenu.Location = new System.Drawing.Point(5, 5);
            this.imMenu.Margin = new System.Windows.Forms.Padding(5, 5, 304, 5);
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
            this.lbMenu.Location = new System.Drawing.Point(333, 2);
            this.lbMenu.Margin = new System.Windows.Forms.Padding(0, 2, 296, 2);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(87, 30);
            this.lbMenu.TabIndex = 1;
            this.lbMenu.Text = "Cartões";
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
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.CloseClick);
            // 
            // CardManager
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
            this.Name = "CardManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewCard";
            this.Load += new System.EventHandler(this.LoadManager);
            this.spSearch.Panel1.ResumeLayout(false);
            this.spSearch.Panel1.PerformLayout();
            this.spSearch.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spSearch)).EndInit();
            this.spSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSearch)).EndInit();
            this.flHeaders.ResumeLayout(false);
            this.pnManager.ResumeLayout(false);
            this.pnControls.ResumeLayout(false);
            this.flCard.ResumeLayout(false);
            this.flCard.PerformLayout();
            this.brTools.ResumeLayout(false);
            this.brTools.PerformLayout();
            this.pnCommand.ResumeLayout(false);
            this.pnWindow.ResumeLayout(false);
            this.brMenu.ResumeLayout(false);
            this.brMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer spSearch;
        private System.Windows.Forms.CheckBox ckSearch;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btNewCard;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.ComboBox cbFilterType;
        private System.Windows.Forms.Label lbNoCard;
        private System.Windows.Forms.DataGridView dgSearch;
        private System.Windows.Forms.FlowLayoutPanel flHeaders;
        private System.Windows.Forms.Label lbHeaderName;
        private System.Windows.Forms.Label lbHeaderUser;
        private System.Windows.Forms.Label lbHeaderClass;
        private System.Windows.Forms.Panel pnManager;
        private System.Windows.Forms.Panel pnControls;
        private System.Windows.Forms.FlowLayoutPanel flCard;
        private System.Windows.Forms.ToolStrip brTools;
        private System.Windows.Forms.ToolStripLabel tbStatus;
        private System.Windows.Forms.ToolStripLabel lbStatus;
        private System.Windows.Forms.ToolStripDropDownButton btActions;
        private System.Windows.Forms.ToolStripMenuItem btUnblock;
        private System.Windows.Forms.ToolStripMenuItem btDelete;
        private System.Windows.Forms.Label lbAccount;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.ComboBox cbAccount;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lbAccountType;
        private System.Windows.Forms.Label lbCVV;
        private System.Windows.Forms.Label lbExpiration;
        private System.Windows.Forms.Label lbFlag;
        private System.Windows.Forms.MaskedTextBox mbNumber;
        private System.Windows.Forms.TextBox tbCVV;
        private System.Windows.Forms.DateTimePicker dpExpiration;
        private System.Windows.Forms.ComboBox cbFlag;
        private System.Windows.Forms.Label lbClosingDay;
        private System.Windows.Forms.Label lbDueDay;
        private System.Windows.Forms.Label lbOverdraft;
        private System.Windows.Forms.Label lbFee;
        private System.Windows.Forms.TextBox tbClosingDay;
        private System.Windows.Forms.TextBox tbDueDay;
        private System.Windows.Forms.TextBox tbCreditLimit;
        private System.Windows.Forms.TextBox tbFee;
        private System.Windows.Forms.ComboBox cbFeeUnit;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel pnCommand;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Panel pnWindow;
        private System.Windows.Forms.FlowLayoutPanel brMenu;
        private System.Windows.Forms.PictureBox imMenu;
        private System.Windows.Forms.Label lbMenu;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label lbEditCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn clId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn clType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFlag;
        private System.Windows.Forms.DataGridViewButtonColumn clEdit;
    }
}