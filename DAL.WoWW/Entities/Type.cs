using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WoWW.Entities
{
    public class Type
    {
        public int Id { get; set; }
        public string NameType { get; set; }
        public int MinLP { get; set; }
        public int MaxLP { get; set; }
        public int MinAP { get; set; }
        public int MaxAP { get; set; }

    }
}
