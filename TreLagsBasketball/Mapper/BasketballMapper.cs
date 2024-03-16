using DataAccess.Model;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess.Mapper
{
    internal class BasketballMapper
    {
        public static DTO.Model.Player Map(Player? player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("Player parameter is null in 'Map' method");
            }
            return new DTO.Model.Player(player.PlayerId, player.Name, player.Position);
        }
        public static Player Map(DTO.Model.Player player)
        {
            return new Player(player.PlayerId, player.Name, player.Position);
        }
        public static List<DTO.Model.Player> Map(List<Player> playerList)
        {
            List<DTO.Model.Player> returList = new List<DTO.Model.Player>();

            if (playerList != null)
            {
                foreach (Player player in playerList)
                {
                    returList.Add(Map(player));
                }
            }
            return returList;
        }

        public static void Update(DTO.Model.Player DTO_Player, Player DataAccess_Player)
        {
            DataAccess_Player.Name = DTO_Player.Name;
            DataAccess_Player.Position = DTO_Player.Position;
        }
        public static DTO.Model.TeamDetail Map(Team? team)
        {
            if (team == null)
            {
                throw new ArgumentNullException("Team parameter is null in 'Map' method");
            }
            DTO.Model.TeamDetail retur = new DTO.Model.TeamDetail();
            retur.TeamDetailName = team.TeamName;
            retur.TeamDetailId = team.TeamId;
            retur.Players = BasketballMapper.Map(team.Players);
            return retur;
        }

        public static Team Map(DTO.Model.Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException("Team parameter is null in 'Map' method");
            }
            Team retur = new Team();
            retur.TeamName = team.TeamName;
            return retur;
        }

        public static List<DTO.Model.TeamDetail> Map(List<Team> teamList)
        {
            List<DTO.Model.TeamDetail> returList = new List<DTO.Model.TeamDetail>();
            foreach (Team team in teamList)
            {
                returList.Add(Map(team));
            }
            return returList;
        }
        public static DTO.Model.SponsorshipDetail Map(Sponsorship? sponsorship)
        {
            if (sponsorship == null)
            {
                throw new ArgumentNullException("Sponsorship parameter is null in 'Map' method");
            }
            DTO.Model.SponsorshipDetail retur = new DTO.Model.SponsorshipDetail();
            retur.SponsorshipId = sponsorship.SponsorshipId;
            retur.SponsorshipName = sponsorship.SponsorshipName;
            retur.Players = BasketballMapper.Map(sponsorship.Players);
            return retur;
        }
    }
}
