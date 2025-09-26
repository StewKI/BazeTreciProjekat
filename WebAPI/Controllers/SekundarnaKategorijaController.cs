using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SekundarnaKategorijaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSekundarneKategorije()
        {
            try
            {
                return new JsonResult(DTOManagerIsporukeZalihe.VratiSveSekundarneKategorije());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSekundarnaKategorija(long id)
        {
            try
            {
                var kategorija = DTOManagerIsporukeZalihe.VratiSekundarnuGrupu(id);
                if (kategorija == null)
                {
                    return NotFound();
                }
                return new JsonResult(kategorija);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostSekundarnaKategorija([FromBody] SekundarnaKategorijaBasic kategorija)
        {
            try
            {
                DTOManagerIsporukeZalihe.DodajSekundarnuGrupu(kategorija);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutSekundarnaKategorija([FromBody] SekundarnaKategorijaBasic kategorija)
        {
            try
            {
                DTOManagerIsporukeZalihe.IzmeniSekundarnuGrupu(kategorija);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSekundarnaKategorija(long id)
        {
            try
            {
                DTOManagerIsporukeZalihe.ObrisiSekundarnuGrupu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
