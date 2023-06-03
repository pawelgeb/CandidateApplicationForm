using System.ComponentModel.DataAnnotations;

namespace CandidateApplicationFormAPI.Entities
{
    public class PreviousJob
    {
        public int Id { get; set; } 
        public string CompanyName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-mm-dd}")]
        public DateTime StartJobDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-mm-dd}")]
        public DateTime EndJobDate { get; set; }
        public int ApplicationFormId { get; set; } 
        public virtual ApplicationForm ApplicationForm { get; set; }
    }
}
