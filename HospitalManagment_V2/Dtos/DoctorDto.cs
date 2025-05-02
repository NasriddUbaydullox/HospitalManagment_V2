using HospitalManagment_V2.DataAccess.Entities;

namespace HospitalManagment_V2.Dtos;


public class DoctorDto
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public bool IsActive { get; set; }
}


