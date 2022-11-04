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
            modelBuilder.Entity<Student>()
                .HasOne(x => x.Role)
                .WithMany(y => y.sId)
                .HasForeignKey(z => z.role)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Student>()
                .HasOne(x => x.Teacher)
                .WithMany(y => y.Students)
                .HasForeignKey(z => z.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Student>()
                .HasOne(x => x.DocumentProgress)
                .WithMany(y => y.Students)
                .HasForeignKey(z => z.ProgressId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Teacher>()
                .HasOne(x => x.Role)
                .WithMany(y => y.tId)
                .HasForeignKey(z => z.role)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Supervisor>()
                .HasOne(x => x.Role)
                .WithMany(y => y.svId)
                .HasForeignKey(z => z.role)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Documents>()
                .HasOne(x => x.Internship)
                .WithMany(y => y.DocumentId)
                .HasForeignKey(z => z.InternshipId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Documents>()
                .HasOne(x => x.Student)
                .WithMany(y => y.Documents)
                .HasForeignKey(z => z.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<DocumentProgress> DocumentProgress { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Internship> Internships { get; set; }
    }
}
