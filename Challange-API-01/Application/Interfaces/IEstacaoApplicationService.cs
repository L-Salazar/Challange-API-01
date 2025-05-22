using Challange_API_01.Application.Dtos;
using Challange_API_01.Domain.Entities;

namespace Challange_API_01.Application.Interfaces
{
    public interface IEstacaoApplicationService
    {
        IEnumerable<EstacaoEntity> ObterTodasEstacoes();
        EstacaoEntity? ObterEstacaoPorId(int id);
        EstacaoEntity? SalvarDadosEstacao(EstacaoDto entity);
        EstacaoEntity? EditarDadosEstacao(int id, EstacaoDto entity);
        EstacaoEntity? DeletarDadosEstacao(int id);
    }
}
