using EmployeeManagement.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    public class ErrorMessage
    {

        ErrorMessageModel errorMessage = new ErrorMessageModel();
        
        public string Message ;

        public const string IdMessage = "社員ID";
        public const string NameMessage = "氏名";
        public const string BirthDayMessage = "生年月日";
        public const string BaseSalaryMessage = "基本給料";
        public const string NullMessage =  "は必須です";
        public const string LengthMessage = "は指定桁数で入力してください。";
    }
}
