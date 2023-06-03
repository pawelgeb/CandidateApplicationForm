namespace CandidateApplicationFormAPI.Entities
{
    public class Resume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public int ApplicationFormId { get; set; }
        public virtual ApplicationForm ApplicationForm { get; set; }
    }
}
