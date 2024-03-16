using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }

        private List<Sponsorship> sponsorships = new List<Sponsorship>();
        public List<Sponsorship> Sponsorships { get { return sponsorships; } }

        public Player(string name, Position position)
        {
            Name = name;
            Position = position;
        }

        public Player(int playerId, string name, Position position)
        {
            PlayerId = playerId;
            Name = name;
            Position = position;
        }

        public Player()
        {
        }
    }
}
