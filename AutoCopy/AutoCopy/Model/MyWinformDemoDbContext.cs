using System.Data.Entity;
using MySql.Data;
using MySql.Data.EntityFramework;

namespace AutoCopy.Model
{
    [DbConfigurationType(typeof(MysqlConfiguration))]
    public class MyWinformDemoDbContext: DbContext
    {
        public DbSet<CopyHistory> CopyHistory { get; set; }

        public MyWinformDemoDbContext(string connectionString): base("server=127.0.0.1;port=3306;initial catalog=my_winform_demo;user id=root;password=yangfang@yc1987;")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CopyHistory>().Property(c => c.FileAddress).IsUnicode(false);
        }
    }
}
