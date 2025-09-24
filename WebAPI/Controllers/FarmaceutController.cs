using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FarmaceutController : ControllerBase
{
    [HttpGet]
    [Route("{id:long}")]
    public IActionResult GetOdgFarmaceut(long id)
    {
        try
        {
            return new JsonResult(DTOManagerZaposleni.VratiOdgovornogFarmaceuta(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpPost]
    public IActionResult AddFarmaceut([FromBody] FarmaceutBasic dto)
    {
        try
        {
            DTOManagerZaposleni.DodajFarmaceuta(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }

    [HttpPut]
    public IActionResult ChangeFarmaceut([FromBody] FarmaceutBasic dto)
    {
        try
        {
            DTOManagerZaposleni.UpdateFarmaceuta(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Ok();
    }
}