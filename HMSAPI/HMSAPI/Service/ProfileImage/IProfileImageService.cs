using HMSAPI.Model.GenericModel;
using Microsoft.AspNetCore.Http;

namespace HMSAPI.Service.ProfileImage
{
    public interface IProfileImageService
    {
        Task<APIResponseModel> UploadProfileImage(int UserID, IFormFile file);
        Task<APIResponseModel> GetProfileImage(int UserID);
        Task<APIResponseModel> DeleteProfileImage(int UserID);
    }
}
    