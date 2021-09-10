
namespace SISCOFIN_v1
{
    partial class AddressAssistent
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
            this.flAddress = new System.Windows.Forms.FlowLayoutPanel();
            this.lbCEP = new System.Windows.Forms.Label();
            this.mbCEP = new System.Windows.Forms.MaskedTextBox();
            this.btSearch = new System.Windows.Forms.PictureBox();
            this.ckMail = new System.Windows.Forms.CheckBox();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.lbComplement = new System.Windows.Forms.Label();
            this.lbDistrict = new System.Windows.Forms.Label();
            this.tbComplement = new System.Windows.Forms.TextBox();
            this.tbDistrict = new System.Windows.Forms.TextBox();
            this.lbCity = new System.Windows.Forms.Label();
            this.lbUF = new System.Windows.Forms.Label();
            this.lbCountry = new System.Windows.Forms.Label();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.cbUF = new System.Windows.Forms.ComboBox();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.pnCommand = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.brMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.imMenu = new System.Windows.Forms.PictureBox();
            this.lbMenu = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.pnWindow = new System.Windows.Forms.Panel();
            this.flAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btSearch)).BeginInit();
            this.pnCommand.SuspendLayout();
            this.brMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imMenu)).BeginInit();
            this.pnWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // flAddress
            // 
            this.flAddress.Controls.Add(this.lbCEP);
            this.flAddress.Controls.Add(this.mbCEP);
            this.flAddress.Controls.Add(this.btSearch);
            this.flAddress.Controls.Add(this.ckMail);
            this.flAddress.Controls.Add(this.lbAddress);
            this.flAddress.Controls.Add(this.lbNumber);
            this.flAddress.Controls.Add(this.tbAddress);
            this.flAddress.Controls.Add(this.tbNumber);
            this.flAddress.Controls.Add(this.lbComplement);
            this.flAddress.Controls.Add(this.lbDistrict);
            this.flAddress.Controls.Add(this.tbComplement);
            this.flAddress.Controls.Add(this.tbDistrict);
            this.flAddress.Controls.Add(this.lbCity);
            this.flAddress.Controls.Add(this.lbUF);
            this.flAddress.Controls.Add(this.lbCountry);
            this.flAddress.Controls.Add(this.tbCity);
            this.flAddress.Controls.Add(this.cbUF);
            this.flAddress.Controls.Add(this.tbCountry);
            this.flAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flAddress.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flAddress.Location = new System.Drawing.Point(0, 0);
            this.flAddress.Margin = new System.Windows.Forms.Padding(10);
            this.flAddress.Name = "flAddress";
            this.flAddress.Padding = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.flAddress.Size = new System.Drawing.Size(598, 262);
            this.flAddress.TabIndex = 0;
            // 
            // lbCEP
            // 
            this.lbCEP.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCEP.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbCEP.Location = new System.Drawing.Point(17, 7);
            this.lbCEP.Margin = new System.Windows.Forms.Padding(0, 7, 0, 1);
            this.lbCEP.Name = "lbCEP";
            this.lbCEP.Size = new System.Drawing.Size(563, 28);
            this.lbCEP.TabIndex = 77;
            this.lbCEP.Text = "CEP";
            this.lbCEP.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // mbCEP
            // 
            this.mbCEP.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mbCEP.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mbCEP.Location = new System.Drawing.Point(17, 36);
            this.mbCEP.Margin = new System.Windows.Forms.Padding(0);
            this.mbCEP.Mask = "00,000-000";
            this.mbCEP.Name = "mbCEP";
            this.mbCEP.Size = new System.Drawing.Size(131, 27);
            this.mbCEP.TabIndex = 0;
            this.mbCEP.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mbCEP.Validated += new System.EventHandler(this.CEPValidated);
            // 
            // btSearch
            // 
            this.btSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSearch.Image = global::SISCOFIN_v1.Properties.Resources.Search_24x24;
            this.btSearch.Location = new System.Drawing.Point(153, 37);
            this.btSearch.Margin = new System.Windows.Forms.Padding(5, 1, 235, 1);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(24, 24);
            this.btSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btSearch.TabIndex = 89;
            this.btSearch.TabStop = false;
            // 
            // ckMail
            // 
            this.ckMail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckMail.Checked = true;
            this.ckMail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckMail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckMail.ForeColor = System.Drawing.Color.DarkGreen;
            this.ckMail.Location = new System.Drawing.Point(412, 36);
            this.ckMail.Margin = new System.Windows.Forms.Padding(0);
            this.ckMail.Name = "ckMail";
            this.ckMail.Size = new System.Drawing.Size(169, 28);
            this.ckMail.TabIndex = 1;
            this.ckMail.Text = "Correspondência?";
            this.ckMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckMail.UseVisualStyleBackColor = true;
            this.ckMail.Validated += new System.EventHandler(this.MailValidated);
            // 
            // lbAddress
            // 
            this.lbAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddress.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbAddress.Location = new System.Drawing.Point(17, 71);
            this.lbAddress.Margin = new System.Windows.Forms.Padding(0, 7, 2, 1);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(461, 28);
            this.lbAddress.TabIndex = 73;
            this.lbAddress.Text = "Logradouro";
            this.lbAddress.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbNumber
            // 
            this.lbNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumber.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbNumber.Location = new System.Drawing.Point(480, 71);
            this.lbNumber.Margin = new System.Windows.Forms.Padding(0, 7, 0, 1);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(101, 28);
            this.lbNumber.TabIndex = 81;
            this.lbNumber.Text = "Nº";
            this.lbNumber.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbAddress
            // 
            this.tbAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbAddress.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress.Location = new System.Drawing.Point(17, 100);
            this.tbAddress.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(461, 27);
            this.tbAddress.TabIndex = 2;
            this.tbAddress.Validated += new System.EventHandler(this.StreetValidated);
            // 
            // tbNumber
            // 
            this.tbNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumber.Location = new System.Drawing.Point(480, 100);
            this.tbNumber.Margin = new System.Windows.Forms.Padding(0);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(101, 27);
            this.tbNumber.TabIndex = 3;
            this.tbNumber.Validated += new System.EventHandler(this.NumberValidated);
            // 
            // lbComplement
            // 
            this.lbComplement.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbComplement.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbComplement.Location = new System.Drawing.Point(17, 134);
            this.lbComplement.Margin = new System.Windows.Forms.Padding(0, 7, 2, 1);
            this.lbComplement.Name = "lbComplement";
            this.lbComplement.Size = new System.Drawing.Size(270, 28);
            this.lbComplement.TabIndex = 79;
            this.lbComplement.Text = "Complemento";
            this.lbComplement.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbDistrict
            // 
            this.lbDistrict.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDistrict.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbDistrict.Location = new System.Drawing.Point(289, 134);
            this.lbDistrict.Margin = new System.Windows.Forms.Padding(0, 7, 0, 1);
            this.lbDistrict.Name = "lbDistrict";
            this.lbDistrict.Size = new System.Drawing.Size(292, 28);
            this.lbDistrict.TabIndex = 83;
            this.lbDistrict.Text = "Bairro";
            this.lbDistrict.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbComplement
            // 
            this.tbComplement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbComplement.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbComplement.Location = new System.Drawing.Point(17, 163);
            this.tbComplement.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tbComplement.Name = "tbComplement";
            this.tbComplement.Size = new System.Drawing.Size(270, 27);
            this.tbComplement.TabIndex = 4;
            this.tbComplement.Validated += new System.EventHandler(this.ComplementValidated);
            // 
            // tbDistrict
            // 
            this.tbDistrict.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDistrict.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDistrict.Location = new System.Drawing.Point(289, 163);
            this.tbDistrict.Margin = new System.Windows.Forms.Padding(0);
            this.tbDistrict.Name = "tbDistrict";
            this.tbDistrict.Size = new System.Drawing.Size(292, 27);
            this.tbDistrict.TabIndex = 5;
            this.tbDistrict.Validated += new System.EventHandler(this.DistrictValidated);
            // 
            // lbCity
            // 
            this.lbCity.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCity.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbCity.Location = new System.Drawing.Point(17, 197);
            this.lbCity.Margin = new System.Windows.Forms.Padding(0, 7, 2, 1);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(270, 28);
            this.lbCity.TabIndex = 88;
            this.lbCity.Text = "Cidade";
            this.lbCity.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbUF
            // 
            this.lbUF.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUF.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbUF.Location = new System.Drawing.Point(289, 197);
            this.lbUF.Margin = new System.Windows.Forms.Padding(0, 7, 2, 1);
            this.lbUF.Name = "lbUF";
            this.lbUF.Size = new System.Drawing.Size(54, 28);
            this.lbUF.TabIndex = 75;
            this.lbUF.Text = "UF";
            this.lbUF.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbCountry
            // 
            this.lbCountry.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountry.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbCountry.Location = new System.Drawing.Point(345, 197);
            this.lbCountry.Margin = new System.Windows.Forms.Padding(0, 7, 0, 1);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(236, 28);
            this.lbCountry.TabIndex = 85;
            this.lbCountry.Text = "País";
            this.lbCountry.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbCity
            // 
            this.tbCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCity.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCity.Location = new System.Drawing.Point(17, 226);
            this.tbCity.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(270, 27);
            this.tbCity.TabIndex = 6;
            this.tbCity.Validated += new System.EventHandler(this.CityValidated);
            // 
            // cbUF
            // 
            this.cbUF.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUF.FormattingEnabled = true;
            this.cbUF.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AM",
            "AP",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MG",
            "MS",
            "MT",
            "PA",
            "PB",
            "PE",
            "PI",
            "PR",
            "RJ",
            "RN",
            "RO",
            "RR",
            "RS",
            "SC",
            "SE",
            "SP",
            "TO"});
            this.cbUF.Location = new System.Drawing.Point(289, 226);
            this.cbUF.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.cbUF.Name = "cbUF";
            this.cbUF.Size = new System.Drawing.Size(54, 28);
            this.cbUF.Sorted = true;
            this.cbUF.TabIndex = 7;
            this.cbUF.Validated += new System.EventHandler(this.UFValidated);
            // 
            // tbCountry
            // 
            this.tbCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCountry.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCountry.Location = new System.Drawing.Point(345, 226);
            this.tbCountry.Margin = new System.Windows.Forms.Padding(0);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(236, 27);
            this.tbCountry.TabIndex = 8;
            this.tbCountry.Validated += new System.EventHandler(this.CountryValidated);
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
            this.pnCommand.TabIndex = 9;
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
            this.brMenu.TabIndex = 91;
            // 
            // imMenu
            // 
            this.imMenu.Image = global::SISCOFIN_v1.Properties.Resources.Address_24x24;
            this.imMenu.Location = new System.Drawing.Point(5, 5);
            this.imMenu.Margin = new System.Windows.Forms.Padding(5, 5, 190, 5);
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
            this.lbMenu.Location = new System.Drawing.Point(219, 2);
            this.lbMenu.Margin = new System.Windows.Forms.Padding(0, 2, 181, 2);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(163, 30);
            this.lbMenu.TabIndex = 1;
            this.lbMenu.Text = "Novo Endereço";
            // 
            // btClose
            // 
            this.btClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Image = global::SISCOFIN_v1.Properties.Resources.Close_16x16;
            this.btClose.Location = new System.Drawing.Point(563, 0);
            this.btClose.Margin = new System.Windows.Forms.Padding(0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(34, 34);
            this.btClose.TabIndex = 2;
            this.btClose.TabStop = false;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.CancelClick);
            // 
            // pnWindow
            // 
            this.pnWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnWindow.Controls.Add(this.flAddress);
            this.pnWindow.Controls.Add(this.pnCommand);
            this.pnWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnWindow.Location = new System.Drawing.Point(0, 33);
            this.pnWindow.Name = "pnWindow";
            this.pnWindow.Size = new System.Drawing.Size(600, 317);
            this.pnWindow.TabIndex = 92;
            // 
            // AddressAssistent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.pnWindow);
            this.Controls.Add(this.brMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddressAssistent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddressAssistent";
            this.Load += new System.EventHandler(this.LoadManager);
            this.flAddress.ResumeLayout(false);
            this.flAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btSearch)).EndInit();
            this.pnCommand.ResumeLayout(false);
            this.brMenu.ResumeLayout(false);
            this.brMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imMenu)).EndInit();
            this.pnWindow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flAddress;
        private System.Windows.Forms.Label lbCEP;
        private System.Windows.Forms.MaskedTextBox mbCEP;
        private System.Windows.Forms.PictureBox btSearch;
        private System.Windows.Forms.CheckBox ckMail;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Label lbComplement;
        private System.Windows.Forms.Label lbDistrict;
        private System.Windows.Forms.TextBox tbComplement;
        private System.Windows.Forms.TextBox tbDistrict;
        private System.Windows.Forms.Label lbCity;
        private System.Windows.Forms.Label lbUF;
        private System.Windows.Forms.Label lbCountry;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.ComboBox cbUF;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.Panel pnCommand;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.FlowLayoutPanel brMenu;
        private System.Windows.Forms.PictureBox imMenu;
        private System.Windows.Forms.Label lbMenu;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel pnWindow;
    }
}