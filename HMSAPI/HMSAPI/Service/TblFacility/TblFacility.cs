using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFacility;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblFacility
{
    public class TblFacility : ITblFacility
    {
        private readonly HSMDBContext _hsmDbContext;

        public TblFacility(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        public async Task<APIResponseModel> Add(TblFacilityModel tblFacility)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool duplicateName = connection.TblFacility
                    .Any(x => x.FacilityName.ToLower() == tblFacility.FacilityName.ToLower());

                    if (!duplicateName)
                    {
                        //_hsmDbContext.TblHospitalTypes.Add(hospitalTypModel);

                        //_hsmDbContext.SaveChanges();
                        _ = await connection.TblFacility.AddAsync(tblFacility);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Inserted Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Duplicate Name Found";
                        responseModel.Data = false;
                    }
                }

            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<APIResponseModel> Delete(int Id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblFacilityModel? data = await connection.TblFacility.Where(x => x.FacilityID == Id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        //connection.TblHospitalTypes.Remove(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "ID Not Found";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();
            try
            {
                List<TblFacilityModel> lstfacility = new();
                using (var connection = _hsmDbContext)
                {
                    lstfacility = string.IsNullOrEmpty(searchBy) ? connection.TblFacility.ToList() :
                    connection.TblFacility.Where(x => x.FacilityName.ToLower() == searchBy.ToLower()).ToList();
                    responseModel.Data = lstfacility;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = null;
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<APIResponseModel> GetTbl(int Id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblFacilityModel data = await connection.TblFacility.Where(x => x.FacilityID == Id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = data.FacilityName;
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "ID Not Found";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<APIResponseModel> Update(TblFacilityModel tblFacility)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblFacilityModel? data = await connection.TblFacility.Where(x => x.FacilityName == tblFacility.FacilityName).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        data.FacilityName = tblFacility.FacilityName;
                        connection.TblFacility.Update(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Update Successfully";

                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Duplicate Name Found";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }
    }
}
