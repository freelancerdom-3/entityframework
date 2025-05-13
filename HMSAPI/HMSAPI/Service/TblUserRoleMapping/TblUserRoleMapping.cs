using HMSAPI.EFContext;
using HMSAPI.Model.Enums;
using HMSAPI.Model.GenericModel;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using static HMSAPI.Model.Enums.Enums;
using System.Net;
using HMSAPI.Model.TblUserRoleMapping;
using HMSAPI.Model.TblUser.ViewModel;

namespace HMSAPI.Service.TblUserRoleMapping
{
    public class TblUserRoleMapping : ITblUserRoleMapping
    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;

        public TblUserRoleMapping(HSMDBContext hSMDBContext, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokendata;

        }


        private int UserId => Convert.ToInt32(_tokenData.UserID);
        private int RoleId => Convert.ToInt32(_tokenData.RoleId);

        public async Task<APIResponseModel> Add(TblUserRoleMappingModel model)
        {
            APIResponseModel responseModel = new();

            try
            {

                bool existingRoles = _hsmDbContext.TblUserRoleMappingModels
                    .Any(x => x.UserId == model.UserId);
                if (existingRoles == true)
                {
                    await _hsmDbContext.Database
                            .ExecuteSqlRawAsync($"DELETE FROM TblUserRoleMapping WHERE UserId = {model.UserId}");


                }

               
                if (model.RoleIds != null && model.RoleIds.Any())
                {
                    List<TblUserRoleMappingModel> abc = model.RoleIds.Select(roleId => new TblUserRoleMappingModel
                    {
                        UserId = model.UserId,
                        RoleId = roleId,
                        CreatedBy =UserId,
                        UpdatedBy = UserId,
                        UpdatedOn = DateTime.Now,
                        CreatedOn = DateTime.Now,
                        VersionNo = 1,
                        IsActive = true

                    }).ToList();

                    //foreach (var roleId in model.RoleIds)
                    //{
                    //    TblUserRoleMappingModel newMapping = new()
                    //    {
                    //        UserId = model.UserId,
                    //        RoleId = roleId,
                    //        CreatedBy = 48, 
                    //        UpdatedBy =48,
                    //        UpdatedOn =DateTime.Now,
                    //        CreatedOn = DateTime.Now,
                    //        VersionNo = 1,
                    //        IsActive = true
                    //    };

                    //}
                     await _hsmDbContext.TblUserRoleMappingModels.AddRangeAsync(abc);

                    await _hsmDbContext.SaveChangesAsync();
                }

                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Roles replaced successfully.";
                responseModel.Data = true;
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException?.Message ?? ex.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }





        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();
            try
            {
                List<TblUserRoleMappingViewModel> lstUsers = new();
                using (var connection = _hsmDbContext)
                {
                    lstUsers = connection.TblUserRoleMappingViewModels.FromSqlRaw($@"
SELECT ut.UserId , ut.FullName, STRING_AGG(tu.RoleName, ' , ') as RoleNames
FROM TblUserRoleMapping tr
INNER JOIN TblRole tu ON tu.RoleId = tr.RoleId
INNER JOIN TblUser ut ON ut.UserId = tr.UserId
WHERE ut.FullName LIKE '%{searchBy}%'
GROUP BY ut.UserId , ut.FullName")
    .ToList();

                    responseModel.Data = lstUsers;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Successfully";
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
