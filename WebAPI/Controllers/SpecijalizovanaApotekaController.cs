using FarmacyLibrary;
using FarmacyLibrary.Entiteti;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecijalizovanaApotekaController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddSpecijalizovanaApoteka([FromBody] SpecijalizovanaApotekaBasic dto)
        {
            try
            {
                DTOManagerProdajneJedinice.DodajSpecApoteku(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public IActionResult ChangeSpecijalizovanaApoteka([FromBody] SpecijalizovanaApotekaBasic dto)
        {
            try
            {
                DTOManagerProdajneJedinice.IzmeniSpecApoetku(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
