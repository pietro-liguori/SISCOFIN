using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    public partial class EmailAssistent : Form
    {
        #region Declarações de variáveis
        /// <summary>
        /// 
        /// </summary>
        private static long Id;
        #endregion
        #region Inicialização da classe AccountManager
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public EmailAssistent(long id)
        {
            InitializeComponent();
            Email.Person = Globals.SelectedPerson;
            Id = id;
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
            Email.Clear();
            Email.Person = Globals.SelectedPerson;
            if (id.Equals(-1))
            {
                ckMail.Checked = false;
                imMenu.Margin = new Padding(5, 5, 207, 5);
                lbMenu.Margin = new Padding(0, 2, 196, 2);
                lbMenu.Text = "Novo E-mail";
                tbEmail.Text = string.Empty;
            }
            else
            {
                ckMail.Checked = DataBase.Tables.EmailBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<bool>("Mail");
                Email.Mail = ckMail.Checked;
                imMenu.Margin = new Padding(5, 5, 205, 5);
                lbMenu.Margin = new Padding(0, 2, 195, 2);
                lbMenu.Text = "Editar E-mail";
                tbEmail.Text = DataBase.Tables.EmailBook.AsEnumerable()
                        .Where(row => row.Field<long>("Id").Equals(id))
                        .CopyToDataTable().Rows[0].Field<string>("Email");
                Email.Text = tbEmail.Text;
            }
            Email.HasChanges = false;
            tbEmail.Select();
        }
        #endregion
        #region Eventos
        #region Validação de dados
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailValidated(object sender, EventArgs e)
        {
            Email.Text = (sender as TextBox).Text.Replace("'", "''").Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailValidating(object sender, CancelEventArgs e)
        {
            TextBox me = sender as TextBox;
            if (!MyMethods.ValidateEmail(me.Text.Replace("'", "''").Trim()))
            {
                MessageBox.Show("E-mail inválido", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MailValidated(object sender, EventArgs e)
        {
            Email.Mail = (sender as RadioButton).Checked;
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
            if (Id.Equals(-1) && Email.HasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("As informações serão perdidas.\n\nDeseja prosseguir?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (!dialogResult.Equals(DialogResult.Yes)) return;
            }
            if (!Id.Equals(-1) && Email.HasChanges)
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
            if (Globals.IsRunning || !Email.HasChanges) return;
            DialogResult dialogResult;
            if (string.IsNullOrWhiteSpace(Email.Text))
            {
                MessageBox.Show("Campos obrigatórios em branco.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbEmail.Select();
                return;
            }
            if (!Id.Equals(-1))
            {
                dialogResult = MessageBox.Show("Deseja atualizar o e-mail?", "Editar e-mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                dialogResult = MessageBox.Show("Confirmar o cadastro do e-mail?", "Novo e-mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (!dialogResult.Equals(DialogResult.Yes)) return;
            Globals.IsRunning = true;
            SuspendLayout();
            if (!Id.Equals(-1)) Email.Update(Id);
            else Email.Insert();
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
