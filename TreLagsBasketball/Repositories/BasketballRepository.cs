using DataAccess.Context;
using DataAccess.Mapper;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BasketballRepository
    {
        public static DTO.Model.Player GetPlayer(int id)
        {
            using (BasketballContext context = new BasketballContext())
            {
                DTO.Model.Player DTO_Player = BasketballMapper.Map(context.Players
                    .Where(e => e.PlayerId == id)
                    .FirstOrDefault());

                if (DTO_Player == null)
                {
                    throw new NullReferenceException($"Player with id={id} not found");
                }
                return DTO_Player;
            }
        }

        // How to return data from DB about created player?
        public static DTO.Model.Player AddPlayer(DTO.Model.Player player)
        {
            using (BasketballContext context = new BasketballContext())
            {
                EntityEntry<Player> returnValue = context.Players.Add(BasketballMapper.Map(player));
                context.SaveChanges();
                
                return BasketballMapper.Map(returnValue.Entity);
            }
        }

        public static List<DTO.Model.Player> GetAllPlayers()
        {
            using (BasketballContext context = new BasketballContext())
            {
                List<DTO.Model.Player> DTO_PlayerList = BasketballMapper.Map(context.Players.ToList());
                return DTO_PlayerList;
            }
        }

        public static void EditPlayer(DTO.Model.Player DTO_Player)
        {
            using (BasketballContext context = new BasketballContext())
            {
                Player dataAccess_Player = context.Players
                    .Where(p => p.PlayerId == DTO_Player.PlayerId)
                    .First();
                BasketballMapper.Update(DTO_Player, dataAccess_Player);
                context.SaveChanges();
            }
        }

        public static DTO.Model.Player DeletePlayer(int playerId)
        {
            using (BasketballContext context = new BasketballContext())
            {
                Player dataAccess_Player = context.Players
                    .Where(p => p.PlayerId == playerId)
                    .First();
                context.Remove(dataAccess_Player);
                context.SaveChanges();

                return BasketballMapper.Map(dataAccess_Player);
            }
        }
        public static DTO.Model.TeamDetail GetTeamDetail(int teamId)
        {
            using (BasketballContext context = new BasketballContext())
            {
                // Hvis den ikke kan findes, returnerer "FirstOrDefault()" null (ref typer) eller default værdi (value typer), dvs. 0 for int f.eks.
                // "First()" returnerer "InvalidOperationException", hvis der ikke kan findes noget
                DTO.Model.TeamDetail DTO_TeamDetail = BasketballMapper.Map(context.Teams
                    .Include(p => p.Players)
                    .Where(t => t.TeamId == teamId)
                    .FirstOrDefault());

                if (DTO_TeamDetail == null)
                {
                    throw new NullReferenceException($"Team with id={teamId} not found");
                }
                return DTO_TeamDetail;
            }
        }
        public static DTO.Model.TeamDetail AddTeam(DTO.Model.Team team)
        {
            using (BasketballContext context = new BasketballContext())
            {
                EntityEntry<Team> returnValue = context.Teams.Add(BasketballMapper.Map(team));
                context.SaveChanges();

                return BasketballMapper.Map(returnValue.Entity);
            }
        }
        public static List<DTO.Model.TeamDetail> GetAllTeams()
        {
            using (BasketballContext context = new BasketballContext())
            {
                List<DTO.Model.TeamDetail> DTO_TeamList = BasketballMapper.Map(context.Teams
                    .Include(p => p.Players)
                    .ToList());
                return DTO_TeamList;
            }
        }
        public static void AddPlayerToTeam(int playerId, int teamId)
        {
            using (BasketballContext context = new BasketballContext())
            {
                Player dataAccess_Player = context.Players
                    .Where(p => p.PlayerId == playerId)
                    .First();
                Team dataAccess_Team = context.Teams
                    .Where(t => t.TeamId == teamId)
                    .First();

                if (!dataAccess_Team.Players.Contains(dataAccess_Player))
                {
                    dataAccess_Team.Players.Add(dataAccess_Player);
                }
                context.SaveChanges();
            }
        }
        public static void RemovePlayersFromTeam(int teamId)
        {
            using (BasketballContext context = new BasketballContext())
            {
                Team dataAccess_Team = context.Teams
                    .Where(t => t.TeamId == teamId)
                    .Include(p => p.Players).First();
                dataAccess_Team.Players.Clear(); //Removes all linked players from team
                context.SaveChanges();
            }
        }
        public static DTO.Model.TeamDetail DeleteTeam(int teamId)
        {
            using (BasketballContext context = new BasketballContext())
            {
                Team dataAccess_Team = context.Teams
                    .Where(t => t.TeamId == teamId)
                    .First();
                context.Teams.Remove(dataAccess_Team);
                context.SaveChanges();

                return BasketballMapper.Map(dataAccess_Team);
            }
        }
        public static DTO.Model.SponsorshipDetail GetSponsorshipDetail(int sposorshipId)
        {
            using (BasketballContext context = new BasketballContext())
            {
                DTO.Model.SponsorshipDetail DTO_SponsorshipDetail = BasketballMapper.Map(context.Sponsorships
                    .Include(p => p.Players)
                    .Where(s => s.SponsorshipId == sposorshipId)
                    .FirstOrDefault());

                if (DTO_SponsorshipDetail == null)
                {
                    throw new NullReferenceException($"Team with id={sposorshipId} not found");
                }
                return DTO_SponsorshipDetail;
            }
        }
        public static void AddPlayerToSponsorship(int playerId, int sponsorshipId)
        {
            using (BasketballContext context = new BasketballContext())
            {
                Player dataAccess_Player = context.Players
                    .Where(p => p.PlayerId == playerId)
                    .First();
                Sponsorship dataAccess_Sponsorship = context.Sponsorships
                    .Where(s => s.SponsorshipId == sponsorshipId)
                    .First();

                if (!dataAccess_Sponsorship.Players.Contains(dataAccess_Player))
                {
                    dataAccess_Sponsorship.Players.Add(dataAccess_Player);
                }
                context.SaveChanges();
            }
        }
    }
}
