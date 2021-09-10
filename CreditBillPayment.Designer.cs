
namespace SISCOFIN_v1
{
    partial class CreditBillPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditBillPayment));
            this.lbDate = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.lbValue = new System.Windows.Forms.Label();
            this.pnWindow = new System.Windows.Forms.Panel();
            this.scDate = new System.Windows.Forms.SplitContainer();
            this.lbParcels = new System.Windows.Forms.Label();
            this.udParcels = new System.Windows.Forms.NumericUpDown();
            this.pnCommand = new System.Windows.Forms.Panel();
            this.btSave = new System.Windows.Forms.Button();
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.pnValue = new System.Windows.Forms.Panel();
            this.lbType = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.pnWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scDate)).BeginInit();
            this.scDate.Panel1.SuspendLayout();
            this.scDate.Panel2.SuspendLayout();
            this.scDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udParcels)).BeginInit();
            this.pnCommand.SuspendLayout();
            this.pnValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbDate.Location = new System.Drawing.Point(45, 9);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(110, 13);
            this.lbDate.TabIndex = 15;
            this.lbDate.Text = "Data do pagamento";
            // 
            // tbValue
            // 
            this.tbValue.BackColor = System.Drawing.SystemColors.Window;
            this.tbValue.Location = new System.Drawing.Point(164, 22);
            this.tbValue.Margin = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.tbValue.MaxLength = 18;
            this.tbValue.Name = "tbValue";
            this.tbValue.ReadOnly = true;
            this.tbValue.Size = new System.Drawing.Size(111, 22);
            this.tbValue.TabIndex = 1;
            this.tbValue.Text = "0,00";
            this.tbValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValue.Validating += new System.ComponentModel.CancelEventHandler(this.ValueValidating);
            this.tbValue.Validated += new System.EventHandler(this.ValueValidated);
            // 
            // lbValue
            // 
            this.lbValue.AutoSize = true;
            this.lbValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValue.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbValue.Location = new System.Drawing.Point(167, 6);
            this.lbValue.Name = "lbValue";
            this.lbValue.Size = new System.Drawing.Size(33, 13);
            this.lbValue.TabIndex = 17;
            this.lbValue.Text = "Valor";
            // 
            // pnWindow
            // 
            this.pnWindow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pnWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnWindow.Controls.Add(this.scDate);
            this.pnWindow.Controls.Add(this.pnValue);
            this.pnWindow.Location = new System.Drawing.Point(14, 14);
            this.pnWindow.Margin = new System.Windows.Forms.Padding(5);
            this.pnWindow.MaximumSize = new System.Drawing.Size(305, 180);
            this.pnWindow.MinimumSize = new System.Drawing.Size(305, 144);
            this.pnWindow.Name = "pnWindow";
            this.pnWindow.Padding = new System.Windows.Forms.Padding(1);
            this.pnWindow.Size = new System.Drawing.Size(305, 144);
            this.pnWindow.TabIndex = 18;
            // 
            // scDate
            // 
            this.scDate.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.scDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.scDate.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scDate.IsSplitterFixed = true;
            this.scDate.Location = new System.Drawing.Point(1, 53);
            this.scDate.MaximumSize = new System.Drawing.Size(301, 124);
            this.scDate.MinimumSize = new System.Drawing.Size(301, 88);
            this.scDate.Name = "scDate";
            this.scDate.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scDate.Panel1
            // 
            this.scDate.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.scDate.Panel1.Controls.Add(this.lbParcels);
            this.scDate.Panel1.Controls.Add(this.udParcels);
            this.scDate.Panel1.Margin = new System.Windows.Forms.Padding(1);
            this.scDate.Panel1Collapsed = true;
            this.scDate.Panel1MinSize = 0;
            // 
            // scDate.Panel2
            // 
            this.scDate.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.scDate.Panel2.Controls.Add(this.lbDate);
            this.scDate.Panel2.Controls.Add(this.pnCommand);
            this.scDate.Panel2.Controls.Add(this.dpDate);
            this.scDate.Panel2MinSize = 0;
            this.scDate.Size = new System.Drawing.Size(301, 88);
            this.scDate.SplitterDistance = 35;
            this.scDate.SplitterWidth = 1;
            this.scDate.TabIndex = 23;
            // 
            // lbParcels
            // 
            this.lbParcels.AutoSize = true;
            this.lbParcels.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbParcels.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbParcels.Location = new System.Drawing.Point(45, 9);
            this.lbParcels.Name = "lbParcels";
            this.lbParcels.Size = new System.Drawing.Size(109, 13);
            this.lbParcels.TabIndex = 18;
            this.lbParcels.Text = "Número de parcelas";
            // 
            // udParcels
            // 
            this.udParcels.Enabled = false;
            this.udParcels.Location = new System.Drawing.Point(157, 6);
            this.udParcels.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.udParcels.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udParcels.Name = "udParcels";
            this.udParcels.Size = new System.Drawing.Size(96, 22);
            this.udParcels.TabIndex = 2;
            this.udParcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.udParcels.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udParcels.Validated += new System.EventHandler(this.ParcelsValidated);
            // 
            // pnCommand
            // 
            this.pnCommand.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnCommand.Controls.Add(this.btSave);
            this.pnCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnCommand.Location = new System.Drawing.Point(0, 31);
            this.pnCommand.MaximumSize = new System.Drawing.Size(301, 55);
            this.pnCommand.MinimumSize = new System.Drawing.Size(301, 55);
            this.pnCommand.Name = "pnCommand";
            this.pnCommand.Size = new System.Drawing.Size(301, 55);
            this.pnCommand.TabIndex = 25;
            // 
            // btSave
            // 
            this.btSave.AutoSize = true;
            this.btSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btSave.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.ForeColor = System.Drawing.Color.DarkGreen;
            this.btSave.Location = new System.Drawing.Point(95, 17);
            this.btSave.Margin = new System.Windows.Forms.Padding(15);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(111, 23);
            this.btSave.TabIndex = 4;
            this.btSave.Text = "Lançar pagamento";
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.SaveClick);
            // 
            // dpDate
            // 
            this.dpDate.CalendarTitleBackColor = System.Drawing.Color.DarkSeaGreen;
            this.dpDate.CustomFormat = "";
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDate.Location = new System.Drawing.Point(157, 5);
            this.dpDate.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dpDate.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(96, 22);
            this.dpDate.TabIndex = 3;
            this.dpDate.Value = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dpDate.Validated += new System.EventHandler(this.ValidatedDate);
            // 
            // pnValue
            // 
            this.pnValue.BackColor = System.Drawing.SystemColors.Window;
            this.pnValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnValue.Controls.Add(this.lbType);
            this.pnValue.Controls.Add(this.tbValue);
            this.pnValue.Controls.Add(this.lbValue);
            this.pnValue.Controls.Add(this.cbType);
            this.pnValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnValue.Location = new System.Drawing.Point(1, 1);
            this.pnValue.MaximumSize = new System.Drawing.Size(301, 52);
            this.pnValue.MinimumSize = new System.Drawing.Size(301, 52);
            this.pnValue.Name = "pnValue";
            this.pnValue.Size = new System.Drawing.Size(301, 52);
            this.pnValue.TabIndex = 24;
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbType.Location = new System.Drawing.Point(23, 6);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(118, 13);
            this.lbType.TabIndex = 20;
            this.lbType.Text = "Opção de pagamento";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "INTEGRAL",
            "PARCELAR",
            "PARCIAL"});
            this.cbType.Location = new System.Drawing.Point(26, 23);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 21);
            this.cbType.TabIndex = 0;
            this.cbType.Text = "INTEGRAL";
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.TypeSelectedIndexChanged);
            this.cbType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TypeKeyDown);
            // 
            // CreditBillPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 174);
            this.Controls.Add(this.pnWindow);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(353, 249);
            this.MinimumSize = new System.Drawing.Size(353, 213);
            this.Name = "CreditBillPayment";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamento de fatura";
            this.pnWindow.ResumeLayout(false);
            this.scDate.Panel1.ResumeLayout(false);
            this.scDate.Panel1.PerformLayout();
            this.scDate.Panel2.ResumeLayout(false);
            this.scDate.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scDate)).EndInit();
            this.scDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.udParcels)).EndInit();
            this.pnCommand.ResumeLayout(false);
            this.pnCommand.PerformLayout();
            this.pnValue.ResumeLayout(false);
            this.pnValue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Label lbValue;
        private System.Windows.Forms.Panel pnWindow;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.DateTimePicker dpDate;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.SplitContainer scDate;
        private System.Windows.Forms.Label lbParcels;
        private System.Windows.Forms.NumericUpDown udParcels;
        private System.Windows.Forms.Panel pnCommand;
        private System.Windows.Forms.Panel pnValue;
    }
}