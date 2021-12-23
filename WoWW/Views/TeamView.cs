using DAL.WoWW.Entities;
using DAL.WoWW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWW.Views
{
    public static class TeamView
    {
        //static int playerId;
        public static void CreationTeam(int playerId)
        {
            Team newTeam = new Team();
            Console.WriteLine("Création de team ");
            Console.Write("Nom : ");
            newTeam.Name = Console.ReadLine();

            TeamService team = new TeamService();
            team.Create(newTeam);
            Console.WriteLine("Equipe créée");
            MenuTeam(playerId);
        }

        public static void MenuTeam(int playerId)
        {
            Console.WriteLine("Choisir une équipe : ");
            Console.WriteLine("0 - Créer une nouvelle équipe");
            AfficherNomsTeams();
            int choix = int.Parse(Console.ReadLine());
            //do
            //{
                if (choix == 0)
                {
                    CreationTeam(playerId);
                }
                else
                {
                    DetailTeam(choix, playerId);
                }
            //}while(choix < 0);
            // ! Vérifier que le chiffre choisi n'est pas supérieur aux nombres d'équipes possible 
            // Sinon reposer la question !      
        }

        //public static void ListeTeam()
        //{
        //    TeamService teamService = new TeamService();
        //    Console.WriteLine("Liste des équipes");
        //    Console.WriteLine("Id ------ Nom ------- Score");
        //    foreach (Team team in teamService.GetAll())
        //    {
        //        Console.WriteLine(team.Id + " -- -- " +team.Name + " -- "+team.Score);
        //    }

        //    Console.WriteLine();
        //    Console.WriteLine("Afficher la team  (id): ");

        //    int choix = int.Parse(Console.ReadLine());
        //    DetailTeam(choix);
        //}

        public static void AfficherNomsTeams()
        {
            TeamService teamService = new TeamService();
            foreach (Team team in teamService.GetAll())
            {
                //int ordre = 1;
                Console.WriteLine(/*ordre*/ team.Id + " - " + team.Name);
            }
        }

        public static void DetailTeam(int idTeam, int playerId)
        {
            TeamService service = new TeamService();
            Team selectedTeam = service.GetById(idTeam);
            Console.WriteLine("Id : "+ selectedTeam.Id);
            Console.WriteLine("Nom : "+ selectedTeam.Name);
            Console.WriteLine("Score : "+ selectedTeam.Score);

            Console.WriteLine("");
            Console.WriteLine("S'y inscire ? 1 - Oui, 2 - Non");
            int choix = int.Parse(Console.ReadLine());

            if(choix == 1)
            {
                PlayerService _playerService = new PlayerService();
                _playerService.SetTeamToPlayer(playerId, idTeam);
                Console.WriteLine("Merci pour votre inscription");
            }
            if(choix == 2)
            {
                MenuTeam(playerId);
            }

        }
    }
}
