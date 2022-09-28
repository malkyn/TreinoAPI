using System.Linq;
using TreinoAPI.Ativos;
using TreinoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TreinoAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
                .HasOne(user => user.Carteira)
                .WithOne(carteira => carteira.User)
                .HasForeignKey<Carteira>(carteira => carteira.UserId);

            builder.Entity<Gerente>()
                .HasMany(cliente => cliente.Clientes)
                .WithOne(gerente => gerente.Gerente)
                .HasForeignKey(cliente => cliente.GerenteId);

            builder.Entity<Carteira>()
                .HasOne(carteira => carteira.Ativos)
                .WithOne(ativo => ativo.Carteira)
                .HasForeignKey<Ativo>(ativo => ativo.CarteiraId);
        }
        public User Get(string usuario, string senha)
        {
            return User.Where(x => x.Usuario.ToLower() == usuario.ToLower() && x.Senha == x.Senha).FirstOrDefault();
        }
        public DbSet<User> User { get; set; }
        public DbSet<Carteira> Carteira { get; set; }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Acao> Acao { get; set; }
        public DbSet<CriptoMoeda> CriptoMoeda { get; set; }
        public DbSet<Fundo> Fundo { get; set; }
    }
}
