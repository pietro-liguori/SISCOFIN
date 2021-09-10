using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    public class Debt
    {
        private static long user = -1;
        private static long person = -1;
        private static long debtClass = -1;
        private static long debtType = 0;
        private static long opperation = -1;
        private static long account = -1;
        private static long card = -1;
        private static long category = -1;
        private static long subcategory1 = -1;
        private static long subcategory2 = -1;
        private static long subcategory3 = -1;
        private static long parcels = -1;
        private static string date = string.Empty;
        private static string description = string.Empty;
        private static string observation = string.Empty;
        private static decimal debtValue = 0;
        private static decimal balance = 0;
        public static bool HasChanges = false;
        public static long CurrentId = -1;
        public static long User
        {
            get { return user; }
            set
            {
                if (!user.Equals(value))
                {
                    user = value;
                    HasChanges = true;
                }
            }
        }
        public static long Person
        {
            get { return person; }
            set
            {
                if (!person.Equals(value))
                {
                    person = value;
                    HasChanges = true;
                }
            }
        }
        public static long DebtClass
        {
            get { return debtClass; }
            set
            {
                if (!debtClass.Equals(value))
                {
                    debtClass = value;
                    HasChanges = true;
                }
            }
        }
        public static long DebtType
        {
            get { return debtType; }
            set
            {
                if (!debtType.Equals(value))
                {
                    debtType = value;
                    HasChanges = true;
                }
            }
        }
        public static long Opperation
        {
            get { return opperation; }
            set
            {
                if (!opperation.Equals(value))
                {
                    opperation = value;
                    HasChanges = true;
                }
            }
        }
        public static long Account
        {
            get { return account; }
            set
            {
                if (!account.Equals(value))
                {
                    account = value;
                    HasChanges = true;
                }
            }
        }
        public static long Card
        {
            get { return card; }
            set
            {
                if (!card.Equals(value))
                {
                    card = value;
                    HasChanges = true;
                }
            }
        }
        public static long Category
        {
            get { return category; }
            set
            {
                if (!category.Equals(value))
                {
                    category = value;
                    HasChanges = true;
                }
            }
        }
        public static long Subcategory1
        {
            get { return subcategory1; }
            set
            {
                if (!subcategory1.Equals(value))
                {
                    subcategory1 = value;
                    HasChanges = true;
                }
            }
        }
        public static long Subcategory2
        {
            get { return subcategory2; }
            set
            {
                if (!subcategory2.Equals(value))
                {
                    subcategory2 = value;
                    HasChanges = true;
                }
            }
        }
        public static long Subcategory3
        {
            get { return subcategory3; }
            set
            {
                if (!subcategory3.Equals(value))
                {
                    subcategory3 = value;
                    HasChanges = true;
                }
            }
        }
        public static long Parcels
        {
            get { return parcels; }
            set
            {
                if (!parcels.Equals(value))
                {
                    parcels = value;
                    HasChanges = true;
                }
            }
        }
        public static string Date
        {
            get { return date; }
            set
            {
                if (!date.Equals(value))
                {
                    date = value;
                    HasChanges = true;
                }
            }
        }
        public static string Description
        {
            get { return description; }
            set
            {
                if (!description.Equals(value))
                {
                    description = value;
                    HasChanges = true;
                }
            }
        }
        public static string Observation
        {
            get { return observation; }
            set
            {
                if (!observation.Equals(value))
                {
                    observation = value;
                    HasChanges = true;
                }
            }
        }
        public static decimal DebtValue
        {
            get { return debtValue; }
            set
            {
                if (!debtValue.Equals(value))
                {
                    debtValue = value;
                    HasChanges = true;
                }
            }
        }
        public static decimal Balance
        {
            get { return balance; }
            set
            {
                if (!balance.Equals(value))
                {
                    balance = value;
                    HasChanges = true;
                }
            }
        }
        private static List<decimal> GetParcels(bool mode = true)
        {
            List<decimal> parcels = new List<decimal>();
            string xPm = (Math.Abs(DebtValue) / Parcels).ToString();
            string cultDecSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            int decSeparatorIndex = xPm.IndexOf(cultDecSeparator);
            if (!decSeparatorIndex.Equals(-1))
            {
                if (decSeparatorIndex.Equals(xPm.Length - 2)) xPm += "0";
                else { xPm = xPm.Substring(0, decSeparatorIndex + 2); }
            }
            decimal xPn = decimal.Parse(xPm);
            decimal roundDif = Math.Abs(DebtValue) - (xPn * Parcels);
            decimal xP1 = xPn + roundDif;
            for (int i = 1; i < Parcels + 1; i++)
            {
                if (mode)
                {
                    if (i.Equals(1)) parcels.Add(xP1);
                    else parcels.Add(xPn);
                }
                else
                {
                    if (i.Equals(Parcels)) parcels.Add(xP1);
                    else parcels.Add(xPn);
                }
            }
            return parcels;
        }
        public static void CheckSubcategory(string subCategory1, string subCategory2, string subCategory3)
        {
            SQLiteConnection sqlConn;
            SQLiteCommand sqlCmd;
            if (subcategory1 < 1)
            {
                if (subCategory1.Equals("(SELECIONE A CATEGORIA)") ||
                    string.IsNullOrWhiteSpace(subCategory1))
                {
                    subcategory1 = 0;
                    subcategory2 = 0;
                    subcategory3 = 0;
                    return;
                }
                else
                {
                    sqlConn = DataBase.DataBaseConnection();
                    sqlCmd = sqlConn.CreateCommand();
                    sqlCmd.CommandText = Properties.Resources.sqlNewDebtSubcategory;
                    sqlCmd.Parameters.AddWithValue("@Table", "DebtSubcategory1");
                    sqlCmd.Parameters.AddWithValue("@Parent", Category);
                    sqlCmd.Parameters.AddWithValue("@Name", subCategory1);
                    sqlCmd.ExecuteNonQuery();
                    sqlConn.Close();
                    DataBase.Types.DebtSubcategory1 = DataBase.Populate(Properties.Resources.sqlDebtSubcategory1);
                    subcategory1 = DataBase.Types.DebtSubcategory1.AsEnumerable()
                        .OrderByDescending(row => row.Field<long>("Id")).Take(1)
                        .CopyToDataTable().Rows[0].Field<long>("Id");
                }
            }
            if (subcategory2 < 1)
            {
                if (subCategory2.Equals("(SELECIONE A SUBCATEGORIA 1)") ||
                    string.IsNullOrWhiteSpace(subCategory2))
                {
                    subcategory2 = 0;
                    subcategory3 = 0;
                    return;
                }
                else
                {
                    sqlConn = DataBase.DataBaseConnection();
                    sqlCmd = sqlConn.CreateCommand();
                    sqlCmd.CommandText = Properties.Resources.sqlNewDebtSubcategory;
                    sqlCmd.Parameters.AddWithValue("@Table", "DebtSubcategory2");
                    sqlCmd.Parameters.AddWithValue("@Parent", Subcategory1);
                    sqlCmd.Parameters.AddWithValue("@Name", subCategory2);
                    sqlCmd.ExecuteNonQuery();
                    sqlConn.Close();
                    DataBase.Types.DebtSubcategory2 = DataBase.Populate(Properties.Resources.sqlDebtSubcategory2);
                    subcategory2 = DataBase.Types.DebtSubcategory2.AsEnumerable()
                        .OrderByDescending(row => row.Field<long>("Id")).Take(1)
                        .CopyToDataTable().Rows[0].Field<long>("Id");
                }
            }
            else
            {
                if (subcategory3 < 1)
                {
                    if (subCategory3.Equals("(SELECIONE A SUBCATEGORIA 2)") ||
                        string.IsNullOrWhiteSpace(subCategory3))
                    {
                        subcategory3 = 0;
                        return;
                    }
                    else
                    {
                        sqlConn = DataBase.DataBaseConnection();
                        sqlCmd = sqlConn.CreateCommand();
                        sqlCmd.CommandText = Properties.Resources.sqlNewDebtSubcategory;
                        sqlCmd.Parameters.AddWithValue("@Table", "DebtSubcategory3");
                        sqlCmd.Parameters.AddWithValue("@Parent", Subcategory2);
                        sqlCmd.Parameters.AddWithValue("@Name", subCategory3);
                        sqlCmd.ExecuteNonQuery();
                        sqlConn.Close();
                        DataBase.Types.DebtSubcategory3 = DataBase.Populate(Properties.Resources.sqlDebtSubcategory3);
                        subcategory3 = DataBase.Types.DebtSubcategory3.AsEnumerable()
                            .OrderByDescending(row => row.Field<long>("Id")).Take(1)
                            .CopyToDataTable().Rows[0].Field<long>("Id");
                    }
                }
            }
        }
        public static void Clear()
        {
            user = -1;
            person = -1;
            debtClass = -1;
            opperation = -1;
            account = -1;
            card = -1;
            category = -1;
            subcategory1 = -1;
            date = string.Empty;
            debtValue = 0;
            parcels = 1;
            balance = 0;
            description = string.Empty;
            observation = string.Empty;
            HasChanges = false;
        }
        public static void Credit(List<decimal> parcelList = null)
        {
            if (parcelList == null) parcelList = GetParcels();
            long dueDay = DataBase.Tables.Cards.AsEnumerable()
                .Where(row => row.Field<long>("Id").Equals(Card))
                .CopyToDataTable().Rows[0].Field<long>("DueDay");
            long closingDay = DataBase.Tables.Cards.AsEnumerable()
                .Where(row => row.Field<long>("Id").Equals(Card))
                .CopyToDataTable().Rows[0].Field<long>("ClosingDay");
            DateTime refDate = DateTime.Parse(Date);
            if (DateTime.Parse(closingDay + "/" + refDate.ToString("MM/yyyy")) <= refDate) refDate = refDate.AddMonths(1);
            DataTable billData = null;
            for (int n = 0; n < Parcels; n++)
            {
                decimal xPn = parcelList[n];
                string dueDate = refDate.AddMonths(n).AddDays(dueDay - refDate.Day).ToString("yyyy-MM-dd");
                string billDescription = refDate.AddMonths(n).ToString("MMMM yyyy").ToUpper();
                billData = null;
                try
                {
                    billData = DataBase.Tables.CreditBills.AsEnumerable()
                        .Where(row => row.Field<long>("Card").Equals(Card) &&
                                row.Field<string>("BillDescription").Equals(billDescription))
                        .CopyToDataTable();
                }
                catch { }
                long creditBill = 0;
                if (billData != null)
                {
                    for (int i = 0; i < billData.Rows.Count; i++)
                    {
                        if (billData.Rows[i].Field<long>("Status").Equals(1))
                        {
                            creditBill = billData.Rows[i].Field<long>("Id");
                            break;
                        }
                    }
                }
                if (creditBill.Equals(0))
                {
                    try
                    {
                        var sqlConn = DataBase.DataBaseConnection();
                        var sqlCmd = sqlConn.CreateCommand();
                        sqlCmd.CommandText = Properties.Resources.sqlNewCreditBill;
                        sqlCmd.Parameters.AddWithValue("@Account", Account);
                        sqlCmd.Parameters.AddWithValue("@Card", Card);
                        sqlCmd.Parameters.AddWithValue("@BillDescription", billDescription);
                        sqlCmd.Parameters.AddWithValue("@BillValue", xPn);
                        sqlCmd.Parameters.AddWithValue("@DueDate", dueDate);
                        sqlCmd.ExecuteNonQuery();
                        sqlConn.Close();
                        DataBase.Tables.CreditBills = DataBase.Populate(Properties.Resources.sqlCreditBills);
                        creditBill = DataBase.Tables.CreditBills.AsEnumerable()
                            .Where(row => row.Field<long>("Card").Equals(Card) &&
                                    row.Field<string>("BillDescription").Equals(billDescription) &&
                                    row.Field<long>("Status").Equals(1))
                            .CopyToDataTable().Rows[0].Field<long>("Id");
                    }
                    catch (Exception exErr)
                    {
                        MessageBox.Show("Erro ao cadastrar a fatura " + billDescription + ".\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Globals.IsError = true;
                        goto ErrHandler;
                    }
                }
                else
                {
                    try
                    {
                        var sqlConn = DataBase.DataBaseConnection();
                        decimal billValue = billData.Rows[0].Field<decimal>("BillValue");
                        billValue += xPn;
                        var sqlCmd = sqlConn.CreateCommand();
                        sqlCmd.CommandText = Properties.Resources.sqlUpdateBillValue;
                        sqlCmd.Parameters.AddWithValue("@BillValue", billValue);
                        sqlCmd.Parameters.AddWithValue("@Id", creditBill);
                        sqlCmd.ExecuteNonQuery();
                        sqlConn.Close();
                    }
                    catch (Exception exErr)
                    {
                        MessageBox.Show("Erro ao atualizar a fatura " + billDescription + ".\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Globals.IsError = true;
                        goto ErrHandler;
                    }
                    DataBase.Tables.CreditBills = DataBase.Populate(Properties.Resources.sqlCreditBills);
                }
                try
                {
                    var sqlConn = DataBase.DataBaseConnection();
                    var sqlCmd = sqlConn.CreateCommand();
                    sqlCmd.CommandText = Properties.Resources.sqlNewCreditFlow;
                    sqlCmd.Parameters.AddWithValue("@Bill", creditBill);
                    sqlCmd.Parameters.AddWithValue("@Debt", CurrentId);
                    sqlCmd.Parameters.AddWithValue("@Parcel", n + 1);
                    sqlCmd.Parameters.AddWithValue("@Value", xPn);
                    sqlCmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception exErr)
                {
                    MessageBox.Show("Erro ao cadastrar a " + (n + 1) + "ª parcela do débito." + "\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Globals.IsError = true;
                    goto ErrHandler;
                }
            }
        ErrHandler:
            DataBase.Tables.CreditBills = DataBase.Populate(Properties.Resources.sqlCreditBills);
            DataBase.Tables.CreditFlow = DataBase.Populate(Properties.Resources.sqlCreditFlow);
        }
        public static void Insert()
        {
            if (DebtClass.Equals(2)) DebtValue = -DebtValue;
            else DebtValue = Math.Abs(DebtValue);
            try
            {
                Balance = DataBase.Tables.CashFlow.AsEnumerable()
                   .Where(row => row.Field<long>("Account").Equals(Account))
                   .OrderByDescending(row => row.Field<long>("Id"))
                   .Take(1).CopyToDataTable().Rows[0].Field<decimal>("Balance");
            }
            catch { }
            if (!Opperation.Equals(4)) Balance += DebtValue;
            try
            {
                var sqlConn = DataBase.DataBaseConnection();
                var sqlCmd = sqlConn.CreateCommand();
                sqlCmd.CommandText = Properties.Resources.sqlNewDebt;
                sqlCmd.Parameters.AddWithValue("@User", User);
                sqlCmd.Parameters.AddWithValue("@Person", Person);
                sqlCmd.Parameters.AddWithValue("@Class", DebtClass);
                sqlCmd.Parameters.AddWithValue("@Type", DebtType);
                sqlCmd.Parameters.AddWithValue("@Opperation", Opperation);
                sqlCmd.Parameters.AddWithValue("@Account", Account);
                sqlCmd.Parameters.AddWithValue("@Card", Card);
                sqlCmd.Parameters.AddWithValue("@Category", Category);
                sqlCmd.Parameters.AddWithValue("@Subcategory1", Subcategory1);
                sqlCmd.Parameters.AddWithValue("@Subcategory2", Subcategory2);
                sqlCmd.Parameters.AddWithValue("@Subcategory3", Subcategory3);
                sqlCmd.Parameters.AddWithValue("@Date", Date);
                sqlCmd.Parameters.AddWithValue("@Value", DebtValue);
                sqlCmd.Parameters.AddWithValue("@Parcels", Parcels);
                sqlCmd.Parameters.AddWithValue("@Balance", Balance);
                sqlCmd.Parameters.AddWithValue("@Description", Description);
                sqlCmd.Parameters.AddWithValue("@Observation", Observation);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                DataBase.Tables.CashFlow = DataBase.Populate(Properties.Resources.sqlCashFlow);
            }
            catch (Exception exErr)
            {
                MessageBox.Show("Erro ao cadastrar o débito.\n\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globals.IsError = true;
                return;
            }
            CurrentId = DataBase.Populate(Properties.Resources.sqlCurrentId).Rows[0].Field<long>("Id");
        }
        public static void PayCreditBill(long status)
        {
            try
            {
                var sqlConn = DataBase.DataBaseConnection();
                var sqlCmd = sqlConn.CreateCommand();
                sqlCmd.CommandText = Properties.Resources.sqlPayCreditBill;
                sqlCmd.Parameters.AddWithValue("@Debt", CurrentId);
                sqlCmd.Parameters.AddWithValue("@Date", Date);
                sqlCmd.Parameters.AddWithValue("@Value", Math.Abs(DebtValue));
                sqlCmd.Parameters.AddWithValue("@Status", status);
                sqlCmd.Parameters.AddWithValue("@Id", CreditBillPayment.Bill);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                DataBase.Tables.CreditBills = DataBase.Populate(Properties.Resources.sqlCreditBills);
            }
            catch (Exception exErr)
            {
                MessageBox.Show("Erro ao cadastrar o débito.\n\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globals.IsError = true;
                return;
            }
        }
    }
}
