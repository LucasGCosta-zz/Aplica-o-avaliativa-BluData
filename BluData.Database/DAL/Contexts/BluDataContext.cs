using BluData.Database.DAL.Config;
using BluData.Database.Entities;
using BluData.Database.Migrations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BluData.Database.DAL.Contexts
{
    [DbConfigurationType(typeof(MySqlConfiguration))]
    public class BluDataContext : DbContext
    {

        public const string ConnectionName = "LocalBluDataConnection";

        public BluDataContext()
            : base(ConnectionName)
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<BluDataContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Telefone> Telefones { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
