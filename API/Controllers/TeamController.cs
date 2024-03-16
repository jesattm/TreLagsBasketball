using API.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        // GET: api/<TeamController>
        [HttpGet]
        public List<TeamDetail> GetAll()
        {
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            try
            {
                List<DTO.Model.TeamDetail> teamsDTO = basketballBLL.GetAllTeams();
                List<TeamDetail> teamsAPI = new List<TeamDetail>();

                foreach (DTO.Model.TeamDetail t in teamsDTO)
                {
                    teamsAPI.Add(new TeamDetail(t));
                }

                return teamsAPI;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET api/<TeamController>/5
        [HttpGet("{id}")]
        public TeamDetail Get(int id)
        {
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            try
            {
                DTO.Model.TeamDetail teamDTO = basketballBLL.GetTeamDetail(id);

                return new TeamDetail(teamDTO);
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST api/<TeamController>
        [HttpPost]
        public TeamDetail Post(DTO.Model.Team team)
        {
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            DTO.Model.TeamDetail DTOtd = basketballBLL.AddTeam(team);
            return new TeamDetail(DTOtd);
        }

        // DELETE api/<TeamController>/5
        [HttpDelete("{id}")]
        public TeamDetail Delete(int id)
        {
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            try
            {
                basketballBLL.RemovePlayersFromTeam(id);
                return new TeamDetail(basketballBLL.DeleteTeam(id));
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{playerId}/{teamId}")]
        public void AddPlayerToTeam(int playerId, int teamId)
        {
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            basketballBLL.AddPlayerToTeam(playerId, teamId);
        }
    }
}
