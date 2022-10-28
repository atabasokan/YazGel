using Microsoft.EntityFrameworkCore;

namespace YazGel.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Okan\\Okan;database=DerseVerse;integrated security=true;");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
    }
}
