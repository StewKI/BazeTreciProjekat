using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    public class IzmeniRadnoMestoRequest
    {
        public long IdRadnogMesta { get; set; }
        public int Smena { get; set; }
    }

    public class ObrisiRasporedRadaRequest
    {
        public long Mbr { get; set; }
        public long ProdajnaJedinicaId { get; set; }
        public DateTime Pocetak { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class RasporedRadaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSviRasporediRada()
        {
            try
            {
                return new JsonResult(DTOManagerZaposleni.VratiSveRasporedeRada());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("zaposleni/{mbr}")]
        public IActionResult GetRasporedRadaZaZaposlenog(long mbr)
        {
            try
            {
                return new JsonResult(DTOManagerZaposleni.VratiRasporedRadaZaZaposlenog(mbr));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{mbr}")]
        public IActionResult GetRasporedRada(long mbr)
        {
            try
            {
                var raspored = DTOManagerZaposleni.VratiRasporedRada(mbr);
                if (raspored == null)
                {
                    return BadRequest($"Raspored rada za zaposlenog sa MBR {mbr} nije pronađen.");
                }
                return new JsonResult(raspored);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostRasporedRada([FromBody] RasporedRadaBasic raspored)
        {
            try
            {
                DTOManagerZaposleni.DodajRasporedRada(raspored);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("zaposleni/{mbr}/radnomesto")]
        public IActionResult PutRadnoMesto(long mbr, [FromBody] IzmeniRadnoMestoRequest request)
        {
            try
            {
                DTOManagerZaposleni.IzmeniRadnoMesto(mbr, request.IdRadnogMesta, request.Smena);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("zaposleni/{mbr}")]
        public IActionResult DeleteRasporedRada(long mbr)
        {
            try
            {
                DTOManagerZaposleni.IzbrisiRasporedRada(mbr);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteRasporedRada([FromBody] ObrisiRasporedRadaRequest request)
        {
            try
            {
                DTOManagerZaposleni.ObrisiRasporedRada(request.Mbr, request.ProdajnaJedinicaId, request.Pocetak);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
