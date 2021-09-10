using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISCOFIN_v1
{
    class AccountType
    {
        private static bool enableCard = false;
        private static bool enableOpperation = false;
        private static bool hasAccount = false;
        private static bool hasAgency = false;
        private static bool hasFee = false;
        private static bool hasGrace = false;
        private static bool hasOverdraft = false;
        private static long standardOpperation = -1;
        private static string accounttClass = string.Empty;
        private static string cardTypes = string.Empty;
        private static string name = string.Empty;
        private static string opperationTypes = string.Empty;

        public static bool Changed { get; set; }
        public static bool EnableCard
        {
            get { return enableCard; }
            set
            {
                if (enableCard.Equals(value)) return;
                enableCard = value;
                Changed = true;
            }
        }
        public static bool EnableOpperation
        {
            get { return enableOpperation; }
            set
            {
                if (enableOpperation.Equals(value)) return;
                enableOpperation = value;
                Changed = true;
            }
        }
        public static bool HasAccount
        {
            get { return hasAccount; }
            set
            {
                if (hasAccount.Equals(value)) return;
                hasAccount = value;
                Changed = true;
            }
        }
        public static bool HasAgency
        {
            get { return hasAgency; }
            set
            {
                if (hasAgency.Equals(value)) return;
                hasAgency = value;
                Changed = true;
            }
        }
        public static bool HasFee
        {
            get { return hasFee; }
            set
            {
                if (hasFee.Equals(value)) return;
                hasFee = value;
                Changed = true;
            }
        }
        public static bool HasGrace
        {
            get { return hasGrace; }
            set
            {
                if (hasGrace.Equals(value)) return;
                hasGrace = value;
                Changed = true;
            }
        }
        public static bool HasOverdraft
        {
            get { return hasOverdraft; }
            set
            {
                if (hasOverdraft.Equals(value)) return;
                hasOverdraft = value;
                Changed = true;
            }
        }
        public static long StandardOpperation
        {
            get { return standardOpperation; }
            set
            {
                if (standardOpperation.Equals(value)) return;
                standardOpperation = value;
                Changed = true;
            }
        }
        public static string AccountClass
        {
            get { return accounttClass; }
            set
            {
                if (accounttClass.Equals(value)) return;
                accounttClass = value;
                Changed = true;
            }
        }
        public static string CardTypes
        {
            get { return cardTypes; }
            set
            {
                if (cardTypes.Equals(value)) return;
                cardTypes = value;
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
    }
}
