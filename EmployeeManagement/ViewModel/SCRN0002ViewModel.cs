using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    public class SCRN0002ViewModel
    {
        public SCRN0002ViewModel()
        {
            ErrorMessageList = new List<ErrorMessageModel>();
           
        }
        public string EmployeeID { set; get; }
        public IList<ErrorMessageModel> ErrorMessageList { get; set; }
       
        public string AffiliationCd { get; set; }
        public string PositionCd { get; set; }
        public string EmployeeName { get; set; }
        public int Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public bool ForeignNationality { get; set; }
        public string BaseSalary { get; set; }
    }
}
