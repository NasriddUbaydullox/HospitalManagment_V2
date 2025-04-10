using AutoMapper;
using HospitalManagment_V2.classes;
using HospitalManagment_V2.DataAccess;
using HospitalManagment_V2.DataAccess.Entities;
using HospitalManagment_V2.Dtos;
using HospitalManagment_V2.Repository;
using HospitalManagment_V2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HospitalManagment_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly ICorroletionId _corrId;
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IPatientRepository _repository;
        private readonly IPatientService _patientService;
        private readonly IPatientRepository _patientRepos;

        public TestController(ICorroletionId corroletionId, 
            ILogger<TestController> logger, Context context , 
            IMapper mapper , IPatientRepository patientRepository,
            IPatientService patientService,
            IPatientRepository patient)
        {
            _logger = logger;
            _corrId = corroletionId;
            _context = context;
            _mapper = mapper;
            _repository = patientRepository;
            _patientService = patientService;
            _patientRepos = patient;
        }

        [HttpGet("test")]
        public IActionResult TestCorrId()
        {
            _logger.LogInformation("CorreletionId {correletionId}", _corrId.Get());
            var getSomething = _context.Doctors.ToList();
            return Ok(getSomething);
        }

        [HttpGet ("get-all-patient")]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(_patientService.GetAllPatients());
        }

        [HttpGet ("get-patient-by-id")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _patientRepos.GetByIdAsync(id));
        }
    }

}
