using EmployeeManagement.Constants;
using EmployeeManagement.LogicDTO;
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
        /// <param name="targetValue">入力した値</param>
        public bool EnteredNullJudge(string targetValue)
        {
            if (!string.IsNullOrEmpty(targetValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EnteredValueLengthJudge(string targetValue, int maxDigit)
        {

            if (string.IsNullOrEmpty(targetValue))
            {
                return true;
            }
            // ここで未入力の引数を受け取ると例外発生するため、
            // 上記コードで未入力時は処理が発生しないようにする
            if (targetValue.Length <= maxDigit)
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
        /// <param name="min">最大許容桁数</param>
        /// <param name="max">最小許容桁数</param>
        /// <returns>合否と該当エラーメッセージを返す</returns>
        public (List<string>, bool) ValueCheck(int min, int max)
        {
            ErrorMessageConstants errorMessages = new ErrorMessageConstants();
            bool result = true;

            switch (min, max)
            {
                case (8, 8):
                    errorMessages.itemNameMessageList.Add(ErrorMessageConstants.IdMessage);
                    break;
                case (1, 32):
                    errorMessages.itemNameMessageList.Add(ErrorMessageConstants.NameMessage);
                    break;
                case (9, 9):
                    errorMessages.itemNameMessageList.Add(ErrorMessageConstants.BirthDayMessage);
                    break;
                case (1, 8):
                    errorMessages.itemNameMessageList.Add(ErrorMessageConstants.BaseSalaryMessage);

                    break;
                default:
                    result = false;
                    break;
            }
            return (errorMessages.itemNameMessageList, result);
        }

        /// <summary>
        /// 部署情報のチェックを行うメソッド
        /// </summary>
        /// <param name="affiliation">部署情報</param>
        /// <returns>判定に応じて必要値を格納する</returns>
        public string AffiliationNmCheck(AffiliationDAO affiliation)
        {
            if (affiliation.BrunchCd != "00")
            {
                return affiliation.BrunchNm;
            }
            if (affiliation.GroupCd != "00")
            {
                return affiliation.GroupNm;
            }
            else
            {
                return affiliation.ManagementNm;
            }
        }
    }
}
