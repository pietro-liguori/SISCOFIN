using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    public class Phone
    {
        /// <summary>
        /// 
        /// </summary>
        private static long person = -1;
        /// <summary>
        /// 
        /// </summary>
        private static string countryCode = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string ddd = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string number = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string type = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public static bool HasChanges = false;
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        public static string CountryCode
        {
            get { return countryCode; }
            set
            {
                if (!countryCode.Equals(value))
                {
                    countryCode = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string DDD
        {
            get { return ddd; }
            set
            {
                if (!ddd.Equals(value))
                {
                    ddd = value;
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
        public static string Type
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
        public static void Clear()
        {
            person = -1;
            countryCode = string.Empty;
            ddd = string.Empty;
            number = string.Empty;
            type = string.Empty;
            HasChanges = false;
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Insert()
        {
            SQLiteConnection sqlConn;
            SQLiteCommand sqlCmd;
            sqlConn = DataBase.DataBaseConnection();
            sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandText = Properties.Resources.sqlNewPhone;
            sqlCmd.Parameters.AddWithValue("@Person", Person);
            sqlCmd.Parameters.AddWithValue("@CountryCode", CountryCode);
            sqlCmd.Parameters.AddWithValue("@DDD", DDD);
            sqlCmd.Parameters.AddWithValue("@Phone", Number);
            sqlCmd.Parameters.AddWithValue("@Type", Type);
            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();
            DataBase.Tables.PhoneBook = DataBase.Populate(Properties.Resources.sqlPhoneBook);
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Update(long id)
        {
            try
            {
                SQLiteConnection sqlConn;
                SQLiteCommand sqlCmd;
                sqlConn = DataBase.DataBaseConnection();
                sqlCmd = sqlConn.CreateCommand();
                sqlCmd.CommandText = Properties.Resources.sqlUpdatePhone;
                sqlCmd.Parameters.AddWithValue("@Id", id);
                sqlCmd.Parameters.AddWithValue("@Person", Person);
                sqlCmd.Parameters.AddWithValue("@CountryCode", CountryCode);
                sqlCmd.Parameters.AddWithValue("@DDD", DDD);
                sqlCmd.Parameters.AddWithValue("@Number", Number);
                sqlCmd.Parameters.AddWithValue("@Type", Type);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                DataBase.Tables.PhoneBook = DataBase.Populate(Properties.Resources.sqlPhoneBook);
            }
            catch (Exception exErr)
            {
                MessageBox.Show("Erro ao atualizar o telefone.\n\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globals.IsError = true;
            }
        }
    }
}
