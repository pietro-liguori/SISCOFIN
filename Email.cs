using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    public class Email
    {
        /// <summary>
        /// 
        /// </summary>
        public static long person = -1;
        /// <summary>
        /// 
        /// </summary>
        public static string text = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public static bool mail = false;
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
        public static string Text
        {
            get { return text; }
            set
            {
                if (!text.Equals(value))
                {
                    text = value;
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
            text = string.Empty;
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
            sqlCmd.CommandText = Properties.Resources.sqlNewEmail;
            sqlCmd.Parameters.AddWithValue("@Person", Person);
            sqlCmd.Parameters.AddWithValue("@Email", Text);
            sqlCmd.Parameters.AddWithValue("@Mail", Mail);
            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();
            DataBase.Tables.EmailBook = DataBase.Populate(Properties.Resources.sqlEmailBook);
            if (Mail)
            {
                // criar a rotina de mudança de Mail de todos emails da mesma pessoa (Trigger no BD?)
            }
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
                sqlCmd.CommandText = Properties.Resources.sqlUpdateEmail;
                sqlCmd.Parameters.AddWithValue("@Id", id);
                sqlCmd.Parameters.AddWithValue("@Person", Person);
                sqlCmd.Parameters.AddWithValue("@Email", Text);
                sqlCmd.Parameters.AddWithValue("@Mail", Mail);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                DataBase.Tables.EmailBook = DataBase.Populate(Properties.Resources.sqlEmailBook);
            }
            catch (Exception exErr)
            {
                MessageBox.Show("Erro ao atualizar o endereço.\n\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globals.IsError = true;
            }
        }
    }
}
