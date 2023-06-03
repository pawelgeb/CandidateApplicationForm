using CandidateApplicationFormAPI.Entities;

namespace CandidateApplicationFormAPI.Models
{
    public class CreateCoverLetterDTO
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
