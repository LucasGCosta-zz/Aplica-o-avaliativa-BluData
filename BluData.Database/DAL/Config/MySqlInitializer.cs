using BluData.Database.DAL.Contexts;
using System.Data.Entity;

namespace BluData.Database.DAL.Config
{
    class MySqlInitializer : IDatabaseInitializer<BluDataContext>
    {
        public void InitializeDatabase(BluDataContext context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}
