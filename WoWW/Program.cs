using DAL.WoWW.Entities;
using DAL.WoWW.Repositories;
using System;
using WoWW.Views;

namespace WoWW
{
//-	Menu Bienvenue
//o Login
//o Inscription
//-	Si Inscription => Formulaire Create Player puis direction vers menu player
//-	Si Login => Form Login + Mot de passe => Si correct => Menu Player
//-	Menu Player :
//o Afficher Liste Characters + Details(ou pas encore de character => Ajouter un Character)
//o Afficher info Team(nom+score)  (ou Choisir Team)
//+ Menu Player :
//	Mettre à jour profil Player(update Player)
//	Ajouter Character => Formulaire Create Character(choisir Nom + Type)
//	Supprimer Character => Delete Character
//	Combattre
//-	Menu Choisir Team => Afficher Liste Team
//o   1. Ajouter une Team => Form Create Team(+ s’inscrire au tournoi)
//o	2. Choisir une équipe => Ajouter IdTeam au player
//-	Menu Combattre => Afficher Liste Character pour choisir ID pour combat
//-	Logic Fight(idCharcter choisi)
//o Récupérer idTeam du player pour choisir un player aléatoire d’une autre équipe + 1 character aléatoire de ce joueur
//o   Comparer points de vie et points de force des 2 joueurs

    class Program
    {
        static void Main(string[] args)
        {
            // CREATION Player View pour pouvoir y accéder tout le temps depuis la main
            PlayerView playerView = new PlayerView();
            Player currentPlayer = null;



            // MENU D'ACCUEIL - TITRE + Menu S'inscrire ou se Connecter
            currentPlayer = AccueilView.AccueilMenu(playerView);
            currentPlayer = AccueilView.AccueilJoueur(currentPlayer);

            // MENU ACCUEIL JOUEUR

            Console.WriteLine("test Ok ?");
            Console.ReadLine();


            //TeamView.MenuTeam(currentPlayer.Id);






            //TeamService teamService = new TeamService();

            //teamService.Create(TeamView.CreationTeam());


            //foreach (Team team in teamService.GetAll())
            //{
            //    Console.WriteLine(team.Name);
            //}

            //Team t1 = new Team();
            //t1.Name = "Wad21";

            //Team t2 = new Team();
            //t1.Name = "Web10";

            //if (teamDAO.Create(t1)) Console.WriteLine("Team 1 créée");
            //else Console.WriteLine("Un problème est survenu");

            //if (teamDAO.Create(t2)) Console.WriteLine("Team 2 créée");
            //else Console.WriteLine("Un problème est survenu"); 

            //foreach (Team t in teamDAO.GetAll())
            //{
            //    Console.WriteLine("ID : {0} -- Nom : {1}", t.Id, t.Name);
            //}

        }
    }
}
