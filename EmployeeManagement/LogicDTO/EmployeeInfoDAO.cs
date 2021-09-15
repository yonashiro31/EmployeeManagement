using System;

namespace EmployeeManagement.LogicDTO
{
    /// <summary>
    /// 社員情報のDAO
    /// </summary>
    /// <remarks>登録用社員情報用のプロパティを宣言する</remarks>
    public class EmployeeInfoDAO
    {
        /// <summary>社員IDプロパティ</summary>
        /// <remarks>DAO用の社員IDコード</remarks>
        /// <value>社員IDプロパティ</value>
        public string EmployeeID { set; get; }
        /// <summary>所属コードプロパティ</summary>
        /// <remarks>DAO用の所属コード</remarks>
        /// <value>所属コードプロパティ</value>
        public string AffiliationCd { get; set; }
        /// <summary>役職コードプロパティ</summary>
        /// <remarks>DAO用の役職コード</remarks>
        /// <value>役職コードプロパティ</value>
        public string PositionCd { get; set; }
        /// <summary>氏名プロパティ</summary>
        /// <remarks>DAO用の氏名</remarks>
        /// <value>氏名プロパティ</value>
        public string EmployeeNm { get; set; }
        /// <summary>性別プロパティ</summary>
        /// <remarks>DAO用の性別</remarks>
        /// <value>性別プロパティ</value>
        public int Gender { get; set; }
        /// <summary>生年月日プロパティ</summary>
        /// <remarks>DAO用の生年月日</remarks>
        /// <value>生年月日プロパティ</value>
        public DateTime BirthDay { get; set; }
        /// <summary>外国籍プロパティ</summary>
        /// <remarks>DAO用の外国籍</remarks>
        /// <value>外国籍プロパティ</value>
        public bool ForeignNationality { get; set; }
        /// <summary>基本給料プロパティ</summary>
        /// <remarks>DAO用の基本給料</remarks>
        /// <value>基本給料プロパティ</value>
        public Decimal BaseSalary { get; set; }
        /// <summary>備考プロパティ</summary>
        /// <remarks>DAO用の備考</remarks>
        /// <value>備考プロパティ</value>
        public string Memo { get; set; }
        /// <summary>登録ユーザプロパティ</summary>
        /// <remarks>DAO用の登録ユーザ</remarks>
        /// <value>登録ユーザプロパティ</value>
        public string InsertUser { get; set; }
        /// <summary>登録日時プロパティ</summary>
        /// <remarks>DAO用の登録日時</remarks>
        /// <value>登録日時プロパティ</value>
        public DateTime InsertTime { get; set; }
        /// <summary>更新ユーザプロパティ</summary>
        /// <remarks>DAO用の更新ユーザ</remarks>
        /// <value>更新ユーザプロパティ</value>
        public string UpdateUser { get; set; }
        /// <summary>更新日時プロパティ</summary>
        /// <remarks>DAO用の更新日時</remarks>
        /// <value>更新日時プロパティ</value>
        public DateTime UpdateTime { get; set; }

    }
}
