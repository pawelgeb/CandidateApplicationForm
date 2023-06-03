using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace CandidateApplicationFormAPI.Entities
{
    public class ApplicationForm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-mm-dd}")]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public Education LevelOfEducation { get; set; } = Education.Primary;
        public List<PreviousJob>? PreviousJobs { get; set; }
        public List<Resume> Resumes { get; set; }
        public CoverLetter CoverLetters { get; set;  }
    }

    public enum Education
    {
        Primary,
        Secondary,
        Higher
    }
}
