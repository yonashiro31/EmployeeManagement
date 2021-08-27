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
        public bool EnteredNullJudge(string checkedValue)
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

        // 桁数は引数に入れてしまう
        public bool EnteredValueLengthJudge(string checkedValue,int digit)
        {
            
            if (string.IsNullOrEmpty(checkedValue))
            {
                return true;
            }
            // ここで未入力の引数を受け取ると例外発生するため、
            // 上のコードで未入力時は処理が発生しないようにする
            if (checkedValue.Length == digit)
            {
                return true;
            }
            else {
                return false;
            }         
        }

        /// <summary>
        /// 入力した日付の判定を行う
        /// </summary>
        /// <remarks>
        /// 入力値が未入力かどうか判定する
        /// </remarks> 
        /// <param name="checkedValue">入力した値</param>
        public bool DateTimeJudge(DateTime checkedValue)
        {
            if (checkedValue == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }      
        public bool NumJudge(decimal checkedValue)
        {
            if (checkedValue == 0)
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