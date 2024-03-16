using System.ComponentModel.DataAnnotations;

namespace MVC_GUI.Models
{
    public class TeamDetail
    {
        public int TeamId { get; set; }
        [Display(Name = "Enter team name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be at least 3 characters")]
        [Required(ErrorMessage = "You must enter team name")]
        public string TeamName { get; set; }
        public List<Player> Players { get; set; }
        public TeamDetail(DTO.Model.TeamDetail teamDetail)
        {
            TeamId = teamDetail.TeamDetailId;
            TeamName = teamDetail.TeamDetailName;
            Players = DTOPlayersToMVCPlayers(teamDetail.Players);
        }

        public TeamDetail()
        {
        }

        private List<Player> DTOPlayersToMVCPlayers(List<DTO.Model.Player> DTOPlayers)
        {
            List<Player> MVCPlayers = new List<Player>();
            foreach (DTO.Model.Player DTOPlayer in DTOPlayers)
            {
                Player MVCPlayer = new Player(DTOPlayer);
                MVCPlayers.Add(MVCPlayer);
            }
            return MVCPlayers;
        }
    }
}
