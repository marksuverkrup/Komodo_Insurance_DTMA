using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Developer
    {
        public string FullName { get; set; }
        public int IdNumber { get; set; }
        public bool PluralSight { get; set; }

        public Developer() { }

        public Developer(string fullName, int idNumber, bool pluralSight)
        {
            FullName = fullName;
            IdNumber = idNumber;
            PluralSight = pluralSight;
        }
    }
}
