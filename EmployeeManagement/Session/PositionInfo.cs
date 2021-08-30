using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Session
{
    public class PositionInfo
    {
        public PositionInfo(string positionCd, string positionNm)
        {
            PositionCd = positionCd;
            PositionNm = positionNm;
        }
        public string PositionCd { get; set; }
        public string PositionNm { get; set; }
    }
}
