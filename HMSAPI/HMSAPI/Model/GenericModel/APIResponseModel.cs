using System.Net;

namespace HMSAPI.Model.GenericModel
{
    public class APIResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public object? Data { get; set; }
        public string? Message { get; set; }
    }
}
