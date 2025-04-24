using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblDiseaseType;
//using HMSAPI.Model.MenuPermissionModel.ViewModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Model.TblMenuRoleMapping;
using HMSAPI.Model.TblMenuRoleMapping.GetTblMenuPermissionViewModel;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static HMSAPI.Model.Enums.Enums;

namespace HMSAPI.Service.TblMenuPermission
{
    public class TblMenuPermission : ITblMenuPermission

    {
        private readonly HSMDBContext _hsmDbContext;
        private readonly ITokenData _tokenData;
        public TblMenuPermission(HSMDBContext hSMDBContext, ITokenData tokenData)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokenData;
        }
        private int UserId => Convert.ToInt32(_tokenData.UserID);

        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            APIResponseModel responseModel = new();

            // if (_tokenData.IsPermission((int)Enums.Roles.Patient, "IsView"))
            List<GetTblMenuPermissionViewModel> lstmenupermisson = new();

            if (true)
            {
                try
                {

                    using (var connection = _hsmDbContext)
                    {
                        lstmenupermisson = await connection.gettblmenupermissionviewmodel.FromSqlRaw($@"
select TMR.MenuRoleMappingID,TR.RoleName,TM.MenuName,
TMR.RoleID,TMR.MenuID,TMR.IsAdd,TMR.IsEdit,TMR.IsDelete,TMR.IsView,TMR.IsActive,
TU.FullName AS CreatedBy,UT.FullName AS UpdatedBy
 from TblMenuRoleMapping TMR
inner join TblUser TU ON TU.UserId = TMR.CreatedBy
left join TblUser UT ON UT.UserId = TMR.UpdatedBy
LEFT join TblMenu TM ON TM.MenuID = TMR.MenuID
inner join TblRole TR ON TR.RoleId = TMR.RoleID
where TU.FullName like '%{searchBy}%'").ToListAsync();
                        responseModel.Data = lstmenupermisson;
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
            }
            else
            {
                responseModel.Message = "you dont have permission";
            }

            return responseModel;
        }


        public async Task<APIResponseModel> Add(List<TblMenuRoleMapping> newMappings)
        {
            APIResponseModel responseModel = new();

            int roleId = newMappings.First().RoleID;

            try
            {
                using (var connection = _hsmDbContext)
                {
                  
                    var existingMappings = await connection.TblMenuRolemapping .Where(x => x.RoleID ==  roleId).ToListAsync();
                    connection.TblMenuRolemapping.RemoveRange(existingMappings);

                  
                    foreach (var item in newMappings)
                    {
                        item.CreatedBy = UserId;
                        item.IsActive = true;
                        item.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    await connection.TblMenuRolemapping.AddRangeAsync(newMappings);
                  
                    await connection.SaveChangesAsync();

                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Menu role mappings replaced successfully.";
                    responseModel.Data = true;
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException?.Message ?? ex.Message;
                responseModel.Data = false;
            }

            return responseModel;
        }
      

    }
}

