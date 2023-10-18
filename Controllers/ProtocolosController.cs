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
    [Route("protocolo")]
    public class ProtocolosController : ControllerBase
    {
        private readonly ILogger<ProtocolosController> _logger;
        private readonly IProtocolosRepository _repository;

        public ProtocolosController(ILogger<ProtocolosController> logger, IProtocolosRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        /// <summary>
        /// Retorna todos os protocolos
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obter-todos-protocolos")]
        public IActionResult ObterTodosProtocolos()
        {
            try
            {
                var protocolos = _repository.GetAll();
                return Ok(protocolos);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterTodosProtocolos(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter os protocolos");

            }

        }
        /// <summary>
        /// Obter um protocolo especifico
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obter-protocolo-por-id")]
        public IActionResult ObterProtocoloPorId(int id)
        {
            try
            {
                var protoclo = _repository.GetById(id);
                return Ok(protoclo);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterProtocoloPorId(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter o protocolo");

            }

        }


        /// <summary>
        /// Criar um no tipo de Pre Quimio
        /// </summary>
        /// <param name="addProtocolosDTO"></param>
        /// <returns></returns> 
        /// <response code = "200">Returns Success</response>
        /// <response code = "400">Bad Request</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
        [HttpPost]
        public IActionResult CriarProtocolo([FromBody] AddProtocolosDTO addProtocolosDTO)
        {
            try
            {
                _repository.Add(new Protocolos(addProtocolosDTO));
                var message = $"Protocolo {addProtocolosDTO.cod_DescricaoProtocolo} criado com sucesso";
                _logger.LogInformation(message);
                return Ok(message);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método CriarProtocolo(){ex.Message}");
                return BadRequest("Ocorreu um erro ao criar o tipo de via de administração");

            }


        }

        /// <summary>
        /// Editar um tipo de  Pre Quimio específico 
        /// </summary>
        ///<param name="updateProtocoloDTO"></param>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
        [HttpPut("{id}")]
        public IActionResult EditarProtocolo(int id, [FromBody] UpdateProtocolosDTO updateProtocoloDTO)
        {
            try
            {
                _repository.Update(new Protocolos(updateProtocoloDTO));
                var message = $"Protocolo {updateProtocoloDTO.Id} atualizado com sucesso!";
                _logger.LogInformation(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método EditarProtocolo(){ex.Message}");
                return BadRequest("Ocorreu um erro ao atualizar o protocolo");
            }

        }

        /// <summary>
        /// Remover um protocolo especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200 ">Returns Success</response>
        /// <response code="401 ">Not Authenticated</response>
        /// <response code="403 ">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpDelete("{id}")]
        public IActionResult RemoverProtocoloDTO(int id)
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
                _logger.LogError(ex, $"Exceção ocorrida no método RemoverProtocoloDTO(){ex.Message}");
                return BadRequest("Ocorreu um erro ao remover o protocolo");
            }
        }

    }

}
