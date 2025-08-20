using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MenadzerApotekaController : ControllerBase
{
    [HttpGet]
    [Route("menadzer/{idMenadzera:long}")]
    public IActionResult GetApotekeZaMenadzera(long idMenadzera)
    {
        try
        {
            return new JsonResult(DTOManager.VratiApotekeMenadzera(idMenadzera));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpPost]
    public IActionResult AddMenadzerApoteka([FromBody] MenadzerApotekaBasic dto)
    {
        try
        {
            DTOManager.DodeliMenadzeraApoteci(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }

    [HttpPut]
    public IActionResult ChangeMenadzerApoteka([FromBody] MenadzerApotekaBasic dto)
    {
        try
        {
            DTOManager.IzmeniMenadzerApoteka(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Ok();   
    }

    [HttpDelete]
    [Route("{menadzer_id:long}/{apoteka_id:long}")]
    public IActionResult DeleteMenadzerApoteka(long menadzer_id, long apoteka_id)
    {
        try
        {
            DTOManager.UkloniMenadzeraSaApoteke(apoteka_id, menadzer_id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Ok();  
    }
}