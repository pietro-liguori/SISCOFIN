using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    /// <summary>
    /// 
    /// </summary>
    public class Person
    {
        /// <summary>
        /// 
        /// </summary>
        private static long branch = -1;
        /// <summary>
        /// 
        /// </summary>
        private static long status = 3;
        /// <summary>
        /// 
        /// </summary>
        private static string name = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string branchText = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string document = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string type = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static bool isUser = false;
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// 
        /// </summary>
        public static bool HasChanges = false;
        /// <summary>
        /// 
        /// </summary>
        public static long Branch
        {
            get { return branch; }
            set
            {
                if (!branch.Equals(value))
                {
                    branch = value;
                    User.HasChanges = HasChanges = true;
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
        public static string BranchText
        {
            get { return branchText; }
            set
            {
                if (!branchText.Equals(value))
                {
                    branchText = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string Document
        {
            get { return document; }
            set
            {
                if (!document.Equals(value))
                {
                    document = value;
                    User.HasChanges = HasChanges = true;
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
                    User.HasChanges = HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool IsUser
        {
            get { return isUser; }
            set
            {
                if (!isUser.Equals(value))
                {
                    isUser = value;
                    HasChanges = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool CheckBranch()
        {
            if (Branch.Equals(-1))
            {
                DialogResult dialogResult = MessageBox.Show("Deseja cadastrar o ramo: \"" + BranchText + "\" no sistema?",
                    "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult.Equals(DialogResult.Yes))
                {
                    SQLiteConnection sqlConn = DataBase.DataBaseConnection();
                    SQLiteCommand sqlCmd = sqlConn.CreateCommand();
                    sqlCmd.CommandText = Properties.Resources.sqlNewBranch;
                    sqlCmd.Parameters.AddWithValue("@Name", BranchText);
                    sqlCmd.ExecuteNonQuery();
                    sqlConn.Close();
                    DataBase.Types.Branches = DataBase.Populate(Properties.Resources.sqlBranches);
                    Branch = DataBase.Types.Branches.AsEnumerable()
                        .OrderByDescending(row => row.Field<long>("Id")).Take(1)
                        .CopyToDataTable().Rows[0].Field<long>("Id");
                    return true;
                }
                else return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Clear()
        {
            name = string.Empty;
            branch = -1;
            branchText = string.Empty;
            document = string.Empty;
            type = string.Empty;
            isUser = false;
            status = 3;
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
            sqlCmd.CommandText = Properties.Resources.sqlNewPerson;
            sqlCmd.Parameters.AddWithValue("@Name", Name);
            sqlCmd.Parameters.AddWithValue("@Branch", Branch);
            sqlCmd.Parameters.AddWithValue("@Document", Document);
            sqlCmd.Parameters.AddWithValue("@IsUser", IsUser);
            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();
            DataBase.Tables.People = DataBase.Populate(Properties.Resources.sqlPeople);
            Globals.SelectedPerson = DataBase.Tables.People.AsEnumerable()
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
                sqlCmd.CommandText = Properties.Resources.sqlUpdatePerson;
                sqlCmd.Parameters.AddWithValue("@Id", Globals.SelectedPerson);
                sqlCmd.Parameters.AddWithValue("@Name", Name);
                sqlCmd.Parameters.AddWithValue("@Branch", Branch);
                sqlCmd.Parameters.AddWithValue("@Document", Document);
                sqlCmd.Parameters.AddWithValue("@IsUser", IsUser);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                DataBase.Tables.People = DataBase.Populate(Properties.Resources.sqlPeople);
            }
            catch (Exception exErr)
            {
                MessageBox.Show("Erro ao atualizar os dados da pessoa.\n\nErro: " + exErr.Message, "Falha na alteração do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Globals.IsError = true;
            }
        }
    }
}
