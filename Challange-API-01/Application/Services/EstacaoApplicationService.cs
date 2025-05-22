using Challange_API_01.Application.Dtos;
using Challange_API_01.Application.Interfaces;
using Challange_API_01.Domain.Entities;
using Challange_API_01.Domain.Interfaces;

namespace Challange_API_01.Application.Services
{
    public class EstacaoApplicationService : IEstacaoApplicationService
    {
        private readonly IEstacaoRepository _repository;

        public EstacaoApplicationService(IEstacaoRepository repository)
        {
            _repository = repository;
        }

        public EstacaoEntity? SalvarDadosEstacao(EstacaoDto dto)
        {
            var estacao = new EstacaoEntity
            {
                IdEstacao = dto.IdEstacao,
                NmEstacao = dto.NmEstacao,
                DsLocalizacao = dto.DsLocalizacao,
                NrCapacidade = dto.NrCapacidade ?? 0, 
                DsStatus = dto.DsStatus,
                DtCriacao = dto.DtCriacao,
                DtUltimaAtualizacao = dto.DtUltimaAtualizacao,
                DsResponsavel = dto.DsResponsavel
            };

            return _repository.Salvar(estacao);
        }

        public EstacaoEntity? EditarDadosEstacao(int id, EstacaoDto dto)
        {
            var estacao = new EstacaoEntity
            {
                IdEstacao = id,
                NmEstacao = dto.NmEstacao,
                DsLocalizacao = dto.DsLocalizacao,
                NrCapacidade = dto.NrCapacidade ?? 0,
                DsStatus = dto.DsStatus,
                DtCriacao = dto.DtCriacao,
                DtUltimaAtualizacao = dto.DtUltimaAtualizacao,
                DsResponsavel = dto.DsResponsavel
            };

            return _repository.Atualizar(estacao);
        }

        public EstacaoEntity? DeletarDadosEstacao(int id)
        {
            return _repository.Deletar(id);
        }

        public EstacaoEntity? ObterEstacaoPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<EstacaoEntity> ObterTodasEstacoes()
        {
            return _repository.ObterTodos();
        }
    }
}
