using FarmacyLibrary;
using FarmacyLibrary.Entiteti;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SpecijalizovanaApotekaController : ControllerBase
{
    [HttpPost]
    public IActionResult AddSpecApoteka([FromBody] SpecijalizovanaApoteka dto)
    {
        try
        {
            DTOManagerProdajneJedinice.DodajSpecApoteku(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Created();
    }

    [HttpPut]
    public IActionResult ChangeSpecApoteka([FromBody] SpecijalizovanaApoteka dto)
    {
        try
        {
            DTOManagerProdajneJedinice.IzmeniSpecApoetku(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }
}