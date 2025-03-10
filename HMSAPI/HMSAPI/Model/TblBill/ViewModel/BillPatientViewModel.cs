using System.ComponentModel.DataAnnotations;
using System.Data;

namespace HMSAPI.Model.TblBill.ViewModel
{
    public class BillPatientViewModel
    {
        [Key]
        public int Billid { get; set; }
        public string? FullName { get; set; }

        public decimal TotalAmount  { get; set; }
        public string? PaymentMethod { get; set; }
        public DateOnly BillDate { get; set; }  

    }
}
