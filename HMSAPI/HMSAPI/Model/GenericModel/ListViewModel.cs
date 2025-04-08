namespace HMSAPI.Model.GenericModel
{
    public class ListViewModel
    {
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int VersionNo { get; set; }
        public bool? IsActive { get; set; }
    }
}
