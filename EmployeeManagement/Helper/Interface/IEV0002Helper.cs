using EmployeeManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Helper
{
    /// <summary>
    /// EV0001Helperインターフェース
    /// </summary>
    /// <remarks>
    /// Controllerの補助を行う
    /// </remarks>
    public interface IEV0002Helper
    {
        /// <summary>
        /// 初期表示メソッド
        /// </summary>
        /// <remarks>
        /// 初期表示メソッド
        /// </remarks>
        public SCRN0002RequestModel Init();

        /// <summary>
        /// 新規登録メソッド
        /// </summary>
        /// <param name="entry">新規登録時情報</param>
        /// <returns>
        /// 新規登録メソッド
        /// </returns>
        public SCRN0002ViewModel Entry(SCRN0002ViewModel entry);
    }
}