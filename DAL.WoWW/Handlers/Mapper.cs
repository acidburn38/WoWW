using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WoWW.Handlers
{
    public Team Convert(IDataRecord reader)
    {
        return new Team
        {
            Id = (int)reader["Id"],
            Name = reader["name"] is DBNull ? null : reader["name"].ToString(),
            Score = (int)reader["Score"]
        };
    }
}

