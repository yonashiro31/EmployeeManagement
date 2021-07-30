using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Judge
{
    /// <summary>
    /// 入力値の判定を行う
    /// </summary>
    /// <remarks>
    /// 入力値の判定を行う
    /// </remarks>
    public class valueJudge
    {
        /// <summary>
        /// 入力値の判定を行う
        /// </summary>
        /// <remarks>
        /// 入力値の判定を行う
        /// </remarks>
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
