using HMSAPI.Model.GenericModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace HMSAPI.Model.TblBill.ViewModel
{
    public class BillPatientViewModel : ListViewModel
    {
        [Key]
        public int Billid { get; set; }
        //public string? FullName { get; set; }

        public string? PatientName { get; set; }

        public decimal TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public DateOnly BillDate { get; set; }

    }

    public class  TotalAmountModel
    {
        [Key]
        public string Day { get; set; }
        public decimal Value { get; set; }
    }


    public class TotalWeelAmountModel
    {
        [Key]
        //public DateTime WeekStartDate { get; set; }
        public decimal WeeklyTotal { get; set; }
    }

}
