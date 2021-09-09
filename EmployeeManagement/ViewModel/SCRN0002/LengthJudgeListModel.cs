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
    /// 桁数チェック時用に要素を抜き出す
    /// </remarks>
    public class LengthJudgeListModel
    {
        /// <summary>
        /// 桁数チェック時用コンストラクタ
        /// </summary>
        /// <remarks>
        /// 桁数チェックに必要な情報と最大桁数を詰める
        /// </remarks>
        public LengthJudgeListModel(string employeeDate, int maxJudgedigit)
        {
            EmployeeDate = employeeDate;
            MaxJudgedigit = maxJudgedigit;
        }

        public string EmployeeDate { get; set; }
        public int MinJudgedigit { get; set; }
        public int MaxJudgedigit { get; set; }
    }
}
