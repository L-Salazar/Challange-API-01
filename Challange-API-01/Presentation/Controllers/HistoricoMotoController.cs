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
    public class HistoricoMotoController : ControllerBase
    {
        private readonly IHistoricoMotoApplicationService _applicationService;

        public HistoricoMotoController(IHistoricoMotoApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os históricos de motos", Description = "Retorna uma lista completa de todos os históricos de motos cadastrados.")]
        [SwaggerResponse(200, "Lista obtida com sucesso", typeof(IEnumerable<HistoricoMotoEntity>))]
        [SwaggerResponse(204, "Nenhum histórico encontrado")]
        [SwaggerResponse(400, "Erro ao obter os dados")]
        [ProducesResponseType(typeof(IEnumerable<HistoricoMotoEntity>), 200)]
        public IActionResult Get()
        {
            try
            {
                var historicos = _applicationService.ObterTodosHistoricos();
                if (historicos is null) return NoContent();

                return Ok(historicos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um histórico específico", Description = "Retorna os detalhes de um histórico de moto com base no ID informado.")]
        [SwaggerResponse(200, "Histórico encontrado com sucesso", typeof(HistoricoMotoEntity))]
        [SwaggerResponse(404, "Histórico não encontrado")]
        [SwaggerResponse(400, "Erro ao obter o histórico")]
        [ProducesResponseType(typeof(HistoricoMotoEntity), 200)]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var historico = _applicationService.ObterHistoricoPorId(id);
                if (historico is null) return NotFound();

                return Ok(historico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo histórico de moto", Description = "Cria um novo registro de histórico de moto com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Histórico criado com sucesso", typeof(HistoricoMotoEntity))]
        [SwaggerResponse(400, "Falha ao inserir o histórico")]
        [ProducesResponseType(typeof(HistoricoMotoEntity), 200)]
        public IActionResult Post([FromBody] HistoricoMotoDto entity)
        {
            try
            {
                var historico = _applicationService.SalvarDadosHistorico(entity);
                return Ok(historico);
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
        [SwaggerOperation(Summary = "Atualiza um histórico existente", Description = "Atualiza as informações de um histórico de moto com base no ID fornecido.")]
        [SwaggerResponse(200, "Histórico atualizado com sucesso", typeof(HistoricoMotoEntity))]
        [SwaggerResponse(400, "Falha para atualizar o histórico")]
        [ProducesResponseType(typeof(HistoricoMotoEntity), 200)]
        public IActionResult Put(int id, [FromBody] HistoricoMotoDto entity)
        {
            try
            {
                var historico = _applicationService.EditarDadosHistorico(id, entity);
                return Ok(historico);
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
        [SwaggerOperation(Summary = "Remove um histórico existente", Description = "Remove as informações de um histórico de moto com base no ID fornecido.")]
        [SwaggerResponse(200, "Histórico removido com sucesso", typeof(HistoricoMotoEntity))]
        [SwaggerResponse(400, "Falha ao excluir o histórico")]
        [ProducesResponseType(typeof(HistoricoMotoEntity), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var historico = _applicationService.DeletarDadosHistorico(id);
                return Ok(historico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
