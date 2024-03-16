using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Sponsorship
    {
        public int SponsorshipId { get; set; }
        public string SponsorshipName { get; set; }

        private List<Player> players = new List<Player>();
        public virtual List<Player> Players { get { return players; } }
    }
}
