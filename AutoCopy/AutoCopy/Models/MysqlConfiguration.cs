using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Infrastructure;

namespace AutoCopy.Models
{
    public class MysqlConfiguration : DbConfiguration
    {
        /// <summary>
        /// 配置EntityFramework支持MySql
        /// </summary>
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
