using FarmacyLibrary;
using FarmacyLibrary.Entiteti;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StandardnaApotekaController : ControllerBase
{
    [HttpPost]
    public IActionResult AddStandApoteka([FromBody] StandardnaApoteka dto)
    {
        try
        {
            DTOManagerProdajneJedinice.DodajStandardnuApoteku(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }

    [HttpPut]
    public IActionResult ChangeStandApoteka([FromBody] StandardnaApoteka dto)
    {
        try
        {
            DTOManagerProdajneJedinice.IzmeniSApoetku(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Ok();
    }
}