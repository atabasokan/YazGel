using Microsoft.EntityFrameworkCore;

namespace YazGel.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=yazgelkou.mssql.somee.com;database=yazgelkou; User Id=teyavuz_SQLLogin_1; Password=2tyf4vqku5; integrated security=false;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Committee>()
                .HasOne(x => x.tId)
                .WithMany(y => y.teacherId)
                .HasForeignKey(z => z.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Student>()
                .HasOne(x => x.Role)
                .WithMany(y => y.sId)
                .HasForeignKey(z => z.role)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Teacher>()
                .HasOne(x => x.Role)
                .WithMany(y => y.tId)
                .HasForeignKey(z => z.role)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Committee>()
                .HasOne(x => x.Role)
                .WithMany(y => y.cId)
                .HasForeignKey(z => z.role)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Supervisor>()
                .HasOne(x => x.Role)
                .WithMany(y => y.svId)
                .HasForeignKey(z => z.role)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
