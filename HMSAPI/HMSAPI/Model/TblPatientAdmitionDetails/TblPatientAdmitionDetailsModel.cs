using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblPatientAdmitionDetails
{
    public class TblPatientAdmitionDetailsModel : SecurityModel
    {
        [Key]
        public int PatientAdmitionDetailsId {  get; set; }
        public int UserId { get; set; }
        public DateTime AdmisionDate {  get; set; }

        public int RoomID { get; set; }
        public int TreatmentDetailsId { get; set; }

        public DateTime? DischargeDate { get; set; }


    }
}
