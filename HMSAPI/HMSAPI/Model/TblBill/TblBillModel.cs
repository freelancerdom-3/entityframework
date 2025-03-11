using HMSAPI.Model.GenericModel;
using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblBill
{
    public class TblBillModel : SecurityModel
    {
        [Key]
        public int BillId { get; set; }
        public int PatientId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public DateOnly BillDate { get; set; }
         
        public int TreatmentDetailsId { get; set; }
    }
}
