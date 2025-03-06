using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblPateintDoctormapping.ViewModel
{
    public class GetPateintDoctorMappingViewModel
    {
        [Key]
        public int PateintDoctormappingId { get; set; }

        public string FullName { get; set; }
    }
}
