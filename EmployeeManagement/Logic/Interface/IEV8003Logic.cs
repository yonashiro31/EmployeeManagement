using EmployeeManagement.LogicDTO;
using System.Collections.Generic;

namespace EmployeeManagement.Session.Interface
{
    /// <summary>
    /// EV8003Logicのインターフェース
    /// </summary>
    /// <remarks>EV8003Logicのインターフェース</remarks>
    public interface IEV8003Logic
    {
        /// <summary>
        /// 役職情報の取得を行うメソッド
        /// </summary>
        /// <returns>役職情報の取得を行うメソッド</returns>
        public List<PositionDAO> FindAll();
    }
}
