using HospitalManagment_V2.Mediator.Doctors.CreateDoctor;
using HospitalManagment_V2.Mediator.Doctors.GetAllDoctors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagment_V2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DoctorController : ControllerBase
	{
		private readonly IMediator _mediator;

		public DoctorController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("get-all-doctors")]
		public async Task<IActionResult> GetAllDoctors()
		{
			return Ok(await _mediator.Send(new GetAllDoctorsQuery()));
		}

		[HttpPost("create-doctor")]
		public async Task<IActionResult> CreateDoctor(CreateDoctorCommand command)
		{
			var doctor = await _mediator.Send(command);
			return Ok(doctor);
		}
	}
}
