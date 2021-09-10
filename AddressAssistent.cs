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
    public partial class AddressAssistent : Form
    {
        #region Declarações de variáveis
        /// <summary>
        /// 
        /// </summary>
        private static long Id;
        #endregion
        #region Inicialização da classe AccountManager
        public AddressAssistent(long id)
        {
            InitializeComponent();
            Address.Person = Globals.SelectedPerson;
            Id = id;
            //
            // cbUF
            //
            cbUF.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbUF.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbUF.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
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
            Setup(Id);
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        #region Métodos
        /// <summary>
        /// 
        /// </summary>
        public void Setup(long id = -1)
        {
            Address.Clear();
            Address.Person = Globals.SelectedPerson;
            if (id.Equals(-1))
            {
                cbUF.SelectedIndex = -1;
                ckMail.Checked = false;
                imMenu.Margin = new Padding(5, 5, 192, 5);
                lbMenu.Margin = new Padding(0, 2, 182, 2);
                lbMenu.Text = "Novo Endereço";
                mbCEP.Text = string.Empty;
                tbAddress.Text = string.Empty;
                tbCity.Text = string.Empty;
                tbComplement.Text = string.Empty;
                tbCountry.Text = string.Empty;
                tbDistrict.Text = string.Empty;
                tbNumber.Text = string.Empty;
            }
            else
            {
                cbUF.Text = DataBase.Tables.AddressBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<string>("Estate");
                Address.Estate = cbUF.Text;
                ckMail.Checked = DataBase.Tables.AddressBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<bool>("Mail");
                Address.Mail = ckMail.Checked;
                imMenu.Margin = new Padding(5, 5, 190, 5);
                lbMenu.Margin = new Padding(0, 2, 181, 2);
                lbMenu.Text = "Editar Endereço";
                mbCEP.Text = DataBase.Tables.AddressBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<string>("CEP");
                Address.CEP = mbCEP.Text;
                tbAddress.Text = DataBase.Tables.AddressBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<string>("Address");
                Address.Street = tbAddress.Text;
                tbCity.Text = DataBase.Tables.AddressBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<string>("City");
                Address.City = tbCity.Text;
                tbComplement.Text = DataBase.Tables.AddressBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<string>("Complement");
                Address.Complement = tbComplement.Text;
                tbCountry.Text = DataBase.Tables.AddressBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<string>("Country");
                Address.Country = tbCountry.Text;
                tbDistrict.Text = DataBase.Tables.AddressBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<string>("District");
                Address.District = tbDistrict.Text;
                tbNumber.Text = DataBase.Tables.AddressBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<string>("Number");
                Address.Number = tbNumber.Text;
            }
            Address.HasChanges = false;
            mbCEP.Select();
        }
        #endregion
        #region Eventos
        #region Validação de dados
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CEPValidated(object sender, EventArgs e)
        {
            Address.CEP = (sender as MaskedTextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CityValidated(object sender, EventArgs e)
        {
            Address.City = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComplementValidated(object sender, EventArgs e)
        {
            Address.Complement = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountryValidated(object sender, EventArgs e)
        {
            Address.Country = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistrictValidated(object sender, EventArgs e)
        {
            Address.District = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MailValidated(object sender, EventArgs e)
        {
            Address.Mail = (sender as CheckBox).Checked;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidated(object sender, EventArgs e)
        {
            Address.Number = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StreetValidated(object sender, EventArgs e)
        {
            Address.Street = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UFValidated(object sender, EventArgs e)
        {
            Address.Estate = (sender as ComboBox).Text.Replace("'", "''").Trim();
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
            if (Id.Equals(-1) && Address.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            if (!Id.Equals(-1) && Address.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("Existem alterações não salvas! As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveClick(object sender, EventArgs e)
        {
            if (Globals.IsRunning || !Address.HasChanges) return;
            DialogResult dialogResult;
            if (string.IsNullOrWhiteSpace(Address.CEP) || string.IsNullOrWhiteSpace(Address.Street) ||
                string.IsNullOrWhiteSpace(Address.Number) || string.IsNullOrWhiteSpace(Address.Complement) ||
                string.IsNullOrWhiteSpace(Address.District) || string.IsNullOrWhiteSpace(Address.City) ||
                string.IsNullOrWhiteSpace(Address.Estate) || string.IsNullOrWhiteSpace(Address.Country))
            {
                MessageBox.Show("Campos obrigatórios em branco.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mbCEP.Select();
                return;
            }
            if (!Id.Equals(-1))
            {
                dialogResult = MessageBox.Show("Deseja atualizar o endereço?", "Editar endereço", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                dialogResult = MessageBox.Show("Confirmar o cadastro do endereço?", "Novo endereço", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (!dialogResult.Equals(DialogResult.Yes)) return; 
            Globals.IsRunning = true;
            SuspendLayout();
            if (!Id.Equals(-1)) Address.Update(Id);
            else Address.Insert();
            Globals.IsError = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
            Close();
        }
        #endregion
        #endregion
    }
}
