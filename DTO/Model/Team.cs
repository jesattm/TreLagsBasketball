using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public Team(string teamName)
        {
            TeamName = teamName;
        }
        public Team()
        {
        }

        public Team(int teamId, string teamName)
        {
            TeamId = teamId;
            TeamName = teamName;
        }
    }
}
