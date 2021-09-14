using EmployeeManagement.LogicDTO;
using System.Collections.Generic;

namespace EmployeeManagement.Session.Interface
{
    /// <summary>
    /// EV8003Logicのインターフェース
    /// </summary>
    /// <remarks>役職情報取得メソッドの宣言を行う</remarks>
    public interface IEV8003Logic
    {
        /// <summary>
        /// 役職情報の取得を行うメソッド
        /// </summary>
        /// <returns>SQLに接続し役職情報の全取得を行う</returns>
        public List<PositionDAO> FindAll();
    }
}
