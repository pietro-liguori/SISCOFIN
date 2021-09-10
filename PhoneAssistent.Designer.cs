
namespace SISCOFIN_v1
{
    partial class PhoneAssistent
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
            this.pnCommand = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.flPhone = new System.Windows.Forms.FlowLayoutPanel();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.mbPhone = new System.Windows.Forms.MaskedTextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.brMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.imMenu = new System.Windows.Forms.PictureBox();
            this.lbMenu = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.pnWindow = new System.Windows.Forms.Panel();
            this.pnCommand.SuspendLayout();
            this.flPhone.SuspendLayout();
            this.brMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imMenu)).BeginInit();
            this.pnWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnCommand
            // 
            this.pnCommand.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnCommand.Controls.Add(this.btCancel);
            this.pnCommand.Controls.Add(this.btSave);
            this.pnCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnCommand.Location = new System.Drawing.Point(0, 262);
            this.pnCommand.Name = "pnCommand";
            this.pnCommand.Size = new System.Drawing.Size(598, 53);
            this.pnCommand.TabIndex = 96;
            this.pnCommand.TabStop = true;
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.DarkGreen;
            this.btCancel.Location = new System.Drawing.Point(369, 15);
            this.btCancel.Margin = new System.Windows.Forms.Padding(15, 15, 2, 15);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(106, 23);
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
            this.btSave.Location = new System.Drawing.Point(479, 15);
            this.btSave.Margin = new System.Windows.Forms.Padding(2, 15, 15, 15);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(106, 23);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "Salvar";
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.SaveClick);
            // 
            // flPhone
            // 
            this.flPhone.Controls.Add(this.lbPhone);
            this.flPhone.Controls.Add(this.lbType);
            this.flPhone.Controls.Add(this.mbPhone);
            this.flPhone.Controls.Add(this.cbType);
            this.flPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flPhone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flPhone.Location = new System.Drawing.Point(0, 0);
            this.flPhone.Margin = new System.Windows.Forms.Padding(10);
            this.flPhone.Name = "flPhone";
            this.flPhone.Padding = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.flPhone.Size = new System.Drawing.Size(598, 262);
            this.flPhone.TabIndex = 97;
            // 
            // lbPhone
            // 
            this.lbPhone.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbPhone.Location = new System.Drawing.Point(17, 7);
            this.lbPhone.Margin = new System.Windows.Forms.Padding(0, 7, 2, 1);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(270, 28);
            this.lbPhone.TabIndex = 73;
            this.lbPhone.Text = "Telefone";
            this.lbPhone.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbType
            // 
            this.lbType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbType.Location = new System.Drawing.Point(291, 7);
            this.lbType.Margin = new System.Windows.Forms.Padding(2, 7, 0, 1);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(290, 28);
            this.lbType.TabIndex = 77;
            this.lbType.Text = "Tipo";
            this.lbType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // mbPhone
            // 
            this.mbPhone.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mbPhone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mbPhone.Location = new System.Drawing.Point(17, 36);
            this.mbPhone.Margin = new System.Windows.Forms.Padding(0);
            this.mbPhone.Mask = "+00 00 0000-0000";
            this.mbPhone.Name = "mbPhone";
            this.mbPhone.Size = new System.Drawing.Size(270, 27);
            this.mbPhone.TabIndex = 0;
            this.mbPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mbPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mbPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PhoneKeyDown);
            this.mbPhone.Validated += new System.EventHandler(this.PhoneValidated);
            // 
            // cbType
            // 
            this.cbType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "CELULAR",
            "COMERCIAL",
            "RESIDENCIAL"});
            this.cbType.Location = new System.Drawing.Point(289, 36);
            this.cbType.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(292, 28);
            this.cbType.Sorted = true;
            this.cbType.TabIndex = 1;
            this.cbType.Validated += new System.EventHandler(this.TypeValidated);
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
            this.brMenu.Size = new System.Drawing.Size(600, 33);
            this.brMenu.TabIndex = 100;
            // 
            // imMenu
            // 
            this.imMenu.Image = global::SISCOFIN_v1.Properties.Resources.Phone_24x24;
            this.imMenu.Location = new System.Drawing.Point(5, 5);
            this.imMenu.Margin = new System.Windows.Forms.Padding(5, 5, 195, 5);
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
            this.lbMenu.Location = new System.Drawing.Point(224, 2);
            this.lbMenu.Margin = new System.Windows.Forms.Padding(0, 2, 183, 2);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(159, 30);
            this.lbMenu.TabIndex = 1;
            this.lbMenu.Text = "Editar Telefone";
            // 
            // btClose
            // 
            this.btClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Image = global::SISCOFIN_v1.Properties.Resources.Close_16x16;
            this.btClose.Location = new System.Drawing.Point(566, 0);
            this.btClose.Margin = new System.Windows.Forms.Padding(0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(34, 34);
            this.btClose.TabIndex = 2;
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // pnWindow
            // 
            this.pnWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnWindow.Controls.Add(this.flPhone);
            this.pnWindow.Controls.Add(this.pnCommand);
            this.pnWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnWindow.Location = new System.Drawing.Point(0, 33);
            this.pnWindow.Name = "pnWindow";
            this.pnWindow.Size = new System.Drawing.Size(600, 317);
            this.pnWindow.TabIndex = 101;
            // 
            // PhoneAssistent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.pnWindow);
            this.Controls.Add(this.brMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PhoneAssistent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhoneAssistent";
            this.Load += new System.EventHandler(this.LoadManager);
            this.pnCommand.ResumeLayout(false);
            this.flPhone.ResumeLayout(false);
            this.flPhone.PerformLayout();
            this.brMenu.ResumeLayout(false);
            this.brMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imMenu)).EndInit();
            this.pnWindow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnCommand;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.FlowLayoutPanel flPhone;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.MaskedTextBox mbPhone;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.FlowLayoutPanel brMenu;
        private System.Windows.Forms.PictureBox imMenu;
        private System.Windows.Forms.Label lbMenu;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel pnWindow;
    }
}