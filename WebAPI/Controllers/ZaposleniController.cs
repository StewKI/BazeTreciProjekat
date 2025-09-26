using FarmacyLibrary;
using FarmacyLibrary.Entiteti;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
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
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetZaposleni(long id)
        {
            try
            {
                var zaposleni = DTOManagerZaposleni.VratiZaposlenog(id);
                if (zaposleni == null)
                {
                    return NotFound();
                }
                return new JsonResult(zaposleni);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostZaposleni([FromBody] ZaposleniBasic zaposleni)
        {
            try
            {
                DTOManagerZaposleni.DodajZaposlenog(zaposleni);
                return CreatedAtAction(nameof(GetZaposleni), new { id = zaposleni.Id }, zaposleni);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutZaposleni([FromBody] ZaposleniBasic zaposleni)
        {
            try
            {
                DTOManagerZaposleni.UpdateZaposlenog(zaposleni);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteZaposleni(long id)
        {
            try
            {
                DTOManagerZaposleni.ObrisiZaposlenog(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
