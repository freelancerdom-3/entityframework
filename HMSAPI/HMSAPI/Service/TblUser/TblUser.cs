﻿using HMSAPI.EFContext;
using HMSAPI.Model.Enums;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Model.TblMenuRoleMapping;
using HMSAPI.Model.TblPatient;
using HMSAPI.Model.TblPatient.ViewModel;
using HMSAPI.Model.TblRole;
using HMSAPI.Model.TblUser;
using HMSAPI.Model.TblUser.ViewModel;
using HMSAPI.Service.TokenData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using static HMSAPI.Model.Enums.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HMSAPI.Service.TblUser
{
    public class TblUser : ITblUser
    {
        private readonly HSMDBContext _hsmDbContext;

        //private readonly HttpContextAccessor _contextAccessor;

        private readonly ITokenData _tokenData;


        public TblUser(HSMDBContext hSMDBContext, ITokenData tokendata)
        {
            _hsmDbContext = hSMDBContext;
            _tokenData = tokendata;

        }

        private int UserId => Convert.ToInt32(_tokenData.UserID);
        private int RoleId => Convert.ToInt32(_tokenData.RoleId);






        //  private string RoleName => Convert.ToString(_tokenData.RoleName);

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
                    inner join tblrole trole on trole.roleid=tuser.roleid where tuser.IsActive=1  and  RoleName like '%{searchBy}%'").ToList();
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
                    // Encrypt the input password before comparing
                    string encryptedPassword = AESHelper.Encrypt(password);

                    TblUserModel? duplicateEmail = connection.TblUsers
                        .Where(x => x.Email.ToLower() == email.ToLower() && x.Password == encryptedPassword)
                        .FirstOrDefault();

                    List<TblMenuRoleMapping> _lstRoleMenumapping = connection.TblMenuRolemapping.ToList();

                    if (duplicateEmail != null)
                    {
                        var token = GenerateJSONWebToken(duplicateEmail, _lstRoleMenumapping);

                        responseModel.Data = new
                        {
                            data = token,
                            userId = duplicateEmail.UserId,
                            useName = duplicateEmail.FullName,
                            Roleid=duplicateEmail.RoleId,
                            profileImage = duplicateEmail.ProfileImagePath
                        };
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
                responseModel.Message = ex.Message;
                responseModel.Data = null;
            }

            return responseModel;
        }

        //public async Task<APIResponseModel> ValidateCredential(string email, string password)
        //{
        //    APIResponseModel responseModel = new();
        //    try
        //    {

        //        using (var connection = _hsmDbContext)
        //        {
        //            TblUserModel? duplicateEmail = connection.TblUsers
        //                    .Where(x => x.Email.ToLower() == email.ToLower() && x.Password == password).FirstOrDefault();



        //            List<TblMenuRoleMapping> _lstRoleMenumapping = connection.TblMenuRolemapping.ToList();  // 23



                    

        //            if (duplicateEmail != null)
        //            {
        //                var token = GenerateJSONWebToken(duplicateEmail, _lstRoleMenumapping);

        //                responseModel.Data = new
        //                {
        //                    data = token,
        //                    userId = duplicateEmail.UserId,
        //                    useName = duplicateEmail.FullName
        //                };
        //                responseModel.StatusCode = HttpStatusCode.OK;
        //                responseModel.Message = "Login Successfully";

        //            }
        //            else
        //            {
        //                responseModel.StatusCode = HttpStatusCode.BadRequest;
        //                responseModel.Message = "Invalid Credentials";
        //                responseModel.Data = false;
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        responseModel.StatusCode = HttpStatusCode.InternalServerError;
        //        responseModel.Message = ex.InnerException.Message;
        //        responseModel.Data = null;
        //    }
        //    return responseModel;
        //}
        public async Task<APIResponseModel> Add(TblUserModel model)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool duplicateEmail = connection.TblUsers
                        .Any(x => x.Email.ToLower() == model.Email.ToLower() && x.MobileNumber == model.MobileNumber);

                    //  if (_tokenData.IsPermission() = true) { }

                    if (RoleId == 3)
                    {
                        if (!duplicateEmail)
                        {
                            model.VersionNo = 1;
                            model.CreatedBy = UserId;
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
            //  if(true)
            if (_tokenData.IsPermission(Enums.Menus.Users, PermissionType.IsEdit)) //(_tokenData.IsPermission((int)Enums.Menus.Users, "IsEdit")) //Enums.Users , ISAdd
            {
                try
                {
                    using (var connection = _hsmDbContext)
                    {
                        bool duplicateEmail = connection.TblUsers.Any(x => x.Email == model.Email.ToLower());
                        bool duplicateMobile = connection.TblUsers.Any(x => x.MobileNumber == model.MobileNumber);
                        TblUserModel? data = await connection.TblUsers.Where(x => x.UserId == model.UserId).FirstOrDefaultAsync();
                        if (data != null && !duplicateEmail && !duplicateMobile)

                        {
                            model.UpdatedBy = UserId;
                            //  model.UpdateBy=_tokenData.UserID

                            data.RoleId = model.RoleId;
                            data.MobileNumber = model.MobileNumber;
                            data.Email = model.Email;
                            data.Password = model.Password;
                            data.FullName = model.FullName;
                            data.UpdatedBy = model.UpdatedBy;
                            data.UpdatedOn = model.UpdatedOn;
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
                responseModel.Message = "Permission Denied";
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
                        data.IsActive = false;
                        connection.TblUsers.Update(data);
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


        private string GenerateJSONWebToken(TblUserModel user, List<TblMenuRoleMapping> tblMenuRoles)//,TblRoleModel role)
        {
            var configdata = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            string decryptedJwtKey = AESHelper.Decrypt(configdata["Jwt:Key"]);


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(decryptedJwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                
            var claims = new[]
            {
                
               // new Claim(JwtRegisteredClaimNames.Email, user.Email),//abc@gmail.com >> YWJjQGdtYWlsLmNvbQ==
                new Claim(JwtRegisteredClaimNames.Email,Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Email))),
                //new Claim(JwtRegisteredClaimNames.Sub, Convert.ToBase64String(Encoding.UTF8.GetBytes( user.FullName))),
                new Claim(JwtRegisteredClaimNames.Sub,user.FullName),
                new Claim("UserId",Convert.ToBase64String(Encoding.UTF8.GetBytes(user.UserId.ToString()))),
                new Claim("Roleid",Convert.ToBase64String(Encoding.UTF8.GetBytes(user.RoleId.ToString()))),
                new Claim("Permission",JsonConvert.SerializeObject(tblMenuRoles)),
                new Claim("ProfileImage", user.ProfileImagePath ?? "")

            };

            var token = new JwtSecurityToken(configdata["Jwt:Issuer"],
             configdata["Jwt:Audience"],
             claims,
             expires: DateTime.Now.AddMinutes(320),
             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<APIResponseModel> GetAllforcount()
        {
            APIResponseModel responseModel = new();
            try
            {
                List<CountOfTotaldoctor> lstUsers = new();
                using (var connection = _hsmDbContext)
                {
                    lstUsers = connection.countOftotaldoctors.FromSqlRaw($@"
select COUNT(*) AS totalDoctorCount  from tbluser  where RoleId=1

 UNION ALL

SELECT COUNT(*) 
FROM TblEmployeeShiftMapping esm
INNER JOIN TblUser tu ON esm.UserId = tu.UserId
INNER JOIN TblShift TS ON TS.ShiftId=esm.ShiftId
WHERE tu.RoleId = 1
 AND (CAST(GETDATE() AS DATE) BETWEEN esm.EmployeeShiftMappingStartingDate AND esm.EmployeeShiftMappingEndingDate) AND 
 (CAST(GETDATE() AS TIME)BETWEEN TS.StartTime AND TS.EndTime)
").ToList();

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






