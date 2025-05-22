using Challange_API_01.Application.Dtos;
using Challange_API_01.Application.Interfaces;
using Challange_API_01.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

namespace Challange_API_01.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplicationService _applicationService;

        public UsuarioController(IUsuarioApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

       
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os usuários", Description = "Este endpoint retorna uma lista completa de todos os usuários cadastrados.")]
        [SwaggerResponse(200, "Lista obtida com sucesso", typeof(IEnumerable<UsuarioEntity>))]
        [SwaggerResponse(204, "Nenhum usuário encontrado")]
        [SwaggerResponse(400, "Erro ao obter os dados")]
        [ProducesResponseType(typeof(IEnumerable<UsuarioEntity>), 200)]
        public IActionResult Get()
        {
            try
            {
                var usuarios = _applicationService.ObterTodosUsuarios();
                if (usuarios is null) return NoContent();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um usuário específico", Description = "Este endpoint retorna os detalhes de um usuário com base no ID informado.")]
        [SwaggerResponse(200, "Usuário encontrado com sucesso", typeof(UsuarioEntity))]
        [SwaggerResponse(404, "Usuário não encontrado")]
        [SwaggerResponse(400, "Erro ao obter o usuário")]
        [ProducesResponseType(typeof(UsuarioEntity), 200)]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var usuario = _applicationService.ObterUsuarioPorId(id);
                if (usuario is null) return NotFound();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo usuário", Description = "Este endpoint cria um novo usuário com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Usuário criado com sucesso", typeof(UsuarioEntity))]
        [SwaggerResponse(400, "Falha ao inserir o usuário")]
        [ProducesResponseType(typeof(UsuarioEntity), 200)]
        public IActionResult Post([FromBody] UsuarioDto entity)
        {
            try
            {
                var usuario = _applicationService.SalvarDadosUsuario(entity);
                return Ok(usuario);
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
        [SwaggerOperation(Summary = "Atualiza um usuário existente", Description = "Este endpoint atualiza as informações de um usuário com base no ID fornecido.")]
        [SwaggerResponse(200, "Usuário atualizado com sucesso", typeof(UsuarioEntity))]
        [SwaggerResponse(400, "Falha para atualizar o usuário")]
        [ProducesResponseType(typeof(UsuarioEntity), 200)]
        public IActionResult Put(int id, [FromBody] UsuarioDto entity)
        {
            try
            {
                var usuario = _applicationService.EditarDadosUsuario(id, entity);
                return Ok(usuario);
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
        [SwaggerOperation(Summary = "Remove um usuário existente", Description = "Este endpoint remove as informações de um usuário com base no ID fornecido.")]
        [SwaggerResponse(200, "Usuário removido com sucesso", typeof(UsuarioEntity))]
        [SwaggerResponse(400, "Falha ao excluir o usuário")]
        [ProducesResponseType(typeof(UsuarioEntity), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var usuario = _applicationService.DeletarDadosUsuario(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
