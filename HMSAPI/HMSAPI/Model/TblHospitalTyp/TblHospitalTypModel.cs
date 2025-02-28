using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblHospitalTyp
{
    public class TblHospitalTypModel
    {
        [Key]
        public int Id { get; set; }
        public string? HospitalType { get; set; }
    }
}
