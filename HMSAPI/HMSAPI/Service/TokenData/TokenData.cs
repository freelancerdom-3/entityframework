using HMSAPI.EFContext;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HMSAPI.Service.TokenData
{
    public class TokenData : ITokenData
    {
        private readonly IHttpContextAccessor _contextAccessor;
        //private readonly HSMDBContext _hsmDbContext;
        
        public TokenData (IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;

        }
        public long UserID => Convert.ToInt64(_contextAccessor.HttpContext.User.Claims.First(x=>x.Type== "UserId").Value);
        public long RoleId => Convert.ToInt64(_contextAccessor.HttpContext.User.Claims.First(x => x.Type == "Roleid").Value);

     

    }
}
