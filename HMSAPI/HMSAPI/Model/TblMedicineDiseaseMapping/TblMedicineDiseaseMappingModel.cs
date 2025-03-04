using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblMedicineDiseaseMapping
{
    public class TblMedicineDiseaseMappingModel
    {
        [Key]
        public int MedicineDiseaseMappingID { get; set; }
        public int DieseaseTypeID { get; set; }
        public int MedicineTypeID { get; set; }
    }
}
