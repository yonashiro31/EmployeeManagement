namespace EmployeeManagement.LogicDTO
{
    /// <summary>
    /// 部署情報のDAO
    /// </summary>
    /// <remarks>部署情報用プロパティを宣言する</remarks>
    public class AffiliationDAO
    {
        /// <summary>所属コードプロパティ</summary>
        /// <remarks>DAO用の所属コード</remarks>
        /// <value>所属コードプロパティ</value>
        public string AffiliationCd { get; set; }
        /// <summary>部門管理コードプロパティ</summary>
        /// <remarks>DAO用の部門管理コード</remarks>
        /// <value>部門管理コードプロパティ</value>
        public string ManagementCd { get; set; }
        /// <summary>部門コードプロパティ</summary>
        /// <remarks>DAO用の部門コード</remarks>
        /// <value>部門コードプロパティ</value>
        public string BrunchCd { get; set; }
        /// <summary>グループコードプロパティ</summary>
        /// <remarks>DAO用のグループコード</remarks>
        /// <value>グループコードプロパティ</value>
        public string GroupCd { get; set; }
        /// <summary>管理名プロパティ</summary>
        /// <remarks>DAO用の管理名</remarks>
        /// <value>管理名プロパティ</value>
        public string ManagementNm { get; set; }
        /// <summary>部門名プロパティ</summary>
        /// <remarks>DAO用の部門名</remarks>
        /// <value>部門名プロパティ</value>
        public string BrunchNm { get; set; }
        /// <summary>グループ名プロパティ</summary>
        /// <remarks>DAO用のグループ名</remarks>
        /// <value>グループ名プロパティ</value>
        public string GroupNm { get; set; }
        /// <summary>管理者プロパティ</summary>
        /// <remarks>DAO用の管理者コード</remarks>
        /// <value>管理者プロパティ</value>
        public string ManagementEmployeeId { get; set; }
        /// <summary>部署名プロパティ</summary>
        /// <remarks>DAO用の部署名コード</remarks>
        /// <value>部署名プロパティ</value>
        public string AffiliationNm { get; set; }
    }
}
