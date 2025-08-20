using System.Diagnostics;
using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SekundarnaKategorijaController : ControllerBase
{
    [HttpPost]
    public IActionResult AddSekundarnaKategorija([FromBody] SekundarnaKategorijaBasic dto)
    {
        try
        {
            DTOManager.DodajSekundarnuKategoriju(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }
}