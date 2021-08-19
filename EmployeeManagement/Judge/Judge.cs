using EmployeeManagement.ViewModel;
using System;

namespace EmployeeManagement.Judge
{
    /// <summary>
    /// 入力値の判定を行うクラス
    /// </summary>
    /// <remarks>
    /// 入力値の判定を行う
    /// </remarks>
    public class ValueJudge
    {
        /// <summary>
        /// 入力値の判定を行う
        /// </summary>
        /// <remarks>
        /// 入力値が未入力かどうか判定する
        /// </remarks> 
        /// <param name="checkedValue">入力した値</param>
        public bool Judge(string checkedValue)
        {
            if (!string.IsNullOrEmpty(checkedValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}