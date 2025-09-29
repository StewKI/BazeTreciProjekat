using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZalihaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetZalihe()
        {
            try
            {
                return new JsonResult(DTOManagerIsporukeZalihe.VratiSveZalihe());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("apoteka/{prodajnaJedinicaId}")]
        public IActionResult GetZaliheApoteke(long prodajnaJedinicaId)
        {
            try
            {
                return new JsonResult(DTOManagerIsporukeZalihe.VratiZaliheApoteke(prodajnaJedinicaId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{prodajnaJedinicaId}/{pakovanjeId}")]
        public IActionResult GetZaliha(long prodajnaJedinicaId, long pakovanjeId)
        {
            try
            {
                var zaliha = DTOManagerIsporukeZalihe.VratiZalihu(prodajnaJedinicaId, pakovanjeId);
                if (zaliha == null)
                {
                    return BadRequest($"Zaliha za prodajnu jedinicu {prodajnaJedinicaId} i pakovanje {pakovanjeId} nije pronađena.");
                }
                return new JsonResult(zaliha);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostZaliha([FromBody] ZalihaBasic zaliha)
        {
            try
            {
                DTOManagerIsporukeZalihe.DodajZalihu(zaliha);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutZaliha([FromBody] ZalihaBasic zaliha)
        {
            try
            {
                DTOManagerIsporukeZalihe.IzmeniZalihu(zaliha);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{prodajnaJedinicaId}/{pakovanjeId}")]
        public IActionResult DeleteZaliha(long prodajnaJedinicaId, long pakovanjeId)
        {
            try
            {
                DTOManagerIsporukeZalihe.ObrisiZalihu(prodajnaJedinicaId, pakovanjeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
