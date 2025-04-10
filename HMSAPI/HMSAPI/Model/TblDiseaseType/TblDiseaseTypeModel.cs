using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;


namespace HMSAPI.Model.TblDiseaseType
{
    public class TblDiseaseTypeModel : SecurityModel
    {
        [Key]
        public int DieseaseTypeID { get; set; }
        public string? DieseaseName { get; set; }

    }
    public class getdiseasetypeviewmodel:ListViewModel
    {
        [Key]
        public int DieseaseTypeID { get; set; }
        public string? DieseaseName { get; set; }

    }
}
