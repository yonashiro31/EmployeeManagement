using EmployeeManagement.Judge;
using EmployeeManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Helper
{
    /// <summary>
    /// SCRN0002を補助するクラス
    /// </summary>
    /// <remarks>
    /// SCRN0002を補助するクラス
    /// </remarks>
    public class EV0002Helper : IEV0002Helper
    {
        /// <summary>
        /// メソッド
        /// </summary>
        /// <returns></returns>
        public SCRN0002ViewModel methodmei()
        {
            ErrorMessageModel errorMessageModel = new ErrorMessageModel();
            ValueJudge judge = new ValueJudge();
            SCRN0002ViewModel SCRN0002ViewModelInstance = new SCRN0002ViewModel();
            judge.Judge(SCRN0002ViewModelInstance);
            return SCRN0002ViewModelInstance;
        }
    }
}
