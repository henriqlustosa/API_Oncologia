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
    [Route("via-de-administracao")]
    public class ViaDeAdministracaoController : ControllerBase
    { 

        private readonly ILogger<ViaDeAdministracaoController> _logger;
        private readonly IViaDeAdministracaoRepository _repository;

        public ViaDeAdministracaoController(ILogger<ViaDeAdministracaoController> logger, IViaDeAdministracaoRepository repository)
        {
            _logger = logger;
            _repository = repository;

        }
        /// <summary>
        /// Retorna todos os tipos de vias de administração cadastrados
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obter-todas-vias-de-administracao")]
        public IActionResult ObterTodasViasDeAdministracao()
        {
            try
            {
                var viasDeAdministracao = _repository.GetAll();
                return Ok(viasDeAdministracao);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterTodasViasDeAdministracao(){ex.Message}");
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
        [HttpGet("obter-via-de-administracao-por-id")]
        public IActionResult ObterViaDeAdministracaoPorId(int id)
        {
            try
            {
                var viaDeAdministracao = _repository.GetById(id);
                return Ok(viaDeAdministracao);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterViaDeAdministracaoPorId(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter a via de administração");

            }
           
        }


        /// <summary>
        /// Criar um no tipo de Via de administração
        /// </summary>
        /// <param name="addViaDeAdministracaoDTO"></param>
        /// <returns></returns> 
        /// <response code = "200">Returns Success</response>
        /// <response code = "400">Bad Request</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
        [HttpPost]
        public IActionResult CriarViaDeAdministracao([FromBody] AddViaDeAdministracaoDTO addViaDeAdministracaoDTO)
        {
            try
            {
                _repository.Add(new ViaDeAdministracao(addViaDeAdministracaoDTO));
                var message = $"Tipo de via de administração {addViaDeAdministracaoDTO.descricao} criada com sucesso";
                _logger.LogInformation(message);
                return Ok(message);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método CriarViaDeAdministracao(){ex.Message}");
                return BadRequest("Ocorreu um erro ao criar o tipo de via de administração");

            }
            

        }

        /// <summary>
        /// Editar um tipo de via de administração específico 
        /// </summary>
        ///<param name="updateViaDeAdministracaoDTO"></param>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
        [HttpPut("{id}")]
        public IActionResult EditarViaDeAdministracao(int id, [FromBody] UpdateViaDeAdministracaoDTO updateViaDeAdministracaoDTO)
        {
            try
            {
                _repository.Update(new ViaDeAdministracao(updateViaDeAdministracaoDTO));
                var message = $"Usuário {updateViaDeAdministracaoDTO.Id} atualizado com sucesso!";
                _logger.LogInformation(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método EditarViaDeAdministracao(){ex.Message}");
                return BadRequest("Ocorreu um erro ao atualizar o usuário");
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
        public IActionResult RemoverViaDeAdministracao(int id)
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
                _logger.LogError(ex, $"Exceção ocorrida no método RemoverViaDeAdministracao(){ex.Message}");
                return BadRequest("Ocorreu um erro ao remover o usuário");
            }
        }

    }
}
