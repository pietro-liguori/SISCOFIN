using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    /// <summary>
    /// Classe utilizada para armazenar variáveis estáticas globais.
    /// </summary>
    public class Globals
    {
        /// <summary>
        /// 
        /// </summary>
        public static bool IsBackspace = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool IsDelete = false;
        /// <summary>
        /// 
        /// </summary>
        [Bindable(true)]
        public static bool IsRunning = false;
        /// <summary>
        /// Versão atual do aplicativo.
        /// </summary>
        public static string Version = "1.0";
        /// <summary>
        /// Nível de acesso do usuário ativo.
        /// </summary>
        public static int Access = 0; //0=Usuário - 1=Administrador
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static string DataBasePath(string dbName)
        {
            string dbPath = Environment.CurrentDirectory + @"\" + dbName + @".db";
            return dbPath;
        }
        /// <summary>
        /// Variável global para rastreamento de ocorrência de erros.
        /// </summary>
        public static bool IsError = false;
        /// <summary>
        /// Variável global para rastreamento do item selecionado em um objeto.
        /// </summary>
        public static int SelectedIndex = -1;
        /// <summary>
        /// Variável global para rastreamento da conta selecionada.
        /// </summary>
        public static long SelectedAccount = -1;
        /// <summary>
        /// Variável global para rastreamento do cartão selecionado.
        /// </summary>
        public static long SelectedCard = -1;
        /// <summary>
        /// Variável global para rastreamento da pessoa selecionada.
        /// </summary>
        public static long SelectedPerson = -1;
        /// <summary>
        /// Variável global para rastreamento do usuário selecionado.
        /// </summary>
        public static long SelectedUser = -1;
    }
}
