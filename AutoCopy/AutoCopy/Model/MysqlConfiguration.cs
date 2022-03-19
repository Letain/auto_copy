using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCopy.Model
{
    public class MysqlConfiguration : DbConfiguration
    {
        public MysqlConfiguration()
        {

            SetExecutionStrategy(MySqlProviderInvariantName.ProviderName, () => new MySqlExecutionStrategy());
            //SetDefaultConnectionFactory(new LocalDbConnectionFactory("mssqllocaldb"));

            Loaded += (_, a) =>
            {
                a.ReplaceService<DbProviderServices>((s, k) => new MySqlProviderServices());
                a.ReplaceService<IDbConnectionFactory>((s, k) => new MySqlConnectionFactory());
            };
        }
    }
}
