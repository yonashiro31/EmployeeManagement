using EmployeeManagement.ViewModel;
using System;
using System.Collections.Generic;

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
        public bool EnteredValueLengthJudge(string targetValue, int MinDigit, int maxDigit)
        {

            if (string.IsNullOrEmpty(targetValue))
            {
                return true;
            }
            // ここで未入力の引数を受け取ると例外発生するため、
            // 上のコードで未入力時は処理が発生しないようにする
            if (targetValue.Length >= MinDigit && targetValue.Length <= maxDigit)
            {
                return true;
            }
            else
            {
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
        /// <summary>
        /// 入力値の種別を判別するメソッド
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public (List<string>, bool) ValueCheck(int min, int max)
        {
            ErrorMessages errorMessages = new ErrorMessages();
            bool result = true;
            switch (min, max)
            {
               

                case (8, 8):
                    errorMessages.itemNameMessageList.Add(ErrorMessages.IdMessage);
                    break;
                case (1, 32):
                    errorMessages.itemNameMessageList.Add(ErrorMessages.NameMessage);
                    break;
                case (9, 9):
                    errorMessages.itemNameMessageList.Add(ErrorMessages.BirthDayMessage);
                    break;
                case (1, 8):
                    errorMessages.itemNameMessageList.Add(ErrorMessages.BaseSalaryMessage);

                    break;
                default: result = false;
                    break;
            }
            return (errorMessages.itemNameMessageList,result);

        }
    }
}
