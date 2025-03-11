namespace HMSAPI.Model.GenericModel
{
    public class SecurityModel
    {
        public int? CreateBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public bool? IsActive { get; set; }
        public int VersionNo { get; set; }
        public int IncreamentVersion()
        {
            return VersionNo += 1;
        }
    }
}
