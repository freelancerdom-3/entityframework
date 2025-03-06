namespace HMSAPI.Model.TblPatient.ViewModel
{
    public class GetTblPatientViewModel
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RoleName { get; set; }
        public string? MobilNumber { get; set; }    
        public int RoleId { get; set; }
        public DateOnly? DOB { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Blood_Group { get; set; }
        public string? Emergency_Contact { get; set; }
        public string? Medical_History { get; set; }
        public int UserId { get; set; }

    }
}
