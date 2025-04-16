using HMSAPI.EFContext;
using HMSAPI.Model.DashboardCardDetail;
using HMSAPI.Model.GenericModel;
using HMSAPI.Model.TblMedicineType;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
    }
}
