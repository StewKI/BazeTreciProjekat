using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenadzerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMenadzeri()
        {
            try
            {
                return new JsonResult(DTOManagerZaposleni.VratiSveMenadzere());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMenadzer(long id)
        {
            try
            {
                var menadzer = DTOManagerZaposleni.VratiMenadzera(id);
                if (menadzer == null)
                {
                    return NotFound();
                }
                return new JsonResult(menadzer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("apoteka/{idApoteke:long}")]
        public IActionResult GetMenadzerApoteka(long idApoteke)
        {
            try
            {
                return new JsonResult(DTOManagerProdajneJedinice.VratiMenadzereZaApoteku(idApoteke));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddMenadzer([FromBody] MenadzerBasic dto)
        {
            try
            {
                DTOManagerZaposleni.DodajMenadzera(dto);
                return CreatedAtAction(nameof(GetMenadzer), new { id = dto.Id }, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult ChangeMenadzer([FromBody] MenadzerBasic dto)
        {
            try
            {
                DTOManagerZaposleni.UpdateMenadzera(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
