namespace EmployeeManagement.LogicDTO
{
    /// <summary>
    /// 部署情報のDAO
    /// </summary>
    /// <remarks>部署情報用プロパティを宣言する</remarks>
    public class AffiliationDAO
    {
        public string AffiliationCd { get; set; }
        public string ManagementCd { get; set; }
        public string BrunchCd { get; set; }
        public string GroupCd { get; set; }
        public string ManagementNm { get; set; }
        public string BrunchNm { get; set; }
        public string GroupNm { get; set; }
        public string ManagementEmployeeId { get; set; }
        public string AffiliationNm { get; set; }
    }
}
