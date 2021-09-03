using EmployeeManagement.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            ErrorMessageList = new List<ErrorMessageModel>();
            AffiliationList = new List<AffiLiationInfo>();
            PositionList = new List<PositionInfo>();
        }
        public string EmployeeID { set; get; }
        public IList<ErrorMessageModel> ErrorMessageList { get; set; }   
        public IList<AffiLiationInfo> AffiliationList { get; set; }
        public IList<PositionInfo> PositionList { get; set; }
        public string AffiliationCd { get; set; }
        public string PositionCd { get; set; }
        public string EmployeeName { get; set; }
        public int Gender { get; set; }
        public string BirthDay { get; set; }
        public bool ForeignNationality { get; set; }
        public string BaseSalary { get; set; }
    }
}
