using EmployeeManagement.Helper.Interface;
using EmployeeManagement.Judge;
using EmployeeManagement.Logic.Interface;
using EmployeeManagement.LogicDTO;
using EmployeeManagement.Session.Interface;
using EmployeeManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Helper
{
    /// <summary>
    /// SCRN0003ヘルパークラス
    /// </summary>
    /// <remarks>
    /// 初期表示、照会・更新等各処理の補助を行う
    /// </remarks>
    public class EV0003Helper : IEV0003Helper
    {
        /// <summary>EV8001Logicのヘルパー</summary>
        /// <remarks>EV8001Logicのヘルパー</remarks>
        private readonly IEV8001Logic _ev8001Logic = null;
        /// <summary>EV8002Logicのヘルパー</summary>
        /// <remarks>EV8002Logicのヘルパー</remarks>
        private readonly IEV8002Logic _ev8002Logic = null;
        /// <summary>EV8003Logicのヘルパー</summary>
        /// <remarks>EV8003Logicのヘルパー</remarks>
        private readonly IEV8003Logic _ev8003Logic = null;
        /// <summary>
        /// EV0003Helperのコンストラクタ
        /// </summary>
        /// <remarks>
        /// DIの実施
        /// </remarks>
        /// <param name="ev8001Logic">社員情報取得ヘルパー</param>
        /// <param name="ev8002Logic">部署取得ヘルパー</param>
        /// <param name="ev8003Logic">役職取得ヘルパー</param>
        public EV0003Helper(IEV8001Logic ev8001Logic, IEV8002Logic ev8002Logic, IEV8003Logic ev8003Logic)
        {
            _ev8001Logic = ev8001Logic;
            _ev8002Logic = ev8002Logic;
            _ev8003Logic = ev8003Logic;
        }

        /// <summary>
        /// 照会・更新画面初期表示メソッド
        /// </summary>
        /// <remarks>相関チェックを呼び出す</remarks>
        /// <param name="employeeId">入力した社員ID</param>
        /// <returns>画面に表示する値をaリストで返す</returns>
        public SCRN0003ViewModel Init(string employeeId)
        {
            SCRN0003ViewModel sCRN0003ViewModel = new SCRN0003ViewModel();

            var employeeInfoList = _ev8001Logic.FindByPrimaryKey(employeeId);
            var result = CorrelationJudge.Equals(employeeInfoList, employeeId);
           

            return sCRN0003ViewModel;
        }


        /// <summary>
        /// 相関チェックの呼び出しメソッド
        /// </summary>
        /// <remarks>相関チェックの結果に応じてエラーメッセージを格納する</remarks>
        /// <param name="employeeInfoList">DB取得値</param>
        /// <param name="employeeId">入力した社員ID</param>
        /// <returns>エラーメッセージリストを返却する</returns>
        public List<DisplayViewErrMessage> SetCorrelationErrMessage(List<EmployeeInfoDAO> employeeInfoList, string employeeId)
        {
            var errorMessageList = new List<DisplayViewErrMessage>();
            if (employeeInfoList.Any(item => item.EmployeeID.Contains(employeeId)))
            {

            }

            return errorMessageList;
        }
    }
}
