using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblTreatmentDetails
{
    public class TblTreatmentDetailsModel : SecurityModel
    {
        [Key]
        public int TreatmentDetailsId { get; set; }

        public int DieseaseTypeID { get; set; }

        public int PatientId { get; set; }

        public DateTime TreatmentDate { get; set; }
        public string? TreatmentCode { get; set; }
    }
}
