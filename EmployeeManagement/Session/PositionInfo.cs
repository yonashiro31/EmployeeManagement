namespace EmployeeManagement.Session
{
    /// <summary>
    /// 役職情報を保持するクラス
    /// </summary>
    /// <remarks>ドロップダウンリストに利用する役職情報用プロパティを宣言する</remarks>
    public class PositionInfo
    {
        /// <summary>役職コードプロパティ</summary>
        /// <remarks>ドロップダウンリスト用用の役職コード</remarks>
        /// <value>役職コードプロパティ</value>
        public string PositionCd { get; set; }
        /// <summary>役職名プロパティ</summary>
        /// <remarks>ドロップダウンリスト用の役職名コード</remarks>
        /// <value>役職名コードプロパティ</value>
        public string PositionNm { get; set; }
    }
}
