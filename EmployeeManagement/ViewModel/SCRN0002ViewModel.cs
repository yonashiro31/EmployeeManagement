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
        public string Gender { get; set; }
        public string BirthDay { get; set; }
        public bool ForeignNationality
        {
            get { return this.ForeignNationality; }
            set { this.ForeignNationality = false; }
        }
        public string BaseSalary { get; set; }
    }
}
