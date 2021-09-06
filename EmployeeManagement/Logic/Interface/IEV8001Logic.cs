using EmployeeManagement.SessionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Logic.Interface
{
    public interface IEV8001Logic
    {
        public List<EmployeeInfoDAO> FindByPrimaryKey(string enteredEmployeeId);
    }
}
