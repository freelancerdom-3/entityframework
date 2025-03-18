using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Model.TblPatient;
using HMSAPI.Model.TblPatient.ViewModel;
using HMSAPI.Model.TblUser;
using HMSAPI.Model.TblUser.ViewModel;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HMSAPI.Service.TblUser
{
    public class TblUser : ITblUser
    {
        private readonly HSMDBContext _hsmDbContext;
        
        private readonly HttpContextAccessor _contextAccessor;

        private readonly ITokenData _tokenData;


        

        public TblUser(HSMDBContext hSMDBContext, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokendata;
            
        }
    
        

        public async Task<APIResponseModel> ForgetPassword(string email)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblUserModel? data = connection.TblUsers.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
                    //update
                    if (data != null)
                    {
                        data.Password = "ABC@123";
                        connection.TblUsers.Update(data);
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
            try
            {
                List<GetTblUserViewModel> lstUsers = new();
                using (var connection = _hsmDbContext)
                {
                    //lstUsers = string.IsNullOrEmpty(searchBy)? connection.TblUsers.ToList():
                    //    connection.TblUsers.Where(x=>x.FullName.ToLower()==searchBy.ToLower()).
                    //    ToList();

                    lstUsers = connection.GetTblUserViewModel.FromSqlRaw($@"SELECT tuser.*,trole.rolename 
                    FROM [HSMDB].[dbo].[TblUser] tuser
                    inner join tblrole trole on trole.roleid=tuser.roleid where RoleName like '%{searchBy}%'").ToList();
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



        public async Task<APIResponseModel> SignupUser(TblUserModel userModel)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    //#2 only email should return
                    //List<string> lstEmail = connection.TblUsers.Select(X=>X.Email).ToList();
                    //#4
                    //bool duplicateEmail = lstEmail.Any(x => x.ToLower() == userModel.Email.ToLower());

                    //bool duplicateEmail =   connection.TblUsers.Where(x => x.Email.ToLower() == userModel.Email.ToLower()).
                    //    FirstOrDefault()?.Email != null;

                    bool duplicateEmail = connection.TblUsers
                        .Any(x => x.Email.ToLower() == userModel.Email.ToLower());


                    if (!duplicateEmail)
                    {
                        //#1
                        _ = connection.TblUsers.Add(userModel);
                        connection.SaveChanges();
                        //#3
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Sign in Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Account NOt Created";
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



        public async Task<APIResponseModel> ValidateCredential(string email, string password)
        {
            APIResponseModel responseModel = new();
            try
            {

                using (var connection = _hsmDbContext)
                {
                    TblUserModel? duplicateEmail = connection.TblUsers
                        .Where(x => x.Email.ToLower() == email.ToLower() && x.Password == password).FirstOrDefault();

                    //var token = GenerateJSONWebToken(duplicateEmail);
                    if (duplicateEmail != null)
                    {
                        var token = GenerateJSONWebToken(duplicateEmail);


                        responseModel.Data = token;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Login Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Invalid Credentials";
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
    

        public async Task<APIResponseModel> Add(TblUserModel model)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool duplicateEmail = connection.TblUsers
                        .Any(x => x.Email.ToLower() == model.Email.ToLower() && x.MobileNumber == model.MobileNumber);

                    if (Convert.ToInt32(_tokenData.RoleId) == 3) 
                    {
                        if (!duplicateEmail)
                        {
                            model.VersionNo = 1;
                            model.CreateBy = Convert.ToInt32(_tokenData.UserID);
                            _ = await connection.TblUsers.AddAsync(model);

                            connection.SaveChanges();

                            responseModel.Data = true;
                            responseModel.StatusCode = HttpStatusCode.OK;
                            responseModel.Message = "Inserted Successfully";
                        }
                        else
                        {
                            responseModel.StatusCode = HttpStatusCode.BadRequest;
                            responseModel.Message = "Duplicate User Found";
                            responseModel.Data = false;
                        }
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "dont have p";
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

        public async Task<APIResponseModel> Update(TblUserModel model)
        {
           
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {

                    bool duplicateEmail = connection.TblUsers.Any(x => x.Email == model.Email.ToLower());
                    bool duplicateMobile = connection.TblUsers.Any(x => x.MobileNumber == model.MobileNumber);
                    TblUserModel? data = await connection.TblUsers.Where(x => x.UserId == model.UserId).FirstOrDefaultAsync();
                    //TblUserModel? data = await connection.TblUsers.Where(x => x.Email != model.Email && x.MobileNumber != model.MobileNumber).FirstOrDefaultAsync();
                   
                   //var vishal =Convert.ToInt32(_tokenData.RoleId);

                    
                    if (Convert.ToInt32(_tokenData.RoleId)==1) 
                    {
                        if (data != null && !duplicateEmail && !duplicateMobile)

                        {
                            model.UpdateBy = Convert.ToInt32(_tokenData.UserID);

                            data.RoleId = model.RoleId;
                            data.MobileNumber = model.MobileNumber;
                            data.Email = model.Email;
                            data.Password = model.Password;
                            data.FullName = model.FullName;
                            data.UpdateBy = model.UpdateBy;
                            data.UpdateOn = model.UpdateOn;
                            data.IsActive = model.IsActive;
                           
                            data.IncreamentVersion();
                            connection.TblUsers.Update(data);
                            

                            connection.SaveChanges();
                            responseModel.Data = true;
                            responseModel.StatusCode = HttpStatusCode.OK;
                            responseModel.Message = "Update Successfully";
                        }
                        else
                        {
                            responseModel.StatusCode = HttpStatusCode.BadRequest;
                            responseModel.Message = "Duplicate  Found";
                            responseModel.Data = false;
                        }
                    }

                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "You Don't have Permission";
                       

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



        public async Task<APIResponseModel> Delete(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    TblUserModel? data = await connection.TblUsers.Where(x => x.UserId == id).FirstOrDefaultAsync();
                    if (data != null)
                    {
                        connection.TblUsers.Remove(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "ID  Not Found";
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


        private string GenerateJSONWebToken(TblUserModel user)
        {
            var configdata = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configdata["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.FullName),
                new Claim("UserId", user.UserId.ToString()),
                new Claim("Roleid",user.RoleId.ToString())
            };

            var token = new JwtSecurityToken(configdata["Jwt:Issuer"],
             //configdata["Jwt:Issuer"],
             configdata["Jwt:Audience"],
             //configdata["Jwt:Audience"],
             claims,
             expires: DateTime.Now.AddMinutes(120),
             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}






