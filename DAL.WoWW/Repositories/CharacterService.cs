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
    public class CharacterService
    {
        //private const string _connectionString = @"Data Source=WAD-01;Initial Catalog=WoWW;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //private const string _connectionString = @"Data Source=DESKTOP-RGPQP6I\TFTIC2019;Initial Catalog=WoWW; Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WoWW;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public IEnumerable<Character> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Character";
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Mapper.ConvertCharacter(reader);
                        }
                    }

                    connection.Close();
                }
            }
        }

        public Character GetById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Character WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", Id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Mapper.ConvertCharacter(reader);
                        }
                    }
                }
            }
            return null;
        }

        public bool Create(Character perso)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Character] (name, FK_Type, FK_Player) VALUES (@name, @)";

                    cmd.Parameters.AddWithValue("@name", perso.Name);
                    cmd.Parameters.AddWithValue("@FK_Type", perso.FK_Type);
                    cmd.Parameters.AddWithValue("@FK_Player", perso.FK_Player);

                    connection.Open();
                    return cmd.ExecuteNonQuery() == 1;
                    //connection.Close();
                }
            }
        }

        //public bool UpdateScore(Character perso)
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        using (SqlCommand cmd = connection.CreateCommand())
        //        {
        //            cmd.CommandText = "UPDATE Character SET Score = @score WHERE Id = @id";

        //            cmd.Parameters.AddWithValue("@score", team.Score);
        //            cmd.Parameters.AddWithValue("@id", team.Id);

        //            connection.Open();
        //            return cmd.ExecuteNonQuery() == 1;
        //            //connection.Close();
        //        }
        //    }
        //}

    }
}