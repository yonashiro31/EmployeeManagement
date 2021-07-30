using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    /// <summary>
    /// エラー文を格納するクラス
    /// </summary>
    /// <remarks>
    /// エラー文を格納する
    /// </remarks>
    public class ErrorMessageModel
    {
        //変数名など修正予
        public List<string> errorMessage = new List<string>() {
           "エラー文",
           "era---"
           };
        
    }
}
