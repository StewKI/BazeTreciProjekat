using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistributerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDistributeri()
        {
            try
            {
                return new JsonResult(DTOManagerIsporukeZalihe.VratiSveDistributere());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDistributer(long id)
        {
            try
            {
                return new JsonResult(DTOManagerIsporukeZalihe.VratiDistributera(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostDistributer([FromBody] DistributerBasic distributer)
        {
            try
            {
                DTOManagerIsporukeZalihe.DodajDistributera(distributer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutDistributer([FromBody] DistributerBasic distributer)
        {
            try
            {
                DTOManagerIsporukeZalihe.IzmeniDistributera(distributer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDistributer(long id)
        {
            try
            {
                DTOManagerIsporukeZalihe.ObrisiDistributera(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
