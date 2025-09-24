using FarmacyLibrary;
using FarmacyLibrary.Entiteti;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ApotekaSaLabController : ControllerBase
{
    [HttpPost]
    public IActionResult AddApotekaSaLab([FromBody] ApotekaSaLabBasic dto)
    {
        try
        {
            DTOManagerProdajneJedinice.DodajApotekuSaLab(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }

    [HttpPut]
    public IActionResult ChangeApotekaSaLab([FromBody] ApotekaSaLabBasic dto)
    {
        try
        {
            DTOManagerProdajneJedinice.IzmeniApoetkuSaLab(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Ok();
    }
}