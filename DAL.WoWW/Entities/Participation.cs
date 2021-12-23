using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WoWW.Entities
{
    public class Participation
    {
        public int Id { get; set; }

        public DateTime? RegistrationDate { get; set; }
        public int FK_Team { get; set; }
        public int FK_Tournament { get; set; }

    }
}
