using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TehnicarController : ControllerBase
    {
        [HttpGet("{mbr}")]
        public IActionResult GetTehnicar(long mbr)
        {
            try
            {
                var tehnicar = DTOManagerZaposleni.VratiTehnicara(mbr);
                if (tehnicar == null)
                {
                    return NotFound();
                }
                return new JsonResult(tehnicar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult AddTehnicar([FromBody] TehnicarBasic dto)
        {
            try
            {
                DTOManagerZaposleni.DodajTehnicara(dto);
                return CreatedAtAction(nameof(GetTehnicar), new { mbr = dto.Id }, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public IActionResult ChangeTehnicar([FromBody] TehnicarBasic dto)
        {
            try
            {
                DTOManagerZaposleni.UpdateTehnicara(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
