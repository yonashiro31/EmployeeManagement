namespace EmployeeManagement.Session
{
    /// <summary>
    /// 部署情報クラス
    /// </summary>
    /// <remarks>
    /// ドロップダウンリスト用に部署情報プロパティを宣言する
    /// </remarks>
    public class AffiliationInfo
    {
        /// <summary>所属コードプロパティ</summary>
        /// <remarks>ドロップダウンリスト用所属コード</remarks>
        /// <value>所属コードプロパティ</value>
        public string AffiliationCd { get; set; }
        /// <summary>部署名プロパティ</summary>
        /// <remarks>ドロップダウンリスト用用の部署名コード</remarks>
        /// <value>部署名プロパティ</value>
        public string AffiliationNm { get; set; }   
    }
}
