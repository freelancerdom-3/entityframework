using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblPateintDoctormapping
{
    public class TblPateintDoctormappingModel
    {
        [Key]
        public int PateintDoctormappingId {  get; set; }

        public int UserId { get; set; }

        public int PatientId { get; set; }

        public int TreatmentDetailsId { get; set; }
    }
}
