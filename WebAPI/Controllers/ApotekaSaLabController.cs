using FarmacyLibrary;
using FarmacyLibrary.Entiteti;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApotekaSaLabController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetApotekeSaLab()
        {
            try
            {
                var dto = DTOManagerProdajneJedinice.VratiApotekeSaLab();
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetApotekaSaLab(long id)
        {
            try
            {
                var apoteka = DTOManagerProdajneJedinice.VratiProdajnuJedinicuTip(id);
                if (apoteka == null || !(apoteka is ApotekaSaLabBasic))
                {
                    return BadRequest($"Apoteka sa laboratorijom sa ID {id} nije pronađena.");
                }
                return new JsonResult(apoteka);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddApotekaSaLab([FromBody] ApotekaSaLabBasic dto)
        {
            try
            {
                DTOManagerProdajneJedinice.DodajApotekuSaLab(dto);
                return CreatedAtAction(nameof(GetApotekaSaLab), new { id = dto.Id }, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult ChangeApotekaSaLab([FromBody] ApotekaSaLabBasic dto)
        {
            try
            {
                DTOManagerProdajneJedinice.IzmeniApotekuSaLab(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
