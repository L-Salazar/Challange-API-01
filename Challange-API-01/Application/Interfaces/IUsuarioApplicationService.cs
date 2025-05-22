using Challange_API_01.Application.Dtos;
using Challange_API_01.Domain.Entities;

namespace Challange_API_01.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        IEnumerable<UsuarioEntity> ObterTodosUsuarios();
        UsuarioEntity? ObterUsuarioPorId(int id);
        UsuarioEntity? SalvarDadosUsuario(UsuarioDto entity);
        UsuarioEntity? EditarDadosUsuario(int id, UsuarioDto entity);
        UsuarioEntity? DeletarDadosUsuario(int id);
    }
}
