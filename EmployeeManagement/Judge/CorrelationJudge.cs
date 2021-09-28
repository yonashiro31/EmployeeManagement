using EmployeeManagement.LogicDTO;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Judge
{
    /// <summary>
    /// SQL接続を必要とするチェッククラス
    /// </summary>
    /// <remarks>IDチェック、部署役職コードチェックを行う</remarks>
    public static class CorrelationJudge
    {
        /// <summary>
        /// 社員登録ID相関チェックメソッド
        /// </summary>
        /// <remarks>入力した社員IDがSQLに存在するかの判定処理を行う</remarks>
        /// <param name="employeeInfoList">入力した社員IDに対応する社員情報リスト</param>
        /// <returns>真偽値を返す</returns>
        public static bool IdCorrelationIdJudge(List<EmployeeInfoDAO> employeeInfoList)
        {
            if(employeeInfoList.Any(item => int.TryParse(item.EmployeeID, out _)))
            {
                return employeeInfoList.Any(item => string.IsNullOrEmpty(item.EmployeeID));
            }
            return true;
        }
        /// <summary>
        /// 部署コードチェック
        /// </summary>
        /// <remarks>入力値と取得した部署コードを比較判定する</remarks>
        /// <param name="employeeInfoList">DBから取得した部署情報リスト</param>
        /// <param name="inputAffiliationCd">入力された部署コード</param>
        /// <returns>真偽値を返す</returns>
        public static bool AfCorrelationJudge(List<AffiliationDAO> employeeInfoList,string inputAffiliationCd)
        {
           return employeeInfoList.Any(item => item.AffiliationCd == inputAffiliationCd);
        }

        /// <summary>
        /// 役職コードチェック
        /// </summary>
        /// <remarks>入力値と取得した役職コードを比較判定する</remarks>
        /// <param name="employeeInfoList">DBから取得した役職リスト</param>
        /// <param name="inputPositionCd">入力された役職コード</param>
        /// <returns>真偽値を返す</returns>
        public static bool PosiCorrelationJudge(List<PositionDAO> employeeInfoList, string inputPositionCd)
        {
            return employeeInfoList.Any(item => item.PositionCd == inputPositionCd);
        }
    }
}
