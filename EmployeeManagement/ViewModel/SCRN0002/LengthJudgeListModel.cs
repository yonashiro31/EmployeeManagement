namespace EmployeeManagement.ViewModel
{
    /// <summary>
    /// 桁数チェック時用リストクラス
    /// </summary>
    /// <remarks>
    /// 桁数チェック時用に抜き出した要素を格納するプロパティを宣言する
    /// </remarks>
    public class LengthJudgeListModel
    {
        /// <summary>
        /// LengthJudgeListModelコンストラクタ
        /// </summary>
        /// <remarks>
        /// 桁数チェックに必要な情報と最大桁数を格納する
        /// </remarks>
        /// <param name="employeeDate">社員情報</param>
        /// <param name="maxJudgeDigit">最大許容桁数</param>
        /// <param name="mixJudgeDigit">最大許容桁数</param>
        public LengthJudgeListModel(string employeeDate, int maxJudgeDigit , int minJudgeDigit)
        {
            EmployeeDate = employeeDate;
            MaxJudgedigit = maxJudgeDigit;
            MinJudgedigit = minJudgeDigit;
        }

        /// <summary>社員情報プロパティ</summary>
        /// <remarks>桁数判定用の社員情報</remarks>
        /// <value>社員情報プロパティ</value>
        public string EmployeeDate { get; set; }
        /// <summary>最小桁数プロパティ</summary>
        /// <remarks>桁数判定用の最小許容桁数</remarks>
        /// <value>最小許容桁数プロパティ</value>
        public int MinJudgedigit { get; set; }
        /// <summary>最大桁数プロパティ</summary>
        /// <remarks>桁数判定用の最大許容桁数</remarks>
        /// <value>最大許容桁数プロパティ</value>
        public int MaxJudgedigit { get; set; }
    }
}
