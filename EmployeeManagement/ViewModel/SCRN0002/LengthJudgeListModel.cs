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
        public LengthJudgeListModel(string employeeDate, int maxJudgedigit)
        {
            EmployeeDate = employeeDate;
            MaxJudgedigit = maxJudgedigit;
        }

        public string EmployeeDate { get; set; }
        public int MinJudgedigit { get; set; }
        public int MaxJudgedigit { get; set; }
    }
}
