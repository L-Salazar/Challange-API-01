using Challange_API_01.Domain.Entities;

namespace Challange_API_01.Domain.Interfaces
{
    public interface IMotoRepository
    {
        IEnumerable<MotoEntity> ObterTodos();
        MotoEntity? ObterPorId(int id);
        MotoEntity? Salvar(MotoEntity entity);
        MotoEntity? Atualizar(MotoEntity entity);
        MotoEntity? Deletar(int id);
    }
}
