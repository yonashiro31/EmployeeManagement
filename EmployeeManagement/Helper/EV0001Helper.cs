using EmployeeManagement.Helper.Interface;
using EmployeeManagement.Judge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Helper
{
    public class EV0001Helper : IEV0001Helper
    {
        public string Init()
        {
            return string.Empty;
        }
       
        public string Name {

            set { string str = "aaaa"; }
            get {return "str"; }
            }
            
    }
}
