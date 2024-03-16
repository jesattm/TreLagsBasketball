using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_GUI.Models;

namespace MVC_GUI.Controllers
{
    [Route("Team")]
    public class TeamDetailController : Controller
    {
        // Both "team/index" and "/team" works
        [HttpGet("")]
        //[Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        // Both "team/index" and "/team" works
        [HttpPost("")]
        //[Route("Index")]
        public IActionResult Index(IFormCollection formCollection)
        {
            int id = Convert.ToInt32(formCollection["TeamId"]);

            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();

            try
            {
                DTO.Model.TeamDetail teamDetail = basketballBLL.GetTeamDetail(id);
                return View(new Models.TeamDetail(teamDetail));
            }
            catch (ArgumentNullException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new Models.TeamDetail());
            }
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        public IActionResult Create(string teamName)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", new TeamDetail());
            }
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            DTO.Model.Team t = new DTO.Model.Team(teamName);
            DTO.Model.TeamDetail pReturn = basketballBLL.AddTeam(t);

            return View(new TeamDetail(pReturn));
        }

        [HttpGet("AddPlayerToTeam")]
        public IActionResult AddPlayerToTeam()
        {
            return View();
        }

        [HttpPost("AddPlayerToTeam")]
        public IActionResult AddPlayerToTeam(int playerId, int teamId)
        {
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            basketballBLL.AddPlayerToTeam(playerId, teamId);

            ViewBag.success = true;

            return View();
        }
    }
}
