using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEYA.APP.Shared.DTO.Cliente;
using SEYA.APP.Shared.Interface;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientesController : ControllerBase
    {
        public ClientesController(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        private IClienteRepository _repository { get; }
        private readonly IMapper _mapper;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            try
            {
                var conecion = await _repository.Get(x => ($"{x.Nombre} {x.Apellido}".ToLower().Contains("default")));

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

        [HttpGet("default")]
        public async Task<ActionResult<Cliente>> GetDefault()
        {
            try
            {
                var conecion = await _repository.Get(x=>!($"{x.Nombre} {x.Apellido}".ToLower().Contains("default")));

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

        [HttpGet("filter/{txt}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetFilter(string txt)
        {
            try
            {
                var conecion = await _repository.Get(x => x.Nombre.ToLower().Contains(txt.ToLower()) || x.Apellido.ToLower().Contains(txt.ToLower()) || x.Cedula.ToLower().Contains(txt.ToLower()));

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

        [HttpGet("FilterById/{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
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
        [HttpPost]
        public async Task<ActionResult> Add(Shared.DTO.Cliente.ClienteCreateDTO Cliente)
        {
            try
            {
                var clienteEntitty = _mapper.Map < Cliente>(Cliente);
               
                await _repository.Add(clienteEntitty);


                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ClienteCreateDTO Cliente)
        {
            try
            {
                var ClienteEntity = _mapper.Map<Cliente>(Cliente);



                var existingCliente = await _repository.Get(id);


                if (existingCliente == null)
                {
                    return NotFound();
                }

                existingCliente.Telefono= ClienteEntity.Telefono;
                existingCliente.Correo= ClienteEntity.Correo;
                existingCliente.Cedula= ClienteEntity.Cedula;
                existingCliente.Nombre= ClienteEntity.Nombre;
                existingCliente.Direccion= ClienteEntity.Direccion;
                existingCliente.Apellido= ClienteEntity.Apellido;
                

                await _repository.Update(existingCliente);

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
