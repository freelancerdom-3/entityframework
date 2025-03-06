using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblTreatmentDetails.ViewModel
{
    public class GetTblTreatmentDetailsViewModel
    {

        [Key]
        public int TreatmentDetailsId{ get; set; }

        public string DieseaseName { get; set; }

        public string FullName { get; set; }
    }
}
