using HospitalManagment_V2.DataAccess;
using HospitalManagment_V2.DataAccess.Entities;
using HospitalManagment_V2.Repository;
using MediatR;

namespace HospitalManagment_V2.Mediator.Patients.GetPatient;

public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Patient>
{
	private readonly IPatientRepository _repo;

	public GetPatientByIdQueryHandler(IPatientRepository repo)
	{
		_repo = repo;
	}

	public async Task<Patient> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
	{
		var patient = await _repo.GetByIdAsync(request.id);
		return patient;
	}
}
