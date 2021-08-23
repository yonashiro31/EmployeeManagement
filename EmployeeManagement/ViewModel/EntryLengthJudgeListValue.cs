using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    public class EntryLengthJudgeListValue
    {
        public string EmployeeID { set; get; }
        public string AffiliationCd { get; set; }
        public string PositionCd { get; set; }
        public string EmployeeName { get; set; }
        public DateTime BirthDay { get; set; }
        public string BaseSalary { get; set; }
    }
}
