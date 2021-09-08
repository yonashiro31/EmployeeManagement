using EmployeeManagement.LogicDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Session.Interface
{
    /// <summary>
    /// EV8002Logicのインターフェース
    /// </summary>
    /// <remarks>EV8002Logicのインターフェース</remarks>
    public interface IEV8002Logic
    {
        /// <summary>
        /// 部署情報取得メソッド
        /// </summary>
        /// <returns>部署情報の取得を行うメソッド</returns>
        public List<AffiliationDAO> FindAll();
    }
}
