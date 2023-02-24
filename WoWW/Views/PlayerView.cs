using DAL.WoWW.Entities;
using DAL.WoWW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWW.Views
{
    internal class PlayerView
    {
        PlayerService _service { get; set; }

        public PlayerView()
        {
            _service = new PlayerService();
        }

        public Player Connexion()
        {
            Console.WriteLine("Entrez votre email : ");
            string email = Console.ReadLine();
            Console.WriteLine("Entrez votre mot de passe : ");
            string password = Console.ReadLine();

            Player currentPlayer = _service.Login(email, password);

            if(currentPlayer is null)
            {
                Console.WriteLine("Utilisateur inexistant, veuillez réessayer");
                Connexion();
            }

            Console.WriteLine("Bienvenue "+ currentPlayer.Name);
            return currentPlayer;
        }

        public Player InscriptionJoueur()
        {
            Player newPlayer = new Player();
            do
            {
                Console.WriteLine("Votre nom : ");
                newPlayer.Name = Console.ReadLine();
                Console.WriteLine("Votre email : ");
                newPlayer.Email = Console.ReadLine();
                Console.WriteLine("Votre password : ");
                newPlayer.Password = Console.ReadLine();
            } while (!_service.CreatePlayer(newPlayer));

            //newPlayer = TeamView.MenuTeam(newPlayer.Id);
            return newPlayer;

        }


        // Mise à jour Joueur NOM ou réinitialiser mot de passe
        public Player UpdateJoueur(Player currentPlayer)
        {
       
                Console.WriteLine("Que voulez vous modifier ?");
                Console.WriteLine("1. Votre nom : " + currentPlayer.Name + "Y/N");
                if (Console.ReadLine()=="Y")
                {
                    Console.WriteLine("Nouveau Nom : ");
                    currentPlayer.Name = Console.ReadLine();
                    _service.ChangeName(currentPlayer.Id, currentPlayer.Name);
                }
                Console.WriteLine("2. Votre Mot de passe ?  Y/N");
                if (Console.ReadLine() == "Y")
                {
                    Console.WriteLine("Nouveau mot de passe : ");
                    currentPlayer.Password = Console.ReadLine();
                    _service.ChangePassword(currentPlayer.Id, currentPlayer.Password);
                }
            return currentPlayer;


        }
    }
}
