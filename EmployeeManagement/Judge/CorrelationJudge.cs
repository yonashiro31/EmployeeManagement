using EmployeeManagement.LogicDTO;
using EmployeeManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Judge
{
    /// <summary>
    /// SQL接続を必要とするチェッククラス
    /// </summary>
    /// <remarks>IDチェック、部署役職コードチェックを行う</remarks>
    public class CorrelationJudge
    {     
        /// <summary>
        /// 社員登録ID相関チェックメソッド
        /// </summary>
        /// <param name="employeeInfoList">社員情報リスト</param>
        /// <returns></returns>
        public bool IdCorrelationIdJudge(List<EmployeeInfoDAO> employeeInfoList)
        {
            return employeeInfoList.Any(item => item.EmployeeID != null);
        }
        /// <summary>
        /// 部署コードチェック
        /// </summary>
        /// <param name="employeeInfoList">SQL取得リスト</param>
        /// <param name="sCRN0002ViewModel">入力値</param>
        /// <returns>入力値と取得した部署コードを比較判定する</returns>
        public bool AfCorrelationJudge(List<EmployeeInfoDAO> employeeInfoList,SCRN0002ViewModel sCRN0002ViewModel)
        {
           return employeeInfoList.Any(item => item.AffiliationCd == sCRN0002ViewModel.AffiliationCd);
        }

        /// <summary>
        /// 役職コードチェック
        /// </summary>
        /// <param name="employeeInfoList">SQL取得リスト</param>
        /// <param name="sCRN0002ViewModel">入力値</param>
        /// <returns>入力値と取得した役職コードを比較判定する</returns>
        public bool PosiCorrelationJudge(List<EmployeeInfoDAO> employeeInfoList, SCRN0002ViewModel sCRN0002ViewModel)
        {
            return employeeInfoList.Any(item => item.PositionCd == sCRN0002ViewModel.PositionCd);
        }
    }
}
