
namespace SISCOFIN_v1
{
    partial class CloseCreditBills
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloseCreditBills));
            this.pnWindow = new System.Windows.Forms.Panel();
            this.pnCloseBills = new System.Windows.Forms.Panel();
            this.dgBills = new System.Windows.Forms.DataGridView();
            this.clId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCloseDate = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lnLine1 = new System.Windows.Forms.Label();
            this.pnCommand = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.brBills = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pnWindow.SuspendLayout();
            this.pnCloseBills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBills)).BeginInit();
            this.pnCommand.SuspendLayout();
            this.brBills.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnWindow
            // 
            this.pnWindow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pnWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnWindow.Controls.Add(this.pnCloseBills);
            this.pnWindow.Location = new System.Drawing.Point(14, 14);
            this.pnWindow.Margin = new System.Windows.Forms.Padding(5);
            this.pnWindow.Name = "pnWindow";
            this.pnWindow.Padding = new System.Windows.Forms.Padding(1);
            this.pnWindow.Size = new System.Drawing.Size(478, 256);
            this.pnWindow.TabIndex = 19;
            // 
            // pnCloseBills
            // 
            this.pnCloseBills.BackColor = System.Drawing.SystemColors.Window;
            this.pnCloseBills.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnCloseBills.Controls.Add(this.dgBills);
            this.pnCloseBills.Controls.Add(this.lnLine1);
            this.pnCloseBills.Controls.Add(this.pnCommand);
            this.pnCloseBills.Controls.Add(this.brBills);
            this.pnCloseBills.Location = new System.Drawing.Point(1, 1);
            this.pnCloseBills.Margin = new System.Windows.Forms.Padding(0);
            this.pnCloseBills.Name = "pnCloseBills";
            this.pnCloseBills.Size = new System.Drawing.Size(474, 252);
            this.pnCloseBills.TabIndex = 0;
            // 
            // dgBills
            // 
            this.dgBills.AllowUserToAddRows = false;
            this.dgBills.AllowUserToDeleteRows = false;
            this.dgBills.AllowUserToResizeColumns = false;
            this.dgBills.AllowUserToResizeRows = false;
            this.dgBills.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgBills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgBills.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBills.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clId,
            this.clCheck,
            this.clDescription,
            this.clCloseDate,
            this.clValue});
            this.dgBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBills.EnableHeadersVisualStyles = false;
            this.dgBills.GridColor = System.Drawing.Color.DarkGreen;
            this.dgBills.Location = new System.Drawing.Point(0, 27);
            this.dgBills.MultiSelect = false;
            this.dgBills.Name = "dgBills";
            this.dgBills.RowHeadersVisible = false;
            this.dgBills.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dgBills.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgBills.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgBills.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            this.dgBills.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgBills.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBills.Size = new System.Drawing.Size(472, 168);
            this.dgBills.TabIndex = 58;
            this.dgBills.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellContentClick_dgBills);
            // 
            // clId
            // 
            this.clId.HeaderText = "Id";
            this.clId.Name = "clId";
            this.clId.ReadOnly = true;
            this.clId.Visible = false;
            // 
            // clCheck
            // 
            this.clCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clCheck.FalseValue = "0";
            this.clCheck.HeaderText = "";
            this.clCheck.Name = "clCheck";
            this.clCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clCheck.TrueValue = "1";
            this.clCheck.Width = 36;
            // 
            // clDescription
            // 
            this.clDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clDescription.HeaderText = "Descrição";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDescription.Width = 220;
            // 
            // clCloseDate
            // 
            this.clCloseDate.ActiveLinkColor = System.Drawing.Color.Blue;
            this.clCloseDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clCloseDate.HeaderText = "   Fechamento           previsto";
            this.clCloseDate.LinkColor = System.Drawing.Color.Blue;
            this.clCloseDate.Name = "clCloseDate";
            this.clCloseDate.ReadOnly = true;
            this.clCloseDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clCloseDate.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // clValue
            // 
            this.clValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clValue.HeaderText = "           Valor";
            this.clValue.Name = "clValue";
            this.clValue.ReadOnly = true;
            this.clValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clValue.Width = 115;
            // 
            // lnLine1
            // 
            this.lnLine1.BackColor = System.Drawing.Color.DarkGreen;
            this.lnLine1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnLine1.Location = new System.Drawing.Point(0, 25);
            this.lnLine1.Name = "lnLine1";
            this.lnLine1.Size = new System.Drawing.Size(472, 2);
            this.lnLine1.TabIndex = 60;
            // 
            // pnCommand
            // 
            this.pnCommand.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnCommand.Controls.Add(this.btCancel);
            this.pnCommand.Controls.Add(this.btSave);
            this.pnCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnCommand.Location = new System.Drawing.Point(0, 195);
            this.pnCommand.Name = "pnCommand";
            this.pnCommand.Size = new System.Drawing.Size(472, 55);
            this.pnCommand.TabIndex = 61;
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.DarkGreen;
            this.btCancel.Location = new System.Drawing.Point(301, 18);
            this.btCancel.Margin = new System.Windows.Forms.Padding(15);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(156, 23);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancelar";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.Click_btCancel);
            // 
            // btSave
            // 
            this.btSave.AutoSize = true;
            this.btSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btSave.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.ForeColor = System.Drawing.Color.DarkGreen;
            this.btSave.Location = new System.Drawing.Point(15, 18);
            this.btSave.Margin = new System.Windows.Forms.Padding(15);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(156, 23);
            this.btSave.TabIndex = 4;
            this.btSave.Text = "Fechar faturas selecionadas";
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.Click_btSave);
            // 
            // brBills
            // 
            this.brBills.BackColor = System.Drawing.SystemColors.Control;
            this.brBills.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.brBills.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.brBills.Location = new System.Drawing.Point(0, 0);
            this.brBills.Name = "brBills";
            this.brBills.Padding = new System.Windows.Forms.Padding(0);
            this.brBills.Size = new System.Drawing.Size(472, 25);
            this.brBills.TabIndex = 59;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(99, 22);
            this.toolStripButton1.Text = "Desmarcar  tudo";
            // 
            // CloseCreditBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 285);
            this.Controls.Add(this.pnWindow);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CloseCreditBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecione as faturas que deseja fechar";
            this.pnWindow.ResumeLayout(false);
            this.pnCloseBills.ResumeLayout(false);
            this.pnCloseBills.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBills)).EndInit();
            this.pnCommand.ResumeLayout(false);
            this.pnCommand.PerformLayout();
            this.brBills.ResumeLayout(false);
            this.brBills.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnWindow;
        private System.Windows.Forms.Panel pnCloseBills;
        private System.Windows.Forms.ToolStrip brBills;
        private System.Windows.Forms.Label lnLine1;
        internal System.Windows.Forms.DataGridView dgBills;
        private System.Windows.Forms.Panel pnCommand;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewLinkColumn clCloseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clValue;
        private System.Windows.Forms.Button btCancel;
    }
}