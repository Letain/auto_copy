using System.Data.Entity;

namespace AutoCopy.Models
{
    /// <summary>
    /// DbContext
    /// </summary>
    [DbConfigurationType(typeof(MysqlConfiguration))]
    public class MyWinformDemoDbContext: DbContext
    {
        public DbSet<CopyHistory> CopyHistory { get; set; }

        public MyWinformDemoDbContext(string connectionString): base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CopyHistory>().Property(c => c.FileAddress).IsUnicode(false);
        }
    }
}
