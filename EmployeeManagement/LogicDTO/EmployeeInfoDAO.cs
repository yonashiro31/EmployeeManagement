using System;

namespace EmployeeManagement.LogicDTO
{
    /// <summary>
    /// 社員情報のDAO
    /// </summary>
    /// <remarks>SQLから取得した社員情報を保持する</remarks>
    public class EmployeeInfoDAO
    {
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
