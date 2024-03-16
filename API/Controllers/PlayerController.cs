using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpGet]
        // GET til "api/player/" lander her
        public List<Player> Get()
        {
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            try
            {
                List<DTO.Model.Player> playersDTO = basketballBLL.GetAllPlayers();
                List<Player> playersGUI = new List<Player>();

                foreach (DTO.Model.Player p in playersDTO)
                {
                    playersGUI.Add(new Player(p));
                }

                return playersGUI;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public Player Get(int id)
        {
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            try
            {
                DTO.Model.Player playerDTO = basketballBLL.GetPlayer(id);

                return new Player(playerDTO);
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public Player Post(DTO.Model.Player player)
        {
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            DTO.Model.Player DTOp = basketballBLL.AddPlayer(player);
            return new Player(DTOp);
        }

        [Route("{id}")]
        [HttpDelete]
        public Player Delete(int id)
        {
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            try
            {
                DTO.Model.Player playerDTO = basketballBLL.DeletePlayer(id);
                return new Player(playerDTO);
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
