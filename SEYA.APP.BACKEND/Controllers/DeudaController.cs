using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEYA.APP.Shared.DTO.Cliente;
using SEYA.APP.Shared.DTO.Deuda;
using SEYA.APP.Shared.Interface;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeudaController : ControllerBase
    {
        public DeudaController(IDeudaRepository repository, IMapper mapper, ICuotaRepository cuotaRepository, IPagoRepository pagoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _CuotaRepository = cuotaRepository;
            _pagoRepository = pagoRepository;
        }
        private readonly IDeudaRepository _repository;
        private readonly ICuotaRepository _CuotaRepository;
        private readonly IPagoRepository _pagoRepository;
        private readonly IMapper _mapper;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deuda>>> GetAll()
        {
            try
            {
                var conecion = await _repository.GetAll();

                if (conecion == null)
                {
                    return NoContent();
                }

                return Ok(conecion);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet("Cliente/{id}")]
        public async Task<ActionResult<IEnumerable<Deuda>>> GetAllbYcLIENTE(int id)
        {
            try
            {
                var conecion = await _repository.GetAll();

                if (conecion == null)
                {
                    return NoContent();
                }

                return Ok(conecion);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Cuota2/{Id}")]
        public async Task<ActionResult<IEnumerable<Deuda>>> GetAll(int Id)
        {
            try
            {
                var conecion = await _CuotaRepository.Get(x=>x.CuentaId==Id);

                if (conecion == null)
                {
                    return NoContent();
                }

                return Ok(conecion);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("filter/{txt}")]
        public async Task<ActionResult<IEnumerable<Deuda>>> GetFilter(string txt)
        {
            try
            {
                var conecion = await _repository.Get(x => x.NumeroComprobante.ToLower().Contains(txt.ToLower()) );

                if (conecion == null)
                {
                    return NoContent();
                }

                return Ok(conecion);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Cuota/{id}")]
        public async Task<ActionResult<Deuda>> GetById(int id)
        {
            try
            {
                var conecion = await _repository.Get(id);

                if (conecion == null)
                {
                    return NoContent();
                }

                return Ok(conecion);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet("Cuotas/{id}")]
        public async Task<ActionResult<Cuota>> GetByIdCuota(int id)
        {
            try
            {
                var conecion = await _CuotaRepository.Get(id);

                if (conecion == null)
                {
                    return NoContent();
                }

                return Ok(conecion);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet("pago/{id}")]
        public async Task<ActionResult<Pago>> GetByIdPago(int id)
        {
            try
            {
                var conecion = await _pagoRepository.Get(x=>x.CuotaId==id);

                if (conecion == null)
                {
                    return NoContent();
                }

                return Ok(conecion.FirstOrDefault());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Add(DeudaCreateDTO Cliente)
        {
            try
            {

                var deudaEntity = _mapper.Map<Deuda>(Cliente);
                await _repository.Add(deudaEntity);


                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}/{usuarioId}")]
        public async Task<ActionResult> Update(int id,int usuarioId)
        {
            try
            {
               

               await _CuotaRepository.PagarCuota(id, usuarioId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var conecion = await _repository.Get(id);

                if (conecion == null)
                {
                    return BadRequest("Conexion no encontrada");
                }
                await _repository.Delete(conecion);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
