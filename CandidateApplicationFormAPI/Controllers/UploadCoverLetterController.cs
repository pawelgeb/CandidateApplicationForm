using AutoMapper;
using CandidateApplicationFormAPI.Entities;
using CandidateApplicationFormAPI.Models;
using CandidateApplicationFormAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateApplicationFormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadCoverLetterController : ControllerBase
    {
        private readonly IFormService _service;
        private readonly IMapper _mapper;
        public UploadCoverLetterController(IFormService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<CoverLetter> Create([FromForm] IFormFile formFile)
        {

            CreateCoverLetterDTO letter = new CreateCoverLetterDTO();
            var data = new byte[formFile.Length];
            letter.Name = formFile.Name;
            letter.ContentType = formFile.ContentType;
            letter.Data = data;
            var letterDb = _mapper.Map<CoverLetter>(letter);
            return letterDb;
        }

    }
}
