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
    /// <summary>
    /// Classe de formulário para alteração de data de fechamento de fatura do cartão de crédito no <see cref="DataGridView"/> <see cref="CloseCreditBills.dgBills"/> do formulário da classe <see cref="CloseCreditBills"/>.
    /// </summary>
    public partial class BillClosingDate : Form
    {
        /// <summary>
        /// Método de inicialização da classe.
        /// </summary>
        /// <param name="date">Variável do tipo <see cref="DateTime"/> que carrega a data de fechamento prevista da fatura selecionada no <see cref="DataGridView"/> <see cref="CloseCreditBills.dgBills"/> do formulário da classe <see cref="CloseCreditBills"/>.</param>
        public BillClosingDate(DateTime date)
        {
            InitializeComponent();
            dpCloseDate.Value = date;
            dpCloseDate.Select();
        }
        /// <summary>
        /// Evento do tipo <see cref="Control.Click"/> para controles do tipo <see cref="Button"/>.
        /// <para>Guarda a data selecionada no <see cref="DateTimePicker"/> <see cref="dpCloseDate"/> em <see cref="Debt.Date"/>.</para>
        /// </summary>
        /// <param name="sender">Objeto que carrega os parâmetros do <see cref="Button"/> que disparou o evento.</param>
        /// <param name="e">Recebe os dados de <see cref="EventArgs"/> para o evento.</param>
        private void Click_btOK(object sender, EventArgs e)
        {
            Debt.Date = dpCloseDate.Value.ToString("yyyy-MM-dd");
            Close();
        }
    }
}
