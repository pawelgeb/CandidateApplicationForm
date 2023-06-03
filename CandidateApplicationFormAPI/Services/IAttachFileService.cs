using CandidateApplicationFormAPI.Entities;
using CandidateApplicationFormAPI.Models;

namespace CandidateApplicationFormAPI.Services
{
    public interface IAttachFileService
    {
        void DeleteCoverLetter(int idForm);
        CoverLetter UploadCoverLetter(IFormFile file);
        public void UpdateCoverLetter(string filePath, int idForm);
        List<Resume> UploadResume(string resumePath);
        Resume AddResume(string filePath);
    }
}