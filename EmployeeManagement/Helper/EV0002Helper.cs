using EmployeeManagement.Judge;
using EmployeeManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Helper
{
    public class EV0002Helper : IEV0002Helper
    {
        public SCRN0002ViewModel methodmei()
        {
            ValueJudge judge = new ValueJudge();
            SCRN0002ViewModel SCRN0002ViewModelInstance = new SCRN0002ViewModel();
      
            return SCRN0002ViewModelInstance;
        }
    }
}
