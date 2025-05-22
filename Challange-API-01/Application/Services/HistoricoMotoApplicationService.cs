using Challange_API_01.Application.Dtos;
using Challange_API_01.Application.Interfaces;
using Challange_API_01.Domain.Entities;
using Challange_API_01.Domain.Interfaces;

namespace Challange_API_01.Application.Services
{
    public class HistoricoMotoApplicationService : IHistoricoMotoApplicationService
    {
        private readonly IHistoricoMotoRepository _repository;

        public HistoricoMotoApplicationService(IHistoricoMotoRepository repository)
        {
            _repository = repository;
        }

        public HistoricoMotoEntity? SalvarDadosHistorico(HistoricoMotoDto dto)
        {
            var historico = new HistoricoMotoEntity
            {
                IdHistorico = dto.IdHistorico,
                IdMoto = dto.IdMoto,
                IdUsuario = dto.IdUsuario,
                TpAcao = dto.TpAcao,
                DtAcao = dto.DtAcao
            };

            return _repository.Salvar(historico);
        }

        public HistoricoMotoEntity? EditarDadosHistorico(int id, HistoricoMotoDto dto)
        {
            var historico = new HistoricoMotoEntity
            {
                IdHistorico = id,
                IdMoto = dto.IdMoto,
                IdUsuario = dto.IdUsuario,
                TpAcao = dto.TpAcao,
                DtAcao = dto.DtAcao
            };

            return _repository.Atualizar(historico);
        }

        public HistoricoMotoEntity? DeletarDadosHistorico(int id)
        {
            return _repository.Deletar(id);
        }

        public HistoricoMotoEntity? ObterHistoricoPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<HistoricoMotoEntity> ObterTodosHistoricos()
        {
            return _repository.ObterTodos();
        }
    }
}
