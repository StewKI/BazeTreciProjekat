using FarmacyLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    // Wrapper classes for POST request bodies
    public class KreirajProdajuRequest
    {
        public ProdajaBasic Prodaja { get; set; }
        public IList<ProdajaStavkaBasic> Stavke { get; set; }
    }

    public class KreirajProdajuNaReceptRequest
    {
        public ProdajaBasic Prodaja { get; set; }
        public string ReceptSerijskiBroj { get; set; }
        public IList<ProdajaStavkaBasic> Stavke { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class ProdajaController : ControllerBase
    {
        [HttpPost]
        [Route("Kreiraj")]
        public IActionResult KreirajProdaju([FromBody] KreirajProdajuRequest request)
        {
            try
            {
                long prodajaId = DTOManagerProdaja.KreirajProdaju(request.Prodaja, request.Stavke);
                return Ok(new { ProdajaId = prodajaId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("KreirajNaRecept")]
        public IActionResult KreirajProdajuNaRecept([FromBody] KreirajProdajuNaReceptRequest request)
        {
            try
            {
                long prodajaId = DTOManagerProdaja.KreirajProdajuNaRecept(request.Prodaja, request.ReceptSerijskiBroj, request.Stavke);
                return Ok(new { ProdajaId = prodajaId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Pakovanja")]
        public IActionResult GetSvaPakovanja()
        {
            try
            {
                return new JsonResult(DTOManagerProdaja.VratiSvaPakovanja());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Pakovanja/{prodajnaJedinicaId}")]
        public IActionResult GetPakovanjaSaZalihe(long prodajnaJedinicaId)
        {
            try
            {
                return new JsonResult(DTOManagerProdaja.VratiPakovanjaSaZalihe(prodajnaJedinicaId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Blagajnici")]
        public IActionResult GetSviBlagajnici()
        {
            try
            {
                return new JsonResult(DTOManagerProdaja.VratiSveBlagajnike());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Recepti")]
        public IActionResult GetSviRecepti()
        {
            try
            {
                return new JsonResult(DTOManagerProdaja.VratiSveRecepte());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetSveProdaje()
        {
            try
            {
                return new JsonResult(DTOManagerIsporukeZalihe.VratiSveProdaje());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("prodajnaJedinica/{prodajnaJedinicaId}")]
        public IActionResult GetProdajeZaProdajnuJedinicu(long prodajnaJedinicaId)
        {
            try
            {
                return new JsonResult(DTOManagerIsporukeZalihe.VratiProdajeZaProdajnuJedinicu(prodajnaJedinicaId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProdaja(long id)
        {
            try
            {
                var prodaja = DTOManagerIsporukeZalihe.VratiProdaju(id);
                if (prodaja == null)
                {
                    return BadRequest($"Prodaja sa ID {id} nije pronađena.");
                }
                return new JsonResult(prodaja);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Dodaj")]
        public IActionResult DodajProdaju([FromBody] ProdajaBasic prodaja)
        {
            try
            {
                long prodajaId = DTOManagerIsporukeZalihe.DodajProdaju(prodaja);
                return CreatedAtAction(nameof(GetProdaja), new { id = prodajaId }, null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult ObrisiProdaju(long id)
        {
            try
            {
                DTOManagerIsporukeZalihe.ObrisiProdaju(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
