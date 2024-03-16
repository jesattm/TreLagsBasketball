using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class TeamDetail
    {
        public TeamDetail()
        {
        }

        public TeamDetail(string teamDetailName)
        {
            TeamDetailName = teamDetailName;
        }

        public int TeamDetailId { get; set; }
        public string TeamDetailName { get; set; }
        public List<Player> Players { get; set; }



        public override string? ToString()
        {
            return TeamDetailName + ", Id: " + TeamDetailId;
        }
    }
}
