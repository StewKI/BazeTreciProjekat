using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FarmaceutController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFarmaceuti()
        {
            try
            {
                return new JsonResult(DTOManagerProdajneJedinice.VratiSveFarmaceuteUSistemu());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFarmaceut(long id)
        {
            try
            {
                var farmaceut = DTOManagerZaposleni.VratiFarmaceuta(id);
                if (farmaceut == null)
                {
                    return NotFound();
                }
                return new JsonResult(farmaceut);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddFarmaceut([FromBody] FarmaceutBasic dto)
        {
            try
            {
                DTOManagerZaposleni.DodajFarmaceuta(dto);
                return CreatedAtAction(nameof(GetFarmaceut), new { id = dto.Id }, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult ChangeFarmaceut([FromBody] FarmaceutBasic dto)
        {
            try
            {
                DTOManagerZaposleni.UpdateFarmaceuta(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
