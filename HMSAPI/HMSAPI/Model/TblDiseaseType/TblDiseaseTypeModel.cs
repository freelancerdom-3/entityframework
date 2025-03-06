using System.ComponentModel.DataAnnotations;


namespace HMSAPI.Model.TblDiseaseType
{
    public class TblDiseaseTypeModel
    {
        [Key]
        public int DieseaseTypeID { get; set; }
        public string? DieseaseName { get; set; }
    }
}
