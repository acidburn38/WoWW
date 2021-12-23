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
    public class TeamService
    {
        //private const string _connectionString = @"Data Source=WAD-01;Initial Catalog=WoWW;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //private const string _connectionString = @"Data Source=DESKTOP-RGPQP6I\TFTIC2019;Initial Catalog=WoWW; Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WoWW;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public IEnumerable<Team> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Team";
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Mapper.ConvertTeam(reader);
                        }
                    }

                    connection.Close();
                }
            }
        }

        public Team GetById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Team WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", Id);
                    connection.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Mapper.ConvertTeam(reader);
                        }
                    }
                }
            }
            return null;
        }

        public bool Create(Team team)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Team] (name) VALUES (@name)";

                    cmd.Parameters.AddWithValue("@name", team.Name);

                    connection.Open();
                    return cmd.ExecuteNonQuery() == 1;
                    //connection.Close();
                }
            }
        }

        public bool UpdateScore(Team team)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Team SET Score = @score WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@score", team.Score);
                    cmd.Parameters.AddWithValue("@id", team.Id);

                    connection.Open();
                    return cmd.ExecuteNonQuery() == 1;
                    //connection.Close();
                }
            }
        }

    }
}
