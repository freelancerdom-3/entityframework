using HMSAPI.EFContext;
using HMSAPI.Model.DashboardCardDetail;
using HMSAPI.Model.GenericModel;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data.Common;
using System.Net;

namespace HMSAPI.Service.DashboardCardDetail
{
    public class DashboardCardDetail : IDashboardCardDetail
    {
        private readonly HSMDBContext _hsmDBContext;

        public DashboardCardDetail(HSMDBContext hsmDBContext)
        {
            _hsmDBContext = hsmDBContext;
        }

        public async Task<APIResponseModel> GetAllCardDetails()
        {
            APIResponseModel responseModel = new APIResponseModel();

            DashboardCardDetailViewModel viewModel = new DashboardCardDetailViewModel();

            List<DashboardCardDetailViewModel> viewModelList = new List<DashboardCardDetailViewModel>();

            try
            {
                using (var connection = _hsmDBContext)
                {
                    var results = connection.Database.SqlQueryRaw<int>($@"
                                    SELECT CAST((SELECT SUM(QuantityAvailable) AS totalMedicineStock
                                    FROM TblMedicineType) AS INT)
                                    
                                    UNION ALL
                                    
                                    SELECT CAST((SELECT ISNULL(SUM(TotalAmount), 0) AS totalAmountOfBillGeneratedToday
                                    FROM TblBill
                                    WHERE BillDate = CAST(GETDATE() AS DATE)) AS INT)
                                    
                                    UNION ALL
                                    
                                    SELECT CAST((SELECT COUNT(*) AS totalPatientsVisitedToday
                                    FROM TblPateintDoctormapping
                                    WHERE CAST(CreatedOn AS DATE) = CAST(GETDATE() AS DATE)) AS INT) 
                                    AS DASHBOARD_CARD_DETAIL").ToList();
                    viewModel.totalMedicineStock = results[0];
                    viewModel.totalPatientsVisitedToday = results[2];
                    viewModel.totalAmountOfBillGeneratedToday = results[1];
                }


                responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                responseModel.Message = "Dashboard card details retrieved successfully";
                responseModel.Data = viewModel;

            }
            catch (Exception ex)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<APIResponseModel> GetPatientTableDetails()
        {
            APIResponseModel responseModel = new APIResponseModel();
            List<PatientTableViewModel> patientTableViewModels = new List<PatientTableViewModel>();
            try
            {
                using(var connection = _hsmDBContext)
                {
                    patientTableViewModels = connection.patientTableViewModels.FromSqlRaw($@"SELECT 
    tp.PateintDoctormappingId,
	tr.TreatmentDetailsId,
	tbb.TotalAmount,
	tbb.PaymentMethod,
    tu.FullName AS DocterName,
    tuu.FullName AS PatientName,
    tpa.Gender,
    ISNULL(tbb.BillDate, tr.TreatmentDate) AS FinalDate,
    CASE 
        WHEN tbb.BillDate IS NOT NULL THEN 1 
        ELSE 0 
    END AS DateSource
FROM TblPateintDoctormapping tp
INNER JOIN TblTreatmentDetails tr ON tr.TreatmentDetailsId = tp.TreatmentDetailsId
LEFT JOIN TblBill tbb ON tbb.TreatmentDetailsId = tr.TreatmentDetailsId
INNER JOIN TblPatient tpa ON tpa.PatientId = tr.PatientId
INNER JOIN TblUser tuu ON tuu.UserId = tpa.UserId
INNER JOIN TblUser tu ON tu.UserId = tp.UserId
WHERE tbb.BillDate IS NULL

UNION

SELECT 
    tp.PateintDoctormappingId,
	tr.TreatmentDetailsId,
	tbb.TotalAmount,
	tbb.PaymentMethod,
    tu.FullName AS DocterName,
    tuu.FullName AS PatientName,
    tpa.Gender,
    tbb.BillDate AS FinalDate,
    1 AS DateSource
FROM TblPateintDoctormapping tp
INNER JOIN TblTreatmentDetails tr ON tr.TreatmentDetailsId = tp.TreatmentDetailsId
INNER JOIN TblBill tbb ON tbb.TreatmentDetailsId = tr.TreatmentDetailsId
INNER JOIN TblPatient tpa ON tpa.PatientId = tr.PatientId
INNER JOIN TblUser tuu ON tuu.UserId = tpa.UserId
INNER JOIN TblUser tu ON tu.UserId = tp.UserId").ToList();
                    responseModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responseModel.Message = "Get All Record Successfully";
                    responseModel.Data = patientTableViewModels;
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responseModel.Message = ex.InnerException.Message;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<APIResponseModel> GetFeedbackCardDetails()
        {
            APIResponseModel responseModel = new APIResponseModel();
            List<FeedbackCardDetailsViewModel> lstUsers = new List<FeedbackCardDetailsViewModel>();

            try
            {


                using (var connection = _hsmDBContext)
                {
                    string query = "SELECT TOP 5 tf.FeedbackId,tu.FullName,tf.Comments FROM TblFeedback tf INNER JOIN TblPatient tp ON tp.PatientId = tf.PatientId INNER JOIN TblUser tu ON tp.UserId = tu.UserId ORDER BY tf.CreatedOn DESC;";

                    lstUsers = await connection.feedbackcarddetailsviewmodel.FromSqlRaw(query).ToListAsync();


                    responseModel.Data = lstUsers;
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = "Get Record Successfully";
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
