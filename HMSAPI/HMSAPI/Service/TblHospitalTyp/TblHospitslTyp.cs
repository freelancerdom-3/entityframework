using HMSAPI.EFContext;
using HMSAPI.Model.TblHospitalTyp;
using Microsoft.EntityFrameworkCore;

namespace HMSAPI.Service.TblHospitalTyp
{
    public class TblHospitslTyp : ITblHospitalTyp
    {
        private readonly HSMDBContext _hsmDbContext;


        public TblHospitslTyp(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        public bool AddHospitalTyp(TblHospitalTypModel hospitalTypModel)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                bool duplicateName = connection.TblHospitalTypes
                .Any(x => x.HospitalType.ToLower() == hospitalTypModel.HospitalType.ToLower());

                if (!duplicateName)
                {
                    //_hsmDbContext.TblHospitalTypes.Add(hospitalTypModel);

                    //_hsmDbContext.SaveChanges();
                    _ = connection.TblHospitalTypes.Add(hospitalTypModel);
                    connection.SaveChanges();
                    result = true;

                }
                else
                {
                    result = false;
                }
            }
            return result;
        }


        public bool UpdateHospitalTyp(int id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                TblHospitalTypModel? data = connection.TblHospitalTypes.Where(x => x.Id == id).FirstOrDefault();
                if (data != null)
                {
                    data.HospitalType = "General";
                    connection.Update(data);
                    connection.SaveChanges();
                    result = true;

                }
                else
                {
                    result = false;
                }
                return result;
            }
        }


        public bool DeleteHospitalTyp(int id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                TblHospitalTypModel? data = connection.TblHospitalTypes.Where(x => x.Id == id).FirstOrDefault();
                if (data != null)
                {
                    connection.TblHospitalTypes.Remove(data);
                    connection.SaveChanges();
                    result = true;

                }
                else
                {
                    result = false;
                }
                return result;
            }
        }

        public TblHospitalTypModel? GetById(int id)
        {

            using (var connection = _hsmDbContext)
            {
                TblHospitalTypModel data = connection.TblHospitalTypes.Where(x => x.Id == id).FirstOrDefault();
                return data;
            }
        }

        public List<TblHospitalTypModel> GetAll(string? searchBy = null)
        {
            List<TblHospitalTypModel> lstHospitalType = new();
            using (var connection = _hsmDbContext)
            {
                lstHospitalType = string.IsNullOrEmpty(searchBy) ? connection.TblHospitalTypes.ToList() :
                    connection.TblHospitalTypes.Where(x => x.HospitalType.ToLower() == searchBy.ToLower()).ToList();
            }
            return lstHospitalType;
        }
    }
}
