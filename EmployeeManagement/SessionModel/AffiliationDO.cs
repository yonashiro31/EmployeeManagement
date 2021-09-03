using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.SessionModel
{
    public class AffiliationDO
    {
        public List<AffiliationDO> List { get; set; }
        public string AffiliationCd { get; set; }
        public string ManagementCd { get; set; }
        public string BrunchCd { get; set; }
        public string GroupCd { get; set; }
        public string ManagementNm { get; set; }
        public string BrunchNm { get; set; }
        public string GroupNm { get; set; }
        public string ManagementEmployeeId { get; set; }
        public string AffiliationNm { get; set; }
    }
}
