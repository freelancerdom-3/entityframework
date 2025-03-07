using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblMedicineDetails.ViewModel
{
    public class GetMedicineDetailsViewModel
    {
        [Key]
        public int MedicineDetailsID { get; set; }
        public string? TypeName { get; set; }
        public string? DieseaseName { get; set; }
        public int Dosage { get; set; }
        public string? Frequency { get; set; }
        public string? Duration { get; set; }
        public string? Instruction { get; set; }
        public DateTime IssueDateTime { get; set; }

    }
}
