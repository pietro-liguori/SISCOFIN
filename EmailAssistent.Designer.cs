
namespace SISCOFIN_v1
{
    partial class EmailAssistent
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
            this.ckMail = new System.Windows.Forms.CheckBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.pnCommand = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.flEmail = new System.Windows.Forms.FlowLayoutPanel();
            this.brMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.imMenu = new System.Windows.Forms.PictureBox();
            this.lbMenu = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.pnWindow = new System.Windows.Forms.Panel();
            this.pnCommand.SuspendLayout();
            this.flEmail.SuspendLayout();
            this.brMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imMenu)).BeginInit();
            this.pnWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckMail
            // 
            this.ckMail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckMail.Checked = true;
            this.ckMail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckMail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckMail.ForeColor = System.Drawing.Color.DarkGreen;
            this.ckMail.Location = new System.Drawing.Point(410, 36);
            this.ckMail.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.ckMail.Name = "ckMail";
            this.ckMail.Size = new System.Drawing.Size(171, 28);
            this.ckMail.TabIndex = 1;
            this.ckMail.Text = "Correspondência?";
            this.ckMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckMail.UseVisualStyleBackColor = true;
            this.ckMail.Validated += new System.EventHandler(this.MailValidated);
            // 
            // lbEmail
            // 
            this.lbEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbEmail.Location = new System.Drawing.Point(17, 7);
            this.lbEmail.Margin = new System.Windows.Forms.Padding(0, 7, 0, 1);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(564, 28);
            this.lbEmail.TabIndex = 76;
            this.lbEmail.Text = "Email";
            this.lbEmail.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbEmail
            // 
            this.tbEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.tbEmail.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.Location = new System.Drawing.Point(17, 36);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(0);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(391, 27);
            this.tbEmail.TabIndex = 0;
            this.tbEmail.Validating += new System.ComponentModel.CancelEventHandler(this.EmailValidating);
            this.tbEmail.Validated += new System.EventHandler(this.EmailValidated);
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
            this.pnCommand.TabIndex = 2;
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
            // flEmail
            // 
            this.flEmail.Controls.Add(this.lbEmail);
            this.flEmail.Controls.Add(this.tbEmail);
            this.flEmail.Controls.Add(this.ckMail);
            this.flEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flEmail.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flEmail.Location = new System.Drawing.Point(0, 0);
            this.flEmail.Margin = new System.Windows.Forms.Padding(10);
            this.flEmail.Name = "flEmail";
            this.flEmail.Padding = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.flEmail.Size = new System.Drawing.Size(598, 262);
            this.flEmail.TabIndex = 98;
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
            this.brMenu.TabIndex = 99;
            // 
            // imMenu
            // 
            this.imMenu.Image = global::SISCOFIN_v1.Properties.Resources.E_mail_24x24;
            this.imMenu.Location = new System.Drawing.Point(5, 5);
            this.imMenu.Margin = new System.Windows.Forms.Padding(5, 5, 207, 5);
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
            this.lbMenu.Location = new System.Drawing.Point(236, 2);
            this.lbMenu.Margin = new System.Windows.Forms.Padding(0, 2, 196, 2);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(134, 30);
            this.lbMenu.TabIndex = 1;
            this.lbMenu.Text = "Novo E-mail";
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
            this.btClose.Click += new System.EventHandler(this.CancelClick);
            // 
            // pnWindow
            // 
            this.pnWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnWindow.Controls.Add(this.flEmail);
            this.pnWindow.Controls.Add(this.pnCommand);
            this.pnWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnWindow.Location = new System.Drawing.Point(0, 33);
            this.pnWindow.Name = "pnWindow";
            this.pnWindow.Size = new System.Drawing.Size(600, 317);
            this.pnWindow.TabIndex = 100;
            // 
            // EmailAssistent
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
            this.Name = "EmailAssistent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmailAssistent";
            this.Load += new System.EventHandler(this.LoadManager);
            this.pnCommand.ResumeLayout(false);
            this.flEmail.ResumeLayout(false);
            this.flEmail.PerformLayout();
            this.brMenu.ResumeLayout(false);
            this.brMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imMenu)).EndInit();
            this.pnWindow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ckMail;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Panel pnCommand;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.FlowLayoutPanel flEmail;
        private System.Windows.Forms.FlowLayoutPanel brMenu;
        private System.Windows.Forms.PictureBox imMenu;
        private System.Windows.Forms.Label lbMenu;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel pnWindow;
    }
}