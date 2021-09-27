namespace EmployeeManagement.ViewModel
{
    /// <summary>
    /// 項目判別単項目チェック用リストクラス
    /// </summary>
    /// <remarks>
    /// 未入力単項目チェック用のプロパティを宣言する
    /// </remarks>
    public class JudgeTargetList
    {
        /// <summary>
        /// NullJudgneListModelのコンストラクタ
        /// </summary>
        /// <remarks>社員情報を格納する</remarks>
        /// <param name="employeeDate">社員情報</param>
        /// <param name="inputValue">入力項目名</param>
        public JudgeTargetList(string employeeDate , string inputValue)
        {
            EmployeeDate = employeeDate;
            InputName = inputValue;
        }
        /// <summary>社員情報プロパティ</summary>
        /// <remarks>未入力判定用の社員情報</remarks>
        /// <value>社員情報プロパティ</value>
        public string EmployeeDate { get; set; }
        public string InputName { get; set; }
    }
}




