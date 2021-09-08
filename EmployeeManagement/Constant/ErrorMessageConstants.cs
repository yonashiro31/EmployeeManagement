using EmployeeManagement.ViewModel;
using System.Collections.Generic;

namespace EmployeeManagement.Constants
{
    /// <summary>
    /// エラーメッセージ定数クラス
    /// </summary>
    /// <remarks>
    /// エラーメッセージに利用する文字列を宣言する
    /// </remarks>
    public class ErrorMessageConstants
    {
        /// <summary>
        /// エラーメッセージを格納するリストを用意するコンストラクタ
        /// </summary>
        /// <remarks>
        /// エラーメッセージを格納するリストを用意する
        /// </remarks>
        public ErrorMessageConstants()
        {
            itemNameMessageList = new List<string>();
            itemNameMessageList.Add(IdMessage);
            itemNameMessageList.Add(AfMessage);
            itemNameMessageList.Add(PosiMessage);
            itemNameMessageList.Add(NameMessage);
            itemNameMessageList.Add(GenderMessage);
            itemNameMessageList.Add(BirthDayMessage);
            itemNameMessageList.Add(BaseSalaryMessage);

            instructionMessageList = new List<string>();
            instructionMessageList.Add(NullMessage);
            instructionMessageList.Add(LengthMessage);

            correlationList = new List<string>();
            correlationList.Add(EmpIdDuplication);
            correlationList.Add(MastaCorrelation);
            correlationList.Add(MastaCorrelation2);
        }
        DisplayDinoteErrMessage errorMessage = new DisplayDinoteErrMessage();

        public List<string> itemNameMessageList { get; set; }
        public List<string> instructionMessageList { get; set; }
        public List<string> correlationList { get; set; }
        public const string IdMessage = "社員ID";
        public const string AfMessage = "部署";
        public const string PosiMessage = "役職";
        public const string NameMessage = "氏名";
        public const string GenderMessage = "性別";
        public const string BirthDayMessage = "生年月日";
        public const string BaseSalaryMessage = "基本給料";
        public const string NullMessage = "は必須です";
        public const string LengthMessage = "は指定桁数で入力してください。";
        public const string EmpIdDuplication = "既に登録済みの社員IDです。";
        public const string MastaCorrelation = "マスタに存在しない";
        public const string MastaCorrelation2 = "を指定しています。";
    }
}
