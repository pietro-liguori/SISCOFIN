using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Security.Policy;
using System.Windows.Forms;
using System.Globalization;

namespace SISCOFIN_v1
{
    class DataBase
    {
        private static SQLiteConnection DataConn;
        public static DataTable ParamSource;
        private static SQLiteCommand SQL;
        public static SQLiteConnection DataBaseConnection()
        {
            DataConn = new SQLiteConnection(@"DataSource=" + Globals.DataBasePath("Novo Teste"));
            DataConn.Open();
            return DataConn;
        }
        public static DataTable Populate(string sqlCommand)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SQLiteConnection dataConn = DataBaseConnection();
                SQLiteCommand sqlCmd = dataConn.CreateCommand();
                sqlCmd.CommandText = sqlCommand;
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sqlCmd.CommandText, dataConn);
                dataAdapter.Fill(dataTable);
                dataConn.Close();
                return dataTable;
            }
            catch  { return null; }
        }
        public static SQLiteCommand GetCommand(string commandType, DataTable param, Dictionary<string,string> alias = null)
        {
            string txt = string.Empty;
            string whr = " where ";
            string columnName;
            int columnCount = param.Columns.Count;
            SQLiteCommand sqlCommand = new SQLiteCommand();
            SQLiteParameter[] sqlParameters = null;
            switch (commandType.ToLower())
            {
                case "select":
                    txt = @"select ";
                    if (param.Columns.Count > 0)
                    {
                        for (int i = 0; i < columnCount; i++)
                        {
                            columnName = param.Columns[i].ColumnName;
                            txt += columnName + " ";
                            if (!(alias is null) && alias.TryGetValue(columnName, out string at)) txt += "as " + alias[columnName];
                            if (i < columnCount - 1) txt += ", ";
                            if (!(param.Columns[i].Table.Rows[0][columnName] is null))
                            {
                                if (!whr.Equals(" where ")) whr += " AND ";
                                whr += columnName + " = " + "@" + columnName;
                                SQLiteParameter sqlParam = sqlCommand.CreateParameter();
                                sqlParam.ParameterName = columnName;
                                sqlParam.Value = param.Columns[i].Table.Rows[0][columnName];
                                Console.WriteLine(sqlCommand.Parameters[i]);
                                sqlParameters.Append(sqlParam);
                            }
                        }
                        txt += " from " + param.TableName;
                        sqlCommand.Parameters.AddRange(sqlParameters);
                    }
                    else txt += "* from " + param.TableName;
                    break;
            }
            return sqlCommand;
        }
        public static string BuildCommand(DataSource enumValue, string [] args = null)
        {
            if (enumValue.Equals(DataSource.Custom)) return string.Empty;
            DataTable dataSource = Populate("SELECT * FROM DataSources").AsEnumerable()
                .Where(row => ((long)row["EnumValue"]).Equals((long)enumValue)).CopyToDataTable();
            string[] value = dataSource.Rows[0].Field<string>("Value").Split(char.Parse(";"));
            if (value.Length.Equals(1)) return value[0];
            else
            {
                if (args == null) return string.Empty;
                else return string.Format(value[0], args);
            }
        }
        public static string CustomCommand(string column, string table, long id, string[] args = null, string displayMember = "Name", string valueMember = "Id")
        {
            string sqlCommand = string.Format("SELECT {0} FROM {1} WHERE Id = {2}", column, table, id);
            string [] customValue = ((string)Populate(sqlCommand).Rows[0][0]).Split(char.Parse(";"));
            if (customValue[0].StartsWith("[") && customValue[0].EndsWith("]"))
            {
                args = customValue[0].Replace("[", "").Replace("]", "").Split(char.Parse(";"));
                string target = column.Replace("Custom", "");
                sqlCommand = string.Format("SELECT {0}, {1} FROM {2} WHERE ", valueMember, displayMember, target);
                foreach(string arg in args)
                {
                    sqlCommand += string.Format("Id = {0}", arg);
                    if (args.ElementAt(args.Length - 1).Equals(arg)) break;
                    sqlCommand += "OR ";
                }
                return sqlCommand;
            }
            else
            {
                if (!customValue[0].ToUpper().Substring(0, 6).Equals("SELECT")) return string.Empty;
                if (customValue.Length.Equals(1)) return customValue[0];
                else
                {
                    if (args == null) return string.Empty;
                    else return string.Format(customValue[0], args);
                }
            }
        }
        public class Tables
        {
            public static DataTable Accounts = null;
            public static DataTable AddressBook = null;
            public static DataTable Cards = null;
            public static DataTable CashFlow = null;
            public static DataTable CreditBills = null;
            public static DataTable CreditFlow = null;
            public static DataTable Documents = null;
            public static DataTable EmailBook = null;
            public static DataTable Groups = null;
            public static DataTable People = null;
            public static DataTable PhoneBook = null;
            public static DataTable Users = null;
            public static DataTable Banks = null;
        }
        public class Types
        {
            public static DataTable Status = null;
            public static DataTable AccountTypes = null;
            public static DataTable CardTypes = null;
            public static DataTable DebtTypes = null;
            public static DataTable DebtClass = null;
            public static DataTable DocumentTypes = null;
            public static DataTable OpperationTypes = null;
            public static DataTable Branches = null;
            public static DataTable DebtCategory = null;
            public static DataTable DebtSubcategories = null;
            public static DataTable DebtSubcategory1 = null;
            public static DataTable DebtSubcategory2 = null;
            public static DataTable DebtSubcategory3 = null;
            public static DataTable AccountClass = null;
            public static DataTable CardFlags = null;
        }
    }
}
