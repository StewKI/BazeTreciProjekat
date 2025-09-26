using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdajnaJedinicaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProdajneJedinice()
        {
            return new JsonResult(DTOManagerProdajneJedinice.VratiSveProdajneJedinice());
        }

        [HttpGet("osnovne")]
        public IActionResult GetOsnovneProdajneJedinice()
        {
            return new JsonResult(DTOManagerProdajneJedinice.VratiOsnovneProdajneJedinice());
        }

        [HttpGet("{id:long}")]
        public IActionResult GetProdajnaJedinica(long id)
        {
            try
            {
                return new JsonResult(DTOManagerProdajneJedinice.VratiProdajnuJedinicu(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("tip/{id:long}")]
        public IActionResult GetProdajnaJedinicaTip(long id)
        {
            try
            {
                return new JsonResult(DTOManagerProdajneJedinice.VratiProdajnuJedinicuTip(id));
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
                DTOManagerProdajneJedinice.DodajProdajnuJedinicu(dto);
                return CreatedAtAction(nameof(GetProdajnaJedinica), new { id = dto.Id }, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public IActionResult ChangeProdajnaJedinica([FromBody] ProdajnaJedinicaBasic dto)
        {
            try
            {
                DTOManagerProdajneJedinice.IzmeniProdajnuJedinicu(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{id:long}")]
        public IActionResult DeleteProdajnaJedinica(long id)
        {
            try
            {
                DTOManagerProdajneJedinice.ObrisiProdajnuJedinicu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // Radno Vreme
        [HttpGet("{id}/radnovreme")]
        public IActionResult GetRadnoVreme(long id)
        {
            try
            {
                return new JsonResult(DTOManagerProdajneJedinice.VratiRadnoVremeZaProdajnuJedinicu(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/radnovreme/{dan}")]
        public IActionResult GetRadnoVreme(long id, int dan)
        {
            try
            {
                return new JsonResult(DTOManagerProdajneJedinice.VratiRadnoVreme(id, dan));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("radnovreme")]
        public IActionResult AddRadnoVreme([FromBody] RadnoVremeBasic dto)
        {
            try
            {
                DTOManagerProdajneJedinice.DodajRadnoVreme(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("radnovreme")]
        public IActionResult UpdateRadnoVreme([FromBody] RadnoVremeBasic dto)
        {
            try
            {
                DTOManagerProdajneJedinice.IzmeniRadnoVreme(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}/radnovreme/{dan}")]
        public IActionResult DeleteRadnoVreme(long id, int dan)
        {
            try
            {
                DTOManagerProdajneJedinice.ObrisiRadnoVreme(id, dan);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Zaposleni & Raspored
        [HttpGet("{id}/farmaceuti")]
        public IActionResult GetFarmaceuti(long id)
        {
            try
            {
                return new JsonResult(DTOManagerProdajneJedinice.VratiSveFarmaceuteZaApoteku(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/menadzeri")]
        public IActionResult GetMenadzeri(long id)
        {
            try
            {
                return new JsonResult(DTOManagerProdajneJedinice.VratiMenadzereZaApoteku(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/rasporedrada")]
        public IActionResult GetRasporedRadaZaProdajnuJedinicu(long id)
        {
            try
            {
                return new JsonResult(DTOManagerZaposleni.VratiRasporedRadaZaProdajnuJedinicu(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("standardne")]
        public IActionResult GetStandardneApoteke()
        {
            try
            {
                return new JsonResult(DTOManagerProdajneJedinice.VratiStandardneApoteke());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("specijalizovane")]
        public IActionResult GetSpecijalizovaneApoteke()
        {
            try
            {
                return new JsonResult(DTOManagerProdajneJedinice.VratiSpecijalizovaneApoteke());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
