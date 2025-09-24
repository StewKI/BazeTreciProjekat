using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OblikController : ControllerBase
{
    [HttpPost]
    public IActionResult AddOblik([FromBody] OblikBasic dto)
    {
        try
        {
            DTOManagerLek.DodajOblik(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }
}