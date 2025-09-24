using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MenadzerController : ControllerBase
{
    [HttpGet]
    [Route("apoteka/{idApoteke:long}")]
    public IActionResult GetMenadzerApoteka(long idApoteke)
    {
        try
        {
            return new JsonResult(DTOManagerProdajneJedinice.VratiMenadzereZaApoteku(idApoteke));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
    
    [HttpPost]
    public IActionResult AddMenadzer([FromBody] MenadzerBasic dto)
    {
        try
        {
            DTOManagerZaposleni.DodajMenadzera(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }

    [HttpPut]
    public IActionResult ChangeMenadzer([FromBody] MenadzerBasic dto)
    {
        try
        {
            DTOManagerZaposleni.UpdateMenadzera(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }

        return Ok();
    }
}