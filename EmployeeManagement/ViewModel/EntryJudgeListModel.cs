using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    public class EntryJudgeListModel
    {
        public string[] NullCheckValue;
        public EntryJudgeListModel()
        {
            NullCheckValue = new string[5];
            NullCheckValue[0] = "";
            NullCheckValue[1] = "";
            NullCheckValue[2] = "";
            NullCheckValue[3] = "";
            NullCheckValue[4] = "";
        }
        public string[] NullValue
        {
         
            get
            {
                return NullCheckValue;
            }
        }
        public string EmployeeID { get; set; }
        public string AffiliationCd { get; set; }
        public string PositionCd { get; set; }
        public string EmployeeName { get; set; }
        public string BaseSalary { get; set; }


    }
}




