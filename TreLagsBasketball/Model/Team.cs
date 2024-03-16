using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Team
    {
        private List<Player> players = new List<Player>();
        public virtual List<Player> Players { get { return players; } }
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public Team()
        {
        }
        public Team(string teamName)
        {
            TeamName = teamName;
        }

        public Team(List<Player> players, int teamId, string teamName)
        {
            this.players = players;
            TeamId = teamId;
            TeamName = teamName;
        }

        public Team(int teamId, string teamName)
        {
            TeamId = teamId;
            TeamName = teamName;
        }
    }
}
