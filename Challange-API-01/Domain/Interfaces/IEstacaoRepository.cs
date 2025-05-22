using Challange_API_01.Domain.Entities;

namespace Challange_API_01.Domain.Interfaces
{
    public interface IEstacaoRepository
    {
        IEnumerable<EstacaoEntity> ObterTodos();
        EstacaoEntity? ObterPorId(int id);
        EstacaoEntity? Salvar(EstacaoEntity entity);
        EstacaoEntity? Atualizar(EstacaoEntity entity);
        EstacaoEntity? Deletar(int id);
    }
}
