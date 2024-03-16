using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GUI_For_API.Model
{
    [Serializable]
    public class PlayerDetail
    {
        public int playerId { get; set; }
        public string name { get; set; }
        public Position position { get; set; }
        public string positionString
        {
            get
            {
                return PositionEnumToString(this.position);
            }
        }

        public PlayerDetail(int playerId, string name, Position position)
        {
            this.playerId = playerId;
            this.name = name;
            this.position = position;
        }

        public PlayerDetail(string name, Position position)
        {
            this.name = name;
            this.position = position;
        }

        public PlayerDetail()
        {
        }

        public override string? ToString()
        {
            return $"{name}, Position: {position}, Id: {playerId}";
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
