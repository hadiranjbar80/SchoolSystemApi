using Domain.EntityMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new SchoolMap());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}