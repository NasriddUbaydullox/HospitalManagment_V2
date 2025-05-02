using HospitalManagment_V2.DataAccess;
using HospitalManagment_V2.DataAccess.Entities;
using MediatR;

namespace HospitalManagment_V2.Mediator.Doctors.CreateDoctor;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, int>
{
	private readonly Context _context;

	public CreateDoctorCommandHandler(Context context)
	{
		_context = context;
	}

	public async Task<int> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
	{
		var doctor = new Doctor
		{
			Firstname = request.dto.Firstname,
			Lastname = request.dto.Lastname,
			IsActive = request.dto.IsActive,
		};
		_context.Doctors.Add(doctor);
		await _context.SaveChangesAsync(cancellationToken);
		return doctor.Id;
	}
}
