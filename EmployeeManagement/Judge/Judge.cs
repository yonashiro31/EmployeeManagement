using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Judge
{
    public class valueJudge
    {

        public static string enteredValueJudge(string val)
        {
            //真偽を返す方がよい
            if(val == string.Empty) {
                return "error";
            }
            return "notError";
            
        }

    }
}
