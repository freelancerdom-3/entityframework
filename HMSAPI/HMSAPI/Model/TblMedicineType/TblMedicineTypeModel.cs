using HMSAPI.Model.GenericModel;
using System.ComponentModel.DataAnnotations;

namespace HMSAPI.Model.TblMedicineType
{
    public class TblMedicineTypeModel : SecurityModel
    {
        [Key]
        public int MedicineTypeID { get; set; }
        public string? TypeName { get; set; }
    }
}
