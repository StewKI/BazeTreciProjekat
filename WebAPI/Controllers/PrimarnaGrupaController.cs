using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PrimarnaGrupaController : ControllerBase
{
    [HttpPost]
    public IActionResult AddPrimarnaGrupa([FromBody] PrimarnaGrupaBasic dto)
    {
        try
        {
            DTOManagerLek.DodajPrimarnuGrupu(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }
}