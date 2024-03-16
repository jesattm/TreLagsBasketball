using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class TeamDetail
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public List<Player> Players { get; set; }
        public TeamDetail(DTO.Model.TeamDetail teamDetail)
        {
            TeamId = teamDetail.TeamDetailId;
            TeamName = teamDetail.TeamDetailName;
            Players = DTOPlayersToAPIPlayers(teamDetail.Players);
        }

        public TeamDetail()
        {
        }

        private List<Player> DTOPlayersToAPIPlayers(List<DTO.Model.Player> DTOPlayers)
        {
            List<Player> APIPlayers = new List<Player>();
            foreach (DTO.Model.Player DTOPlayer in DTOPlayers)
            {
                Player MVCPlayer = new Player(DTOPlayer);
                APIPlayers.Add(MVCPlayer);
            }
            return APIPlayers;
        }
    }
}
