using EmployeeManagement.Constant;
using EmployeeManagement.Constants;
using EmployeeManagement.LogicDTO;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Judge
{
    /// <summary>
    /// 入力値の判定を行うクラス
    /// </summary>
    /// <remarks>
    /// 未入力、桁数、種別、部署情報の判定を行う
    /// </remarks>
    public static class ValueJudge
    {
        /// <summary>
        /// 入力値が未入力か判定するメソッド
        /// </summary>
        /// <remarks>
        /// string型の引数を受け取り、条件分岐する
        /// </remarks>
        /// <param name="targetValue">入力値</param>
        /// <returns>真偽値を返す</returns>
        public static bool EnteredNullJudge(string targetValue)
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
        /// <remarks>
        /// string型とint型の引数を受け取り、条件分岐する
        /// </remarks>
        /// <param name="targetValue">入力値</param>
        /// <param name="maxDigit">最大許容桁数</param>
        /// <returns>真偽値を返却する</returns>
        public static bool InputValueLengthJudge(string targetValue, int maxDigit,int minDigit)
        {
            if (string.IsNullOrEmpty(targetValue))
            {
                return true;
            }
            // ここで未入力の引数を受け取ると例外発生するため、
            // 上記コードで未入力時は処理が発生しないようにする
            if (targetValue.Length <= maxDigit && minDigit <= targetValue.Length)
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
        /// <remarks>最大値と最小値の組み合わせで条件分岐する</remarks>
        /// <param name="min">最大許容桁数</param>
        /// <param name="max">最小許容桁数</param>
        /// <returns>真偽値とstringリストを返す</returns>
        public static (List<string>, bool) ValueCheck(int min, int max)
        {
            ErrorMessageConstants errorMessages = new ErrorMessageConstants
            {
                ItemNameMessageList = new List<string>()
            };
            bool result = true;

            switch (min, max)
            {
                case (CommonConstants.ID_MIN_DIGITS, CommonConstants.ID_MAX_DIGITS):
                    errorMessages.ItemNameMessageList.Add(ErrorMessageConstants.ID_MESSAGE);
                    break;
                case (CommonConstants.NAME_MIN_DIGITS, CommonConstants.NAME_MAX_DIGITS):
                    errorMessages.ItemNameMessageList.Add(ErrorMessageConstants.NAME_MESSAGE);
                    break;
                case (CommonConstants.BIRTH_DAY_MIN_DIGITS, CommonConstants.BIRTH_DAY_MAX_DIGITS):
                    errorMessages.ItemNameMessageList.Add(ErrorMessageConstants.BIRTHDAY_MESSAGE);
                    break;
                case (CommonConstants.SALARY_MIN_DIGITS, CommonConstants.SALARY_MAX_DIGITS):
                    errorMessages.ItemNameMessageList.Add(ErrorMessageConstants.BASE_SALARY_MESSAGE);
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
        /// <remarks>該当cdが00かどうかで条件分岐する</remarks>
        /// <param name="affiliation">部署情報</param>
        /// <returns>判定に応じて必要値を格納する</returns>
        public static string AffiliationNmCheck(AffiliationDAO affiliation)
        {
            if (affiliation.BrunchCd != CommonConstants.AFFILIATION_CHECK_VALUE)
            {
                return affiliation.BrunchNm;
            };
            if (affiliation.GroupCd != CommonConstants.AFFILIATION_CHECK_VALUE)
            {
                return affiliation.GroupNm;
            };
            return affiliation.ManagementNm;
        }

        /// <summary>
        /// 値判別メソッド
        /// </summary>
        /// <remarks>入力された値が数値化文字列か判別する</remarks>
        /// <param name="targetValue">入力値</param>
        /// <returns>真偽値</returns>
        public static bool NumOrCharaJudge(string targetValue , bool nullPatternResult)
        {
            if(string.IsNullOrEmpty(targetValue))
            {
                return nullPatternResult;
            }

            char[] removeChars = new char[] {'.','/'};
            if (targetValue.Contains(".") || targetValue.Contains("/"))
            {
                foreach (char c in removeChars)
                {
                    targetValue = targetValue.Replace(c.ToString(), "");
                }
            }
            return int.TryParse(targetValue , out _);
        }

        /// <summary>
        /// 日時が存在するか判定するメソッド
        /// </summary>
        /// <remarks>生年月日の判定を行う</remarks>
        /// <param name="targetTime">入力された生年月日</param>
        /// <returns>真偽値を返す</returns>
        public static bool DateTimeJudge(string targetTime)
        {
            if (string.IsNullOrEmpty(targetTime))
            {
                return true;
            }
            return DateTime.TryParse(targetTime, out _);
        }
    }
}
