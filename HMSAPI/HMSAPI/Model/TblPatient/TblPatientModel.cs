using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HMSAPI.Model.TblPatient
{
    public class TblPatientModel
    {
        [Key]
        public int PatientId { get; set; }

        public DateOnly? DOB { get; set; }

        public string?  Gender { get; set; }

        public string? Address { get; set; }

        public string? Blood_Group { get; set; }

        public string? Emergency_Contact  {get ; set; }

        public string? Medical_History {  get; set; }

        public int UserId { get; set; }
    }
}
