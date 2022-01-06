using DAL.WoWW.Entities;
using DAL.WoWW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWW.Views
{
    internal class TypeView
    {
        //static int playerId;
        public static void CreationType(int playerId)
        {
            TypeCharacter newType = new TypeCharacter();
            Console.WriteLine("Création d'un nouveau type de personnage : ");
            Console.Write("Nom du type : ");
            newType.NameType = Console.ReadLine(); 
            Console.Write("Minimum Points de vie (LP) : ");
            newType.MinLP = Int32.Parse(Console.ReadLine());
            Console.Write("Maximum Points de vie (LP) : ");
            newType.MaxLP = Int32.Parse(Console.ReadLine());
            Console.Write("Minimum Points d'attaque (AP) : ");
            newType.MinAP = Int32.Parse(Console.ReadLine());
            Console.Write("Maximum Points d'attaque (AP) : ");
            newType.MaxAP = Int32.Parse(Console.ReadLine());

            TypeService typeCharacter = new TypeService();
            typeCharacter.Create(newType);
            Console.WriteLine("Type de Personnage créé");
            MenuType(playerId);
        }

        public static void MenuType(int playerId)
        {
            Console.WriteLine("Choisir un type : ");
            Console.WriteLine("0 - Créer un nouveau type");
            AfficherNomsTypes();
            int choix = int.Parse(Console.ReadLine());
            //do
            //{
                if (choix == 0)
                {
                    CreationType(playerId);
                }
                else
                {
                    DetailType(choix, playerId);
                }
            //}while(choix < 0);
            // ! Vérifier que le chiffre choisi n'est pas supérieur aux nombres d'équipes possible 
            // Sinon reposer la question !      
        }

        //public static void ListeType()
        //{
        //    TypeService teamService = new TypeService();
        //    Console.WriteLine("Liste des équipes");
        //    Console.WriteLine("Id ------ Nom ------- Score");
        //    foreach (TypeCharacter typeCharacter in teamService.GetAll())
        //    {
        //        Console.WriteLine(typeCharacter.Id + " -- -- " +typeCharacter.Name + " -- "+typeCharacter.Score);
        //    }

        //    Console.WriteLine();
        //    Console.WriteLine("Afficher la typeCharacter  (id): ");

        //    int choix = int.Parse(Console.ReadLine());
        //    DetailType(choix);
        //}

        public static void AfficherNomsTypes()
        {
            TypeService teamService = new TypeService();
            foreach (TypeCharacter typeCharacter in teamService.GetAll())
            {
                //int ordre = 1;
                Console.WriteLine(/*ordre*/ typeCharacter.Id + " - " + typeCharacter.NameType);
            }
        }

        public static void DetailType(int idType, int playerId)
        {
            TypeService service = new TypeService();
            TypeCharacter selectedType = service.GetById(idType);
            Console.WriteLine("Id : "+ selectedType.Id);
            Console.WriteLine("Nom : "+ selectedType.Name);
            Console.WriteLine("Score : "+ selectedType.Score);

            Console.WriteLine("");
            Console.WriteLine("S'y inscire ? 1 - Oui, 2 - Non");
            int choix = int.Parse(Console.ReadLine());

            if(choix == 1)
            {
                PlayerService _playerService = new PlayerService();
                _playerService.SetTypeToPlayer(playerId, idType);
                Console.WriteLine("Merci pour votre inscription");
                //MenuType(playerId); FAIRE UNE SUITE POUR RETOURNER AU MENU JOUEUR
            }
            if(choix == 2)
            {
                MenuType(playerId);
            }

        }
    }
}
