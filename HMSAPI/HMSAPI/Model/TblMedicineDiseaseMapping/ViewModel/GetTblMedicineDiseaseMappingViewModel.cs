using HMSAPI.Model.GenericModel;
using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblMedicineDiseaseMapping.ViewModel
{
    public class GetTblMedicineDiseaseMappingViewModel
    {
        [Key]
        public int MedicineDiseaseMappingID { get; set; }
        public string? DieseaseName { get; set; }
        public string? TypeName { get; set; }

    }
    public class GetTblMedicineDiseaseMappingModel : ListViewModel
    {
        [Key]
        public int MedicineDiseaseMappingID { get; set; }

        public string? DieseaseName { get; set; }

        public string? TypeName { get; set; }
    }
}
