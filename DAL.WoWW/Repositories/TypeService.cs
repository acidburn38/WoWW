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
    internal class TypeService
    {
        private const string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WoWW;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<TypeCharacter> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Type";
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Mapper.ConvertType(reader);
                        }
                    }

                    connection.Close();
                }
            }
        }
        public Type GetById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Type WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", Id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Mapper.ConvertType(reader);
                        }
                    }
                }
            }
            return null;
        }

        public bool Create(TypeCharacter type)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Type] (name, LP, AP, status, FK_Type, FK_Player) VALUES (@name,  @LP, @AP, @status, @FK_Type, @FK_Player)";

                    cmd.Parameters.AddWithValue("@nameType", type.NameType);
                    cmd.Parameters.AddWithValue("@minLP", type.MinLP);
                    cmd.Parameters.AddWithValue("@maxLP", type.MaxLP);
                    cmd.Parameters.AddWithValue("@minAP", type.MinAP);
                    cmd.Parameters.AddWithValue("@maxAP", type.MaxAP);

                    connection.Open();
                    return cmd.ExecuteNonQuery() == 1;
                    //connection.Close();
                }
            }
        }
    }
}