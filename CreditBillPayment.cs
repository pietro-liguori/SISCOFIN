using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CreditBillPayment : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public static long Bill; 
        /// <summary>
        /// 
        /// </summary>
        private static decimal BillValue;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="billData"></param>
        public CreditBillPayment(DataTable billData)
        {
            InitializeComponent();
            tbValue.KeyDown += new KeyEventHandler(MyEvents.DecimalMask);
            Bill = billData.Rows[Globals.SelectedIndex].Field<long>("Id");
            BillValue = billData.Rows[Globals.SelectedIndex].Field<decimal>("DecValor");
            Debt.DebtValue = BillValue;
            tbValue.Text = Math.Abs(Debt.DebtValue).ToString("#,##0.00");
            Debt.Date = DateTime.Today.ToString("yyyy-MM-dd");
            dpDate.Value = DateTime.Today;
            cbType.Select();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveClick(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            if(cbType.SelectedIndex.Equals(0))
            {
                DialogResult dialogResult = MessageBox.Show(string.Format(@"
                    Lançar o pagamento total desta fatura em {0}?
                    ", DateTime.Parse(Debt.Date).ToString("dd/MM/yyyy")), "Pagamento de fatura", MessageBoxButtons.YesNo);
                if (!dialogResult.Equals(DialogResult.Yes))
                {
                    cbType.Select();
                    return;
                }
                Globals.IsRunning = true;
                SuspendLayout();
                Debt.Description = "PAGAMENTO DA FATURA DO CARTÃO DE CRÉDITO";
                Debt.Insert();
                long sts = 11;
                Debt.PayCreditBill(sts);
            }
            else if(cbType.SelectedIndex.Equals(1))
            {
                DialogResult dialogResult = MessageBox.Show(string.Format(@"
                    Lançar o parcelamento em {0}x desta fatura em {1}?
                    ", udParcels.Value.ToString(), DateTime.Parse(Debt.Date).ToString("dd/MM/yyyy")), "Pagamento de fatura", MessageBoxButtons.YesNo);
                if (!dialogResult.Equals(DialogResult.Yes))
                {
                    cbType.Select();
                    return;
                }
                Globals.IsRunning = true;
                SuspendLayout();
                Debt.Description = "PARCELAMENTO DA FATURA DO CARTÃO DE CRÉDITO";
                Debt.Opperation = 4;
                Debt.Insert();
                long sts = 14;
                Debt.PayCreditBill(sts);
                Debt.Credit();
            }
            else if (cbType.SelectedIndex.Equals(2))
            {
                DialogResult dialogResult = MessageBox.Show("Lançar o pagamento à menor da fatura em " + 
                    DateTime.Parse(Debt.Date).ToString("dd/MM/yyyy") + "?\nValor total: R$" + 
                    BillValue.ToString("#,##0.00") + "\nValor pago: R$" + tbValue.Text
                    , "Pagamento de fatura", MessageBoxButtons.YesNo);
                if (!dialogResult.Equals(DialogResult.Yes))
                {
                    cbType.Select();
                    return;
                }
                Globals.IsRunning = true;
                SuspendLayout();
                Debt.Description = "PAGAMENTO À MENOR DA FATURA DO CARTÃO DE CRÉDITO";
                Debt.Insert();
                long sts = 12;
                Debt.PayCreditBill(sts);
                Debt.Opperation = 4;
                Debt.Description = "SALDO RESTANTE DA FATURA DO MÊS ANTERIOR";
                Debt.DebtValue = Math.Abs(Debt.DebtValue) - BillValue;
                Debt.Insert();
                Debt.Credit();
            }
            Debt.Clear();
            Globals.IsRunning = false;
            Globals.IsError = false;
            ResumeLayout(false);
            PerformLayout();
            Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeKeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeSelectedIndexChanged(object sender, EventArgs e)
        {
            switch((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    Size = MinimumSize;
                    pnWindow.Size = pnWindow.MinimumSize;
                    scDate.Size = scDate.MinimumSize;
                    scDate.Panel1Collapsed = true;
                    udParcels.Value = 1;
                    udParcels.Enabled = false;
                    tbValue.ReadOnly = true;
                    tbValue.Text = BillValue.ToString("#,##0.00");
                    dpDate.Select();
                    Debt.DebtValue = BillValue;
                    Debt.Parcels = 1;
                    break;
                case 1:
                    Size = MaximumSize;
                    pnWindow.Size = pnWindow.MaximumSize;
                    scDate.Size = scDate.MaximumSize;
                    scDate.Panel1Collapsed = false;
                    udParcels.Enabled = true;
                    tbValue.ReadOnly = true;
                    tbValue.Text = BillValue.ToString("#,##0.00");
                    udParcels.Select();
                    Debt.DebtValue = BillValue;
                    break;
                case 2:
                    Size = MinimumSize;
                    pnWindow.Size = pnWindow.MinimumSize;
                    scDate.Size = scDate.MinimumSize;
                    scDate.Panel1Collapsed = true;
                    udParcels.Value = 1;
                    udParcels.Enabled = false;
                    tbValue.ReadOnly = false;
                    tbValue.Select();
                    tbValue.SelectionStart = 0;
                    tbValue.SelectionLength = tbValue.TextLength;
                    Debt.Parcels = 1;
                    break;
            }
            scDate.SplitterWidth = 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidatedDate(object sender, EventArgs e)
        {
            try { Debt.Date = (sender as DateTimePicker).Value.ToString("yyyy-MM-dd"); }
            catch { Debt.Date = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueValidating(object sender, CancelEventArgs e)
        {
            if (decimal.Parse(tbValue.Text) > BillValue) tbValue.Text = BillValue.ToString("#,##0.00");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueValidated(object sender, EventArgs e)
        {
            try { Debt.DebtValue = decimal.Parse((sender as TextBox).Text); }
            catch { Debt.DebtValue = 0; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParcelsValidated(object sender, EventArgs e)
        {
            try { Debt.Parcels = (long)(sender as NumericUpDown).Value; }
            catch { Debt.Parcels = 1; }
        }
    }
}
