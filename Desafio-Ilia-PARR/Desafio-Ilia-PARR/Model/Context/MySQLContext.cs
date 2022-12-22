

using Microsoft.EntityFrameworkCore;

namespace Desafio_Ilia_PARR.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        public DbSet<Alocacao> Alocacoes { get; set; }  


    }
}
