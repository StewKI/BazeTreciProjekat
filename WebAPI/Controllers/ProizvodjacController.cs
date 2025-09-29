using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodjacController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProizvodjaci()
        {
            try
            {
                return new JsonResult(DTOManagerIsporukeZalihe.VratiSveProizvodjace());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProizvodjac(long id)
        {
            try
            {
                var proizvodjac = DTOManagerIsporukeZalihe.VratiProizvodjaca(id);
                if (proizvodjac == null)
                {
                    return BadRequest($"Proizvođač sa ID {id} nije pronađen.");
                }
                return new JsonResult(proizvodjac);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostProizvodjac([FromBody] ProizvodjacBasic proizvodjac)
        {
            try
            {
                DTOManagerIsporukeZalihe.DodajProizvodjaca(proizvodjac);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutProizvodjac([FromBody] ProizvodjacBasic proizvodjac)
        {
            try
            {
                DTOManagerIsporukeZalihe.IzmeniProizvodjaca(proizvodjac);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProizvodjac(long id)
        {
            try
            {
                DTOManagerIsporukeZalihe.ObrisiProizvodjaca(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
