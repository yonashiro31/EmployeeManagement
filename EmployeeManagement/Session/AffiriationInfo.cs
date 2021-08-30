using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Session
{
    public class AffiriationInfo
    {
    public AffiriationInfo(string affiriationCd ,string affiriationNm)
        {
            AffiriationCd = affiriationCd;
            AffiriationNm = affiriationNm;
        }

        public string AffiriationCd { get; set; }
        public string AffiriationNm { get; set; }   
    }
}
