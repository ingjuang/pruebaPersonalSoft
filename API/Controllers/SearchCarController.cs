using API.DTO;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SearchCarController : Controller
    {
        private readonly ISearchCar _searchCarService;

        public SearchCarController(ISearchCar service)
        {
            _searchCarService = service;
        }

        [HttpPost]
        public async Task<ActionResult> SearchCarByLocation([FromBody]FindCarByParametersDTO DTO)
        {
            PetitionResponse res = await _searchCarService.FindCarByParameters(DTO);
            if(res.Success)
            {

                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}
