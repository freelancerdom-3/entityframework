namespace HMSAPI.Model.EmailModel
{
    public class EmailBillRequest
    {
        public int BillId { get; set; }
        public string? PdfBase64 { get; set; }
    }
}
