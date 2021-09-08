using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    /// <summary>
    /// 桁数チェック時用に要素を抜き出すリストクラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public class LengthJudgeListModel
    {
        /// <summary>
        /// 桁数チェック時用に要素を抜き出すリスト
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public LengthJudgeListModel(string employeeDate,int maxJudgedigit)
        {      
            EmployeeDate = employeeDate;
            MaxJudgedigit = maxJudgedigit;
        }

        public string EmployeeDate { get; set; }
        public int MinJudgedigit { get; set; }
        public int MaxJudgedigit { get; set; }
    }
}
