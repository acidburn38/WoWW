using DAL.WoWW.Entities;
using DAL.WoWW.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WoWW.Repositories
{
    public class PlayerService
    {
        //private const string _connectionString = @"Data Source=DESKTOP-RGPQP6I\TFTIC2019;Initial Catalog=WoWW; Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WoWW;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
       
        public bool CreatePlayer(Player p)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Player] (name, email, password) VALUES (@name, @email, @password)";

                    cmd.Parameters.AddWithValue("@name", p.Name);
                    cmd.Parameters.AddWithValue("@email", p.Email);
                    cmd.Parameters.AddWithValue("@password", p.Password);

                    connection.Open();
                    return cmd.ExecuteNonQuery() == 1;
                    //connection.Close();
                }
            }
        }

        public Player GetById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Player WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", Id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Mapper.ConvertPlayer(reader);
                        }
                    }
                }
            }
            return null;
        }


        public void SetTeamToPlayer(int playerId, int teamId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Player SET FK_Team = @teamid WHERE Id = @playerid";
                    cmd.Parameters.AddWithValue("@teamid", teamId);
                    cmd.Parameters.AddWithValue("@playerid", playerId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //public void SetCharacterToPlayer(int playerId, int characterId)
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        using (SqlCommand cmd = connection.CreateCommand())
        //        {
        //            cmd.CommandText = "UPDATE Character SET FK_Team = @teamid WHERE Id = @playerid";
        //            cmd.Parameters.AddWithValue("@characterid", characterId);
        //            cmd.Parameters.AddWithValue("@playerid", playerId);

        //            connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        public IEnumerable<Player> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Player";
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Mapper.ConvertPlayer(reader);
                        }
                    }
                }
            }
        }

        public void ChangePassword(int playerId, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Player SET password = @newpwd WHERE Id = @playerid";
                    cmd.Parameters.AddWithValue("@newpwd", newPassword);
                    cmd.Parameters.AddWithValue("@playerid", playerId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Player Login(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Player WHERE email = @email AND password = @password";
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    Player connectedUser = null;
                    connection.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            connectedUser = Mapper.ConvertPlayer(reader);
                    }

                    return connectedUser;
                }
            }
            
        }
    }
}
