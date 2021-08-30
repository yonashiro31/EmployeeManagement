using EmployeeManagement.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    /// <summary>
    /// 登録時に利用する　（現在登録処理でSCRN0002ViewModelになっている部分も差し替える）
    /// </summary>
    public class SCRN0002RequestModel
    {
        public SCRN0002RequestModel()
        {
            EmployeeID = string.Empty;
            AffiliationCd = string.Empty;
            PositionCd = string.Empty;
            EmployeeName = string.Empty;
            Gender = 1;
            BirthDay = string.Empty;
            BaseSalary = string.Empty;
            Memo = string.Empty;
        }
        public string EmployeeID { set; get; }
        public List<AffiriationInfo> AffiriationList { get; set; }
        public List<PositionInfo> PositionList { get; set; }
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
