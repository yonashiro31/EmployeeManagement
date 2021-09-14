using EmployeeManagement.LogicDTO;
using System.Collections.Generic;

namespace EmployeeManagement.Logic.Interface
{
    /// <summary>
    /// EV8001Logicのインターフェース
    /// </summary>
    /// <remarks>社員情報取得メソッドと登録メソッドのインターフェース</remarks>
    public interface IEV8001Logic
    {
        /// <summary>
        /// 社員情報取得メソッド
        /// </summary>
        /// <param name="enteredEmployeeId">社員ID</param>
        /// <returns>SQLに接続し入力したIDに対応する社員情報を取得する</returns>
        public List<EmployeeInfoDAO> FindByPrimaryKey(string enteredEmployeeId);
        /// <summary>
        /// SQL登録メソッド
        /// </summary>
        /// <param name="entryValues">登録用の値</param>
        /// <remarks>入力情報をSQLに登録する</remarks>
        public void Register(EmployeeInfoDAO entryValues);
    }
}
