using Challange_API_01.Application.Dtos;
using Challange_API_01.Domain.Entities;

namespace Challange_API_01.Application.Interfaces
{
    public interface IHistoricoMotoApplicationService
    {
        IEnumerable<HistoricoMotoEntity> ObterTodosHistoricos();
        HistoricoMotoEntity? ObterHistoricoPorId(int id);
        HistoricoMotoEntity? SalvarDadosHistorico(HistoricoMotoDto entity);
        HistoricoMotoEntity? EditarDadosHistorico(int id, HistoricoMotoDto entity);
        HistoricoMotoEntity? DeletarDadosHistorico(int id);
    }
}
