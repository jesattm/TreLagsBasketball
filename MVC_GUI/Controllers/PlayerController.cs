using DTO.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MVC_GUI.Controllers
{
    public class PlayerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection formCollection)
        {
            int id = Convert.ToInt32(formCollection["PlayerId"]);

            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();

            try
            {
                DTO.Model.Player player = basketballBLL.GetPlayer(id);
                return View(new Models.Player(player.PlayerId, player.Name, player.Position));
            }
            catch (ArgumentNullException ex)
            {
                return View("PlayerNotFound", ex);
            }

        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult PlayerCreatedSimpleTypes(string name, Position position)
        {
            // Validation server side
            if (!ModelState.IsValid)
            {
                return View("Create", new MVC_GUI.Models.Player());
            }
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            DTO.Model.Player p = new DTO.Model.Player(name, position);
            DTO.Model.Player pReturn = basketballBLL.AddPlayer(p);

            return View("PlayerCreated", new MVC_GUI.Models.Player(pReturn.PlayerId, pReturn.Name, pReturn.Position));
        }
    }
}
