using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    public class EntryJudgeListModel
    {
        public List<EntryJudgeListModel> NullCheckList { get; set; }
        public string EmployeeID { get; set; }
        public string AffiliationCd { get; set; }
        public string PositionCd { get; set; }
        public string EmployeeName { get; set; }
        public string BaseSalary { get; set; }
    }
}




