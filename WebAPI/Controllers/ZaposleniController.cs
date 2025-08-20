using FarmacyLibrary;
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
            return new JsonResult(DTOManager.VratiSveZaposlene());
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
            return new JsonResult(DTOManager.VratiZaposlenog(m_br));
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
            DTOManager.DodajZaposlenog(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Created();
    }

    [HttpPut]
    public IActionResult ChangeZaposleni([FromBody] ZaposleniBasic dto)
    {
        try
        {
            DTOManager.UpdateZaposlenog(dto);
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
            DTOManager.ObrisiZaposlenog(mbr);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Ok();
    }
}