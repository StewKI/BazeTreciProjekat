using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LekController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLekovi()
        {
            try
            {
                return new JsonResult(DTOManagerLek.VratiSveLekove());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetLek(long id)
        {
            try
            {
                var lek = DTOManagerLek.VratiLek(id);
                if (lek == null)
                {
                    return NotFound();
                }
                return new JsonResult(lek);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostLek([FromBody] LekBasic lek)
        {
            try
            {
                var lekId = DTOManagerLek.DodajLek(lek);
                return CreatedAtAction(nameof(GetLek), new { id = lekId }, lek);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutLek([FromBody] LekBasic lek)
        {
            try
            {
                DTOManagerLek.IzmeniLek(lek);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLek(long id)
        {
            try
            {
                DTOManagerLek.ObrisiLek(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{lekId}/sekundarnakategorija/{skId}")]
        public IActionResult DodajLekSekundarna(long lekId, long skId)
        {
            try
            {
                DTOManagerLek.DodajLekSekundarna(skId, lekId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
