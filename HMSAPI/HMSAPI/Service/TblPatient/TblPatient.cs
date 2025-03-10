using System.Net;
using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFeedback;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Model.TblPatient;
using HMSAPI.Model.TblPatient.ViewModel;
using HMSAPI.Model.TblUser;
using HMSAPI.Model.TblUser.ViewModel;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HMSAPI.Service.TblPatient
{
    public class TblPatient : ITblPatient
    {
        private readonly HSMDBContext _hSMDBContext;

        public TblPatient (HSMDBContext hSMDBContext)
        {
            _hSMDBContext = hSMDBContext;
        }



        //public async Task<APIResponseModel> Delete(int id)
        //{
        //    APIResponseModel responseModel = new();
        //    try
        //    {
        //        using (var connection = _hSMDBContext)
        //        {
        //            TblPatientModel? data = await connection.TblPatients.Where(x => x.PatientId == id).FirstOrDefaultAsync();
        //            if(data != null)
        //            {
        //                connection.TblPatients.Remove(data);
        //                connection.SaveChanges();
        //                responseModel.Data = true;
        //                responseModel.StatusCode = HttpStatusCode.OK;
        //                responseModel.Message = "Delete Successfully";
        //            }

        //            else
        //            {
        //                responseModel.StatusCode = HttpStatusCode.BadRequest;
        //                responseModel.Message = "ID Not Found";
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


        public async Task<APIResponseModel> Delete(int userId)
        {
            APIResponseModel responseModel = new APIResponseModel();
            try
            {
                using (var connection = _hSMDBContext)
                {
                    TblPatientModel? patient = await _hSMDBContext.TblPatients.Where(x => x.UserId == userId).FirstOrDefaultAsync();

                    TblUserModel? user = await _hSMDBContext.TblUsers.Where(x => x.UserId == userId).FirstOrDefaultAsync();

                    if (patient != null || user != null) 
                    {
                        connection.TblPatients.Remove(patient);
                        connection.TblUsers.Remove(user);

                        await _hSMDBContext.SaveChangesAsync(); 

                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Deleted Successfully";
                    }
                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "User ID Not Found";
                        responseModel.Data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException?.Message ?? ex.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<APIResponseModel> Update(GetTblPatientViewModel update)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hSMDBContext)
                {
                    connection.Database.BeginTransaction();
                    bool DuplicateMobile = connection.TblUsers
                        .Any(x => x.UserId == update.UserId);

                    try
                    {

                        if (!DuplicateMobile)
                        {

                            TblUserModel user = new TblUserModel()
                            {
                                Email = update.Email,
                                Password = update.Password,
                                FullName = update.Email,
                                RoleId = update.RoleId,
                            };

                            //connection.TblUsers.Update(user);
                            await connection.SaveChangesAsync();

                            if (update.RoleId == 9)
                            {
                                connection.TblPatients.Update(new TblPatientModel()
                                {
                                    DOB = update.DOB,
                                    Gender = update.Gender,
                                    Address = update.Address,
                                    Blood_Group = update.Blood_Group,
                                    Emergency_Contact = update.Emergency_Contact,
                                    Medical_History = update.Medical_History,
                                    UserId = user.UserId,

                                });

                                await connection.SaveChangesAsync();
                                connection.Database.CommitTransaction();
                            }

                            responseModel.Data = true;
                            responseModel.StatusCode = HttpStatusCode.OK;
                            responseModel.Message = "Update Successfully";
                        }
                        else
                        {
                            responseModel.StatusCode = HttpStatusCode.BadRequest;
                            responseModel.Message = "Duplicate Mobile Number Found";
                            responseModel.Data = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        connection.Database.RollbackTransaction();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = false;
            }

            return responseModel;
        }


        //public async Task<APIResponseModel> Update(GetTblPatientViewModel objuser)
        //{
        //    APIResponseModel response = new APIResponseModel();
        //    try
        //    {
        //        using (var connection = _hSMDBContext)
        //        { 
        //            GetTblPatientViewModel? update  = ;
        //        if (update != null)
        //        {
        //            update.FullName = objuser.FullName;
        //            update.Address = objuser.Address;
        //            update.Email = objuser.Email;
        //            update.Password = objuser.Password;

        //            await connection.SaveChangesAsync();    
        //            response.Data = (int)objuser.UserID;
        //            response.Message = "record updated successfully";
        //            response.IsSuccess = true;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        response.Data = null;
        //        response.Message = "Something went wrong";
        //        response.IsSuccess = false;
        //    }
        //    return response;
        //}

        public async Task<APIResponseModel> Add(GetTblPatientViewModel patient)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hSMDBContext)
                {
                    connection.Database.BeginTransaction();
                    bool duplicateEmail = connection.TblUsers
                        .Any(x => x.Email.ToLower() == patient.Email.ToLower());

                    try
                    {
                        if (!duplicateEmail)
                        {

                            TblUserModel user = new TblUserModel()
                            {
                                Email = patient.Email,
                                Password = patient.Password,
                                FullName = patient.FullName,
                                RoleId = patient.RoleId,
                                MobileNumber = patient.MobilNumber,
                            };

                            await connection.TblUsers.AddAsync(user);
                            await connection.SaveChangesAsync();


                            if (patient.RoleId == 9)
                            {
                                await connection.TblPatients.AddAsync(new TblPatientModel()
                                {
                                    DOB = patient.DOB,
                                    Gender = patient.Gender,
                                    Address = patient.Address,
                                    Blood_Group = patient.Blood_Group,
                                    Emergency_Contact = patient.Emergency_Contact,
                                    Medical_History = patient.Medical_History,
                                    UserId = user.UserId,


                                });

                                await connection.SaveChangesAsync();
                                connection.Database.CommitTransaction();

                            }

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
                    catch (Exception ex)
                    {
                        connection.Database.RollbackTransaction();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = false;
            }
            return responseModel;
        }

        public async Task<APIResponseModel> GetAll(string searchBy = null)
        {
            APIResponseModel responseModel = new ();
            try
            {
                List<GetTblPatientViewModel2> lstUsers = new();
                using (var connection = _hSMDBContext)
                {
                    lstUsers = await connection.getTblPatientViewModel2.FromSqlRaw($@"select TblPatient.PatientId,TblUser.FullName,TblUser.MobileNumber,
                    TblUser.Email,TblPatient.Blood_Group ,TblPatient.[Address],
                    TblPatient.Emergency_Contact from TblUser inner join TblPatient
                    on TblPatient.UserId=TblUser.UserId where FullName like '%{searchBy}%'").ToListAsync();
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

        //    public async Task<APIResponseModel> GetbyId(int id)
        //    {
        //        APIResponseModel responseModel = new ();
        //        try
        //        {
        //            using(var connection = _hSMDBContext)
        //            {
        //                TblFeedbackModel data = await connection.TblFeedbacks.Where(x => x.PatientId == id).FirstOrDefaultAsync();
        //                if(data == null)
        //                {
        //                    responseModel.Data = true;
        //                    responseModel.StatusCode = HttpStatusCode.OK;
        //                    //responseModel.Message = data.PatientId;
        //                    responseModel.Message = data.PatientId;
        //                }
        //                else
        //                {
        //                    responseModel.StatusCode = HttpStatusCode.BadRequest;
        //                    responseModel.Message = "ID Not Found";
        //                    responseModel.Data = false;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            responseModel.StatusCode = HttpStatusCode.InternalServerError;
        //            responseModel.Message = ex.InnerException.Message;
        //            responseModel.Data = null;
        //        }
        //        return responseModel;
        //    }
    }
}

