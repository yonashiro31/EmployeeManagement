using EmployeeManagement.Logic.Interface;
using EmployeeManagement.SessionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Judge
{
    /// <summary>
    /// 
    /// </summary>
    public class CorrelationJudge
    {     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeInfoList"></param>
        /// <returns></returns>
        public bool CorrelationIdJudge(List<EmployeeInfoDAO> employeeInfoList)
        {
            return employeeInfoList.Any(item => item.EmployeeID != null);
        }
       
    }
}
