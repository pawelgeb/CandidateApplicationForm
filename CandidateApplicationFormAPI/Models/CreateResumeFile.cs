using System.ComponentModel.DataAnnotations;

namespace CandidateApplicationFormAPI.Models
{
    public class CreateResumeFile
    {
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}
