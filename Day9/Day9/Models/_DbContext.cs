using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YourProject.Models;

namespace Day8.Models
{
    public class _DbContext : IdentityDbContext<Client>
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options) { }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TraineeCourse> TraineeCourses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TraineeCourse>()
                .HasKey(tc => new { tc.TraineeID, tc.CourseID });

            base.OnModelCreating(modelBuilder);
        }
    }
}
