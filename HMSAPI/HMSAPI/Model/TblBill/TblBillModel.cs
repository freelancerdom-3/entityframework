using HMSAPI.Model.GenericModel;
using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.TblBill.ViewModel;
using HMSAPI.Model.TblTreatmentDetails;

namespace HMSAPI.Model.TblBill
{
    public class TblBillModel : SecurityModel
    {
        [Key]
        public int BillId { get; set; }
      //  public int PatientId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public DateOnly BillDate { get; set; }
         
        public int TreatmentDetailsId { get; set; }

        public TblTreatmentDetailsModel TreatmentDetails { get; set; }



    }
}
