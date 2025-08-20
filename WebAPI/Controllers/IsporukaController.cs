using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class IsporukaController : ControllerBase
{
    [HttpPost]
    public IActionResult AddIsporuka([FromBody] IsporukaBasic dto)
    {
        try
        {
            DTOManager.KreirajIsporuku(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }
}