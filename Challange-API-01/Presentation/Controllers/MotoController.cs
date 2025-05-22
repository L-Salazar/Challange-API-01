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
    public class MotoController : ControllerBase
    {
        private readonly IMotoApplicationService _applicationService;

        public MotoController(IMotoApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as motos", Description = "Retorna uma lista completa de todas as motos cadastradas.")]
        [SwaggerResponse(200, "Lista obtida com sucesso", typeof(IEnumerable<MotoEntity>))]
        [SwaggerResponse(204, "Nenhuma moto encontrada")]
        [SwaggerResponse(400, "Erro ao obter os dados")]
        [ProducesResponseType(typeof(IEnumerable<MotoEntity>), 200)]
        public IActionResult Get()
        {
            try
            {
                var motos = _applicationService.ObterTodasMotos();
                if (motos is null) return NoContent();

                return Ok(motos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma moto específica", Description = "Retorna os detalhes de uma moto com base no ID informado.")]
        [SwaggerResponse(200, "Moto encontrada com sucesso", typeof(MotoEntity))]
        [SwaggerResponse(404, "Moto não encontrada")]
        [SwaggerResponse(400, "Erro ao obter a moto")]
        [ProducesResponseType(typeof(MotoEntity), 200)]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var moto = _applicationService.ObterMotoPorId(id);
                if (moto is null) return NotFound();

                return Ok(moto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova moto", Description = "Cria uma nova moto com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Moto criada com sucesso", typeof(MotoEntity))]
        [SwaggerResponse(400, "Falha ao inserir a moto")]
        [ProducesResponseType(typeof(MotoEntity), 200)]
        public IActionResult Post([FromBody] MotoDto entity)
        {
            try
            {
                var moto = _applicationService.SalvarDadosMoto(entity);
                return Ok(moto);
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
        [SwaggerOperation(Summary = "Atualiza uma moto existente", Description = "Atualiza as informações de uma moto com base no ID fornecido.")]
        [SwaggerResponse(200, "Moto atualizada com sucesso", typeof(MotoEntity))]
        [SwaggerResponse(400, "Falha para atualizar a moto")]
        [ProducesResponseType(typeof(MotoEntity), 200)]
        public IActionResult Put(int id, [FromBody] MotoDto entity)
        {
            try
            {
                var moto = _applicationService.EditarDadosMoto(id, entity);
                return Ok(moto);
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
        [SwaggerOperation(Summary = "Remove uma moto existente", Description = "Remove as informações de uma moto com base no ID fornecido.")]
        [SwaggerResponse(200, "Moto removida com sucesso", typeof(MotoEntity))]
        [SwaggerResponse(400, "Falha ao excluir a moto")]
        [ProducesResponseType(typeof(MotoEntity), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var moto = _applicationService.DeletarDadosMoto(id);
                return Ok(moto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
