using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WoWW.Entities
{
    public class Fight
    {
        public int Id { get; set; }

        public DateTime? DateFight { get; set; }
        //DateTime n'était pas nullable mais on a besoin que ça le soit dans la DB donc ajouter un ? après le type pour lui dire qu'il pourrait être nullable

        public int FK_Tournament { get; set; }
        public int FK_Winner { get; set; }
        public int FK_Looser { get; set; }


        //Pour récupérer le détail d'un combat
        /*
         1. Remplir cet objet avec les info de la table Fight
         2. Récupérer les info du winner et du looser dans la table Player
         2'. Récupérer les info du tournoi de la table Tournament
         3. Jouer avec les 3 objets pour créer ton affichage
         */
    }
}
