using Challange_API_01.Application.Dtos;
using Challange_API_01.Application.Interfaces;
using Challange_API_01.Domain.Entities;
using Challange_API_01.Domain.Interfaces;

namespace Challange_API_01.Application.Services
{
    public class MotoApplicationService : IMotoApplicationService
    {
        private readonly IMotoRepository _repository;

        public MotoApplicationService(IMotoRepository repository)
        {
            _repository = repository;
        }

        public MotoEntity? SalvarDadosMoto(MotoDto dto)
        {
            var moto = new MotoEntity
            {
                IdMoto = dto.IdMoto,
                DsPlaca = dto.DsPlaca,
                NmModelo = dto.NmModelo,
                DsCor = dto.DsCor,
                NrAno = dto.NrAno,
                DsStatus = dto.DsStatus,
                IdEstacao = dto.IdEstacao,
                DsVaga = dto.DsVaga
            };

            return _repository.Salvar(moto);
        }

        public MotoEntity? EditarDadosMoto(int id, MotoDto dto)
        {
            var moto = new MotoEntity
            {
                IdMoto = id,
                DsPlaca = dto.DsPlaca,
                NmModelo = dto.NmModelo,
                DsCor = dto.DsCor,
                NrAno = dto.NrAno,
                DsStatus = dto.DsStatus,
                IdEstacao = dto.IdEstacao,
                DsVaga = dto.DsVaga
            };

            return _repository.Atualizar(moto);
        }

        public MotoEntity? DeletarDadosMoto(int id)
        {
            return _repository.Deletar(id);
        }

        public MotoEntity? ObterMotoPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<MotoEntity> ObterTodasMotos()
        {
            return _repository.ObterTodos();
        }
    }
}
