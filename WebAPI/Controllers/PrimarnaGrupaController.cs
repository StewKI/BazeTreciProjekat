using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimarnaGrupaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPrimarneGrupe()
        {
            try
            {
                return new JsonResult(DTOManagerLek.VratiPrimarneGrupe());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPrimarnaGrupa(long id)
        {
            try
            {
                var grupa = DTOManagerLek.VratiPrimarnuGrupu(id);
                if (grupa == null)
                {
                    return NotFound();
                }
                return new JsonResult(grupa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostPrimarnaGrupa([FromBody] PrimarnaGrupaBasic grupa)
        {
            try
            {
                var grupaId = DTOManagerLek.DodajPrimarnuGrupu(grupa);
                return CreatedAtAction(nameof(GetPrimarnaGrupa), new { id = grupaId }, grupa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutPrimarnaGrupa([FromBody] PrimarnaGrupaBasic grupa)
        {
            try
            {
                DTOManagerLek.IzmeniPrimarnuGrupu(grupa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePrimarnaGrupa(long id)
        {
            try
            {
                DTOManagerLek.ObrisiPrimarnuGrupu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
