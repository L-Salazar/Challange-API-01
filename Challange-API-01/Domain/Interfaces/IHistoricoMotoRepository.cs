using Challange_API_01.Domain.Entities;

namespace Challange_API_01.Domain.Interfaces
{
    public interface IHistoricoMotoRepository
    {
        IEnumerable<HistoricoMotoEntity> ObterTodos();
        HistoricoMotoEntity? ObterPorId(int id);
        HistoricoMotoEntity? Salvar(HistoricoMotoEntity entity);
        HistoricoMotoEntity? Atualizar(HistoricoMotoEntity entity);
        HistoricoMotoEntity? Deletar(int id);
    }
}
