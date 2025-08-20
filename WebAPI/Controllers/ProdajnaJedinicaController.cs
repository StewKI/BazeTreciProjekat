using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdajnaJedinicaController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProdajneJedinice()
    {
        return new JsonResult(DTOManager.VratiSveProdajneJedinice());
    }
    
    [HttpGet]
    [Route("{id:long}")]
    public IActionResult GetProdajnaJedinica(long id)
    {
        try
        {
            return new JsonResult(DTOManager.VratiProdajnuJedinicu(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
    
    [HttpGet]
    [Route("tip/{id:long}")]
    public IActionResult GetProdajnaJedinicaTip(long id)
    {
        try
        {
            return new JsonResult(DTOManager.VratiProdajnuJedinicuTip(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpPost]
    public IActionResult AddProdajnaJedinica([FromBody] ProdajnaJedinicaBasic dto)
    {
        try
        {
            DTOManager.DodajProdajnuJedinicu(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }

        return Created();
    }

    [HttpPut]
    public IActionResult ChangeProdajnaJedinica([FromBody] ProdajnaJedinicaBasic dto)
    {
        try
        {
            DTOManager.IzmeniProdajnuJedinicu(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Ok();
    }

    [HttpDelete]
    [Route("{id:long}")]
    public IActionResult DeleteProdajnaJedinica(long id)
    {
        try
        {
            DTOManager.ObrisiProdajnuJedinicu(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        return Ok();   
    }
}