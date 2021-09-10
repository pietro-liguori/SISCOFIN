using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISCOFIN_v1
{
    class CardType
    {
        private static bool hasClosingDay = false;
        private static bool hasCreditLimit = false;
        private static bool hasCVV = false;
        private static bool hasDueDay = false;
        private static bool hasExpiration = false;
        private static bool hasFee = false;
        private static bool hasFlag = false;
        private static string name = string.Empty;
        private static string opperationTypes = string.Empty;

        public static bool Changed { get; set; }
        public static bool HasClosingDay
        {
            get { return hasClosingDay; }
            set
            {
                if (hasClosingDay.Equals(value)) return;
                hasClosingDay = value;
                Changed = true;
            }
        }
        public static bool HasCreditLimit
        {
            get { return hasCreditLimit; }
            set
            {
                if (hasCreditLimit.Equals(value)) return;
                hasCreditLimit = value;
                Changed = true;
            }
        }
        public static bool HasCVV
        {
            get { return hasCVV; }
            set
            {
                if (hasCVV.Equals(value)) return;
                hasCVV = value;
                Changed = true;
            }
        }
        public static bool HasDueDay
        {
            get { return hasDueDay; }
            set
            {
                if (hasDueDay.Equals(value)) return;
                hasDueDay = value;
                Changed = true;
            }
        }
        public static bool HasExpiration
        {
            get { return hasExpiration; }
            set
            {
                if (hasExpiration.Equals(value)) return;
                hasExpiration = value;
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
        public static bool HasFlag
        {
            get { return hasFlag; }
            set
            {
                if (hasFlag.Equals(value)) return;
                hasFlag = value;
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
