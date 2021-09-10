using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    public class Address
    {
        /// <summary>
        /// 
        /// </summary>
        private static long person = -1;
        /// <summary>
        /// 
        /// </summary>
        private static string cep = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string street = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string number = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string complement = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string district = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string city = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string estate = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string country = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static bool mail = false;
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
        public static string CEP
        {
            get { return cep; }
            set
            {
                if (!cep.Equals(value))
                {
                    cep = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string Street
        {
            get { return street; }
            set
            {
                if (!street.Equals(value))
                {
                    street = value;
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
        public static string Complement
        {
            get { return complement; }
            set
            {
                if (!complement.Equals(value))
                {
                    complement = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string District
        {
            get { return district; }
            set
            {
                if (!district.Equals(value))
                {
                    district = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string City
        {
            get { return city; }
            set
            {
                if (!city.Equals(value))
                {
                    city = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string Estate
        {
            get { return estate; }
            set
            {
                if (!estate.Equals(value))
                {
                    estate = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string Country
        {
            get { return country; }
            set
            {
                if (!country.Equals(value))
                {
                    country = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool Mail
        {
            get { return mail; }
            set
            {
                if (!mail.Equals(value))
                {
                    mail = value;
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
            cep = string.Empty;
            street = string.Empty;
            number = string.Empty;
            complement = string.Empty;
            district = string.Empty;
            city = string.Empty;
            estate = string.Empty;
            country = string.Empty;
            mail = false;
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
            sqlCmd.CommandText = Properties.Resources.sqlNewAddress;
            sqlCmd.Parameters.AddWithValue("@Person", Person);
            sqlCmd.Parameters.AddWithValue("@CEP", CEP);
            sqlCmd.Parameters.AddWithValue("@Address", Street);
            sqlCmd.Parameters.AddWithValue("@Number", Number);
            sqlCmd.Parameters.AddWithValue("@Complement", Complement);
            sqlCmd.Parameters.AddWithValue("@District", District);
            sqlCmd.Parameters.AddWithValue("@City", City);
            sqlCmd.Parameters.AddWithValue("@Estate", Estate);
            sqlCmd.Parameters.AddWithValue("@Country", Country);
            sqlCmd.Parameters.AddWithValue("@Mail", Mail);
            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();
            DataBase.Tables.AddressBook = DataBase.Populate(Properties.Resources.sqlAddressBook);
            if (Mail)
            {
                // criar a rotina de mudança de Mail de todos endereços da mesma pessoa (Trigger no BD?)
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Update(long Id)
        {
            try
            {
                SQLiteConnection sqlConn;
                SQLiteCommand sqlCmd;
                sqlConn = DataBase.DataBaseConnection();
                sqlCmd = sqlConn.CreateCommand();
                sqlCmd.CommandText = Properties.Resources.sqlUpdateAddress;
                sqlCmd.Parameters.AddWithValue("@Id", Id);
                sqlCmd.Parameters.AddWithValue("@Person", Person);
                sqlCmd.Parameters.AddWithValue("@CEP", CEP);
                sqlCmd.Parameters.AddWithValue("@Address", Street);
                sqlCmd.Parameters.AddWithValue("@Number", Number);
                sqlCmd.Parameters.AddWithValue("@Complement", Complement);
                sqlCmd.Parameters.AddWithValue("@District", District);
                sqlCmd.Parameters.AddWithValue("@City", City);
                sqlCmd.Parameters.AddWithValue("@Estate", Estate);
                sqlCmd.Parameters.AddWithValue("@Country", Country);
                sqlCmd.Parameters.AddWithValue("@Mail", Mail);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                DataBase.Tables.AddressBook = DataBase.Populate(Properties.Resources.sqlAddressBook);
            }
            catch (Exception exErr)
            {
                MessageBox.Show("Erro ao atualizar o endereço.\n\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globals.IsError = true;
            }
        }
    }
}
