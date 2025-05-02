using HospitalManagment_V2.DataAccess.Entities;
using MediatR;

namespace HospitalManagment_V2.Mediator.Patients.GetPatient;

public record GetPatientByIdQuery(int id) : IRequest<Patient>;
