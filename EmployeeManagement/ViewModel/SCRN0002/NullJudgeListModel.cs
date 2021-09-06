using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    /// <summary>
    /// 未入力単項目チェック時に使用するリスト
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public class NullJudgeListModel
    {
        public NullJudgeListModel(string employeeDate)
        {
            EmployeeDate = employeeDate;
        }
        public string EmployeeDate { get; set; }

    }
}




