using HospitalManagment_V2.Dtos;
using MediatR;

namespace HospitalManagment_V2.Mediator.Patients.CreatePatient;

public record CreatePatientCommand(PatientDto dto) : IRequest<int>;
