using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblTreatmentDetails
{
    public class TblTreatmentDetailsModel
    {
        [Key]
        public int TreatmentDetailsId { get; set; }

        public int DieseaseTypeID { get; set; } 

        public int PatientId { get; set; }

        public DateTime TreatmentDate { get; set; }
    }
}
 