using CandidateApplicationFormAPI.Entities;
using CandidateApplicationFormAPI.Models;

namespace CandidateApplicationFormAPI.Services
{
    public interface IAttachFileService
    {
        void DeleteCoverLetter(int idForm);
        CoverLetter UploadCoverLetter(IFormFile file);
        List<Resume> UploadResume(IFormFile resume, IFormFile? resumeAdditional);
    }
}