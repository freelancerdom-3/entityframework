using System.Net;
using HMSAPI.EFContext;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblHospitalType;
using HMSAPI.Model.TblPatient;
using Microsoft.EntityFrameworkCore;

namespace HMSAPI.Service.TblPatient
{
    public class TblPatient : ITblPatient
    {
        private readonly HSMDBContext _hSMDBContext;

        public TblPatient (HSMDBContext hSMDBContext)
        {
            _hSMDBContext = hSMDBContext;
        }



        public async Task<APIResponseModel> Delete(int id)
        {
            APIResponseModel responseModel = new();
            try
            {
                using (var connection = _hSMDBContext)
                {
                    TblPatientModel? data = await connection.TblPatients.Where(x => x.PatientId == id).FirstOrDefaultAsync();
                    if(data != null)
                    {
                        connection.TblPatients.Remove(data);
                        connection.SaveChanges();
                        responseModel.Data = true;
                        responseModel.StatusCode = HttpStatusCode.OK;
                        responseModel.Message = "Delete Successfully";
                    }
                    else
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
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }






        }
}
