using HMSAPI.EFContext;
using HMSAPI.Model.Enums;
using HMSAPI.Model.TblBill.ViewModel;
using HMSAPI.Model.TblMenuRoleMapping;
using HMSAPI.Service.TblUser;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using static HMSAPI.Model.Enums.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HMSAPI.Service.TokenData
{
    public class TokenData : ITokenData
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HSMDBContext _hsmDbContext;

        public TokenData(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;

        }



        public long UserID => Convert.ToInt64(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(_contextAccessor.HttpContext.User.Claims.First(x => x.Type == "UserId").Value)));
       // public long UserID => Convert.ToInt64(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String((_contextAccessor.HttpContext.User.Claims.First(x => x.Type == "UserId").Value))));
        public long RoleId => Convert.ToInt64(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(_contextAccessor.HttpContext.User.Claims.First(x => x.Type == "Roleid").Value))); 
        public List<TblMenuRoleMapping> lstMenuPermission =>
           JsonConvert.DeserializeObject<List<TblMenuRoleMapping>>(_contextAccessor.HttpContext.User.Claims
               .First(x => x.Type == "Permission")
               .ToString()
               .Replace("Permission:", ""));

        public bool IsPermission(Menus menuId, PermissionType permissionType)
        {
            bool result = false;
            switch (permissionType)
            {
                case PermissionType.IsView:
                    result= lstMenuPermission.Any(x => x.MenuId == (int)menuId && x.IsView == 1 && RoleId == RoleId);
                    break;
                case PermissionType.IsEdit:
                    result= lstMenuPermission.Any(x => x.MenuId == (int)menuId && x.IsEdit == 1 && RoleId == RoleId);
                    break;
                case PermissionType.IsAdd:
                    result= lstMenuPermission.Any(x => x.MenuId == (int)menuId && x.IsAdd == 1 && RoleId == RoleId);
                    break;
                case PermissionType.IsDelete:
                    result= lstMenuPermission.Any(x => x.MenuId == (int)menuId && x.IsDelete == 1 && RoleId == RoleId);
                    break;
                default:
                    break;

            }
            return result;

        }
    }
}
