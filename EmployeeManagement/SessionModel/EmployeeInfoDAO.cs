using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.SessionModel
{
    public class EmployeeInfoDAO
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public EmployeeInfoDAO()
        {
           
        }
        public string EmployeeID { set; get; }
        public string AffiliationCd { get; set; }
        public string PositionCd { get; set; }
        public string EmployeeNm { get; set; }
        public string Gender { get; set; }
        public string BirthDay { get; set; }
        public bool ForeignNationality { get; set; }
        public string BaseSalary { get; set; }
        public string Memo { get; set; }
    }
}
