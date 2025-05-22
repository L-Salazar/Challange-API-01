using Challange_API_01.Domain.Entities;
using Challange_API_01.Domain.Interfaces;
using Challange_API_01.Infrastructure.Data.AppData;

namespace Challange_API_01.Infrastructure.Data.Repositories
{
    public class HistoricoMotoRepository : IHistoricoMotoRepository
    {
        private readonly ApplicationContext _context;

        public HistoricoMotoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<HistoricoMotoEntity> ObterTodos()
        {
            return _context.HistoricoMoto.ToList();
        }

        public HistoricoMotoEntity? ObterPorId(int id)
        {
            return _context.HistoricoMoto.Find(id);
        }

        public HistoricoMotoEntity? Salvar(HistoricoMotoEntity entity)
        {
            _context.HistoricoMoto.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public HistoricoMotoEntity? Atualizar(HistoricoMotoEntity entity)
        {
            var historicoExistente = _context.HistoricoMoto.Find(entity.IdHistorico);
            if (historicoExistente is null) return null;

            historicoExistente.IdMoto = entity.IdMoto;
            historicoExistente.IdUsuario = entity.IdUsuario;
            historicoExistente.TpAcao = entity.TpAcao;
            historicoExistente.DtAcao = entity.DtAcao;

            _context.HistoricoMoto.Update(historicoExistente);
            _context.SaveChanges();

            return historicoExistente;
        }

        public HistoricoMotoEntity? Deletar(int id)
        {
            var historicoExistente = _context.HistoricoMoto.Find(id);
            if (historicoExistente is not null)
            {
                _context.HistoricoMoto.Remove(historicoExistente);
                _context.SaveChanges();
                return historicoExistente;
            }
            return null;
        }
    }
}
