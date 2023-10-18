using BackendOncologia.DTO.AddDTO;
using BackendOncologia.DTO.UpdateDTO;
using BackendOncologia.Entities;
using BackendOncologia.Enums;
using BackendOncologia.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendOncologia.Controllers
{
    [ApiController]
    [Route("tipo-pre-quimio")]
    public class TipoPreQuimioController : ControllerBase
    {
        private readonly ILogger<TipoPreQuimioController> _logger;
        private readonly ITipoPreQuimioRepository _repository;

        public TipoPreQuimioController(ILogger<TipoPreQuimioController> logger, ITipoPreQuimioRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Retorna todos os tipos de pre quimio
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obter-todos-tipos-pre-quimio")]
        public IActionResult ObterTodosTiposPreQuimio()
        {
            try
            {
                var tipoPreQuimio = _repository.GetAll();
                return Ok(tipoPreQuimio);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterTodosTiposPreQuimio(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter as vias de administração");

            }

        }
        /// <summary>
        /// Obter um tipo de via de administração especifica
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obter-tipo-pre-quimio-por-id")]
        public IActionResult ObterTipoPreQuimioPorId(int id)
        {
            try
            {
                var tipoPreQuimio = _repository.GetById(id);
                return Ok(tipoPreQuimio);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterTipoPreQuimioPorId(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter a via de administração");

            }

        }


        /// <summary>
        /// Criar um no tipo de Pre Quimio
        /// </summary>
        /// <param name="addTipoPreQuimioDTO"></param>
        /// <returns></returns> 
        /// <response code = "200">Returns Success</response>
        /// <response code = "400">Bad Request</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
        [HttpPost]
        public IActionResult CriarTipoPreQuimio([FromBody] AddTipoPreQuimioDTO addTipoPreQuimioDTO)
        {
            try
            {
                _repository.Add(new TipoPreQuimio(addTipoPreQuimioDTO));
                var message = $"Tipo de PreQuimio {addTipoPreQuimioDTO.descricao} criado com sucesso";
                _logger.LogInformation(message);
                return Ok(message);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método CriarTipoPreQuimio(){ex.Message}");
                return BadRequest("Ocorreu um erro ao criar o tipo de via de administração");

            }


        }

        /// <summary>
        /// Editar um tipo de  Pre Quimio específico 
        /// </summary>
        ///<param name="updateTipoPreQuimioDTO"></param>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
        [HttpPut("{id}")]
        public IActionResult EditarTipoPreQumio(int id, [FromBody] UpdateTipoPreQuimioDTO updateTipoPreQuimioDTO)
        {
            try
            {
                _repository.Update(new TipoPreQuimio(updateTipoPreQuimioDTO));
                var message = $"Tipo Pre Quimio {updateTipoPreQuimioDTO.Id} atualizado com sucesso!";
                _logger.LogInformation(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método EditarTipoPreQumio(){ex.Message}");
                return BadRequest("Ocorreu um erro ao atualizar o usuário");
            }

        }

        /// <summary>
        /// Remover um tipo  de Pre Quimio especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200 ">Returns Success</response>
        /// <response code="401 ">Not Authenticated</response>
        /// <response code="403 ">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpDelete("{id}")]
        public IActionResult RemoverTipoPreQuimioDTO(int id)
        {
            try
            {
                if (_repository.GetById(id) == null)
                {
                    return NotFound();
                }
                _repository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método RemoverTipoPreQuimioDTO(){ex.Message}");
                return BadRequest("Ocorreu um erro ao remover o usuário");
            }
        }

    }
}
