using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    /// <summary>
    /// 単項目チェック時に使用するリスト
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public class EntryJudgeListModel
    {

        public EntryJudgeListModel()
            {
            NullJudgeList = new List<string>();
            }

        public List<string> NullJudgeList { get; set; }  

        public string Employees { get; set; }
        public string EmployeeID { get; set; }
        public string AffiliationCd { get; set; }
        public string PositionCd { get; set; }
        public string EmployeeName { get; set; }
        public string BaseSalary { get; set; }


    }
}




