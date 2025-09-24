using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ZalihaController : ControllerBase
{
    [HttpGet]
    [Route("apoteka/{idApoteke}")]
    public IActionResult GetZaliheApoteke(long idApoteke)
    {
        try
        {
            return new JsonResult(DTOManagerIsporukeZalihe.VratiZaliheApoteke(idApoteke));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}