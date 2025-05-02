using HospitalManagment_V2.DataAccess.Entities;
using HospitalManagment_V2.Dtos;
using MediatR;

namespace HospitalManagment_V2.Mediator.Doctors.GetAllDoctors;

public record GetAllDoctorsQuery : IRequest<List<Doctor>>;
