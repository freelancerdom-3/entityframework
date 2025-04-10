using HMSAPI.Model.GenericModel;
using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblTreatmentDetails.ViewModel
{
    public class GetTblTreatmentDetailsViewModel:SecurityModel
    {

        [Key]
        public int TreatmentDetailsId{ get; set; }

        public string DieseaseName { get; set; }

        public string PatientName { get; set; }

        public DateTime TreatmentDate { get; set; }
        public string? TreatmentCode { get; set; }
    }

    public class Gettbltreatmentmodel : ListViewModel
    {
        [Key]
        public int TreatmentDetailsId { get; set; }

        public string DieseaseName { get; set; }

        public string PatientName { get; set; }

        public DateTime TreatmentDate { get; set; }
        public string? TreatmentCode { get; set; }

    }
}
