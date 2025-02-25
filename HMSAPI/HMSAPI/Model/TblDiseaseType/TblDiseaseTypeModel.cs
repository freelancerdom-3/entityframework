using System.ComponentModel.DataAnnotations;


namespace HMSAPI.Model.TblDiseaseType
{
    public class TblDiseaseTypeModel
    {
        [Key]
        public int DieseaseID { get; set; }
        public string? DieseaseName { get; set; }
    }
}
