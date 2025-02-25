using HMSAPI.Model.TblDiseaseType;

namespace HMSAPI.Service.TblDiseaseType
{
    public interface ITblDiseaseType
    {
        List<TblDiseaseTypeModel> GetAll (String? searchby=null);
        bool UpdateDieasesWithID(int Id);
        bool DeleteDieases(int Id);
        bool AddDieases (TblDiseaseTypeModel diseaseTypeModel);

       TblDiseaseTypeModel GetTblDiseaseTypeById(int Id);
    }
}
