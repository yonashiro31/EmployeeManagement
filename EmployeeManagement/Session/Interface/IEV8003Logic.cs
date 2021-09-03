using EmployeeManagement.SessionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Session.Interface
{
    public interface IEV8003Logic
    {
        public List<PositionDO> FindAll();
    }
}
