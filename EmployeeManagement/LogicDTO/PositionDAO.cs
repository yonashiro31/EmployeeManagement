namespace EmployeeManagement.LogicDTO
{
    /// <summary>
    /// 役職情報DAO
    /// </summary>
    /// <remarks>SQLから取得した役職情報を保持する</remarks>
    public class PositionDAO
    {
        public string PositionCd { get; set; }
        public string GradeCd { get; set; }
        public string RankCd { get; set; }
        public string PositionNm { get; set; }
    }
}
