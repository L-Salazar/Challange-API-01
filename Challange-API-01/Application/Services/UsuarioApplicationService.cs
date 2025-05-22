using Challange_API_01.Application.Dtos;
using Challange_API_01.Application.Interfaces;
using Challange_API_01.Domain.Entities;
using Challange_API_01.Domain.Interfaces;

namespace Challange_API_01.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioApplicationService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public UsuarioEntity? SalvarDadosUsuario(UsuarioDto dto)
        {
            var usuario = new UsuarioEntity
            {
                IdUsuario = dto.IdUsuario,
                NmUsuario = dto.NmUsuario,
                DsEmail = dto.DsEmail,
                DsSenha = dto.DsSenha,
                TpUsuario = dto.TpUsuario
            };

            return _repository.Salvar(usuario);
        }

        public UsuarioEntity? EditarDadosUsuario(int id, UsuarioDto dto)
        {
            var usuario = new UsuarioEntity
            {
                IdUsuario = id,
                NmUsuario = dto.NmUsuario,
                DsEmail = dto.DsEmail,
                DsSenha = dto.DsSenha,
                TpUsuario = dto.TpUsuario
            };

            return _repository.Atualizar(usuario);
        }

        public UsuarioEntity? DeletarDadosUsuario(int id)
        {
            return _repository.Deletar(id);
        }

        public UsuarioEntity? ObterUsuarioPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<UsuarioEntity> ObterTodosUsuarios()
        {
            return _repository.ObterTodos();
        }
    }
}
