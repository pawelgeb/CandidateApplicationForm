using Microsoft.EntityFrameworkCore;

namespace CandidateApplicationFormAPI.Entities
{
    public class ApplicationFormDbContext :DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<ApplicationForm> ApplicationForms { get; set; }
        public DbSet<PreviousJob> PreviousJobs { get; set; }
        public DbSet<CoverLetter> CoverLetters { get; set; }
        public DbSet<Resume> Resumes { get; set; }

        public ApplicationFormDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationForm>()
                .Property(p => p.FirstName)
                .IsRequired();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
