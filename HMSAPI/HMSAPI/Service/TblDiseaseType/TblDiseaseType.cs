using HMSAPI.EFContext;
using HMSAPI.Model.TblDiseaseType;
using HMSAPI.Model.TblUser;

//using HMSAPI.Service.TblUser;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HMSAPI.Service.TblDiseaseType
{
    public class TblDiseaseType : ITblDiseaseType
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblDiseaseType(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        // ADD DIEASES 
        public bool AddDieases(TblDiseaseTypeModel diseaseTypeModel)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                bool DuplicateDieases = connection.tblDiseaseTypes.Any(x => x.DieseaseID == diseaseTypeModel.DieseaseID);
                if (!DuplicateDieases)
                {
                    _ = connection.tblDiseaseTypes.Add(diseaseTypeModel);
                    connection.SaveChanges();
                    result = true;
                }
                else
                {
                    return false;
                }
                return result;
            }
        }

        //GETALL
        public List<TblDiseaseTypeModel> GetAll(string? searchby = null)
        {
            List<TblDiseaseTypeModel> lstDisease = new();
            using (var connection = _hsmDbContext)
            {
                lstDisease = string.IsNullOrEmpty(searchby) ? connection.tblDiseaseTypes.ToList() :
                       connection.tblDiseaseTypes.Where(x => x.DieseaseName.ToLower() == searchby.ToLower()).
                       ToList();
            }
            return lstDisease;
        }

        //GET ONE BY ID



        //public List<TblDiseaseTypeModel> GetOne(string? searchby = null)
        //{
        //    List<TblDiseaseTypeModel> lstDieases = new();
        //    using (var connection = _hsmDbContext)
        //    {
        //        TblDiseaseTypeModel? data = connection.tblDiseaseTypes
        //            .Where(x => x.DieseaseID == id)
        //            .FirstOrDefault();
        //    }
        //    return lstDieases;
        //}
        //DELETEDOEASES BY ID
        public bool DeleteDieases(int Id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                TblDiseaseTypeModel? data = connection.tblDiseaseTypes
                    .Where(x => x.DieseaseID == Id)
                    .FirstOrDefault();

                if (data != null)
                {
                    connection.tblDiseaseTypes.Remove(data);
                    connection.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
                return result;
            }
        }

        //UPDATE DIEASES WITH ID
        public bool UpdateDieasesWithID(int Id)
        {
            bool result = false;
            using (var connection = _hsmDbContext)
            {
                TblDiseaseTypeModel? data = connection.tblDiseaseTypes
                    .Where(x => x.DieseaseID == Id)
                    .FirstOrDefault();
                if (data != null)
                {
                    data.DieseaseName = "Fever";
                    connection.tblDiseaseTypes.Update(data);
                    connection.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                return result;
            }
        }

        public List<TblDiseaseTypeModel> GetOne(int Id)
        {
            throw new NotImplementedException();
        }

        public TblDiseaseTypeModel GetTblDiseaseTypeById(int Id)
        {
            using (var connection = _hsmDbContext)
            {
                TblDiseaseTypeModel? data = connection.tblDiseaseTypes.Where(x => x.DieseaseID == Id).FirstOrDefault();
                return data;
            }
            
        }
    }
}

    
