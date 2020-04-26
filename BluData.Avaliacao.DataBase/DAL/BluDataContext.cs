using BluData.Avaliacao.Database.Models;
using BluData.Avaliacao.DataBase.Extensions;
//using BluData.Avaliacao.Database.Migrations;
using Microsoft.EntityFrameworkCore;

namespace BluData.Avaliacao.Database.DAL
{
    //[DbConfigurationType(typeof(MySqlConfiguration))]
    public class BluDataContext : DbContext
    {

        public const string ConnectionName = "LocalBluDataConnection";

        public BluDataContext(DbContextOptions options) : base(options) 
        {
            //System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<BluDataContext, Configuration>());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Telefone> Telefones { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
