using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SISCOFIN_v1
{
    public class DebtType
    {
        private static bool enableParcels = false;
        private static bool enableSelection = false;
        private static bool enableValue = false;
        private static decimal debtValue = 0;
        private static long maxParcels = 0;
        private static long parcels = 0;
        private static long status = 11;
        private static string description = string.Empty;
        private static string name = string.Empty;
        private static string observation = string.Empty;
        public static bool Changed { get; set; }
        public static bool EnableParcels
        {
            get { return enableParcels; }
            set
            {
                if (enableParcels.Equals(value)) return;
                enableParcels = value;
                Changed = true;
            }
        }
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
        public static bool EnableValue
        {
            get { return enableValue; }
            set
            {
                if (enableValue.Equals(value)) return;
                enableValue = value;
                Changed = true;
            }
        }
        public static decimal DebtValue
        {
            get { return debtValue; }
            set
            {
                if (debtValue.Equals(value)) return;
                debtValue = value;
                Changed = true;
            }
        }
        public static long MaxParcels
        {
            get { return maxParcels; }
            set
            {
                if (maxParcels.Equals(value)) return;
                maxParcels = value;
                Changed = true;
            }
        }
        public static long Parcels
        {
            get { return parcels; }
            set
            {
                if (parcels.Equals(value)) return;
                parcels = value;
                Changed = true;
            }
        }
        public static long Status
        {
            get { return status; }
            set
            {
                if (status.Equals(value)) return;
                status = value;
                Changed = true;
            }
        }
        public static string Description
        {
            get { return description; }
            set
            {
                if (description.Equals(value)) return;
                description = value;
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
        public static string Observation
        {
            get { return observation; }
            set
            {
                if (observation.Equals(value)) return;
                observation = value;
                Changed = true;
            }
        }

        public static class Custom
        {
            private static string accounts = string.Empty;
            private static string cards = string.Empty;
            private static string debtCategories = string.Empty;
            private static string debtClass = string.Empty;
            private static string debtSubcategories1 = string.Empty;
            private static string debtSubcategories2 = string.Empty;
            private static string debtSubcategories3 = string.Empty;
            private static string opperationTypes = string.Empty;
            private static string people = string.Empty;
            private static string users = string.Empty;
            public static string Accounts
            {
                get { return accounts; }
                set
                {
                    if (accounts.Equals(value)) return;
                    accounts = value;
                    Changed = true;
                }
            }
            public static string Cards
            {
                get { return cards; }
                set
                {
                    if (cards.Equals(value)) return;
                    cards = value;
                    Changed = true;
                }
            }
            public static string DebtCategories
            {
                get { return debtCategories; }
                set
                {
                    if (debtCategories.Equals(value)) return;
                    debtCategories = value;
                    Changed = true;
                }
            }
            public static string DebtClass
            {
                get { return debtClass; }
                set
                {
                    if (debtClass.Equals(value)) return;
                    debtClass = value;
                    Changed = true;
                }
            }
            public static string OpperationTypes
            {
                get { return opperationTypes; }
                set
                {
                    if (opperationTypes.Equals(value)) return;
                    opperationTypes = value;
                    Changed = true;
                }
            }
            public static string People
            {
                get { return people; }
                set
                {
                    if (people.Equals(value)) return;
                    people = value;
                    Changed = true;
                }
            }
            public static string DebtSubcategories1
            {
                get { return debtSubcategories1; }
                set
                {
                    if (debtSubcategories1.Equals(value)) return;
                    debtSubcategories1 = value;
                    Changed = true;
                }
            }
            public static string DebtSubcategories2
            {
                get { return debtSubcategories2; }
                set
                {
                    if (debtSubcategories2.Equals(value)) return;
                    debtSubcategories2 = value;
                    Changed = true;
                }
            }
            public static string DebtSubcategories3
            {
                get { return debtSubcategories3; }
                set
                {
                    if (debtSubcategories3.Equals(value)) return;
                    debtSubcategories3 = value;
                    Changed = true;
                }
            }
            public static string Users
            {
                get { return users; }
                set
                {
                    if (users.Equals(value)) return;
                    users = value;
                    Changed = true;
                }
            }
        }
        public static class Enum
        {
            private static long accounts = 1;
            private static long cards = 1;
            private static long debtCategories = 1;
            private static long debtClass = 1;
            private static long opperationTypes = 1;
            private static long people = 1;
            private static long debtSubcategories1 = 1;
            private static long debtSubcategories2 = 1;
            private static long debtSubcategories3 = 1;
            private static long users = 1;
            public static long Accounts
            {
                get { return accounts; }
                set
                {
                    if (accounts.Equals(value)) return;
                    accounts = value;
                    Changed = true;
                }
            }
            public static long Cards
            {
                get { return cards; }
                set
                {
                    if (cards.Equals(value)) return;
                    cards = value;
                    Changed = true;
                }
            }
            public static long DebtCategories
            {
                get { return debtCategories; }
                set
                {
                    if (debtCategories.Equals(value)) return;
                    debtCategories = value;
                    Changed = true;
                }
            }
            public static long DebtClass
            {
                get { return debtClass; }
                set
                {
                    if (debtClass.Equals(value)) return;
                    debtClass = value;
                    Changed = true;
                }
            }
            public static long OpperationTypes
            {
                get { return opperationTypes; }
                set
                {
                    if (opperationTypes.Equals(value)) return;
                    opperationTypes = value;
                    Changed = true;
                }
            }
            public static long People
            {
                get { return people; }
                set
                {
                    if (people.Equals(value)) return;
                    people = value;
                    Changed = true;
                }
            }
            public static long DebtSubcategories1
            {
                get { return debtSubcategories1; }
                set
                {
                    if (debtSubcategories1.Equals(value)) return;
                    debtSubcategories1 = value;
                    Changed = true;
                }
            }
            public static long DebtSubcategories2
            {
                get { return debtSubcategories2; }
                set
                {
                    if (debtSubcategories2.Equals(value)) return;
                    debtSubcategories2 = value;
                    Changed = true;
                }
            }
            public static long DebtSubcategories3
            {
                get { return debtSubcategories3; }
                set
                {
                    if (debtSubcategories3.Equals(value)) return;
                    debtSubcategories3 = value;
                    Changed = true;
                }
            }
            public static long Users
            {
                get { return users; }
                set
                {
                    if (users.Equals(value)) return;
                    users = value;
                    Changed = true;
                }
            }
        }
        public static class Inherit
        {
            private static bool accounts = false;
            private static bool cards = false;
            private static bool opperationTypes = false;
            private static bool debtSubcategories = false;
            private static bool parcels = false;
            public static bool Accounts
            {
                get { return accounts; }
                set
                {
                    if (accounts.Equals(value)) return;
                    accounts = value;
                    Changed = true;
                }
            }
            public static bool Cards
            {
                get { return cards; }
                set
                {
                    if (cards.Equals(value)) return;
                    cards = value;
                    Changed = true;
                }
            }
            public static bool OpperationTypes
            {
                get { return opperationTypes; }
                set
                {
                    if (opperationTypes.Equals(value)) return;
                    opperationTypes = value;
                    Changed = true;
                }
            }
            public static bool DebtSubcategories
            {
                get { return debtSubcategories; }
                set
                {
                    var oldValue = debtSubcategories;
                    if (oldValue.Equals(value)) return;
                    debtSubcategories = value;
                    Changed = true;
                }
            }
            public static bool Parcels
            {
                get { return parcels; }
                set
                {
                    var oldValue = parcels;
                    if (oldValue.Equals(value)) return;
                    parcels = value;
                    Changed = true;
                }
            }
        }
    }
}
