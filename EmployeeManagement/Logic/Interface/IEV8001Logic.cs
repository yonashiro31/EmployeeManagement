using EmployeeManagement.LogicDTO;
using System.Collections.Generic;

namespace EmployeeManagement.Logic.Interface
{
    /// <summary>
    /// EV8001Logicのインターフェース
    /// </summary>
    /// <remarks>社員情報取得と登録メソッドのインターフェース</remarks>
    public interface IEV8001Logic
    {
        public List<EmployeeInfoDAO> FindByPrimaryKey(string enteredEmployeeId);
        public void Register(EmployeeInfoDAO entryValues);
    }
}
