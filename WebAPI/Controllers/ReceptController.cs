using FarmacyLibrary;
using FarmacyLibrary.Entiteti;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    public class RealizujReceptRequest
    {
        public long ProdajnaJedinicaId { get; set; }
        public DateTime Datum { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class ReceptController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRecepti()
        {
            try
            {
                return new JsonResult(DTOManagerProdaja.VratiSveRecepte());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{serijskiBroj}")]
        public IActionResult GetRecept(string serijskiBroj)
        {
            try
            {
                var recept = DTOManagerIsporukeZalihe.VratiRecept(serijskiBroj);
                if (recept == null)
                {
                    return NotFound();
                }
                return new JsonResult(recept);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostRecept([FromBody] Recept recept)
        {
            try
            {
                DTOManagerIsporukeZalihe.DodajRecept(recept);
                return CreatedAtAction(nameof(GetRecept), new { serijskiBroj = recept.SerijskiBroj }, recept);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{serijskiBroj}")]
        public IActionResult DeleteRecept(string serijskiBroj)
        {
            try
            {
                DTOManagerIsporukeZalihe.ObrisiRecept(serijskiBroj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{serijskiBroj}/realizuj")]
        public IActionResult RealizujRecept(string serijskiBroj, [FromBody] RealizujReceptRequest request)
        {
            try
            {
                DTOManagerIsporukeZalihe.RealizujRecept(serijskiBroj, request.ProdajnaJedinicaId, request.Datum);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("stavka")]
        public IActionResult PostReceptStavka([FromBody] ReceptStavkaBasic stavka)
        {
             try
            {
                DTOManagerIsporukeZalihe.DodajReceptStavku(stavka);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
