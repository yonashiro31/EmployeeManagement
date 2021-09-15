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
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>社員ID</remarks>
        public const string IdMessage = "社員ID";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>部署</remarks>
        public const string AfMessage = "部署";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>役職</remarks>
        public const string PosiMessage = "役職";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>氏名</remarks>
        public const string NameMessage = "氏名";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>性別</remarks>
        public const string GenderMessage = "性別";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>生年月日</remarks>
        public const string BirthDayMessage = "生年月日";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>基本給料</remarks>
        public const string BaseSalaryMessage = "基本給料";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>必須項目メッセージ</remarks>
        public const string NullMessage = "は必須です";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>指定桁数メッセージ</remarks>
        public const string LengthMessage = "は指定桁数で入力してください。";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>登録済みメッセージ</remarks>
        public const string EmpIdDuplication = "既に登録済みの社員IDです。";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>マスタエラーメッセージ</remarks>
        public const string MastaCorrelation = "マスタに存在しない";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>指定エラーメッセージ</remarks>
        public const string MastaCorrelation2 = "を指定しています。";

        /// <summary>
        /// ErrorMessageConstantsのコンストラクタ
        /// </summary>
        /// <remarks>
        /// エラーメッセージを格納するリストの宣言と格納を行う
        /// </remarks>
        public ErrorMessageConstants()
        {
            ItemNameMessageList = new List<string>
            {
                IdMessage,
                AfMessage,
                PosiMessage,
                NameMessage,
                GenderMessage,
                BirthDayMessage,
                BaseSalaryMessage
            };

            InstructionMessageList = new List<string>
            {
                NullMessage,
                LengthMessage
            };

            CorrelationErrorList = new List<string>
            {
                EmpIdDuplication,
                MastaCorrelation,
                MastaCorrelation2
            };
        }
        /// <summary>相関チェックエラーメッセージリストプロパティ</summary>
        /// <remarks>相関チェック用エラーメッセージを格納する</remarks>
        /// <value>相関チェックエラーメッセージリストプロパティ</value>
        public List<string> CorrelationErrorList { get; set; }
        /// <summary>エラーメッセージリストプロパティ</summary>
        /// <remarks>エラーメッセージ項目表示部分を格納する</remarks>
        /// <value>エラーメッセージリストプロパティ</value>
        public List<string> ItemNameMessageList { get; set; }
        /// <summary>エラーメッセージリストプロパティ</summary>
        /// <remarks>エラーメッセージ種別表示部分を格納する</remarks>
        /// <value>エラーメッセージリストプロパティ</value>
        public List<string> InstructionMessageList { get; set; }       
    }
}
