using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblRole;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HMSAPI.Service.TblRole
{
    public class TblRole : ITblRole
        
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;
        public TblRole(HSMDBContext hSMDBContext)//, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            //_tokenData = tokendata;
        }
        public async Task<APIResponseModel> Add(TblRoleModel roleModel)
        {
            APIResponseModel responseModel = new();
            try 
            {
                using (var connection = _hsmDbContext)
                {


                    bool duplicateRoleName = connection.TblRoles.Any(x => x.RoleName.ToLower() == roleModel.RoleName.ToLower());
                    if (!duplicateRoleName)
                    {
                        roleModel.VersionNo = 1;
                        roleModel.CreateBy = Convert.ToInt32(_tokenData.UserID);
                        _ = connection.TblRoles.Add(roleModel);
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
        public async Task<APIResponseModel> delete(int id)
        {
            APIResponseModel responseModel = new();
            try 
            {
                using (var connection = _hsmDbContext)
                {
                    
                    TblRoleModel? data = connection.TblRoles.Where(x => x.RoleId == id).FirstOrDefault();
                    if (data != null)
                    {
                        connection.TblRoles.Remove(data);
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

        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();

            List<TblRoleModel> lstRolles = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    lstRolles = string.IsNullOrEmpty(searchBy) ? connection.TblRoles.ToList() : connection.TblRoles.Where(x => x.RoleName.ToLower() == searchBy.ToLower()).ToList();
                    responseModel.Data = lstRolles;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Inserted Successfully";
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

        public async Task<APIResponseModel> GetById (int id)
        {
            APIResponseModel responseModel = new();
            try 
            {
                using (var connection = _hsmDbContext)
                {
                    TblRoleModel? data = connection.TblRoles.
                     Where(x => x.RoleId == id).FirstOrDefault();
                    responseModel.Data = data.RoleName;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Inserted Successfully";

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

        public async Task <APIResponseModel>  Update(int ObjId)
        {
            APIResponseModel responseModel = new();

            try
            {

                using (var connection = _hsmDbContext)
                {

                    TblRoleModel? data = connection.TblRoles.Where(x => x.RoleId == ObjId).FirstOrDefault();

                    if (data != null)
                    {
                        data.RoleName = "vishal";
                        data.UpdateBy = data.UpdateBy;
                        data.UpdateOn = data.UpdateOn;
                        data.IsActive = data.IsActive;
                        data.IncreamentVersion();
                        connection.TblRoles.Update(data);
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


    }
}
