using EmployeeManagement.ViewModel;
using System.Collections.Generic;

namespace EmployeeManagement.Constants
{
    /// <summary>
    /// エラーメッセージ定数クラス
    /// </summary>
    /// <remarks>
    /// エラーメッセージ用の定数を宣言し、リストに格納する
    /// </remarks>
    public class ErrorMessageConstants
    {
        /// <summary>
        /// ErrorMessageConstantsのコンストラクタ
        /// </summary>
        /// <remarks>
        /// エラーメッセージを格納するリストの宣言と格納を行う
        /// </remarks>
        public ErrorMessageConstants()
        {
            ItemNameMessageList = new List<string>();
            ItemNameMessageList.Add(IdMessage);
            ItemNameMessageList.Add(AfMessage);
            ItemNameMessageList.Add(PosiMessage);
            ItemNameMessageList.Add(NameMessage);
            ItemNameMessageList.Add(GenderMessage);
            ItemNameMessageList.Add(BirthDayMessage);
            ItemNameMessageList.Add(BaseSalaryMessage);

            InstructionMessageList = new List<string>();
            InstructionMessageList.Add(NullMessage);
            InstructionMessageList.Add(LengthMessage);

            CorrelationList = new List<string>();
            CorrelationList.Add(EmpIdDuplication);
            CorrelationList.Add(MastaCorrelation);
            CorrelationList.Add(MastaCorrelation2);
        }
        DisplayViewErrMessage errorMessage = new DisplayViewErrMessage();
        
        public List<string> ItemNameMessageList { get; set; }
        public List<string> InstructionMessageList { get; set; }
        public List<string> CorrelationList { get; set; }
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
