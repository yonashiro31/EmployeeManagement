namespace EmployeeManagement.ViewModel
{
    /// <summary>
    /// 未入力単項目チェック用リストクラス
    /// </summary>
    /// <remarks>
    /// 未入力単項目チェック用のプロパティを宣言する
    /// </remarks>
    public class NullJudgeListModel
    {
        /// <summary>
        /// NullJudgneListModelのコンストラクタ
        /// </summary>
        /// <remarks>社員情報を格納する</remarks>
        /// <param name="employeeDate">社員情報</param>
        public NullJudgeListModel(string employeeDate)
        {
            EmployeeDate = employeeDate;
        }
        /// <summary>社員情報プロパティ</summary>
        /// <remarks>未入力判定用の社員情報</remarks>
        /// <value>社員情報プロパティ</value>
        public string EmployeeDate { get; set; }
    }
}




