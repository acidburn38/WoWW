using DAL.WoWW.Entities;
using DAL.WoWW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWW.Views
{
    internal class CharacterView
    {
        static int playerId;
        static int typeId;

        public static void MenuCharacter(int playerId)
        {
            Console.WriteLine("Choisir un personnage : ");
            Console.WriteLine("0 - Créer un nouveau personnage");
            AfficherCharacter(playerId);
            int choix = int.Parse(Console.ReadLine());
            //do
            //{
            if (choix == 0)
            {
                CreationCharacter(playerId);
            }
            else
            {
                DetailCharacter(choix, playerId);
            }
        }
            public static void CreationCharacter(int playerId)
        {
            Character newCharacter = new Character();
            Console.WriteLine("Création de team ");
            Console.Write("Nom : ");
            newCharacter.Name = Console.ReadLine();

            CharacterService character = new CharacterService();
            character.Create(newCharacter);
            Console.WriteLine("Character créé");
            //MenuCharacter(playerId);
        }
        public static void ListeCharacter(int playerId)
        {
            CharacterService characterService = new CharacterService();
            Console.WriteLine("Liste des équipes");
            Console.WriteLine("Id ------ Nom ------- Type");
            foreach (Character perso in characterService.GetAll())
            {
                Console.WriteLine(perso.Id + " -- -- " + perso.Name + " -- " + perso.FK_Type);
            }
            // _ modifier TypeId par nom du type

            Console.WriteLine();
            Console.WriteLine("Afficher le perso (id): ");

            int choix = int.Parse(Console.ReadLine());
            //DetailPerso(choix);
        }

        public static void AfficherCharacter(int playerId)
        {
            CharacterService characterService = new CharacterService();
            foreach (Character perso in characterService.GetAll())
            {
                //int ordre = 1;
                Console.WriteLine(/*ordre*/ perso.Id + " - " + perso.Name);
            }
        }

        public static void DetailCharacter(int idCharacter, int playerId)
        {
            CharacterService service = new CharacterService();
            Character selectedCharacter = service.GetById(idCharacter);
            Console.WriteLine("Id : " + selectedCharacter.Id);
            Console.WriteLine("Nom : " + selectedCharacter.Name);
            Console.WriteLine("Type : " + selectedCharacter.FK_Type);

            Console.WriteLine("");
            Console.WriteLine("Que faire ?");

            Console.WriteLine("1. Mettre à jour mon Personnage.");
            Console.WriteLine("2. Supprimer mon Personnage");
            Console.WriteLine("3. Combattre");
            int choix = int.Parse(Console.ReadLine());

            //switch (choix)
            //{
            //    case 1: return currentPlayer = playerView.InscriptionJoueur(); break;
            //    case 2:
            //        TeamView.MenuTeam(currentPlayer.Id);
            //        return currentPlayer; break;
            //    case 3: return currentPlayer = playerView.Connexion(); ; break;

            //    default:
            //        {
            //            Console.WriteLine("Choix invalide");
            //            AccueilMenu(playerView);
            //            return currentPlayer = null;
            //            break;
            //        }
            //};

        }
    }
}
