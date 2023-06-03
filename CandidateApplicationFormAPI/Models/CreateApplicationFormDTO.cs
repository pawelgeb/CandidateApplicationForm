using CandidateApplicationFormAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CandidateApplicationFormAPI.Models
{
    public class CreateApplicationFormDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-mm-dd}")]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        [Required]
        [FromForm]
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
        public Education LevelOfEducation { get; set; }
        //public string ResumePath { get; set; }
        //public List<CreatePreviousJobDTO> PreviousJobs { get; set; }
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
