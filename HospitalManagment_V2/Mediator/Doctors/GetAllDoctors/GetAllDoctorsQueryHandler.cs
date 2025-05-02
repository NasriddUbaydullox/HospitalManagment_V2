using HospitalManagment_V2.DataAccess;
using HospitalManagment_V2.DataAccess.Entities;
using HospitalManagment_V2.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagment_V2.Mediator.Doctors.GetAllDoctors;

public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, List<Doctor>>
{
	private readonly Context _context;

	public GetAllDoctorsQueryHandler(Context context)
	{
		_context = context;
	}

	public async Task<List<Doctor>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
	{
		return await _context.Doctors.ToListAsync(cancellationToken);
	}
}
