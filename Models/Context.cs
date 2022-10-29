using Microsoft.EntityFrameworkCore;

namespace YazGel.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=yazgelkou.mssql.somee.com;database=yazgelkou; User Id=teyavuz_SQLLogin_1; Password=2tyf4vqku5; integrated security=false;");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
    }
}
