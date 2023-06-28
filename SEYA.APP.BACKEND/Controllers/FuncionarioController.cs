using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEYA.APP.BACKEND.Repository;
using SEYA.APP.Shared.DTO.Funcionario;
using SEYA.APP.Shared.DTO.Funcionario;
using SEYA.APP.Shared.Interface;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        public FuncionarioController(IFuncionarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        private IFuncionarioRepository _repository { get; }
        private readonly IMapper _mapper;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetAll()
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
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFilter(string txt)
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
        public async Task<ActionResult<Funcionario>> GetById(int id)
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
        public async Task<ActionResult> Add(FuncionarioCreateDTO Funcionario)
        {
            try
            {
                var FuncionarioEntitty = _mapper.Map<Funcionario>(Funcionario);

                await _repository.Add(FuncionarioEntitty);


                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, FuncionarioCreateDTO Funcionario)
        {
            try
            {
                var FuncionarioEntity = _mapper.Map<Funcionario>(Funcionario);



                var existingFuncionario = await _repository.Get(id);


                if (existingFuncionario == null)
                {
                    return NotFound();
                }

                existingFuncionario.Telefono = FuncionarioEntity.Telefono;
                existingFuncionario.Correo = FuncionarioEntity.Correo;
                existingFuncionario.Cedula = FuncionarioEntity.Cedula;
                existingFuncionario.Nombre = FuncionarioEntity.Nombre;
                existingFuncionario.Direccion = FuncionarioEntity.Direccion;
                existingFuncionario.Apellido = FuncionarioEntity.Apellido;


                await _repository.Update(existingFuncionario);

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
