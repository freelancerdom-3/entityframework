using HMSAPI.Model.GenericModel;
using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblPatientAdmitionDetails.ViewModel
{
    public class GetTblPatientAdmitionDetailsViewModel : SecurityModel


    {

        [Key]
        public int PatientAdmitionDetailsId { get; set; }
        //public int UserId { get; set; }
        public DateTime AdmisionDate { get; set; }

        //public int RoomID { get; set; }


        public string? PatientName { get; set; }
        public string? RoomNumber { get; set; }
        public string? TreatmentCode { get; set; }
        
    }

    public class GetTblPatientAdmitionViewModel : ListViewModel
    {
        [Key]
        public int PatientAdmitionDetailsId { get; set; }
        //public int UserId { get; set; }
        public DateTime AdmisionDate { get; set; }

        //public int RoomID { get; set; }

        public int TreatmentDetailsId { get; set; }

        public string DieseaseName {  get; set; }
        public string? PatientName { get; set; }
        public int RoomNumber { get; set; }
        public string? TreatmentCode { get; set; }

        public DateTime? DischargeDate { get; set; }
    }
}
