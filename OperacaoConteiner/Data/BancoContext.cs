using Microsoft.EntityFrameworkCore;
using OperacaoConteiner.Models;

namespace OperacaoConteiner.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<ContainerModel> Container { get; set; }

        public DbSet<MovimentacaoModel> Movimentacao { get; set; }
    }
}
