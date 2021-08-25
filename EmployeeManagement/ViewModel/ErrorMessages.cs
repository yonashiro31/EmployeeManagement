using EmployeeManagement.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    public class ErrorMessages
    {
        /// <summary>
        /// エラーメッセージを格納するリストを用意するコンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public ErrorMessages(){
            itemNameMessageList = new List<string>();
            itemNameMessageList.Add(IdMessage);
            itemNameMessageList.Add(NameMessage);
            itemNameMessageList.Add(BirthDayMessage);
            itemNameMessageList.Add(BaseSalaryMessage);
            itemNameMessageList.Add(BaseSalaryMessage);

            instructionMessageList = new List<string>();
            instructionMessageList.Add(NullMessage);
            instructionMessageList.Add(LengthMessage);
        }
        ErrorMessageModel errorMessage = new ErrorMessageModel();
        
        public string Message ;
        public List<string> itemNameMessageList { get; set; }
        public List<string> instructionMessageList { get; set; }
        public const string IdMessage = "社員ID";
        public const string NameMessage = "氏名";
        public const string BirthDayMessage = "生年月日";
        public const string BaseSalaryMessage = "基本給料";
        public const string NullMessage =  "は必須です";
        public const string LengthMessage = "は指定桁数で入力してください。";
    }
}
