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
    [Route("quimio")]
    public class QuimioController : ControllerBase
    {
        private readonly ILogger<QuimioController> _logger;
        private readonly IQuimioRepository _repository;

        public QuimioController(ILogger<QuimioController> logger, IQuimioRepository repository)
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
        /// <remarks code = "403">Not Authorized</remarks>

        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obter-todas-quimios")]
        public IActionResult ObterTodasQuimios()
        {
            try
            {
                var quimios = _repository.GetAll();
                return Ok(quimios);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterTodasQuimios(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter as quimios");

            }

        }

        /// <summary>
        /// Obter um tipo de quimio especifica
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        /// 
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obter-quimio-por-id")]
        public IActionResult ObterQuimioPorId(int id)
        {
            try
            {
                var quimio = _repository.GetById(id);
                return Ok(quimio);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterQuimioPorId(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter a quimio");

            }

        }

        /// <summary>
        /// Criar um no tipo de Via de administração
        /// </summary>
        /// <param name="addQuimioDTO"></param>
        /// <returns></returns> 
        /// <response code = "200">Returns Success</response>
        /// <response code = "400">Bad Request</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
        [HttpPost]
        public IActionResult CriarQuimio([FromBody] AddQuimioDTO addQuimioDTO)
        {
            try
            {
                _repository.Add(new Quimio(addQuimioDTO));
                var message = $"Tipo de via de administração {addQuimioDTO.descricao} criada com sucesso";
                _logger.LogInformation(message);
                return Ok(message);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método CriarQuimio(){ex.Message}");
                return BadRequest("Ocorreu um erro ao criar a quimio");

            }


        }

        /// <summary>
        /// Editar um tipo de via de administração específico 
        /// </summary>
        ///<param name="updateQuimioDTO"></param>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
        [HttpPut("{id}")]
        public IActionResult EditarQuimio(int id, [FromBody] UpdateQuimioDTO updateQuimioDTO)
        {
            try
            {
                _repository.Update(new Quimio(updateQuimioDTO));
                var message = $"Usuário {updateQuimioDTO.Id} atualizado com sucesso!";
                _logger.LogInformation(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método EditarQuimio(){ex.Message}");
                return BadRequest("Ocorreu um erro ao atualizar a quimio");
            }

        }

        /// <summary>
        /// Remover um tipo  de via de administração especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200 ">Returns Success</response>
        /// <response code="401 ">Not Authenticated</response>
        /// <response code="403 ">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpDelete("{id}")]
        public IActionResult RemoverQuimio(int id)
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
                _logger.LogError(ex, $"Exceção ocorrida no método RemoverQuimio(){ex.Message}");
                return BadRequest("Ocorreu um erro ao remover a quimio");
            }
        }
    }
}
