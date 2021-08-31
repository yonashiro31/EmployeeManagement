using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Session.Interface
{
    public interface IDateAccess
    {
        public List<string> DateSelect();
    }
}
