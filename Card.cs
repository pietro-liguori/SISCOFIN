using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    public class Card
    {
        /// <summary>
        /// 
        /// </summary>
        private static long account = -1;
        /// <summary>
        /// 
        /// </summary>
        private static long type = -1;
        /// <summary>
        /// 
        /// </summary>
        private static long flag = -1;
        /// <summary>
        /// 
        /// </summary>
        private static long cvv = -1;
        /// <summary>
        /// 
        /// </summary>
        private static long status = 3;
        /// <summary>
        /// 
        /// </summary>
        private static long closingDay = -1;
        /// <summary>
        /// 
        /// </summary>
        private static long dueDay = -1;
        /// <summary>
        /// 
        /// </summary>
        private static string number = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string feeUnit = "M";
        /// <summary>
        /// 
        /// </summary>
        private static string expiration = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static decimal creditLimit = 0;
        /// <summary>
        /// 
        /// </summary>
        private static decimal fee = 0;
        /// <summary>
        /// 
        /// </summary>
        public static bool HasChanges = false;
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        public static long Type
        {
            get { return type; }
            set
            {
                if (!type.Equals(value))
                {
                    type = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static long Flag
        {
            get { return flag; }
            set
            {
                if (!flag.Equals(value))
                {
                    flag = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static long CVV
        {
            get { return cvv; }
            set
            {
                if (!cvv.Equals(value))
                {
                    cvv = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static long Status
        {
            get { return status; }
            set
            {
                if (!status.Equals(value))
                {
                    status = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static long ClosingDay
        {
            get { return closingDay; }
            set
            {
                if (!closingDay.Equals(value))
                {
                    closingDay = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static long DueDay
        {
            get { return dueDay; }
            set
            {
                if (!dueDay.Equals(value))
                {
                    dueDay = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string Number
        {
            get { return number; }
            set
            {
                if (!number.Equals(value))
                {
                    number = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string FeeUnit
        {
            get { return feeUnit; }
            set
            {
                if (!feeUnit.Equals(value))
                {
                    feeUnit = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string Expiration
        {
            get { return expiration; }
            set
            {
                if (!expiration.Equals(value))
                {
                    expiration = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static decimal CreditLimit
        {
            get { return creditLimit; }
            set
            {
                if (!creditLimit.Equals(value))
                {
                    creditLimit = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static decimal Fee
        {
            get { return fee; }
            set
            {
                if (!fee.Equals(value))
                {
                    fee = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Clear()
        {
            account = -1;
            type = -1;
            flag = -1;
            cvv = -1;
            status = -1;
            closingDay = -1;
            dueDay = -1;
            number = string.Empty;
            feeUnit = "M";
            expiration = string.Empty;
            creditLimit = 0;
            fee = 0;
            HasChanges = false;
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Insert()
        {
            try
            {
                SQLiteConnection sqlConn;
                SQLiteCommand sqlCmd;
                sqlConn = DataBase.DataBaseConnection();
                sqlCmd = sqlConn.CreateCommand();
                sqlCmd.CommandText = Properties.Resources.sqlNewCard;
                sqlCmd.Parameters.AddWithValue("@Account", Account);
                sqlCmd.Parameters.AddWithValue("@Type", Type);
                sqlCmd.Parameters.AddWithValue("@Number", Number);
                sqlCmd.Parameters.AddWithValue("@CVV", CVV);
                sqlCmd.Parameters.AddWithValue("@Flag", Flag);
                sqlCmd.Parameters.AddWithValue("@Expiration", Expiration);
                sqlCmd.Parameters.AddWithValue("@ClosingDay", ClosingDay);
                sqlCmd.Parameters.AddWithValue("@DueDay", DueDay);
                sqlCmd.Parameters.AddWithValue("@Limit", CreditLimit);
                sqlCmd.Parameters.AddWithValue("@Fee", Fee);
                sqlCmd.Parameters.AddWithValue("@FeeUnit", FeeUnit);
                sqlCmd.Parameters.AddWithValue("@Status", Status);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                DataBase.Tables.Cards = DataBase.Populate(Properties.Resources.sqlCards);
                Globals.SelectedCard = DataBase.Tables.Cards.AsEnumerable()
                    .OrderByDescending(row => row.Field<long>("Id")).Take(1)
                    .CopyToDataTable().Rows[0].Field<long>("Id");
            }
            catch (Exception exErr)
            {
                MessageBox.Show("Erro ao cadastrar o novo cartão.\n\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globals.IsError = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Update()
        {
            try
            {
                SQLiteConnection sqlConn;
                SQLiteCommand sqlCmd;
                sqlConn = DataBase.DataBaseConnection();
                sqlCmd = sqlConn.CreateCommand();
                sqlCmd.CommandText = Properties.Resources.sqlUpdateCard;
                sqlCmd.Parameters.AddWithValue("@Id", Globals.SelectedCard);
                sqlCmd.Parameters.AddWithValue("@Account", Account);
                sqlCmd.Parameters.AddWithValue("@Type", Type);
                sqlCmd.Parameters.AddWithValue("@Number", Number);
                sqlCmd.Parameters.AddWithValue("@CVV", CVV);
                sqlCmd.Parameters.AddWithValue("@Flag", Flag);
                sqlCmd.Parameters.AddWithValue("@Expiration", Expiration);
                sqlCmd.Parameters.AddWithValue("@ClosingDay", ClosingDay);
                sqlCmd.Parameters.AddWithValue("@DueDay", DueDay);
                sqlCmd.Parameters.AddWithValue("@Limit", CreditLimit);
                sqlCmd.Parameters.AddWithValue("@Fee", Fee);
                sqlCmd.Parameters.AddWithValue("@FeeUnit", FeeUnit);
                sqlCmd.Parameters.AddWithValue("@Status", Status);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                DataBase.Tables.Cards = DataBase.Populate(Properties.Resources.sqlCards);
            }
            catch (Exception exErr)
            {
                MessageBox.Show("Erro ao atualizar os dados do cartão.\n\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globals.IsError = true;
            }
        }
    }
}
