
using HMSAPI.Model.TblShift;
using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using System.Net;
namespace HMSAPI.Service.TblShift

{
    public class TblShift : ITblShift
    {

        private readonly HSMDBContext _hsmDbContext;
        //private object connection;

        public TblShift(HSMDBContext hSMDBContext)
        {
            _hsmDbContext = hSMDBContext;
        }

        public async Task<APIResponseModel> Add(TblShiftModel Shift)
        {
            APIResponseModel responseModel = new();

            try
            {
                using (var connection = _hsmDbContext)
                {

                    // bool duplicateRoleName = connection.TblRoles.Any(x => x.RoleName.ToLower() == roleModel.RoleName.ToLower());

                    bool DuplicateShift = connection.TblShifts.Any(x => x.Shiftname.ToLower() == Shift.Shiftname.ToLower());

                    if (!DuplicateShift)
                    {

                        connection.TblShifts.Add(Shift);
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

        public async Task<APIResponseModel> Delete(int id)
        {
            APIResponseModel responseModel = new();

            try
            {
                using (var connection = _hsmDbContext)
                {

                    TblShiftModel? data = connection.TblShifts.Where(j => j.Shiftid == id).FirstOrDefault();

                    if (data != null)
                    {
                        connection.TblShifts.Remove(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete Successfully";

                    }

                    else
                    {
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        responseModel.Message = "Enter Valid Number";
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

            List<TblShiftModel> shitList = new();

            try
            {
                using (var connection = _hsmDbContext)
                {
                    shitList = string.IsNullOrEmpty(searchBy)? connection.TblShifts.ToList():connection.TblShifts.Where(x=>x.Shiftname==searchBy).ToList();
                    responseModel.Data = shitList;
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

        public async Task<APIResponseModel> GetById(int id)
        {
            APIResponseModel responseModel = new();

           // TblShiftModel data = new TblShiftModel();

            try
            {
                using (var connection = _hsmDbContext)
                {
                   TblShiftModel? data= connection.TblShifts.Where(x=>x.Shiftid==id).FirstOrDefault();
                    responseModel.Data = new
                    {
                      data.Shiftid,
                      data.StartTime,
                      data.EndTime,
                      data.Shiftname,
                    };
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "done";


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

        public async Task<APIResponseModel> Update(int id)
        {
            APIResponseModel responseModel = new();

            try
            {
                using (var connection = _hsmDbContext)
                {

                    TblShiftModel? data = connection.TblShifts.Where(j => j.Shiftid == id).FirstOrDefault();

                    if (data != null)
                    {
                        data.Shiftname = "Mornig Night";
                        connection.TblShifts.Update(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Update Successfully";


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


    }


}
