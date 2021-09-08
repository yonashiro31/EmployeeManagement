using EmployeeManagement.LogicDTO;
using EmployeeManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Judge
{
    /// <summary>
    /// SQL接続を必要とするチェッククラス
    /// </summary>
    public class CorrelationJudge
    {     
        /// <summary>
        /// 社員登録ID相関チェックメソッド
        /// </summary>
        /// <param name="employeeInfoList"></param>
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
        /// <returns></returns>
        public bool AfCorrelationJudge(List<EmployeeInfoDAO> employeeInfoList,SCRN0002ViewModel sCRN0002ViewModel)
        {
           return employeeInfoList.Any(item => item.AffiliationCd == sCRN0002ViewModel.AffiliationCd);
        }

        /// <summary>
        /// 役職コードチェック
        /// </summary>
        /// <param name="employeeInfoList">SQL取得リスト</param>
        /// <param name="sCRN0002ViewModel">入力値</param>
        /// <returns></returns>
        public bool PosiCorrelationJudge(List<EmployeeInfoDAO> employeeInfoList, SCRN0002ViewModel sCRN0002ViewModel)
        {
            return employeeInfoList.Any(item => item.PositionCd == sCRN0002ViewModel.PositionCd);
        }
    }
}
