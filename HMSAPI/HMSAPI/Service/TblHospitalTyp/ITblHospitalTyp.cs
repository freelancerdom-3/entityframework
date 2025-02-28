using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.TblHospitalTyp;

namespace HMSAPI.Service.TblHospitalTyp
{
    public interface ITblHospitalTyp
    {
        bool AddHospitalTyp(TblHospitalTypModel hospitalTyp);

        bool UpdateHospitalTyp(int id);

        bool DeleteHospitalTyp(int id);

        TblHospitalTypModel? GetById(int id);

        List<TblHospitalTypModel> GetAll(string? searchBy = null);
    }
}
