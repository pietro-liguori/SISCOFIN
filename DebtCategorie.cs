using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISCOFIN_v1
{
    class DebtCategorie
    {
        private static bool enableSelection = false;
        private static long[] debtSubcategories1 = null;
        private static long[] debtSubcategories2 = null;
        private static long[] debtSubcategories3 = null;
        private static string name = string.Empty;

        public static bool Changed { get; set; }
        public static bool EnableSelection
        {
            get { return enableSelection; }
            set
            {
                if (enableSelection.Equals(value)) return;
                enableSelection = value;
                Changed = true;
            }
        }
        public static long[] DebtSubcategories1
        {
            get { return debtSubcategories1; }
            set
            {
                if (debtSubcategories1.Equals(value)) return;
                debtSubcategories1 = value;
                Changed = true;
            }
        }
        public static long[] DebtSubcategories2
        {
            get { return debtSubcategories2; }
            set
            {
                if (debtSubcategories2.Equals(value)) return;
                debtSubcategories2 = value;
                Changed = true;
            }
        }
        public static long[] DebtSubcategories3
        {
            get { return debtSubcategories3; }
            set
            {
                if (debtSubcategories3.Equals(value)) return;
                debtSubcategories3 = value;
                Changed = true;
            }
        }
        public static string Name
        {
            get { return name; }
            set
            {
                if (name.Equals(value)) return;
                name = value;
                Changed = true;
            }
        }
    }
}
