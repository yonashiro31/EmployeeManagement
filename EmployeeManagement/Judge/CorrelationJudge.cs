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
        /// <param name="employeeInfoList">入力した社員IDに対応する社員情報リスト</param>
        /// <returns>入力した社員IDがSQLに存在するかの判定処理を行う</returns>
        public static bool IdCorrelationIdJudge(List<EmployeeInfoDAO> employeeInfoList)
        {
            return employeeInfoList.Any(item => item.EmployeeID != null);
        }
        /// <summary>
        /// 部署コードチェック
        /// </summary>
        /// <param name="employeeInfoList">入力した社員IDに対応する社員情報リスト</param>
        /// <param name="sCRN0002ViewModel">入力値</param>
        /// <returns>入力値と取得した部署コードを比較判定する</returns>
        public static bool AfCorrelationJudge(List<EmployeeInfoDAO> employeeInfoList,string inputAffiliationCd)
        {
           return employeeInfoList.Any(item => item.AffiliationCd == inputAffiliationCd);
        }

        /// <summary>
        /// 役職コードチェック
        /// </summary>
        /// <param name="employeeInfoList">入力した社員IDに対応する社員情報リスト</param>
        /// <param name="sCRN0002ViewModel">入力値</param>
        /// <returns>入力値と取得した役職コードを比較判定する</returns>
        public static bool PosiCorrelationJudge(List<EmployeeInfoDAO> employeeInfoList, string inputPositionCd)
        {
            return employeeInfoList.Any(item => item.PositionCd == inputPositionCd);
        }
    }
}
