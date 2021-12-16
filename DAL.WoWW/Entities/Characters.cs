using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WoWW.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LP { get; set; }
        public int AP { get; set; }
        public bool Status { get; set; }

    }
}
