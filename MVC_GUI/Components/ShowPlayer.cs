using DTO.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MVC_GUI.Components
{
    public class ShowPlayer : ViewComponent
    {
        public IViewComponentResult Invoke(MVC_GUI.Models.Player p)
        {
            // Change type from DTO.Models.Player to MVC_GUI.Models.Player
            // MVC_GUI.Models.Player has method to show postion as a string
            //MVC_GUI.Models.Player mvcPlayer = new MVC_GUI.Models.Player(p.PlayerId, p.Name, p.Position);
            return View(p);
        }
    }
}
