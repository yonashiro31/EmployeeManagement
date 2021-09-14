namespace EmployeeManagement.LogicDTO
{
    /// <summary>
    /// 役職情報DAO
    /// </summary>
    /// <remarks>役職情報用のプロパティを宣言する</remarks>
    public class PositionDAO
    {
        public string PositionCd { get; set; }
        public string GradeCd { get; set; }
        public string RankCd { get; set; }
        public string PositionNm { get; set; }
    }
}
