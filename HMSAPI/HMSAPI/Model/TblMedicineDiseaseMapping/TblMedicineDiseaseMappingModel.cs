using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblMedicineDiseaseMapping
{
    public class TblMedicineDiseaseMappingModel : SecurityModel
    {
        [Key]
        public int MedicineDiseaseMappingID { get; set; }
        public int DieseaseTypeID { get; set; }
        public int MedicineTypeID { get; set; }
    }
}
