using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProizvodjacController : ControllerBase
{
    [HttpPost]
    public IActionResult AddProizvodjac([FromBody] ProizvodjacBasic dto)
    {
        try
        {
            DTOManager.DodajProizvodjaca(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }
}