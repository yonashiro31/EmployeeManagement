using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.LogicDTO
{
    /// <summary>
    /// 
    /// </summary>
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
        public int Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public bool ForeignNationality { get; set; }
        public Decimal BaseSalary { get; set; }
        public string Memo { get; set; }
        public string insertUser { get; set; }
        public DateTime insertTime { get; set; }
        public string updateUser { get; set; }
        public DateTime updateTime { get; set; }

    }
}
