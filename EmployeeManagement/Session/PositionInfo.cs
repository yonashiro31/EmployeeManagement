namespace EmployeeManagement.Session
{
    /// <summary>
    /// 役職情報を保持するクラス
    /// </summary>
    /// <remarks>ドロップダウンリストに利用する役職情報用プロパティを宣言する</remarks>
    public class PositionInfo
    {
        public string PositionCd { get; set; }
        public string PositionNm { get; set; }
    }
}
