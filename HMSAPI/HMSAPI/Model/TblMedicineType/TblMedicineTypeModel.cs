using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblMedicineType
{
    public class TblMedicineTypeModel
    {
        [Key]
        public int MedicineID { get; set; }
        public string? TypeName { get; set; }
    }
}
