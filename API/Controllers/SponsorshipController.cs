using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorshipController : ControllerBase
    {
        // GET api/<TeamController>/5
        [HttpGet("{id}")]
        public SponsorshipDetail Get(int id)
        {
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            try
            {
                DTO.Model.SponsorshipDetail sponsorshipDTO = basketballBLL.GetSponsorship(id);

                return new SponsorshipDetail(sponsorshipDTO);
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{playerId}/{sponsorshipId}")]
        public void AddPlayerToSponsorship(int playerId, int sponsorshipId)
        {
            BusinessLogic.BLL.BasketballBLL basketballBLL = new BusinessLogic.BLL.BasketballBLL();
            basketballBLL.AddPlayerToSponsorship(playerId, sponsorshipId);
        }
    }
}
