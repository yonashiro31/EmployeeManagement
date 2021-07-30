using EmployeeManagement.Helper.Interface;
using EmployeeManagement.Judge;
using EmployeeManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Helper
{
    /// <summary>
    /// インターフェースクラス
    /// </summary>
    /// <remarks>
    /// EV0001Helperのインターフェース
    /// </remarks>
    public class EV0001Helper : IEV0001Helper
    {
        /// <summary>
        /// インターフェースクラス
        /// </summary>
        /// <remarks>
        /// EV0001Helperのインターフェース
        /// </remarks>
        public SCRN0001ViewModel Init()
        {
            SCRN0001ViewModel SCRN1ViewModelinstance = new SCRN0001ViewModel();
            return SCRN1ViewModelinstance;
        }

    }
}
