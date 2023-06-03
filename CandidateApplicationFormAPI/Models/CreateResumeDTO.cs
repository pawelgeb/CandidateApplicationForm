namespace CandidateApplicationFormAPI.Models
{
    public class CreateResumeDTO
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public int ApplicationFormId { get; set; }
    }
}
