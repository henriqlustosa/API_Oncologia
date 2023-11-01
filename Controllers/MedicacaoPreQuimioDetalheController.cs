using BackendOncologia.DTO.AddDTO;
using BackendOncologia.DTO.UpdateDTO;
using BackendOncologia.Entities;
using BackendOncologia.Enums;
using BackendOncologia.Interfaces;
using BackendOncologia.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendOncologia.Controllers
{
    [ApiController]
    [Route("pre-quimio")]
    public class MedicacaoPreQuimioDetalheController : ControllerBase
    {
        private readonly ILogger<MedicacaoPreQuimioDetalheController> _logger;
        private readonly IPreQuimioRepository _repository;

        public MedicacaoPreQuimioDetalheController(ILogger<MedicacaoPreQuimioDetalheController> logger, IPreQuimioRepository preQuimioRepository)
        {
            _logger = logger;
            _repository = preQuimioRepository;
        }

        /// <summary>
        /// Retorna todos os tipos pre quimio
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obter-todos-pre-quimio")]
        public IActionResult ObterTodosPreQuimio()
        {
            try
            {
                var preQuimio = _repository.GetAll();
                return Ok(preQuimio);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterTodosPreQuimio(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter os pre quimio");

            }

        }

        /// <summary>
        /// Obter um tipo de pre quimio especifico
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obter-pre-quimio-por-id")]
        public IActionResult ObterPreQuimioPorId(int id)
        {
            try
            {
                var preQuimio = _repository.GetById(id);
                return Ok(preQuimio);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterPreQuimioPorId(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter o pre quimio");

            }

        }



        /// <summary>
        /// Criar um pre quimio
        /// </summary>
        /// <param name="addPreQuimioDTO"></param>
        /// <returns></returns> 
        /// <response code = "200">Returns Success</response>
        /// <response code = "400">Bad Request</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]

        [HttpPost]
        public IActionResult CriarPreQuimio([FromBody] AddMedicacaoPreQuimioDetalheDTO addPreQuimioDTO)
        {
            try
            {
                _repository.Add(new MedicacaoPreQuimioDetalhe(addPreQuimioDTO));
                var message = $"Pre quimio {addPreQuimioDTO.cod_TipoPreQuimio} criada com sucesso";
                _logger.LogInformation(message);
                return Ok(message);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método CriarPreQuimio(){ex.Message}");
                return BadRequest("Ocorreu um erro ao criar o tipo de via de administração");

            }


        }


        /// <summary>
        /// Editar um pre quimio especifico
        /// </summary>
        ///<param name="updatePreQuimioDTO"></param>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
        [HttpPut("{id}")]
        public IActionResult EditarPreQuimio(int id, [FromBody] UpdateMedicacaoPreQuimioDetalheDTO updatePreQuimioDTO)
        {
            try
            {
                _repository.Update(new MedicacaoPreQuimioDetalhe(updatePreQuimioDTO));
                var message = $"Pre quimio com o número {updatePreQuimioDTO.Id} atualizado com sucesso!";
                _logger.LogInformation(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método EditarPreQuimio(){ex.Message}");
                return BadRequest("Ocorreu um erro ao atualizar o usuário");
            }

        }


        /// <summary>
        /// Remover um pre quimio especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200 ">Returns Success</response>
        /// <response code="401 ">Not Authenticated</response>
        /// <response code="403 ">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpDelete("{id}")]
        public IActionResult RemoverPreQuimio(int id)
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
                _logger.LogError(ex, $"Exceção ocorrida no método RemoverPreQuimioo(){ex.Message}");
                return BadRequest("Ocorreu um erro ao remover o usuário");
            }
        }
    }
}
