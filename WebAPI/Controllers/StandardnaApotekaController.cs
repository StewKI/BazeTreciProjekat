using FarmacyLibrary;
using FarmacyLibrary.Entiteti;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StandardnaApotekaController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddStandardnaApoteka([FromBody] StandardnaApotekaBasic dto)
        {
            try
            {
                DTOManagerProdajneJedinice.DodajStandardnuApoteku(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public IActionResult ChangeStandardnaApoteka([FromBody] StandardnaApotekaBasic dto)
        {
            try
            {
                DTOManagerProdajneJedinice.IzmeniSApoetku(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
