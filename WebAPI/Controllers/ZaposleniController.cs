using FarmacyLibrary;
using FarmacyLibrary.Entiteti;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ZaposleniController : ControllerBase
{
    [HttpGet]
    public IActionResult GetZaposleni()
    {
        try
        {
            return new JsonResult(DTOManagerZaposleni.VratiSveZaposlene());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
    
    [HttpGet]
    [Route("{m_br:long}")]
    public IActionResult GetZaposleni(long m_br)
    {
        try
        {
            return new JsonResult(DTOManagerZaposleni.VratiZaposlenog(m_br));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpPost]
    public IActionResult AddZaposleni([FromBody] ZaposleniBasic dto)
    {
        try
        {
            DTOManagerZaposleni.DodajZaposlenog(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }

    [HttpPut]
    public IActionResult ChangeZaposleni([FromBody] Zaposleni dto)
    {
        try
        {
            DTOManagerZaposleni.UpdateZaposlenog(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Ok();
    }

    [HttpDelete]
    [Route("{mbr:long}")]
    public IActionResult DeleteZaposleni(long mbr)
    {
        try
        {
            DTOManagerZaposleni.ObrisiZaposlenog(mbr);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Ok();
    }
}