using EmployeeManagement.Session;
using System.Collections.Generic;

namespace EmployeeManagement.ViewModel
{
    /// <summary>
    /// 登録画面のViewModel
    /// </summary>
    /// <remarks>
    /// 入力した値を受け取るプロパティを宣言する
    /// </remarks>
    public class SCRN0003ViewModel
    {
        /// <summary>
        /// SCRN0003コンストラクタ
        /// </summary>
        /// <remarks>
        /// Viewで利用するエラーメッセージリスト作成
        /// </remarks>
        public SCRN0003ViewModel()
        {
            ErrorMessageList = new List<DisplayViewErrMessage>();
            AffiliationList = new List<AffiliationInfo>();
            PositionList = new List<PositionInfo>();
        }
        /// <summary>社員IDプロパティ</summary>
        /// <remarks>ViewModel用社員ID</remarks>
        /// <value>社員IDプロパティ</value>
        public string EmployeeID { set; get; }
        /// <summary>エラーメッセージリストプロパティ</summary>
        /// <remarks>ViewModel用エラーメッセージリスト</remarks>
        /// <value>エラーメッセージリストプロパティ</value>
        public IList<DisplayViewErrMessage> ErrorMessageList { get; set; }
        /// <summary>部署リストプロパティ</summary>
        /// <remarks>ViewModel用部署リスト</remarks>
        /// <value>部署リストプロパティ</value>
        public IList<AffiliationInfo> AffiliationList { get; set; }
        /// <summary>役職リストプロパティ</summary>
        /// <remarks>ViewModel用役職リスト</remarks>
        /// <value>役職リストプロパティ</value>
        public IList<PositionInfo> PositionList { get; set; }
        /// <summary>部署コードプロパティ</summary>
        /// <remarks>ViewModel用部署コード</remarks>
        /// <value>部署コードプロパティ</value>
        public string AffiliationCd { get; set; }
        /// <summary>役職コードプロパティ</summary>
        /// <remarks>ViewModel用役職コード</remarks>
        /// <value>役職コードプロパティ</value>
        public string PositionCd { get; set; }
        /// <summary>氏名プロパティ</summary>
        /// <remarks>ViewModel用氏名</remarks>
        /// <value>氏名プロパティ</value>
        public string EmployeeName { get; set; }
        /// <summary>性別プロパティ</summary>
        /// <remarks>ViewModel用性別</remarks>
        /// <value>性別プロパティ</value>
        public int Gender { get; set; }
        /// <summary>生年月日プロパティ</summary>
        /// <remarks>ViewModel用生年月日</remarks>
        /// <value>生年月日プロパティ</value>
        public string BirthDay { get; set; }
        /// <summary>外国籍プロパティ</summary>
        /// <remarks>ViewModel用外国籍</remarks>
        /// <value>外国籍プロパティ</value>
        public bool ForeignNationality { get; set; }
        /// <summary>基本給料プロパティ</summary>
        /// <remarks>ViewModel用基本給料</remarks>
        /// <value>基本給料プロパティ</value>
        public string BaseSalary { get; set; }
        /// <summary>備考プロパティ</summary>
        /// <remarks>ViewModel用備考</remarks>
        /// <value>備考プロパティ</value>
        public string Memo { get; set; }
    }
}
