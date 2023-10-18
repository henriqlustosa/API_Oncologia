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
    [Route("descricao-protocolo")]
    public class DescricaoProtocoloController : ControllerBase
    {
        private readonly ILogger<DescricaoProtocoloController> _logger;
        private readonly IDescricaoProtocoloRepository _repository;

        public DescricaoProtocoloController(ILogger<DescricaoProtocoloController> logger, IDescricaoProtocoloRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Retorna todos os tipos de descrição de protocolo
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obter-todos-descricao-protocolo")]
        public IActionResult ObterTodosDescricaoProtocolo()
        {
            try
            {
                var descricaoProtocolo = _repository.GetAll();
                return Ok(descricaoProtocolo);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterTodosDescricaoProtocolo(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter as vias de administração");

            }

        }
        /// <summary>
        /// Obter uma descricao de protocolo específica
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obter-descricao-protocolo-por-id")]
        public IActionResult ObterDescricaoProtocoloPorId(int id)
        {
            try
            {
                var descricaoProtocolo = _repository.GetById(id);
                return Ok(descricaoProtocolo);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterDescricaoProtocoloPorId(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter a via de administração");

            }

        }


        /// <summary>
        /// Criar um no tipo de Pre Quimio
        /// </summary>
        /// <param name="addDescricaoProtocoloDTO"></param>
        /// <returns></returns> 
        /// <response code = "200">Returns Success</response>
        /// <response code = "400">Bad Request</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
        [HttpPost]
        public IActionResult CriarDescricaoProtocolo([FromBody] AddDescricaoProtocoloDTO addDescricaoProtocoloDTO)
        {
            try
            {
                _repository.Add(new DescricaoProtocolo(addDescricaoProtocoloDTO));
                var message = $"Descricao de Protocolo {addDescricaoProtocoloDTO.descricao} criado com sucesso";
                _logger.LogInformation(message);
                return Ok(message);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método CriarDescricaoProtocolo(){ex.Message}");
                return BadRequest("Ocorreu um erro ao criar a descrição de protocolo");

            }


        }

        /// <summary>
        /// Editar uma Descricao de Prototocolo específica
        /// </summary>
        ///<param name="updateDescricaoProtocoloDTO"></param>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
        [HttpPut("{id}")]
        public IActionResult EditarDescricaoProtocolo(int id, [FromBody] UpdateDescricaoProtocoloDTO updateDescricaoProtocoloDTO)
        {
            try
            {
                _repository.Update(new DescricaoProtocolo(updateDescricaoProtocoloDTO));
                var message = $"Descricao de Protocolo {updateDescricaoProtocoloDTO.descricao} atualizado com sucesso!";
                _logger.LogInformation(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método EditarDescricaoProtocolo(){ex.Message}");
                return BadRequest("Ocorreu um erro ao atualizar a descricao de protocolo");
            }

        }

        /// <summary>
        /// Remover uma Descricao de Protocolo específica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200 ">Returns Success</response>
        /// <response code="401 ">Not Authenticated</response>
        /// <response code="403 ">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpDelete("{id}")]
        public IActionResult RemoverDescricaoProtocoloDTO(int id)
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
                _logger.LogError(ex, $"Exceção ocorrida no método RemoverDescricaoProtocoloDTO(){ex.Message}");
                return BadRequest("Ocorreu um erro ao remover uma descricao de protocolo");
            }
        }

    }
}
