namespace HMSAPI.Model.GenericModel
{
    public class SecurityModel
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
        public int VersionNo { get; set; }
        public int IncreamentVersion()
        {
            return VersionNo += 1;
        }
    }
}
