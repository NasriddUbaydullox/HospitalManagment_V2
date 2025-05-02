using HospitalManagment_V2.DataAccess;
using HospitalManagment_V2.DataAccess.Entities;
using HospitalManagment_V2.Repository;
using MediatR;

namespace HospitalManagment_V2.Mediator.Patients.CreatePatient;

public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, int>
{
	private readonly IPatientRepository _repo;

	public CreatePatientCommandHandler(IPatientRepository repo)
	{
		_repo = repo;
	}

	public async Task<int> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
	{
		var patient = new Patient
		{
			FirstName = request.dto.FirstName,
			LastName = request.dto.LastName,
			DateOfBirth = request.dto.DateOfBirth,
			IsActive = request.dto.IsActive,
			RegisteredDate = request.dto.RegisteredDate,
			PatientBlankId = request.dto.PatientBlankId,
		};

		await _repo.AddAsync(patient);
		return patient.Id;
	}
}
