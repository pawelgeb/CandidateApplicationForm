using CandidateApplicationFormAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CandidateApplicationFormAPI.Models
{
    public class CreateApplicationFormDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-mm-dd}")]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        public Education LevelOfEducation { get; set; }
        [Required]
        [FromForm]
        [DataType(DataType.Upload)]
        public IFormFile CoverLetterFile { get; set; }

        [Required]
        [FromForm]
        [DataType(DataType.Upload)]
        public IFormFile ResumesFile { get; set; }
        [FromForm]
        [DataType(DataType.Upload)]
        public IFormFile ResumeFileAdditional { get; set; }
        public List<CreatePreviousJobDTO> PreviousJobs { get; set; }
    }

    public class CreatePreviousJobDTO
    {
        public string CompanyName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-mm-dd}")]
        public DateTime StartJobDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-mm-dd}")]
        public DateTime EndJobDate { get; set; }
    }

}
