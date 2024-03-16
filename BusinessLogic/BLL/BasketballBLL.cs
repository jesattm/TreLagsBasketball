using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using DTO.Model;

namespace BusinessLogic.BLL
{
    public class BasketballBLL
    {
        public Player GetPlayer(int id)
        {
            return BasketballRepository.GetPlayer(id);
        }
        public Player AddPlayer(Player player)
        {
            return BasketballRepository.AddPlayer(player);
        }
        public List<Player> GetAllPlayers()
        {
            return BasketballRepository.GetAllPlayers();
        }
        public void EditPlayer(Player player)
        {
            BasketballRepository.EditPlayer(player);
        }
        public Player DeletePlayer(int id)
        {
            return BasketballRepository.DeletePlayer(id);
        }
        public TeamDetail GetTeamDetail(int id)
        {
            return BasketballRepository.GetTeamDetail(id);
        }
        public TeamDetail AddTeam(Team team)
        {
            return BasketballRepository.AddTeam(team);
        }
        public List<TeamDetail> GetAllTeams()
        {
            return BasketballRepository.GetAllTeams();
        }
        public void AddPlayerToTeam(int playerId, int teamId)
        {
            BasketballRepository.AddPlayerToTeam(playerId, teamId);
        }
        public void RemovePlayersFromTeam(int teamId)
        {
            BasketballRepository.RemovePlayersFromTeam(teamId);
        }
        public TeamDetail DeleteTeam(int teamId)
        {
            return BasketballRepository.DeleteTeam(teamId);
        }
        public SponsorshipDetail GetSponsorship(int sponsorshipId)
        {
            return BasketballRepository.GetSponsorshipDetail(sponsorshipId);
        }
        public void AddPlayerToSponsorship(int playerId, int sponsorshipId)
        {
            BasketballRepository.AddPlayerToSponsorship(playerId, sponsorshipId);
        }
    }
}
