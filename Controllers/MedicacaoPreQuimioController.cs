using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BackendOncologia.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BackendOncologia.Enums;
using BackendOncologia.DTO;
using BackendOncologia.Entities;

namespace BackendOncologia.Controllers
{
    [ApiController]
    [Route("medicacao-pre-quimio")]
    public class MedicacaoPreQuimioController : ControllerBase
    { 
        private readonly IMedicacaoPreQuimioRepository _repository;

        private readonly ILogger<MedicacaoPreQuimioController> _logger;


        public MedicacaoPreQuimioController(IMedicacaoPreQuimioRepository repository, ILogger<MedicacaoPreQuimioController> logger)
        {
            _repository = repository;
            _logger = logger;

        }




        /// <summary>
        ///  Retorna todas as medicações pré quimio cadastradas
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]   
        [HttpGet("obter-todas-medicacoes-prequimio")]
        public IActionResult ObterTodosMedicamentosPreQuimio()
        {
            try 
            {
                var medicacoesPreQUimio = _repository.GetAll();
                return Ok(medicacoesPreQUimio);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterTodosMedicamentosPreQuimio(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter as medicações pré quimio");

            }
           
        }
        /// <summary>
        /// Obter uma medicação pré quimio especifica através do seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>   
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Funcionario)]
        [HttpGet("obter-medicacao-prequimio-por-id/{id}")]
        public IActionResult ObterMedicacaoPreQuimioPorId(int id)
        {
            try
            {
                var medicacaoPreQuimio = _repository.GetById(id);
                if (medicacaoPreQuimio == null)
                {
                    return NotFound();
                }
                return Ok(medicacaoPreQuimio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método ObterMedicacaoPreQuimioPorId(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter a medicação pré quimio");
            }   
        }
        /// <summary>
        /// Criar uma nova medicação pré quimio
        /// </summary>
        /// <param name="addMedicacaoPreQuimioDTO"></param>
        /// <returns></returns> 
        /// <response code = "200">Returns Success</response>
        /// <response code = "400">Bad Request</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
        [HttpPost]
        public IActionResult CriarMedicacaoPreQuimio([FromBody] AddMedicacaoPreQuimioDTO addMedicacaoPreQuimioDTO)
        {
            try
            {
                 _repository.Add(new MedicacaoPreQuimio(addMedicacaoPreQuimioDTO));
                 var message = $"Medicação pré quimio {addMedicacaoPreQuimioDTO.descricao} criada com sucesso";
                _logger.LogInformation(message);
                return Ok(message);
            } catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método CriarMedicacaoPreQuimio(){ex.Message}");
                return BadRequest("Ocorreu um erro ao criar a medicação pré quimio");


            }
        }

        /// <summary>
        /// Editar uma medicação pré quimio específica 
        /// </summary>
        ///<param name="updatemedicacaoPreQuimioDTO"></param>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
        [HttpPut("{id}")]
        public IActionResult EditarMedicacaoPreQuimio(int id, [FromBody] UpdateMedicacaoPreQuimioDTO updatemedicacaoPreQuimioDTO)
        {
            try
            {
                _repository.Update(new MedicacaoPreQuimio(updatemedicacaoPreQuimioDTO));
                var message = $"Usuário {updatemedicacaoPreQuimioDTO.Id} atualizado com sucesso!";
                _logger.LogInformation(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método EditarUsuario(){ex.Message}");
                return BadRequest("Ocorreu um erro ao atualizar o usuário");
            }

        }

        /// <summary>
        /// Remover uma medicacao pre quimio especifica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200 ">Returns Success</response>
        /// <response code="401 ">Not Authenticated</response>
        /// <response code="403 ">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpDelete("{id}")]
        public IActionResult RemoverMedicacaoPreQuimio(int id)
        {
            try
            {
                if (_repository.GetById(id) == null)
                {
                    return NotFound();
                }
                _repository.Delete(id);
                return NoContent();
            } catch (Exception ex)
            {
                _logger.LogError(ex, $"Exceção ocorrida no método RemoverMedicacaoPreQuimio(){ex.Message}");
                return BadRequest("Ocorreu um erro ao remover o usuário");
            }
        }   
    }
}
