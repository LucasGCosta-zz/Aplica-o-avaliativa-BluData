using BluData.Database.DAL.Contexts;
using System.Data.Entity;

namespace BluData.Database.DAL.Config
{
    public class MySqlConfiguration : DbConfiguration
    {
        public MySqlConfiguration()
        {
            SetHistoryContext("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));

            SetMigrationSqlGenerator("MySql.Data.MySqlClient", () => new MySql.Data.EntityFramework.MySqlMigrationSqlGenerator());
        }
    }
}
