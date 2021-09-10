using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppWindow());
        }

        public static Dictionary<string, ScriptOptions> ScriptClass = new Dictionary<string, ScriptOptions>
        {
            {"Account", ScriptOptions.Default.WithReferences(typeof(Account).Assembly) },
            {"AccountType", ScriptOptions.Default.WithReferences(typeof(AccountType).Assembly) },
            {"Address", ScriptOptions.Default.WithReferences(typeof(Address).Assembly) },
            {"Card", ScriptOptions.Default.WithReferences(typeof(Card).Assembly) },
            {"CardType", ScriptOptions.Default.WithReferences(typeof(CardType).Assembly) },
            {"Debt", ScriptOptions.Default.WithReferences(typeof(Debt).Assembly) },
            {"DebtCategorie", ScriptOptions.Default.WithReferences(typeof(DebtCategorie).Assembly) },
            {"DebtType", ScriptOptions.Default.WithReferences(typeof(DebtType).Assembly) },
            {"Email", ScriptOptions.Default.WithReferences(typeof(Email).Assembly) },
            {"Globals", ScriptOptions.Default.WithReferences(typeof(Globals).Assembly) },
            {"OpperationType", ScriptOptions.Default.WithReferences(typeof(OpperationType).Assembly) },
            {"Person", ScriptOptions.Default.WithReferences(typeof(Person).Assembly) },
            {"Phone", ScriptOptions.Default.WithReferences(typeof(Phone).Assembly) },
            {"User", ScriptOptions.Default.WithReferences(typeof(User).Assembly) }
        };
    }

    public enum DataSource : long
    {
        Custom = -1,
        FullTable = 0,
        NameAndID = 1,
        UserAccounts = 2,
        CardsShort = 3,
        AccountCardsShort = 4,
        PeopleExceptUser = 5,
        OnlyBanks = 6,
        EnableSelection = 7,
        AccountOpperations = 8,
        ParentSubcategories = 9,
        UserPersons = 10,
        NameAndIDForUsers = 11,
        EnabledStatusFem = 12,
        EnabledStatusMasc = 13
    }

}
