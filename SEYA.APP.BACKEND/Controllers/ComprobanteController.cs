using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEYA.APP.Shared.DTO.Cliente;
using SEYA.APP.Shared.Interface;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteController : ControllerBase
    {
        public ComprobanteController(IComprobanteRepository repository) 
        {
           _repository = repository;
        }
        private readonly IComprobanteRepository _repository;

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Comprobante Comprobante)
        {
            try
            {
               



                var existingCliente = await _repository.Get(id);


                if (existingCliente == null)
                {
                    return NotFound();
                }

                existingCliente.Sucursal = Comprobante.Sucursal;
                existingCliente.NumeroFinal = Comprobante.NumeroFinal;
                existingCliente.NumeroActual = Comprobante.NumeroActual;
                existingCliente.Timbrado = Comprobante.Timbrado;
                existingCliente.Descripcion = Comprobante.Descripcion;
                existingCliente.FinVigencia = Comprobante.FinVigencia;
                existingCliente.InicioVigencia = Comprobante.InicioVigencia;
                existingCliente.PuntoExpedicion=Comprobante.PuntoExpedicion;
   


                await _repository.Update(existingCliente);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<ActionResult<Comprobante>> GetById()
        {
            try
            {
                var Comprobante = await _repository.Get(1);

                if (Comprobante == null)
                {
                    return NoContent();
                }

                return Ok(Comprobante);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
