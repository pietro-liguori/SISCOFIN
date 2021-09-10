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
    public partial class PhoneAssistent : Form
    {
        #region Declarações de variáveis
        /// <summary>
        /// 
        /// </summary>
        private static long Id;
        #endregion
        #region Inicialização da classe AccountManager
        public PhoneAssistent(long id)
        {
            InitializeComponent();
            Id = id;
            Phone.Person = Globals.SelectedPerson;
            //
            // cbType
            //
            cbType.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);
            cbType.KeyPress += new KeyPressEventHandler(MyEvents.OnlyMatchComboBox);
            cbType.TextChanged += new EventHandler(MyEvents.ComboBoxAutoComplete);
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
        public void Setup(long id)
        {
            Phone.Clear();
            Phone.Person = Globals.SelectedPerson;
            if (id.Equals(-1))
            {
                cbType.SelectedIndex = -1;
                imMenu.Margin = new Padding(5, 5, 193, 5);
                lbMenu.Margin = new Padding(0, 2, 188, 2);
                lbMenu.Text = "Novo Telefone";
                mbPhone.Text = string.Empty;
            }
            else
            {
                cbType.Text = DataBase.Tables.PhoneBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<string>("Type");
                Phone.Type = cbType.Text;
                imMenu.Margin = new Padding(5, 5, 195, 5);
                lbMenu.Margin = new Padding(0, 2, 183, 2);
                lbMenu.Text = "Editar Telefone";
                mbPhone.Text = DataBase.Tables.PhoneBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<string>("CountryCode") +
                        DataBase.Tables.PhoneBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<string>("DDD") +
                        DataBase.Tables.PhoneBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<string>("Phone");
                Phone.CountryCode = mbPhone.Text.Substring(0, 2);
                Phone.DDD = mbPhone.Text.Substring(2, 2);
                Phone.Number = mbPhone.Text.Substring(4);
            }
            Phone.HasChanges = false;
            mbPhone.Select();
        }
        #endregion
        #region Eventos
        #region Validação de dados
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneValidated(object sender, EventArgs e)
        {
            try { Phone.CountryCode = (sender as MaskedTextBox).Text.Substring(0, 2); }
            catch { Phone.CountryCode = string.Empty; }
            try { Phone.DDD = (sender as MaskedTextBox).Text.Substring(2, 2); }
            catch { Phone.DDD = string.Empty; }
            try { Phone.Number = (sender as MaskedTextBox).Text.Substring(4); }
            catch { Phone.Number = string.Empty; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeValidated(object sender, EventArgs e)
        {
            Phone.Type = (sender as ComboBox).Text.Replace("'", "''").Trim();
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
            if (Id.Equals(-1) && Phone.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            if (!Id.Equals(-1) && Phone.HasChanges)
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
            if (Globals.IsRunning || !Phone.HasChanges) return;
            DialogResult dialogResult;
            if (string.IsNullOrWhiteSpace(Phone.Number) || string.IsNullOrWhiteSpace(Phone.Type))
            {
                MessageBox.Show("Campos obrigatórios em branco.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mbPhone.Select();
                return;
            }
            if (!Id.Equals(-1))
            {
                dialogResult = MessageBox.Show("Deseja atualizar o telefone?", "Editar telefone", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                dialogResult = MessageBox.Show("Confirmar o cadastro do telefone?", "Novo telefone", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (!dialogResult.Equals(DialogResult.Yes)) return;
            Globals.IsRunning = true;
            SuspendLayout();
            if (!Id.Equals(-1)) Phone.Update(Id);
            else Phone.Insert();
            Globals.IsError = false;
            Globals.IsRunning = false;
            ResumeLayout(false);
            PerformLayout();
            Close();
        }
        #endregion
        #region Configuração do formulário
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneKeyDown(object sender, KeyEventArgs e)
        {
            MaskedTextBox me = (MaskedTextBox)sender;
            int selStart = me.SelectionStart;
            int offSet = 0;
            if (e.KeyCode.Equals(Keys.Back)) offSet = 1;
            if (me.Text.Length > 11 + offSet) me.Mask = "+00 00 00000-0000";
            else me.Mask = "+00 00 0000-0000";
            me.SelectionStart = selStart;
        }
        #endregion
        #endregion
    }
}
