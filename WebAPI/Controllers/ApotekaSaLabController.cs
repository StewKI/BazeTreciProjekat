using FarmacyLibrary;
using FarmacyLibrary.Entiteti;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ApotekaSaLabController : ControllerBase
{
    [HttpPost]
    public IActionResult AddApotekaSaLab([FromBody] ApotekaSaLab dto)
    {
        try
        {
            DTOManager.DodajApotekuSaLab(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }

    [HttpPut]
    public IActionResult ChangeApotekaSaLab([FromBody] ApotekaSaLab dto)
    {
        try
        {
            DTOManager.IzmeniApoetkuSaLab(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Ok();
    }
}