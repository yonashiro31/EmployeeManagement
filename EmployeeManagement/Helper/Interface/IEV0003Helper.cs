using EmployeeManagement.LogicDTO;
using EmployeeManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Helper.Interface
{
    /// <summary>
    /// EV0003Helperインターフェース
    /// </summary>
    /// <remarks>
    /// Controllerの補助を行う
    /// </remarks>
    public interface IEV0003Helper
    {
        /// <summary>
        /// 初期表示メソッド
        /// </summary>
        /// <remarks>
        /// 初期表示に必要な処理を行う
        /// </remarks>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public SCRN0003ViewModel Init(string employeeId);
    }
}
