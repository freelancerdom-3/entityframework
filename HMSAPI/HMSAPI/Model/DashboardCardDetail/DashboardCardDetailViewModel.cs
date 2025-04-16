using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;
using Microsoft.EntityFrameworkCore;

namespace HMSAPI.Model.DashboardCardDetail
{
    public class DashboardCardDetailViewModel
    {
        [Key]
        public int totalPatientsVisitedToday {  get; set; }

        public int totalMedicineStock {  get; set; }

        public int totalAmountOfBillGeneratedToday { get; set; }

    }
}
