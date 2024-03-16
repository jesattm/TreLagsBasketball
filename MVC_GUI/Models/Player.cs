using DTO.Model;
using System.ComponentModel.DataAnnotations;

namespace MVC_GUI.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        [Display(Name = "Enter player name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be at least 2 characters")]
        [Required(ErrorMessage = "You forgot to enter player name")]
        public string Name { get; set; }
        [Display(Name = "Select position")]
        [Required(ErrorMessage = "You forgot to select position")]
        public Position Position { get; set; }
        public string PositionString
        {
            get
            {
                return PositionEnumToString(this.Position);
            }
        }

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

        public Player(DTO.Model.Player player)
        {
            PlayerId = player.PlayerId;
            Name = player.Name;
            Position = player.Position;
        }

        public override string? ToString()
        {
            return $"{Name}, Position: {Position}, Id: {PlayerId}";
        }
        private string PositionEnumToString(Position position)
        {
            switch (position)
            {
                case Position.PointGuard:
                    return "Point Guard";
                case Position.ShootingGuard:
                    return "Shooting Guard";
                case Position.SmallForward:
                    return "Small Forward";
                case Position.PowerForward:
                    return "Power Forward";
                case Position.Center:
                    return "Center";
                default:
                    return "Position not found";
            }
        }
    }
}
