using Challange_API_01.Application.Dtos;
using Challange_API_01.Application.Interfaces;
using Challange_API_01.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Challange_API_01.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstacaoController : ControllerBase
    {
        private readonly IEstacaoApplicationService _applicationService;

        public EstacaoController(IEstacaoApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as estações", Description = "Retorna uma lista completa de todas as estações cadastradas.")]
        [SwaggerResponse(200, "Lista obtida com sucesso", typeof(IEnumerable<EstacaoEntity>))]
        [SwaggerResponse(204, "Nenhuma estação encontrada")]
        [SwaggerResponse(400, "Erro ao obter os dados")]
        [ProducesResponseType(typeof(IEnumerable<EstacaoEntity>), 200)]
        public IActionResult Get()
        {
            try
            {
                var estacoes = _applicationService.ObterTodasEstacoes();
                if (estacoes is null) return NoContent();

                return Ok(estacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma estação específica", Description = "Retorna os detalhes de uma estação com base no ID informado.")]
        [SwaggerResponse(200, "Estação encontrada com sucesso", typeof(EstacaoEntity))]
        [SwaggerResponse(404, "Estação não encontrada")]
        [SwaggerResponse(400, "Erro ao obter a estação")]
        [ProducesResponseType(typeof(EstacaoEntity), 200)]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var estacao = _applicationService.ObterEstacaoPorId(id);
                if (estacao is null) return NotFound();

                return Ok(estacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova estação", Description = "Cria uma nova estação com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Estação criada com sucesso", typeof(EstacaoEntity))]
        [SwaggerResponse(400, "Falha ao inserir a estação")]
        [ProducesResponseType(typeof(EstacaoEntity), 200)]
        public IActionResult Post([FromBody] EstacaoDto entity)
        {
            try
            {
                var estacao = _applicationService.SalvarDadosEstacao(entity);
                return Ok(estacao);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma estação existente", Description = "Atualiza as informações de uma estação com base no ID fornecido.")]
        [SwaggerResponse(200, "Estação atualizada com sucesso", typeof(EstacaoEntity))]
        [SwaggerResponse(400, "Falha para atualizar a estação")]
        [ProducesResponseType(typeof(EstacaoEntity), 200)]
        public IActionResult Put(int id, [FromBody] EstacaoDto entity)
        {
            try
            {
                var estacao = _applicationService.EditarDadosEstacao(id, entity);
                return Ok(estacao);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove uma estação existente", Description = "Remove as informações de uma estação com base no ID fornecido.")]
        [SwaggerResponse(200, "Estação removida com sucesso", typeof(EstacaoEntity))]
        [SwaggerResponse(400, "Falha ao excluir a estação")]
        [ProducesResponseType(typeof(EstacaoEntity), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var estacao = _applicationService.DeletarDadosEstacao(id);
                return Ok(estacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
