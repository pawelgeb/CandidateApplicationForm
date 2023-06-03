using AutoMapper;
using CandidateApplicationFormAPI.Entities;

namespace CandidateApplicationFormAPI.Models
{
    public class FormMappingProfile : Profile
    {
        public FormMappingProfile()
        {
            CreateMap<ApplicationForm, ApplicationFormDTO>()
                .ForMember(x => x.DateOfBirth, c=>c.MapFrom(s=>s.DateOfBirth.ToString("yyyy/MM/dd")));
            CreateMap<CreateApplicationFormDTO, ApplicationForm>();
            CreateMap<CreatePreviousJobDTO, PreviousJob>();
            CreateMap<PreviousJob, PreviousJobDTO>()
                .ForMember(x => x.StartJobDate, c => c.MapFrom(s => s.StartJobDate.ToString("yyyy/MM/dd")))
                .ForMember(x => x.EndJobDate, c => c.MapFrom(s => s.EndJobDate.ToString("yyyy/MM/dd")));
            CreateMap<CreateCoverLetterDTO, CoverLetter>();
            CreateMap<CreateResumeDTO, Resume>();
        }
    }
}
