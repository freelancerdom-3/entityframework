    using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblBill;
using HMSAPI.Model.TblPatient;

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

        public ICollection<TblBillModel> Bills { get; set; }

        public TblPatientModel Patient { get; set; }

    }
}
