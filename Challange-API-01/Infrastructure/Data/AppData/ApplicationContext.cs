using Challange_API_01.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Challange_API_01.Infrastructure.Data.AppData
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<MotoEntity> Moto { get; set; }

        public DbSet<HistoricoMotoEntity> HistoricoMoto { get; set; }

        public DbSet<UsuarioEntity> Usuario { get; set; }

        public DbSet<EstacaoEntity> Estacao { get; set; }
    }

}
