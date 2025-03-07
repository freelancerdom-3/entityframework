using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblPatientAdmitionDetails.ViewModel
{
    public class GetTblPatientAdmitionDetailsViewModel 


    {

        [Key]
        public int PatientAdmitionDetailsId { get; set; }
        public string? FullName { get; set; }
        public int RoomNumber { get; set; }





    
        public DateTime AdmisionDate { get; set; }


        public int TreatmentDetailsId { get; set; }

        public DateTime? DischargeDate { get; set; }


    }
}
