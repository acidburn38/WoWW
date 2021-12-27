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
        public static void AfficherWOWW(){
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
        }

        public static Player AccueilMenu(PlayerView playerView)
        {
            string choix;
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Que faire ?");
                Console.WriteLine("1. Créer un nouveau compte Player ?");
                Console.WriteLine("2. Se connecter");
                choix = Console.ReadLine();
            } while (choix != "1" && choix != "2");

            switch (choix)
            {
                case "1": return currentPlayer = playerView.InscriptionJoueur(); break;
                case "2": return currentPlayer = playerView.Connexion(); ; break;
                default:
                    {
                        Console.WriteLine("Choix invalide");
                        AccueilMenu(playerView);
                        return currentPlayer = null;
                        break;
                    }
            };

        }

        public static void AccueilJoueur(Player currentPlayer)
        {
            string choix;
            do
            {

                Console.WriteLine("Bonjour " + currentPlayer.Name);
                Console.WriteLine("Que faire ?");

                Console.WriteLine("1. Mettre à jour mon profil.(Pas encore fini)");
                Console.WriteLine("2. Choisir une équipe.");
                Console.WriteLine("3. Voir mes Personnages (Pas encore fini)");
                choix = Console.ReadLine();

            } while (choix != "1" && choix != "2" && choix != "3");


            switch (choix)
            {
                case "1": playerView.UpdateJoueur(currentPlayer);
                            break;
                case "2": TeamView.MenuTeam(currentPlayer.Id);
                            break;
                case "3": CharacterView.MenuCharacter(currentPlayer.Id);
                            break;
                default:
                    {
                        Console.WriteLine("Choix invalide");
                        AccueilJoueur(currentPlayer);
                        break;
                    }
            };
        }
    }
}
//}	Ajouter Character => Formulaire Create Character(choisir Nom + Type)
//	Supprimer Character => Delete Character
//	Combattre

