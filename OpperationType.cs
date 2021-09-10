using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISCOFIN_v1
{
    class OpperationType
    {
        private static bool cardSelection = false;
        private static bool parcelsSelection = false;
        private static string name = string.Empty;

        public static bool Changed { get; set; }
        public static bool CardSelection
        {
            get { return cardSelection; }
            set
            {
                if (cardSelection.Equals(value)) return;
                cardSelection = value;
                Changed = true;
            }
        }
        public static bool ParcelsSelection
        {
            get { return parcelsSelection; }
            set
            {
                if (parcelsSelection.Equals(value)) return;
                parcelsSelection = value;
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
