using System.Net;
using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblFeedback;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Model.TblPatient;
using HMSAPI.Model.TblPatient.ViewModel;
using HMSAPI.Model.TblRole;
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

        public async Task<APIResponseModel> Deletebyid(int userId)
        {
            APIResponseModel responseModel = new APIResponseModel();
            try
            {
                using (var connection = _hSMDBContext)
                {
                    TblPatientModel? patient = await _hSMDBContext.TblPatients.Where(x => x.PatientId == userId).FirstOrDefaultAsync();

                    //TblUserModel? user = await _hSMDBContext.TblUsers.Where(x => x.UserId == userId).FirstOrDefaultAsync();

                    //if (patient != null || user != null)
                    //{
                    //    connection.TblPatients.Remove(patient);
                    //    //connection.TblUsers.Remove(user);

                    //    await _hSMDBContext.SaveChangesAsync();

                    //    responseModel.Data = true;
                    //    responseModel.StatusCode = HttpStatusCode.OK;
                    //    responseModel.Message = "Deleted Successfully";
                    //}
                    //else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "ID Not Found";
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
                            patient.VersionNo = 1;
                            TblUserModel user = new TblUserModel()
                            {
                                Email = patient.Email,
                                Password = patient.Password,
                                FullName = patient.FullName,
                                RoleId = patient.RoleId,
                                MobileNumber = patient.MobilNumber,
                                CreateBy = patient.CreateBy,
                                CreatedOn = patient.CreatedOn,
                                IsActive = patient.IsActive,
                                VersionNo = 1,
                                
                            };

                            await connection.TblUsers.AddAsync(user);
                            await connection.SaveChangesAsync();


                            if (patient.RoleId == 9)
                            {
                                patient.VersionNo = 1;
                                await connection.TblPatients.AddAsync(new TblPatientModel()
                                {
                                    DOB = patient.DOB,
                                    Gender = patient.Gender,
                                    Address = patient.Address,
                                    Blood_Group = patient.Blood_Group,
                                    Emergency_Contact = patient.Emergency_Contact,
                                    Medical_History = patient.Medical_History,
                                    UserId = user.UserId,
                                    CreateBy = user.CreateBy,
                                    CreatedOn = user.CreatedOn,
                                    IsActive = user.IsActive,
                                    VersionNo = 1,

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
                    lstUsers = await connection.GetTblPatientViewModel2.FromSqlRaw($@"select TblPatient.*,TblUser.FullName,TblUser.MobileNumber,
                    TblUser.Email from TblUser inner join TblPatient
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

        public async  Task<APIResponseModel> GetById(int id)
        {
            APIResponseModel responseModel = new ();
            try
            {

                using (var connection = _hSMDBContext)
                {
                    TblPatientModel? data = connection.TblPatients.Where(x => x.PatientId == id).FirstOrDefault();
                    
                    responseModel.Data = new
                    {
                        data.PatientId,
                        data.DOB,
                        data.Gender,
                        data.Address,
                        data.Blood_Group,
                        data.Emergency_Contact,
                        data.Medical_History,
                    };
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Inserted Successfully";
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


        public async Task<APIResponseModel> Update(GetTblPatientViewModel update)
        {
            APIResponseModel responseModel = new();
            try
            {

                using (var connection = _hSMDBContext)
                {
                    await using var transaction = await connection.Database.BeginTransactionAsync();
                    try
                    {

                        TblUserModel? existingUser = await connection.TblUsers
                            .FirstOrDefaultAsync(x => x.UserId == update.UserId);

                        if (existingUser != null)
                        {
                            existingUser.Email = update.Email;
                            existingUser.Password = update.Password;
                            existingUser.FullName = update.FullName;
                            existingUser.RoleId = update.RoleId;
                            existingUser.UpdateBy = update.UpdateBy;
                            existingUser.UpdateOn= update.UpdateOn;
                            existingUser.IsActive = update.IsActive;
                            existingUser.VersionNo += 1;
                        }
                        connection.TblUsers.Update(existingUser);
                        await connection.SaveChangesAsync();

                        if (update.RoleId == 9)
                        {

                            TblPatientModel? existingPatient = await connection.TblPatients
                                .FirstOrDefaultAsync(p => p.PatientId == update.PatientId);

                            if (existingPatient != null)
                            {
                                existingPatient.DOB = update.DOB;
                                existingPatient.Gender = update.Gender;
                                existingPatient.Address = update.Address;
                                existingPatient.Blood_Group = update.Blood_Group;
                                existingPatient.Emergency_Contact = update.Emergency_Contact;
                                existingPatient.Medical_History = update.Medical_History;
                                existingPatient.UserId = update.UserId;
                                existingPatient.UpdateBy = update.UpdateBy;
                                existingPatient.UpdateOn = update.UpdateOn;
                                existingPatient.IsActive = update.IsActive;
                                existingPatient.VersionNo += 1;
                            }
                            connection.TblPatients.Update(existingPatient);
                            await connection.SaveChangesAsync();
                        }

                        await transaction.CommitAsync();

                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Update Successfully";
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        responseModel.StatusCode = HttpStatusCode.InternalServerError;
                        responseModel.Message = ex.Message;
                        responseModel.Data = false;
                    }
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


