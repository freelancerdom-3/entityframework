using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblPateintDoctormapping
{
    public class TblPateintDoctormappingModel : SecurityModel
    {
        [Key]
        public int PateintDoctormappingId {  get; set; }

        public int UserId { get; set; }

        public int TreatmentDetailsId { get; set; }
    }
}
