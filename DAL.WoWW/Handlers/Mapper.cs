using DAL.WoWW.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WoWW.Handlers
{
    public static class Mapper
    {
        public static Team ConvertTeam(IDataRecord reader)
        {
            return new Team
            {
                Id = (int)reader["Id"],
                Name = reader["name"] is DBNull ? null : reader["name"].ToString(),
                Score = (int)reader["Score"]
            };
        }
        public static Tournament ConvertTournament(IDataRecord reader)
        {
            return new Tournament
            {
                Id = (int)reader["Id"],
                Name = (string)reader["name"],
                Category = (string)reader["Category"]
            };
        }

        public static Player ConvertPlayer(IDataRecord reader)
        {
            return new Player
            {
                Id = (int)reader["Id"],
                Name = reader["name"] is DBNull ? null : reader["name"].ToString(),
                Email = (string)reader["email"],
                FK_Team = reader["FK_Team"] is DBNull ? 0 : (int)reader["FK_Team"]
            };
        }
        public static Character ConvertCharacter(IDataRecord reader)
        {
            return new Character
            {
                Id = (int)reader["Id"],
                Name = reader["name"] is DBNull ? null : reader["name"].ToString(),
                LP = (int)reader["LP"],
                AP = (int)reader["AP"],
                Status = (bool)reader["Status"],
                FK_Type = reader["FK_Type"] is DBNull ? 0 : (int)reader["FK_Type"],
                FK_Player = reader["FK_Player"] is DBNull ? 0 : (int)reader["FK_Player"]
            };
        }
        public static TypeCharacter ConvertType(IDataRecord reader)
        {
            return new TypeCharacter
            {
                Id = (int)reader["Id"],
                NameType = reader["nameType"] is DBNull ? null : reader["nameType"].ToString(),
                MinLP = (int)reader["minLP"],
                MaxLP = (int)reader["maxLP"],
                MinAP = (int)reader["minAP"],
                MaxAP = (int)reader["maxAP"]
            };
        }
        public static Fight ConvertFight(IDataRecord reader)
        {
            return new Fight
            {
                Id = (int)reader["Id"],
                DateFight = reader["DateFight"] is DBNull ? null : (DateTime)reader["DateFight"],
                FK_Tournament = reader["FK_Tournament"] is DBNull ? 0 : (int)reader["FK_Tournament"],
                FK_Winner = reader["FK_Winner"] is DBNull ? 0 : (int)reader["FK_Winner"],
                FK_Looser = reader["FK_Looser"] is DBNull ? 0 : (int)reader["FK_Looser"]
            };
        }
        public static Participation ConvertParticipation(IDataRecord reader)
        {
            return new Participation
            {
                Id = (int)reader["Id"],
                RegistrationDate = reader["RegistrationDate"] is DBNull ? null : (DateTime)reader["RegistrationDate"],
                FK_Team = reader["FK_Team"] is DBNull ? 0 : (int)reader["FK_Team"],
                FK_Tournament = reader["FK_Tournament"] is DBNull ? 0 : (int)reader["FK_Tournament"]            };
        }
    }
   
}

