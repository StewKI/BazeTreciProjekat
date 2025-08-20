using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LekController : ControllerBase
{
    [HttpGet]
    public IActionResult GetLekovi()
    {
        try
        {
            return new JsonResult(DTOManager.VratiSveLekove());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult AddLek([FromBody] LekBasic dto)
    {
        try
        {
            DTOManager.DodajLek(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }
}