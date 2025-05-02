using HospitalManagment_V2.DataAccess.Entities;
using HospitalManagment_V2.Dtos;
using MediatR;

namespace HospitalManagment_V2.Mediator.Doctors.CreateDoctor;

public record CreateDoctorCommand(DoctorDto dto) : IRequest<int>;

