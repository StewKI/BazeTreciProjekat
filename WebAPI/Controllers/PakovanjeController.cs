using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PakovanjeController : ControllerBase
{
    [HttpPost]
    public IActionResult AddPakovanje([FromBody] PakovanjeBasic dto)
    {
        try
        {
            DTOManagerLek.DodajPakovanje(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Created();
    }
}