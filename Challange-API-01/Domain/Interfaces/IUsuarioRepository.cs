using Challange_API_01.Domain.Entities;

namespace Challange_API_01.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        IEnumerable<UsuarioEntity> ObterTodos();
        UsuarioEntity? ObterPorId(int id);
        UsuarioEntity? Salvar(UsuarioEntity entity);
        UsuarioEntity? Atualizar(UsuarioEntity entity);
        UsuarioEntity? Deletar(int id);
    }
}
