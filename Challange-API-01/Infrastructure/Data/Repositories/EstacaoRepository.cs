using Challange_API_01.Domain.Entities;
using Challange_API_01.Domain.Interfaces;
using Challange_API_01.Infrastructure.Data.AppData;

namespace Challange_API_01.Infrastructure.Data.Repositories
{
    public class EstacaoRepository : IEstacaoRepository
    {
        private readonly ApplicationContext _context;

        public EstacaoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<EstacaoEntity> ObterTodos()
        {
            return _context.Estacao.ToList();
        }

        public EstacaoEntity? ObterPorId(int id)
        {
            return _context.Estacao.Find(id);
        }

        public EstacaoEntity? Salvar(EstacaoEntity entity)
        {
            _context.Estacao.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public EstacaoEntity? Atualizar(EstacaoEntity entity)
        {
            var estacaoExistente = _context.Estacao.Find(entity.IdEstacao);
            if (estacaoExistente is null) return null;

            estacaoExistente.NmEstacao = entity.NmEstacao;
            estacaoExistente.DsLocalizacao = entity.DsLocalizacao;
            estacaoExistente.NrCapacidade = entity.NrCapacidade;
            estacaoExistente.DsStatus = entity.DsStatus;
            estacaoExistente.DtCriacao = entity.DtCriacao;
            estacaoExistente.DtUltimaAtualizacao = entity.DtUltimaAtualizacao;
            estacaoExistente.DsResponsavel = entity.DsResponsavel;

            _context.Estacao.Update(estacaoExistente);
            _context.SaveChanges();

            return estacaoExistente;
        }

        public EstacaoEntity? Deletar(int id)
        {
            var estacaoExistente = _context.Estacao.Find(id);
            if (estacaoExistente is not null)
            {
                _context.Estacao.Remove(estacaoExistente);
                _context.SaveChanges();
                return estacaoExistente;
            }
            return null;
        }
    }
}
