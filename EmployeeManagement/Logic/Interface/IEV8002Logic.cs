using EmployeeManagement.LogicDTO;
using System.Collections.Generic;

namespace EmployeeManagement.Session.Interface
{
    /// <summary>
    /// EV8002Logicのインターフェース
    /// </summary>
    /// <remarks>部署情報の取得を行う</remarks>
    public interface IEV8002Logic
    {
        /// <summary>
        /// 部署情報取得メソッド
        /// </summary>
        /// <returns>入力値に応じた社員情報を取得する</returns>
        public List<AffiliationDAO> FindAll();
    }
}
