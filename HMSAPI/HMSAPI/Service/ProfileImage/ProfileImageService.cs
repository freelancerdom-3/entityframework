using System.IO;
using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblUser;
using HMSAPI.Service.ProfileImage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HMSAPI.Service.ProfileImage 
{
    public class ProfileImageService : IProfileImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;
        private readonly HSMDBContext _context;

        public ProfileImageService(
            IWebHostEnvironment environment,
            IConfiguration configuration,
            HSMDBContext context)
        {
            _environment = environment;
            _configuration = configuration;
            _context = context;
        }

        public async Task<APIResponseModel> UploadProfileImage(int UserID, IFormFile file)
        {
            try
            {
                
                if (file == null || file.Length == 0)
                    return new APIResponseModel { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "No file uploaded" };

                if (file.Length > 2 * 1024 * 1024) 
                    return new APIResponseModel { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "File size exceeds 2MB limit" };

                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(fileExtension))
                    return new APIResponseModel { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Invalid file type. Only images are allowed" };

                
                var user = await _context.TblUsers.FindAsync(UserID);
                if (user == null)
                    return new APIResponseModel { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "User not found" };

               
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "profiles");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = $"profile_{UserID}_{DateTime.Now:yyyyMMddHHmmss}{fileExtension}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

            
                if (!string.IsNullOrEmpty(user.ProfileImagePath))
                {
                    var oldFilePath = Path.Combine(_environment.WebRootPath, user.ProfileImagePath.TrimStart('/'));
                    if (File.Exists(oldFilePath))
                        File.Delete(oldFilePath);
                }

               
                user.ProfileImagePath = $"/uploads/profiles/{uniqueFileName}";
                await _context.SaveChangesAsync();

                return new APIResponseModel
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = "Profile image uploaded successfully",
                    Data = new { imagePath = user.ProfileImagePath }
                };
            }
            catch (Exception ex)
            {
                return new APIResponseModel
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = $"Error uploading profile image: {ex.Message}"
                };
            }
        }




        public async Task<APIResponseModel> GetProfileImage(int UserID)
        {
            try
            {
                var user = await _context.TblUsers.FindAsync(UserID);
                if (user == null)
                    return new APIResponseModel { StatusCode = System.Net.HttpStatusCode.BadGateway, Message = "User not found" };

                var imagePath = string.IsNullOrEmpty(user.ProfileImagePath)  ? "/default-profile.png"
            :   user.ProfileImagePath;
                return new APIResponseModel
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = "Succefully Getting Profile Photo",
                    Data = new { imagePath }

                };
            }
            catch (Exception ex)
            {
                return new APIResponseModel
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = $"Error getting profile image: {ex.Message}"
                };
            }
        }

        public async Task<APIResponseModel> DeleteProfileImage(int UserID)
        {
            try
            {
                var user = await _context.TblUsers.FindAsync(UserID);
                if (user == null)
                    return new APIResponseModel { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "User not found" };

                if (string.IsNullOrEmpty(user.ProfileImagePath))
                    return new APIResponseModel { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "No profile image to delete" };

             
                var filePath = Path.Combine(_environment.WebRootPath, user.ProfileImagePath.TrimStart('/'));
                if (File.Exists(filePath))
                    File.Delete(filePath);

           
                user.ProfileImagePath = null;
                user.ProfileImageThumbnailPath = null;
                await _context.SaveChangesAsync();

                return new APIResponseModel
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = "Profile image deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new APIResponseModel
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = $"Error deleting profile image: {ex.Message}"
                };
            }
        }
    }
}