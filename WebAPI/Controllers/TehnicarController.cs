using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TehnicarController : ControllerBase
{
    [HttpPost]
    public IActionResult AddTehnicar([FromBody] TehnicarBasic dto)
    {
        try
        {
            DTOManagerZaposleni.DodajTehnicara(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }

    [HttpPut]
    public IActionResult ChangeTehnicar([FromBody] TehnicarBasic dto)
    {
        try
        {
            DTOManagerZaposleni.UpdateTehnicara(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }

        return Ok();
    }
}