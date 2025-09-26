using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PakovanjeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPakovanja()
        {
            try
            {
                return new JsonResult(DTOManagerLek.VratiSvaPakovanja());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPakovanje(long id)
        {
            try
            {
                var pakovanje = DTOManagerLek.VratiPakovanje(id);
                if (pakovanje == null)
                {
                    return NotFound();
                }
                return new JsonResult(pakovanje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostPakovanje([FromBody] PakovanjeBasic pakovanje)
        {
            try
            {
                var pakovanjeId = DTOManagerLek.DodajPakovanje(pakovanje);
                return CreatedAtAction(nameof(GetPakovanje), new { id = pakovanjeId }, pakovanje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutPakovanje([FromBody] PakovanjeBasic pakovanje)
        {
            try
            {
                DTOManagerLek.IzmeniPakovanje(pakovanje);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePakovanje(long id)
        {
            try
            {
                DTOManagerLek.ObrisiPakovanje(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
