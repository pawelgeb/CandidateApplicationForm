using CandidateApplicationFormAPI.Models;

namespace CandidateApplicationFormAPI.Services
{
    public interface IFormService
    {
        int CreateForm(CreateApplicationFormDTO formDto);
        ApplicationFormDTO GetForm(int id);
        IEnumerable<ApplicationFormDTO> GetForms();
    }
}