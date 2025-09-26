
using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenadzerApotekaController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddMenadzerApoteka([FromBody] MenadzerApotekaBasic dto)
        {
            try
            {
                DTOManagerProdajneJedinice.DodajMenadzerApoteka(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateMenadzerApoteka([FromBody] MenadzerApotekaBasic dto)
        {
            try
            {
                DTOManagerProdajneJedinice.IzmeniMenadzerApoteka(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("menadzer/{id}")]
        public IActionResult GetApotekeMenadzera(long id)
        {
            try
            {
                return new JsonResult(DTOManagerProdajneJedinice.VratiApotekeMenadzera(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idApoteke}/menadzer/{idMenadzera}")]
        public IActionResult DeleteMenadzerApoteka(long idApoteke, long idMenadzera)
        {
            try
            {
                DTOManagerProdajneJedinice.UkloniMenadzeraSaApoteke(idApoteke, idMenadzera);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
