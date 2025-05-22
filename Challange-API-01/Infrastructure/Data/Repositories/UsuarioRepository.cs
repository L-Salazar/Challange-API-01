using Challange_API_01.Domain.Entities;
using Challange_API_01.Domain.Interfaces;
using Challange_API_01.Infrastructure.Data.AppData;

namespace Challange_API_01.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<UsuarioEntity> ObterTodos()
        {
            return _context.Usuario.ToList();
        }

        public UsuarioEntity? ObterPorId(int id)
        {
            return _context.Usuario.Find(id);
        }

        public UsuarioEntity? Salvar(UsuarioEntity entity)
        {
            _context.Usuario.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public UsuarioEntity? Atualizar(UsuarioEntity entity)
        {
            var usuarioExistente = _context.Usuario.Find(entity.IdUsuario);
            if (usuarioExistente is null) return null;

            usuarioExistente.NmUsuario = entity.NmUsuario;
            usuarioExistente.DsEmail = entity.DsEmail;
            usuarioExistente.DsSenha = entity.DsSenha;
            usuarioExistente.TpUsuario = entity.TpUsuario;

            _context.Usuario.Update(usuarioExistente);
            _context.SaveChanges();

            return usuarioExistente;
        }

        public UsuarioEntity? Deletar(int id)
        {
            var usuarioExistente = _context.Usuario.Find(id);
            if (usuarioExistente is not null)
            {
                _context.Usuario.Remove(usuarioExistente);
                _context.SaveChanges();
                return usuarioExistente;
            }
            return null;
        }
    }
}
