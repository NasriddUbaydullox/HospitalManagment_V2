using HospitalManagment_V2.DataAccess.Entities;

namespace HospitalManagment_V2.Dtos;


public class PatientDto
{
    public string FullName { get; set; }
    public string? DateOfBirth { get; set; }
    public bool IsActive { get; set; }
    public string RegisteredDate { get; set; }
    public int? PatientBlankId { get; set; }
    public string BlankIdentifier { get; set; }
}

