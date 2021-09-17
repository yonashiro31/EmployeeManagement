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
        public const string ID_MESSAGE = "社員ID";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>部署</remarks>
        public const string AF_MESSAGE = "部署";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>役職</remarks>
        public const string POSI_MESSAGE = "役職";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>氏名</remarks>
        public const string NAME_MESSAGE = "氏名";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>性別</remarks>
        public const string GENDER_MESSAGE = "性別";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>生年月日</remarks>
        public const string BIRTHDAY_MESSAGE = "生年月日";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>基本給料</remarks>
        public const string BASE_SALARY_MESSAGE = "基本給料";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>必須項目メッセージ</remarks>
        public const string NULL_MESSAGE = "は必須です";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>指定桁数メッセージ</remarks>
        public const string LENGTH_MESSAGE = "は指定桁数で入力してください。";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>登録済みメッセージ</remarks>
        public const string EmpIdDuplication = "既に登録済みの社員IDです。";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>マスタエラーメッセージ</remarks>
        public const string MASTA_CORRELATION_MESSAGE = "マスタに存在しない";
        /// <summary>エラーメッセージ用定数</summary>
        /// <remarks>指定エラーメッセージ</remarks>
        public const string MASTA_CORRELATION_MESSAGE_2 = "を指定しています。";

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
                ID_MESSAGE,
                AF_MESSAGE,
                POSI_MESSAGE,
                NAME_MESSAGE,
                GENDER_MESSAGE,
                BIRTHDAY_MESSAGE,
                BASE_SALARY_MESSAGE
            };

            InstructionMessageList = new List<string>
            {
                NULL_MESSAGE,
                LENGTH_MESSAGE
            };

            CorrelationErrorList = new List<string>
            {
                EmpIdDuplication,
                MASTA_CORRELATION_MESSAGE,
                MASTA_CORRELATION_MESSAGE_2
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
