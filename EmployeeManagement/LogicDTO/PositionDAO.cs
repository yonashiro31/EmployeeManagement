namespace EmployeeManagement.LogicDTO
{
    /// <summary>
    /// 役職情報DAO
    /// </summary>
    /// <remarks>役職情報用のプロパティを宣言する</remarks>
    public class PositionDAO
    {
        /// <summary>役職コードプロパティ</summary>
        /// <remarks>DAO用の役職コード</remarks>
        /// <value>役職コードプロパティ</value>
        public string PositionCd { get; set; }
        /// <summary>等級コードプロパティ</summary>
        /// <remarks>DAO用の等級コード</remarks>
        /// <value>等級コードプロパティ</value>
        public string GradeCd { get; set; }
        /// <summary>号棒コードプロパティ</summary>
        /// <remarks>DAO用の号棒コード</remarks>
        /// <value>号棒コードプロパティ</value>
        public string RankCd { get; set; }
        /// <summary>役職名プロパティ</summary>
        /// <remarks>DAO用の役職名コード</remarks>
        /// <value>役職名コードプロパティ</value>
        public string PositionNm { get; set; }
    }
}
