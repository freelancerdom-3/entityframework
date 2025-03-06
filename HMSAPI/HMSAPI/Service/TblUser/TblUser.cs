using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Model.TblUser;
using HMSAPI.Model.TblUser.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HMSAPI.Service.TblUser
{
    public class TblUser : ITblUser
    {
        private readonly HSMDBContext _hsmDbContext;
        public TblUser(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
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
                    inner join tblrole trole on trole.roleid=tuser.roleid where fullname like '%{searchBy}%'").ToList();
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
                bool match = false;
                using (var connection = _hsmDbContext)
                {
                    match = connection.TblUsers
                        .Where(x => x.Email == email && x.Password == password)
                        .FirstOrDefault()?.UserId > 0;
                }
                responseModel.Data = true;
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "ValidateCredential Successfully";
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }


        //public TblUserModel? validateCredentialWithData(string email, string password)
        //{
        //    if (email == "test@gmail.com" && password == "Abc@123")
        //    {
        //        return new TblUserModel()
        //        {
        //            UserId = 1,
        //            Email = "test@gmail.com",
        //            FullName = "Naitik Gondaliya"
        //        };
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public async Task<APIResponseModel> Add(TblUserModel model)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hsmDbContext)
                {
                    bool duplicateEmail = connection.TblUsers
                        .Any(x => x.Email.ToLower() == model.Email.ToLower());

                    if (!duplicateEmail)
                    {
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

                    if (data != null && !duplicateEmail && !duplicateMobile)

                    {
                        data.RoleId = model.RoleId;
                        data.MobileNumber = model.MobileNumber;
                        data.Email = model.Email;
                        data.Password = model.Password;
                        data.FullName = model.FullName;
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
        
    }
}
