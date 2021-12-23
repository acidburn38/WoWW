using DAL.WoWW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWW.Views
{
    internal class AccueilView
    {
            public static Player currentPlayer;
            public static PlayerView playerView;
        public static Player AccueilMenu(PlayerView playerView)
        {

            Console.WriteLine("#     #                                                 #     #                  #     #                #####    #   ");
            Console.WriteLine("#  #  #  ####  #####  #      #####      ####  ######    #  #  #   ##   #####     #  #  #   ##   #####  #     #  ##   ");
            Console.WriteLine("#  #  #  ####  #####  #      #####      ####  ######    #  #  #   ##   #####     #  #  #   ##   #####  #     #  ##   ");
            Console.WriteLine("#  #  # #    # #    # #      #    #    #    # #         #  #  #  #  #  #    #    #  #  #  #  #  #    #       # # #   ");
            Console.WriteLine("#  #  # #    # #    # #      #    #    #    # #         #  #  #  #  #  #    #    #  #  #  #  #  #    #       # # #   ");
            Console.WriteLine("#  #  # #    # #    # #      #    #    #    # #####     #  #  # #    # #    #    #  #  # #    # #    #  #####    #   ");
            Console.WriteLine("#  #  # #    # #####  #      #    #    #    # #         #  #  # ###### #####     #  #  # ###### #    # #         #   ");
            Console.WriteLine("#  #  # #    # #   #  #      #    #    #    # #         #  #  # #    # #   #     #  #  # #    # #    # #         #   ");
            Console.WriteLine(" ## ##   ####  #    # ###### #####      ####  #          ## ##  #    # #    #     ## ##  #    # #####  ####### ##### ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Que faire ?");
            Console.WriteLine("1. Créer un compte Player ?");
            Console.WriteLine("2. Se connecter");
            int choix = int.Parse(Console.ReadLine());

            switch (choix)
            {
                case 1: return currentPlayer = playerView.InscriptionJoueur(); break;
                case 2: return currentPlayer = playerView.Connexion(); ; break;
                default:
                    {
                        Console.WriteLine("Choix invalide");
                        AccueilMenu(playerView);
                        return currentPlayer = null;
                        break;
                    }
            };

        }

        public static Player AccueilJoueur(Player currentPlayer)
        {
            Console.WriteLine("Bonjour " + currentPlayer.Name);
            Console.WriteLine("Que faire ?");

            Console.WriteLine("1. Mettre à jour mon profil.(Pas encore fini)");
            Console.WriteLine("2. Choisir une équipe.");
            Console.WriteLine("3. Voir mes Personnages (Pas encore fini)");
            int choix = int.Parse(Console.ReadLine());

            switch (choix)
            {
                case 1: AccueilJoueur(currentPlayer);
                        return currentPlayer; break;
                case 2: TeamView.MenuTeam(currentPlayer.Id);
                        return currentPlayer; break;
                case 3: CharacterView.MenuCharacter(currentPlayer.Id);
                        return currentPlayer = playerView.Connexion(); ; break;

                default:
                    {
                        Console.WriteLine("Choix invalide");
                        AccueilJoueur(currentPlayer);
                        return currentPlayer = null;
                        break;
                    }
            };
        }
    }
}
//}	Ajouter Character => Formulaire Create Character(choisir Nom + Type)
//	Supprimer Character => Delete Character
//	Combattre

