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
        [Route("medicacao")]
        public class MedicacaoController : ControllerBase
        {
            private readonly IMedicacaoRepository _repository;

            private readonly ILogger<MedicacaoController> _logger;


            public MedicacaoController(IMedicacaoRepository repository, ILogger<MedicacaoController> logger)
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
            [HttpGet("obter-todas-medicacoes")]
            public IActionResult ObterTodosMedicamentos()
            {
                try
                {
                    var medicacoes = _repository.GetAll();
                    return Ok(medicacoes);

                }

                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Exceção ocorrida no método ObterTodosMedicamentos(){ex.Message}");
                    return BadRequest("Ocorreu um erro ao obter as medicações");

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
            [HttpGet("obter-medicacao-por-id/{id}")]
            public IActionResult ObterMedicacaoPorId(int id)
            {
                try
                {
                    var medicacao = _repository.GetById(id);
                    if (medicacao == null)
                    {
                        return NotFound();
                    }
                    return Ok(medicacao);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Exceção ocorrida no método ObterMedicacaoPorId(){ex.Message}");
                    return BadRequest("Ocorreu um erro ao obter a medicação ");
                }
            }
            /// <summary>
            /// Criar uma nova medicação pré quimio
            /// </summary>
            /// <param name="addMedicacaoDTO"></param>
            /// <returns></returns> 
            /// <response code = "200">Returns Success</response>
            /// <response code = "400">Bad Request</response>
            /// <response code = "401">Not Authenticated</response>
            /// <response code = "403">Not Authorized</response>
            [Authorize]
            [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
            [HttpPost]
            public IActionResult CriarMedicacao([FromBody] AddMedicacaoDTO addMedicacaoDTO)
            {
                try
                {
                    _repository.Add(new Medicacao(addMedicacaoDTO));
                    var message = $"Medicação pré quimio: {addMedicacaoDTO.descricao} criada com sucesso";
                    _logger.LogInformation(message);
                    return Ok(message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Exceção ocorrida no método CriarMedicacao(){ex.Message}");
                    return BadRequest("Ocorreu um erro ao criar a medicação");


                }
            }

            /// <summary>
            /// Editar uma medicação pré quimio específica 
            /// </summary>
            ///<param name="updateMedicacaoDTO"></param>
            /// <returns></returns>
            /// <response code = "200">Returns Success</response>
            /// <response code = "401">Not Authenticated</response>
            /// <response code = "403">Not Authorized</response>
            [Authorize]
            [Authorize(Roles = $"{Permissoes.Administrador}, {Permissoes.Funcionario}")]
            [HttpPut("{id}")]
            public IActionResult EditarMedicacao(int id, [FromBody] UpdateMedicacaoDTO updateMedicacaoDTO)
            {
                try
                {
                    _repository.Update(new Medicacao(updateMedicacaoDTO));
                    var message = $"Medicação  - {updateMedicacaoDTO.descricao} atualizado com sucesso!";
                    _logger.LogInformation(message);
                    return Ok(message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Exceção ocorrida no método EditarMedicacao(){ex.Message}");
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
            public IActionResult RemoverMedicacao(int id)
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
                    _logger.LogError(ex, $"Exceção ocorrida no método RemoverMedicacao(){ex.Message}");
                    return BadRequest("Ocorreu um erro ao remover o usuário");
                }
            }
        }
    
}
