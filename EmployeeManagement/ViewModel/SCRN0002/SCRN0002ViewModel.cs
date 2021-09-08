using EmployeeManagement.Session;
using System.Collections.Generic;

namespace EmployeeManagement.ViewModel
{
    /// <summary>
    /// 登録画面のViewModel
    /// </summary>
    /// <remarks>
    /// 登録画面処理に利用するViewModel
    /// </remarks>
    public class SCRN0002ViewModel
    {
        /// <summary>
        /// SCRN0002コンストラクタ
        /// </summary>
        /// <remarks>
        /// Viewで利用するエラーメッセージリスト作成
        /// </remarks>
        public SCRN0002ViewModel()
        {
            ErrorMessageList = new List<DisplayDinoteErrMessage>();
            AffiliationList = new List<AffiliationInfo>();
            PositionList = new List<PositionInfo>();
        }
        public string EmployeeID { set; get; }
        public IList<DisplayDinoteErrMessage> ErrorMessageList { get; set; }
        public IList<AffiliationInfo> AffiliationList { get; set; }
        public IList<PositionInfo> PositionList { get; set; }
        public string AffiliationCd { get; set; }
        public string PositionCd { get; set; }
        public string EmployeeName { get; set; }
        public int Gender { get; set; }
        public string BirthDay { get; set; }
        public bool ForeignNationality { get; set; }
        public string BaseSalary { get; set; }
        public string Memo { get; set; }
    }
}
