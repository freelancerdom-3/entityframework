using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblMedicineDetails
{
    public class TblMedicineDetailsModel : SecurityModel
    {
        [Key]
        public int MedicineDetailsID { get; set; }
        public int TreatmentDetailsId { get; set; }
        public int MedicineTypeID { get; set; }
        public int Dosage { get; set; }
        public string? Frequency { get; set; }
        public string? Duration { get; set; }
        public string? Instruction { get; set; }
        public DateTime IssueDateTime { get; set; }

    }
}
