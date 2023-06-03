using CandidateApplicationFormAPI.Entities;
using CandidateApplicationFormAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateApplicationFormAPI.Controllers
{
    [Route("api/resume")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IFormService _service;
        public ResumeController(IFormService service)
        {
            _service = service;
        }

        //[HttpPut]
        //public List<Resume> AddAdditionalResume(int formId, string resumePath)
        //{

        //}
    }
}
