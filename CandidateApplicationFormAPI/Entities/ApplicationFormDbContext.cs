using Microsoft.EntityFrameworkCore;

namespace CandidateApplicationFormAPI.Entities
{
    public class ApplicationFormDbContext :DbContext
    {
        private readonly string connectionString = "Host=localhost:8080;Database=postgres;Username=postgres;Password=formtask";

        public DbSet<ApplicationForm> ApplicationForms { get; set; }
        public DbSet<PreviousJob> PreviousJobs { get; set; }
        public DbSet<CoverLetter> CoverLetters { get; set; }
        public DbSet<Resume> Resumes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationForm>()
                .Property(p => p.FirstName)
                .IsRequired();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
