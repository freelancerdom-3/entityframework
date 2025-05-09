using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.DashboardCardDetail
{
    public class PatientTableViewModel
    {
        [Key]
        public int PateintDoctormappingId {  get; set; }
        public string? DocterName { get; set; }
        public string? PatientName { get; set; }
        public DateTime FinalDate { get; set; }
        public string? Gender { get; set; }
        public int DateSource { get; set; }
        public int TreatmentDetailsId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }

    }
}
