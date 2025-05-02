namespace HospitalManagment_V2.DataAccess.Entities
{
    public class Doctor
    {
     
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsActive { get; set; }
        public int SpecialityId { get; set; }

    }
}