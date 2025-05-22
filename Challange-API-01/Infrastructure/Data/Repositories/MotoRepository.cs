using Challange_API_01.Domain.Entities;
using Challange_API_01.Domain.Interfaces;
using Challange_API_01.Infrastructure.Data.AppData;

namespace Challange_API_01.Infrastructure.Data.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly ApplicationContext _context;

        public MotoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<MotoEntity> ObterTodos()
        {
            return _context.Moto.ToList();
        }

        public MotoEntity? ObterPorId(int id)
        {
            return _context.Moto.Find(id);
        }

        public MotoEntity? Salvar(MotoEntity entity)
        {
            _context.Moto.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public MotoEntity? Atualizar(MotoEntity entity)
        {
            var motoExistente = _context.Moto.Find(entity.IdMoto);
            if (motoExistente is null) return null;

            motoExistente.DsPlaca = entity.DsPlaca;
            motoExistente.NmModelo = entity.NmModelo;
            motoExistente.DsCor = entity.DsCor;
            motoExistente.NrAno = entity.NrAno;
            motoExistente.DsStatus = entity.DsStatus;
            motoExistente.IdEstacao = entity.IdEstacao;
            motoExistente.DsVaga = entity.DsVaga;

            _context.Moto.Update(motoExistente);
            _context.SaveChanges();

            return motoExistente;
        }

        public MotoEntity? Deletar(int id)
        {
            var motoExistente = _context.Moto.Find(id);
            if (motoExistente is not null)
            {
                _context.Moto.Remove(motoExistente);
                _context.SaveChanges();
                return motoExistente;
            }
            return null;
        }
    }
}
