using CandidateApplicationFormAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace CandidateApplicationFormAPI.Models
{
    public class ApplicationFormDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public Education LevelOfEducation { get; set; }
        public List<PreviousJobDTO> PreviousJobs { get; set; }

    }

    public class PreviousJobDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public string StartJobDate { get; set; }

        public string EndJobDate { get; set; }
    }
}
