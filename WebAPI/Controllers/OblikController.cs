using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OblikController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOblici()
        {
            try
            {
                return new JsonResult(DTOManagerLek.VratiSveOblikeLekova());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOblik(long id)
        {
            try
            {
                var oblik = DTOManagerLek.VratiOblikBasic(id);
                if (oblik == null)
                {
                    return NotFound();
                }
                return new JsonResult(oblik);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostOblik([FromBody] OblikBasic oblik)
        {
            try
            {
                var oblikId = DTOManagerLek.DodajOblik(oblik);
                return CreatedAtAction(nameof(GetOblik), new { id = oblikId }, oblik);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutOblik([FromBody] OblikBasic oblik)
        {
            try
            {
                DTOManagerLek.IzmeniOblik(oblik);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOblik(long id)
        {
            try
            {
                DTOManagerLek.ObrisiOblik(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
