using CandidateApplicationFormAPI.Models;
using CandidateApplicationFormAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateApplicationFormAPI.Controllers
{
    [Route("api/form")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IFormService _service;
        public ApplicationFormController(IFormService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Create([FromForm]CreateApplicationFormDTO formDto)
        {
            int formId = _service.CreateForm(formDto);
            return Ok(formId);
        }
        [HttpGet("{id}")]
        public ActionResult<ApplicationFormDTO> GetById(int id)
        {
            var form = _service.GetForm(id);
            return Ok(form);
        }
        [HttpGet]
        public ActionResult<IEnumerable<ApplicationFormDTO>> GetAll()
        {
            var forms = _service.GetForms();
            return Ok(forms);
        }
    }
}
