using EmployeeManagement.LogicDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Session.Interface
{
    public interface IEV8002Logic
    {
        public List<AffiliationDAO> FindAll();
    }
}
