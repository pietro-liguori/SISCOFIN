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
    /// 
    /// </summary>
    public partial class CloseCreditBills : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="billList"></param>
        /// <param name="billData"></param>
        public CloseCreditBills(Dictionary<int, long> billList, DataTable billData)
        {
            InitializeComponent();
            dgBills.CellMouseDown += new DataGridViewCellMouseEventHandler(MyEvents.DataGridViewRightClick);
            dgBills.Rows.Clear();
            foreach (int index in billList.Keys)
            {
                long closingDay = billData.Rows[index].Field<long>("ClosingDay");
                dgBills.Rows.Add();
                dgBills.Rows[dgBills.Rows.Count - 1].Cells[clId.Index].Value = billList[index];
                dgBills.Rows[dgBills.Rows.Count - 1].Cells[clCheck.Index].Value = 1;
                dgBills.Rows[dgBills.Rows.Count - 1].Cells[clDescription.Index].Value = billData.Rows[index].Field<string>("Description");
                dgBills.Rows[dgBills.Rows.Count - 1].Cells[clCloseDate.Index].Value = closingDay + "/" + billData.Rows[index].Field<DateTime>("DueDate").ToString("MM/yyyy");
                dgBills.Rows[dgBills.Rows.Count - 1].Cells[clValue.Index].Value = billData.Rows[index].Field<string>("Value");
            }
            dgBills.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_btCancel(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_btSave(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgBills.Rows)
            {
                if(((int)dgBills.Rows[row.Index].Cells[clCheck.Index].Value).Equals(1))
                {
                    long creditBill = (long)dgBills.Rows[row.Index].Cells[clId.Index].Value;
                    string closingDate = Convert.ToDateTime(dgBills.Rows[row.Index].Cells[clCloseDate.Index].Value).ToString("yyyy-MM-dd");
                    string billDescription = (string)dgBills.Rows[row.Index].Cells[clDescription.Index].Value;
                    try
                    {
                        var sqlConn = DataBase.DataBaseConnection();
                        var sqlCmd = sqlConn.CreateCommand();
                        sqlCmd.CommandText = Properties.Resources.sqlCloseCreditBill;
                        sqlCmd.Parameters.AddWithValue("@ClosingDate", closingDate);
                        sqlCmd.Parameters.AddWithValue("@Id", creditBill);
                        sqlCmd.ExecuteNonQuery();
                        sqlConn.Close();
                        DataBase.Tables.CreditBills = DataBase.Populate(Properties.Resources.sqlCreditBills);
                    }
                    catch (Exception exErr)
                    {
                        MessageBox.Show("Erro ao fechar a fatura " + billDescription + ".\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Globals.IsError = true;
                        return;
                    }
                }
            }
            Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellContentClick_dgBills(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex.Equals(3) && e.RowIndex > -1)
            {
                DateTime foreCastDate = DateTime.Parse(dgBills.Rows[e.RowIndex].Cells[clCloseDate.Index].Value.ToString());
                BillClosingDate newWindow = new BillClosingDate(foreCastDate);
                newWindow.ShowDialog();
                dgBills.Rows[e.RowIndex].Cells[clCloseDate.Index].Value = Debt.Date;
            }
        }
    }
}
