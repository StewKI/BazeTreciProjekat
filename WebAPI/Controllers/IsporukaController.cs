using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

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
            var id = DTOManagerIsporukeZalihe.KreirajIsporuku(dto);
            return Ok(new { Id = id });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}