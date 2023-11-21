using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext: DbContext
    {
        public DbSet<Text> Texts { get; set; }
        public DbSet<FileMeta> FileMetas { get; set; }
        public DbSet<User> Users { get; set; }





        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
