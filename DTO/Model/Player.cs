using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public enum Position
    {
        PointGuard = 1,
        ShootingGuard = 2,
        SmallForward = 3,
        PowerForward = 4,
        Center = 5
    }
    public class Player
    {
        public int PlayerId { get; set; }
        [Required]
        public string Name { get; set; }
        public Position Position { get; set; }

        public Player(int playerId, string name, Position position)
        {
            PlayerId = playerId;
            Name = name;
            Position = position;
        }

        public Player(string name, Position position)
        {
            Name = name;
            Position = position;
        }

        public Player()
        {
        }

        public override string? ToString()
        {
            return $"{Name}, Position: {Position}, Id: {PlayerId}";
        }
    }
}
