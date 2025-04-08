using HMSAPI.Model.GenericModel;
using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblPateintDoctormapping.ViewModel
{
    public class GetPateintDoctorMappingViewModel : SecurityModel
    {
        [Key]
        public int PateintDoctormappingId { get; set; }

        public string DocterName { get; set; }

        public string PatientName { get; set; }
        public string TreatmentCode { get; set; }

    }
    public class GetPatientMappingViewModel : ListViewModel
    {
        [Key]
        public int PateintDoctormappingId { get; set; }

        public string DocterName { get; set; }

        public string PatientName { get; set; }
        public string TreatmentCode { get; set; }
    }
}
