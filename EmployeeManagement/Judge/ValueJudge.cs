using EmployeeManagement.Constant;
using EmployeeManagement.Constants;
using EmployeeManagement.LogicDTO;
using System.Collections.Generic;

namespace EmployeeManagement.Judge
{
    /// <summary>
    /// 入力値の判定を行うクラス
    /// </summary>
    /// <remarks>
    /// 未入力、桁数、種別、部署情報の判定を行う
    /// </remarks>
    public class ValueJudge
    {
        /// <summary>
        /// 入力値が未入力か判定するメソッド
        /// </summary>
        /// <remarks>
        /// 真偽値を返す
        /// </remarks>
        /// <param name="targetValue">入力値</param>
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

        /// <summary>
        /// 入力値の桁数を判定するメソッド
        /// </summary>
        /// <param name="targetValue">入力値</param>
        /// <param name="maxDigit">最大許容桁数</param>
        /// <returns></returns>
        public bool InputValueLengthJudge(string targetValue, int maxDigit)
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
        /// <returns>真偽値と該当エラーメッセージを返す</returns>
        public (List<string>, bool) ValueCheck(int min, int max)
        {
            ErrorMessageConstants errorMessages = new ErrorMessageConstants();
            errorMessages.ItemNameMessageList = new List<string>();
            bool result = true;

            switch (min, max)
            {
                case (CommonConstants.Eight, CommonConstants.Eight):
                    errorMessages.ItemNameMessageList.Add(ErrorMessageConstants.IdMessage);
                    break;
                case (CommonConstants.One, CommonConstants.ThirtyTwo):
                    errorMessages.ItemNameMessageList.Add(ErrorMessageConstants.NameMessage);
                    break;
                case (CommonConstants.One, CommonConstants.Nine):
                    errorMessages.ItemNameMessageList.Add(ErrorMessageConstants.BirthDayMessage);
                    break;
                case (CommonConstants.One, CommonConstants.Eight):
                    errorMessages.ItemNameMessageList.Add(ErrorMessageConstants.BaseSalaryMessage);

                    break;
                default:

                    result = false;
                    break;
            }
            return (errorMessages.ItemNameMessageList, result);
        }

        /// <summary>
        /// 部署情報のチェックを行うメソッド
        /// </summary>
        /// <param name="affiliation">部署情報</param>
        /// <returns>判定に応じて必要値を格納する</returns>
        public string AffiliationNmCheck(AffiliationDAO affiliation)
        {
            if (affiliation.BrunchCd != CommonConstants.Zero)
            {
                return affiliation.BrunchNm;
            };
            if (affiliation.GroupCd != CommonConstants.Zero)
            {
                return affiliation.GroupNm;
            };
            return affiliation.ManagementNm;
        }
    }
}
