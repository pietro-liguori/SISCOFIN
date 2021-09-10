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
    public class Account
    {
        /// <summary>
        /// 
        /// </summary>
        private static long accountClass = -1;
        /// <summary>
        /// 
        /// </summary>
        private static long type = -1;
        /// <summary>
        /// 
        /// </summary>
        private static long user = -1;
        /// <summary>
        /// 
        /// </summary>
        private static long status = 3;
        /// <summary>
        /// 
        /// </summary>
        private static long bank = -1;
        /// <summary>
        /// 
        /// </summary>
        private static long grace = 0;
        /// <summary>
        /// 
        /// </summary>
        private static string agency = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string number = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string name = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string graceUnit = "D";
        /// <summary>
        /// 
        /// </summary>
        private static string feeUnit = "M";
        /// <summary>
        /// 
        /// </summary>
        private static decimal balance = 0;
        /// <summary>
        /// 
        /// </summary>
        private static decimal overdraft = 0;
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
        public static long Class
        {
            get { return accountClass; }
            set
            {
                if (!accountClass.Equals(value))
                {
                    accountClass = value;
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
        public static long Bank
        {
            get { return bank; }
            set
            {
                if (!bank.Equals(value))
                {
                    bank = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static long Grace
        {
            get { return grace; }
            set
            {
                if (!grace.Equals(value))
                {
                    grace = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string Agency
        {
            get { return agency; }
            set
            {
                if (!agency.Equals(value))
                {
                    agency = value;
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
        public static string Name
        {
            get { return name; }
            set
            {
                if (!name.Equals(value))
                {
                    name = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string GraceUnit
        {
            get { return graceUnit; }
            set
            {
                if (!graceUnit.Equals(value))
                {
                    graceUnit = value;
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
        /// <summary>
        /// 
        /// </summary>
        public static decimal Overdraft
        {
            get { return overdraft; }
            set
            {
                if (!overdraft.Equals(value))
                {
                    overdraft = value;
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
        public static void ChangeStandardCard()
        {
            try
            {
                SQLiteConnection sqlConn;
                SQLiteCommand sqlCmd;
                sqlConn = DataBase.DataBaseConnection();
                sqlCmd = sqlConn.CreateCommand();
                sqlCmd.CommandText = Properties.Resources.sqlChangeStandardCard;
                sqlCmd.Parameters.AddWithValue("@Id", Globals.SelectedAccount);
                sqlCmd.Parameters.AddWithValue("@StandardCard", Globals.SelectedCard);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                DataBase.Tables.Accounts = DataBase.Populate(Properties.Resources.sqlAccounts);
            }
            catch (Exception exErr)
            {
                MessageBox.Show("Erro ao atualizar os dados da conta.\n\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globals.IsError = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Clear()
        {
            balance = 0;
            accountClass = -1;
            type = -1;
            user = -1;
            status = -1;
            agency = string.Empty;
            bank = -1;
            number = string.Empty;
            name = string.Empty;
            balance = 0;
            overdraft = 0;
            grace = 0;
            graceUnit = "D";
            fee = 0;
            feeUnit = "M";
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
                sqlCmd.CommandText = Properties.Resources.sqlNewAccount;
                sqlCmd.Parameters.AddWithValue("@Name", Name);
                sqlCmd.Parameters.AddWithValue("@Class", Class);
                sqlCmd.Parameters.AddWithValue("@Type", Type);
                sqlCmd.Parameters.AddWithValue("@User", User);
                sqlCmd.Parameters.AddWithValue("@Bank", Bank);
                sqlCmd.Parameters.AddWithValue("@Agency", Agency);
                sqlCmd.Parameters.AddWithValue("@Number", Number);
                sqlCmd.Parameters.AddWithValue("@Overdraft", Overdraft);
                sqlCmd.Parameters.AddWithValue("@Grace", Grace);
                sqlCmd.Parameters.AddWithValue("@GraceUnit", GraceUnit);
                sqlCmd.Parameters.AddWithValue("@Fee", Fee);
                sqlCmd.Parameters.AddWithValue("@FeeUnit", FeeUnit);
                sqlCmd.Parameters.AddWithValue("@Status", 3);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                DataBase.Tables.Accounts = DataBase.Populate(Properties.Resources.sqlAccounts);
                Globals.SelectedAccount = DataBase.Tables.Accounts.AsEnumerable()
                    .OrderByDescending(row => row.Field<long>("Id")).Take(1)
                    .CopyToDataTable().Rows[0].Field<long>("Id");
            }
            catch (Exception exErr)
            {
                MessageBox.Show("Erro ao cadastrar a nova conta.\n\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globals.IsError = true;
                return;
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
                sqlCmd.CommandText = Properties.Resources.sqlUpdateAccount;
                sqlCmd.Parameters.AddWithValue("@Id", Globals.SelectedAccount);
                sqlCmd.Parameters.AddWithValue("@Name", Name);
                sqlCmd.Parameters.AddWithValue("@Class", Class);
                sqlCmd.Parameters.AddWithValue("@Type", Type);
                sqlCmd.Parameters.AddWithValue("@User", User);
                sqlCmd.Parameters.AddWithValue("@Person", Bank);
                sqlCmd.Parameters.AddWithValue("@Agency", Agency);
                sqlCmd.Parameters.AddWithValue("@Number", Number);
                sqlCmd.Parameters.AddWithValue("@Overdraft", Overdraft);
                sqlCmd.Parameters.AddWithValue("@Grace", Grace);
                sqlCmd.Parameters.AddWithValue("@GraceUnit", GraceUnit);
                sqlCmd.Parameters.AddWithValue("@Fee", Fee);
                sqlCmd.Parameters.AddWithValue("@FeeUnit", FeeUnit);
                sqlCmd.Parameters.AddWithValue("@Status", Status);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                DataBase.Tables.Accounts = DataBase.Populate(Properties.Resources.sqlAccounts);
            }
            catch (Exception exErr)
            {
                MessageBox.Show("Erro ao atualizar os dados da conta.\n\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globals.IsError = true;
            }
        }

    }
}
