using Challange_API_01.Application.Dtos;
using Challange_API_01.Domain.Entities;

namespace Challange_API_01.Application.Interfaces
{
    public interface IMotoApplicationService
    {
        IEnumerable<MotoEntity> ObterTodasMotos();
        MotoEntity? ObterMotoPorId(int id);
        MotoEntity? SalvarDadosMoto(MotoDto entity);
        MotoEntity? EditarDadosMoto(int id, MotoDto entity);
        MotoEntity? DeletarDadosMoto(int id);
    }
}
