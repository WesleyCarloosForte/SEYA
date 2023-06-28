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
    public class RolController : ControllerBase
    {
        public RolController(IRolRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        private IRolRepository _repository { get; }
        private readonly IMapper _mapper;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetAll()
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

        [HttpGet("filter/{txt}")]
        public async Task<ActionResult<IEnumerable<Rol>>> GetFilter(string txt)
        {
            try
            {
                var conecion = await _repository.Get(x => x.RolName.ToLower().Contains(txt.ToLower()));

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
        public async Task<ActionResult<Rol>> GetById(int id)
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
        public async Task<ActionResult> Add(Rol Cliente)
        {
            try
            {
                

                await _repository.Add(Cliente);


                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Rol rol)
        {
            try
            {
    

                var existingRol = await _repository.Get(id);


                if (existingRol == null)
                {
                    return NotFound();
                }

                existingRol.RolName = rol.RolName;



                await _repository.Update(existingRol);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
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
