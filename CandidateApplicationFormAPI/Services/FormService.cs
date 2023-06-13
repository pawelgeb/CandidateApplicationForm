using AutoMapper;
using CandidateApplicationFormAPI.Entities;
using CandidateApplicationFormAPI.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CandidateApplicationFormAPI.Services
{
    public class FormService : IFormService
    {
        private readonly ApplicationFormDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAttachFileService _serviceAttach;
        public FormService(ApplicationFormDbContext context, IMapper mapper, IAttachFileService serviceAttach)
        {
            _context = context;
            _mapper = mapper;
            _serviceAttach = serviceAttach;
        }
        public int CreateForm(CreateApplicationFormDTO formDto)
        {

            var newForm = _mapper.Map<ApplicationForm>(formDto);
            newForm.CoverLetters = _serviceAttach.UploadCoverLetter(formDto.CoverLetterFile);
            newForm.Resumes = _serviceAttach.UploadResume(formDto.ResumesFile, formDto.ResumeFileAdditional);
            _context.Add(newForm);
            _context.SaveChanges();
            return newForm.Id; 
        }
        public ApplicationFormDTO GetForm(int id)
        {
            var form = _context.ApplicationForms
                .Include(p => p.PreviousJobs)
                .FirstOrDefault(p => p.Id == id);
            var formDto = _mapper.Map<ApplicationFormDTO>(form);
            return formDto;
        }
        public IEnumerable<ApplicationFormDTO> GetForms()
        {
            var forms = _context.ApplicationForms
                .Include(p => p.PreviousJobs)
                .ToList();
            var formDtos = _mapper.Map<List<ApplicationFormDTO>>(forms);
            return formDtos;
        }
    }
}
