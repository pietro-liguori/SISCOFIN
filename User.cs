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
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        private static long person = -1;
        /// <summary>
        /// 
        /// </summary>
        private static long access = 1;
        /// <summary>
        /// 
        /// </summary>
        private static long status = 3;
        /// <summary>
        /// 
        /// </summary>
        private static string city = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string country = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string birth = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string name = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string username = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string sex = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string estate = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string password = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string maritalStatus = string.Empty;
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
        public static long Access
        {
            get { return access; }
            set
            {
                if (!access.Equals(value))
                {
                    access = value;
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
        public static string Birth
        {
            get { return birth; }
            set
            {
                if (!birth.Equals(value))
                {
                    birth = value;
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
        public static string Username
        {
            get { return username; }
            set
            {
                if (!username.Equals(value))
                {
                    username = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string Sex
        {
            get { return sex; }
            set
            {
                if (!sex.Equals(value))
                {
                    sex = value;
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
        public static string Password
        {
            get { return password; }
            set
            {
                if (!password.Equals(value))
                {
                    password = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string MaritalStatus
        {
            get { return maritalStatus; }
            set
            {
                if (!maritalStatus.Equals(value))
                {
                    maritalStatus = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Clear()
        {
            Username = string.Empty;
            Password = string.Empty;
            Person = -1;
            Country = string.Empty;
            City = string.Empty;
            Estate = string.Empty;
            MaritalStatus = string.Empty;
            Sex = string.Empty;
            Birth = string.Empty;
            Access = 1;
            Status = 3;
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
            sqlCmd.CommandText = Properties.Resources.sqlNewUser;
            sqlCmd.Parameters.AddWithValue("@Name", Name);
            sqlCmd.Parameters.AddWithValue("@Username", Username);
            sqlCmd.Parameters.AddWithValue("@Type", SISCOFIN_v1.Person.Type);
            sqlCmd.Parameters.AddWithValue("@Person", Person);
            sqlCmd.Parameters.AddWithValue("@Birth", Birth);
            sqlCmd.Parameters.AddWithValue("@Sex", Sex);
            sqlCmd.Parameters.AddWithValue("@City", City);
            sqlCmd.Parameters.AddWithValue("@Country", Country);
            sqlCmd.Parameters.AddWithValue("@Estate", Estate);
            sqlCmd.Parameters.AddWithValue("@MaritalStatus", MaritalStatus);
            sqlCmd.Parameters.AddWithValue("@Password", Password);
            sqlCmd.Parameters.AddWithValue("@Status", Status);
            sqlCmd.Parameters.AddWithValue("@Access", Access);
            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();
            DataBase.Tables.Users = DataBase.Populate(Properties.Resources.sqlUsers);
            Globals.SelectedUser = DataBase.Tables.Users.AsEnumerable()
                .OrderByDescending(row => row.Field<long>("Id")).Take(1)
                .CopyToDataTable().Rows[0].Field<long>("Id");
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
                sqlCmd.CommandText = Properties.Resources.sqlUpdateUser;
                sqlCmd.Parameters.AddWithValue("@Id", Globals.SelectedUser);
                sqlCmd.Parameters.AddWithValue("@Username", Username);
                sqlCmd.Parameters.AddWithValue("@Birth", Birth);
                sqlCmd.Parameters.AddWithValue("@Sex", Sex);
                sqlCmd.Parameters.AddWithValue("@City", City);
                sqlCmd.Parameters.AddWithValue("@Country", Country);
                sqlCmd.Parameters.AddWithValue("@Estate", Estate);
                sqlCmd.Parameters.AddWithValue("@MaritalStatus", MaritalStatus);
                sqlCmd.Parameters.AddWithValue("@Password", Password);
                sqlCmd.Parameters.AddWithValue("@Status", Status);
                sqlCmd.Parameters.AddWithValue("@Access", Access);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                DataBase.Tables.Users = DataBase.Populate(Properties.Resources.sqlUsers);
            }
            catch (Exception exErr)
            {
                MessageBox.Show("Erro ao atualizar os dados do usuário.\n\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globals.IsError = true;
            }
        }
    }
}
